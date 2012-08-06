using MyNes.Core;

namespace MyNes.Debug.ConsoleCommands
{
    class ShowDisassembler : ConsoleCommand
    {
        public override void Execute(string parameters)
        {
            Frm_Disassembler frm = new Frm_Disassembler();
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
