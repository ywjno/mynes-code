namespace MyNes.Core.Boards
{
    public class Board
    {
        private byte[] chr;
        private byte[] prg;
        private int chrMask;
        private int prgMask;

        private byte PeekChr(int address) { return chr[DecodeChrAddress(address) & chrMask]; }
        private byte PeekPrg(int address) { return prg[DecodePrgAddress(address) & prgMask]; }
        private void PokeChr(int address, byte data) { }
        private void PokePrg(int address, byte data) { }

        protected virtual int DecodeChrAddress(int address) { return address; }
        protected virtual int DecodePrgAddress(int address) { return address; }
    }
}