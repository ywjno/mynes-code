using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myNES
{
    public partial class FormAbout : Form
    {
        public FormAbout(string version)
        {
            InitializeComponent();
            label_version.Text = "version " + version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
