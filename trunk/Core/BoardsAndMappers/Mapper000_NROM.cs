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
    [BoardInfo("NROM", 0, false)]
    class Mapper000_NROM : Board
    {
        public Mapper000_NROM()
            : base()
        { }
        public Mapper000_NROM(byte[] chr, byte[] prg, byte[] trainer, bool isVram)
            : base(chr, prg, trainer, isVram)
        { }
        public override void WriteSRAM(int address, byte value)
        {
            base.WriteSRAM(address, value);
            Console.WriteLine("SRAM Write: " + (new System.Text.ASCIIEncoding()).GetString(new byte[] { value }), DebugCode.Warning);
        }
    }
}
