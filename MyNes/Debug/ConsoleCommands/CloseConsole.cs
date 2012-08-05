using MyNes.Core;

namespace MyNes.Debug.ConsoleCommands
{
    class CloseConsole : ConsoleCommand
    {
        public CloseConsole(Frm_Console frm)
        {
            this.frm = frm;
        }
        Frm_Console frm;
        public override void Execute(string parameters)
        {
            frm.Close();
        }

        public override string Method
        {
            get { return "exit"; }
        }

        public override string Description
        {
            get { return "Close the console"; }
        }
    }
}
