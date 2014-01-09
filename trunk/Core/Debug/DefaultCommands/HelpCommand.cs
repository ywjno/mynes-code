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
namespace MyNes.Core.Debug.DefaultCommands
{
    public class HelpCommand : ConsoleCommand
    {
        public override string Method
        {
            get { return "help"; }
        }
        public override string Description
        {
            get { return "View available console instructions"; }
        }

        public override void Execute(string parameters)
        {
            Console.WriteLine("Available instructions:", DebugCode.Good);

            foreach (ConsoleCommand command in ConsoleCommands.AvailableCommands)
            {
                Console.WriteLine("> " + command.Method + ": " + command.Description);

                foreach (ConsoleCommandParameter par in command.Parameters)
                    Console.WriteLine(" ->" + par.Code + ": " + par.Description);
            }
        }
    }
}