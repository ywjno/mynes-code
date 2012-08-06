namespace MyNes.Core
{
    public class PpuMemory : Memory
    {
        private byte[] nmtBank = new byte[4];
        private byte[] pal = new byte[] // Miscellaneous, real NES loads values similar to these during power up
        {
           0x09, 0x01, 0x00, 0x01, 0x00, 0x02, 0x02, 0x0D, 0x08, 0x10, 0x08, 0x24, 0x00, 0x00, 0x04, 0x2C, // Bkg palette
           0x09, 0x01, 0x34, 0x03, 0x00, 0x04, 0x00, 0x14, 0x08, 0x3A, 0x00, 0x02, 0x00, 0x20, 0x2C, 0x08  // Spr palette
        };
        private byte[][] nmt = new byte[2][]
        {
            new byte[1024], new byte[1024]
        };

        public PpuMemory()
            : base(1 << 14)
        {
            Hook(0x2000, 0x3EFF, PeekNmt, PokeNmt);
            Hook(0x3F00, 0x3FFF, PeekPal, PokePal);
        }

        public byte PeekNmt(int addr)
        {
            return nmt[nmtBank[addr >> 10 & 0x03]][addr & 0x03FF];
        }
        public byte PeekPal(int addr)
        {
            return pal[addr & ((addr & 0x03) == 0 ? 0x0C : 0x1F)];
        }
        public void PokeNmt(int addr, byte data)
        {
            nmt[nmtBank[addr >> 10 & 0x03]][addr & 0x03FF] = data;
        }
        public void PokePal(int addr, byte data)
        {
            pal[addr & ((addr & 0x03) == 0 ? 0x0C : 0x1F)] = data;
        }

        public void SwitchMirroring(int value)
        {
            nmtBank[0] = (byte)(value >> 3 & 0x01);
            nmtBank[1] = (byte)(value >> 2 & 0x01);
            nmtBank[2] = (byte)(value >> 1 & 0x01);
            nmtBank[3] = (byte)(value >> 0 & 0x01);
        }

        public override void Initialize()
        {
            base.Hook(0x2000, 0x3EFF, PeekNmt, PokeNmt);
            base.Hook(0x3F00, 0x3FFF, PeekPal, PokePal);
        }
    }
}