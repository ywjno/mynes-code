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
    public partial class FormSoundSettings : Form
    {
        public FormSoundSettings()
        {
            InitializeComponent();
            //TODO: find a way to detect supported frequencies and bitdepths.
            //Add frequencies
            comboBox1.Items.Add(44100);
            comboBox1.Items.Add(48000);

            checkBox_enableSound.Checked = RenderersCore.SettingsManager.Settings.Sound_Enabled;
            comboBox1.SelectedItem = RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq;
            trackBar1.Value = RenderersCore.SettingsManager.Settings.Sound_Volume;
            label_volLevel.Text = ((((100 * (3000 - trackBar1.Value)) / 3000) - 200) * -1).ToString() + " %";

            trackBar_latency.Value = RenderersCore.SettingsManager.Settings.Sound_Latency / 10;
            label_latency.Text = RenderersCore.SettingsManager.Settings.Sound_Latency.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_volLevel.Text = ((((100 * (3000 - trackBar1.Value)) / 3000) - 200) * -1).ToString() + " %";
        }
        //ok
        private void button1_Click(object sender, EventArgs e)
        {
            RenderersCore.SettingsManager.Settings.Sound_Enabled = checkBox_enableSound.Checked;
            RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq = (int)comboBox1.SelectedItem;

            RenderersCore.SettingsManager.Settings.Sound_Volume = trackBar1.Value;
            RenderersCore.SettingsManager.Settings.Sound_Latency = (trackBar_latency.Value * 10);
            RenderersCore.SettingsManager.SaveSettings();
            Close();
        }
        //defaults
        private void button3_Click(object sender, EventArgs e)
        {
            checkBox_enableSound.Checked = true;
            comboBox1.SelectedItem = 44100;
            trackBar1.Value = 0;
        }
        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trackBar_latency_Scroll(object sender, EventArgs e)
        {
            label_latency.Text = (trackBar_latency.Value * 10).ToString();
        }
    }
}
