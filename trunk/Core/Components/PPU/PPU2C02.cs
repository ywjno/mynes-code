/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;

namespace MyNes.Core.PPU
{
    /// <summary>
    /// Emulates the nes ppu
    /// </summary>
    public partial class PPU2C02 : IProcesserBase
    {
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void HardReset()
        {
            base.HardReset();
            PAL = new byte[] // Miscellaneous, real NES loads values similar to these during power up
            {
               0x09, 0x01, 0x00, 0x01, 0x00, 0x02, 0x02, 0x0D, 0x08, 0x10, 0x08, 0x24, 0x00, 0x00, 0x04, 0x2C, // Bkg palette
               0x09, 0x01, 0x34, 0x03, 0x00, 0x04, 0x00, 0x14, 0x08, 0x3A, 0x00, 0x02, 0x00, 0x20, 0x2C, 0x08  // Spr palette
            };
            switch (NesCore.TV)
            {
                case TVSystem.NTSC:
                    {
                        vbl_vclock_Start = 241;//20 scanlines for VBL
                        vbl_vclock_End = 261;
                        frameEnd = 262;
                        UseOddFrame = true;
                        break;
                    }
                case TVSystem.PALB:
                    {
                        vbl_vclock_Start = 241;//70 scanlines for VBL
                        vbl_vclock_End = 311;
                        frameEnd = 312;
                        UseOddFrame = false;
                        break;
                    }
                case TVSystem.DENDY:
                    {
                        vbl_vclock_Start = 291;//51 dummy scanlines, 20 VBL's
                        vbl_vclock_End = 311;
                        frameEnd = 312;
                        UseOddFrame = false;
                        break;
                    }
            }
            oam_ram = new byte[256];
            oam_secondary = new Sprite[8];
            bkg_pixels = new int[272];
            spr_pixels = new int[256];
            grayscale = 0xF3;
            vram_flipflop = false;
            emphasis = 0;
            vram_increament = 1;
            HClock = 0;
            VClock = 0;
            EvaluationReset();
        }
        public void SetupPalette(int[] palette)
        {
            this.palette = palette;
            this.paletteIndexes = VSUnisystem.GetPalette(NesCore.RomInfo.SHA1);
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(PAL);
            stream.Write(nmi_enabled);
            stream.Write(vbl_flag);
            stream.Write(vbl_flag_temp);
            stream.Write(VClock);
            stream.Write(HClock);
            stream.Write(oddSwap);
            stream.Write(vram_temp);
            stream.Write(vram_address);
            stream.Write(vram_increament);
            stream.Write(vram_flipflop);
            stream.Write(vram_fine);
            stream.Write(reg2007buffer);
            stream.Write(bkg_enabled);
            stream.Write(bkg_clipped);
            stream.Write(bkg_patternAddress);
            stream.Write(bkg_fetch_address);
            stream.Write(bkg_fetch_nametable);
            stream.Write(bkg_fetch_attr);
            stream.Write(bkg_fetch_bit0);
            stream.Write(bkg_fetch_bit1);
            stream.Write(spr_enabled);
            stream.Write(spr_clipped);
            stream.Write(spr_patternAddress);
            stream.Write(spr_size16);
            stream.Write(spr_0Hit);
            stream.Write(spr_overflow);
            stream.Write(spr_fetch_address);
            stream.Write(spr_fetch_bit0);
            stream.Write(spr_fetch_bit1);
            stream.Write(spr_fetch_attr);
            stream.Write(oam_ram);
            for (int i = 0; i < 8; i++)
            {
                stream.Write(oam_secondary[i].attr);
                stream.Write(oam_secondary[i].name);
                stream.Write(oam_secondary[i].x);
                stream.Write(oam_secondary[i].y);
                stream.Write(oam_secondary[i].zero);
            }
            stream.Write(oam_address);
            stream.Write(oam_dmaAddress);
            stream.Write(oam_fetch_data);
            stream.Write(oam_evaluate_slot);
            stream.Write(oam_evaluate_count);
            stream.Write(grayscale);
            stream.Write(emphasis);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            stream.Read(PAL, 0, PAL.Length);
            nmi_enabled = stream.ReadBoolean();
            vbl_flag = stream.ReadBoolean();
            vbl_flag_temp = stream.ReadBoolean();
            VClock = stream.ReadInt32();
            HClock = stream.ReadInt32();
            oddSwap = stream.ReadBoolean();
            vram_temp = stream.ReadInt32();
            vram_address = stream.ReadInt32();
            vram_increament = stream.ReadInt32();
            vram_flipflop = stream.ReadBoolean();
            vram_fine = stream.ReadByte();
            reg2007buffer = stream.ReadByte();
            bkg_enabled = stream.ReadBoolean();
            bkg_clipped = stream.ReadBoolean();
            bkg_patternAddress = stream.ReadInt32();
            bkg_fetch_address = stream.ReadInt32();
            bkg_fetch_nametable = stream.ReadByte();
            bkg_fetch_attr = stream.ReadByte();
            bkg_fetch_bit0 = stream.ReadByte();
            bkg_fetch_bit1 = stream.ReadByte();
            spr_enabled = stream.ReadBoolean();
            spr_clipped = stream.ReadBoolean();
            spr_patternAddress = stream.ReadInt32();
            spr_size16 = stream.ReadInt32();
            spr_0Hit = stream.ReadBoolean();
            spr_overflow = stream.ReadBoolean();
            spr_fetch_address = stream.ReadInt32();
            spr_fetch_bit0 = stream.ReadByte();
            spr_fetch_bit1 = stream.ReadByte();
            spr_fetch_attr = stream.ReadByte();
            stream.Read(oam_ram, 0, oam_ram.Length);
            for (int i = 0; i < 8; i++)
            {
                oam_secondary[i].attr = stream.ReadByte();
                oam_secondary[i].name = stream.ReadByte();
                oam_secondary[i].x = stream.ReadByte();
                oam_secondary[i].y = stream.ReadByte();
                oam_secondary[i].zero = stream.ReadBoolean();
            }
            oam_address = stream.ReadByte();
            oam_dmaAddress = stream.ReadInt32();
            oam_fetch_data = stream.ReadByte();
            oam_evaluate_slot = stream.ReadByte();
            oam_evaluate_count = stream.ReadByte();
            grayscale = stream.ReadInt32();
            emphasis = stream.ReadInt32();
        }
    }
}
