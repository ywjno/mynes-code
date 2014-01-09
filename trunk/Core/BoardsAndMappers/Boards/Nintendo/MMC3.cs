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
using MyNes.Core;

namespace MyNes.Core.Boards
{
    abstract class MMC3 : Board
    {
        public MMC3() : base() { }
        public MMC3(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        protected bool flag_c;
        protected bool flag_p;
        protected int address_8001;
        protected int[] chr_reg;
        protected int[] prg_reg;
        protected bool SRAM_WriteProtect;
        // IRQ
        protected bool irq_enabled;
        protected byte irq_counter;
        protected byte irq_reload;
        public bool mmc3_alt_behavior;
        protected bool irq_clear;

        public override void HardReset()
        {
            base.HardReset();
            // Flags
            flag_c = flag_p = false;
            address_8001 = 0;
            SRAM_WriteProtect = false;

            prg_reg = new int[4];
            prg_reg[0] = 0;
            prg_reg[1] = 1;
            prg_reg[2] = PRGROM08KBBanksCountMask - 1;
            prg_reg[3] = PRGROM08KBBanksCountMask;
            SetupPRG();

            // CHR
            chr_reg = new int[6];
            for (int i = 0; i < 6; i++)
                chr_reg[i] = 0;

            // IRQ
            irq_enabled = false;
            irq_counter = 0;
            irq_reload = 0xFF;
            // mmc3_alt_behavior = false;
            irq_clear = false;

            if (NesCore.RomInfo.IsGameFoundOnDB)
            {
                switch (NesCore.RomInfo.DatabaseGameInfo.chip_type[0].ToLower())
                {
                    case "mmc3a": mmc3_alt_behavior = true; Console.WriteLine("Chip= MMC3 A, MMC3 IQR mode switched to RevA"); break;
                    case "mmc3b": mmc3_alt_behavior = false; Console.WriteLine("Chip= MMC3 B, MMC3 IQR mode switched to RevB"); break;
                    case "mmc3c": mmc3_alt_behavior = false; Console.WriteLine("Chip= MMC3 C, MMC3 IQR mode switched to RevB"); break;
                }
            }
        }

        public override void WritePRG(int address, byte value)
        {
            switch (address & 0xE001)
            {
                case 0x8000: Write8000(value); break;
                case 0x8001: Write8001(value); break;
                case 0xA000: WriteA000(value); break;
                case 0xA001: WriteA001(value); break;
                case 0xC000: WriteC000(value); break;
                case 0xC001: WriteC001(value); break;
                case 0xE000: WriteE000(value); break;
                case 0xE001: WriteE001(value); break;
            }
        }

        protected virtual void Write8000(byte data)
        {
            address_8001 = data & 0x7;
            flag_c = (data & 0x80) != 0;
            flag_p = (data & 0x40) != 0;
            SetupCHR();
            SetupPRG();
        }
        protected virtual void Write8001(byte data)
        {
            switch (address_8001)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5: chr_reg[address_8001] = data; SetupCHR(); break;
                case 6:
                case 7: prg_reg[address_8001 - 6] = data & PRGROM08KBBanksCountMask; SetupPRG(); break;
            }
        }
        protected virtual void WriteA000(byte data)
        {
            if (NesCore.RomInfo.Mirroring != Mirroring.ModeFull)
            {
                base.SwitchMirroring((data & 1) == 1 ? Mirroring.ModeHorz : Mirroring.ModeVert);
            }
        }
        protected virtual void WriteA001(byte data)
        {
            //SRAM_ON = (data & 0x80) != 0;
            SRAM_WriteProtect = (data & 0x40) != 0;
        }
        protected virtual void WriteC000(byte data)
        { irq_reload = data; }
        protected virtual void WriteC001(byte data)
        { if (mmc3_alt_behavior) irq_clear = true; irq_counter = 0; }
        protected virtual void WriteE000(byte data)
        { irq_enabled = false; NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.BOARD, false); }
        protected virtual void WriteE001(byte data)
        { irq_enabled = true; }

        protected virtual void SetupCHR()
        {
            base.Switch02kCHR(chr_reg[0] >> 1, 0x0000 | (!flag_c ? 0x0000 : 0x1000));
            base.Switch02kCHR(chr_reg[1] >> 1, 0x0800 | (!flag_c ? 0x0000 : 0x1000));
            base.Switch01kCHR(chr_reg[2], 0x0000 | (!flag_c ? 0x1000 : 0x0000));
            base.Switch01kCHR(chr_reg[3], 0x0400 | (!flag_c ? 0x1000 : 0x0000));
            base.Switch01kCHR(chr_reg[4], 0x0800 | (!flag_c ? 0x1000 : 0x0000));
            base.Switch01kCHR(chr_reg[5], 0x0C00 | (!flag_c ? 0x1000 : 0x0000));
        }
        protected virtual void SetupPRG()
        {
            base.Switch08KPRG(prg_reg[flag_p ? 2 : 0], 0x8000);
            base.Switch08KPRG(prg_reg[1], 0xA000);
            base.Switch08KPRG(prg_reg[flag_p ? 0 : 2], 0xC000);
            base.Switch08KPRG(prg_reg[3], 0xE000);
        }
        // The scanline timer, clocked on PPU A12 raising edge ...
        public override void OnPPUA12RaisingEdge()
        {
            int old = irq_counter;

            if (irq_counter == 0 || irq_clear)
                irq_counter = irq_reload;
            else
                irq_counter = (byte)(irq_counter - 1);

            if ((!mmc3_alt_behavior || old != 0 || irq_clear) && irq_counter == 0 && irq_enabled)
                NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.BOARD, true);

            irq_clear = false;
        }
    }
    class MMC3ConsoleCommands : ConsoleCommand
    {
        public override string Method
        {
            get { return "mmc3"; }
        }
        public override string Description
        {
            get { return "Call MMC3 board commands, use parameters for options"; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[]
                {
                new ConsoleCommandParameter("reva","Set MMC3 IQR mode to RevA (Alternative mode)"),
                new ConsoleCommandParameter("revb","Set MMC3 IQR mode to RevB"),
                };
            }
        }
        public override void Execute(string parameters)
        {
            if (!NesCore.ON)
            {
                Console.WriteLine("The emulation is off, you can't access the board.", DebugCode.Error);
                return;
            }
            if (!NesCore.BOARD.Name.Contains("MMC3"))
            {
                Console.WriteLine("The current loaded board is not MMC3 !", DebugCode.Error);
                return;
            }
            if (parameters.Length > 0)
            {
                string[] codes = parameters.Split(new char[] { ' ' });
                for (int i = 0; i < codes.Length; i++)
                {
                    if (codes[i] == "reva")
                    {
                        ((MMC3)NesCore.BOARD).mmc3_alt_behavior = true;
                        Console.WriteLine("MMC3 IQR mode switched to RevA");
                    }
                    if (codes[i] == "revb")
                    {
                        ((MMC3)NesCore.BOARD).mmc3_alt_behavior = false;
                        Console.WriteLine("MMC3 IQR mode switched to RevB");
                    }
                }
            }
        }
    }
}
