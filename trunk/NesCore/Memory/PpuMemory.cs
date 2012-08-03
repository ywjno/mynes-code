namespace MyNes.Core
{
    public class PpuMemory : Memory
    {
        public PpuMemory() :
            base(0x4000)
        { }

        private byte[] pal = new byte[]//Misc, real nes load these values at power up
        {
           0x09,0x01,0x00,0x01,0x00,0x02,0x02,0x0D,0x08,0x10,0x08,0x24,0x00,0x00,0x04,0x2C,
           0x09,0x01,0x34,0x03,0x00,0x04,0x00,0x14,0x08,0x3A,0x00,0x02,0x00,0x20,0x2C,0x08
        };
        private byte[][] nmt;
        private byte[] nmtBank;
        private byte[] Chr;
        private Mirroring mirroring;

        public byte NmtPeek(int addr)
        {
            return nmt[nmtBank[addr >> 10 & 0x03]][addr & 0x03FF];
        }
        private void NmtPoke(int addr, byte data)
        {
            nmt[nmtBank[addr >> 10 & 0x03]][addr & 0x03FF] = data;
        }

        public byte PalPeek(int addr)
        {
            return pal[addr & ((addr & 0x03) == 0 ? 0x0C : 0x1F)];
        }
        private void PalPoke(int addr, byte data)
        {
            pal[addr & ((addr & 0x03) == 0 ? 0x0C : 0x1F)] = data;
        }

        public void SwitchMirroring(byte value)
        {
            this.mirroring = (Mirroring)value;
            nmtBank[0] = (byte)(value >> 6 & 0x03);
            nmtBank[1] = (byte)(value >> 4 & 0x03);
            nmtBank[2] = (byte)(value >> 2 & 0x03);
            nmtBank[3] = (byte)(value >> 0 & 0x03);
        }
        public void SwitchMirroring(Mirroring mirroring)
        {
            SwitchMirroring((byte)mirroring);
        }
        public Mirroring Mirroring
        { get { return mirroring; } set { SwitchMirroring(value); } }
    }
}
