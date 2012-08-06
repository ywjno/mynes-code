namespace MyNes.Core.Boards
{
    public class NesNROM256 : Board
    {
        public NesNROM256(byte[] chr, byte[] prg)
            : base(chr, prg) { }

        protected override int DecodePrgAddress(int address)
        {
            return address & 0x7FFF; // 256 kbit
        }
    }
}