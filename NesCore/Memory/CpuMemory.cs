namespace MyNes.Core
{
    public class CpuMemory : Memory
    {
        private byte[] ram = new byte[2048];

        public CpuMemory()
            : base(1 << 16)
        {
            Hook(0x0000, 0x1FFF, PeekRam, PokeRam);
        }

        private byte PeekRam(int address)
        {
            return ram[address & 0x7FF];
        }
        private void PokeRam(int address, byte data)
        {
            ram[address & 0x7FF] = data;
        }

        public override void Initialize()
        {
            base.Hook(0x0000, 0x1FFF, PeekRam, PokeRam);
        }
    }
}