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
                {
                    try
                    {
                        Nes.CreateNew(form.FileName);
                        //launch the renderer form (slimdx for now)
                        //the renderer (or host) form should setup input and output
                        RendererFormSlimDX frm = new RendererFormSlimDX();
                        frm.Show();
                        //for tests, make result outputs on the console
                        Nes.CpuMemory.Hook(0x6000, 0x7FFF, poke6004);
                        //turn on
                        Nes.TurnOn();
                        //run the thread
                        System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ThreadStart(Nes.Run));
                        thr.Start();
                    }
                    catch { }

                }
            }
        }

        void poke6004(int address, byte data)
        {
            //output result
            if (data != 0)// 0= nothing
                Console.WriteLine((new System.Text.ASCIIEncoding()).GetString(new byte[] { data }), DebugCode.Warning);
        }
    }
}