﻿/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
/*Written by Ala Ibrahim Hadid*/
using MyNes.Core.Types;
namespace MyNes.Core.Boards.Discreet
{
    [BoardName("Future", 117)]
    class Future : Board
    {
        public Future() : base() { }
        public Future(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }
        byte irq_counter = 0;
        byte irq_enable = 0;
        public override void Initialize()
        {
            base.Initialize();
            Nes.Ppu.ScanlineTimer = TickScanlineTimer;
        }
        public override void HardReset()
        {
            base.HardReset();

            Switch16KPRG(prg.Length - 0x4000 >> 14, 0xC000);
        }
        protected override void PokePrg(int address, byte data)
        {
            switch (address)
            {
                case 0x8000: Switch08KPRG(data, 0x8000); break;
                case 0x8001: Switch08KPRG(data, 0xA000); break;
                case 0x8002: Switch08KPRG(data, 0xC000); break;
                case 0xA000: Switch01kCHR(data, 0x0000); break;
                case 0xA001: Switch01kCHR(data, 0x0400); break;
                case 0xA002: Switch01kCHR(data, 0x0800); break;
                case 0xA003: Switch01kCHR(data, 0x0C00); break;
                case 0xA004: Switch01kCHR(data, 0x1000); break;
                case 0xA005: Switch01kCHR(data, 0x1400); break;
                case 0xA006: Switch01kCHR(data, 0x1800); break;
                case 0xA007: Switch01kCHR(data, 0x1C00); break;
                case 0xC001:
                case 0xC002:
                case 0xC003: irq_counter = data; Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, false); break;
                case 0xE000: irq_enable = (byte)(data & 1); break;
            }
        }
        public void TickScanlineTimer()
        {
            if (irq_enable != 0)
            {
                if (irq_counter ==Nes.Ppu.vclock)
                {
                    irq_counter = 0;
                    Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, true);
                }
            }
        }
    }
}
