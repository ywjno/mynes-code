﻿/* This file is part of My Nes
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

namespace MyNes.Core
{
    [BoardInfo("C&E", 245, true, true)]
    [NotImplementedWell("Mapper 245\nGraphic glitches, maybe chr switches.")]
    class Mapper245 : Board
    {
        private bool flag_c;
        private bool flag_p;
        private int address_8001;
        private int[] chr_reg;
        private int[] prg_reg;
        private int prg_or;
        // IRQ
        private bool irq_enabled;
        private byte irq_counter;
        private int old_irq_counter;
        private byte irq_reload;
        private bool irq_clear;
        private bool mmc3_alt_behavior;

        public override void HardReset()
        {
            base.HardReset();
            // Flags
            flag_c = flag_p = false;
            address_8001 = 0;
            prg_reg = new int[4];
            prg_or = 0;
            prg_reg[0] = 0;
            prg_reg[1] = 1;
            prg_reg[2] = prg_08K_rom_mask - 1;
            prg_reg[3] = prg_08K_rom_mask;

            // CHR
            chr_reg = new int[6];
            for (int i = 0; i < 6; i++)
                chr_reg[i] = 0;

            SetupPRG();
            SetupCHR();
            // IRQ
            irq_enabled = false;
            irq_counter = 0;
            irq_reload = 0xFF;
            old_irq_counter = 0;
            // mmc3_alt_behavior = false;
            irq_clear = false;
        }
        public override void WritePRG(ref int address, ref byte data)
        {
            switch (address & 0xE001)
            {
                case 0x8000:
                    {
                        address_8001 = data & 0x7;
                        flag_c = (data & 0x80) != 0;
                        flag_p = (data & 0x40) != 0;
                        SetupCHR();
                        SetupPRG();
                        break;
                    }
                case 0x8001:
                    {
                        switch (address_8001)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5: chr_reg[address_8001] = data; SetupCHR(); break;
                            case 6: prg_reg[0] = data & 0x3F; SetupPRG(); break;
                            case 7: prg_reg[1] = data & 0x3F; SetupPRG(); break;
                        }
                        break;
                    }
                case 0xA000:
                    {
                        if (default_mirroring != Mirroring.Full)
                        {
                            base.SwitchNMT((data & 1) == 1 ? Mirroring.Horz : Mirroring.Vert);
                        }
                        break;
                    }
                case 0xA001:
                    {
                        TogglePRGRAMEnable((data & 0x80) != 0);
                        TogglePRGRAMWritableEnable((data & 0x40) == 0);
                        break;
                    }
                case 0xC000: irq_reload = data; break;
                case 0xC001: if (mmc3_alt_behavior) irq_clear = true; irq_counter = 0; break;
                case 0xE000: irq_enabled = false; NesEmu.IRQFlags &= ~NesEmu.IRQ_BOARD; break;
                case 0xE001: irq_enabled = true; break;
            }
        }
        private void SetupCHR()
        {
            if (chr_01K_rom_count > 0)
            {
                // If CHR ROM is presented, use normal MMC3 mode.
                if (!flag_c)
                {
                    base.Switch02KCHR(chr_reg[0] >> 1, 0x0000, chr_01K_rom_count > 0);
                    base.Switch02KCHR(chr_reg[1] >> 1, 0x0800, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[2], 0x1000, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[3], 0x1400, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[4], 0x1800, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[5], 0x1C00, chr_01K_rom_count > 0);
                }
                else
                {
                    base.Switch02KCHR(chr_reg[0] >> 1, 0x1000, chr_01K_rom_count > 0);
                    base.Switch02KCHR(chr_reg[1] >> 1, 0x1800, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[2], 0x0000, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[3], 0x0400, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[4], 0x0800, chr_01K_rom_count > 0);
                    base.Switch01KCHR(chr_reg[5], 0x0C00, chr_01K_rom_count > 0);
                }
            }
            else
            {
                // With CHR RAM mode, flag c can "flip" the left/right pattern tables.
                if (!flag_c)
                {
                    Switch04KCHR(0, 0x0000, false);
                    Switch04KCHR(1, 0x1000, false);
                }
                else
                {
                    Switch04KCHR(1, 0x0000, false);
                    Switch04KCHR(0, 0x1000, false);
                }
            }
        }
        private void SetupPRG()
        {
            prg_or = (chr_reg[0] & 0x2) << 5;
            base.Switch08KPRG(prg_reg[flag_p ? 2 : 0] | prg_or, 0x8000, true);
            base.Switch08KPRG(prg_reg[1] | prg_or, 0xA000, true);
            base.Switch08KPRG(prg_reg[flag_p ? 0 : 2] | prg_or, 0xC000, true);
            base.Switch08KPRG(prg_reg[3] | prg_or, 0xE000, true);
        }
        // The scanline timer, clocked on PPU A12 raising edge ...
        public override void OnPPUA12RaisingEdge()
        {
            old_irq_counter = irq_counter;

            if (irq_counter == 0 || irq_clear)
                irq_counter = irq_reload;
            else
                irq_counter = (byte)(irq_counter - 1);

            if ((!mmc3_alt_behavior || old_irq_counter != 0 || irq_clear) && irq_counter == 0 && irq_enabled)
                NesEmu.IRQFlags |= NesEmu.IRQ_BOARD;

            irq_clear = false;
        }
        public override void SaveState(System.IO.BinaryWriter stream)
        {
            base.SaveState(stream);
            stream.Write(flag_c);
            stream.Write(flag_p);
            stream.Write(address_8001);
            for (int i = 0; i < chr_reg.Length; i++)
                stream.Write(chr_reg[i]);
            for (int i = 0; i < prg_reg.Length; i++)
                stream.Write(prg_reg[i]);
            stream.Write(irq_enabled);
            stream.Write(irq_counter);
            stream.Write(old_irq_counter);
            stream.Write(irq_reload);
            stream.Write(irq_clear);
            stream.Write(prg_or);
        }
        public override void LoadState(System.IO.BinaryReader stream)
        {
            base.LoadState(stream);
            flag_c = stream.ReadBoolean();
            flag_p = stream.ReadBoolean();
            address_8001 = stream.ReadInt32();
            for (int i = 0; i < chr_reg.Length; i++)
                chr_reg[i] = stream.ReadInt32();
            for (int i = 0; i < prg_reg.Length; i++)
                prg_reg[i] = stream.ReadInt32();
            irq_enabled = stream.ReadBoolean();
            irq_counter = stream.ReadByte();
            old_irq_counter = stream.ReadInt32();
            irq_reload = stream.ReadByte();
            irq_clear = stream.ReadBoolean();
            prg_or = stream.ReadInt32();
        }
    }
}
