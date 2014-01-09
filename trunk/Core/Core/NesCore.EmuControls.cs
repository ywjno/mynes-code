/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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
using System;
using System.Threading;
namespace MyNes.Core
{
    public partial class NesCore
    {
        private static byte clock = 0;
        // Requests
        private static bool softResetRequest = false;
        private static bool hardResetRequest = false;
        /// <summary>
        /// Determine the engine status. True=emulation is on, False=emulation is off
        /// </summary>
        public static bool ON;
        /// <summary>
        /// When the engine is on, this flag pause components from updating.
        /// </summary>
        public static bool PAUSED;
        private static bool SoundEnabled;
        public static bool TogglePauseAtFrameFinish = false;
        // Frame skip
        public static bool FrameSkipEnabled = true;
        private static byte frameSkipTimer;
        public static byte frameSkipReload = 2;

        public static event EventHandler EmuShutdown;

        public static void SoftReset()
        {
            if (ON)
            {
                PAUSED = true;
                softResetRequest = true;
            }
        }
        public static void HardReset()
        {
            if (ON)
            {
                PAUSED = true;
                hardResetRequest = true;
            }
        }
        public static void _HardReset()
        {
            Console.WriteLine("HARD RESET !", DebugCode.Warning);
            clock = 0;
            memoryState = new byte[0];

            SpeedLimiter.HardReset();
            BOARD.HardReset();
            CPU.HardReset();
            PPU.HardReset();
            APU.HardReset();
            ControlsUnit.HardReset();

            if (RomInfo.HasSaveRam)
                LoadSram();
        }
        public static void _SoftReset()
        {
            Console.WriteLine("SOFT RESET !", DebugCode.Warning);
            clock = 0;
            SpeedLimiter.SoftReset();
            BOARD.SoftReset();
            CPU.SoftReset();
            PPU.SoftReset();
            APU.SoftReset();
            ControlsUnit.SoftReset();
        }
        public static void TurnOn(bool useThread)
        {
            _HardReset();
            ON = true;
            //PAUSED = false;
            Console.WriteLine("Emulation turned on.", DebugCode.Good);
            if (useThread)
            {
                MainThread = new Thread(new ThreadStart(RUN));
                MainThread.Start();
                Console.WriteLine("Emulation thread is running !", DebugCode.Good);
            }
        }
        public static void ShutDown()
        {
            if (ON)
            {
                Console.WriteLine("SHUTDOWN EMULATION", DebugCode.Warning);
                ON = false;
                SpeedLimiter.ShutDown();
                BOARD.ShutDown();
                CPU.ShutDown();
                PPU.ShutDown();
                APU.ShutDown();
                ControlsUnit.ShutDown();

                if (VideoOutput != null)
                    VideoOutput.ShutDown();
                if (AudioOutput != null)
                    AudioOutput.Shutdown();

                if (SaveSRAMOnShutdown && RomInfo.HasSaveRam)
                    SaveSram();

                OnEmuShutdown();

                if (MainThread != null)
                {
                    if (MainThread.IsAlive)
                    {
                        Console.WriteLine("Aborting emulation thread ...", DebugCode.Warning);
                        MainThread.Abort();
                    }
                }
            }
        }
        public static void OnEmuShutdown()
        {
            if (EmuShutdown != null)
                EmuShutdown(null, null);
        }
        /// <summary>
        /// Run the emulation. It's better to use this method in separate thread.
        /// </summary>
        public static void RUN()
        {
            while (ON)
            {
                if (!PAUSED)
                {
                    CPU.Clock();
                }
                else
                {
                    if (SpeedLimiter != null)
                        SpeedLimiter.SleepOnPause();
                    if (softResetRequest)
                    {
                        softResetRequest = false;
                        _SoftReset();
                        PAUSED = false;
                    }
                    else if (hardResetRequest)
                    {
                        hardResetRequest = false;
                        _HardReset();
                        PAUSED = false;
                    }
                    else if (saveStateRequest)
                    {
                        _saveState();
                    }
                    else if (loadStateRequest)
                    {
                        _loadState();
                    }
                    else if (saveMemoryStateRequest)
                    {
                        _saveMemoryState();
                    }
                    else if (loadMemoryStateRequest)
                    {
                        _loadMemoryState();
                    }
                    else if (saveSRAMRequest)
                    {
                        SaveSram();
                    }
                    else if (loadSRAMRequest)
                    {
                        LoadSram();
                    }
                    // pause sound if playing
                    if (AudioOutput != null)
                        if (AudioOutput.IsPlaying)
                            AudioOutput.Stop();
                }
            }
        }
        /// <summary>
        /// Clock other components
        /// </summary>
        public static void ClockComponents()
        {
            switch (TV)
            {
                case TVSystem.NTSC:
                case TVSystem.DENDY:// 3 dots per CPU cycle 
                    {
                        PPU.Clock();
                        /*
                         * NMI edge detector polls the status of the NMI line during φ2 of each CPU cycle 
                         * (i.e., during the second half of each cycle) 
                         */
                        CPU.PollInterruptStatus();
                        PPU.Clock();
                        PPU.Clock();
                        APU.Clock();
                        break;
                    }
                case TVSystem.PALB:// 3⅕ dots per CPU cycle; each 5 cpu cycles, ppu clock additional cycle ...
                    {
                        PPU.Clock();
                        /*
                         * NMI edge detector polls the status of the NMI line during φ2 of each CPU cycle 
                         * (i.e., during the second half of each cycle) 
                         */
                        CPU.PollInterruptStatus();
                        PPU.Clock();
                        PPU.Clock();
                        clock++;
                        if (clock == 5)
                        {
                            PPU.Clock();
                            clock = 0;
                        }
                        APU.Clock();
                        break;
                    }
            }
            // Clock mapper !
            BOARD.OnCPUClock();
        }
        public static void FinishFrame(int[] screen)
        {
            // Render   
            if (VideoOutput != null)
            {
                if (FrameSkipEnabled)
                {
                    if (frameSkipTimer == 0)
                    {
                        VideoOutput.RenderFrame(screen);
                    }
                }
                else
                {
                    VideoOutput.RenderFrame(screen);
                }
            }
            if (AudioOutput != null)
            {
                if (SoundEnabled)
                {
                    if (!AudioOutput.IsPlaying)
                        AudioOutput.Play();
                    AudioOutput.UpdateFrame();
                }
            }
            // Update things...
            ControlsUnit.FinishFrame();
            if (FrameSkipEnabled)
            {
                if (frameSkipTimer > 0)
                    frameSkipTimer--;
                else
                    frameSkipTimer = frameSkipReload;
            }
            // Speed
            SpeedLimiter.Update();
            // Frame-end requests
            if (TogglePauseAtFrameFinish)
            {
                TogglePauseAtFrameFinish = false;
                PAUSED = true;
            }
        }
    }
}
