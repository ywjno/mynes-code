/* This file is part of My Nes
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
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace MyNes
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        private bool az = false;
        public ListViewItemComparer(int column, bool az)
        {
            this.col = column;
            this.az = az;
        }
        public int Compare(object x, object y)
        {
            BRom rom1 = ((ListViewItemBRom)x).BRom;
            BRom rom2 = ((ListViewItemBRom)y).BRom;
            int val = -1;
            switch (col)
            {
                case 0://name
                    val = String.Compare(rom1.Name, rom2.Name); break;
                case 1://size
                    val = String.Compare(rom1.Size, rom2.Size); break;
                case 2://mapper
                    val = String.Compare(rom1.Mapper, rom2.Mapper); break;
                case 3://mirroring
                    val = String.Compare(rom1.Mirroring, rom2.Mirroring); break;
                case 4://has trainer
                    val = String.Compare(rom1.HasTrainer, rom2.HasTrainer); break;
                case 5://is battery
                    val = String.Compare(rom1.IsBattery, rom2.IsBattery); break;
                case 6://is pc10
                    val = String.Compare(rom1.IsPc10, rom2.IsPc10); break;
                case 7://is vsunisystem
                    val = String.Compare(rom1.IsVsUnisystem, rom2.IsVsUnisystem); break;
                case 8://path
                    val = String.Compare(rom1.Path, rom2.Path); break;
            }
            return az ? val : val * -1;
        }
    }
}
