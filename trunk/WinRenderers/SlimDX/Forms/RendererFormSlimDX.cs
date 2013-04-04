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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MyNes;
using MyNes.Core;
using MyNes.Core.APU;
using MyNes.Core.PPU;
using MyNes.Core.IO.Output;
using Console = MyNes.Core.Console;
using MyNes.Renderers;
namespace MyNes.WinRenderers
{
    public partial class RendererFormSlimDX : Form
    {
        public RendererFormSlimDX()
        {
            InitializeComponent();
            // load settings
            InitializeRendrers();

            Nes.EmuShutdown += new EventHandler(Nes_EmuShutdown);
            Nes.FullscreenSwitch += new EventHandler(Nes_FullscreenSwitch);
            if (Nes.RomInfo.DatabaseGameInfo.Game_Name != null)
            {
                this.Text = Nes.RomInfo.DatabaseGameInfo.Game_Name +
                    " (" + Nes.RomInfo.DatabaseGameInfo.Game_AltName + ") - My Nes [SlimDX Direct3D9]";
            }
            else
            {
                this.Text = Path.GetFileNameWithoutExtension(Nes.RomInfo.Path) + " - My Nes [SlimDX Direct3D9]";
            }
            Nes.TogglePause(false);
        }
        public VideoD3D videoDevice;
        private IAudioDevice audioDevice;
        private Zapper zapper;
        private Point mouseUpPoint;

        public bool DetectZapperLight()
        {
            int x = (255 * mouseUpPoint.X) / this.Width;
            int y = (239 * mouseUpPoint.Y) / this.Height;

            int c = Nes.Ppu.GetPixel(x, y);
            byte r = (byte)(c >> 0x10); // R
            byte g = (byte)(c >> 0x08); // G
            byte b = (byte)(c >> 0x00);  // B

            return (r > 128 && g > 128 && b > 128);//bright color ?
        }
        private void InitializeVideo()
        {
            base.ClientSize = new Size(256 * RenderersCore.SettingsManager.Settings.Video_StretchMultiply,
                ((Nes.emuSystem.Master == MyNes.Core.TimingInfo.NTSC.Master) ? 224 : 240) * RenderersCore.SettingsManager.Settings.Video_StretchMultiply);
            videoDevice = new VideoD3D(Nes.emuSystem, this);
            videoDevice.ImmediateMode = RenderersCore.SettingsManager.Settings.Video_ImmediateMode;
            videoDevice.cutLines = RenderersCore.SettingsManager.Settings.Video_HideLines;
            videoDevice.FullScreenModeIndex = RenderersCore.SettingsManager.Settings.Video_ResIndex;
            videoDevice.FullScreen = RenderersCore.SettingsManager.Settings.Video_Fullscreen;
            videoDevice.ShowFPS = RenderersCore.SettingsManager.Settings.Video_ShowFPS;
            videoDevice.ShowNotifications = RenderersCore.SettingsManager.Settings.Video_ShowNotifications;
            videoDevice.KeepAspectRatio = RenderersCore.SettingsManager.Settings.Video_KeepAspectRationOnStretch;
            videoDevice.Initialize();
        }
        private void InitializeAudio()
        {
            audioDevice = new AudioDSD(this.Handle, RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq,
              RenderersCore.SettingsManager.Settings.Sound_Latency);
            ((AudioDSD)audioDevice).SetVolume(RenderersCore.SettingsManager.Settings.Sound_Volume);
            Nes.SoundEnabled = RenderersCore.SettingsManager.Settings.Sound_Enabled;
        }
        private void InitializeInput()
        {
            InputManager inputManager = new InputManager(this.Handle);
            //SHORTCUTS
            inputManager.MyNesShortcuts.HardReset.Input =
               RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.HardReset;
            inputManager.MyNesShortcuts.LoadState.Input =
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.LoadState;
            inputManager.MyNesShortcuts.SaveState.Input =
                      RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SaveState;
            inputManager.MyNesShortcuts.SelectedSlot0.Input =
                     RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot0;
            inputManager.MyNesShortcuts.SelectedSlot1.Input =
                      RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot1;
            inputManager.MyNesShortcuts.SelectedSlot2.Input =
                    RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot2;
            inputManager.MyNesShortcuts.SelectedSlot3.Input =
                     RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot3;
            inputManager.MyNesShortcuts.SelectedSlot4.Input =
                     RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot4;
            inputManager.MyNesShortcuts.SelectedSlot5.Input =
                   RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot5;
            inputManager.MyNesShortcuts.SelectedSlot6.Input =
                   RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot6;
            inputManager.MyNesShortcuts.SelectedSlot7.Input =
                  RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot7;
            inputManager.MyNesShortcuts.SelectedSlot8.Input =
                  RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot8;
            inputManager.MyNesShortcuts.SelectedSlot9.Input =
                    RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot9;
            inputManager.MyNesShortcuts.ShutdownEmulation.Input =
                     RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ShutdownEmulation;
            inputManager.MyNesShortcuts.SoftReset.Input =
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SoftReset;
            inputManager.MyNesShortcuts.TakeSnapshot.Input =
                 RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.TakeSnapshot;
            inputManager.MyNesShortcuts.ToggleLimiter.Input =
                   RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ToggleLimiter;
            inputManager.MyNesShortcuts.PauseEmulation.Input =
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.PauseEmulation;
            inputManager.MyNesShortcuts.ResumeEmulation.Input =
                  RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ResumeEmulation;
            inputManager.MyNesShortcuts.Fullscreen.Input =
                    RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.Fullscreen;
            //Setup input
            Joypad joy1 = new Joypad(inputManager);
            Joypad joy2 = new Joypad(inputManager);
            joy1.A.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.A;
            joy1.B.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.B;
            joy1.TurboA.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.TurboA;
            joy1.TurboB.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.TurboB;
            joy1.Down.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.Down;
            joy1.Left.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.Left;
            joy1.Right.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.Right;
            joy1.Up.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.Up;
            joy1.Select.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.Select;
            joy1.Start.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player1.Start;

            joy2.A.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.A;
            joy2.B.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.B;
            joy2.TurboA.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.TurboA;
            joy2.TurboB.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.TurboB;
            joy2.Down.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.Down;
            joy2.Left.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.Left;
            joy2.Right.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.Right;
            joy2.Up.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.Up;
            joy2.Select.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.Select;
            joy2.Start.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player2.Start;
            if (RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Connect4Players)
            {
                Joypad joy3 = new Joypad(inputManager);
                Joypad joy4 = new Joypad(inputManager);
                joy3.A.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.A;
                joy3.B.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.B;
                joy3.TurboA.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.TurboA;
                joy3.TurboB.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.TurboB;
                joy3.Down.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.Down;
                joy3.Left.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.Left;
                joy3.Right.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.Right;
                joy3.Up.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.Up;
                joy3.Select.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.Select;
                joy3.Start.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player3.Start;

                joy4.A.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.A;
                joy4.B.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.B;
                joy4.TurboA.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.TurboA;
                joy4.TurboB.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.TurboB;
                joy4.Down.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.Down;
                joy4.Left.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.Left;
                joy4.Right.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.Right;
                joy4.Up.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.Up;
                joy4.Select.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.Select;
                joy4.Start.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Player4.Start;
                Nes.SetupInput(inputManager, joy1, joy2, joy3, joy4, true);
            }
            else
            {
                Nes.SetupInput(inputManager, joy1, joy2);
            }
            if (RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].ConnectZapper)
            {
                Nes.ControlsUnit.IsZapperConnected = true;
                Nes.ControlsUnit.Zapper = zapper = new Zapper(this);
            }
            if (Nes.RomInfo.VSUnisystem)
            {
                VSUnisystemDIP vs = new VSUnisystemDIP(inputManager);
                vs.CreditLeftCoinSlot.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.CreditLeftCoinSlot;
                vs.CreditRightCoinSlot.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.CreditRightCoinSlot;
                vs.CreditServiceButton.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.CreditServiceButton;
                vs.DIPSwitch1.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch1;
                vs.DIPSwitch2.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch2;
                vs.DIPSwitch3.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch3;
                vs.DIPSwitch4.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch4;
                vs.DIPSwitch5.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch5;
                vs.DIPSwitch6.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch6;
                vs.DIPSwitch7.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch7;
                vs.DIPSwitch8.Input = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].VSunisystemDIP.DIPSwitch8;
                Nes.ControlsUnit.VSunisystemDIP = vs;
            }
        }
        private void InitializeRendrers()
        {
            InitializeVideo();

            InitializeAudio();

            InitializeInput();

            Nes.SetupOutput(videoDevice, audioDevice, new ApuPlaybackDescription(RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq));
            Nes.SetupLimiter(new Timer());

            //palette
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
        }

        public void ApplySettings(SettingType stype)
        {
            switch (stype)
            {
                case SettingType.All:
                case SettingType.Input: InitializeInput(); break;
            }
        }
        private void EmuShutdown()
        {
            this.Close();
        }

        private void FullScreenSwitch()
        {
            Nes.TogglePause(true);
            RenderersCore.SettingsManager.Settings.Video_Fullscreen = !RenderersCore.SettingsManager.Settings.Video_Fullscreen;
            //shutdown renderers
            videoDevice.FullScreen = RenderersCore.SettingsManager.Settings.Video_Fullscreen;
            videoDevice.Shutdown();
            //re-Initialize
            InitializeVideo();
           
            Nes.VideoDevice = videoDevice;
            if (!RenderersCore.SettingsManager.Settings.Video_Fullscreen)
            {
                base.ClientSize = new Size(256 * RenderersCore.SettingsManager.Settings.Video_StretchMultiply,
    ((Nes.emuSystem.Master == MyNes.Core.TimingInfo.NTSC.Master) ? 224 : 240) * RenderersCore.SettingsManager.Settings.Video_StretchMultiply);
            }
            Nes.TogglePause(false);
        }

        private void Nes_FullscreenSwitch(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(FullScreenSwitch));
            else
                FullScreenSwitch();
        }

        private void Nes_EmuShutdown(object sender, EventArgs e)
        {
            if (!this.InvokeRequired)
                EmuShutdown();
            else
                this.Invoke(new Action(EmuShutdown));
        }

        private void RendererFormSlimDX_FormClosing(object sender, FormClosingEventArgs e)
        {
            Nes.Shutdown();
        }
        private void RendererFormSlimDX_MouseUp(object sender, MouseEventArgs e)
        {
            if (Nes.ON)
            {
                if (Nes.ControlsUnit.IsZapperConnected)
                {
                    zapper.trigger = (e.Button == System.Windows.Forms.MouseButtons.Left);
                    mouseUpPoint = e.Location;
                }
            }
        }
        private void RendererFormSlimDX_MouseDown(object sender, MouseEventArgs e)
        {
            if (Nes.ON)
            {
                if (Nes.ControlsUnit.IsZapperConnected)
                    zapper.trigger = e.Button != System.Windows.Forms.MouseButtons.Left;
            }
        }
    }
}
