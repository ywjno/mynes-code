﻿/* This file is part of My Nes
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
using MyNes.Core.IO.Input;
namespace CPRenderers
{
    class CPZapper: IZapper
    {
        public CPZapper(DetectZapperLight detect)
        {
            this.detectLight = detect;
        }
        public bool trigger = false;
        public bool lightDetected = false;
        public delegate bool DetectZapperLight();
        DetectZapperLight detectLight;
        public bool Trigger
        {
            get
            {
                return trigger;
            }
        }

        public bool LightDetected
        {
            get
            {
                lightDetected = this.detectLight();
                return !lightDetected;
            }
        }
    }
}
