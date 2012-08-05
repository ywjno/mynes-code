namespace MyNes.Core
{
    public class NesCore
    {
        public static CPU Cpu;
        public static Ppu Ppu;
        public static Apu Apu;
        public static CpuMemory CpuMemory;
        public static PpuMemory PpuMemory;

        /// <summary>
        /// Create new nes emulation core
        /// </summary>
        /// <param name="romPath">The complete rom path</param>
        public static void CreateNew(string romPath)
        { 
        
        }
        /// <summary>
        /// Stop the emulation and dispose components
        /// </summary>
        public static void Shutdown()
        { 
        
        }
    }
}