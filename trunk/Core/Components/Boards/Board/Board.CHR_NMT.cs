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
    // CHR and NMT
    public abstract partial class Board : INesComponent
    {
        protected bool IsVram;
        protected byte[] CHR;
        /// <summary>
        /// The CHR size in KB (all banks)
        /// </summary>
        protected int CHRSizeInKB;
        /// <summary>
        /// The CHR size in bytes - 1 (to be used as mask)
        /// </summary>
        protected int CHRMaxSizeInBytesMask;
        /// <summary>
        /// How many 1 KB CHR banks - 1
        /// </summary>
        protected int CHR_01KBBanksCountMask;
        /// <summary>
        /// How many 2 KB CHR banks - 1
        /// </summary>
        protected int CHR_02KBBanksCountMask;
        /// <summary>
        /// How many 4 KB CHR banks - 1
        /// </summary>
        protected int CHR_04KBBanksCountMask;
        /// <summary>
        /// How many 8 KB CHR banks - 1
        /// </summary>
        protected int CHR_08KBBanksCountMask;
        protected int[] CHROffset;
        // Name Tables (Yes, name tables control is located in board. 
        // Nes motherboard include 2k, and some boards include other 2k for 4-screen mirroring.
        // Here, name tables and name tables controls (accessing, mirroring and switching) are handled.
        protected byte[] NMTOffset;
        protected byte[][] NMT;

        protected virtual void InitializeVRAM()
        {
            if (IsVram)
            {
                if (NesCore.RomInfo.IsGameFoundOnDB)
                {
                    if (NesCore.RomInfo.DatabaseGameInfo.VRAM_size != null)
                    {
                        // Get the vram size
                        int vsize = 0;
                        if (int.TryParse(NesCore.RomInfo.DatabaseGameInfo.VRAM_size.Replace("k", ""), out vsize))
                        {
                            Console.WriteLine("Using database to initialize CHR RAM; CHR RAM size = " +
                                NesCore.RomInfo.DatabaseGameInfo.VRAM_size, DebugCode.Good);
                            CreateCHR_RAM(vsize);
                        }
                        else
                        {
                            Console.WriteLine("CHR RAM info not found in database to initialize CHR RAM; CHR RAM size set to 8 KB", DebugCode.Warning);
                            // Assume 8kb vram
                            CreateCHR_RAM(8);
                        }
                    }
                    else
                    {
                        Console.WriteLine("CHR RAM info not found in database to initialize CHR RAM; CHR RAM size set to 8 KB", DebugCode.Warning);
                        // Assume 8kb vram
                        CreateCHR_RAM(8);
                    }
                }
                else// Not in database :(
                {
                    Console.WriteLine("Game not found in database to initialize CHR RAM; CHR RAM size set to 64 KB", DebugCode.Warning);
                    // Assume 64kb vram
                    CreateCHR_RAM(8);
                }
            }
        }
        /// <summary>
        /// Create CHR RAM
        /// </summary>
        /// <param name="sizeInKB">Ram size in KB. Cart will access this via ReadCHR method.</param>
        public void CreateCHR_RAM(int sizeInKB)
        {
            if (IsVram)
            {
                CHR = new byte[1024 * sizeInKB];
                CalculateBankMasks();
            }
        }
        /// <summary>
        /// Write at Cartridge CHR-ROM Area 8K, 0000h-1FFFh
        /// </summary>
        /// <param name="address">The address to write into. Ranged in 0000h-1FFFh</param>
        /// <param name="value">The value to write</param>
        public virtual void WriteCHR(int address, byte value)
        {
            if (!IsVram) return;// NO CHR rom so writes are FORPEDDIN.
            CHR[((address & 0x03FF) | CHROffset[(address >> 10) & 0x7]) & CHRMaxSizeInBytesMask] = value;
        }
        /// <summary>
        /// Read at Cartridge CHR-ROM Area 8K, 0000h-1FFFh
        /// </summary>
        /// <param name="address">The address to read from. Ranged in 0000h-1FFFh</param>
        /// <returns>Value at given address</returns>
        public virtual byte ReadCHR(int address)
        {
            return CHR[((address & 0x03FF) | CHROffset[(address >> 10) & 0x7]) & CHRMaxSizeInBytesMask];
        }
        /// <summary>
        /// Read at name table, 2000h-2FFFh
        /// </summary>
        /// <param name="address">The address to read at, 2000h-2FFFh</param>
        /// <returns>The value at given address</returns>
        public virtual byte ReadNMT(int address)
        {
            return NMT[NMTOffset[(address >> 10) & 0x03]][address & 0x03FF];
        }
        /// <summary>
        /// Write at name table, 2000h-2FFFh
        /// </summary>
        /// <param name="address">The address to write at, 2000h-2FFFh</param>
        /// <param name="value">The value to write</param>
        public virtual void WriteNMT(int address, byte value)
        {
            NMT[NMTOffset[(address >> 10) & 0x03]][address & 0x03FF] = value;
        }

        /// <summary>
        /// Switch 1k chr bank to area
        /// </summary>
        /// <param name="index">The index within cart</param>
        /// <param name="where">The area where to switch. 0x0000, 0x0400, 0x0800, 0x0C00, 0x1000, 0x1400, 0x1800 or 0x1800</param>
        protected void Switch01kCHR(int index, int where)
        {
            CHROffset[(where >> 10) & 0x07] = index << 10;
        }
        /// <summary>
        /// Switch 2k chr bank to area
        /// </summary>
        /// <param name="index">The index within cart</param>
        /// <param name="where">The area where to switch. 0x0000, 0x800, 0x1000 or 0x1800</param>
        protected void Switch02kCHR(int index, int where)
        {
            int area = (where >> 10) & 0x07;
            int bank = index << 11;

            CHROffset[area] = bank;
            CHROffset[area + 1] = bank + 0x400;
        }
        /// <summary>
        /// Switch 4k chr bank to area
        /// </summary>
        /// <param name="index">The index within cart</param>
        /// <param name="where">The area where to switch. 0x0000, or 0x1000</param>
        protected void Switch04kCHR(int index, int where)
        {
            int area = (where >> 10) & 0x07;
            int bank = index << 12;

            CHROffset[area] = bank;
            area++;
            bank += 0x400;
            CHROffset[area] = bank;
            area++;
            bank += 0x400;
            CHROffset[area] = bank;
            area++;
            bank += 0x400;
            CHROffset[area] = bank;
        }
        /// <summary>
        /// Switch 8k chr bank to 0x0000
        /// </summary>
        /// <param name="index">The index within cart</param>
        public void Switch08kCHR(int index)
        {
            int bank = index << 13;
            CHROffset[0] = bank;
            bank += 0x400;
            CHROffset[1] = bank;
            bank += 0x400;
            CHROffset[2] = bank;
            bank += 0x400;
            CHROffset[3] = bank;
            bank += 0x400;
            CHROffset[4] = bank;
            bank += 0x400;
            CHROffset[5] = bank;
            bank += 0x400;
            CHROffset[6] = bank;
            bank += 0x400;
            CHROffset[7] = bank;
        }
        /// <summary>
        /// Switch name tables mirroring
        /// </summary>
        /// <param name="value">The mirroring to use</param>
        protected void SwitchMirroring(Mirroring value)
        {
            SwitchMirroring((byte)value);
        }
        /// <summary>
        /// Switch mirroring.
        /// </summary>
        /// <param name="value">The value to use (aabb ccdd) where aa is for bank 0, 
        /// bb is for bank 1, cc is for bank 2, dd is for bank 3</param>
        protected void SwitchMirroring(byte value)
        {
            NMTOffset[0] = (byte)(value >> 6 & 0x03);
            NMTOffset[1] = (byte)(value >> 4 & 0x03);
            NMTOffset[2] = (byte)(value >> 2 & 0x03);
            NMTOffset[3] = (byte)(value >> 0 & 0x03);
        }
        /// <summary>
        /// Switch name tables.
        /// </summary>
        /// <param name="value">The value to use (aabb ccdd) where aa is for bank 3, 
        /// bb is for bank 2, cc is for bank 1, dd is for bank 0</param>
        protected void SwitchNMT(byte value)
        {
            NMTOffset[3] = (byte)(value >> 6 & 0x03);
            NMTOffset[2] = (byte)(value >> 4 & 0x03);
            NMTOffset[1] = (byte)(value >> 2 & 0x03);
            NMTOffset[0] = (byte)(value >> 0 & 0x03);
        }
    }
}
