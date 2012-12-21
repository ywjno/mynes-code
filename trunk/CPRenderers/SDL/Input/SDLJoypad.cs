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
using MyNes.Core.IO.Input;
namespace CPRenderers
{
    class SDLJoypad : IJoypad
    {
        public bool A = false;
        public bool B = false;
        public bool TurboA = false;
        public bool TurboB = false;
        public bool Up = false;
        public bool Right = false;
        public bool Left = false;
        public bool Down = false;
        public bool Start = false;
        public bool Select = false;
        private bool turbo = false;

        public byte GetData()
        {
            byte num = 0;

            if (A)
                num |= 1;

            if (B)
                num |= 2;

            if (turbo)
            {
                if (TurboA)
                    num |= 1;

                if (TurboB)
                    num |= 2;
            }

            if (Select)
                num |= 4;

            if (Start)
                num |= 8;

            if (Up)
                num |= 0x10;

            if (Down)
                num |= 0x20;

            if (Left)
                num |= 0x40;

            if (Right)
                num |= 0x80;

            return num;
        }
        public bool Turbo
        {
            get
            {
                return turbo;
            }
            set
            {
                turbo = value;
            }
        }
    }
}
