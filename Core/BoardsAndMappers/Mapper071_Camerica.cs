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
    [BoardInfo("Camerica", 71, false)]
    class Mapper071_Camerica : Board
    {
        public Mapper071_Camerica() : base() { }
        public Mapper071_Camerica(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void HardReset()
        {
            base.HardReset();
            //base.Switch16KPRG((prg_dump.Length - 0x4000) >> 14, 0xC000);
        }
        public override void WritePRG(int address, byte data)
        {
            if (address >= 0x8000 && address < 0x9FFF)
            {
                if ((data & 0x10) != 0)
                    SwitchMirroring(Mirroring.Mode1ScB);
                else
                    SwitchMirroring(Mirroring.Mode1ScA);
            }
            else if (address >= 0xC000)
            {
                base.Switch16KPRGROM((data & 0x0F), 0x8000);
            }
        }
    }
}
