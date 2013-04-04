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
using MyNes.Core;
using MyNes.Renderers;
namespace MyNes.WinRenderers
{
    public class MyNesShortcuts
    {
        private JoyButton[] _buttons;

        public JoyButton SaveState { get { return _buttons[0]; } }
        public JoyButton LoadState { get { return _buttons[1]; } }
        public JoyButton HardReset { get { return _buttons[2]; } }
        public JoyButton SoftReset { get { return _buttons[3]; } }
        public JoyButton ShutdownEmulation { get { return _buttons[5]; } }
        public JoyButton TakeSnapshot { get { return _buttons[6]; } }
        public JoyButton ToggleLimiter { get { return _buttons[7]; } }
        public JoyButton SelectedSlot0 { get { return _buttons[8]; } }
        public JoyButton SelectedSlot1 { get { return _buttons[9]; } }
        public JoyButton SelectedSlot2 { get { return _buttons[10]; } }
        public JoyButton SelectedSlot3 { get { return _buttons[11]; } }
        public JoyButton SelectedSlot4 { get { return _buttons[12]; } }
        public JoyButton SelectedSlot5 { get { return _buttons[13]; } }
        public JoyButton SelectedSlot6 { get { return _buttons[14]; } }
        public JoyButton SelectedSlot7 { get { return _buttons[15]; } }
        public JoyButton SelectedSlot8 { get { return _buttons[16]; } }
        public JoyButton SelectedSlot9 { get { return _buttons[17]; } }
        public JoyButton PauseEmulation { get { return _buttons[18]; } }
        public JoyButton ResumeEmulation { get { return _buttons[19]; } }
        public JoyButton Fullscreen { get { return _buttons[20]; } }

        private int pressCounter = 0;
        private const int pressVal = 22;

        public MyNesShortcuts(InputManager manager)
        {
            _buttons = new JoyButton[21];
            for (int i = 0; i < 21; i++)
            {
                _buttons[i] = new JoyButton(manager);
            }
        }

        public void Update()
        {
            if (pressCounter > 0)
            {
                pressCounter--;
                return;
            }
            if (SaveState.IsPressed())
            { Nes.SaveState(RenderersCore.SettingsManager.Settings.Folders_StateFolder); pressCounter = pressVal; }
            else if (LoadState.IsPressed())
            { Nes.LoadState(RenderersCore.SettingsManager.Settings.Folders_StateFolder); pressCounter = pressVal; }

            else if (HardReset.IsPressed())
            { Nes.HardReset(); pressCounter = pressVal; }
            else if (SoftReset.IsPressed())
            { Nes.SoftReset(); pressCounter = pressVal; }
            else if (ShutdownEmulation.IsPressed())
            { Nes.Shutdown(); pressCounter = pressVal; }

            else if (TakeSnapshot.IsPressed())
            {
                Nes.VideoDevice.TakeSnapshot(
                    RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder,
                    System.IO.Path.GetFileNameWithoutExtension(Nes.RomInfo.Path),
                    RenderersCore.SettingsManager.Settings.Video_SnapshotFormat,
                    false);
                pressCounter = pressVal;
            }
            else if (ToggleLimiter.IsPressed())
            {
                Nes.SpeedLimiter.ON = !Nes.SpeedLimiter.ON;
                if (Nes.AudioDevice != null)
                    Nes.AudioDevice.ResetBuffer();
                if (Nes.VideoDevice != null)
                {
                    if (Nes.SpeedLimiter.ON)
                        Nes.VideoDevice.DrawText("Speed limiter is ON", 120, System.Drawing.Color.Green);
                    else
                        Nes.VideoDevice.DrawText("Speed limiter is OFF", 120, System.Drawing.Color.Navy);
                }
                pressCounter = pressVal;
            }
            else if (SelectedSlot0.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 0;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot1.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 1;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot2.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 2;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot3.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 3;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot4.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 4;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot5.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 5;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot6.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 6;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot7.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 7;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot8.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 8;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (SelectedSlot9.IsPressed())
            {
                pressCounter = pressVal;
                Nes.StateSlot = 9;
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (PauseEmulation.IsPressed())
            {
                pressCounter = pressVal;
                Nes.TogglePause(true);
                if (Nes.VideoDevice != null)
                    Nes.VideoDevice.DrawText("State slot changed to " + Nes.StateSlot, 120, System.Drawing.Color.White);
            }
            else if (ResumeEmulation.IsPressed())
            {
                pressCounter = pressVal;
                Nes.TogglePause(false);
            }
            else if (Fullscreen.IsPressed())
            { Nes.OnFullscreen(); pressCounter = pressVal; }
        }
    }
}