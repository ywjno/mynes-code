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
            public int Gpu;
            public int Spu;

            public System(int master, int cpu, int gpu, int spu)
            {
                this.Master = master;
                this.Cpu = cpu;
                this.Gpu = gpu;
                this.Spu = spu;
            }

            public static bool operator ==(System a, System b)
            {
                return (a.Master == b.Master) && (a.Cpu == b.Cpu) && (a.Gpu == b.Gpu) && (a.Spu == b.Spu);
            }
            public static bool operator !=(System a, System b)
            {
                return (a.Master != b.Master) || (a.Cpu != b.Cpu) || (a.Gpu != b.Gpu) || (a.Spu != b.Spu);
            }
        }
    }
}