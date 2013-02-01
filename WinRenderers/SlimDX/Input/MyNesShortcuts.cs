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
            if (SaveState.IsPressed())
                Nes.SaveState(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
            else if (LoadState.IsPressed())
                Nes.LoadState(RenderersCore.SettingsManager.Settings.Folders_StateFolder);

            else if (HardReset.IsPressed())
                Nes.HardReset();
            else if (SoftReset.IsPressed())
                Nes.SoftReset();
            else if (ShutdownEmulation.IsPressed())
                Nes.Shutdown();

            else if (TakeSnapshot.IsPressed())
                Nes.VideoDevice.TakeSnapshot(RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder + "\\" +
                    System.IO.Path.GetFileNameWithoutExtension(Nes.RomInfo.Path) +
              RenderersCore.SettingsManager.Settings.Video_SnapshotFormat, 
              RenderersCore.SettingsManager.Settings.Video_SnapshotFormat);

            else if (ToggleLimiter.IsPressed())
                Nes.SpeedLimiter.ON = !Nes.SpeedLimiter.ON;
            else if (SelectedSlot0.IsPressed())
                Nes.StateSlot = 0;
            else if (SelectedSlot1.IsPressed())
                Nes.StateSlot = 1;
            else if (SelectedSlot2.IsPressed())
                Nes.StateSlot = 2;
            else if (SelectedSlot3.IsPressed())
                Nes.StateSlot = 3;
            else if (SelectedSlot4.IsPressed())
                Nes.StateSlot = 4;
            else if (SelectedSlot5.IsPressed())
                Nes.StateSlot = 5;
            else if (SelectedSlot6.IsPressed())
                Nes.StateSlot = 6;
            else if (SelectedSlot7.IsPressed())
                Nes.StateSlot = 7;
            else if (SelectedSlot8.IsPressed())
                Nes.StateSlot = 8;
            else if (SelectedSlot9.IsPressed())
                Nes.StateSlot = 9;
            else if (PauseEmulation.IsPressed())
                Nes.TogglePause(true);
            else if (ResumeEmulation.IsPressed())
                Nes.TogglePause(false);
            else if (Fullscreen.IsPressed())
                Nes.OnFullscreen();
        }
    }
}