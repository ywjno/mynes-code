namespace MyNes.Core.Boards.Nintendo
{
    public class NROM256 : Board
    {
        public NROM256(byte[] chr, byte[] prg)
            : base(chr, prg) { }

        protected override int DecodePrgAddress(int address)
        {
            return address & 0x7FFF; // 256 kbit (((256 * 1024) / 8) bytes)
        }
    }
}