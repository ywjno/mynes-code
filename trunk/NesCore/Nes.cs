using System.IO;
using System.Threading;
using myNES.Core.APU;
using myNES.Core.Boards;
using myNES.Core.Boards.Discreet;
using myNES.Core.Boards.Nintendo;
using myNES.Core.CPU;
using myNES.Core.IO.Output;
using myNES.Core.PPU;
using myNES.Core.ROM;

namespace myNES.Core
{
    public class Nes
    {
        public static Cpu Cpu;
        public static Ppu Ppu;
        public static Apu Apu;
        public static CpuMemory CpuMemory;
        public static PpuMemory PpuMemory;
        public static Board Board;
        //devices
        public static IVideoDevice VideoDevice;
        public static IAudioDevice AudioDevice;
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
            Console.WriteLine("Reading header...");

            INESHeader header = new INESHeader(romPath);

            if (header.Result == INESHeader.INESResult.Valid)
            {
                Console.UpdateLine("Reading header... Success!", DebugCode.Good);

                #region Read banks

                var stream = File.OpenRead(romPath);
                var reader = new BinaryReader(stream);

                stream.Seek(16L, SeekOrigin.Begin);

                // Skip trainer if presented
                if (header.HasTrainer)
                {
                    Console.WriteLine("Trainer found! Skipping...");
                    stream.Seek(512L, SeekOrigin.Current);
                }

                // Get PRG dump
                Console.WriteLine("Reading PRG-ROM...");

                byte[] prg = reader.ReadBytes(header.PrgPages * 16384);

                Console.UpdateLine("Reading PRG-ROM... Finished!");

                Console.WriteLine("Reading CHR-ROM...");

                byte[] chr = reader.ReadBytes(header.ChrPages * 8192);

                Console.UpdateLine("Reading CHR-ROM... Finished!");

                if (chr.Length == 0)
                {
                    Console.WriteLine("No chr, VRAM");
                    chr = new byte[8192]; // assume 8kb vram
                }

                reader.Close();

                #endregion

                Board = BoardManager.GetBoard(header, chr, prg);

                if (Board == null)
                {
                    Console.WriteLine("Mapper isn't supported!", DebugCode.Error);
                    return;
                }

                //everything is ok, initialize components
                InitializeComponents();
                Console.WriteLine("Ready.", DebugCode.Good);
            }
            else
            {
                Console.UpdateLine("Reading header... Failed", DebugCode.Error);

                switch (header.Result)
                {
                    case INESHeader.INESResult.InvalidHeader:
                        Console.WriteLine("Not INES rom", DebugCode.Error);
                        throw new System.Exception("Not INES rom");
                    case INESHeader.INESResult.InvalidMapper:
                        Console.WriteLine("Mapper not supported", DebugCode.Error);
                        throw new System.Exception("Mapper not supported");
                    default:
                        Console.WriteLine("Can't open this rom (Unspecified error)", DebugCode.Error);
                        throw new System.Exception("Can't open this rom (Unspecified error)");
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
                    Cpu.Update();
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