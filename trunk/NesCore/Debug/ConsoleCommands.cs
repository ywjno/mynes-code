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
using System.Reflection;

namespace MyNes.Core
{
    /// <summary>
    /// The class that manage the console commands
    /// </summary>
    public class ConsoleCommands
    {
        static List<ConsoleCommand> availableCommands = new List<ConsoleCommand>();

        /// <summary>
        /// Get tha available commands
        /// </summary>
        public static ConsoleCommand[] AvailableCommands
        {
            get { return availableCommands.ToArray(); }
        }

        /// <summary>
        /// Add command to the commands
        /// </summary>
        /// <param name="theCommand">The command to add</param>
        public static void AddCommand(ConsoleCommand theCommand)
        {
            availableCommands.Add(theCommand);
        }

        /// <summary>
        /// Detect and add the default commands, the available commands list get cleared
        /// </summary>
        public static void AddDefaultCommands()
        {
            availableCommands = new List<ConsoleCommand>();
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type tp in types)
            {
                if (tp.IsSubclassOf(typeof(ConsoleCommand)))
                {
                    ConsoleCommand command = Activator.CreateInstance(tp) as ConsoleCommand;
                    availableCommands.Add(command);
                }
            }
        }
    }
}