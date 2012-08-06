namespace MyNes.Core.Boards
{
    class brd_NROM : Board
    {
        public brd_NROM(byte[] prg, byte[] chr)
        {
            base.chr = chr;
            base.prg = prg;
        }
        public override void Initialize()
        {
            NesCore.CpuMemory.Hook(0x8000, 0xFFFF, base.PeekPrg);
            NesCore.PpuMemory.Hook(0x0000, 0x1FFF, base.PeekChr, base.PokeChr);
        }
        protected override int DecodePrgAddress(int address)
        {
            //for roms that has only one prg page
            if (address >= base.prg.Length)
                return address - 0xC000;

            return base.DecodePrgAddress(address);
        }
    }
}
