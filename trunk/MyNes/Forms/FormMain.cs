using System;
using System.Windows.Forms;

namespace MyNes
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCreateFolder_Click(object sender, EventArgs e) { }
        private void buttonModifyFolder_Click(object sender, EventArgs e) { }
        private void buttonDeleteFolder_Click(object sender, EventArgs e) { }

        private void buttonPlay_Click(object sender, EventArgs e) { }
        private void buttonHalt_Click(object sender, EventArgs e) { }
        private void buttonStop_Click(object sender, EventArgs e) { }

        private void buttonConsole_Click(object sender, EventArgs e) { }
        private void buttonPalette_Click(object sender, EventArgs e) { }

        private void buttonCpu_Click(object sender, EventArgs e) { }
        private void buttonPpu_Click(object sender, EventArgs e) { }
        private void buttonApu_Click(object sender, EventArgs e) { }
        private void buttonPad_Click(object sender, EventArgs e) { }
    }
}