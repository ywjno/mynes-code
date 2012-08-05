using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNes.Core.Debug.DefaultCommands
{
    class help : ConsoleCommand
    {
        /// <summary>
        /// Do the command
        /// </summary>
        /// <param name="parameters">The parameters</param>
        /// <returns>True if executed success, otherwise false</returns>
        public override void Execute(string parameters)
        {
            CONSOLE.WriteLine("AVAILABLE INSTRUCTIONS:", DebugCode.Good);
            foreach (ConsoleCommand command in ConsoleCommands.AvailableCommands)
            {
                string line = "> " + command.Method + ": ";
                foreach (string par in command.Parameters)
                    line += par + " ";
                line += command.Description;

                CONSOLE.WriteLine(line);
            }
        }
        /// <summary>
        /// The method
        /// </summary>
        public override string Method
        {
            get { return "help"; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public override string Description
        {
            get { return "View available console instructions"; }
        }
    }
}
