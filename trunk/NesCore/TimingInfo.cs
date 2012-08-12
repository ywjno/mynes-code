namespace myNES.Core
{
    public struct TimingInfo
    {
        public static readonly System NTSC = new System(236250000, 132, 44, 264);
        public static readonly System PALB = new System(212813700, 128, 40, 256);

        public int cycles;
        public int period;
        public int single;

        public struct System
        {
            public int Master;
            public int Cpu;
            public int Ppu;
            public int Apu;

            public System(int master, int cpu, int ppu, int apu)
            {
                this.Master = master;
                this.Cpu = cpu;
                this.Ppu = ppu;
                this.Apu = apu;
            }
        }
    }
}