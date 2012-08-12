using System.IO;
using myNES.Core.APU;
using myNES.Core.Boards;
using myNES.Core.Controls;
using myNES.Core.CPU;
using myNES.Core.IO.Input;
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
        public static ControlsUnit ControlsUnit;
        //devices
        public static VideoDevice VideoDevice;
        public static AudioDevice AudioDevice;
        //emulation controls
        public static bool ON;
        public static bool Pause;
        public static SpeedLimiter SpeedLimiter;
        //events
        public static event System.EventHandler EmuShutdown;

        private static TimingInfo.System emuSystem = TimingInfo.NTSC;

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

                Board = INESBoardManager.GetBoard(header, chr, prg);

                if (Board == null)
                {
                    Console.WriteLine("Mapper isn't supported!", DebugCode.Error);
                    throw new System.Exception("Mapper isn't supported!");
                }

                //everything is ok, initialize components
                InitializeComponents();

                PpuMemory.SwitchMirroring(header.Mirroring);

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

            ControlsUnit = new Controls.ControlsUnit();
            ControlsUnit.Initianlize();

            Cpu = new Cpu(emuSystem);
            Ppu = new Ppu(emuSystem);
            Apu = new Apu(emuSystem);

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
                    SpeedLimiter.SleepOnPause();
                }
            }
        }
        /// <summary>
        /// Stop the emulation and dispose components
        /// </summary>
        public static void Shutdown()
        {
            Console.WriteLine("SHUTTING DOWN", DebugCode.Warning);
            if (ON)
            {
                ON = false;
                Apu.Dispose();
                Cpu.Dispose();
                Ppu.Dispose();
                CpuMemory.Dispose();
                PpuMemory.Dispose();
                ControlsUnit.Shutdown();
                VideoDevice.Dispose();
                AudioDevice.Dispose();

                if (EmuShutdown != null)
                    EmuShutdown(null, null);
                Console.UpdateLine("EMU SHUTDOWN", DebugCode.Good);
            }
        }
        public static void SoftReset()
        {
            if (ON)
            {
                Cpu.SoftReset();
                Console.WriteLine("SOFT RESET", DebugCode.Warning);
            }
        }

        /// <summary>
        /// Setup output devices
        /// </summary>
        /// <param name="system">The emulation system</param>
        /// <param name="videoDevice">The video device</param>
        /// <param name="audioDevice"></param>
        public static void SetupOutput(TimingInfo.System system, VideoDevice videoDevice, AudioDevice audioDevice)
        {
            VideoDevice = videoDevice;
            AudioDevice = audioDevice;
            emuSystem = system;
        }
        /// <summary>
        /// Setup input
        /// </summary>
        /// <param name="inputDevice">The input device</param>
        /// <param name="joypad1">The player 1 joypad</param>
        /// <param name="joypad2">The player 2 joypad</param>
        public static void SetupInput(InputPort inputDevice, InputDevice joypad1, InputDevice joypad2)
        {
            SetupInput(inputDevice, joypad1, joypad2, null, null, false);
        }
        /// <summary>
        /// Setup input
        /// </summary>
        /// <param name="inputDevice">The input device</param>
        /// <param name="joypad1">The player 1 joypad</param>
        /// <param name="joypad2">The player 2 joypad</param>
        /// <param name="joypad3">The player 3 joypad</param>
        /// <param name="joypad4">The player 4 joypad</param>
        /// <param name="is4Players">Is 4 players enabled</param>
        public static void SetupInput(InputPort inputDevice, InputDevice joypad1, InputDevice joypad2, InputDevice joypad3, InputDevice joypad4, bool is4Players)
        {
            ControlsUnit.InputDevice = inputDevice;
            ControlsUnit.IsFourPlayers = is4Players;
            ControlsUnit.Joypad1 = joypad1;
            ControlsUnit.Joypad2 = joypad2;
            ControlsUnit.Joypad3 = joypad3;
            ControlsUnit.Joypad4 = joypad4;
        }
        /// <summary>
        /// Setup the speed limiter that should control emulation speed depending on emulation system
        /// </summary>
        /// <param name="timer">The timer</param>
        public static void SetupLimiter(ITimer timer)
        {
            SpeedLimiter = new SpeedLimiter(timer, emuSystem);
        }
    }
}