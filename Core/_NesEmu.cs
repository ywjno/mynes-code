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
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
/*
 * Using one big partial class may increase performance in C#
*/
namespace MyNes.Core
{
    /// <summary>
    /// The nes emulation engine.
    /// </summary>
    public partial class NesEmu
    {
        static NesEmu()
        {
            InputInitialize();
            switch (TVFormat)
            {
                case TVSystem.NTSC: systemIndex = 0; cpuSpeedInHz = 1789772; break;
                case TVSystem.PALB: systemIndex = 1; cpuSpeedInHz = 1662607; break;
                case TVSystem.DENDY: systemIndex = 2; cpuSpeedInHz = 1773448; break;
            }
            if (TVFormat == TVSystem.NTSC)
                FramePeriod = (1.0 / (FPS = 60.0));
            else//PALB, DENDY
                FramePeriod = (1.0 / (FPS = 50.0));
        }
        public static TVSystemSetting TVFormatSetting;
        public static TVSystem TVFormat;
        public static Thread EmulationThread;
        public static bool EmulationON;
        public static bool EmulationPaused;
        public static EmulationStatus EmuStatus;
        public enum EmulationStatus
        { PAUSED, SAVINGSTATE, LOADINGSTATE, SAVINGSNAP, SAVINGSRAM, HARDRESET, SOFTRESET }
        public static string GAMEFILE;
        private static bool DoPalAdditionalClock;
        private static byte palCyc;
        public static bool INITIALIZED;
        /*SRAM*/
        private static bool SaveSRAMAtShutdown;
        private static string SRAMFileName;
        private static string SRAMFolder;
        /*STATE*/
        private static string STATEFileName;
        private static string STATEFolder;
        public static int STATESlot;
        /*Snapshot*/
        private static string SNAPSFolder;
        private static string SNAPSFileName;
        private static string SNAPSFormat;
        private static bool SNAPSReplace;
        /*SPEED LIMITER*/
        public static bool SpeedLimitterON = true;
        public static double CurrentFrameTime;
        public static double ImmediateFrameTime;
        private static double DeadTime;
        private static double LastFrameTime;
        private static double FramePeriod = (1.0 / 60.0988);
        private static double FPS = 0;
        public static int FPSDone;
        // Requests !
        private static bool request_pauseAtFrameFinish;
        private static bool request_hardReset;
        private static bool request_softReset;
        private static bool request_state_save;
        private static bool request_state_load;
        private static bool request_snapshot;
        private static bool request_save_sram;
        // Events !
        /// <summary>
        /// Raised when the emu engine finished shutdown.
        /// </summary>
        public static event EventHandler EMUShutdown;

        /// <summary>
        /// Call this at application start up to set nes default stuff
        /// </summary>
        public static void WarmUp()
        {
            InitializeDACTables();
            NesCartDatabase.LoadDatabase("database.xml");
        }

        /// <summary>
        /// Check a rom file to see if it can be used or not
        /// </summary>
        /// <param name="fileName">The complete file path. Archive is NOT supported.</param>
        /// <param name="is_supported_mapper">Indicates if this rom mapper is supported or not</param>
        /// <param name="has_issues">Indicates if this rom mapper have issues or not</param>
        /// <param name="known_issues">Issues with this mapper.</param>
        /// <returns>True if My Nes can run this game otherwise false.</returns>
        public static bool CheckRom(string fileName, out bool is_supported_mapper,
            out bool has_issues, out string known_issues)
        {
            switch (Path.GetExtension(fileName).ToLower())
            {
                case ".nes":
                    {
                        INes header = new INes();
                        header.Load(fileName, true);
                        if (header.IsValid)
                        {
                            // Check board existince
                            bool found = false;
                            string mapperName = "MyNes.Core.Mapper" + header.MapperNumber.ToString("D3");
                            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                            foreach (Type tp in types)
                            {
                                if (tp.FullName == mapperName)
                                {
                                    board = Activator.CreateInstance(tp) as Board;
                                    is_supported_mapper = board.Supported;
                                    has_issues = board.NotImplementedWell;
                                    known_issues = board.Issues;
                                    found = true;
                                    return true;
                                }
                            }
                            if (!found)
                            {
                                throw new MapperNotSupportedException(header.MapperNumber);
                            }
                            is_supported_mapper = false;
                            has_issues = false;
                            known_issues = "";
                            return false;
                        }
                        is_supported_mapper = false;
                        has_issues = false;
                        known_issues = "";
                        return false;
                    }
            }
            is_supported_mapper = false;
            has_issues = false;
            known_issues = "";
            return false;
        }
        /// <summary>
        /// Create new emulation engine
        /// </summary>
        /// <param name="fileName">The rom complete path. Not compressed</param>
        /// <param name="tvsetting">The tv system setting to use</param>
        /// <param name="makeThread">Indicates if the emulation engine should make an internal thread and run through it. Otherwise you should make a thread and use EMUClock to run the loop.</param>
        public static void CreateNew(string fileName, TVSystemSetting tvsetting, bool makeThread)
        {
            switch (Path.GetExtension(fileName).ToLower())
            {
                case ".nes":
                    {
                        INes header = new INes();
                        header.Load(fileName, true);
                        if (header.IsValid)
                        {
                            INITIALIZED = false;
                            GAMEFILE = fileName;
                            CheckGameVSUnisystem(header.SHA1, header.IsVSUnisystem, header.MapperNumber);
                            // Make SRAM file name
                            SRAMFileName = Path.Combine(SRAMFolder, Path.GetFileNameWithoutExtension(fileName) + ".srm");
                            STATESlot = 0;
                            UpdateStateSlot(STATESlot);
                            // Make snapshots file name
                            SNAPSFileName = Path.GetFileNameWithoutExtension(fileName);
                            // Initialzie
                            MEMInitialize(header);

                            TVFormatSetting = tvsetting;

                            // Hard reset
                            hardReset();
                            // Run emu
                            EmulationPaused = true;
                            EmulationON = true;
                            // Let's go !
                            if (makeThread)
                            {
                                EmulationThread = new Thread(new ThreadStart(EMUClock));
                                EmulationThread.Start();
                            }
                            // Done !
                            INITIALIZED = true;
                        }
                        else
                        {
                            throw new RomNotValidException();
                        }
                        break;
                    }
            }
        }
        public static void ApplySettings(bool saveSramOnSutdown, string sramFolder, string stateFolder,
            string snapshotsFolder, string snapFormat, bool replaceSnap)
        {
            SaveSRAMAtShutdown = saveSramOnSutdown;
            SRAMFolder = sramFolder;
            STATEFolder = stateFolder;
            SNAPSFolder = snapshotsFolder;
            SNAPSFormat = snapFormat;
            SNAPSReplace = replaceSnap;
        }
        /// <summary>
        /// Run the emulation loop while EmulationON is true.
        /// </summary>
        public static void EMUClock()
        {
            while (EmulationON)
            {
                if (!EmulationPaused)
                {
                    CPUClock();
                }
                else
                {
                    EmuStatus = EmulationStatus.PAUSED;
                    if (AudioOut != null)
                    {
                        AudioOut.Pause();
                        audio_playback_w_pos = AudioOut.CurrentWritePosition;
                    }
                    if (request_save_sram)
                    {
                        EmuStatus = EmulationStatus.SAVINGSRAM;
                        request_save_sram = false;
                        SaveSRAM();
                        EmulationPaused = false;
                    }
                    if (request_hardReset)
                    {
                        EmuStatus = EmulationStatus.HARDRESET;
                        request_hardReset = false;
                        hardReset();
                        EmulationPaused = false;
                    }
                    if (request_softReset)
                    {
                        EmuStatus = EmulationStatus.SOFTRESET;
                        request_softReset = false;
                        softReset();
                        EmulationPaused = false;
                    }
                    if (request_state_save)
                    {
                        EmuStatus = EmulationStatus.SAVINGSTATE;
                        request_state_save = false;
                        SaveStateAs(STATEFileName);
                        EmulationPaused = false;
                    }
                    if (request_state_load)
                    {
                        EmuStatus = EmulationStatus.LOADINGSTATE;
                        request_state_load = false;
                        LoadStateAs(STATEFileName);
                        EmulationPaused = false;
                    }
                    if (request_snapshot)
                    {
                        EmuStatus = EmulationStatus.SAVINGSNAP;
                        request_snapshot = false;
                        videoOut.TakeSnapshot(SNAPSFolder, SNAPSFileName, SNAPSFormat, SNAPSReplace);
                        EmulationPaused = false;
                    }
                    Thread.Sleep(100);
                }
            }
            // Shutdown
            ShutDown();
        }
        /// <summary>
        /// Request a hard reset in the next frame.
        /// </summary>
        public static void EMUHardReset()
        {
            request_pauseAtFrameFinish = true;
            request_hardReset = true;
            request_save_sram = true;
        }
        /// <summary>
        /// Request a soft reset in the next frame
        /// </summary>
        public static void EMUSoftReset()
        {
            request_pauseAtFrameFinish = true;
            request_softReset = true;
        }
        /// <summary>
        /// Shutdown the emulation. This will set the EmulationON to false as well.
        /// </summary>
        public static void ShutDown()
        {
            if (!INITIALIZED)
                return;
            EmulationON = false;
            MEMShutdown();
            if (videoOut != null)
                videoOut.ShutDown();
            // videoOut = null;
            if (AudioOut != null)
                AudioOut.Shutdown();
            // AudioOut = null;
            System.GC.Collect();

            CPUShutdown();
            PPUShutdown();
            APUShutdown();

            if (EMUShutdown != null)
                EMUShutdown(null, new EventArgs());

            INITIALIZED = false;
        }
        /// <summary>
        /// Take game snapshot
        /// </summary>
        public static void TakeSnapshot()
        {
            request_pauseAtFrameFinish = true;
            request_snapshot = true;
        }
        public static void SetupGameGenie(bool IsGameGenieActive, GameGenieCode[] GameGenieCodes)
        {
            if (board != null)
                board.SetupGameGenie(IsGameGenieActive, GameGenieCodes);
        }
        public static GameGenieCode[] GameGenieCodes
        { get { return board.GameGenieCodes; } }
        public static bool IsGameGenieActive
        { get { return board.IsGameGenieActive; } }
        public static bool IsGameFoundOnDB
        { get { return board.IsGameFoundOnDB; } }
        public static NesCartDatabaseGameInfo GameInfo
        { get { return board.GameInfo; } }
        public static NesCartDatabaseCartridgeInfo GameCartInfo
        { get { return board.GameCartInfo; } }
        // Internal methods
        private static void ClockComponents()
        {
            PPUClock();
            /*
             * NMI edge detector polls the status of the NMI line during φ2 of each CPU cycle 
             * (i.e., during the second half of each cycle) 
             */
            PollInterruptStatus();
            PPUClock();
            PPUClock();
            if (DoPalAdditionalClock)// In pal system ..
            {
                palCyc++;
                if (palCyc == 5)
                {
                    PPUClock();
                    palCyc = 0;
                }
            }
            APUClock();
            DMAClock();
            board.OnCPUClock();
        }
        private static void OnFinishFrame()
        {
            InputFinishFrame();
            // Sound
            if (SoundEnabled)
            {
                if (!AudioOut.IsPlaying)
                {
                    AudioOut.Play();
                    // Reset buffer
                    audio_playback_w_pos = AudioOut.CurrentWritePosition + audio_playback_latency;
                }
                // Submit sound buffer
                AudioOut.SubmitBuffer(ref audio_playback_buffer);
            }
            // Speed
            ImmediateFrameTime = CurrentFrameTime = GetTime() - LastFrameTime;
            DeadTime = FramePeriod - CurrentFrameTime;
            if (DeadTime < 0)
                audio_playback_w_pos = AudioOut.CurrentWritePosition + audio_playback_latency;
            if (SpeedLimitterON)
            {
                while (ImmediateFrameTime < FramePeriod)
                {
                    ImmediateFrameTime = GetTime() - LastFrameTime;
                }
            }
            LastFrameTime = GetTime();
            // FPS
            FPSDone++;
            // Reset
            if (FPSDone > 1000)
                FPSDone = 0;
            if (request_pauseAtFrameFinish)
            {
                request_pauseAtFrameFinish = false;
                EmulationPaused = true;
            }
        }
        private static void hardReset()
        {
            switch (TVFormatSetting)
            {
                case TVSystemSetting.AUTO:
                    {
                        if (board.GameInfo.Cartridges != null)
                        {
                            if (board.GameCartInfo.System.ToUpper().Contains("PAL"))
                                TVFormat = TVSystem.PALB;
                            else if (board.GameCartInfo.System.ToUpper().Contains("DENDY"))
                                TVFormat = TVSystem.DENDY;
                            else
                                TVFormat = TVSystem.NTSC;
                        }
                        else
                        {
                            TVFormat = TVSystem.NTSC;// force NTSC
                        }
                        break;
                    }
                case TVSystemSetting.NTSC: { TVFormat = TVSystem.NTSC; break; }
                case TVSystemSetting.PALB: { TVFormat = TVSystem.PALB; break; }
                case TVSystemSetting.DENDY: { TVFormat = TVSystem.DENDY; break; }
            }
            DoPalAdditionalClock = TVFormat == TVSystem.PALB;
            palCyc = 0;
            // SPEED LIMITTER
            SpeedLimitterON = true;
            /*
             * IMPORTANT
             * ---------
             * We MUST not use 60, 50 FPS here. Why ?
             * Because of we used close numbers not the real number, for example
             * When FPS calculated in real nes the result was 6.0988 (this is a close number by the way)
             * same for CPU frequency 1789772.67 which is a close number.
             * In emulator, we usually use even more close numbers like:
             * CPU RATE = 1798772 (A 0.67 is lost)
             * FPS = 60 (A 0.0988 is lost)
             * If we continue, some bad result could happen:
             * * Loose of audio samples.
             * * Not as same as real nes speed although we output 60 FPS.
             * * Synchronization problems between audio and video.
             * 
             * To fix this porblem, you need to CLOSE the FPS (or emu speed)
             * to replace the loose. For example, using 1798772 instead of 1789772.67
             * will make a lose of ~ 0.67 Hz. Also using 0.016 second as frame time instead
             * of 1/60 = 0.01666666666666666666666666666667 second will lose 0.00066666666666666666666666666667
             * of a second !
             * This matters after running emulation in minutes.
             * 
             * Again, here, we use close numbers to:
             * * Replace the lost details using close numbers (we use cpu rate 1789772 then we don't use 60.0988 FPS)
             * * Make emulation run (output) as close as possible to real hardware speed.
             * 
             * To make that happen, we need to use what I call the 'DOZAN' method which means focusing.
             * Make emulation run in FPS speed then make audio collect samples (note that FPS speed
             * means your emulator run at 1/FPS for each frame) at REAL time. 
             * You'll notice the sound loose sync after few seconds, adjust the FPS until the sync is ok.
             * To determine that sync is ok, use the video renderer (or some gui) to output
             * the value of (SOUND RENDER BUFFER WRITE POSITION - NES SOUND BUFFER WRITE POSITION)
             * let's call it syncdiffer.
             * Assuming that we have 2 sound buffers, one in emulation engine and other on the renderer.
             * The syncdiffer value will output positive or negative number, that doesn't matter
             * the matter is that number CHANGES AFTER FEW SECOND from value to another ONLY when the
             * sound buffers are not sycnhronised. By adjusting the FPS, we make the syncdiffer never
             * change or change very very small value in time. For example, the syncdiffer would be 5044
             * at time 0 second, In time 60 second the syncdiffer become 7000. This is bad because of the
             * buffers will loose sync after minutes.
             * If syncdiffer become 5055 in 0 second then become 5100 in 60 second thats good but the less
             * change we have in time the better.
             * After we finished, we'll get the very close FPS for the real hardware using close numbers.
             * Here, using FPS = 59.2 for example for NTSC and CPU SPEED used is 1789772 Hz. The sync will 
             * loose after 10 minutes or more.
             * 
             * NOTE that this FPS represents 60.0988 in real nes. It's not nesseccary to use the real
             * time to output the sound like I did, but using the FPS=59.234 here will be good to replace 
             * the loose and then make the emu speed as close as possible to real hardware and that will be better
             * for playing experience.
             */
            if (TVFormat == TVSystem.NTSC)
                FramePeriod = (1.0 / (FPS = 59.234));
            else if (TVFormat == TVSystem.PALB)
                FramePeriod = (1.0 / (FPS = 49.08));
            else if (TVFormat == TVSystem.DENDY)
                FramePeriod = (1.0 / (FPS = 49.74));
            MEMHardReset();
            CPUHardReset();
            PPUHardReset();
            APUHardReset();
            DMAHardReset();
        }
        private static void softReset()
        {
            MEMSoftReset();
            CPUSoftReset();
            PPUSoftReset();
            APUSoftReset();
            DMASoftReset();
        }
        private static double GetTime()
        {
            return (double)Stopwatch.GetTimestamp() / (double)Stopwatch.Frequency;
        }
        private static void takeSnapshot()
        {

        }
    }
}

