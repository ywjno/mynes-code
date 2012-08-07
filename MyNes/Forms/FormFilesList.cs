using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myNES
{
    public partial class FormFilesList : Form
    {
        public FormFilesList(string[] FILES)
        {
            InitializeComponent(); 
            for (int i = 0; i < FILES.Length; i++)
            {
                if (Path.GetExtension(FILES[i]).ToLower() == ".nes")
                {
                    listBox1.Items.Add(FILES[i]);
                }
            }
            listBox1.SelectedIndex = (listBox1.Items.Count > 0) ? 0 : -1;
        }

        public string SelectedRom { get { return listBox1.SelectedItem.ToString(); } }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = listBox1.SelectedIndex >= 0;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
