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
using System.IO;
using MyNes.Core.ROM;
using MyNes.Core.ROM.Exceptions;
namespace MyNes.Core
{
    public partial class NesCore
    {
        public static string SRAMFolder;
        private static bool SaveSRAMOnShutdown;
        private static bool saveSRAMRequest;
        private static bool loadSRAMRequest;

        public static RomReadResult CheckRom(string romPath, out int mapperNumber)
        {
            // Read the rom, determine format and see if it can be loaded.
            RomInfo inf = new RomInfo(romPath);
            mapperNumber = inf.INESMapperNumber;
            return inf.ReadStatus;
        }
        /// <summary>
        /// Create new emulation engine instance
        /// </summary>
        /// <param name="romPath">The rom path</param>
        /// <param name="tvsettings">TV Format settings</param>
        public static void CreateNew(string romPath, TVSystemSettings tvsettings)
        {
            if (ON)
            {
                Console.WriteLine("The emulation system is on ! Shutdown emulation engine first.");
                return;
            }

            // Read the rom, determine format and see if it can be loaded.
            RomInfo = new RomInfo(romPath);
            switch (RomInfo.ReadStatus)
            {
                case RomReadResult.NotSupportedBoard:
                    {
                        Console.WriteLine("Not supported board (mapper)", DebugCode.Error);
                        throw new NotSupportedMapperOrBoardExcption("Not supported board (mapper # " + RomInfo.INESMapperNumber + ")", RomInfo.INESMapperNumber);
                    }
                case RomReadResult.Invalid:
                    {
                        Console.WriteLine("Invalid rom file ! not supported format or file is damaged.", DebugCode.Error);
                        throw new InvailedRomException("Invalid rom file ! not supported format or file is damaged.");
                    }
            }
            // Setup TV Format
            switch (tvsettings)
            {
                case TVSystemSettings.AUTO:// Let the database decide !
                    {
                        //as virtually no ROM images in circulation make use of the INES header system bit, we'll depend on database 
                        //to specify emulation system. 
                        if (RomInfo.DatabaseGameInfo.Cartridges != null)
                        {
                            if (RomInfo.DatabaseCartInfo.System.ToUpper().Contains("PAL"))
                                TV = TVSystem.PALB;
                            else if (RomInfo.DatabaseCartInfo.System.ToUpper().Contains("DENDY"))
                                TV = TVSystem.DENDY;
                            else
                                TV = TVSystem.NTSC;
                        }
                        else
                        {
                            TV = RomInfo.TVSystem;//set by rom info
                        }
                        break;
                    }
                case TVSystemSettings.NTSC:// Force NTSC !
                    {
                        TV = TVSystem.NTSC;
                        break;
                    }
                case TVSystemSettings.PALB:// Force PALB !
                    {
                        TV = TVSystem.PALB;
                        break;
                    }
                case TVSystemSettings.DENDY:// Force DENDY !
                    {
                        TV = TVSystem.DENDY;
                        break;
                    }
            }
            // Reached here means this rom is good and supported. Start the engine initializing sequence...
            // 1 Load banks then set up the board.
            BOARD = RomInfo.SetupBoard();
            // 2 Initialize components
            InitializeComponents();
            // 3 Setup output devices then turn on ... this should be done at renderer
        }

        public static void RequestSRAMSave()
        {
            saveSRAMRequest = true;
            PAUSED = true;
        }
        public static void RequestSRAMLoad()
        {
            loadSRAMRequest = true;
            PAUSED = true;
        }
        private static void LoadSram()
        {
            Console.WriteLine("SRAMFolder=" + SRAMFolder);
            if (Directory.Exists(SRAMFolder))
                LoadSramAs(Path.Combine(SRAMFolder, Path.GetFileNameWithoutExtension(RomInfo.RomPath) + ".sav"));
            else
                Console.WriteLine("Unable to Load SRAM, SRAM folder isn't exist !", DebugCode.Error);
            loadSRAMRequest = false;
        }
        public static void LoadSramAs(string sramPath)
        {
            Console.WriteLine("Loading SRAM ...");
            if (File.Exists(sramPath))
            {
                try
                {
                    Stream str = new FileStream(sramPath, FileMode.Open, FileAccess.Read);
                    byte[] b = new byte[str.Length];
                    str.Read(b, 0, b.Length);

                    BOARD.SetSRAMFromBuffer(b);

                    str.Close();
                    str.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to load SRAM: " + ex.Message, DebugCode.Error);
                }
            }
            else
            {
                Console.WriteLine("Unable to Load SRAM, no SRAM file found for this rom !", DebugCode.Error);
            }
        }
        private static void SaveSram()
        {
            if (Directory.Exists(SRAMFolder))
                SaveSramAs(Path.Combine(SRAMFolder, Path.GetFileNameWithoutExtension(RomInfo.RomPath) + ".sav"));
            else
                Console.WriteLine("Unable to Save SRAM, SRAM folder isn't exist !", DebugCode.Error);
            saveSRAMRequest = false;
        }
        public static void SaveSramAs(string sramPath)
        {
            Console.WriteLine("Saving SRAM ...");
            try
            {
                byte[] buffer = BOARD.GetSRAMBuffer();
                if (buffer != null)
                {
                    Stream str = new FileStream(sramPath, FileMode.Create, FileAccess.Write);
                    str.Write(buffer, 0, buffer.Length);
                    str.Close();
                    str.Dispose();
                    Console.WriteLine("SRAM saved successfully.", DebugCode.Good);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to save SRAM: " + ex.Message, DebugCode.Error);
            }
        }
    }
}
