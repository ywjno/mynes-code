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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNes.Core;

namespace MyNes.Core.PPU
{
    public partial class PPU2C02 : IProcesserBase
    {
        private byte[] PAL;// Palettes

        private void Write(int address, byte value)
        {
            address &= 0x3FFF;
            if (address < 0x2000)
            {
                NesCore.BOARD.WriteCHR(address, value);
            }
            else if (address < 0x3F00)
            {
                NesCore.BOARD.WriteNMT(address, value);
            }
            else
            {
                PAL[address & ((address & 0x03) == 0 ? 0x0C : 0x1F)] = value;
            }
        }
        private byte Read(int address)
        {
            address &= 0x3FFF;
            if (address < 0x2000)
            {
                return NesCore.BOARD.ReadCHR(address);
            }
            else if (address < 0x3F00)
            {
                return NesCore.BOARD.ReadNMT(address);
            }
            else
            {
                return PAL[address & ((address & 0x03) == 0 ? 0x0C : 0x1F)];
            }
        }
    }
}
