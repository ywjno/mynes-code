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
using SdlDotNet.Input;
using SdlDotNet.Core;
using MyNes.Renderers;
using MyNes.Core;
using MyNes.Core.IO.Input;

namespace CPRenderers
{
    class SDLInputManager : IInputDevice
    {
        public CPJoypad joypad1;
        public CPJoypad joypad2;
        public CPJoypad joypad3;
        public CPJoypad joypad4;
        public CPVSUnisystemDIP vsunisystem;
        public bool IsFourPlayers = false;
        public bool IsVSUnisystem = false;
        private int pressCounter = 0;
        private const int pressVal = 22;
        #region joypads
        public Key p1_A = Key.X;
        public Key p1_B = Key.Z;
        public Key p1_TurboA = Key.A;
        public Key p1_TurboB = Key.S;
        public Key p1_ST = Key.V;
        public Key p1_SE = Key.C;
        public Key p1_UP = Key.UpArrow;
        public Key p1_DO = Key.DownArrow;
        public Key p1_LF = Key.LeftArrow;
        public Key p1_RT = Key.RightArrow;

        public Key p2_A = Key.K;
        public Key p2_B = Key.J;
        public Key p2_ST = Key.I;
        public Key p2_SE = Key.U;
        public Key p2_UP = Key.W;
        public Key p2_DO = Key.S;
        public Key p2_LF = Key.A;
        public Key p2_RT = Key.D;
        public Key p2_TurboA = Key.Escape;
        public Key p2_TurboB = Key.Escape;

        public Key p3_A = Key.Escape;
        public Key p3_B = Key.Escape;
        public Key p3_ST = Key.Escape;
        public Key p3_SE = Key.Escape;
        public Key p3_UP = Key.Escape;
        public Key p3_DO = Key.Escape;
        public Key p3_LF = Key.Escape;
        public Key p3_RT = Key.Escape;
        public Key p3_TurboA = Key.Escape;
        public Key p3_TurboB = Key.Escape;

        public Key p4_A = Key.Escape;
        public Key p4_B = Key.Escape;
        public Key p4_ST = Key.Escape;
        public Key p4_SE = Key.Escape;
        public Key p4_UP = Key.Escape;
        public Key p4_DO = Key.Escape;
        public Key p4_LF = Key.Escape;
        public Key p4_RT = Key.Escape;
        public Key p4_TurboA = Key.Escape;
        public Key p4_TurboB = Key.Escape;
        #endregion
        #region VS unisystem
        public Key vsu_CreditServiceButton = Key.End;
        public Key vsu_DIPSwitch1 = (Key.Keypad1 | Key.LeftControl);
        public Key vsu_DIPSwitch2 = (Key.Keypad2 | Key.LeftControl);
        public Key vsu_DIPSwitch3 = (Key.Keypad3 | Key.LeftControl);
        public Key vsu_DIPSwitch4 = (Key.Keypad4 | Key.LeftControl);
        public Key vsu_DIPSwitch5 = (Key.Keypad5 | Key.LeftControl);
        public Key vsu_DIPSwitch6 = (Key.Keypad6 | Key.LeftControl);
        public Key vsu_DIPSwitch7 = (Key.Keypad7 | Key.LeftControl);
        public Key vsu_DIPSwitch8 = (Key.Keypad8 | Key.LeftControl);
        public Key vsu_CreditLeftCoinSlot = Key.Insert;
        public Key vsu_CreditRightCoinSlot = Key.Home;
        #endregion
        #region Shortcuts
        public Key sct_SaveState = Key.F6;
        public Key sct_LoadState = Key.F9;
        public Key sct_HardReset = Key.F4;
        public Key sct_SoftReset = Key.F3;
        public Key sct_ShutdownEmulation = Key.Escape;
        public Key sct_TakeSnapshot = Key.F5;
        public Key sct_ToggleLimiter = Key.F7;
        public Key sct_SelectedSlot0 = Key.Zero;
        public Key sct_SelectedSlot1 = Key.One;
        public Key sct_SelectedSlot2 = Key.Two;
        public Key sct_SelectedSlot3 = Key.Three;
        public Key sct_SelectedSlot4 = Key.Four;
        public Key sct_SelectedSlot5 = Key.Five;
        public Key sct_SelectedSlot6 = Key.Six;
        public Key sct_SelectedSlot7 = Key.Seven;
        public Key sct_SelectedSlot8 = Key.Eight;
        public Key sct_SelectedSlot9 = Key.Nine;
        public Key sct_PauseEmulation = Key.F2;
        public Key sct_ResumeEmulation = Key.F1;
        public Key sct_Fullscreen = Key.F12;
        #endregion
        public SDLInputManager(CPJoypad joypad1, CPJoypad joypad2)
        {
            this.joypad1 = joypad1;
            this.joypad2 = joypad2;
            IsFourPlayers = true;
        }
        public SDLInputManager(CPJoypad joypad1, CPJoypad joypad2, CPJoypad joypad3, CPJoypad joypad4)
        {
            this.joypad1 = joypad1;
            this.joypad2 = joypad2;
            this.joypad3 = joypad3;
            this.joypad4 = joypad4;
            IsFourPlayers = true;
        }

        public void Update()
        {
            if (Nes.Pause) return;

            KeyboardState state = new KeyboardState(true);

            joypad1.A = state.IsKeyPressed(p1_A);
            joypad1.B = state.IsKeyPressed(p1_B);
            joypad1.TurboA = state.IsKeyPressed(p1_TurboA);
            joypad1.TurboB = state.IsKeyPressed(p1_TurboB);
            joypad1.Start = state.IsKeyPressed(p1_ST);
            joypad1.Select = state.IsKeyPressed(p1_SE);
            joypad1.Up = state.IsKeyPressed(p1_UP);
            joypad1.Down = state.IsKeyPressed(p1_DO);
            joypad1.Left = state.IsKeyPressed(p1_LF);
            joypad1.Right = state.IsKeyPressed(p1_RT);

            joypad2.A = state.IsKeyPressed(p2_A);
            joypad2.B = state.IsKeyPressed(p2_B);
            joypad2.TurboA = state.IsKeyPressed(p2_TurboA);
            joypad2.TurboB = state.IsKeyPressed(p2_TurboB);
            joypad2.Start = state.IsKeyPressed(p2_ST);
            joypad2.Select = state.IsKeyPressed(p2_SE);
            joypad2.Up = state.IsKeyPressed(p2_UP);
            joypad2.Down = state.IsKeyPressed(p2_DO);
            joypad2.Left = state.IsKeyPressed(p2_LF);
            joypad2.Right = state.IsKeyPressed(p2_RT);
            if (IsFourPlayers)
            {
                joypad3.A = state.IsKeyPressed(p3_A);
                joypad3.B = state.IsKeyPressed(p3_B);
                joypad3.TurboA = state.IsKeyPressed(p3_TurboA);
                joypad3.TurboB = state.IsKeyPressed(p3_TurboB);
                joypad3.Start = state.IsKeyPressed(p3_ST);
                joypad3.Select = state.IsKeyPressed(p3_SE);
                joypad3.Up = state.IsKeyPressed(p3_UP);
                joypad3.Down = state.IsKeyPressed(p3_DO);
                joypad3.Left = state.IsKeyPressed(p3_LF);
                joypad3.Right = state.IsKeyPressed(p3_RT);

                joypad4.A = state.IsKeyPressed(p4_A);
                joypad4.B = state.IsKeyPressed(p4_B);
                joypad4.TurboA = state.IsKeyPressed(p4_TurboA);
                joypad4.TurboB = state.IsKeyPressed(p4_TurboB);
                joypad4.Start = state.IsKeyPressed(p4_ST);
                joypad4.Select = state.IsKeyPressed(p4_SE);
                joypad4.Up = state.IsKeyPressed(p4_UP);
                joypad4.Down = state.IsKeyPressed(p4_DO);
                joypad4.Left = state.IsKeyPressed(p4_LF);
                joypad4.Right = state.IsKeyPressed(p4_RT);
            }
            if (IsVSUnisystem)
            {
                vsunisystem.CreditLeftCoinSlot = state.IsKeyPressed(vsu_CreditLeftCoinSlot);
                vsunisystem.CreditRightCoinSlot = state.IsKeyPressed(vsu_CreditRightCoinSlot);
                vsunisystem.CreditServiceButton = state.IsKeyPressed(vsu_CreditServiceButton);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch1);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch2);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch3);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch4);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch5);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch6);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch7);
                vsunisystem.DIPSwitch1 = state.IsKeyPressed(vsu_DIPSwitch8);
            }
        }

        public void UpdateEvents()
        {
            if (pressCounter > 0)
            {
                pressCounter--;
                return;
            }
            KeyboardState state = new KeyboardState(true);
            if (state.IsKeyPressed(sct_SaveState))
            { Nes.SaveState(RenderersCore.SettingsManager.Settings.Folders_StateFolder); pressCounter = pressVal; }
            else if (state.IsKeyPressed(sct_LoadState))
            { Nes.LoadState(RenderersCore.SettingsManager.Settings.Folders_StateFolder); pressCounter = pressVal; }

            else if (state.IsKeyPressed(sct_HardReset))
            { Nes.HardReset(); pressCounter = pressVal; }
            else if (state.IsKeyPressed(sct_SoftReset))
            { Nes.SoftReset(); pressCounter = pressVal; }
            else if (state.IsKeyPressed(sct_ShutdownEmulation))
            {
                pressCounter = pressVal;
                Nes.Pause = true;
                Nes.Shutdown();
                Events.QuitApplication();
            }

            else if (state.IsKeyPressed(sct_TakeSnapshot))
            {
                Nes.VideoDevice.TakeSnapshot(
                    RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder + "\\" +
                    System.IO.Path.GetFileNameWithoutExtension(Nes.RomInfo.Path) +
                    RenderersCore.SettingsManager.Settings.Video_SnapshotFormat,
                    System.IO.Path.GetFileNameWithoutExtension(Nes.RomInfo.Path),
                    RenderersCore.SettingsManager.Settings.Video_SnapshotFormat,
                    false);
                pressCounter = pressVal;
            }
            else if (state.IsKeyPressed(sct_ToggleLimiter))
            {
                Nes.SpeedLimiter.ON = !Nes.SpeedLimiter.ON; pressCounter = pressVal;
                if (Nes.SpeedLimiter.ON)
                    Nes.VideoDevice.DrawText("Speed limiter is on", 120, System.Drawing.Color.White);
                else
                    Nes.VideoDevice.DrawText("Speed limiter is off", 120, System.Drawing.Color.Navy);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot0))
            {
                Nes.StateSlot = 0; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot1))
            {
                Nes.StateSlot = 1; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot2))
            {
                Nes.StateSlot = 2; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot3))
            {
                Nes.StateSlot = 3; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot4))
            {
                Nes.StateSlot = 4; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot5))
            {
                Nes.StateSlot = 5; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot6))
            {
                Nes.StateSlot = 6; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot7))
            {
                Nes.StateSlot = 7; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot8))
            {
                Nes.StateSlot = 8; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_SelectedSlot9))
            {
                Nes.StateSlot = 9; pressCounter = pressVal;
                Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (state.IsKeyPressed(sct_PauseEmulation))
            { Nes.TogglePause(true); pressCounter = pressVal; }
            else if (state.IsKeyPressed(sct_ResumeEmulation))
            { Nes.TogglePause(false); pressCounter = pressVal; }
            else if (state.IsKeyPressed(sct_Fullscreen))
            { Nes.OnFullscreen(); pressCounter = pressVal; }
        }
    }
}
