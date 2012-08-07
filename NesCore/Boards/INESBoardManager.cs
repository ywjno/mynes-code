using myNES.Core.Boards.Discreet;
using myNES.Core.Boards.Nintendo;
using myNES.Core.ROM;

namespace myNES.Core.Boards
{
    public static class INESBoardManager
    {
        public static Board GetBoard(INESHeader header, byte[] chr, byte[] prg)
        {
            // todo: add more cases, until a proprietary format is devised to store all of this information

            switch (header.Mapper)
            {
                case 0:
                    switch (header.PrgPages * 16384)
                    {
                        case 0x4000: return new NROM128(chr, prg); // 128 kb PRG, 8kB CHR-RAM
                        case 0x8000: return new NROM256(chr, prg); // 256 kb PRG, 8kB CHR-RAM
                    }
                    break;

                case 2:
                    switch (header.PrgPages * 16384)
                    {
                        case 0x20000: return new UNROM(chr, prg); // 128 kB PRG, 8kB CHR-RAM
                        case 0x40000: return new UOROM(chr, prg); // 256 kB PRG, 8kB CHR-RAM
                    }
                    break;
            }

            return null;
        }
    }
}