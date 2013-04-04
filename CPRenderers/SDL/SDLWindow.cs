using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;

using SdlDotNet;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Core;
using SdlDotNet.Input;
using SdlDotNet.Graphics.Primitives;

using MyNes.Core;
using MyNes.Core.APU;
using MyNes.Core.PPU;
using MyNes.Core.IO.Output;
using MyNes.Renderers;
using Console = MyNes.Core.Console;

namespace CPRenderers
{
    class SDLWindow
    {
        public SDLWindow()
        {
            Console.WriteLine("SDL .NET: setup keys for settings");
            SetupKeys();
            Console.WriteLine("SDL .NET: getting rom name and info");
            if (Nes.RomInfo.DatabaseGameInfo.Game_Name != null)
            {
                romName = Nes.RomInfo.DatabaseGameInfo.Game_Name +
                    " (" + Nes.RomInfo.DatabaseGameInfo.Game_AltName + ")";
            }
            else
            {
                romName = Path.GetFileNameWithoutExtension(Nes.RomInfo.Path);
            }
        }

        private SDLvideo video;
        private SDLsound sound;
        private CPZapper zapper;
        private string romName = "";
        private Dictionary<RenderersKeys, Key> keys = new Dictionary<RenderersKeys, Key>();//to convert given key to sdl key
        private Point mouseUpPoint;
        private bool shutdownRequest = false;

        public void Run()
        {
            InitializeRendrers();
            Nes.EmuShutdown += new EventHandler(Nes_EmuShutdown);
            Nes.FullscreenSwitch += new EventHandler(Nes_FullscreenSwitch);

            if (Nes.emuSystem.Master == TimingInfo.NTSC.Master)
            {
                Events.TargetFps = 60;
            }
            else if (Nes.emuSystem.Master == TimingInfo.PALB.Master)
            {
                Events.TargetFps = 50;
            }
            else if (Nes.emuSystem.Master == TimingInfo.Dendy.Master)
            {
                Events.TargetFps = 50;
            }
            Events.Quit += new EventHandler<QuitEventArgs>(Quit);
            Events.VideoResize += new EventHandler<VideoResizeEventArgs>(VideoResize);
            Events.MouseButtonDown += Events_MouseButtonDown;
            Events.MouseButtonUp += Events_MouseButtonUp;
            Events.Tick += Events_Tick;
            Events.Run();
        }
        public void KillWindow()
        {
            shutdownRequest = true;
        }
        void InitializeRendrers()
        {
            Console.WriteLine("SDL .NET: initializing renderers..");
            // input
            Console.WriteLine("SDL .NET: setup input...");
            Nes.SetupLimiter(new Timer());
            SetupInput();
            Console.WriteLine("SDL .NET: setup input... OK");
            Console.WriteLine("SDL .NET: initializing video device...");
            // video and sound
            video = new SDLvideo(Nes.emuSystem, RenderersCore.SettingsManager.Settings.Video_StretchMultiply, romName,
                 RenderersCore.SettingsManager.Settings.Video_ImmediateMode, RenderersCore.SettingsManager.Settings.Video_HideLines,
                 0, RenderersCore.SettingsManager.Settings.Video_ResIndex,
                 RenderersCore.SettingsManager.Settings.Video_OpenGL,
                 RenderersCore.SettingsManager.Settings.Video_Fullscreen,
                 RenderersCore.SettingsManager.Settings.Video_ShowFPS,
                 RenderersCore.SettingsManager.Settings.Video_ShowNotifications,
                 RenderersCore.SettingsManager.Settings.Video_KeepAspectRationOnStretch);
            Console.WriteLine("SDL .NET: initializing video device...  OK");
            Console.WriteLine("SDL .NET: initializing sound device ...");
            sound = new SDLsound(true, RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq);
            Console.WriteLine("SDL .NET: initializing sound device...  OK");
            Console.WriteLine("SDL .NET: apply devices to emulation core");
            Nes.SetupOutput(video, sound, new ApuPlaybackDescription(RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq));

            Console.WriteLine("SDL .NET: setup palette ..");
            // palette
            NTSCPaletteGenerator.brightness = RenderersCore.SettingsManager.Settings.Video_Palette.NTSC_brightness;
            NTSCPaletteGenerator.contrast = RenderersCore.SettingsManager.Settings.Video_Palette.NTSC_contrast;
            NTSCPaletteGenerator.gamma = RenderersCore.SettingsManager.Settings.Video_Palette.NTSC_gamma;
            NTSCPaletteGenerator.hue_tweak = RenderersCore.SettingsManager.Settings.Video_Palette.NTSC_hue_tweak;
            NTSCPaletteGenerator.saturation = RenderersCore.SettingsManager.Settings.Video_Palette.NTSC_saturation;

            PALBPaletteGenerator.brightness = RenderersCore.SettingsManager.Settings.Video_Palette.PALB_brightness;
            PALBPaletteGenerator.contrast = RenderersCore.SettingsManager.Settings.Video_Palette.PALB_contrast;
            PALBPaletteGenerator.gamma = RenderersCore.SettingsManager.Settings.Video_Palette.PALB_gamma;
            PALBPaletteGenerator.hue_tweak = RenderersCore.SettingsManager.Settings.Video_Palette.PALB_hue_tweak;
            PALBPaletteGenerator.saturation = RenderersCore.SettingsManager.Settings.Video_Palette.PALB_saturation;

            Nes.SetupPalette();
            Console.WriteLine("SDL .NET: Run !");

            video.Launch();
        }
        void SetupInput()
        {
            SDLInputManager inputManager = new SDLInputManager(new CPJoypad(), new CPJoypad(), new CPJoypad(), new CPJoypad());
            ControlProfile profile =
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex];
            // shortcuts
            inputManager.sct_Fullscreen = GetKey(profile.Shortcuts.Fullscreen);
            inputManager.sct_HardReset = GetKey(profile.Shortcuts.HardReset);
            inputManager.sct_LoadState = GetKey(profile.Shortcuts.LoadState);
            inputManager.sct_PauseEmulation = GetKey(profile.Shortcuts.PauseEmulation);
            inputManager.sct_ResumeEmulation = GetKey(profile.Shortcuts.ResumeEmulation);
            inputManager.sct_SaveState = GetKey(profile.Shortcuts.SaveState);
            inputManager.sct_SelectedSlot0 = GetKey(profile.Shortcuts.SelecteSlot0);
            inputManager.sct_SelectedSlot1 = GetKey(profile.Shortcuts.SelecteSlot1);
            inputManager.sct_SelectedSlot2 = GetKey(profile.Shortcuts.SelecteSlot2);
            inputManager.sct_SelectedSlot3 = GetKey(profile.Shortcuts.SelecteSlot3);
            inputManager.sct_SelectedSlot4 = GetKey(profile.Shortcuts.SelecteSlot4);
            inputManager.sct_SelectedSlot5 = GetKey(profile.Shortcuts.SelecteSlot5);
            inputManager.sct_SelectedSlot6 = GetKey(profile.Shortcuts.SelecteSlot6);
            inputManager.sct_SelectedSlot7 = GetKey(profile.Shortcuts.SelecteSlot7);
            inputManager.sct_SelectedSlot8 = GetKey(profile.Shortcuts.SelecteSlot8);
            inputManager.sct_SelectedSlot9 = GetKey(profile.Shortcuts.SelecteSlot9);
            inputManager.sct_ShutdownEmulation = GetKey(profile.Shortcuts.ShutdownEmulation);
            inputManager.sct_SoftReset = GetKey(profile.Shortcuts.SoftReset);
            inputManager.sct_TakeSnapshot = GetKey(profile.Shortcuts.TakeSnapshot);
            inputManager.sct_ToggleLimiter = GetKey(profile.Shortcuts.ToggleLimiter);
            // vsunisystem
            inputManager.vsu_CreditLeftCoinSlot = GetKey(profile.VSunisystemDIP.CreditLeftCoinSlot);
            inputManager.vsu_CreditRightCoinSlot = GetKey(profile.VSunisystemDIP.CreditRightCoinSlot);
            inputManager.vsu_CreditServiceButton = GetKey(profile.VSunisystemDIP.CreditServiceButton);
            inputManager.vsu_DIPSwitch1 = GetKey(profile.VSunisystemDIP.DIPSwitch1);
            inputManager.vsu_DIPSwitch2 = GetKey(profile.VSunisystemDIP.DIPSwitch2);
            inputManager.vsu_DIPSwitch3 = GetKey(profile.VSunisystemDIP.DIPSwitch3);
            inputManager.vsu_DIPSwitch4 = GetKey(profile.VSunisystemDIP.DIPSwitch4);
            inputManager.vsu_DIPSwitch5 = GetKey(profile.VSunisystemDIP.DIPSwitch5);
            inputManager.vsu_DIPSwitch6 = GetKey(profile.VSunisystemDIP.DIPSwitch6);
            inputManager.vsu_DIPSwitch7 = GetKey(profile.VSunisystemDIP.DIPSwitch7);
            inputManager.vsu_DIPSwitch8 = GetKey(profile.VSunisystemDIP.DIPSwitch8);
            inputManager.IsVSUnisystem = Nes.RomInfo.VSUnisystem;
            // joypads
            inputManager.IsFourPlayers = profile.Connect4Players;
            inputManager.p1_A = GetKey(profile.Player1.A);
            inputManager.p1_B = GetKey(profile.Player1.B);
            inputManager.p1_TurboA = GetKey(profile.Player1.TurboA);
            inputManager.p1_TurboB = GetKey(profile.Player1.TurboB);
            inputManager.p1_DO = GetKey(profile.Player1.Down);
            inputManager.p1_LF = GetKey(profile.Player1.Left);
            inputManager.p1_RT = GetKey(profile.Player1.Right);
            inputManager.p1_SE = GetKey(profile.Player1.Select);
            inputManager.p1_ST = GetKey(profile.Player1.Start);
            inputManager.p1_UP = GetKey(profile.Player1.Up);

            inputManager.p2_A = GetKey(profile.Player2.A);
            inputManager.p2_B = GetKey(profile.Player2.B);
            inputManager.p2_TurboA = GetKey(profile.Player2.TurboA);
            inputManager.p2_TurboB = GetKey(profile.Player2.TurboB);
            inputManager.p2_DO = GetKey(profile.Player2.Down);
            inputManager.p2_LF = GetKey(profile.Player2.Left);
            inputManager.p2_RT = GetKey(profile.Player2.Right);
            inputManager.p2_SE = GetKey(profile.Player2.Select);
            inputManager.p2_ST = GetKey(profile.Player2.Start);
            inputManager.p2_UP = GetKey(profile.Player2.Up);

            inputManager.p3_A = GetKey(profile.Player3.A);
            inputManager.p3_B = GetKey(profile.Player3.B);
            inputManager.p3_TurboA = GetKey(profile.Player3.TurboA);
            inputManager.p3_TurboB = GetKey(profile.Player3.TurboB);
            inputManager.p3_DO = GetKey(profile.Player3.Down);
            inputManager.p3_LF = GetKey(profile.Player3.Left);
            inputManager.p3_RT = GetKey(profile.Player3.Right);
            inputManager.p3_SE = GetKey(profile.Player3.Select);
            inputManager.p3_ST = GetKey(profile.Player3.Start);
            inputManager.p3_UP = GetKey(profile.Player3.Up);

            inputManager.p4_A = GetKey(profile.Player4.A);
            inputManager.p4_B = GetKey(profile.Player4.B);
            inputManager.p4_TurboA = GetKey(profile.Player4.TurboA);
            inputManager.p4_TurboB = GetKey(profile.Player4.TurboB);
            inputManager.p4_DO = GetKey(profile.Player4.Down);
            inputManager.p4_LF = GetKey(profile.Player4.Left);
            inputManager.p4_RT = GetKey(profile.Player4.Right);
            inputManager.p4_SE = GetKey(profile.Player4.Select);
            inputManager.p4_ST = GetKey(profile.Player4.Start);
            inputManager.p4_UP = GetKey(profile.Player4.Up);

            Nes.SetupInput(inputManager, inputManager.joypad1, inputManager.joypad2,
                inputManager.joypad3, inputManager.joypad4, profile.Connect4Players);

            if (Nes.RomInfo.VSUnisystem)
            {
                Nes.ControlsUnit.VSunisystemDIP = inputManager.vsunisystem;
            }
            if (profile.ConnectZapper)
            {
                Nes.ControlsUnit.IsZapperConnected = true;
                Nes.ControlsUnit.Zapper = zapper = new CPZapper(new CPZapper.DetectZapperLight(DetectZapperLight));
            }
        }
        Key GetKey(string value)
        {
            if (value != null)
            {
                if (value.StartsWith("Keyboard"))
                {
                    string keyName = value.Substring(9, value.Length - 9);
                    //get key
                    RenderersKeys k = (RenderersKeys)Enum.Parse(typeof(RenderersKeys), keyName);
                    return keys[k];
                }
            }
            return Key.Unknown;
        }
        bool DetectZapperLight()
        {
            int x = (255 * mouseUpPoint.X) / Video.Screen.Width;
            int y = (239 * mouseUpPoint.Y) / Video.Screen.Height;

            int c = Nes.Ppu.GetPixel(x, y);
            byte r = (byte)(c >> 0x10); // R
            byte g = (byte)(c >> 0x08); // G
            byte b = (byte)(c >> 0x00);  // B

            return (r > 128 && g > 128 && b > 128);//bright color ?
        }

        void FullScreenSwitch()
        {
            Nes.TogglePause(true);
            RenderersCore.SettingsManager.Settings.Video_Fullscreen = !RenderersCore.SettingsManager.Settings.Video_Fullscreen;
            //shutdown renderers
            
            //resize
            video.Resize( RenderersCore.SettingsManager.Settings.Video_Fullscreen);
            //video.Launch();

            Nes.TogglePause(false);
        }
        void Nes_FullscreenSwitch(object sender, EventArgs e)
        {
            FullScreenSwitch();
        }
        void Nes_EmuShutdown(object sender, EventArgs e)
        {
            if (shutdownRequest)
            {
                shutdownRequest = false;
                Events.Close();
            }
            else
                shutdownRequest = true;
        }
        public void ApplySettings(SettingType stype)
        {
            switch (stype)
            { 
                case SettingType.All:
                case SettingType.Input: SetupInput(); break;
            }
        }
        void SetupKeys()
        {
            keys = new Dictionary<RenderersKeys, Key>();
            keys.Add(RenderersKeys.A, Key.A);
            keys.Add(RenderersKeys.B, Key.B);
            keys.Add(RenderersKeys.Backslash, Key.Backslash);
            keys.Add(RenderersKeys.Backspace, Key.Backspace);
            keys.Add(RenderersKeys.C, Key.C);
            keys.Add(RenderersKeys.CapsLock, Key.CapsLock);
            keys.Add(RenderersKeys.Colon, Key.Colon);
            keys.Add(RenderersKeys.Comma, Key.Comma);
            keys.Add(RenderersKeys.Convert, Key.Compose);
            keys.Add(RenderersKeys.D, Key.D);
            keys.Add(RenderersKeys.D0, Key.Zero);
            keys.Add(RenderersKeys.D1, Key.One);
            keys.Add(RenderersKeys.D2, Key.Two);
            keys.Add(RenderersKeys.D3, Key.Three);
            keys.Add(RenderersKeys.D4, Key.Four);
            keys.Add(RenderersKeys.D5, Key.Five);
            keys.Add(RenderersKeys.D6, Key.Six);
            keys.Add(RenderersKeys.D7, Key.Seven);
            keys.Add(RenderersKeys.D8, Key.Eight);
            keys.Add(RenderersKeys.D9, Key.Nine);
            keys.Add(RenderersKeys.Delete, Key.Delete);
            keys.Add(RenderersKeys.DownArrow, Key.DownArrow);
            keys.Add(RenderersKeys.E, Key.E);
            keys.Add(RenderersKeys.End, Key.End);
            keys.Add(RenderersKeys.Equals, Key.Equals);
            keys.Add(RenderersKeys.Escape, Key.Escape);
            keys.Add(RenderersKeys.F, Key.F);
            keys.Add(RenderersKeys.F1, Key.F1);
            keys.Add(RenderersKeys.F2, Key.F2);
            keys.Add(RenderersKeys.F3, Key.F3);
            keys.Add(RenderersKeys.F4, Key.F4);
            keys.Add(RenderersKeys.F5, Key.F5);
            keys.Add(RenderersKeys.F6, Key.F6);
            keys.Add(RenderersKeys.F7, Key.F7);
            keys.Add(RenderersKeys.F8, Key.F8);
            keys.Add(RenderersKeys.F9, Key.F9);
            keys.Add(RenderersKeys.F10, Key.F10);
            keys.Add(RenderersKeys.F11, Key.F11);
            keys.Add(RenderersKeys.F12, Key.F12);
            keys.Add(RenderersKeys.F13, Key.F13);
            keys.Add(RenderersKeys.F14, Key.F14);
            keys.Add(RenderersKeys.F15, Key.F15);
            keys.Add(RenderersKeys.G, Key.G);
            keys.Add(RenderersKeys.H, Key.H);
            keys.Add(RenderersKeys.Home, Key.Home);
            keys.Add(RenderersKeys.I, Key.I);
            keys.Add(RenderersKeys.Insert, Key.Insert);
            keys.Add(RenderersKeys.J, Key.J);
            keys.Add(RenderersKeys.K, Key.K);
            keys.Add(RenderersKeys.NumberPad0, Key.Keypad0);
            keys.Add(RenderersKeys.NumberPad1, Key.Keypad1);
            keys.Add(RenderersKeys.NumberPad2, Key.Keypad2);
            keys.Add(RenderersKeys.NumberPad3, Key.Keypad3);
            keys.Add(RenderersKeys.NumberPad4, Key.Keypad4);
            keys.Add(RenderersKeys.NumberPad5, Key.Keypad5);
            keys.Add(RenderersKeys.NumberPad6, Key.Keypad6);
            keys.Add(RenderersKeys.NumberPad7, Key.Keypad7);
            keys.Add(RenderersKeys.NumberPad8, Key.Keypad8);
            keys.Add(RenderersKeys.NumberPad9, Key.Keypad9);
            keys.Add(RenderersKeys.L, Key.L);
            keys.Add(RenderersKeys.LeftAlt, Key.LeftAlt);
            keys.Add(RenderersKeys.LeftArrow, Key.LeftArrow);
            keys.Add(RenderersKeys.LeftBracket, Key.LeftBracket);
            keys.Add(RenderersKeys.LeftControl, Key.LeftControl);
            keys.Add(RenderersKeys.LeftShift, Key.LeftShift);
            keys.Add(RenderersKeys.M, Key.M);
            keys.Add(RenderersKeys.Minus, Key.Minus);
            keys.Add(RenderersKeys.N, Key.N);
            keys.Add(RenderersKeys.NumberLock, Key.NumLock);
            keys.Add(RenderersKeys.NumberPadEnter, Key.KeypadEnter);
            keys.Add(RenderersKeys.NumberPadEquals, Key.KeypadEquals);
            keys.Add(RenderersKeys.NumberPadMinus, Key.KeypadMinus);
            keys.Add(RenderersKeys.NumberPadPeriod, Key.KeypadPeriod);
            keys.Add(RenderersKeys.NumberPadPlus, Key.KeypadPlus);
            keys.Add(RenderersKeys.NumberPadSlash, Key.KeypadDivide);
            keys.Add(RenderersKeys.NumberPadStar, Key.KeypadMultiply);
            keys.Add(RenderersKeys.O, Key.O);
            keys.Add(RenderersKeys.P, Key.P);
            keys.Add(RenderersKeys.PageDown, Key.PageDown);
            keys.Add(RenderersKeys.PageUp, Key.PageUp);
            keys.Add(RenderersKeys.Pause, Key.Pause);
            keys.Add(RenderersKeys.Period, Key.Period);
            keys.Add(RenderersKeys.Power, Key.Power);
            keys.Add(RenderersKeys.Q, Key.Q);
            keys.Add(RenderersKeys.R, Key.R);
            keys.Add(RenderersKeys.Return, Key.Return);
            keys.Add(RenderersKeys.RightAlt, Key.RightAlt);
            keys.Add(RenderersKeys.RightArrow, Key.RightArrow);
            keys.Add(RenderersKeys.RightBracket, Key.RightBracket);
            keys.Add(RenderersKeys.RightControl, Key.RightControl);
            keys.Add(RenderersKeys.RightShift, Key.RightShift);
            keys.Add(RenderersKeys.S, Key.S);
            keys.Add(RenderersKeys.ScrollLock, Key.ScrollLock);
            keys.Add(RenderersKeys.Semicolon, Key.Semicolon);
            keys.Add(RenderersKeys.Slash, Key.Slash);
            keys.Add(RenderersKeys.Space, Key.Space);
            keys.Add(RenderersKeys.T, Key.T);
            keys.Add(RenderersKeys.Tab, Key.Tab);
            keys.Add(RenderersKeys.U, Key.U);
            keys.Add(RenderersKeys.Unknown, Key.Unknown);
            keys.Add(RenderersKeys.UpArrow, Key.UpArrow);
            keys.Add(RenderersKeys.V, Key.V);
            keys.Add(RenderersKeys.W, Key.W);
            keys.Add(RenderersKeys.X, Key.X);
            keys.Add(RenderersKeys.Y, Key.Y);
            keys.Add(RenderersKeys.Z, Key.Z);
        }
        #region EventHandler Methods
        void VideoResize(object sender, VideoResizeEventArgs e)
        {
            video.Resize(video.FullScreen, true, e.Width, e.Height);
        }
        void Events_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Nes.ON)
            {
                if (Nes.ControlsUnit.IsZapperConnected)
                    zapper.trigger = e.Button != MouseButton.PrimaryButton;
            }
        }
        void Events_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Nes.ON)
            {
                if (Nes.ControlsUnit.IsZapperConnected)
                {
                    zapper.trigger = (e.Button == MouseButton.PrimaryButton);
                    mouseUpPoint = e.Position;
                }
            }
        }
        void Events_Tick(object sender, TickEventArgs e)
        {
            if (shutdownRequest)
            {
                Nes.Shutdown();
            }
        }
        void Quit(object sender, QuitEventArgs e)
        {
            shutdownRequest = true;
        }
        #endregion EventHandler Methods
    }
}
