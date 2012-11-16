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
namespace MyNes.Core.Boards.Discreet
{
    [BoardName("AxROM", 7)]
    class AxROM : Board
    {
        public AxROM()
            : base()
        { }
        public AxROM(byte[] chr, byte[] prg, byte[] trainer, bool isVram)
            : base(chr, prg, trainer, isVram)
        { }
        protected override void PokePrg(int address, byte data)
        {
            if ((data & 0x10) == 0x10)
                Nes.PpuMemory.SwitchMirroring(MyNes.Core.Types.Mirroring.Mode1ScA);
            else
                Nes.PpuMemory.SwitchMirroring(MyNes.Core.Types.Mirroring.Mode1ScB);

            base.Switch32KPRG((data & 0x07));
        }
    }
}
