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

namespace MyNes.Core
{
    /// <summary>
    /// My Nes Console
    /// </summary>
    public class Console
    {
        /// <summary>
        /// Write line to the console and raise the "LineWritten" event
        /// </summary>
        /// 
        /// <param name="text">The debug line</param>
        /// <param name="code">The status</param>
        public static void WriteLine(string text, DebugCode code = DebugCode.None)
        {
            if (LineWritten != null)
                LineWritten(null, new DebugEventArgs(text, code));
        }
        /// <summary>
        /// Update the last written line
        /// </summary>
        /// <param name="text">The debug line</param>
        /// <param name="code">The status</param>
        public static void UpdateLine(string text, DebugCode code = DebugCode.None)
        {
            if (UpdateLastLine != null)
                UpdateLastLine(null, new DebugEventArgs(text, code));
        }

        public static event EventHandler<DebugEventArgs> LineWritten;
        public static event EventHandler<DebugEventArgs> UpdateLastLine;
    }
}