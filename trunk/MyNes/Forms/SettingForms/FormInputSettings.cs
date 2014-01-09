/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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
    public partial class FormInputSettings : Form
    {
        public FormInputSettings()
        {
            InitializeComponent();
            // Fix
            if (Program.Settings.InputProfiles == null)
                ControlProfile.BuildDefaultProfile();
            if (Program.Settings.InputProfiles.Count == 0)
                ControlProfile.BuildDefaultProfile();

            pr_ProfileChanged(this, null);
            //Add controls
            ISC_Profiles pr = new ISC_Profiles();
            controls.Add(pr);
            pr.BeforeProfileChange += pr_BeforeProfileChange;
            pr.ProfileChanged += new EventHandler(pr_ProfileChanged);
            listBox1.Items.Add(Program.ResourceManager.GetString("Title_Profiles"));

            ISC_General gn = new ISC_General();
            controls.Add(gn);
            listBox1.Items.Add(Program.ResourceManager.GetString("Title_General"));
            gn.LoadSettings();

            ISC_Player pl = new ISC_Player(1);
            controls.Add(pl);
            listBox1.Items.Add(Program.ResourceManager.GetString("Title_Player1"));
            pl.LoadSettings();

            pl = new ISC_Player(2);
            controls.Add(pl);
            listBox1.Items.Add(Program.ResourceManager.GetString("Title_Player2"));
            pl.LoadSettings();

            pl = new ISC_Player(3);
            controls.Add(pl);
            listBox1.Items.Add(Program.ResourceManager.GetString("Title_Player3"));
            pl.LoadSettings();

            pl = new ISC_Player(4);
            controls.Add(pl);
            listBox1.Items.Add(Program.ResourceManager.GetString("Title_Player4"));
            pl.LoadSettings();

            ISC_VSUnisystem uni = new ISC_VSUnisystem();
            controls.Add(uni);
            listBox1.Items.Add(Program.ResourceManager.GetString("Title_VSUnisystemDIP"));
            uni.LoadSettings();

            listBox1.SelectedIndex = 0;
        }
        void pr_BeforeProfileChange(object sender, EventArgs e)
        {
            // Save all settings to current profile before changing ...
            foreach (InputSettingsControl con in controls)
                if (!(con is ISC_Profiles))
                    con.SaveSettings();
        }
        void pr_ProfileChanged(object sender, EventArgs e)
        {
            foreach (InputSettingsControl con in controls)
                if (!(con is ISC_Profiles))
                    con.LoadSettings();

            this.Text = Program.ResourceManager.GetString("Title_InputSettings")
                + " (" +
              Program.ResourceManager.GetString("Title_CurrentProfile")
                + ": " +
              Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Name + ")";
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
