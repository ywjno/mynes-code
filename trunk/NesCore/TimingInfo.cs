namespace MyNes.Core
{
    public struct TimingInfo
    {
        public static readonly Cookie NTSC = new Cookie(236250000, 132, 44, 264);
        public static readonly Cookie PALB = new Cookie(212813700, 128, 40, 256);

        public int cycles;
        public int period;
        public int single;

        public struct Cookie
        {
            public int Master;
            public int Cpu;
            public int Gpu;
            public int Spu;

            public Cookie(int master, int cpu, int gpu, int spu)
            {
                this.Master = master;
                this.Cpu = cpu;
                this.Gpu = gpu;
                this.Spu = spu;
            }
        }
    }
}