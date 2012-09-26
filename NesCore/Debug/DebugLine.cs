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
namespace MyNes.Core
{
    public struct DebugLine
    {
        public DebugLine(string debugLine, DebugCode status)
        {
            this.debugLine = debugLine;
            this.status = status;
        }
        string debugLine;
        DebugCode status;

        public string Text
        { get { return debugLine; } set { debugLine = value; } }
        public DebugCode Code
        { get { return status; } set { status = value; } }
    }
}
