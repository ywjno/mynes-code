using myNES.Core;

namespace myNES.Debug.ConsoleCommands
{
    public class ShowDisassembler : ConsoleCommand
    {
        public override string Method
        {
            get { return "disassembler"; }
        }
        public override string Description
        {
            get { return "Show the system disassembler"; }
        }

        public override void Execute(string parameters)
        {
            var form = new FormDisassembler();
            form.Show();
        }
    }
}