using MyNes.Core;

namespace MyNes.Debug.ConsoleCommands
{
    public class CloseConsole : ConsoleCommand
    {
        FormConsole form;

        public override string Description
        {
            get { return "Close the console"; }
        }
        public override string Method
        {
            get { return "exit"; }
        }

        public CloseConsole(FormConsole form)
        {
            this.form = form;
        }

        public override void Execute(string parameters)
        {
            form.Close();
        }
    }
}