namespace myNES.Core.Boards.Discreet
{
    public class UOROM : Board
    {
        public UOROM(byte[] chr, byte[] prg)
            : base(chr, prg)
        {
            prgPage = new int[2];
            prgPage[0] = 0x0 << 14;
            prgPage[1] = 0xF << 14;
        }

        protected override int DecodePrgAddress(int address)
        {
            // rr rraa aaaa aaaa aaaa
            // |   ||               |
            // |   |+---------------+- address bits  ($3FFF)
            // +---+------------------ pagesel bits ($3C000)
            //                                      ($3FFFF) = (256 * 1024) - 1

            switch (address & 0xC000)
            {
            case 0x8000: return (address & 0x3FFF) | prgPage[0]; // first bank switchable
            case 0xC000: return (address & 0x3FFF) | prgPage[1]; // second bank fixed to last page ($F << 14)
            }

            return (address & 0x3FFF) | prgPage[address >> 14 & 1]; // simplified, one-line version of above
        }

        protected override void PokePrg(int address, byte data)
        {
            prgPage[0] = (data & 0x0F) << 14; // UNROM uses bits d:[3-0]
        }
    }
}