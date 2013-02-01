/* This file is part of My Nes
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
namespace MyNes.Core
{
    /// <summary>
    /// Class represent My Nes console command
    /// </summary>
    public abstract class ConsoleCommand
    {
        /// <summary>
        /// Get the method of this command
        /// </summary>
        public abstract string Method { get; }
        /// <summary>
        /// Get the description of this command
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Get the parameters that accepted
        /// </summary>
        public virtual ConsoleCommandParameter[] Parameters { get { return new ConsoleCommandParameter[0]; } }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameters">The parameters if this command have parameters</param>
        public abstract void Execute(string parameters);
    }
    public struct ConsoleCommandParameter
    {
        public ConsoleCommandParameter(string Code, string Description)
        {
            this.Code = Code;
            this.Description = Description;
        }
        /// <summary>
        /// Get the code of this parameter
        /// </summary>
        public string Code;
        /// <summary>
        /// Get the description of this parameter
        /// </summary>
        public string Description;
    }
}