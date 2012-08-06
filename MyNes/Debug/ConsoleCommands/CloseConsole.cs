using MyNes.Core;

namespace MyNes.Debug.ConsoleCommands
{
    class CloseConsole : ConsoleCommand
    {
        public CloseConsole(FormConsole frm)
        {
            this.frm = frm;
        }
        FormConsole frm;
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
