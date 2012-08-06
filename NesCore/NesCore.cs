using System.IO;
using System.Threading;
using MyNes.Core.IO.Output;
using MyNes.Core.Boards;

namespace MyNes.Core
{
    public class NesCore
    {
        public static Cpu Cpu;
        public static Ppu Ppu;
        public static Apu Apu;
        public static CpuMemory CpuMemory;
        public static PpuMemory PpuMemory;
        public static Board Board;
        //devices
        public static IVideoDevice VideoDevice;
        public static ISoundDevice AudioDevice;
        //Emulation controls
        public static bool ON;
        public static bool Pause;

        /// <summary>
        /// Create new nes emulation core
        /// </summary>
        /// <param name="romPath">The complete rom path</param>
        public static void CreateNew(string romPath)
        {
            string extension = System.IO.Path.GetExtension(romPath).ToLower();
            switch (extension) 
            {
                case ".nes": Console.WriteLine("INES ROM"); LoadINES(romPath); break;
            }
        }
        private static void LoadINES(string romPath)
        {
            Console.WriteLine("Reading header ...");
            INESHeader header = new INESHeader(romPath);
            Console.UpdateLine("Reading header ... OK");
            if (header.Result == INESHeader.InesOpenRomResult.Valid)
            {
                #region Read banks
                //the header is ok, load the banks
                Stream fileStream = new FileStream(romPath, FileMode.Open, FileAccess.Read);
                fileStream.Position = 16;
                //bank arrays
                byte[] prg = new byte[0];
                byte[] chr = new byte[0];
                byte[] trainer = new byte[0];
                //get trainer if presented
                if (header.HasTrainer)
                {
                    Console.WriteLine("Reading trainer......");
                    trainer = new byte[512];
                    fileStream.Read(trainer, 0, 512);
                    Console.UpdateLine("Reading trainer...... OK");
                }

                //get prg banks
                Console.WriteLine("Reading prg......");
                int prg_roms = header.PrgPages * 4;
                prg = new byte[prg_roms * 4096];
                for (int i = 0; i < prg_roms; i++)
                {
                    fileStream.Read(prg, i * 4096, 4096);
                }
                Console.UpdateLine("Reading prg...... OK");

                //get chr banks if presented
                if (header.ChrPages > 0)
                {
                    Console.WriteLine("Reading chr......");
                    int chr_roms = header.ChrPages * 8;
                    chr = new byte[chr_roms * 1024];
                    for (int i = 0; i < (chr_roms); i++)
                    {
                        fileStream.Read(chr, i * 1024, 1024);
                    }
                    Console.UpdateLine("Reading chr...... OK");
                }
                else
                {
                    Console.WriteLine("No chr, VRAM");
                }
                fileStream.Dispose();
                fileStream.Close();
                #endregion
                #region Get board depending on mapper #
                // TODO: find a way to get board without using switch
                switch (header.Mapper)
                {
                    case 0: Board = new NesNROM128(chr, prg); break;
                }
                #endregion
                //everything is ok, initialize components
                InitializeComponents();
                Console.WriteLine("Ready.", DebugCode.Good);
            }
            else
            {
                Console.WriteLine("Reading header ... Failed", DebugCode.Error);
                switch (header.Result)
                {
                    case INESHeader.InesOpenRomResult.NotINES:
                        Console.WriteLine("Not INES rom", DebugCode.Error);
                        throw new System.Exception("Not INES rom");
                    case INESHeader.InesOpenRomResult.NotSupportedMapper:
                        Console.WriteLine("Mapper not supported", DebugCode.Error);
                        throw new System.Exception("Mapper not supported");
                    default:
                        Console.WriteLine("Can't open this rom", DebugCode.Error);
                        throw new System.Exception("Can't open this rom");
                }
            }
        }
        private static void InitializeComponents()
        {
            //memory first
            CpuMemory = new CpuMemory();
            PpuMemory = new PpuMemory();

            CpuMemory.Initialize();
            PpuMemory.Initialize();
           
            Board.Initialize();

            Cpu = new Cpu(TimingInfo.NTSC);
            Ppu = new Ppu(TimingInfo.NTSC);
            Apu = new Apu(TimingInfo.NTSC);

            Cpu.Initialize();
            Ppu.Initialize();
            Apu.Initialize();
        }

        /// <summary>
        /// Get the emu into the active state
        /// </summary>
        public static void TurnOn() 
        {
            ON = true;
            Console.WriteLine("Emu ON", DebugCode.Good);
        }
        /// <summary>
        /// Run the emu, keep executing the cpu while is ON
        /// </summary>
        public static void Run()
        {
            while (ON)
            {
                if (!Pause)
                {
                    Cpu.Execute();
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
        /// <summary>
        /// Stop the emulation and dispose components
        /// </summary>
        public static void Shutdown()
        {
            Console.WriteLine("SHUTTING DOWN", DebugCode.Warning);
            ON = false;
            Apu.Shutdown();
            Cpu.Shutdown();
            Ppu.Shutdown();
            CpuMemory.Shutdown();
            PpuMemory.Shutdown();
            VideoDevice.Shutdown();
            AudioDevice.Shutdown();
            Console.UpdateLine("EMU SHUTDOWN", DebugCode.Good);
        }
    }
}