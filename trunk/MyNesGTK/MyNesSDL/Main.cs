//  
//  Main.cs
//  
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
// 
//  Copyright (c) 2009 - 2015 Ala Ibrahim Hadid
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using SdlDotNet.Core;
using SdlDotNet.Input;
using MyNes.Core;

namespace MyNesSDL
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Working directory
            WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            WorkingFolder = Path.Combine(WorkingFolder, "MyNes");
            ApplicationFolder = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            Directory.CreateDirectory(WorkingFolder);
            // NES
            NesEmu.WarmUp();
            // Database
            NesCartDatabase.LoadDatabase(Path.Combine(ApplicationFolder, "database.xml"));
            // Load settings !
            Settings.LoadSettings();
            // Execute commands
            Settings.ExecuteCommands(args);

            // Apply settings.
            ApplyEmuSettings();
			
            // Initialize providers
            InitializeVideo();
            InitializeAudio();
            InitializeInput();
            InitializePalette();
            // Initialize rooms (menus)
            InitializeMenus();
            // Load the rom !
            if (args != null)
            {
                if (args.Length > 0)
                {
                    // First arg must be rom path !
                    if (File.Exists(args[0]))
                        LoadRom(args[0]);
                    else
                    {
                        Console.WriteLine("File is not exist at: " + args[0]);
                    }
                }
            }
            // Execute commands of the emulation
            if (NesEmu.EmulationON)
                ExecuteCommands(args);

            // Run SDL
            Events.KeyboardDown += OnKeyDown;
            Events.JoystickButtonDown += OnJoystickButtonDown;  
            Events.JoystickAxisMotion += OnJoystickAxisMove;
            Events.Quit += OnQuit;

            NesEmu.EmulationPaused = false;

            Events.Run();
			
            // Reached here means everything is done.
            Settings.SaveSettings();
        }
        // Game
        public static string CurrentGameFile;
        public static string WorkingFolder;
        public static string ApplicationFolder;
        // Providers
        public static SDLVideo VIDEO;
        public static SDLAudio AUDIO;
        // Shortcuts
        private static Joystick joyState;
        public static Key Key_HardReset;
        public static Key Key_SoftReset;
        public static Key Key_SwitchFullscreen;
        public static Key Key_TakeSnap;
        public static Key Key_SaveState;
        public static Key Key_LoadState;
        public static Key Key_StateSlot0;
        public static Key Key_StateSlot1;
        public static Key Key_StateSlot2;
        public static Key Key_StateSlot3;
        public static Key Key_StateSlot4;
        public static Key Key_StateSlot5;
        public static Key Key_StateSlot6;
        public static Key Key_StateSlot7;
        public static Key Key_StateSlot8;
        public static Key Key_StateSlot9;
        public static Key Key_ShutdownEmu;
        public static Key Key_TogglePause;
        public static Key Key_ToggleTurbo;
        public static Key Key_RecordSound;
        public static Key Key_ToggleFrameSkip;
        public static Key Key_ShowGameStatus;
        // Menu items
        public static bool PausedShowMenu;
        public static int RoomIndex;
        public static List<RoomBase> Rooms;

        public static void LoadRom(string fileName)
        {
            CurrentGameFile = fileName;

            NesEmu.EmulationPaused = true;
            // Make sure it's still paused !
            bool is_supported_mapper = false;
            bool has_issues = false;
            string issues = "";
            if (NesEmu.CheckRom(fileName, out is_supported_mapper, out has_issues, out issues))
            {
                if (!is_supported_mapper)
                {
                    Console.WriteLine("** MAPPER IS NOT SUPPORTED !!");
                    Console.WriteLine("** RUNNING WITH DEFAULT MAPPER CONFIGURATION");
                }
                if (has_issues)
                {
                    Console.WriteLine("** " + issues);
                }
                NesEmu.EmulationON = false;
                NesEmu.EmulationPaused = true;
                // Kill the original thread
                if (NesEmu.EmulationThread != null)
                if (NesEmu.EmulationThread.IsAlive)
                    NesEmu.EmulationThread.Abort();
				
                // Create new
                TVSystemSetting sett = TVSystemSetting.AUTO;
                switch (Settings.TvSystemSetting.ToLower())
                {
                    case "auto":
                        sett = TVSystemSetting.AUTO;
                        break;
                    case "ntsc":
                        sett = TVSystemSetting.NTSC;
                        break;
                    case "palb":
                        sett = TVSystemSetting.PALB;
                        break;
                    case "dendy":
                        sett = TVSystemSetting.DENDY;
                        break;
                }
                NesEmu.CreateNew(fileName, sett, true);
				
                VIDEO.SetWindowTitle();
                InitializePalette();// Confirm palette selection !
                NesEmu.EmulationPaused = true;
            }
            else
            {
                Console.WriteLine(@"** MY NES CAN'T RUN THIS GAME !!");
                if (!is_supported_mapper)
                {
                    Console.WriteLine("** MAPPER IS NOT SUPPORTED !!");
                    Console.WriteLine("** RUNNING WITH DEFAULT MAPPER CONFIGURATION");
                }
                if (has_issues)
                {
                    Console.WriteLine("** " + issues);
                }
                if (NesEmu.EmulationON)
                    NesEmu.EmulationPaused = false;
            }
        }

        private static void ExecuteCommands(string[] commands)
        {
            if (commands == null)
                return;
            if (commands.Length == 0)
                return;
            // Commands that can be ued for emu
            foreach (string command in commands)
            {
                switch (command.ToLower())
                {
                    case "record_sound":
                        AUDIO.Record();
                        break;
                    case "gamegenie_enable":
                        ActiveGameGenie();
                        break;
                    case "state_slot_0":
                        NesEmu.UpdateStateSlot(0);
                        break;
                    case "state_slot_1":
                        NesEmu.UpdateStateSlot(1);
                        break;
                    case "state_slot_2":
                        NesEmu.UpdateStateSlot(2);
                        break;
                    case "state_slot_3":
                        NesEmu.UpdateStateSlot(3);
                        break;
                    case "state_slot_4":
                        NesEmu.UpdateStateSlot(4);
                        break;
                    case "state_slot_5":
                        NesEmu.UpdateStateSlot(5);
                        break;
                    case "state_slot_6":
                        NesEmu.UpdateStateSlot(6);
                        break;
                    case "state_slot_7":
                        NesEmu.UpdateStateSlot(7);
                        break;
                    case "state_slot_8":
                        NesEmu.UpdateStateSlot(8);
                        break;
                    case "state_slot_9":
                        NesEmu.UpdateStateSlot(9);
                        break;
                    case "state_load":// Request a state load on the first rendered frame !
                        NesEmu.LoadState();
                        break;
                }
            }
        }

        private static void InitializeVideo()
        {
            VIDEO = new SDLVideo(NesEmu.TVFormat);
            //NesEmu.SetupVideoRenderer(VIDEO);
        }

        public static void InitializePalette()
        {
            NTSCPaletteGenerator.brightness = Settings.Palette_NTSC_brightness;
            NTSCPaletteGenerator.contrast = Settings.Palette_NTSC_contrast;
            NTSCPaletteGenerator.gamma = Settings.Palette_NTSC_gamma;
            NTSCPaletteGenerator.hue_tweak = Settings.Palette_NTSC_hue_tweak;
            NTSCPaletteGenerator.saturation = Settings.Palette_NTSC_saturation;

            PALBPaletteGenerator.brightness = Settings.Palette_PALB_brightness;
            PALBPaletteGenerator.contrast = Settings.Palette_PALB_contrast;
            PALBPaletteGenerator.gamma = Settings.Palette_PALB_gamma;
            PALBPaletteGenerator.hue_tweak = Settings.Palette_PALB_hue_tweak;
            PALBPaletteGenerator.saturation = Settings.Palette_PALB_saturation;

            if (Settings.Palette_AutoSelect)
            {
                switch (NesEmu.TVFormat)
                {
                    case TVSystem.NTSC:
                        NesEmu.SetPalette(NTSCPaletteGenerator.GeneratePalette());
                        break;
                    case TVSystem.DENDY:
                    case TVSystem.PALB:
                        NesEmu.SetPalette(PALBPaletteGenerator.GeneratePalette());
                        break;
                }
            }
            else
            {
                if (Settings.Palette_UseNTSCPalette)
                    NesEmu.SetPalette(NTSCPaletteGenerator.GeneratePalette());
                else
                    NesEmu.SetPalette(PALBPaletteGenerator.GeneratePalette());
            }
        }

        private static void InitializeAudio()
        {  
            AUDIO = new SDLAudio();
            NesEmu.SetupSoundPlayback(AUDIO, Settings.Audio_PlaybackEnabled, Settings.Audio_PlaybackFrequency);

            NesEmu.audio_playback_dmc_enabled = Settings.Audio_playback_dmc_enabled;
            NesEmu.audio_playback_noz_enabled = Settings.Audio_playback_noz_enabled;
            NesEmu.audio_playback_sq1_enabled = Settings.Audio_playback_sq1_enabled;
            NesEmu.audio_playback_sq2_enabled = Settings.Audio_playback_sq2_enabled;
            NesEmu.audio_playback_trl_enabled = Settings.Audio_playback_trl_enabled;
        }

        public static void InitializeInput()
        {
            LoadShortcuts();
            NesEmu.IsFourPlayers = Settings.Key_Connect4Players;
            NesEmu.IsZapperConnected = Settings.Key_ConnectZapper;
            IJoypadConnecter joy1 = null;
            IJoypadConnecter joy2 = null;
            IJoypadConnecter joy3 = null;
            IJoypadConnecter joy4 = null;
            IVSUnisystemDIPConnecter vsUni = null;
            Console.WriteLine(">Initializing input settings...");
            if (Settings.Key_P1_UseJoystick ||
                Settings.Key_P2_UseJoystick ||
                Settings.Key_P3_UseJoystick ||
                Settings.Key_P4_UseJoystick ||
                Settings.Key_VS_UseJoystick)
            {
                Console.WriteLine(">Initializing joysticks...");
                Joysticks.Initialize();
                Console.WriteLine("->Joysticks number = " + Joysticks.NumberOfJoysticks);
            }
            Console.WriteLine(">Applying key mappings...");
            #region Player 1
            if (!Settings.Key_P1_UseJoystick)
            {
                joy1 = new SDL_Keyboard_Joyad(0);
                Console.WriteLine("->Using keyboard for player 1.");
            }
            else
            {
                if (Joysticks.IsValidJoystickNumber(Settings.Key_P1_JoystickIndex))
                {
                    joy1 = new SDL_Joystick_Joypad(Settings.Key_P1_JoystickIndex, 0);
                    Console.WriteLine("->Using joystick for player 1.");
                }
                else
                {
                    // USE keyboard ?
                    joy1 = new SDL_Keyboard_Joyad(0);
                    Console.WriteLine("->Joystick is not connected; using keyboard for player 1.");
                }
            }
            #endregion
            #region Player 2
            if (!Settings.Key_P2_UseJoystick)
            {
                joy2 = new SDL_Keyboard_Joyad(1);
                Console.WriteLine("->Using keyboard for player 2.");
            }
            else
            {
                if (Joysticks.IsValidJoystickNumber(Settings.Key_P2_JoystickIndex))
                {
                    joy2 = new SDL_Joystick_Joypad(Settings.Key_P2_JoystickIndex, 1);
                    Console.WriteLine("->Using joystick for player 2.");
                }
                else
                {
                    // USE keyboard ?
                    joy2 = new SDL_Keyboard_Joyad(1);
                    Console.WriteLine("->Joystick is not connected; using keyboard for player 2.");
                }
            }
            #endregion
            #region Player 3
            if (!Settings.Key_P3_UseJoystick)
            {
                joy3 = new SDL_Keyboard_Joyad(2);
                Console.WriteLine("->Using keyboard for player 3.");
            }
            else
            {
                if (Joysticks.IsValidJoystickNumber(Settings.Key_P3_JoystickIndex))
                {
                    joy3 = new SDL_Joystick_Joypad(Settings.Key_P3_JoystickIndex, 2);
                    Console.WriteLine("->Using joystick for player 3.");
                }
                else
                {
                    // USE keyboard ?
                    joy3 = new SDL_Keyboard_Joyad(2);
                    Console.WriteLine("->Joystick is not connected; using keyboard for player 3.");
                }
            }
            #endregion
            #region Player 4
            if (!Settings.Key_P4_UseJoystick)
            {
                joy4 = new SDL_Keyboard_Joyad(3);
                Console.WriteLine("->Using keyboard for player 4.");
            }
            else
            {
                if (Joysticks.IsValidJoystickNumber(Settings.Key_P4_JoystickIndex))
                {
                    joy4 = new SDL_Joystick_Joypad(Settings.Key_P4_JoystickIndex, 3);
                    Console.WriteLine("->Using joystick for player 4.");
                }
                else
                {
                    // USE keyboard ?
                    joy4 = new SDL_Keyboard_Joyad(3);
                    Console.WriteLine("->Joystick is not connected; using keyboard for player 4.");
                }
            }
            #endregion
            #region VS Unisystem
            if (!Settings.Key_VS_UseJoystick)
            {
                vsUni = new SDL_Keyboard_VSUnisystem();
                Console.WriteLine("->Using keyboard for VS Unisystem PID.");
            }
            else
            {
                if (Joysticks.IsValidJoystickNumber(Settings.Key_VS_JoystickIndex))
                {
                    vsUni = new SDL_Joystick_VSUnisystem(Settings.Key_VS_JoystickIndex);
                    Console.WriteLine("->Using joystick for VS Unisystem PID.");
                }
                else
                {
                    // USE keyboard ?
                    vsUni = new SDL_Keyboard_VSUnisystem();
                    Console.WriteLine("->Joystick is not connected; using keyboard for VS Unisystem PID.");
                }
            }
            #endregion
            NesEmu.SetupJoypads(joy1, joy2, joy3, joy4);
            NesEmu.SetupVSUnisystemDIP(vsUni);
            NesEmu.IsZapperConnected = Settings.Key_ConnectZapper;
            NesEmu.IsFourPlayers = Settings.Key_Connect4Players;
            if (NesEmu.IsZapperConnected)
            {
                Console.WriteLine("->ZAPPER IS CONNECTED !!");
                NesEmu.SetupZapper(new SDLZapper());
                SdlDotNet.Input.Mouse.ShowCursor = true;
            }
            if (NesEmu.IsFourPlayers)
            {
                Console.WriteLine("->4 PLAYERS IS CONNECTED !!");
            }
            Console.WriteLine(">Input settings initialized successfully.");
        }

        public static void LoadShortcuts()
        { 
            if (Settings.Key_Shortcuts_UseJoystick)
            {
                Joysticks.Initialize();
                if (Joysticks.IsValidJoystickNumber(Settings.Key_Shortcuts_JoystickIndex))
                {
                    joyState = Joysticks.OpenJoystick(Settings.Key_Shortcuts_JoystickIndex);
                }
            }
            Enum.TryParse<Key>(Settings.Key_SoftReset, out Key_SoftReset);
            Enum.TryParse<Key>(Settings.Key_HardReset, out Key_HardReset);
            Enum.TryParse<Key>(Settings.Key_SwitchFullscreen, out Key_SwitchFullscreen);
            Enum.TryParse<Key>(Settings.Key_TakeSnap, out Key_TakeSnap);
            Enum.TryParse<Key>(Settings.Key_SaveState, out Key_SaveState);
            Enum.TryParse<Key>(Settings.Key_LoadState, out Key_LoadState);
            Enum.TryParse<Key>(Settings.Key_StateSlot0, out Key_StateSlot0);
            Enum.TryParse<Key>(Settings.Key_StateSlot1, out Key_StateSlot1);
            Enum.TryParse<Key>(Settings.Key_StateSlot2, out Key_StateSlot2);
            Enum.TryParse<Key>(Settings.Key_StateSlot3, out Key_StateSlot3);
            Enum.TryParse<Key>(Settings.Key_StateSlot4, out Key_StateSlot4);
            Enum.TryParse<Key>(Settings.Key_StateSlot5, out Key_StateSlot5);
            Enum.TryParse<Key>(Settings.Key_StateSlot6, out Key_StateSlot6);
            Enum.TryParse<Key>(Settings.Key_StateSlot7, out Key_StateSlot7);
            Enum.TryParse<Key>(Settings.Key_StateSlot8, out Key_StateSlot8);
            Enum.TryParse<Key>(Settings.Key_StateSlot9, out Key_StateSlot9);
            Enum.TryParse<Key>(Settings.Key_ShutdownEmu, out Key_ShutdownEmu);
            Enum.TryParse<Key>(Settings.Key_TogglePause, out Key_TogglePause);
            Enum.TryParse<Key>(Settings.Key_ToggleTurbo, out Key_ToggleTurbo);
            Enum.TryParse<Key>(Settings.Key_RecordSound, out Key_RecordSound);
            Enum.TryParse<Key>(Settings.Key_ToggleFrameSkip, out Key_ToggleFrameSkip);
            Enum.TryParse<Key>(Settings.Key_ShowGameStatus, out Key_ShowGameStatus);
        }

        private static void InitializeMenus()
        {
            Console.WriteLine(">Loading menu items ...");
            PausedShowMenu = false;
            RoomIndex = 0;
            // Find all rooms ..
            List<Type> types = new List<System.Type>(Assembly.GetExecutingAssembly().GetTypes());
            Rooms = new List<RoomBase>();
            foreach (Type t in types)
            {
                if (t.IsSubclassOf(typeof(RoomBase)))
                {
                    RoomBase room = Activator.CreateInstance(t) as RoomBase;
                    Rooms.Add(room);
                    Console.WriteLine("->Menu page added: " + room.Name);
                }
            }
            // Select the main menu
            SelectRoom("main menu");
        }

        /// <summary>
        /// Selects menu page (room).
        /// </summary>
        /// <param name="name">Room page name.</param>
        public static void SelectRoom(string name)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Name.ToLower() == name.ToLower())
                {
                    RoomIndex = i;
                    Rooms[i].OnOpen();
                    break;
                }
            }
        }

        public static void ActiveGameGenie()
        {
            if (!NesEmu.EmulationON)
            {    
                Program.VIDEO.WriteNotification("Game Genie can't be enabled while emulation is OFF.", 200, System.Drawing.Color.Red);
                return;
            }
            string filePath = Path.Combine(Settings.Folder_GameGenieCodes,
                                  Path.GetFileNameWithoutExtension(Program.CurrentGameFile) + ".ggc");
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                // Clear all
                if (lines.Length > 0)
                {
                    GameGenie gameGenie = new GameGenie();
                    List<GameGenieCode> codes = new List<GameGenieCode>();
                    // Add code by code
                    for (int i = 0; i < lines.Length; i++)
                    {
                        GameGenieCode newcode = new GameGenieCode();
                        newcode.Enabled = true; 
                        newcode.Name = lines[i];

                        if (lines[i].Length == 6)
                        {
                            newcode.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(lines[i]), 6) | 0x8000;
                            newcode.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(lines[i]), 6);
                            newcode.IsCompare = false;
                        }
                        else
                        {
                            newcode.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(lines[i]), 8) | 0x8000;
                            newcode.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(lines[i]), 8);
                            newcode.Compare = gameGenie.GetGGCompareValue(gameGenie.GetCodeAsHEX(lines[i]));
                            newcode.IsCompare = true;
                        }
                        codes.Add(newcode);
                    }
                    if (codes.Count > 0)
                    {
                        NesEmu.SetupGameGenie(true, codes.ToArray());
                        Program.VIDEO.WriteNotification("Game Genie File Loaded; Game Genie enabled.", 200, System.Drawing.Color.Lime);
                    }
                    else
                    {
                        Program.VIDEO.WriteNotification("There is no Game Genie code to load.", 200, System.Drawing.Color.Red);
                    }
                }
                else
                {    
                    Program.VIDEO.WriteNotification("Game Genie file is empty.", 200, System.Drawing.Color.Red);
                }
            }
            else
            {    
                Program.VIDEO.WriteNotification("Game Genie file is not found.", 200, System.Drawing.Color.Red);
            }
        }

        public static void ApplyEmuSettings()
        {
            NesEmu.ApplySettings(Settings.SaveSRAMOnShutdown, Settings.Folder_SRAM, Settings.Folder_STATE, Settings.Folder_SNAPS, Settings.SnapsFormat, Settings.SnapReplace);
        
            NesEmu.SetupFrameSkip(Settings.FrameSkipEnabled, (byte)Settings.FrameSkipCount);
        }

        public static void Quit()
        {
            NesEmu.EmulationON = false;
            NesEmu.EmulationPaused = true;
            // Kill the original thread
            if (NesEmu.EmulationThread != null)
            if (NesEmu.EmulationThread.IsAlive)
                NesEmu.EmulationThread.Abort();
            Events.QuitApplication();
        }

        private static void OnQuit(object sender, SdlDotNet.Core.QuitEventArgs e)
        {
            Quit();
        }

        private static void OnKeyDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (PausedShowMenu)
            {
                Rooms[RoomIndex].DoKeyDown(e);
                if (e.Key == Key.Tab)
                {
                    NesEmu.EmulationPaused = false;
                    PausedShowMenu = false;
                    Rooms[RoomIndex].OnTabResume();
                }
                return;
            }

            if (e.Key == Key.Escape)
            {
                Quit();
            }
            else if (e.Key == Key.Tab)
            {
                if (!PausedShowMenu)
                {
                    NesEmu.EmulationPaused = true;
                    SelectRoom("main menu");
                    PausedShowMenu = true;
                }
                else
                {
                    NesEmu.EmulationPaused = false;
                    PausedShowMenu = false;
                }
            }
            else if (e.Key == Key_SwitchFullscreen)
            {
                VIDEO.SwitchFullscreen();
            }
            else if (e.Key == Key_HardReset)
            {
                if (NesEmu.EmulationON)
                {
                    NesEmu.EMUHardReset();
                }
                else
                {
                    if (CurrentGameFile != "")
                    if (File.Exists(CurrentGameFile))
                        LoadRom(CurrentGameFile);
                }
                VIDEO.WriteNotification("HARD RESET", 120, System.Drawing.Color.Red);
            }
            else if (e.Key == Key_SoftReset)
            {
                NesEmu.EMUSoftReset();
                VIDEO.WriteNotification("SOFT RESET", 120, System.Drawing.Color.LightYellow);
            }
            else if (e.Key == Key_TakeSnap)
            {
                NesEmu.TakeSnapshot();
            }
            else if (e.Key == Key_LoadState)
            {
                NesEmu.LoadState();
            }
            else if (e.Key == Key_SaveState)
            {
                NesEmu.SaveState();
            }
            else if (e.Key == Key_ShutdownEmu)
            {
                NesEmu.EmulationON = false;
            }
            else if (e.Key == Key_StateSlot0)
            {
                NesEmu.UpdateStateSlot(0);
                VIDEO.WriteNotification("STATE SLOT SET TO 0", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot1)
            {
                NesEmu.UpdateStateSlot(1);
                VIDEO.WriteNotification("STATE SLOT SET TO 1", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot2)
            {
                NesEmu.UpdateStateSlot(2);
                VIDEO.WriteNotification("STATE SLOT SET TO 2", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot3)
            {
                NesEmu.UpdateStateSlot(3);
                VIDEO.WriteNotification("STATE SLOT SET TO 3", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot4)
            {
                NesEmu.UpdateStateSlot(4);
                VIDEO.WriteNotification("STATE SLOT SET TO 4", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot5)
            {
                NesEmu.UpdateStateSlot(5);
                VIDEO.WriteNotification("STATE SLOT SET TO 5", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot6)
            {
                NesEmu.UpdateStateSlot(6);
                VIDEO.WriteNotification("STATE SLOT SET TO 6", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot7)
            {
                NesEmu.UpdateStateSlot(7);
                VIDEO.WriteNotification("STATE SLOT SET TO 7", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot8)
            {
                NesEmu.UpdateStateSlot(8);
                VIDEO.WriteNotification("STATE SLOT SET TO 8", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_StateSlot9)
            {
                NesEmu.UpdateStateSlot(9);
                VIDEO.WriteNotification("STATE SLOT SET TO 9", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_TogglePause)
            {
                NesEmu.EmulationPaused = !NesEmu.EmulationPaused;
            }
            else if (e.Key == Key_ToggleTurbo)
            {
                NesEmu.SpeedLimitterON = !NesEmu.SpeedLimitterON;
            }
            else if (e.Key == Key_RecordSound)
            {
                if (AUDIO.IsRecording)
                    AUDIO.StopRecord();
                else
                    AUDIO.Record();
            }
            else if (e.Key == Key_ToggleFrameSkip)
            {
                Settings.FrameSkipEnabled = !Settings.FrameSkipEnabled;
                NesEmu.SetupFrameSkip(Settings.FrameSkipEnabled, (byte)Settings.FrameSkipCount);

                VIDEO.WriteNotification(Settings.FrameSkipEnabled ? "Frame skip enabled." : "Frame skip disabled.", 120, System.Drawing.Color.White);
            }
            else if (e.Key == Key.KeypadPlus || e.Key == Key.Plus)
            {
                if (AUDIO.Volume + 10 < 100)
                    AUDIO.Volume += 10;
                else
                    AUDIO.Volume = 100;
                VIDEO.WriteNotification("VOLUME " + AUDIO.Volume + " %", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key.Minus || e.Key == Key.KeypadMinus)
            {
                if (AUDIO.Volume - 10 > 0)
                    AUDIO.Volume -= 10;
                else
                    AUDIO.Volume = 0;
                VIDEO.WriteNotification("VOLUME " + AUDIO.Volume + " %", 120, System.Drawing.Color.Lime);
            }
            else if (e.Key == Key_ShowGameStatus)
            {
                VIDEO.ShowGameStatus();
            }
        }

        private static void OnJoystickButtonDown(object sender, SdlDotNet.Input.JoystickButtonEventArgs e)
        {
            if (PausedShowMenu)
            {
                Rooms[RoomIndex].DoJoystickButtonDown(e);
                return;
            }

            CheckJoyShortcuts();
        }

        private static bool IsJoyButtonPressed(string button)
        {
            if (button == "+X")
            {
                return joyState.GetAxisPosition(JoystickAxis.Horizontal) == 1;
            }
            else if (button == "-X")
            {
                return joyState.GetAxisPosition(JoystickAxis.Horizontal) == 0;
            }
            else if (button == "+Y")
            {
                return joyState.GetAxisPosition(JoystickAxis.Vertical) == 1;
            }
            else if (button == "-Y")
            {
                return joyState.GetAxisPosition(JoystickAxis.Vertical) == 0;
            }
            else
            {
                int value = -1;
                if (int.TryParse(button, out value))
                    return joyState.GetButtonState(value) == ButtonKeyState.Pressed;
            }
            return false;
        }

        private static void CheckJoyShortcuts()
        {
            if (IsJoyButtonPressed(Settings.JoyKey_SwitchFullscreen))
            {
                VIDEO.SwitchFullscreen();
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_HardReset))
            {
                if (NesEmu.EmulationON)
                {
                    NesEmu.EMUHardReset();
                }
                else
                {
                    if (CurrentGameFile != "")
                    if (File.Exists(CurrentGameFile))
                        LoadRom(CurrentGameFile);
                }
                VIDEO.WriteNotification("HARD RESET", 120, System.Drawing.Color.Red);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_SoftReset))
            {
                NesEmu.EMUSoftReset();
                VIDEO.WriteNotification("SOFT RESET", 120, System.Drawing.Color.LightYellow);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_TakeSnap))
            {
                NesEmu.TakeSnapshot();
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_LoadState))
            {
                NesEmu.LoadState();
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_SaveState))
            {
                NesEmu.SaveState();
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_ShutdownEmu))
            {
                NesEmu.EmulationON = false;
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot0))
            {
                NesEmu.UpdateStateSlot(0);
                VIDEO.WriteNotification("STATE SLOT SET TO 0", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot1))
            {
                NesEmu.UpdateStateSlot(1);
                VIDEO.WriteNotification("STATE SLOT SET TO 1", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot2))
            {
                NesEmu.UpdateStateSlot(2);
                VIDEO.WriteNotification("STATE SLOT SET TO 2", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot3))
            {
                NesEmu.UpdateStateSlot(3);
                VIDEO.WriteNotification("STATE SLOT SET TO 3", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot4))
            {
                NesEmu.UpdateStateSlot(4);
                VIDEO.WriteNotification("STATE SLOT SET TO 4", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot5))
            {
                NesEmu.UpdateStateSlot(5);
                VIDEO.WriteNotification("STATE SLOT SET TO 5", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot6))
            {
                NesEmu.UpdateStateSlot(6);
                VIDEO.WriteNotification("STATE SLOT SET TO 6", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot7))
            {
                NesEmu.UpdateStateSlot(7);
                VIDEO.WriteNotification("STATE SLOT SET TO 7", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot8))
            {
                NesEmu.UpdateStateSlot(8);
                VIDEO.WriteNotification("STATE SLOT SET TO 8", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_StateSlot9))
            {
                NesEmu.UpdateStateSlot(9);
                VIDEO.WriteNotification("STATE SLOT SET TO 9", 120, System.Drawing.Color.Lime);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_TogglePause))
            {
                NesEmu.EmulationPaused = !NesEmu.EmulationPaused;
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_ToggleTurbo))
            {
                NesEmu.SpeedLimitterON = !NesEmu.SpeedLimitterON;
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_RecordSound))
            {
                if (AUDIO.IsRecording)
                    AUDIO.StopRecord();
                else
                    AUDIO.Record();
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_ToggleFrameSkip))
            {
                Settings.FrameSkipEnabled = !Settings.FrameSkipEnabled;
                NesEmu.SetupFrameSkip(Settings.FrameSkipEnabled, (byte)Settings.FrameSkipCount);

                VIDEO.WriteNotification(Settings.FrameSkipEnabled ? "Frame skip enabled." : "Frame skip disabled.", 120, System.Drawing.Color.White);
            }
            else if (IsJoyButtonPressed(Settings.JoyKey_ShowGameStatus))
            {
                VIDEO.ShowGameStatus();
            }
        }

        private static void OnJoystickAxisMove(object sender, SdlDotNet.Input.JoystickAxisEventArgs e)
        {
            if (PausedShowMenu)
            {
                Rooms[RoomIndex].DoJoystickAxisMove(e);
                return;
            }
            CheckJoyShortcuts();
        }
    }
}

