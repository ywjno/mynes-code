namespace MyNes.Core.Boards
{
    public abstract class Board
    {
        protected byte[] chr;
        protected byte[] prg;
        protected int chrMask;
        protected int prgMask;

        public Board(byte[] chr, byte[] prg)
        {
            this.chr = chr;
            this.prg = prg;
        }

        protected virtual byte PeekChr(int address) { return chr[DecodeChrAddress(address) & chrMask]; }
        protected virtual byte PeekPrg(int address) { return prg[DecodePrgAddress(address) & prgMask]; }
        protected virtual void PokeChr(int address, byte data) { }
        protected virtual void PokePrg(int address, byte data) { }

        protected virtual int DecodeChrAddress(int address) { return address; }
        protected virtual int DecodePrgAddress(int address) { return address; }

        public virtual void Initialize()
        {
            NesCore.CpuMemory.Hook(0x8000, 0xFFFF, PeekPrg, PokePrg);
            NesCore.PpuMemory.Hook(0x0000, 0x1FFF, PeekChr, PokeChr);
        }
    }
}