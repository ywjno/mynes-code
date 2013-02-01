/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
using MyNes.Core.Types;

namespace MyNes.Core.ROM
{
    /// <summary>
    /// Encapsulates an INES format header
    /// </summary>
    public class INESHeader
    {
        public bool IsValid;
        public byte ChrPages;
        public byte PrgPages;
        public byte Mapper;
        public bool HasTrainer;
        public bool HasSaveRam;
        public bool IsVram;
        public bool IsVSUnisystem;
        public bool IsPlaychoice10;
        public bool IsVersion2;
        public Mirroring Mirroring;
        public INESRVSystem TVSystem;

        /// <summary>
        /// Create a new instance of INES format header
        /// </summary>
        /// <param name="romPath">The absolute ROM path</param>
        public INESHeader(string romPath)
        {
            FileStream stream = new FileStream(romPath, FileMode.Open, FileAccess.Read);
            byte[] header = new byte[16];

            stream.Read(header, 0, 16);
            stream.Close();

            if (header[0] != 'N' ||
                header[1] != 'E' ||
                header[2] != 'S' ||
                header[3] != 0x1A)
            {
                IsValid = false;
                return;
            }

            PrgPages = header[4];
            ChrPages = header[5];

            IsVram = ChrPages == 0;

            switch (header[6] & 0x9)
            {
                case 0x0: this.Mirroring = Types.Mirroring.ModeHorz; break;
                case 0x1: this.Mirroring = Types.Mirroring.ModeVert; break;
                case 0x8:
                case 0x9: this.Mirroring = Types.Mirroring.ModeFull; break;
            }

            HasSaveRam = (header[6] & 0x2) != 0x0;
            HasTrainer = (header[6] & 0x4) != 0x0;

            if ((header[7] & 0x0F) == 0)
                Mapper = (byte)((header[7] & 0xF0) | (header[6] >> 4));
            else
                Mapper = (byte)((header[6] >> 4));

            IsVSUnisystem = (header[7] & 0x01) != 0;
            IsPlaychoice10 = (header[7] & 0x02) != 0;

            //Pal system detect, Though in the official specification, very few emulators honor this 
            //bit as virtually no ROM images in circulation make use of it. 
            TVSystem = (header[9] & 1) == 1 ? INESRVSystem.PAL : INESRVSystem.NTSC;
            IsValid = true;
        }
    }
    public enum INESRVSystem
    {
        NTSC, PAL, DualCompatible
    }
}