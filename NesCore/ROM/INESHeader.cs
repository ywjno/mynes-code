using System;
using System.IO;

namespace myNES.Core.ROM
{
    /// <summary>
    /// Encapsulates an INES format header
    /// </summary>
    public class INESHeader
    {
        public INESResult Result;
        public byte ChrPages;
        public byte PrgPages;
        public byte Mapper;
        public bool HasTrainer;
        public bool HasSaveRam;
        public bool IsPalb;
        public bool IsVSUnisystem;
        public bool IsPlaychoice10;
        public int Mirroring;

        /// <summary>
        /// Create a new instance of INES format header
        /// </summary>
        /// <param name="romPath">The absolute ROM path</param>
        public INESHeader(string romPath)
        {
            var stream = new FileStream(romPath, FileMode.Open, FileAccess.Read);
            var header = new byte[16];

            stream.Read(header, 0, 16);
            stream.Close();

            if (header[0] != 'N' ||
                header[1] != 'E' ||
                header[2] != 'S' ||
                header[3] != 0x1A)
            {
                Result = INESResult.InvalidHeader;
                return;
            }

            PrgPages = header[4];
            ChrPages = header[5];

            switch (header[6] & 0x9)
            {
                case 0x0: this.Mirroring = Types.Mirroring.ModeHorz; break;
                case 0x1: this.Mirroring = Types.Mirroring.ModeVert; break;
                case 0x8:
                case 0x9: throw new Exception("4-screen mirroring isn't supported.");
            }

            HasSaveRam = (header[6] & 0x2) != 0x0;
            HasTrainer = (header[6] & 0x4) != 0x0;

            if ((header[7] & 0x0F) == 0)
                Mapper |= (byte)((header[7] & 0xF0) | (header[6] >> 4));
            else
                throw new Exception("Header is corrupted, please use the header cleaner tool");

            IsVSUnisystem = (header[7] & 0x01) != 0;
            IsPlaychoice10 = (header[7] & 0x02) != 0;

            // TODO: pal system detect
            IsPalb = false;
            Result = INESResult.Valid;
        }

        public enum INESResult
        {
            InvalidHeader = -2,
            InvalidMapper = -1,
            Valid = 0,
        }
    }
}