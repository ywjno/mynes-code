using MyNes.Core;

namespace MyNes.Debug.ConsoleCommands
{
    class ShowDisassembler : ConsoleCommand
    {
        public override void Execute(string parameters)
        {
            FormDisassembler frm = new FormDisassembler();
            frm.Show();
        }

        public override string Method
        {
            get { return "disassembler"; }
        }

        public override string Description
        {
            get { return "Show the system disassembler"; }
        }
    }
}
