using System.Windows.Forms;
using myNES.Core;

namespace myNES
{
    public partial class FormDisassembler : Form
    {
        public FormDisassembler()
        {
            InitializeComponent();

            RefreshCpu();
            RefreshMemory();
        }

        private void RefreshCpu() { }
        private void RefreshMemory()
        {
            con_Memory1.Memory = Nes.CpuMemory;
        }
    }
}