/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Renderers;
namespace MyNes
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
            this.Text = "Input settings (Current profile: " +
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Name + ")";
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
            this.Text = "Input settings (Current profile: " + RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Name + ")";
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
            RenderersCore.SettingsManager.SaveSettings();
        }
    }
}
