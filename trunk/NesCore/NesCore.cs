namespace MyNes.Core
{
    public class NesCore
    {
        private static Apu apu;
        private static CPU cpu;
        private static Ppu ppu;
        private static CpuMemory cpuMemory;
        private static PpuMemory ppuMemory;

        public static CpuMemory CpuMemory
        { get { return CpuMemory; } set { CpuMemory = value; } }
        public PpuMemory PpuMemory
        {
            get
            {
                return ppuMemory;
            }
            set
            {
                ppuMemory = value;
            }
        }
        public static CPU CPU
        {
            get
            {
                return cpu;
            }
            set
            {
                cpu = value;
            }
        }
        public Ppu Ppu
        {
            get
            {
                return ppu;
            }
            set
            {
                ppu = value;
            }
        }
        public Apu Apu
        {
            get
            {
                return apu;
            }
            set
            {
                apu = value;
            }
        }
    }
}
