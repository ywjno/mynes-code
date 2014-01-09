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
namespace MyNes.Core.Boards
{
    [BoardInfo("AxROM", 7, false)]
    class Mapper007_AxROM : Board
    {
        public Mapper007_AxROM() : base() { }
        public Mapper007_AxROM(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        public override void WritePRG(int address, byte value)
        {
            if ((value & 0x10) == 0x10)
                SwitchMirroring(Mirroring.Mode1ScA);
            else
                SwitchMirroring(Mirroring.Mode1ScB);

            base.Switch32KPRGROM((value & 0x07));
        }
    }
}
