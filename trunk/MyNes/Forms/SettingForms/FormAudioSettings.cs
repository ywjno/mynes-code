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

namespace MyNes
{
    public partial class FormAudioSettings : Form
    {
        public FormAudioSettings()
        {
            InitializeComponent();
            // Frequencies
            comboBox_freq.Items.Add(44100);
            comboBox_freq.Items.Add(48000);
            comboBox_freq.Items.Add(88200);
            comboBox_freq.Items.Add(96000);
            // Bits
            comboBox_bits.Items.Add((short)8);
            comboBox_bits.Items.Add((short)16);
            comboBox_bits.Items.Add((short)32);
            // Load settings
            switch (Program.Settings.AudioOutputMode)
            {
                case SoundOutputMode.DirectSound: comboBox_renderer.SelectedIndex = 0; break;
            }
            checkBox_soundEnable.Checked = Program.Settings.AudioSoundEnabled;
            trackBar_latency.Value = Program.Settings.AudioLatency;
            trackBar_volume.Value = Program.Settings.AudioVolume;
            comboBox_bits.SelectedItem = Program.Settings.AudioBitsPerSample;
            comboBox_freq.SelectedItem = Program.Settings.AudioFrequency;
            switch (Program.Settings.AudioChannelsCount)
            {
                case 1: radioButton_mono.Checked = true; radioButton_stereo.Checked = false; break;
                case 2: radioButton_mono.Checked = false; radioButton_stereo.Checked = true; break;
            }
            // Apply
            trackBar_volume_Scroll(this, null);
            trackBar_latency_Scroll(this, null);
        }
        private void trackBar_volume_Scroll(object sender, EventArgs e)
        {
            label_volumeLevel.Text = trackBar_volume.Value + "%";
        }
        private void trackBar_latency_Scroll(object sender, EventArgs e)
        {
            label_latency.Text = trackBar_latency.Value + " Milliseconds";
        }
        // Defaults
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox_renderer.SelectedIndex = 0;
            comboBox_freq.SelectedItem = 44100;
            comboBox_bits.SelectedItem = 16;
            trackBar_latency.Value = 100;
            trackBar_volume.Value = 85;
            radioButton_mono.Checked = true;
            radioButton_stereo.Checked = false;
        }
        // Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Save
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox_renderer.SelectedIndex)
            {
                case 0: Program.Settings.AudioOutputMode = SoundOutputMode.DirectSound; break;
            }
            Program.Settings.AudioSoundEnabled = checkBox_soundEnable.Checked;
            Program.Settings.AudioLatency = trackBar_latency.Value;
            Program.Settings.AudioVolume = trackBar_volume.Value;
            Program.Settings.AudioBitsPerSample = (short)comboBox_bits.SelectedItem;
            Program.Settings.AudioFrequency = (int)comboBox_freq.SelectedItem;
            if (radioButton_mono.Checked)
            {
                Program.Settings.AudioChannelsCount = 1;
            }
            else
            {
                Program.Settings.AudioChannelsCount = 2;
            }
            Program.Settings.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
