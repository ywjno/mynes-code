﻿/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
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
    [BoardName("Unknown", 154)]
    class Mapper154 : Board
    {
        public Mapper154() : base() { }
        public Mapper154(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        private int index = 0;

        public override void HardReset()
        {
            base.HardReset();
            index = 0;
            Switch16KPRG(prg.Length - 0x4000 >> 14, 0xC000);
        }
        protected override void PokePrg(int address, byte data)
        {
            switch (address & 0x8001)
            {
                case 0x8000: index = data & 0x7; Nes.PpuMemory.SwitchMirroring((data & 0x40) == 0x40 ? Mirroring.Mode1ScB : Mirroring.Mode1ScA); break;
                case 0x8001: switch (index)
                    {
                        case 0: Switch02kCHR((data >> 1) & 0x3F, 0x0000); break;
                        case 1: Switch02kCHR((data >> 1) & 0x3F, 0x0800); break;
                        case 2: Switch01kCHR(data | 0x40, 0x1000); break;
                        case 3: Switch01kCHR(data | 0x40, 0x1400); break;
                        case 4: Switch01kCHR(data | 0x40, 0x1800); break;
                        case 5: Switch01kCHR(data | 0x40, 0x1C00); break;
                        case 6: Switch08KPRG(data, 0x8000); break;
                        case 7: Switch08KPRG(data, 0xA000); break;
                    }
                    break;
            }
        }
        public override void SaveState(StateStream stream)
        {
            base.SaveState(stream);
            stream.Write(index);
        }
        public override void LoadState(StateStream stream)
        {
            base.LoadState(stream);
            index = stream.ReadInt32();
        }
    }
}
