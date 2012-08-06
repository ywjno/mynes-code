using System.Windows.Forms;
using MyNes.Core;

namespace MyNes
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
            con_Memory1.Memory = NesCore.CpuMemory;
        }
    }
}