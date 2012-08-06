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
                var line = "> " + command.Method + ": ";

                foreach (var parameter in command.Parameters)
                    line += parameter + " ";

                line += command.Description;

                Console.WriteLine(line);
            }
        }
    }
}