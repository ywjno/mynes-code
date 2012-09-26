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
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
            this.Text = "Input settings (Current profile: " + Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Name + ")";
            //Add controls
            ISC_Profiles pr = new ISC_Profiles();
            controls.Add(pr);
            pr.ProfileChanged += new EventHandler(pr_ProfileChanged);
            listBox1.Items.Add("Profiles");

            ISC_General gn = new ISC_General();
            controls.Add(gn);
            listBox1.Items.Add("General");

            ISC_Shortcuts srt = new ISC_Shortcuts();
            controls.Add(srt);
            listBox1.Items.Add("Emulation");

            ISC_Player pl = new ISC_Player(1);
            controls.Add(pl);
            listBox1.Items.Add("Player 1");
            pl = new ISC_Player(2);
            controls.Add(pl);
            listBox1.Items.Add("Player 2");
            pl = new ISC_Player(3);
            controls.Add(pl);
            listBox1.Items.Add("Player 3");
            pl = new ISC_Player(4);
            controls.Add(pl);
            listBox1.Items.Add("Player 4");

            ISC_VSUnisystem uni = new ISC_VSUnisystem();
            controls.Add(uni);
            listBox1.Items.Add("VSUnisystem DIP");

            listBox1.SelectedIndex = 0;
        }

        void pr_ProfileChanged(object sender, EventArgs e)
        {
            this.Text = "Input settings (Current profile: " + Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Name + ")";
        }
        List<InputSettingsControl> controls = new List<InputSettingsControl>();
        //close
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //default selected
        private void button3_Click(object sender, EventArgs e)
        {
            controls[listBox1.SelectedIndex].DefaultSettings();
        }
        //default all
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (InputSettingsControl control in controls)
                control.DefaultSettings();
        }
        //when selecting option
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InputSettingsControl control = controls[listBox1.SelectedIndex];
            control.OnSettingsSelect();
            control.Location = new Point(0, 0);
            panel1.Controls.Add(control);
        }
        //save on closing
        private void FormInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (InputSettingsControl control in controls)
                control.SaveSettings();
            Program.Settings.Save();
        }
    }
}
