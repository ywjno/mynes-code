﻿/* This file is part of My Nes
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
namespace MyNes.Core
{
    public enum Mirroring : byte
    {
        /*
               (  D  C  B  A)
   Horz:  $50  (%01 01 00 00)
   Vert:  $44  (%01 00 01 00)
   1ScA:  $00  (%00 00 00 00)
   1ScB:  $55  (%01 01 01 01)
   Full:  $E4  (%11 10 01 00)
        */
        Horz = 0x50,
        Vert = 0x44,
        OneScA = 0x00,
        OneScB = 0x55,
        Full = 0xE4
    }
}

