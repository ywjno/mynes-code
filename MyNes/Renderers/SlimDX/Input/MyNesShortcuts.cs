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
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectInput;
using MyNes.Core.IO.Input;
using MyNes.Core;

namespace MyNes
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
        public JoyButton SelecteSlot0 { get { return _buttons[8]; } }
        public JoyButton SelecteSlot1 { get { return _buttons[9]; } }
        public JoyButton SelecteSlot2 { get { return _buttons[10]; } }
        public JoyButton SelecteSlot3 { get { return _buttons[11]; } }
        public JoyButton SelecteSlot4 { get { return _buttons[12]; } }
        public JoyButton SelecteSlot5 { get { return _buttons[13]; } }
        public JoyButton SelecteSlot6 { get { return _buttons[14]; } }
        public JoyButton SelecteSlot7 { get { return _buttons[15]; } }
        public JoyButton SelecteSlot8 { get { return _buttons[16]; } }
        public JoyButton SelecteSlot9 { get { return _buttons[17]; } }
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
                Nes.SaveState(Program.Settings.StateFolder);
            else if (LoadState.IsPressed())
                Nes.LoadState(Program.Settings.StateFolder);

            else if (HardReset.IsPressed())
                Nes.HardReset();
            else if (SoftReset.IsPressed())
                Nes.SoftReset();
            else if (ShutdownEmulation.IsPressed())
                Nes.Shutdown();

            else if (TakeSnapshot.IsPressed())
                Nes.VideoDevice.TakeSnapshot(Program.Settings.SnapshotsFolder + "\\" +
                    System.IO.Path.GetFileNameWithoutExtension(Nes.RomInfo.Path) +
                    Program.Settings.SnapshotFormat, Program.Settings.SnapshotFormat);

            else if (ToggleLimiter.IsPressed())
                Nes.SpeedLimiter.ON = !Nes.SpeedLimiter.ON;
            else if (SelecteSlot0.IsPressed())
                Nes.StateSlot = 0;
            else if (SelecteSlot1.IsPressed())
                Nes.StateSlot = 1;
            else if (SelecteSlot2.IsPressed())
                Nes.StateSlot = 2;
            else if (SelecteSlot3.IsPressed())
                Nes.StateSlot = 3;
            else if (SelecteSlot4.IsPressed())
                Nes.StateSlot = 4;
            else if (SelecteSlot5.IsPressed())
                Nes.StateSlot = 5;
            else if (SelecteSlot6.IsPressed())
                Nes.StateSlot = 6;
            else if (SelecteSlot7.IsPressed())
                Nes.StateSlot = 7;
            else if (SelecteSlot8.IsPressed())
                Nes.StateSlot = 8;
            else if (SelecteSlot9.IsPressed())
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
