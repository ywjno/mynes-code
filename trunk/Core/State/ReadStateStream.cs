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
namespace MyNes.Core.State
{
    public class ReadStateStream : BinaryReader
    {
        public ReadStateStream(Stream stream)
            : base(stream)
        {
        }
        public ReadStateStream(string fileName)
            : base(new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            this.fileName = fileName;
        }
        private string fileName;
        /// <summary>
        /// Read My Nes State file header and check it, then check the sha1
        /// </summary>
        /// <param name="SHA1">The rom sha1, used to determine that this state file match the rom</param>
        /// <returns>True= read ok and this file is state file for the rom</returns>
        public bool ReadHeader(byte version, string SHA1)
        {
            byte[] header = new byte[3];
            base.Read(header, 0, 3);
            //check header
            if (header[0] != 0x4D | header[1] != 0x4E | header[2] != 0x53)//MNS
            {
                Console.WriteLine("Unable to open state file, not MNS format file.", DebugCode.Error);
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification("Unable to open state file, not MNS format file.", 120, System.Drawing.Color.Red.ToArgb());
                return false;
            }
            //read version
            byte ver = base.ReadByte();
            if (ver != version)
            {
                Console.WriteLine("Unable to open state file, incompatible version.", DebugCode.Error);
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification("Unable to open state file, incompatible version.", 120, System.Drawing.Color.Red.ToArgb());
                return false;
            }
            //Read sha1
            string sha1 = "";
            for (int i = 0; i < SHA1.Length; i += 2)
            {
                sha1 += (base.ReadByte()).ToString("X2");
            }
            if (sha1.ToLower() != SHA1.ToLower())
            {
                Console.WriteLine("Unable to open state file, this state file is not for this rom (sha1 not matched)", DebugCode.Error);
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification("Unable to open state file, this state file is not for this rom (sha1 not matched)", 120, System.Drawing.Color.Red.ToArgb());
                return false;
            }
            return true;
        }
    }
}
