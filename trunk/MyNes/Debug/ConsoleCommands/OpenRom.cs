using MyNes.Core;
using System.Windows.Forms;

namespace MyNes.Debug.ConsoleCommands
{
    class OpenRom : ConsoleCommand
    {
        public override void Execute(string parameters)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "INES (*.nes)|*.nes";
            if (op.ShowDialog() == DialogResult.OK)
            {
                NesCore.CreateNew(op.FileName);
            }
        }

        public override string Method
        {
            get { return "open"; }
        }

        public override string Description
        {
            get { return "Open a rom (for test)"; }
        }
    }
}
