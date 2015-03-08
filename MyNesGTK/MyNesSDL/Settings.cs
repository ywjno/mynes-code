//  
//  Settings.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using MyNes.Core;

namespace MyNesSDL
{
    public class Settings
    {
        static Settings()
        {
            BuildCommands();
            if (Program.WorkingFolder != null)
                SettingsFilePath = Path.Combine(Program.WorkingFolder, "SDLSettings.conf");
        }

        private static string SettingsFilePath;
        // Folders
        public static string Folder_STATE;
        public static string Folder_SRAM;
        public static string Folder_SNAPS;
        public static string Folder_SoundRecords;
        public static string Folder_GameGenieCodes;
        // Video
        public static bool Video_AutoResizeToFitEmu;
        public static int Video_StretchMulti;
        public static int Video_ScreenWidth;
        public static int Video_ScreenHeight;
        public static bool Video_KeepAspectRatio;
        public static bool Video_HideLinesForNTSCAndPAL;
        public static int Video_FullScreenModeIndex;
        public static bool Video_StartInFullscreen;
        public static bool Video_ShowFPS;
        public static bool Video_ShowNotification;
        // Audio
        public static int Audio_PlaybackVolume;
        public static int Audio_PlaybackFrequency;
        public static bool Audio_PlaybackEnabled;
        public static bool Audio_playback_dmc_enabled;
        public static bool Audio_playback_noz_enabled;
        public static bool Audio_playback_sq1_enabled;
        public static bool Audio_playback_sq2_enabled;
        public static bool Audio_playback_trl_enabled;
        // Palette
        public static float Palette_NTSC_brightness;
        public static float Palette_NTSC_contrast;
        public static float Palette_NTSC_gamma;
        public static float Palette_NTSC_hue_tweak;
        public static float Palette_NTSC_saturation;
        public static float Palette_PALB_brightness;
        public static float Palette_PALB_contrast;
        public static float Palette_PALB_gamma;
        public static float Palette_PALB_hue_tweak;
        public static float Palette_PALB_saturation;
        public static bool Palette_AutoSelect;
        public static bool Palette_UseNTSCPalette;
        // Frame skip
        public static int FrameSkipCount;
        public static bool FrameSkipEnabled;
        // Keys
        public static bool Key_Connect4Players;
        public static bool Key_ConnectZapper;
        public static bool Key_Shortcuts_UseJoystick;
        public static int Key_Shortcuts_JoystickIndex;
        public static bool Key_P1_UseJoystick;
        public static int Key_P1_JoystickIndex;
        public static bool Key_P2_UseJoystick;
        public static int Key_P2_JoystickIndex;
        public static bool Key_P3_UseJoystick;
        public static int Key_P3_JoystickIndex;
        public static bool Key_P4_UseJoystick;
        public static int Key_P4_JoystickIndex;
        public static bool Key_VS_UseJoystick;
        public static int Key_VS_JoystickIndex;

        #region Keyboard

        public static string Key_HardReset;
        public static string Key_SoftReset;
        public static string Key_SwitchFullscreen;
        public static string Key_TakeSnap;
        public static string Key_SaveState;
        public static string Key_LoadState;
        public static string Key_StateSlot0;
        public static string Key_StateSlot1;
        public static string Key_StateSlot2;
        public static string Key_StateSlot3;
        public static string Key_StateSlot4;
        public static string Key_StateSlot5;
        public static string Key_StateSlot6;
        public static string Key_StateSlot7;
        public static string Key_StateSlot8;
        public static string Key_StateSlot9;
        public static string Key_ShutdownEmu;
        public static string Key_TogglePause;
        public static string Key_ToggleTurbo;
        public static string Key_RecordSound;
        public static string Key_ToggleFrameSkip;
        public static string Key_ShowGameStatus;
          
        public static string Key_P1_ButtonA;
        public static string Key_P1_ButtonB;
        public static string Key_P1_ButtonUp;
        public static string Key_P1_ButtonDown;
        public static string Key_P1_ButtonLeft;
        public static string Key_P1_ButtonRight;
        public static string Key_P1_ButtonStart;
        public static string Key_P1_ButtonSelect;
        public static string Key_P1_ButtonTurboA;
        public static string Key_P1_ButtonTurboB;

        public static string Key_P2_ButtonA;
        public static string Key_P2_ButtonB;
        public static string Key_P2_ButtonUp;
        public static string Key_P2_ButtonDown;
        public static string Key_P2_ButtonLeft;
        public static string Key_P2_ButtonRight;
        public static string Key_P2_ButtonStart;
        public static string Key_P2_ButtonSelect;
        public static string Key_P2_ButtonTurboA;
        public static string Key_P2_ButtonTurboB;
       
        public static string Key_P3_ButtonA;
        public static string Key_P3_ButtonB;
        public static string Key_P3_ButtonUp;
        public static string Key_P3_ButtonDown;
        public static string Key_P3_ButtonLeft;
        public static string Key_P3_ButtonRight;
        public static string Key_P3_ButtonStart;
        public static string Key_P3_ButtonSelect;
        public static string Key_P3_ButtonTurboA;
        public static string Key_P3_ButtonTurboB;

        public static string Key_P4_ButtonA;
        public static string Key_P4_ButtonB;
        public static string Key_P4_ButtonUp;
        public static string Key_P4_ButtonDown;
        public static string Key_P4_ButtonLeft;
        public static string Key_P4_ButtonRight;
        public static string Key_P4_ButtonStart;
        public static string Key_P4_ButtonSelect;
        public static string Key_P4_ButtonTurboA;
        public static string Key_P4_ButtonTurboB;

        public static string Key_VS_CreditServiceButton;
        public static string Key_VS_DIPSwitch1;
        public static string Key_VS_DIPSwitch2;
        public static string Key_VS_DIPSwitch3;
        public static string Key_VS_DIPSwitch4;
        public static string Key_VS_DIPSwitch5;
        public static string Key_VS_DIPSwitch6;
        public static string Key_VS_DIPSwitch7;
        public static string Key_VS_DIPSwitch8;
        public static string Key_VS_CreditLeftCoinSlot;
        public static string Key_VS_CreditRightCoinSlot;

        #endregion

        #region Joystick

        public static string JoyKey_HardReset;
        public static string JoyKey_SoftReset;
        public static string JoyKey_SwitchFullscreen;
        public static string JoyKey_TakeSnap;
        public static string JoyKey_SaveState;
        public static string JoyKey_LoadState;
        public static string JoyKey_StateSlot0;
        public static string JoyKey_StateSlot1;
        public static string JoyKey_StateSlot2;
        public static string JoyKey_StateSlot3;
        public static string JoyKey_StateSlot4;
        public static string JoyKey_StateSlot5;
        public static string JoyKey_StateSlot6;
        public static string JoyKey_StateSlot7;
        public static string JoyKey_StateSlot8;
        public static string JoyKey_StateSlot9;
        public static string JoyKey_ShutdownEmu;
        public static string JoyKey_TogglePause;
        public static string JoyKey_ToggleTurbo;
        public static string JoyKey_RecordSound;
        public static string JoyKey_ToggleFrameSkip;
        public static string JoyKey_ShowGameStatus;

        public static string JoyKey_P1_ButtonA;
        public static string JoyKey_P1_ButtonB;
        public static string JoyKey_P1_ButtonUp;
        public static string JoyKey_P1_ButtonDown;
        public static string JoyKey_P1_ButtonLeft;
        public static string JoyKey_P1_ButtonRight;
        public static string JoyKey_P1_ButtonStart;
        public static string JoyKey_P1_ButtonSelect;
        public static string JoyKey_P1_ButtonTurboA;
        public static string JoyKey_P1_ButtonTurboB;

        public static string JoyKey_P2_ButtonA;
        public static string JoyKey_P2_ButtonB;
        public static string JoyKey_P2_ButtonUp;
        public static string JoyKey_P2_ButtonDown;
        public static string JoyKey_P2_ButtonLeft;
        public static string JoyKey_P2_ButtonRight;
        public static string JoyKey_P2_ButtonStart;
        public static string JoyKey_P2_ButtonSelect;
        public static string JoyKey_P2_ButtonTurboA;
        public static string JoyKey_P2_ButtonTurboB;

        public static string JoyKey_P3_ButtonA;
        public static string JoyKey_P3_ButtonB;
        public static string JoyKey_P3_ButtonUp;
        public static string JoyKey_P3_ButtonDown;
        public static string JoyKey_P3_ButtonLeft;
        public static string JoyKey_P3_ButtonRight;
        public static string JoyKey_P3_ButtonStart;
        public static string JoyKey_P3_ButtonSelect;
        public static string JoyKey_P3_ButtonTurboA;
        public static string JoyKey_P3_ButtonTurboB;

        public static string JoyKey_P4_ButtonA;
        public static string JoyKey_P4_ButtonB;
        public static string JoyKey_P4_ButtonUp;
        public static string JoyKey_P4_ButtonDown;
        public static string JoyKey_P4_ButtonLeft;
        public static string JoyKey_P4_ButtonRight;
        public static string JoyKey_P4_ButtonStart;
        public static string JoyKey_P4_ButtonSelect;
        public static string JoyKey_P4_ButtonTurboA;
        public static string JoyKey_P4_ButtonTurboB;

        public static string JoyKey_VS_CreditServiceButton;
        public static string JoyKey_VS_DIPSwitch1;
        public static string JoyKey_VS_DIPSwitch2;
        public static string JoyKey_VS_DIPSwitch3;
        public static string JoyKey_VS_DIPSwitch4;
        public static string JoyKey_VS_DIPSwitch5;
        public static string JoyKey_VS_DIPSwitch6;
        public static string JoyKey_VS_DIPSwitch7;
        public static string JoyKey_VS_DIPSwitch8;
        public static string JoyKey_VS_CreditLeftCoinSlot;
        public static string JoyKey_VS_CreditRightCoinSlot;

        #endregion

        // Misc
        public static string SnapsFormat;
        public static bool SnapReplace;
        public static bool SaveSRAMOnShutdown;
        public static string TvSystemSetting;
        // Commands base !
        private static Dictionary<string, string> commands;
        private static FieldInfo[] Fields;

        /* !! IMPORTANT !!
		 * When you add new settings value, just register it
		 * here in this method.
		 * Only string, bool, float and int are supported.
		 * */
        public static void BuildCommands()
        {
            commands = new Dictionary<string, string>();
            commands.Add("state_folder", "Folder_STATE");
            commands.Add("sram_folder", "Folder_SRAM");
            commands.Add("snaps_folder", "Folder_SNAPS");
            commands.Add("gamegenie_folder", "Folder_GameGenieCodes");
            commands.Add("soundrecords_folder", "Folder_SoundRecords");
            commands.Add("auto_resize", "Video_AutoResizeToFitEmu");
            commands.Add("stretchx", "Video_StretchMulti");
            commands.Add("screen_w", "Video_ScreenWidth");
            commands.Add("screen_h", "Video_ScreenHeight");
            commands.Add("aspect_ratio", "Video_KeepAspectRatio");
            commands.Add("hide_lines", "Video_HideLinesForNTSCAndPAL");
            commands.Add("fullscreen_mode", "Video_FullScreenModeIndex");
            commands.Add("fullscreen", "Video_StartInFullscreen");
            commands.Add("show_fps", "Video_ShowFPS");
            commands.Add("show_not", "Video_ShowNotification");
            commands.Add("snap_format", "SnapsFormat");
            commands.Add("audio_volume", "Audio_PlaybackVolume");
            commands.Add("audio_freq", "Audio_PlaybackFrequency");
            commands.Add("audio_enabled", "Audio_PlaybackEnabled");
            commands.Add("audio_playback_dmc_enabled", "Audio_playback_dmc_enabled");
            commands.Add("audio_playback_noz_enabled", "Audio_playback_noz_enabled");
            commands.Add("audio_playback_sq1_enabled", "Audio_playback_sq1_enabled");
            commands.Add("audio_playback_sq2_enabled", "Audio_playback_sq2_enabled");
            commands.Add("audio_playback_trl_enabled", "Audio_playback_trl_enabled");
            commands.Add("connect_4players", "Key_Connect4Players");
            commands.Add("connect_zapper", "Key_ConnectZapper");
            commands.Add("p1_usejoystick", "Key_P1_UseJoystick");
            commands.Add("p1_joystick_index", "Key_P1_JoystickIndex");
            commands.Add("p2_joystick_index", "Key_P2_JoystickIndex");
            commands.Add("p3_joystick_index", "Key_P3_JoystickIndex");
            commands.Add("p4_joystick_index", "Key_P4_JoystickIndex");
            commands.Add("shortcuts_usejoystick", "Key_Shortcuts_UseJoystick");
            commands.Add("shortcuts_joystickindex", "Key_Shortcuts_JoystickIndex");
            // Keyboards
            commands.Add("key_p1_a", "Key_P1_ButtonA");
            commands.Add("key_p1_b", "Key_P1_ButtonB");
            commands.Add("key_p1_up", "Key_P1_ButtonUp");
            commands.Add("key_p1_down", "Key_P1_ButtonDown");
            commands.Add("key_p1_left", "Key_P1_ButtonLeft");
            commands.Add("key_p1_right", "Key_P1_ButtonRight");
            commands.Add("key_p1_start", "Key_P1_ButtonStart");
            commands.Add("key_p1_select", "Key_P1_ButtonSelect");
            commands.Add("key_p1_turboa", "Key_P1_ButtonTurboA");
            commands.Add("key_p1_turbob", "Key_P1_ButtonTurboB");
            commands.Add("key_p2_usejoystick", "Key_P2_UseJoystick");
            commands.Add("key_p2_a", "Key_P2_ButtonA");
            commands.Add("key_p2_b", "Key_P2_ButtonB");
            commands.Add("key_p2_up", "Key_P2_ButtonUp");
            commands.Add("key_p2_down", "Key_P2_ButtonDown");
            commands.Add("key_p2_left", "Key_P2_ButtonLeft");
            commands.Add("key_p2_right", "Key_P2_ButtonRight");
            commands.Add("key_p2_start", "Key_P2_ButtonStart");
            commands.Add("key_p2_select", "Key_P2_ButtonSelect");
            commands.Add("key_p2_turboa", "Key_P2_ButtonTurboA");
            commands.Add("key_p2_turbob", "Key_P2_ButtonTurboB");
            commands.Add("key_p3_usejoystick", "Key_P3_UseJoystick");
            commands.Add("key_p3_a", "Key_P3_ButtonA");
            commands.Add("key_p3_b", "Key_P3_ButtonB");
            commands.Add("key_p3_up", "Key_P3_ButtonUp");
            commands.Add("key_p3_down", "Key_P3_ButtonDown");
            commands.Add("key_p3_left", "Key_P3_ButtonLeft");
            commands.Add("key_p3_right", "Key_P3_ButtonRight");
            commands.Add("key_p3_start", "Key_P3_ButtonStart");
            commands.Add("key_p3_select", "Key_P3_ButtonSelect");
            commands.Add("key_p3_turboa", "Key_P3_ButtonTurboA");
            commands.Add("key_p3_turbob", "Key_P3_ButtonTurboB");
            commands.Add("key_p4_usejoystick", "Key_P4_UseJoystick");
            commands.Add("key_p4_a", "Key_P4_ButtonA");
            commands.Add("key_p4_b", "Key_P4_ButtonB");
            commands.Add("key_p4_up", "Key_P4_ButtonUp");
            commands.Add("key_p4_down", "Key_P4_ButtonDown");
            commands.Add("key_p4_left", "Key_P4_ButtonLeft");
            commands.Add("key_p4_right", "Key_P4_ButtonRight");
            commands.Add("key_p4_start", "Key_P4_ButtonStart");
            commands.Add("key_p4_select", "Key_P4_ButtonSelect");
            commands.Add("key_p4_turboa", "Key_P4_ButtonTurboA");
            commands.Add("key_p4_turbob", "Key_P4_ButtonTurboB");
            commands.Add("key_vs_usejoystick", "Key_VS_UseJoystick");
            commands.Add("key_vs_joystick_index", "Key_VS_JoystickIndex");
            commands.Add("key_vs_credit", "Key_VS_CreditServiceButton");
            commands.Add("key_vs_dip1", "Key_VS_DIPSwitch1");
            commands.Add("key_vs_dip2", "Key_VS_DIPSwitch2");
            commands.Add("key_vs_dip3", "Key_VS_DIPSwitch3");
            commands.Add("key_vs_dip4", "Key_VS_DIPSwitch4");
            commands.Add("key_vs_dip5", "Key_VS_DIPSwitch5");
            commands.Add("key_vs_dip6", "Key_VS_DIPSwitch6");
            commands.Add("key_vs_dip7", "Key_VS_DIPSwitch7");
            commands.Add("key_vs_dip8", "Key_VS_DIPSwitch8");
            commands.Add("key_vs_leftslot", "Key_VS_CreditLeftCoinSlot");
            commands.Add("key_vs_rightslot", "Key_VS_CreditRightCoinSlot");
            // Shortcuts
            commands.Add("key_shortcut_hardreset", "Key_HardReset");
            commands.Add("key_shortcut_softreset", "Key_SoftReset");
            commands.Add("key_shortcut_fullscreen", "Key_SwitchFullscreen");
            commands.Add("key_shortcut_takesnap", "Key_TakeSnap");
            commands.Add("key_shortcut_savestate", "Key_SaveState");
            commands.Add("key_shortcut_loadstate", "Key_LoadState");
            commands.Add("key_shortcut_stateslot0", "Key_StateSlot0");
            commands.Add("key_shortcut_stateslot1", "Key_StateSlot1");
            commands.Add("key_shortcut_stateslot2", "Key_StateSlot2");
            commands.Add("key_shortcut_stateslot3", "Key_StateSlot3");
            commands.Add("key_shortcut_stateslot4", "Key_StateSlot4");
            commands.Add("key_shortcut_stateslot5", "Key_StateSlot5");
            commands.Add("key_shortcut_stateslot6", "Key_StateSlot6");
            commands.Add("key_shortcut_stateslot7", "Key_StateSlot7");
            commands.Add("key_shortcut_stateslot8", "Key_StateSlot8");
            commands.Add("key_shortcut_stateslot9", "Key_StateSlot9");
            commands.Add("key_shortcut_shutdown", "Key_ShutdownEmu");
            commands.Add("key_shortcut_togglepause", "Key_TogglePause");
            commands.Add("key_shortcut_toggleturbo", "Key_ToggleTurbo");
            commands.Add("key_shortcut_recordsound", "Key_RecordSound");
            commands.Add("key_shortcut_frameskip", "Key_ToggleFrameSkip");
            commands.Add("key_shortcut_showstatus", "Key_ShowGameStatus");
            // Joysticks
            commands.Add("joy_p1_a", "JoyKey_P1_ButtonA");
            commands.Add("joy_p1_b", "JoyKey_P1_ButtonB");
            commands.Add("joy_p1_up", "JoyKey_P1_ButtonUp");
            commands.Add("joy_p1_down", "JoyKey_P1_ButtonDown");
            commands.Add("joy_p1_left", "JoyKey_P1_ButtonLeft");
            commands.Add("joy_p1_right", "JoyKey_P1_ButtonRight");
            commands.Add("joy_p1_start", "JoyKey_P1_ButtonStart");
            commands.Add("joy_p1_select", "JoyKey_P1_ButtonSelect");
            commands.Add("joy_p1_turboa", "JoyKey_P1_ButtonTurboA");
            commands.Add("joy_p1_turbob", "JoyKey_P1_ButtonTurboB");
            commands.Add("joy_p2_usejoystick", "JoyKey_P2_UseJoystick");
            commands.Add("joy_p2_a", "JoyKey_P2_ButtonA");
            commands.Add("joy_p2_b", "JoyKey_P2_ButtonB");
            commands.Add("joy_p2_up", "JoyKey_P2_ButtonUp");
            commands.Add("joy_p2_down", "JoyKey_P2_ButtonDown");
            commands.Add("joy_p2_left", "JoyKey_P2_ButtonLeft");
            commands.Add("joy_p2_right", "JoyKey_P2_ButtonRight");
            commands.Add("joy_p2_start", "JoyKey_P2_ButtonStart");
            commands.Add("joy_p2_select", "JoyKey_P2_ButtonSelect");
            commands.Add("joy_p2_turboa", "JoyKey_P2_ButtonTurboA");
            commands.Add("joy_p2_turbob", "JoyKey_P2_ButtonTurboB");
            commands.Add("joy_p3_usejoystick", "JoyKey_P3_UseJoystick");
            commands.Add("joy_p3_a", "JoyKey_P3_ButtonA");
            commands.Add("joy_p3_b", "JoyKey_P3_ButtonB");
            commands.Add("joy_p3_up", "JoyKey_P3_ButtonUp");
            commands.Add("joy_p3_down", "JoyKey_P3_ButtonDown");
            commands.Add("joy_p3_left", "JoyKey_P3_ButtonLeft");
            commands.Add("joy_p3_right", "JoyKey_P3_ButtonRight");
            commands.Add("joy_p3_start", "JoyKey_P3_ButtonStart");
            commands.Add("joy_p3_select", "JoyKey_P3_ButtonSelect");
            commands.Add("joy_p3_turboa", "JoyKey_P3_ButtonTurboA");
            commands.Add("joy_p3_turbob", "JoyKey_P3_ButtonTurboB");
            commands.Add("joy_p4_usejoystick", "JoyKey_P4_UseJoystick");
            commands.Add("joy_p4_a", "JoyKey_P4_ButtonA");
            commands.Add("joy_p4_b", "JoyKey_P4_ButtonB");
            commands.Add("joy_p4_up", "JoyKey_P4_ButtonUp");
            commands.Add("joy_p4_down", "JoyKey_P4_ButtonDown");
            commands.Add("joy_p4_left", "JoyKey_P4_ButtonLeft");
            commands.Add("joy_p4_right", "JoyKey_P4_ButtonRight");
            commands.Add("joy_p4_start", "JoyKey_P4_ButtonStart");
            commands.Add("joy_p4_select", "JoyKey_P4_ButtonSelect");
            commands.Add("joy_p4_turboa", "JoyKey_P4_ButtonTurboA");
            commands.Add("joy_p4_turbob", "JoyKey_P4_ButtonTurboB");
            commands.Add("joy_vs_usejoystick", "JoyKey_VS_UseJoystick");
            commands.Add("joy_vs_joystick_index", "JoyKey_VS_JoystickIndex");
            commands.Add("joy_vs_credit", "JoyKey_VS_CreditServiceButton");
            commands.Add("joy_vs_dip1", "JoyKey_VS_DIPSwitch1");
            commands.Add("joy_vs_dip2", "JoyKey_VS_DIPSwitch2");
            commands.Add("joy_vs_dip3", "JoyKey_VS_DIPSwitch3");
            commands.Add("joy_vs_dip4", "JoyKey_VS_DIPSwitch4");
            commands.Add("joy_vs_dip5", "JoyKey_VS_DIPSwitch5");
            commands.Add("joy_vs_dip6", "JoyKey_VS_DIPSwitch6");
            commands.Add("joy_vs_dip7", "JoyKey_VS_DIPSwitch7");
            commands.Add("joy_vs_dip8", "JoyKey_VS_DIPSwitch8");
            commands.Add("joy_vs_leftslot", "JoyKey_VS_CreditLeftCoinSlot");
            commands.Add("joy_vs_rightslot", "JoyKey_VS_CreditRightCoinSlot");
            // Shortcuts
            commands.Add("joy_shortcut_hardreset", "JoyKey_HardReset");
            commands.Add("joy_shortcut_softreset", "JoyKey_SoftReset");
            commands.Add("joy_shortcut_fullscreen", "JoyKey_SwitchFullscreen");
            commands.Add("joy_shortcut_takesnap", "JoyKey_TakeSnap");
            commands.Add("joy_shortcut_savestate", "JoyKey_SaveState");
            commands.Add("joy_shortcut_loadstate", "JoyKey_LoadState");
            commands.Add("joy_shortcut_stateslot0", "JoyKey_StateSlot0");
            commands.Add("joy_shortcut_stateslot1", "JoyKey_StateSlot1");
            commands.Add("joy_shortcut_stateslot2", "JoyKey_StateSlot2");
            commands.Add("joy_shortcut_stateslot3", "JoyKey_StateSlot3");
            commands.Add("joy_shortcut_stateslot4", "JoyKey_StateSlot4");
            commands.Add("joy_shortcut_stateslot5", "JoyKey_StateSlot5");
            commands.Add("joy_shortcut_stateslot6", "JoyKey_StateSlot6");
            commands.Add("joy_shortcut_stateslot7", "JoyKey_StateSlot7");
            commands.Add("joy_shortcut_stateslot8", "JoyKey_StateSlot8");
            commands.Add("joy_shortcut_stateslot9", "JoyKey_StateSlot9");
            commands.Add("joy_shortcut_shutdown", "JoyKey_ShutdownEmu");
            commands.Add("joy_shortcut_togglepause", "JoyKey_TogglePause");
            commands.Add("joy_shortcut_toggleturbo", "JoyKey_ToggleTurbo");
            commands.Add("joy_shortcut_recordsound", "JoyKey_RecordSound");
            commands.Add("joy_shortcut_frameskip", "JoyKey_ToggleFrameSkip");
            commands.Add("joy_shortcut_showstatus", "JoyKey_ShowGameStatus");
            // Misc
            commands.Add("snap_replace", "SnapReplace");
            commands.Add("onshutdown_save_sram", "SaveSRAMOnShutdown");
            commands.Add("region", "TvSystemSetting");
            // Palettes
            commands.Add("pal_ntsc_brightness", "Palette_NTSC_brightness");
            commands.Add("pal_ntsc_contrast", "Palette_NTSC_contrast");
            commands.Add("pal_ntsc_gamma", "Palette_NTSC_gamma");
            commands.Add("pal_ntsc_hue_tweak", "Palette_NTSC_hue_tweak");
            commands.Add("pal_ntsc_saturation", "Palette_NTSC_saturation");
            commands.Add("pal_pal_brightness", "Palette_PALB_brightness");
            commands.Add("pal_pal_contrast", "Palette_PALB_contrast");
            commands.Add("pal_pal_gamma", "Palette_PALB_gamma");
            commands.Add("pal_pal_hue_tweak", "Palette_PALB_hue_tweak");
            commands.Add("pal_pal_saturation", "Palette_PALB_saturation");
            commands.Add("pal_autoselect", "Palette_AutoSelect");
            commands.Add("pal_usentsc", "Palette_UseNTSCPalette");
            commands.Add("frameskip_enabled", "FrameSkipEnabled");
            commands.Add("frameskip_count", "FrameSkipCount");
        }

        public static void ExecuteCommands(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string command = args[i];
                if (commands.ContainsKey(command))
                {
                    string val = "";
                    i++;
                    if (i < args.Length)
                    {
                        val = args[i];
                        SetField(commands[command], val);
                    }
                }
            }
        }

        public static void ResetDefaults()
        {
            // Folders
            Folder_STATE = Path.Combine(Program.WorkingFolder, "STATE");
            Directory.CreateDirectory(Folder_STATE);
            Folder_SRAM = Path.Combine(Program.WorkingFolder, "SRAM");
            Directory.CreateDirectory(Folder_SRAM);
            Folder_SNAPS = Path.Combine(Program.WorkingFolder, "SNAPS");
            Directory.CreateDirectory(Folder_SNAPS);
            Folder_SoundRecords = Path.Combine(Program.WorkingFolder, "SoundRecords");
            Directory.CreateDirectory(Folder_SoundRecords);
            Folder_GameGenieCodes = Path.Combine(Program.WorkingFolder, "GameGenieCodes");
            Directory.CreateDirectory(Folder_GameGenieCodes);
            // Video
            Video_AutoResizeToFitEmu = true;
            Video_StretchMulti = 2;
            Video_ScreenWidth = 1024;
            Video_ScreenHeight = 600;
            Video_KeepAspectRatio = false;
            Video_HideLinesForNTSCAndPAL = true;
            Video_FullScreenModeIndex = 0;
            Video_StartInFullscreen = false;
            Video_ShowFPS = false;
            Video_ShowNotification = true;
			
            // Audio
            Audio_PlaybackVolume = 100;
            Audio_PlaybackFrequency = 44100;
            Audio_PlaybackEnabled = true;
            Audio_playback_dmc_enabled = true;
            Audio_playback_noz_enabled = true;
            Audio_playback_sq1_enabled = true;
            Audio_playback_sq2_enabled = true;
            Audio_playback_trl_enabled = true;

            // Palette
            Palette_NTSC_brightness = NTSCPaletteGenerator.default_brightness;
            Palette_NTSC_contrast = NTSCPaletteGenerator.default_contrast;
            Palette_NTSC_gamma = NTSCPaletteGenerator.default_gamma;
            Palette_NTSC_hue_tweak = NTSCPaletteGenerator.default_hue_tweak;
            Palette_NTSC_saturation = NTSCPaletteGenerator.default_saturation;
            Palette_PALB_brightness = PALBPaletteGenerator.default_brightness;
            Palette_PALB_contrast = PALBPaletteGenerator.default_contrast;
            Palette_PALB_gamma = PALBPaletteGenerator.default_gamma;
            Palette_PALB_hue_tweak = PALBPaletteGenerator.default_hue_tweak;
            Palette_PALB_saturation = PALBPaletteGenerator.default_saturation;
            Palette_AutoSelect = true;
            Palette_UseNTSCPalette = true;
            // Frame Skip
            FrameSkipCount = 1;
            FrameSkipEnabled = false;
            // Keys
            Key_Connect4Players = false;
            Key_ConnectZapper = false;
            Key_Shortcuts_UseJoystick = false;
            Key_Shortcuts_JoystickIndex = 0;
            Key_P1_UseJoystick = false;
            Key_P1_JoystickIndex = 0;
            Key_P2_UseJoystick = false;
            Key_P2_JoystickIndex = 0;
            Key_P3_UseJoystick = false;
            Key_P3_JoystickIndex = 0;
            Key_P4_UseJoystick = false;
            Key_P4_JoystickIndex = 0;
            Key_VS_UseJoystick = false;
            Key_VS_JoystickIndex = 0;

            #region Keyboard
            Key_TogglePause = "F1";
            Key_ShutdownEmu = "F2";
            Key_SoftReset = "F3";
            Key_HardReset = "F4";
            Key_TakeSnap = "F5";
            Key_SaveState = "F6";
            Key_RecordSound = "F7";
            Key_ToggleFrameSkip = "F8";
            Key_LoadState = "F9";
            Key_ShowGameStatus = "F10";
            Key_ToggleTurbo = "F11";
            Key_SwitchFullscreen = "F12";
            Key_StateSlot0 = "Zero";
            Key_StateSlot1 = "One";
            Key_StateSlot2 = "Two";
            Key_StateSlot3 = "Three";
            Key_StateSlot4 = "Four";
            Key_StateSlot5 = "Five";
            Key_StateSlot6 = "Six";
            Key_StateSlot7 = "Seven";
            Key_StateSlot8 = "Eight";
            Key_StateSlot9 = "Nine";
            Key_P1_UseJoystick = false;
            Key_P1_JoystickIndex = 0;
            Key_P1_ButtonA = "X";
            Key_P1_ButtonB = "Z";
            Key_P1_ButtonUp = "UpArrow";
            Key_P1_ButtonDown = "DownArrow";
            Key_P1_ButtonLeft = "LeftArrow";
            Key_P1_ButtonRight = "RightArrow";
            Key_P1_ButtonStart = "V";
            Key_P1_ButtonSelect = "C";
            Key_P1_ButtonTurboA = "A";
            Key_P1_ButtonTurboB = "S";
            Key_P2_UseJoystick = false;
            Key_P2_JoystickIndex = 0;
            Key_P2_ButtonA = "";
            Key_P2_ButtonB = "";
            Key_P2_ButtonUp = "";
            Key_P2_ButtonDown = "";
            Key_P2_ButtonLeft = "";
            Key_P2_ButtonRight = "";
            Key_P2_ButtonStart = "";
            Key_P2_ButtonSelect = "";
            Key_P2_ButtonTurboA = "";
            Key_P2_ButtonTurboB = "";
            Key_P3_UseJoystick = false;
            Key_P3_JoystickIndex = 0;
            Key_P3_ButtonA = "";
            Key_P3_ButtonB = "";
            Key_P3_ButtonUp = "";
            Key_P3_ButtonDown = "";
            Key_P3_ButtonLeft = "";
            Key_P3_ButtonRight = "";
            Key_P3_ButtonStart = "";
            Key_P3_ButtonSelect = "";
            Key_P3_ButtonTurboA = "";
            Key_P3_ButtonTurboB = "";
            Key_P4_UseJoystick = false;
            Key_P4_JoystickIndex = 0;
            Key_P4_ButtonA = "";
            Key_P4_ButtonB = "";
            Key_P4_ButtonUp = "";
            Key_P4_ButtonDown = "";
            Key_P4_ButtonLeft = "";
            Key_P4_ButtonRight = "";
            Key_P4_ButtonStart = "";
            Key_P4_ButtonSelect = "";
            Key_P4_ButtonTurboA = "";
            Key_P4_ButtonTurboB = "";
            Key_VS_UseJoystick = false;
            Key_VS_JoystickIndex = 0;
            Key_VS_CreditServiceButton = "End";
            Key_VS_DIPSwitch1 = "Keypad1";
            Key_VS_DIPSwitch2 = "Keypad2";
            Key_VS_DIPSwitch3 = "Keypad3";
            Key_VS_DIPSwitch4 = "Keypad4";
            Key_VS_DIPSwitch5 = "Keypad5";
            Key_VS_DIPSwitch6 = "Keypad6";
            Key_VS_DIPSwitch7 = "Keypad7";
            Key_VS_DIPSwitch8 = "Keypad8";
            Key_VS_CreditLeftCoinSlot = "Insert";
            Key_VS_CreditRightCoinSlot = "Home";
            #endregion
            #region Joystick

            JoyKey_TogglePause = "";
            JoyKey_ShutdownEmu = "";
            JoyKey_SoftReset = "";
            JoyKey_HardReset = "";
            JoyKey_TakeSnap = "";
            JoyKey_SaveState = "";
            JoyKey_RecordSound = "";
            JoyKey_ToggleFrameSkip = "";
            JoyKey_LoadState = "";
            JoyKey_ToggleTurbo = "";
            JoyKey_SwitchFullscreen = "";
            JoyKey_StateSlot0 = "";
            JoyKey_StateSlot1 = "";
            JoyKey_StateSlot2 = "";
            JoyKey_StateSlot3 = "";
            JoyKey_StateSlot4 = "";
            JoyKey_StateSlot5 = "";
            JoyKey_StateSlot6 = "";
            JoyKey_StateSlot7 = "";
            JoyKey_StateSlot8 = "";
            JoyKey_StateSlot9 = "";
            JoyKey_ShowGameStatus = "";

            JoyKey_P1_ButtonA = "3";
            JoyKey_P1_ButtonB = "2";
            JoyKey_P1_ButtonUp = "-Y";
            JoyKey_P1_ButtonDown = "+Y";
            JoyKey_P1_ButtonLeft = "-X";
            JoyKey_P1_ButtonRight = "+X";
            JoyKey_P1_ButtonStart = "9";
            JoyKey_P1_ButtonSelect = "8";
            JoyKey_P1_ButtonTurboA = "0";
            JoyKey_P1_ButtonTurboB = "1";

            JoyKey_P2_ButtonA = "3";
            JoyKey_P2_ButtonB = "2";
            JoyKey_P2_ButtonUp = "-Y";
            JoyKey_P2_ButtonDown = "+Y";
            JoyKey_P2_ButtonLeft = "-X";
            JoyKey_P2_ButtonRight = "+X";
            JoyKey_P2_ButtonStart = "9";
            JoyKey_P2_ButtonSelect = "8";
            JoyKey_P2_ButtonTurboA = "0";
            JoyKey_P2_ButtonTurboB = "1";

            JoyKey_P3_ButtonA = "3";
            JoyKey_P3_ButtonB = "2";
            JoyKey_P3_ButtonUp = "-Y";
            JoyKey_P3_ButtonDown = "+Y";
            JoyKey_P3_ButtonLeft = "-X";
            JoyKey_P3_ButtonRight = "+X";
            JoyKey_P3_ButtonStart = "9";
            JoyKey_P3_ButtonSelect = "8";
            JoyKey_P3_ButtonTurboA = "0";
            JoyKey_P3_ButtonTurboB = "1";

            JoyKey_P4_ButtonA = "3";
            JoyKey_P4_ButtonB = "2";
            JoyKey_P4_ButtonUp = "-Y";
            JoyKey_P4_ButtonDown = "+Y";
            JoyKey_P4_ButtonLeft = "-X";
            JoyKey_P4_ButtonRight = "+X";
            JoyKey_P4_ButtonStart = "9";
            JoyKey_P4_ButtonSelect = "8";
            JoyKey_P4_ButtonTurboA = "0";
            JoyKey_P4_ButtonTurboB = "1";

            JoyKey_VS_CreditServiceButton = "";
            JoyKey_VS_DIPSwitch1 = "";
            JoyKey_VS_DIPSwitch2 = "";
            JoyKey_VS_DIPSwitch3 = "";
            JoyKey_VS_DIPSwitch4 = "";
            JoyKey_VS_DIPSwitch5 = "";
            JoyKey_VS_DIPSwitch6 = "";
            JoyKey_VS_DIPSwitch7 = "";
            JoyKey_VS_DIPSwitch8 = "";
            JoyKey_VS_CreditLeftCoinSlot = "";
            JoyKey_VS_CreditRightCoinSlot = "";
            #endregion
            // Misc
            SnapsFormat = ".png";
            SnapReplace = false;
            SaveSRAMOnShutdown = true;
            TvSystemSetting = "AUTO";
        }

        public static void LoadSettings(string filePath)
        {
            SettingsFilePath = filePath;
            LoadSettings();
        }

        public static void LoadSettings()
        {
            Fields = typeof(Settings).GetFields();
            string[] readLines;
            List<string> lines = new List<string>();
            if (File.Exists(SettingsFilePath))
            {
                readLines = File.ReadAllLines(SettingsFilePath);

                for (int i = 0; i < readLines.Length; i++)
                {
                    string[] codes = readLines[i].Split('=');
                    if (codes != null)
                    {
                        if (codes.Length == 2)
                        {
                            lines.Add(codes[0]);
                            lines.Add(codes[1]);
                        }
                    }
                }
            }
            else
            {
                ResetDefaults();
                return;
            }

            ExecuteCommands(lines.ToArray());
        }

        public static void SaveSettings()
        {
            Fields = typeof(Settings).GetFields();
            List<string> lines = new List<string>();
            foreach (string key in commands.Keys)
            {
                lines.Add(key + "=" + GetFieldValue(commands[key]));
            }
            File.WriteAllLines(SettingsFilePath, lines.ToArray());
        }

        private static void SetField(string fieldName, string val)
        {
            for (int i = 0; i < Fields.Length; i++)
            {
                if (Fields[i].Name == fieldName)
                {
                    if (Fields[i].FieldType == typeof(String))
                    {
                        Fields[i].SetValue(null, val);
                    }
                    else if (Fields[i].FieldType == typeof(Boolean))
                    {
                        Fields[i].SetValue(null, val == "1");
                    }
                    else if (Fields[i].FieldType == typeof(Int32))
                    {
                        int num = 0;
                        if (int.TryParse(val, out num))
                            Fields[i].SetValue(null, num);
                    }
                    else if (Fields[i].FieldType == typeof(Single))
                    {
                        float num = 0;
                        if (float.TryParse(val, out num))
                            Fields[i].SetValue(null, num);
                    }
                    break;
                }
            }
        }

        private static string GetFieldValue(string fieldName)
        {
            for (int i = 0; i < Fields.Length; i++)
            {
                if (Fields[i].Name == fieldName)
                {
                    object val = Fields[i].GetValue(null);
                    if (Fields[i].FieldType == typeof(String))
                    {
                        return val.ToString();
                    }
                    else if (Fields[i].FieldType == typeof(Boolean))
                    {
                        return (bool)val ? "1" : "0";
                    }
                    else if (Fields[i].FieldType == typeof(Int32))
                    {
                        return val.ToString();
                    }
                    else if (Fields[i].FieldType == typeof(Single))
                    {
                        return val.ToString();
                    }
                    break;
                }
            }
            return "";
        }
    }
}

