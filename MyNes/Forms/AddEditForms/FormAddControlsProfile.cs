﻿/* This file is part of My Nes
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
    public partial class FormAddControlsProfile : Form
    {
        public FormAddControlsProfile()
        {
            InitializeComponent();
            foreach (ControlProfile profile in RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection)
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
