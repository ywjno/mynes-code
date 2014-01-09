/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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

namespace MyNes.Debug.ConsoleCommands
{
    class Save : ConsoleCommand
    {
        public override string Method
        {
            get { return "save"; }
        }

        public override string Description
        {
            get { return "Save console lines to a file"; }
        }

        public override void Execute(string parameters)
        {
            // No need to do anything. The console window should take care of this.
            // I added this class so when user type 'help' the description of this class should listed in help lines.
        }
    }
}
