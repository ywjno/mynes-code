using System.IO;

namespace MyNes.Core
{
    /// <summary>
    /// A class for reading INES file format header
    /// </summary>
    public class INESHeader
    {
        /// <summary>
        /// Create a new instant of INES format header
        /// </summary>
        /// <param name="romPath">The complete rom path</param>
        public INESHeader(string romPath)
        {
            //create read stream
            Stream fileStream = new FileStream(romPath, FileMode.Open, FileAccess.Read);
            //read header
            byte[] header = new byte[16];
            fileStream.Read(header, 0, 16);
            //Check header
            if (header[0] != 0x4E | header[1] != 0x45 | header[2] != 0x53 | header[3] != 0x1A)
            {
                fileStream.Close();
                Result = InesOpenRomResult.NotINES;
                return;
            }
            //Flags
            PrgPages = header[4];
            ChrPages = header[5];
            if ((header[6] & 0x1) == 0)
                this.Mirroring = MyNes.Core.Mirroring.ModeHorz;
            else
                this.Mirroring = MyNes.Core.Mirroring.ModeVert;

            if ((header[6] & 0x8) != 0)
                this.Mirroring = MyNes.Core.Mirroring.ModeFull;

            HasSaveRam = (header[6] & 0x2) != 0x0;
            HasTrainer = (header[6] & 0x4) != 0x0;

            if ((header[7] & 0x0F) == 0)
                Mapper = (byte)((header[7] & 0xF0) | (header[6] & 0xF0) >> 4);
            else
                Mapper = (byte)((header[6] & 0xF0) >> 4);

            IsVSUnisystem = ((header[7] & 0x1) == 0x1);
            IsPC10 = ((header[7] & 0x2) == 0x2);
            //TODO: pal system detect
            IsPal = false;

            /*if (!MappersManager.SupportedMapper(mapper))
            {
                fileStream.Close();
                return LoadRomStatus.InvalidMapper;
            }*/
            fileStream.Close();
            Result = InesOpenRomResult.Valid;
        }
        public InesOpenRomResult Result;
        public byte ChrPages;
        public byte PrgPages;
        public byte Mapper;
        public bool HasTrainer;
        public bool HasSaveRam;
        public bool IsPal;
        public bool IsVSUnisystem;
        public bool IsPC10;
        public int Mirroring;

        public enum InesOpenRomResult
        { NotINES, NotSupportedMapper, Valid, }
    }
}
