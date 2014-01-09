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
    public class SaveStateStream : BinaryWriter
    {
        public SaveStateStream()
            : base(new MemoryStream())
        { compressData = false; }
        public SaveStateStream(string fileName)
            : base(new MemoryStream())
        { compressData = true; this.fileName = fileName; }

        private string fileName;
        private bool compressData;

        /// <summary>
        /// Write My Nes State Header !
        /// </summary>
        /// <param name="version">My Nes State version</param>
        /// <param name="sha1">The rom sha1. It will be used later on load for comparing ...</param>
        public void WriteHeader(byte version, string sha1)
        {
            /*My Nes State*/
            base.Write((byte)0x4D);//M
            base.Write((byte)0x4E);//N
            base.Write((byte)0x53);//S
            base.Write(version);
            //Write sha1
            for (int i = 0; i < sha1.Length; i += 2)
            {
                string v = sha1.Substring(i, 2).ToUpper();
                base.Write(Convert.ToByte(v, 16));
            }
        }
        /// <summary>
        /// Close stream and compress.
        /// </summary>
        public override void Close()
        {
            if (compressData)
            {
                // get the buffer
                byte[] buffer = ((MemoryStream)base.BaseStream).GetBuffer();
                base.Close();
                // compress
                byte[] compressedBuffer;
                ZLIBWrapper.CompressData(buffer, out compressedBuffer);
                // write the compressed buffer
                Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                stream.Write(compressedBuffer, 0, compressedBuffer.Length);
                stream.Close();
                stream.Dispose();
            }
            base.Close();// Close streams ...
        }
        /// <summary>
        /// Get the buffer compressed
        /// </summary>
        /// <returns></returns>
        public byte[] GetBufferCompressed()
        {
            // get the buffer
            byte[] buffer = ((MemoryStream)this.BaseStream).GetBuffer();
            // compress
            byte[] compressedBuffer;
            ZLIBWrapper.CompressData(buffer, out compressedBuffer);
            return compressedBuffer;
        }
        /// <summary>
        /// Get the buffer
        /// </summary>
        /// <returns></returns>
        public byte[] GetBuffer()
        {
            // get the buffer
            byte[] buffer = ((MemoryStream)this.BaseStream).GetBuffer();
            return buffer;
        }
    }
}
