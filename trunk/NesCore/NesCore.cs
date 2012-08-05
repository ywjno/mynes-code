namespace MyNes.Core
{
    public class NesCore
    {
        private static CPU cpu;
        private static CpuMemory cpuMemory;

        public static CpuMemory CpuMemory
        { get { return CpuMemory; } set { CpuMemory = value; } }
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
    }
}
