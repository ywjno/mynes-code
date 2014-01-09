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

namespace MyNes.Core.PPU
{
    public partial class PPU2C02 : IProcesserBase
    {
        // VRAM Address register
        private int vram_temp;
        private int vram_address;
        private int vram_increament;
        private bool vram_flipflop;
        private byte vram_fine;// used for scroll
        private byte reg2007buffer;// Used in $2007 register
        // Background
        private bool bkg_enabled;
        private bool bkg_clipped;
        private int bkg_patternAddress;
        // Sprites
        private bool spr_enabled;
        private bool spr_clipped;
        private int spr_patternAddress;
        private int spr_size16;
        private bool spr_0Hit;
        private bool spr_overflow;
        // Colors
        private int grayscale;
        private int emphasis;

        public void Write2000(byte value)
        {
            vram_temp = (vram_temp & 0x73FF) | ((value & 0x3) << 10);
            vram_increament = ((value & 0x4) != 0) ? 32 : 1;
            spr_patternAddress = ((value & 0x8) != 0) ? 0x1000 : 0x0000;
            bkg_patternAddress = ((value & 0x10) != 0) ? 0x1000 : 0x0000;
            spr_size16 = (value & 0x20) != 0 ? 0x0010 : 0x0008;

            bool old = nmi_enabled;
            nmi_enabled = (value & 0x80) != 0;

            if (!nmi_enabled)// NMI disable effect only at vbl set period (HClock between 1 and 3)
                CheckNMI();
            else if (vbl_flag_temp & !old)// Special case ! NMI can be enabled anytime if vbl already set
                NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.NMI, true);
        }
        public void Write2001(byte value)
        {
            grayscale = (value & 0x01) != 0 ? 0x30 : 0x3F;
            emphasis = (value & 0xE0) << 1;

            bkg_clipped = (value & 0x02) == 0;
            spr_clipped = (value & 0x04) == 0;
            bkg_enabled = (value & 0x08) != 0;
            spr_enabled = (value & 0x10) != 0;
        }
        public byte Read2002()
        {
            byte ret = 0;

            if (vbl_flag)
                ret |= 0x80;
            if (spr_0Hit)
                ret |= 0x40;
            if (spr_overflow)
                ret |= 0x20;

            vbl_flag_temp = false;
            vram_flipflop = false;

            CheckNMI();// NMI disable effect only at vbl set period (HClock between 1 and 3)

            return ret;
        }
        public void Write2003(byte value)
        {
            oam_address = value;
        }
        public void Write2004(byte value)
        {
            if (VClock < 240 && IsRenderingOn())
                value = 0xFF;
            if ((oam_address & 0x03) == 0x02)
                value &= 0xE3;
            oam_ram[oam_address++] = value;
        }
        public byte Read2004()
        {
            byte val = oam_ram[oam_address];
            if (VClock < 240 && IsRenderingOn())
            {
                if (HClock < 64)
                    val = 0xFF;
                else if (HClock < 192)
                    val = oam_ram[((HClock - 64) << 1) & 0xFC];
                else if (HClock < 256)
                    val = ((HClock & 1) == 1) ? oam_ram[0xFC] : oam_ram[((HClock - 192) << 1) & 0xFC];
                else if (HClock < 320)
                    val = 0xFF;
                else val = oam_ram[0];
            }
            return val;
        }
        public void Write2005(byte value)
        {
            if (!vram_flipflop)
            {
                vram_temp = (vram_temp & 0x7FE0) | ((value & 0xF8) >> 3);
                vram_fine = (byte)(value & 0x07);
            }
            else
            {
                vram_temp = (vram_temp & 0x0C1F) | ((value & 0x7) << 12) | ((value & 0xF8) << 2);
            }
            vram_flipflop = !vram_flipflop;
        }
        public void Write2006(byte value)
        {
            if (!vram_flipflop)
            {
                vram_temp = (vram_temp & 0x00FF) | ((value & 0x3F) << 8);
            }
            else
            {
                vram_temp = (vram_temp & 0x7F00) | value;
                vram_address = vram_temp;

                NesCore.BOARD.OnPPUAddressUpdate(vram_address);
            }
            vram_flipflop = !vram_flipflop;
        }
        public void Write2007(byte value)
        {
            Write(vram_address, value);

            vram_address = (vram_address + vram_increament) & 0x7FFF;
            NesCore.BOARD.OnPPUAddressUpdate(vram_address);
        }
        public byte Read2007()
        {
            byte returnValue;

            if ((vram_address & 0x3F00) == 0x3F00)
            {
                returnValue = (byte)(Read(vram_address) & grayscale);
                reg2007buffer = Read(vram_address & 0x2FFF);
            }
            else
            {
                returnValue = reg2007buffer;
                reg2007buffer = Read(vram_address);
            }

            vram_address = (vram_address + vram_increament) & 0x7FFF;
            NesCore.BOARD.OnPPUAddressUpdate(vram_address);
            return returnValue;
        }
        public void Write4014(byte value)
        {
            oam_dmaAddress = value << 8;
            NesCore.CPU.AssertRDY(CPU.CPU6502.RDYType.PPU);
        }
        public void DoDMA()
        {
            for (int i = 0; i < 256; i++)
            {
                byte data = NesCore.CPU.Read(oam_dmaAddress);

                NesCore.CPU.Write(0x2004, data);

                oam_dmaAddress = (++oam_dmaAddress) & 0xFFFF;
            }
        }
    }
}
