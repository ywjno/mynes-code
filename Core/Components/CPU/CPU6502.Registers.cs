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
/*Registers section*/
using System.Runtime.InteropServices;
namespace MyNes.Core.CPU
{
    public partial class CPU6502 : IProcesserBase
    {
        // Registers
        private StatusRegister P;// Processor status
        private Register16 PC;// Program Counter
        private Register16 S;// Stack pointer
        private byte A;// Accumulator
        private byte X;// Index register X
        private byte Y;// Index register Y
        // Helper registers
        private Register16 EA;// Effective address.

        /// <summary>
        /// Represents 16-bit register 
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        struct Register16
        {
            [FieldOffset(0)]
            public byte LOW;
            [FieldOffset(1)]
            public byte Hi;

            [FieldOffset(0)]
            public ushort VAL;
        }
        struct StatusRegister
        {
            public bool N;
            public bool V;
            public bool D;
            public bool I;
            public bool Z;
            public bool C;
            /// <summary>
            /// Get or set the value of status register
            /// </summary>
            public byte VAL
            {
                get
                {
                    return (byte)(
                        (N ? 0x80 : 0) |
                        (V ? 0x40 : 0) |
                        (D ? 0x08 : 0) |
                        (I ? 0x04 : 0) |
                        (Z ? 0x02 : 0) |
                        (C ? 0x01 : 0) | 0x20);
                }
                set
                {
                    N = (value & 0x80) != 0;
                    V = (value & 0x40) != 0;
                    D = (value & 0x08) != 0;
                    I = (value & 0x04) != 0;
                    Z = (value & 0x02) != 0;
                    C = (value & 0x01) != 0;
                }
            }
            /// <summary>
            /// Get the value with B flag set
            /// </summary>
            public byte VALB()
            {
                return (byte)(
                        (N ? 0x80 : 0) |
                        (V ? 0x40 : 0) |
                        (D ? 0x08 : 0) |
                        (I ? 0x04 : 0) |
                        (Z ? 0x02 : 0) |
                        (C ? 0x01 : 0) | 0x30);
            }
        }
    }
}
