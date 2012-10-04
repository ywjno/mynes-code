/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
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
namespace MyNes
{
    public partial class RendererFormSlimDX : Form
    {
        public RendererFormSlimDX()
        {
            InitializeComponent();
            InitializeRendrers();
            base.ClientSize = new Size(256 * Program.Settings.VideoStretchMultiply,
                ((Nes.emuSystem.Master == MyNes.Core.TimingInfo.NTSC.Master) ? 224 : 240) * Program.Settings.VideoStretchMultiply);
            Nes.EmuShutdown += new EventHandler(Nes_EmuShutdown);
            Nes.RendererShutdown += new EventHandler(Nes_RendererShutdown);
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
        }
        private VideoD3D videoDevice;
        private IAudioDevice audioDevice;
        private Zapper zapper;
        private bool isRendererShutdown = false;
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
        void InitializeVideo()
        {
            videoDevice = new VideoD3D(Nes.emuSystem, this);
            videoDevice.ImmediateMode = Program.Settings.VideoImmediateMode;
            videoDevice.cutLines = Program.Settings.VideoHideLines;
            videoDevice.AdapterIndex = Program.Settings.VideoAdapterIndex;
            videoDevice.FullScreenModeIndex = Program.Settings.VideoResIndex;
            videoDevice.FullScreen = Program.Settings.VideoFullscreen;
            videoDevice.Initialize();
        }
        void InitializeAudio()
        {
            audioDevice = new AudioDSD(this.Handle, Program.Settings.SoundPlaybackFreq, Program.Settings.SoundLatency);
            ((AudioDSD)audioDevice).SetVolume(Program.Settings.Volume);
            Nes.SoundEnabled = Program.Settings.SoundEnabled;
        }
        void InitializeInput()
        {
            InputManager inputManager = new InputManager(this.Handle);
            //SHORTCUTS
            inputManager.MyNesShortcuts.HardReset.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.HardReset;
            inputManager.MyNesShortcuts.LoadState.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.LoadState;
            inputManager.MyNesShortcuts.SaveState.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SaveState;
            inputManager.MyNesShortcuts.SelectedSlot0.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot0;
            inputManager.MyNesShortcuts.SelectedSlot1.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot1;
            inputManager.MyNesShortcuts.SelectedSlot2.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot2;
            inputManager.MyNesShortcuts.SelectedSlot3.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot3;
            inputManager.MyNesShortcuts.SelectedSlot4.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot4;
            inputManager.MyNesShortcuts.SelectedSlot5.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot5;
            inputManager.MyNesShortcuts.SelectedSlot6.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot6;
            inputManager.MyNesShortcuts.SelectedSlot7.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot7;
            inputManager.MyNesShortcuts.SelectedSlot8.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot8;
            inputManager.MyNesShortcuts.SelectedSlot9.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SelecteSlot9;
            inputManager.MyNesShortcuts.ShutdownEmulation.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.ShutdownEmulation;
            inputManager.MyNesShortcuts.SoftReset.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.SoftReset;
            inputManager.MyNesShortcuts.TakeSnapshot.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.TakeSnapshot;
            inputManager.MyNesShortcuts.ToggleLimiter.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.ToggleLimiter;
            inputManager.MyNesShortcuts.PauseEmulation.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.PauseEmulation;
            inputManager.MyNesShortcuts.ResumeEmulation.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.ResumeEmulation;
            inputManager.MyNesShortcuts.Fullscreen.Input =
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Shortcuts.Fullscreen;
            //Setup input
            Joypad joy1 = new Joypad(inputManager);
            Joypad joy2 = new Joypad(inputManager);
            joy1.A.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.A;
            joy1.B.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.B;
            joy1.TurboA.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.TurboA;
            joy1.TurboB.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.TurboB;
            joy1.Down.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Down;
            joy1.Left.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Left;
            joy1.Right.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Right;
            joy1.Up.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Up;
            joy1.Select.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Select;
            joy1.Start.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Start;

            joy2.A.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.A;
            joy2.B.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.B;
            joy2.TurboA.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.TurboA;
            joy2.TurboB.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.TurboB;
            joy2.Down.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Down;
            joy2.Left.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Left;
            joy2.Right.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Right;
            joy2.Up.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Up;
            joy2.Select.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Select;
            joy2.Start.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Start;
            if (Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Connect4Players)
            {
                Joypad joy3 = new Joypad(inputManager);
                Joypad joy4 = new Joypad(inputManager);
                joy3.A.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.A;
                joy3.B.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.B;
                joy3.TurboA.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.TurboA;
                joy3.TurboB.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.TurboB;
                joy3.Down.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Down;
                joy3.Left.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Left;
                joy3.Right.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Right;
                joy3.Up.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Up;
                joy3.Select.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Select;
                joy3.Start.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Start;

                joy4.A.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.A;
                joy4.B.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.B;
                joy4.TurboA.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.TurboA;
                joy4.TurboB.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.TurboB;
                joy4.Down.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Down;
                joy4.Left.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Left;
                joy4.Right.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Right;
                joy4.Up.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Up;
                joy4.Select.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Select;
                joy4.Start.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Start;
                Nes.SetupInput(inputManager, joy1, joy2, joy3, joy4, true);
            }
            else
            {
                Nes.SetupInput(inputManager, joy1, joy2);
            }
            if (Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].ConnectZapper)
            {
                Nes.ControlsUnit.IsZapperConnected = true;
                Nes.ControlsUnit.Zapper = zapper = new Zapper(this);
            }
            if (Nes.RomInfo.VSUnisystem)
            {
                VSUnisystemDIP vs = new VSUnisystemDIP(inputManager);
                vs.CreditLeftCoinSlot.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditLeftCoinSlot;
                vs.CreditRightCoinSlot.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditRightCoinSlot;
                vs.CreditServiceButton.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditServiceButton;
                vs.DIPSwitch1.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch1;
                vs.DIPSwitch2.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch2;
                vs.DIPSwitch3.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch3;
                vs.DIPSwitch4.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch4;
                vs.DIPSwitch5.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch5;
                vs.DIPSwitch6.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch6;
                vs.DIPSwitch7.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch7;
                vs.DIPSwitch8.Input = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch8;
                Nes.ControlsUnit.VSunisystemDIP = vs;
            }
        }
        void InitializeRendrers()
        {
            InitializeVideo();

            InitializeAudio();

            InitializeInput();

            Nes.SetupOutput(videoDevice, audioDevice, new ApuPlaybackDescription(Program.Settings.SoundPlaybackFreq));
            Nes.SetupLimiter(new Timer());

            //palette
            NTSCPaletteGenerator.brightness = Program.Settings.PaletteSettings.NTSC_brightness;
            NTSCPaletteGenerator.contrast = Program.Settings.PaletteSettings.NTSC_contrast;
            NTSCPaletteGenerator.gamma = Program.Settings.PaletteSettings.NTSC_gamma;
            NTSCPaletteGenerator.hue_tweak = Program.Settings.PaletteSettings.NTSC_hue_tweak;
            NTSCPaletteGenerator.saturation = Program.Settings.PaletteSettings.NTSC_saturation;

            PALBPaletteGenerator.brightness = Program.Settings.PaletteSettings.PALB_brightness;
            PALBPaletteGenerator.contrast = Program.Settings.PaletteSettings.PALB_contrast;
            PALBPaletteGenerator.gamma = Program.Settings.PaletteSettings.PALB_gamma;
            PALBPaletteGenerator.hue_tweak = Program.Settings.PaletteSettings.PALB_hue_tweak;
            PALBPaletteGenerator.saturation = Program.Settings.PaletteSettings.PALB_saturation;

            Nes.SetupPalette();
        }
        void RedererShutdown()
        {
            videoDevice.Shutdown();
            audioDevice.Shutdown();
            isRendererShutdown = true;
            this.Close();
        }
        void EmuShutdown()
        {
            isRendererShutdown = false;
            this.Close();
        }

        void FullScreenSwitch()
        {
            Nes.TogglePause(true);
            Program.Settings.VideoFullscreen = !Program.Settings.VideoFullscreen;
            //shutdown renderers
            videoDevice.Shutdown();
            //re-Initialize
            InitializeVideo();

            Nes.VideoDevice = videoDevice;

            Nes.TogglePause(false);
        }

        void Nes_FullscreenSwitch(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(FullScreenSwitch));
            else
                FullScreenSwitch();
        }
        void Nes_RendererShutdown(object sender, EventArgs e)
        {
            if (!this.InvokeRequired)
                RedererShutdown();
            else
                this.Invoke(new Action(RedererShutdown));
        }
        void Nes_EmuShutdown(object sender, EventArgs e)
        {
            if (!this.InvokeRequired)
                EmuShutdown();
            else
                this.Invoke(new Action(EmuShutdown));
        }

        private void RendererFormSlimDX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isRendererShutdown)
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
