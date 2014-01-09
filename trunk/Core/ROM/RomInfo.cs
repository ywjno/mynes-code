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
using System.Security.Cryptography;
using MyNes.Core.Boards;
using MyNes.Core.Database;
namespace MyNes.Core.ROM
{
    /// <summary>
    /// Hold rom information. Also used to read rom file.
    /// </summary>
    public class RomInfo : INesComponent
    {
        /// <summary>
        /// Hold rom information. Also used to read rom file.
        /// </summary>
        /// <param name="romPath">The rom path to get information for.</param>
        public RomInfo(string romPath)
        {
            format = RomFormat.UNKNOWN;
            this.romPath = romPath;
            switch (Path.GetExtension(romPath).ToLower())
            {
                case ".nes": LoadINES(); break;
                default: readStatus = RomReadResult.Invalid; break;
            }
        }

        private RomFormat format;
        private RomReadResult readStatus;
        private string sha1;
        private string romPath;
        private int PrgPages;
        private int ChrPages;
        private bool IsVram;
        private Mirroring mirroring;
        private bool _HasSaveRam;
        private bool _HasTrainer;
        private bool _IsVSUnisystem;
        private bool _IsPlaychoice10;
        private int _INESMapperNumber;
        private TVSystem tv;
        private bool isGameFoundOnDB;
        private NesDatabaseGameInfo dataBaseInfo;
        private NesDatabaseCartridgeInfo dataBaseCartInfo;
        // INES2
        private int subMapperNumber = 0;
        private int prgRamBatteryBacked;
        private int prgRamNOTBatteryBacked;
        private int chrRamBatteryBacked;
        private int chrRamNOTBatteryBacked;
        private VSSystemPP vsSystem_PP;
        private int vsSystem_MM;

        private void LoadINES()
        {

            FileStream stream = new FileStream(romPath, FileMode.Open, FileAccess.Read);
            // Read header
            byte[] header = new byte[16];
            stream.Read(header, 0, 16);
            // Read SHA1 buffer
            byte[] buffer = new byte[stream.Length - 16];
            stream.Read(buffer, 0, (int)(stream.Length - 16));
            stream.Close();
            //SHA1
            sha1 = "";
            SHA1Managed managedSHA1 = new SHA1Managed();
            byte[] shaBuffer = managedSHA1.ComputeHash(buffer);
            foreach (byte b in shaBuffer)
                sha1 += b.ToString("x2").ToLower();
            // Header
            if (header[0] != 'N' ||
                header[1] != 'E' ||
                header[2] != 'S' ||
                header[3] != 0x1A)
            {
                readStatus = RomReadResult.Invalid;
                return;
            }
            format = RomFormat.INES;
            PrgPages = header[4];
            ChrPages = header[5];

            IsVram = ChrPages == 0;

            switch (header[6] & 0x9)
            {
                case 0x0: mirroring = Mirroring.ModeHorz; break;
                case 0x1: mirroring = Mirroring.ModeVert; break;
                case 0x8:
                case 0x9: mirroring = Mirroring.ModeFull; break;
            }

            _HasSaveRam = (header[6] & 0x2) != 0x0;
            _HasTrainer = (header[6] & 0x4) != 0x0;

            if ((header[7] & 0x0F) == 0)
                _INESMapperNumber = (byte)((header[7] & 0xF0) | (header[6] >> 4));
            else
                _INESMapperNumber = (byte)((header[6] >> 4));

            _IsVSUnisystem = (header[7] & 0x01) != 0;
            _IsPlaychoice10 = (header[7] & 0x02) != 0;

            //Pal system detect, Though in the official specification, very few emulators honor this 
            //bit as virtually no ROM images in circulation make use of it. 
            tv = (header[9] & 1) == 1 ? TVSystem.PALB : TVSystem.NTSC;

            bool isINES2 = ((header[7] & 0x0C) >> 2) == 2;

            if (isINES2)
            {
                Console.WriteLine("INES 2 HEADER DETECTED !", DebugCode.Warning);
                format = RomFormat.INES2;
                // Byte 8
                subMapperNumber = header[8] >> 4;
                _INESMapperNumber = (_INESMapperNumber | ((header[8] & 0xF) << 8));
                // Byte 9
                PrgPages = PrgPages | ((header[9] & 0x0F) << 8);
                ChrPages = ChrPages | ((header[9] & 0xF0) << 4);
                // Byte 10
                prgRamNOTBatteryBacked = header[10] & 0x0F;
                prgRamBatteryBacked = (header[10] & 0xF0) >> 4;
                // Byte 11
                chrRamNOTBatteryBacked = header[11] & 0x0F;
                chrRamBatteryBacked = (header[11] & 0xF0) >> 4;
                // Byte 12
                tv = (header[12] & 1) == 1 ? TVSystem.PALB : TVSystem.NTSC;
                // Byte 13
                vsSystem_PP = (VSSystemPP)(header[13] & 0x0F);
                vsSystem_MM = (header[13] & 0xF0) >> 4;
            }

            //DATABASE
            dataBaseInfo = NesDatabase.Find(sha1, out isGameFoundOnDB);
            //set cart info
            if (dataBaseInfo.Cartridges != null)
            {
                foreach (NesDatabaseCartridgeInfo cartinf in dataBaseInfo.Cartridges)
                    if (cartinf.SHA1.ToLower() == sha1.ToLower())
                    { dataBaseCartInfo = cartinf; break; }
            }
            readStatus = BoardsManager.IsBoardSupported(_INESMapperNumber) ?
                RomReadResult.Success : RomReadResult.NotSupportedBoard;

            if (isGameFoundOnDB)
            {
                Console.WriteLine("Game found in Database !!", DebugCode.Good);
                Console.WriteLine("> Game name: " + dataBaseInfo.Game_Name);
                Console.WriteLine("> Game alt name: " + dataBaseInfo.Game_AltName);
            }
        }
        public Board SetupBoard()
        {
            switch (format)
            {
                case RomFormat.INES:
                case RomFormat.INES2:
                    {
                        // Load banks
                        FileStream stream = File.OpenRead(romPath);
                        BinaryReader reader = new BinaryReader(stream);

                        stream.Seek(16L, SeekOrigin.Begin);

                        // Read trainer if presented
                        byte[] trainer = new byte[512];
                        if (_HasTrainer)
                        {
                            Console.WriteLine("Trainer found! reading...");
                            stream.Read(trainer, 0, 512);
                        }

                        // Get PRG dump

                        Console.WriteLine("Reading PRG-ROM...");

                        byte[] prg = reader.ReadBytes(PrgPages * 0x4000);

                        Console.WriteLine("Reading PRG-ROM... Finished!");

                        Console.WriteLine("Reading CHR-ROM...");

                        byte[] chr = reader.ReadBytes(ChrPages * 0x2000);

                        Console.WriteLine("Reading CHR-ROM... Finished!");

                        reader.Close();
                        // Now return the board
                        return BoardsManager.GetBoard(_INESMapperNumber, IsVram, chr, prg, trainer);
                    }
            }
            return null;
        }

        /// <summary>
        /// Get the rom's SHA1
        /// </summary>
        public string SHA1
        { get { return sha1; } }
        /// <summary>
        /// Get if this rom is located on database !
        /// </summary>
        public bool IsGameFoundOnDB
        { get { return isGameFoundOnDB; } }
        /// <summary>
        /// Get NesDatabaseGameInfo element
        /// </summary>
        public NesDatabaseGameInfo DatabaseGameInfo
        { get { return dataBaseInfo; } }
        /// <summary>
        /// Get NesDatabaseCartridgeInfo element
        /// </summary>
        public NesDatabaseCartridgeInfo DatabaseCartInfo
        { get { return dataBaseCartInfo; } }
        /// <summary>
        /// Get the rom file read status
        /// </summary>
        public RomReadResult ReadStatus
        {
            get { return readStatus; }
        }
        /// <summary>
        /// Get the rom file path
        /// </summary>
        public string RomPath
        { get { return romPath; } }
        /// <summary>
        /// Get the default mirroring
        /// </summary>
        public Mirroring Mirroring
        { get { return mirroring; } }
        /// <summary>
        /// Get the tv system as loaded from header.
        /// </summary>
        public TVSystem TVSystem { get { return tv; } }
        /// <summary>
        /// Get if the rom is vs unisystem
        /// </summary>
        public bool VSUnisystem
        { get { return _IsVSUnisystem; } }
        /// <summary>
        /// Get the prg pages count
        /// </summary>
        public int PRGcount
        { get { return PrgPages; } }
        /// <summary>
        /// Get the chr pages count
        /// </summary>
        public int CHRcount
        { get { return ChrPages; } }
        /// <summary>
        /// Get or set if the game has save ram (should set carefully 'cause this value affect the s-ram save at emu shutdown)
        /// </summary>
        public bool HasSaveRam
        { get { return _HasSaveRam; } set { _HasSaveRam = value; } }
        /// <summary>
        /// Get if rom is for playchoice 10
        /// </summary>
        public bool IsPlaychoice10
        { get { return _IsPlaychoice10; } }
        /// <summary>
        /// Get id this rom is for VS Unisystem
        /// </summary>
        public bool IsVSUnisystem
        { get { return _IsVSUnisystem; } }
        /// <summary>
        /// Get the INES mapper number
        /// </summary>
        public int INESMapperNumber
        { get { return _INESMapperNumber; } }
        /// <summary>
        /// Get if this rom has trainer
        /// </summary>
        public bool HasTrainer
        { get { return _HasTrainer; } }

        /// <summary>
        /// Get the board name, NES emulation must be on.
        /// </summary>
        public string MapperBoard
        {
            get
            {
                if (NesCore.BOARD != null)
                    return _INESMapperNumber + " [" + NesCore.BOARD.Name + "]";
                return _INESMapperNumber.ToString();
            }
        }
        /// <summary>
        /// Get current rom format
        /// </summary>
        public RomFormat Format
        { get { return format; } }
        /// <summary>
        /// Get the sub mapper number as provided by INES2 header
        /// </summary>
        public int INES2SubMapperNumber
        { get { return subMapperNumber; } }
        /// <summary>
        /// Get PRG RAM which is battery backed
        /// </summary>
        public int PRGRamSize_BatteryBacked { get { return prgRamBatteryBacked; } }
        /// <summary>
        /// Get PRG RAM which is NOT battery backed
        /// </summary>
        public int PRGRamSize_NOTBatteryBacked { get { return prgRamNOTBatteryBacked; } }
        /// <summary>
        /// Get CHR RAM which is battery backed
        /// </summary>
        public int CHRRamSize_BatteryBacked { get { return chrRamBatteryBacked; } }
        /// <summary>
        /// Get CHR RAM which is NOT battery backed
        /// </summary>
        public int CHRRamSize_NOTBatteryBacked { get { return chrRamNOTBatteryBacked; } }
        public VSSystemPP VSSystem_PP { get { return vsSystem_PP; } }
        public int VSSystem_MM { get { return vsSystem_MM; } }
    }
}
