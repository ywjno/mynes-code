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
using System.Collections.Generic;
using MyNes.Core.GameGenie;
using MyNes.Core.Database;
using MyNes.Core.State;
namespace MyNes.Core.Boards
{
    // PRG !
    public abstract partial class Board : INesComponent
    {
        // Game Genie
        private bool isGameGenieActive;
        private GameGenieCode[] gameGenieCodes;

        /// <summary>
        /// PRG banks, 8 KB each. Can be ROM or RAM
        /// </summary>
        protected byte[][] PRG;
        /// <summary>
        /// The index of first PRG ROM bank ....
        /// </summary>
        protected int PRGROMOffset;
        /// <summary>
        /// The offset of a bank at prg 8 k slot ($6000, $8000, &A000, $C000 and $E000)
        /// </summary>
        protected int[] PRGOffsets;
        /// <summary>
        /// Set to enable a PRG bank at index (if a bank disabled, read will result an open bus !)
        /// </summary>
        protected bool[] PRGEnabled;
        /// <summary>
        /// Indicates if a bank is RAM
        /// </summary>
        protected bool[] PRGRAM;
        /// <summary>
        /// Set to enable PRG bank writing (RAM) at index
        /// </summary>
        protected bool[] PRGWriteEnable;
        /// <summary>
        /// Set to enable PRG bank (RAM) battery flag at index (this bank will be saved as S-RAM file)
        /// </summary>
        protected bool[] PRGIsBattery;
        // Important values
        /// <summary>
        /// The PRG ROM size in KB
        /// </summary>
        protected int PRGROMSizeInKB;
        /// <summary>
        /// The PRG ROM size in bytes - 1 (to be used as mask)
        /// </summary>
        protected int PRGROMMaxSizeInBytesMask;
        /// <summary>
        /// How many 8 KB PRG ROM banks - 1
        /// </summary>
        protected int PRGROM08KBBanksCountMask;
        /// <summary>
        /// How many 16 KB PRG ROM banks - 1
        /// </summary>
        protected int PRGROM16KBBanksCountMask;
        /// <summary>
        /// How many 32 KB PRG ROM banks - 1
        /// </summary>
        protected int PRGROM32KBBanksCountMask;
        /// <summary>
        /// PRG RAM size in KB
        /// </summary>
        protected int PRGRAMSizeInKB;
        /// <summary>
        /// PRG RAM size in bytes - 1
        /// </summary>
        protected int PRGRAMSizeInBytesMask;
        /// <summary>
        /// How many 8 KB PRG RAM banks - 1
        /// </summary>
        protected int PRGRAM08KBBanksCountMask;
        /// <summary>
        /// The PRG size totally (RAM + ROM) in kb
        /// </summary>
        protected int PRGTotal08KBCount;
        /// <summary>
        /// How many 8 KB PRG RAM banks - 1
        /// </summary>
        protected int PRGTotal08KBCountMask;
        protected bool BusConflictEnabled;

        // Methods
        /// <summary>
        /// Initialize the PRG (RAM/S-RAM and ROM)
        /// </summary>
        /// <param name="prg_dump">The PRG ROM dump as provided from rom file ...</param>
        protected virtual void InitializePRG(byte[] prg_dump, byte[] trainer_dump)
        {
            Console.WriteLine("Setup prg ....");
            // Calculates
            // PRG ROM
            this.PRGROMMaxSizeInBytesMask = prg_dump.Length - 1;
            this.PRGROMSizeInKB = (prg_dump.Length / 1024);
            Console.WriteLine("PRG ROM size: " + PRGROMSizeInKB + " KB");
            this.PRGROM08KBBanksCountMask = (PRGROMSizeInKB / 08) - 1;
            Console.WriteLine("PRG ROM 08KB banks: " + (PRGROMSizeInKB / 08));
            this.PRGROM16KBBanksCountMask = (PRGROMSizeInKB / 16) - 1;
            Console.WriteLine("PRG ROM 16KB banks: " + (PRGROMSizeInKB / 16));
            this.PRGROM32KBBanksCountMask = (PRGROMSizeInKB / 32) - 1;
            Console.WriteLine("PRG ROM 32KB banks: " + (PRGROMSizeInKB / 32));
            // PRG RAM
            SRAMBankInfo[] prgRAMBanks = GetPRGRAMBanks();// 8k each
            PRGRAM08KBBanksCountMask = prgRAMBanks.Length - 1;
            PRGRAMSizeInKB = prgRAMBanks.Length * 8;
            Console.WriteLine("PRG RAM size: " + PRGRAMSizeInKB + " KB");
            PRGRAMSizeInBytesMask = (PRGRAMSizeInKB * 1024) - 1;
            Console.WriteLine("PRG RAM 08KB banks: " + prgRAMBanks.Length);
            // Actual banks ..
            List<byte[]> bs = new List<byte[]>();// The banks
            // Calculate banks count
            PRGTotal08KBCount = (PRGROMSizeInKB / 08) + prgRAMBanks.Length;
            Console.WriteLine("PRG ROM+RAM 8KB banks: " + PRGTotal08KBCount);
            PRGTotal08KBCountMask = PRGTotal08KBCount - 1;
            // Initialize flags
            PRGEnabled = new bool[PRGTotal08KBCount];
            PRGWriteEnable = new bool[PRGTotal08KBCount];
            PRGIsBattery = new bool[PRGTotal08KBCount];
            PRGRAM = new bool[PRGTotal08KBCount];
            // ADD RAM BANKS
            for (int i = 0; i < prgRAMBanks.Length; i++)
            {
                PRGRAM[i] = true;
                PRGEnabled[i] = true;
                PRGWriteEnable[i] = true;
                PRGIsBattery[i] = prgRAMBanks[i].BATTERY;

                bs.Add(new byte[0x2000]);
                if (i == 0)
                    if (NesCore.RomInfo.HasTrainer)
                        trainer_dump.CopyTo(bs[i], 0x1000);
                Console.WriteLine("> 8KB PRG RAM bank added; id = " + prgRAMBanks[i].id + "; battery = " + (PRGIsBattery[i] ? "Yes" : "No"));
            }
            PRGROMOffset = prgRAMBanks.Length;

            // ADD ROM BANKS ...
            for (int i = PRGROMOffset; i < PRGTotal08KBCount; i++)
            {
                PRGRAM[i] = false;
                PRGEnabled[i] = true;
                PRGWriteEnable[i] = false;
                PRGIsBattery[i] = false;
                bs.Add(new byte[0x2000]);
                for (int j = 0; j < 0x2000; j++)
                {
                    bs[i][j] = prg_dump[((i - PRGROMOffset) * 0x2000) + j];
                }
            }
            PRG = bs.ToArray();

            // Set offsets..
            this.PRGOffsets = new int[5];// 1st one for $6000 area ...

            Console.WriteLine("PRG Initialized Successfully !", DebugCode.Good);
        }

        // Memory access
        /// <summary>
        /// Write at Cartridge Expansion Area 8K, 4018h-5FFFh
        /// </summary>
        /// <param name="address">The address to write into. Ranged in 4018h-5FFFh</param>
        /// <param name="value">The value to write</param>
        public virtual void WriteExpansion(int address, byte value)
        {

        }
        /// <summary>
        /// Read at Cartridge Expansion Area 8K, 4018h-5FFFh
        /// </summary>
        /// <param name="address">The address to read from. Ranged in 4018h-5FFFh</param>
        /// <returns>Value at given address</returns>
        public virtual byte ReadExpansion(int address)
        {
            return 0;
        }
        /// <summary>
        /// Write at Cartridge SRAM Area 8K, 6000h-7FFFh
        /// </summary>
        /// <param name="address">The address to write into. Ranged in 6000h-7FFFh</param>
        /// <param name="value">The value to write</param>
        public virtual void WriteSRAM(int address, byte value)
        {
            if (PRGEnabled[0])
                if (PRGRAM[0])
                    if (PRGWriteEnable[0])
                        PRG[PRGOffsets[0]][address & 0x1FFF] = value;
        }
        /// <summary>
        /// Read at Cartridge SRAM Area 8K, 6000h-7FFFh
        /// </summary>
        /// <param name="address">The address to read from. Ranged in 6000h-7FFFh</param>
        /// <returns>Value at given address</returns>
        public virtual byte ReadSRAM(int address)
        {
            if (PRGEnabled[0])
                return PRG[PRGOffsets[0]][address & 0x1FFF];
            return 0;// Open bus !??
        }
        /// <summary>
        /// Write at Cartridge PRG-ROM Area 32K, 8000h-FFFFh
        /// </summary>
        /// <param name="address">The address to write into. Ranged in 8000h-FFFFh</param>
        /// <param name="value">The value to write</param>
        public virtual void WritePRG(int address, byte value)
        {
        }
        /// <summary>
        /// Read at Cartridge PRG-ROM Area 32K, 8000h-FFFFh
        /// </summary>
        /// <param name="address">The address to read from. Ranged in 8000h-FFFFh</param>
        /// <returns>Value at given address</returns>
        public virtual byte ReadPRG(int address)
        {
            int bIndex = ((address >> 13) & 0x3);
            bIndex++;
            if (isGameGenieActive)
            {
                foreach (GameGenieCode code in gameGenieCodes)
                {
                    if (code.Enabled)
                    {
                        if (code.Address == address)
                        {
                            if (code.IsCompare)
                            {
                                if (code.Compare == PRG[PRGOffsets[bIndex]][address & 0x1FFF])
                                    return code.Value;
                            }
                            else
                            {
                                return code.Value;
                            }

                            break;
                        }
                    }
                }
            }
            return PRG[PRGOffsets[bIndex]][address & 0x1FFF];
        }

        // Save S-RAM
        private SRAMBankInfo[] GetPRGRAMBanks()
        {
            List<SRAMBankInfo> ramBanks = new List<SRAMBankInfo>();
            Console.WriteLine("Retrieving PRG RAM information from database ....");
            if (NesCore.RomInfo.IsGameFoundOnDB)
            {
                // Get the sram size
                if (NesCore.RomInfo.DatabaseGameInfo.WRAMBanks.Count > 0)
                {
                    int id = 0;
                    foreach (SRAMBankInfo s in NesCore.RomInfo.DatabaseGameInfo.WRAMBanks)
                    {
                        int wsize = 0;
                        if (int.TryParse(s.SIZE.Replace("k", ""), out wsize))
                        {
                            for (int i = 0; i < wsize / 8; i++)
                            {
                                ramBanks.Add(new SRAMBankInfo(id, "8k", s.BATTERY));
                                id++;
                            }
                        }
                        else
                        {
                            // Unacceptable value, assume 8k
                            ramBanks.Add(new SRAMBankInfo(id, "8k", false)); id++;
                        }
                    }
                }
                else// No info for SRAM; This mean this rom has no sram !
                {
                    Console.WriteLine("This game has no PRG RAM !", DebugCode.Warning);
                }
            }
            else// Not in database :(
            {
                Console.WriteLine("Could't find this game in database .... Adding 8K PRG RAM at $6000 to avoid exceptions.", DebugCode.Warning);
                // Assume 8k
                ramBanks.Add(new SRAMBankInfo(0, "8k", false));
            }
            // Sort by id !
            ramBanks.Sort(new SRAMBankInfoSorter());
            return ramBanks.ToArray();
        }
        /// <summary>
        /// Reset all prg ram banks data to 0 !
        /// </summary>
        protected void ResetPRGRAM()
        {
            for (int i = 0; i < PRG.Length; i++)
            {
                if (PRGRAM[i])
                {
                    PRG[i] = new byte[0x2000];
                }
            }
        }
        /// <summary>
        /// Use this to disable/enable all PRG RAM banks
        /// </summary>
        /// <param name="enabled">The enabled flag</param>
        protected void TogglePRGRAMEnable(bool enabled)
        {
            for (int i = 0; i < PRG.Length; i++)
            {
                if (PRGRAM[i])
                {
                    PRGEnabled[i] = enabled;
                }
            }
        }
        /// <summary>
        /// Get the save-ram buffer that need to be saved
        /// </summary>
        /// <returns></returns>
        public virtual byte[] GetSRAMBuffer()
        {
            List<byte> buffer = new List<byte>();
            for (int i = 0; i < PRG.Length; i++)
            {
                if (PRGRAM[i] && PRGIsBattery[i])
                    buffer.AddRange(PRG[i]);
            }
            byte[] outData;
            ZLIBWrapper.CompressData(buffer.ToArray(), out outData);
            return outData;
        }
        /// <summary>
        /// Set the sram data from buffer
        /// </summary>
        /// <param name="buffer">The buffer as read from file ...</param>
        public virtual void SetSRAMFromBuffer(byte[] buffer)
        {
            byte[] outData;
            ZLIBWrapper.DecompressData(buffer, out outData);

            int sramBlock = 0;
            for (int i = 0; i < PRG.Length; i++)
            {
                if (PRGRAM[i] && PRGIsBattery[i])
                {
                    for (int j = 0; j < 0x2000; j++)
                    {
                        PRG[i][j] = outData[(sramBlock * 0x2000) + j];
                    }
                    sramBlock++;
                }
            }
        }

        // Switches
        /// <summary>
        /// Switch 8k prg bank (ROM or RAM) to area
        /// </summary>
        /// <param name="index">The index within cart</param>
        /// <param name="where">The area where to switch; 0x6000, 0x8000, 0xA000, 0xC000 or 0xE000</param>
        protected void Switch08KPRG(int index, int where)
        {
            if (where >= 0x8000)
                PRGOffsets[((where >> 13) & 0x3) + 1] = index + PRGROMOffset;
            else // On 0x6000
                PRGOffsets[0] = index;
        }
        /// <summary>
        /// Switch 16k prg bank (ROM) to area
        /// </summary>
        /// <param name="index">The index within cart</param>
        /// <param name="where">The area where to switch. 0x8000 or 0xC000</param>
        protected void Switch16KPRGROM(int index, int where)
        {
            where >>= 13;
            where &= 3;
            where++;

            index <<= 1;

            PRGOffsets[where + 0] = ((index + 0) & PRGROM08KBBanksCountMask) + PRGROMOffset;
            PRGOffsets[where + 1] = ((index + 1) & PRGROM08KBBanksCountMask) + PRGROMOffset;
        }
        /// <summary>
        /// Switch 32k prg bank (ROM) to 0x8000
        /// </summary>
        /// <param name="index">The index within cart</param>
        protected void Switch32KPRGROM(int index)
        {
            index <<= 2;

            PRGOffsets[1] = ((index + 0) & PRGROM08KBBanksCountMask) + PRGROMOffset;
            PRGOffsets[2] = ((index + 1) & PRGROM08KBBanksCountMask) + PRGROMOffset;
            PRGOffsets[3] = ((index + 2) & PRGROM08KBBanksCountMask) + PRGROMOffset;
            PRGOffsets[4] = ((index + 3) & PRGROM08KBBanksCountMask) + PRGROMOffset;
        }
    }
}
