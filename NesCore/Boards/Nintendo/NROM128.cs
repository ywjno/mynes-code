namespace MyNes.Core.Boards.Nintendo
{
    public class NROM128 : Board
    {
        public NROM128(byte[] chr, byte[] prg)
            : base(chr, prg) { }

        protected override int DecodePrgAddress(int address)
        {
            return address & 0x3FFF; // 128 kbit (((128 * 1024) / 8) bytes)
        }
    }
}