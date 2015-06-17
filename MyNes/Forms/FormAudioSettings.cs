/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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

namespace MyNes
{
    public partial class FormAudioSettings : Form
    {
        public FormAudioSettings()
        {
            InitializeComponent();
            radioButton1_sound_enabled.Checked = Program.Settings.Audio_SoundEnabled;
            trackBar2.Value = Program.Settings.Audio_Volume;

            //trackBar_bufferLength.Value = Program.Settings.Audio_BufferSizeInBytes / 100;
            int val = Program.Settings.Audio_BufferSizeInBytes / 1024;
            switch (val)
            {
                case 8: radioButton_size_8kb.Checked = true; break;
                case 16: radioButton_size_16kb.Checked = true; break;
            }
            trackBar_latency.Value = Program.Settings.Audio_LatencyInPrecentage;
            trackBar1_Scroll(this, null);
            label_volume.Text = trackBar2.Value + "%";
            // label_bufferLength.Text = (trackBar_bufferLength.Value / 10).ToString() + "." + (trackBar_bufferLength.Value % 10);

            checkBox_dmc.Checked = Program.Settings.AudioChannelDMCEnabled;
            checkBox_noize.Checked = Program.Settings.AudioChannelNOZEnabled;
            checkBox_sq1.Checked = Program.Settings.AudioChannelSQ1Enabled;
            checkBox_sq2.Checked = Program.Settings.AudioChannelSQ2Enabled;
            checkBox_triangle.Checked = Program.Settings.AudioChannelTRLEnabled;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // OK
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.Audio_SoundEnabled = radioButton1_sound_enabled.Checked;

            Program.Settings.Audio_Volume = trackBar2.Value;
            if (radioButton_size_8kb.Checked)
                Program.Settings.Audio_BufferSizeInBytes = 1024 * 8;
            if (radioButton_size_16kb.Checked)
                Program.Settings.Audio_BufferSizeInBytes = 1024 * 16;

            Program.Settings.Audio_LatencyInPrecentage = trackBar_latency.Value;
            Program.Settings.AudioChannelDMCEnabled = checkBox_dmc.Checked;
            Program.Settings.AudioChannelNOZEnabled = checkBox_noize.Checked;
            Program.Settings.AudioChannelSQ1Enabled = checkBox_sq1.Checked;
            Program.Settings.AudioChannelSQ2Enabled = checkBox_sq2.Checked;
            Program.Settings.AudioChannelTRLEnabled = checkBox_triangle.Checked;
            Program.Settings.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label_volume.Text = trackBar2.Value + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1_sound_enabled.Checked = true;
            trackBar2.Value = 100;
            trackBar_latency.Value = 53;
            radioButton_size_8kb.Checked = true;
            label_volume.Text = trackBar2.Value + "%";

            checkBox_dmc.Checked = true;
            checkBox_noize.Checked = true;
            checkBox_sq1.Checked = true;
            checkBox_sq2.Checked = true;
            checkBox_triangle.Checked = true;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            checkBox_dmc.Checked = true;
            checkBox_noize.Checked = true;
            checkBox_sq1.Checked = true;
            checkBox_sq2.Checked = true;
            checkBox_triangle.Checked = true;
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            checkBox_dmc.Checked = false;
            checkBox_noize.Checked = false;
            checkBox_sq1.Checked = false;
            checkBox_sq2.Checked = false;
            checkBox_triangle.Checked = false;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_latency.Text = trackBar_latency.Value.ToString() + "%";
        }
    }
}
