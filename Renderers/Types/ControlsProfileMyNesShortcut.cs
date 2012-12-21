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
namespace MyNes.Renderers
{
    public class ControlsProfileMyNesShortcut
    {
        private string _SaveState;
        private string _LoadState;
        private string _HardReset;
        private string _SoftReset;
        private string _ShutdownEmulation;
        private string _TakeSnapshot;
        private string _ToggleLimiter;
        private string _SelecteSlot0;
        private string _SelecteSlot1;
        private string _SelecteSlot2;
        private string _SelecteSlot3;
        private string _SelecteSlot4;
        private string _SelecteSlot5;
        private string _SelecteSlot6;
        private string _SelecteSlot7;
        private string _SelecteSlot8;
        private string _SelecteSlot9;
        private string _PauseEmulation;
        private string _ResumeEmulation;
        private string _Fullscreen;

        public string SaveState { get { return _SaveState; } set { _SaveState = value; } }
        public string LoadState { get { return _LoadState; } set { _LoadState = value; } }
        public string HardReset { get { return _HardReset; } set { _HardReset = value; } }
        public string SoftReset { get { return _SoftReset; } set { _SoftReset = value; } }
        public string ShutdownEmulation { get { return _ShutdownEmulation; } set { _ShutdownEmulation = value; } }
        public string TakeSnapshot { get { return _TakeSnapshot; } set { _TakeSnapshot = value; } }
        public string ToggleLimiter { get { return _ToggleLimiter; } set { _ToggleLimiter = value; } }
        public string SelecteSlot0 { get { return _SelecteSlot0; } set { _SelecteSlot0 = value; } }
        public string SelecteSlot1 { get { return _SelecteSlot1; } set { _SelecteSlot1 = value; } }
        public string SelecteSlot2 { get { return _SelecteSlot2; } set { _SelecteSlot2 = value; } }
        public string SelecteSlot3 { get { return _SelecteSlot3; } set { _SelecteSlot3 = value; } }
        public string SelecteSlot4 { get { return _SelecteSlot4; } set { _SelecteSlot4 = value; } }
        public string SelecteSlot5 { get { return _SelecteSlot5; } set { _SelecteSlot5 = value; } }
        public string SelecteSlot6 { get { return _SelecteSlot6; } set { _SelecteSlot6 = value; } }
        public string SelecteSlot7 { get { return _SelecteSlot7; } set { _SelecteSlot7 = value; } }
        public string SelecteSlot8 { get { return _SelecteSlot8; } set { _SelecteSlot8 = value; } }
        public string SelecteSlot9 { get { return _SelecteSlot9; } set { _SelecteSlot9 = value; } }
        public string PauseEmulation { get { return _PauseEmulation; } set { _PauseEmulation = value; } }
        public string ResumeEmulation { get { return _ResumeEmulation; } set { _ResumeEmulation = value; } }
        public string Fullscreen { get { return _Fullscreen; } set { _Fullscreen = value; } }
    }
}
