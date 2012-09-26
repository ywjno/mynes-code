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

namespace MyNes
{
    public partial class FormSoundSettings : Form
    {
        public FormSoundSettings()
        {
            InitializeComponent();
            //TODO: find a way to detect supported frequencies and bitdepths.
            //Add frequencies
            comboBox1.Items.Add(8000);
            comboBox1.Items.Add(11025);
            comboBox1.Items.Add(22050);
            comboBox1.Items.Add(44100);
            comboBox1.Items.Add(48000);
            comboBox1.Items.Add(56000);
            comboBox1.Items.Add(64000);
            comboBox1.Items.Add(96000);
            comboBox1.Items.Add(192000);

            comboBox_bitrate.Items.Add(8);
            comboBox_bitrate.Items.Add(16);
            comboBox_bitrate.Items.Add(24);
            comboBox_bitrate.Items.Add(32);

            checkBox_enableSound.Checked = Program.Settings.SoundEnabled;
            comboBox1.SelectedItem = Program.Settings.SoundPlaybackFreq;
            comboBox_bitrate.SelectedItem = Program.Settings.SoundPlaybackBit;
            trackBar1.Value = Program.Settings.Volume;
            label_volLevel.Text = ((((100 * (3000 - trackBar1.Value)) / 3000) - 200) * -1).ToString() + " %";
            switch (Program.Settings.SoundMixerType)
            {
                case Core.APU.ApuMixerType.Implementation: radioButton_Implementation.Checked = true; break;
                case Core.APU.ApuMixerType.LinearApproximation: radioButton_Linear.Checked = true; break;
                case Core.APU.ApuMixerType.Normal: radioButton_Normal.Checked = true; break;
            }
            trackBar_latency.Value = Program.Settings.SoundLatency / 10;
            label_latency.Text = Program.Settings.SoundLatency.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_volLevel.Text = ((((100 * (3000 - trackBar1.Value)) / 3000) - 200) * -1).ToString() + " %";
        }
        //ok
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.SoundEnabled = checkBox_enableSound.Checked;
            Program.Settings.SoundPlaybackFreq = (int)comboBox1.SelectedItem;
            Program.Settings.SoundPlaybackBit = (int)comboBox_bitrate.SelectedItem;

            if (radioButton_Implementation.Checked)
                Program.Settings.SoundMixerType = Core.APU.ApuMixerType.Implementation;
            else if (radioButton_Linear.Checked)
                Program.Settings.SoundMixerType = Core.APU.ApuMixerType.LinearApproximation;
            else if (radioButton_Normal.Checked)
                Program.Settings.SoundMixerType = Core.APU.ApuMixerType.Normal;

            Program.Settings.Volume = trackBar1.Value;
            Program.Settings.SoundLatency = (trackBar_latency.Value * 10);
            Program.Settings.Save();
            Close();
        }
        //defaults
        private void button3_Click(object sender, EventArgs e)
        {
            checkBox_enableSound.Checked = true;
            comboBox1.SelectedItem = 44100;
            comboBox_bitrate.SelectedItem = 16;
            radioButton_Implementation.Checked = true;
            trackBar1.Value = 0;
        }
        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.SelectedItem = 22050;
            comboBox_bitrate.SelectedItem = 8;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.SelectedItem = 44100;
            comboBox_bitrate.SelectedItem = 16;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.SelectedItem = 48000;
            comboBox_bitrate.SelectedItem = 16;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.SelectedItem = 48000;
            comboBox_bitrate.SelectedItem = 24;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.SelectedItem = 192000;
            comboBox_bitrate.SelectedItem = 32;
        }

        private void trackBar_latency_Scroll(object sender, EventArgs e)
        {
            label_latency.Text = (trackBar_latency.Value * 10).ToString();
        }
    }
}
