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
/*CPU memory section*/
namespace MyNes.Core.CPU
{
    public partial class CPU6502 : IProcesserBase
    {
        private byte[] WRAM = new byte[0x800];// Internal 2K Work RAM (mirrored to 800h-1FFFh)
        // BUS
        public byte BUS_DATA;
        public int BUS_ADDRESS;
        public bool BUS_RW;
        /// <summary>
        /// Indicates bus conflict at $8000 - $FFFF
        /// </summary>
        public bool BUS_CONFLICTS;
        /// <summary>
        /// Previous status of RW
        /// </summary>
        public bool BUS_RW_P;

        public byte Read(int address)
        {
            BUS_RW_P = BUS_RW;
            BUS_ADDRESS = address;
            BUS_RW = true;

            NesCore.ClockComponents();
            //CheckRDY();
            // Access !
            if (address < 0x2000)// Internal 2K Work RAM (mirrored to 800h-1FFFh)
            {
                return BUS_DATA = WRAM[address & 0x7FF];
            }
            else if (address < 0x4000)// Internal PPU Registers (mirrored to 2008h-3FFFh)
            {
                switch (address & 7)
                {
                    case 2: return BUS_DATA = NesCore.PPU.Read2002();
                    case 4: return BUS_DATA = NesCore.PPU.Read2004();
                    case 7: return BUS_DATA = NesCore.PPU.Read2007();
                }
            }
            else if (address < 0x4020)// Internal APU Registers
            {
                switch (address)
                {
                    case 0x4015: return BUS_DATA = NesCore.APU.Read4015();
                    case 0x4016: return BUS_DATA = NesCore.ControlsUnit.Read4016();
                    case 0x4017: return BUS_DATA = NesCore.ControlsUnit.Read4017();
                }
            }
            else if (address < 0x6000)// Cartridge Expansion Area almost 8K
            {
                return BUS_DATA = NesCore.BOARD.ReadExpansion(address);
            }
            else if (address < 0x8000)// Cartridge SRAM Area 8K
            {
                return BUS_DATA = NesCore.BOARD.ReadSRAM(address);
            }
            else if (address <= 0xFFFF)// Cartridge PRG-ROM Area 32K
            {
                return BUS_DATA = NesCore.BOARD.ReadPRG(address);
            }
            else
            {
                Console.WriteLine("Attempting to read from out range address ! Address= " + string.Format("X4", address),
                    DebugCode.Error);
            }
            return BUS_DATA = 0;// Should not reach here !
        }
        public void Write(int address, byte value)
        {
            BUS_RW_P = BUS_RW;
            BUS_ADDRESS = address;
            BUS_RW = false;

            NesCore.ClockComponents();
            //CheckRDY();
            // Access !
            if (address < 0x2000)// Internal 2K Work RAM (mirrored to 800h-1FFFh)
            {
                WRAM[address & 0x7FF] = value;
            }
            else if (address < 0x4000)// Internal PPU Registers (mirrored to 2008h-3FFFh)
            {
                switch (address & 7)
                {
                    case 0: NesCore.PPU.Write2000(value); break;
                    case 1: NesCore.PPU.Write2001(value); break;
                    case 3: NesCore.PPU.Write2003(value); break;
                    case 4: NesCore.PPU.Write2004(value); break;
                    case 5: NesCore.PPU.Write2005(value); break;
                    case 6: NesCore.PPU.Write2006(value); break;
                    case 7: NesCore.PPU.Write2007(value); break;
                }
            }
            else if (address < 0x4020)// Internal APU Registers
            {
                switch (address)
                {
                    case 0x4000: NesCore.APU.Write4000(value); break;
                    case 0x4001: NesCore.APU.Write4001(value); break;
                    case 0x4002: NesCore.APU.Write4002(value); break;
                    case 0x4003: NesCore.APU.Write4003(value); break;
                    case 0x4004: NesCore.APU.Write4004(value); break;
                    case 0x4005: NesCore.APU.Write4005(value); break;
                    case 0x4006: NesCore.APU.Write4006(value); break;
                    case 0x4007: NesCore.APU.Write4007(value); break;
                    case 0x4008: NesCore.APU.Write4008(value); break;
                    //case 0x4009: NesCore.APU.Write4009(value); break;
                    case 0x400A: NesCore.APU.Write400A(value); break;
                    case 0x400B: NesCore.APU.Write400B(value); break;
                    case 0x400C: NesCore.APU.Write400C(value); break;
                    //case 0x400D: NesCore.APU.Write400D(value); break;
                    case 0x400E: NesCore.APU.Write400E(value); break;
                    case 0x400F: NesCore.APU.Write400F(value); break;
                    case 0x4010: NesCore.APU.Write4010(value); break;
                    case 0x4011: NesCore.APU.Write4011(value); break;
                    case 0x4012: NesCore.APU.Write4012(value); break;
                    case 0x4013: NesCore.APU.Write4013(value); break;
                    case 0x4014: NesCore.PPU.Write4014(value); break;
                    case 0x4015: NesCore.APU.Write4015(value); break;
                    case 0x4016: NesCore.ControlsUnit.Write4016(value); break;
                    case 0x4017: NesCore.APU.Write4017(value); break;
                }
            }
            else if (address < 0x6000)// Cartridge Expansion Area almost 8K
            {
                NesCore.BOARD.WriteExpansion(address, value);
            }
            else if (address < 0x8000)// Cartridge SRAM Area 8K
            {
                NesCore.BOARD.WriteSRAM(address, value);
            }
            else if (address <= 0xFFFF)// Cartridge PRG-ROM Area 32K
            {
                if (BUS_CONFLICTS)
                    value |= NesCore.BOARD.ReadPRG(address);
                NesCore.BOARD.WritePRG(address, value);
            }
            else
            {
                Console.WriteLine("Attempting to write at out range address ! Address= " + string.Format("X4", address),
                    DebugCode.Error);
            }
            BUS_DATA = value;
        }
    }
}
