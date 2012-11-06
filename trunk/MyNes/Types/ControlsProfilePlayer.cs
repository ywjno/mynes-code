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
namespace MyNes
{
    public class ControlsProfilePlayer
    {
        private string _A;
        private string _B;
        private string _TurboA;
        private string _TurboB;
        private string _Left;
        private string _Right;
        private string _Up;
        private string _Down;
        private string _Start;
        private string _Select;

        public string A
        { get { return _A; } set { _A = value; } }
        public string B
        { get { return _B; } set { _B = value; } }
        public string TurboA
        { get { return _TurboA; } set { _TurboA = value; } }
        public string TurboB
        { get { return _TurboB; } set { _TurboB = value; } }
        public string Left
        { get { return _Left; } set { _Left = value; } }
        public string Right
        { get { return _Right; } set { _Right = value; } }
        public string Up
        { get { return _Up; } set { _Up = value; } }
        public string Down
        { get { return _Down; } set { _Down = value; } }
        public string Start
        { get { return _Start; } set { _Start = value; } }
        public string Select
        { get { return _Select; } set { _Select = value; } }
    }
}
