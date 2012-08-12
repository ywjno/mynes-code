namespace myNES.Core.PPU
{
    public partial class Ppu
    {
        private void FetchBkgName_0()
        {
            fetch.addr = 0x2000 | (scroll.addr & 0xFFF);
        }
        private void FetchBkgName_1()
        {
            fetch.name = Nes.PpuMemory.Peek(fetch.addr);
        }
        private void FetchBkgAttr_0()
        {
            fetch.addr = 0x23C0 | (scroll.addr & 0xC00) | (scroll.addr >> 4 & 0x38) | (scroll.addr >> 2 & 0x7);
        }
        private void FetchBkgAttr_1()
        {
            fetch.attr = Nes.PpuMemory.Peek(fetch.addr) >> ((scroll.addr >> 4 & 0x04) | (scroll.addr & 0x02));
        }
        private void FetchBkgBit0_0()
        {
            fetch.addr = bkg.address | (fetch.name << 4) | 0 | (scroll.addr >> 12 & 7);
        }
        private void FetchBkgBit0_1()
        {
            fetch.bit0 = Nes.PpuMemory.Peek(fetch.addr);
        }
        private void FetchBkgBit1_0()
        {
            fetch.addr = bkg.address | (fetch.name << 4) | 8 | (scroll.addr >> 12 & 7);
        }
        private void FetchBkgBit1_1()
        {
            fetch.bit1 = Nes.PpuMemory.Peek(fetch.addr);
        }
    }
}