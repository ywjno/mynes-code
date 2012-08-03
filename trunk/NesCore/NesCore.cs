namespace MyNes.Core
{
    public class NesCore
    {
        private static CpuMemory cpuMemory;

        public static CpuMemory CpuMemory
        { get { return CpuMemory; } set { CpuMemory = value; } }
    }
}
