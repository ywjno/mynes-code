namespace MyNes.Core.Boards
{
    public class NesNROM128 : Board
    {
        public NesNROM128(byte[] chr, byte[] prg)
            : base(chr, prg) { }

        protected override int DecodePrgAddress(int address)
        {
            return address & 0x3FFF; // 128 kbit
        }
    }
}