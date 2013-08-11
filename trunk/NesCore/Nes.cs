/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using MyNes.Core.APU;
using MyNes.Core.Boards;
using MyNes.Core.Controls;
using MyNes.Core.CPU;
using MyNes.Core.Exceptions;
using MyNes.Core.IO.Input;
using MyNes.Core.IO.Output;
using MyNes.Core.PPU;
using MyNes.Core.ROM;
using MyNes.Core.Types;
using MyNes.Core.Database;
using System.IO;
using System.Drawing;

namespace MyNes.Core
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
        public static IVideoDevice VideoDevice;
        public static IAudioDevice AudioDevice;
        public static bool SoundEnabled = true;
        //emulation controls
        public static bool ON;
        public static bool Pause;
        public static SpeedLimiter SpeedLimiter;
        private static bool softResetRequest = false;
        private static bool hardResetRequest = false;
        /// <summary>
        /// Set to true atomatically after emulation initialize. Set to false atomatically after shutdown of ALL components.
        /// </summary>
        public static bool Initialized = false;
        //events
        /// <summary>
        /// Rised when the emulation shutdown
        /// </summary>
        public static event System.EventHandler EmuShutdown;
        /// <summary>
        /// Rised when the user request a fullscreen state change
        /// </summary>
        public static event System.EventHandler FullscreenSwitch;
        //others
        public static RomInfo RomInfo;
        public static bool SaveSramOnShutdown = true;
        //state
        private static bool saveStateRequest;
        public static bool saveMemoryStateRequest;
        private static bool loadStateRequest;
        public static bool loadMemoryStateRequest;
        private static string requestStatePath;
        public static byte[] memoryState;
        public static int StateSlot = 0;
        public static bool TogglePauseAtFrameFinish = false;
        private static bool fullscreenRequest = false;

        public static TimingInfo.System emuSystem = TimingInfo.NTSC;

        /// <summary>
        /// Create new nes emulation core
        /// </summary>
        /// <param name="romPath">The complete rom path</param>
        public static void CreateNew(string romPath, EmulationSystem systemType)
        {
            if (ON)
            {
                throw new System.Exception("Nes is on !");
            }
            Initialized = false;
            string extension = System.IO.Path.GetExtension(romPath).ToLower();
            switch (extension)
            {
                case ".nes": Console.WriteLine("INES ROM"); LoadINES(romPath, systemType); break;
            }
        }
        private static void LoadINES(string romPath, EmulationSystem systemType)
        {
            Console.WriteLine("Reading header...");

            INESHeader header = new INESHeader(romPath);

            if (header.IsValid)
            {
                Console.UpdateLine("Reading header... Success!", DebugCode.Good);

                RomInfo = new ROM.RomInfo(romPath);
                RomInfo.Format = "INES";
                RomInfo.CHRcount = header.ChrPages;
                RomInfo.PRGcount = header.PrgPages;
                RomInfo.Mirroring = header.Mirroring;
                RomInfo.MapperBoard = "Mapper " + header.Mapper;
                RomInfo.HasSaveRam = header.HasSaveRam;
                // This is not a fix, 
                // all mapper 99 roms are vsunisystem and doesn't have the flag set !
                RomInfo.VSUnisystem = header.IsVSUnisystem || (header.Mapper == 99);
                RomInfo.PC10 = header.IsPlaychoice10;
                #region Select emulation system
                switch (systemType)
                {
                    case EmulationSystem.AUTO:
                        //as virtually no ROM images in circulation make use of the INES header system bit, we'll depend on database 
                        //to specify emulation system. 
                        if (RomInfo.DatabaseGameInfo.Cartridges != null)
                        {
                            if (RomInfo.DatabaseCartInfo.System.ToUpper().Contains("PAL"))
                                emuSystem = TimingInfo.PALB;
                            else if (RomInfo.DatabaseCartInfo.System.ToUpper().Contains("DENDY"))
                                emuSystem = TimingInfo.Dendy;
                            else
                                emuSystem = TimingInfo.NTSC;
                        }
                        else
                        {
                            emuSystem = TimingInfo.NTSC;//set NTSC by default
                        }
                        break;
                    case EmulationSystem.NTSC: emuSystem = TimingInfo.NTSC; break;
                    case EmulationSystem.PALB: emuSystem = TimingInfo.PALB; break;
                    case EmulationSystem.DENDY: emuSystem = TimingInfo.Dendy; break;
                }
                Console.WriteLine("Switching to " + emuSystem.Name + " system.");
                #endregion
                #region Read banks

                var stream = File.OpenRead(romPath);
                var reader = new BinaryReader(stream);

                stream.Seek(16L, SeekOrigin.Begin);

                // Read trainer if presented
                byte[] trainer = new byte[512];
                if (header.HasTrainer)
                {
                    Console.WriteLine("Trainer found! reading...");
                    stream.Read(trainer, 0, 512);
                }

                // Get PRG dump

                Console.WriteLine("Reading PRG-ROM...");

                byte[] prg = reader.ReadBytes(header.PrgPages * 0x4000);

                Console.UpdateLine("Reading PRG-ROM... Finished!");

                Console.WriteLine("Reading CHR-ROM...");

                byte[] chr = reader.ReadBytes(header.ChrPages * 0x2000);

                Console.UpdateLine("Reading CHR-ROM... Finished!");

                if (chr.Length == 0)
                {
                    Console.WriteLine("No chr, activated VRAM");
                    chr = new byte[0x10000]; // assume 64kb vram
                }

                reader.Close();

                #endregion

                //Board = INESBoardManager.GetBoard(header, chr, prg, trainer);
                Board = BoardsManager.GetBoard(header, chr, prg, trainer);

                if (Board == null)
                {
                    Console.WriteLine("Mapper isn't supported!", DebugCode.Error);
                    throw new NotSupportedMapperException("Mapper isn't supported!\n" + "Mapper # = " + header.Mapper);
                }
                RomInfo.MapperBoard += " [" + Board.Name + "]";
                //everything is ok, initialize components
                InitializeComponents();

                Console.WriteLine("Ready.", DebugCode.Good);
            }
            else
            {
                Console.UpdateLine("Reading header... Failed", DebugCode.Error);
                Console.WriteLine("Can't open this rom, Unspecified error or not INES format", DebugCode.Error);
                throw new ReadRomFailedException("Can't open this rom, Unspecified error or not INES format");
            }
        }
        private static void InitializeComponents()
        {
            //memory first
            CpuMemory = new CpuMemory();
            PpuMemory = new PpuMemory();

            CpuMemory.Initialize();
            PpuMemory.Initialize();

            ControlsUnit = new Controls.ControlsUnit();
            ControlsUnit.Initianlize();

            Cpu = new Cpu(emuSystem);
            Ppu = new Ppu(emuSystem);
            Apu = new Apu(emuSystem);

            Ppu.Initialize();
            Apu.Initialize();
            Board.Initialize();
            Cpu.Initialize();
            //load sram
            if (RomInfo.HasSaveRam)
                LoadSram();
            Initialized = true;
        }

        /// <summary>
        /// Get the emu into the active state
        /// </summary>
        public static void TurnOn()
        {
            Pause = false;
            ON = true;
            Console.WriteLine("Emu ON", DebugCode.Good);
        }
        public static void TogglePause(bool pause)
        {
            Pause = pause;
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
                    if (SpeedLimiter != null)
                        SpeedLimiter.SleepOnPause();

                    if (softResetRequest)
                    {
                        softResetRequest = false;
                        _softReset();
                        Pause = false;
                    }
                    else if (hardResetRequest)
                    {
                        hardResetRequest = false;
                        _hardReset();
                        Pause = false;
                    }
                    else if (saveStateRequest)
                    {
                        _saveState();
                    }
                    else if (loadStateRequest)
                    {
                        _loadState();
                    }

                    // for shortcuts
                    if (ControlsUnit != null)
                        if (ControlsUnit.InputDevice != null)
                            ControlsUnit.InputDevice.UpdateEvents();
                    // pause sound if playing
                    if (AudioDevice != null)
                        if (AudioDevice.IsPlaying)
                            AudioDevice.Stop();
                    // fullscreen switch request
                    if (fullscreenRequest)
                    {
                        fullscreenRequest = false;
                        if (FullscreenSwitch != null)
                            FullscreenSwitch(null, null);
                    }
                }
                if (saveMemoryStateRequest)
                {
                    _saveMemoryState();
                }
                else if (loadMemoryStateRequest)
                {
                    _loadMemoryState();
                }
            }
        }
        public static void FinishFrame(int[][] screen)
        {
            VideoDevice.RenderFrame(screen);
            if (SoundEnabled)
            {
                if (!AudioDevice.IsPlaying)
                    AudioDevice.Play();
                AudioDevice.UpdateFrame();
            }
            SpeedLimiter.Update();
            //for shortcuts
            ControlsUnit.InputDevice.UpdateEvents();
            ControlsUnit.FinishFrame();

            if (TogglePauseAtFrameFinish)
            {
                TogglePauseAtFrameFinish = false;
                Pause = true;
            }
        }

        /// <summary>
        /// Stop the emulation and dispose components
        /// </summary>
        public static void Shutdown()
        {
            Pause = true;
            if (ON)
            {
                ON = false;
                if (VideoDevice != null)
                    VideoDevice.DrawText("SHUTTING DOWN", 160, Color.Gold);
                Console.WriteLine("SHUTTING DOWN", DebugCode.Warning);

                if (SaveSramOnShutdown && RomInfo.HasSaveRam)
                    SaveSram();
                Apu.Shutdown();
                Cpu.Shutdown();
                Ppu.Shutdown();
                CpuMemory.Shutdown();
                PpuMemory.Shutdown();
                ControlsUnit.Shutdown();
                VideoDevice.Shutdown();
                AudioDevice.Shutdown();
                Initialized = false;
                Console.UpdateLine("EMU SHUTDOWN", DebugCode.Good);
                OnEmuShutdown();
            }
        }
        public static void OnEmuShutdown()
        {
            if (EmuShutdown != null)
                EmuShutdown(null, null);
        }
        public static void SoftReset()
        {
            if (ON)
            {
                Pause = true;
                softResetRequest = true;
                Console.WriteLine("SOFT RESET", DebugCode.Warning);
            }
        }
        private static void _softReset()
        {
            CpuMemory.SoftReset();
            PpuMemory.SoftReset();
            ControlsUnit.SoftReset();
            Board.SoftReset();
            Cpu.SoftReset();
            Apu.SoftReset();
            Ppu.SoftReset();

            if (VideoDevice != null)
                VideoDevice.DrawText("SOFT RESET", 160, Color.Gold);
        }
        public static void HardReset()
        {
            if (ON)
            {
                Pause = true;
                hardResetRequest = true;
                Console.WriteLine("HARD RESET", DebugCode.Warning);
            }
        }
        private static void _hardReset()
        {
            CpuMemory.HardReset();
            PpuMemory.HardReset();
            ControlsUnit.HardReset();
            SpeedLimiter.HardReset();
            Board.HardReset();
            Cpu.HardReset();
            Apu.HardReset();
            Ppu.HardReset();
            SetupPalette();
            if (RomInfo.HasSaveRam)
                LoadSram();
            if (VideoDevice != null)
                VideoDevice.DrawText("HARD RESET", 160, Color.Gold);
        }
        public static void LoadSram()
        {
            string dir = Path.GetDirectoryName(RomInfo.Path);
            if (dir.Length == 0)
                dir = Path.GetPathRoot(RomInfo.Path);
            LoadSramAs(Path.Combine(dir, Path.GetFileNameWithoutExtension(RomInfo.Path) + ".sav"));
        }
        public static void LoadSramAs(string sramPath)
        {
            if (File.Exists(sramPath))
            {
                Stream str = new FileStream(sramPath, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[str.Length];
                str.Read(buffer, 0, buffer.Length);
                str.Close();
                str.Dispose();

                Board.SetSram(buffer);
            }
        }
        public static void SaveSram()
        {
            string dir = Path.GetDirectoryName(RomInfo.Path);
            if (dir.Length == 0)
                dir = Path.GetPathRoot(RomInfo.Path);
            SaveSramAs(Path.Combine(dir, Path.GetFileNameWithoutExtension(RomInfo.Path) + ".sav"));
        }
        public static void SaveSramAs(string sramPath)
        {
            byte[] buffer = Board.GetSaveRam();
            if (buffer != null)
            {
                Stream str = new FileStream(sramPath, FileMode.Create, FileAccess.Write);
                str.Write(buffer, 0, buffer.Length);
                str.Close();
                str.Dispose();
            }
        }

        /// <summary>
        /// Call this at the start of your program (in Main() method in Program.cs for example) to load up boards, database ..etc
        /// </summary>
        public static void StartUp()
        {
            //load database
            if (File.Exists(Path.Combine(Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]), "database.xml")))
                NesDatabase.LoadDatabase(Path.Combine(Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]), "database.xml"));
            //load boards
            BoardsManager.LoadAvailableBoards();
        }
        /*SETUP*/
        /// <summary>
        /// Setup output devices
        /// </summary>
        /// <param name="system">The emulation system</param>
        /// <param name="videoDevice">The video device</param>
        /// <param name="audioDevice"></param>
        public static void SetupOutput(IVideoDevice videoDevice, IAudioDevice audioDevice, ApuPlaybackDescription des)
        {
            VideoDevice = videoDevice;
            AudioDevice = audioDevice;
            Apu.SetupPlayback(des);
        }
        /// <summary>
        /// Setup input
        /// </summary>
        /// <param name="inputDevice">The input device</param>
        /// <param name="joypad1">The player 1 joypad</param>
        /// <param name="joypad2">The player 2 joypad</param>
        public static void SetupInput(IInputDevice inputDevice, IJoypad joypad1, IJoypad joypad2)
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
        public static void SetupInput(IInputDevice inputDevice, IJoypad joypad1, IJoypad joypad2, IJoypad joypad3, IJoypad joypad4, bool is4Players)
        {
            ControlsUnit.InputDevice = inputDevice;
            ControlsUnit.IsFourPlayers = is4Players;
            ControlsUnit.Joypad1 = joypad1;
            ControlsUnit.Joypad2 = joypad2;
            ControlsUnit.Joypad3 = joypad3;
            ControlsUnit.Joypad4 = joypad4;
            SpeedLimiter = new SpeedLimiter(emuSystem);
        }
        public static void SetupPalette()
        {
            if (emuSystem.Master == TimingInfo.NTSC.Master)
                Ppu.SetupPalette(NTSCPaletteGenerator.GeneratePalette());
            else//use pal palette for pal and dendy
                Ppu.SetupPalette(PALBPaletteGenerator.GeneratePalette());
        }
        /// <summary>
        /// Rise the FullscreenSwitch event (this will request a switch at next cpu clock)
        /// </summary>
        public static void OnFullscreen()
        {
            Pause = true;
            fullscreenRequest = true;
        }
        /*STATE*/
        public static void LoadState(string stateFolder)
        {
            LoadStateAs(Path.Combine(stateFolder, Path.GetFileNameWithoutExtension(RomInfo.Path) + "_" + StateSlot + ".msn"));
        }
        public static void LoadStateAs(string fileName)
        {
            TogglePauseAtFrameFinish = true;
            requestStatePath = fileName;
            loadStateRequest = true;
        }
        public static void SaveState(string stateFolder)
        {
            SaveStateAs(Path.Combine(stateFolder, Path.GetFileNameWithoutExtension(RomInfo.Path) + "_" + StateSlot + ".msn"));
        }
        public static void SaveStateAs(string fileName)
        {
            TogglePauseAtFrameFinish = true;
            requestStatePath = fileName;
            saveStateRequest = true;
        }
        private static void _saveState()
        {
            saveStateRequest = false;
            Console.WriteLine("Saving state at slot " + StateSlot);
            StateStream st = new StateStream(requestStatePath, false);
            st.WriteHeader(RomInfo.SHA1);

            //save
            Cpu.SaveState(st);
            Ppu.SaveState(st);
            Apu.SaveState(st);
            CpuMemory.SaveState(st);
            PpuMemory.SaveState(st);
            Board.SaveState(st);
            ControlsUnit.SaveState(st);

            st.Finish();

            //save snap
            VideoDevice.TakeSnapshot(Path.GetDirectoryName(requestStatePath), Path.GetFileNameWithoutExtension(requestStatePath),
                ".png", true);
            //save text info
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(requestStatePath),
                Path.GetFileNameWithoutExtension(requestStatePath) + ".txt"), RomInfo.Path);
            if (VideoDevice != null)
                VideoDevice.DrawText("State saved at slot " + StateSlot, 120, Color.Green);
            Console.WriteLine("State saved at slot " + StateSlot, DebugCode.Good);
            Pause = false;
        }
        private static void _loadState()
        {
            Console.WriteLine("Loading state at slot " + StateSlot);
            StateStream st = new StateStream(requestStatePath, true);
            if (!st.IsVailed)
            {
                if (VideoDevice != null)
                    VideoDevice.DrawText("No state found at slot " + StateSlot, 120, Color.Red);
                goto Finish;
            }
            if (!st.ReadHeader(RomInfo.SHA1))
            {
                if (VideoDevice != null)
                    VideoDevice.DrawText("Unable to load state from slot " + StateSlot + ", corrupted header !!", 120, Color.Green);
                Console.WriteLine("Unable to load state, corrupted header !!", DebugCode.Error);
                goto Finish;
            }

            Cpu.LoadState(st);
            Ppu.LoadState(st);
            Apu.LoadState(st);
            CpuMemory.LoadState(st);
            PpuMemory.LoadState(st);
            Board.LoadState(st);
            ControlsUnit.LoadState(st);
            if (VideoDevice != null)
                VideoDevice.DrawText("State loaded from slot " + StateSlot, 120, Color.Green);
            Console.WriteLine("State loaded from slot " + StateSlot, DebugCode.Good);
        Finish:
            st.Finish();
            loadStateRequest = false;
            Pause = false;
        }
        /*Memory State*/
        public static void SaveMemoryState()
        {
            saveMemoryStateRequest = true;
        }
        private static void _saveMemoryState()
        {
            StateStream st = new StateStream();
            // memoryState.WriteHeader(RomInfo.SHA1);

            //save
            Cpu.SaveState(st);
            Ppu.SaveState(st);
            Apu.SaveState(st);
            CpuMemory.SaveState(st);
            PpuMemory.SaveState(st);
            Board.SaveState(st);
            ControlsUnit.SaveState(st);

            memoryState = st.GetBuffer();
            st.Finish();
            saveMemoryStateRequest = false;
        }
        public static void LoadMemoryState()
        {
            loadMemoryStateRequest = true;
        }
        private static void _loadMemoryState()
        {
            if (memoryState != null)
            {
                StateStream st = new StateStream(memoryState);

                Cpu.LoadState(st);
                Ppu.LoadState(st);
                Apu.LoadState(st);
                CpuMemory.LoadState(st);
                PpuMemory.LoadState(st);
                Board.LoadState(st);
                ControlsUnit.LoadState(st);

                st.Finish();
            }
            loadMemoryStateRequest = false;
        }
        public static byte[] GetMemoryState()
        {
            return memoryState;
        }
        public static void SetMemoryState(byte[] state)
        {
            memoryState = state;
        }
    }
}