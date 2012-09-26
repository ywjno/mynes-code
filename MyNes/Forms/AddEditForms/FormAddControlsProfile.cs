using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNes
{
    public partial class FormAddControlsProfile : Form
    {
        public FormAddControlsProfile()
        {
            InitializeComponent();
            foreach (ControlProfile profile in Program.Settings.ControlProfiles)
                comboBox1.Items.Add(profile.Name);
            comboBox1.SelectedIndex = 0;
        }
        public string ProfileName
        { get { return textBox_name.Text; } }
        public int ProfileIndexToCopyFrom
        { get { return comboBox1.SelectedIndex; } }
        //ok
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Length == 0)
            {
                MessageBox.Show("Please enter a name for the profile first");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
