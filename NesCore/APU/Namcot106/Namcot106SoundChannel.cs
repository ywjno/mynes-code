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
using MyNes.Core.APU;
namespace MyNes.Core.APU.Namcot106
{
    class Namcot106SoundChannel: Channel
    {
        public Namcot106SoundChannel(TimingInfo.System system)
            : base(system) { }

        public void PokeA(byte data)
        { }
        public void PokeB(byte data)
        { }
        public void PokeC(byte data)
        { }
        public void PokeD(byte data)
        { }
        public void PokeE(byte data)
        { }
    }
}
