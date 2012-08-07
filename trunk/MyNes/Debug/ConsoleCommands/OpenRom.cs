using System.Windows.Forms;
using myNES.Core;

namespace myNES.Debug.ConsoleCommands
{
    public class OpenRom : ConsoleCommand
    {
        public override string Description
        {
            get { return "Open a rom (for test)"; }
        }
        public override string Method
        {
            get { return "open"; }
        }

        public override void Execute(string parameters)
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "INES (*.nes)|*.nes";

                if (form.ShowDialog() == DialogResult.OK)
                    Nes.CreateNew(form.FileName);
            }
        }
    }
}