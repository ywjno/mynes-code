using System.Collections.Generic;
using System.Reflection;
using System;
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
        { get { return availableCommands.ToArray(); } }
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
