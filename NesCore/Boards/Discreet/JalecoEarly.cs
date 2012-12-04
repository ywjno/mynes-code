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
    [BoardName("Jaleco Early", 72)]
    class JalecoEarly : Board
    {
        public JalecoEarly() : base() { }
        public JalecoEarly(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        public override void Initialize()
        {
            // Maps prg writes to 0x8000 - 0xFFFF. Maps sram reads and writes to 0x6000 - 0x8000.
            // Then do a hard reset.
            base.Initialize();

            // TODO: add your board initialize code like memory mapping. NEVER remove the previous line.
        }
        public override void HardReset()
        {
            base.HardReset();

            Switch16KPRG(prg.Length - 04000 >> 14, 0xC000);
        }
        protected override void PokePrg(int address, byte data)
        {
            if ((data & 0x40) == 0x40)
            {
                Switch08kCHR(data & 0xF);
            }

            if ((data & 0x80) == 0x80)
                Switch16KPRG(data & 0xF, 0x8000);
        }
        protected override void PokeSram(int address, byte data)
        {
            if (address == 0x6000)
            {
                Switch32KPRG(data >> 4 & 0x3);
                Switch08kCHR((data >> 4 & 0x4) | (data & 0x3));
            }
        }
    }
}
