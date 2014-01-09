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
using SlimDX;
using SlimDX.Direct3D9;
namespace MyNes
{
    public partial class FormVideoSettings : Form
    {
        public FormVideoSettings()
        {
            InitializeComponent();
            // Fill fullscreen res
            //res
            Direct3D d3d = new Direct3D();
            comboBox_fullscreenRes.Items.Clear();
            for (int i = 0; i < d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8).Count; i++)
            {
                comboBox_fullscreenRes.Items.Add(d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].Width + " x " +
                    d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].Height + " " +
                    d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].RefreshRate + " Hz");
            }
            // Load settings
            checkBox_fullscreen.Checked = Program.Settings.VideoLaunchFullscreen;
            checkBox_hideLines.Checked = Program.Settings.VideoCutLines;
            checkBox_immediateMode.Checked = Program.Settings.VideoImmediateMode;
            checkBox_keepAspectRatio.Checked = Program.Settings.VideoKeepAspectRatio;
            checkBox_showFps.Checked = Program.Settings.VideoShowFPS;
            checkBox_showNot.Checked = Program.Settings.VideoShowNotifications;
            comboBox_fullscreenRes.SelectedIndex = Program.Settings.VideoFullscreenResIndex;
            switch (Program.Settings.VideoOutputMode)
            {
                case VideoOutputMode.DirectX9: comboBox_mode.SelectedIndex = 0; break;
            }
            comboBox_snapshotFormat.SelectedItem = Program.Settings.SnapshotsFormat;
            comboBox_windowSize.SelectedIndex = Program.Settings.VideoWindowStretchMultiply - 1;
            checkBox_stretchWindow.Checked = Program.Settings.VideoStretchWindowToFitSize;
        }
        // Mode settings
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_mode.SelectedIndex == 0)
            {
                FormSlimDXSettings frm = new FormSlimDXSettings();
                frm.ShowDialog(this);
            }
        }
        // Cancel
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Save
        private void button2_Click(object sender, EventArgs e)
        {
            Program.Settings.VideoLaunchFullscreen = checkBox_fullscreen.Checked;
            Program.Settings.VideoCutLines = checkBox_hideLines.Checked;
            Program.Settings.VideoImmediateMode = checkBox_immediateMode.Checked;
            Program.Settings.VideoKeepAspectRatio = checkBox_keepAspectRatio.Checked;
            Program.Settings.VideoShowFPS = checkBox_showFps.Checked;
            Program.Settings.VideoShowNotifications = checkBox_showNot.Checked;
            Program.Settings.VideoFullscreenResIndex = comboBox_fullscreenRes.SelectedIndex;
            switch (comboBox_mode.SelectedIndex)
            {
                case 0: Program.Settings.VideoOutputMode = VideoOutputMode.DirectX9; break;
            }
            Program.Settings.SnapshotsFormat = comboBox_snapshotFormat.SelectedItem.ToString();
            Program.Settings.VideoWindowStretchMultiply = comboBox_windowSize.SelectedIndex + 1;
            Program.Settings.VideoStretchWindowToFitSize = checkBox_stretchWindow.Checked;
            Program.Settings.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        // Defaults
        private void button4_Click(object sender, EventArgs e)
        {
            checkBox_fullscreen.Checked = false;
            checkBox_hideLines.Checked = true;
            checkBox_immediateMode.Checked = true;
            checkBox_keepAspectRatio.Checked = true;
            checkBox_showFps.Checked = false;
            checkBox_showNot.Checked = true;
            comboBox_fullscreenRes.SelectedIndex = 0;
            comboBox_mode.SelectedIndex = 0;
            comboBox_windowSize.SelectedIndex = 1;
            checkBox_stretchWindow.Checked = true;
            comboBox_snapshotFormat.SelectedItem = ".png";
        }
    }
}
