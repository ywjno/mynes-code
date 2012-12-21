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
using SlimDX;
using SlimDX.Direct3D9;
using MyNes.Renderers;
namespace MyNes
{
    public partial class FormVideoSettings : Form
    {
        public FormVideoSettings()
        {
            Direct3D d3d = new Direct3D();
            InitializeComponent();
            //adpaters
            foreach (AdapterInformation adp in d3d.Adapters)
                comboBox_adapter.Items.Add(adp.Details.Description);

            comboBox_adapter.SelectedIndex = RenderersCore.SettingsManager.Settings.Video_AdapterIndex;
            //res
            for (int i = 0; i < d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8).Count; i++)
            {
                comboBox_fullscreenRes.Items.Add(d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].Width + " x " +
                    d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].Height + " " +
                    d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].RefreshRate + " Hz");
            }
            comboBox_fullscreenRes.SelectedIndex = RenderersCore.SettingsManager.Settings.Video_ResIndex;
            checkBox_hideLines.Checked = RenderersCore.SettingsManager.Settings.Video_HideLines;
            checkBox_imMode.Checked = RenderersCore.SettingsManager.Settings.Video_ImmediateMode;
            checkBox_fullscreen.Checked = RenderersCore.SettingsManager.Settings.Video_Fullscreen;
            //stretch
            numericUpDown1.Value = RenderersCore.SettingsManager.Settings.Video_StretchMultiply;
            //snapshot image format
            switch (RenderersCore.SettingsManager.Settings.Video_SnapshotFormat.ToLower())
            {
                case ".jpg": radioButton_jpg.Checked = true; break;
                case ".bmp": radioButton_bmp.Checked = true; break;
                case ".png": radioButton_png.Checked = true; break;
                case ".gif": radioButton_gif.Checked = true; break;
                case ".tiff": radioButton_tiff.Checked = true; break;
                case ".emf": radioButton_emf.Checked = true; break;
                case ".wmf": radioButton_wmf.Checked = true; break;
                case ".exif": radioButton_exif.Checked = true; break;
            }
        }
        //ok
        private void button1_Click(object sender, EventArgs e)
        {
            RenderersCore.SettingsManager.Settings.Video_AdapterIndex = comboBox_adapter.SelectedIndex;
            RenderersCore.SettingsManager.Settings.Video_ResIndex = comboBox_fullscreenRes.SelectedIndex;
            RenderersCore.SettingsManager.Settings.Video_HideLines = checkBox_hideLines.Checked;
            RenderersCore.SettingsManager.Settings.Video_ImmediateMode = checkBox_imMode.Checked;
            RenderersCore.SettingsManager.Settings.Video_Fullscreen = checkBox_fullscreen.Checked;
            RenderersCore.SettingsManager.Settings.Video_StretchMultiply = (int)numericUpDown1.Value;
            //snapshot image format
            if (radioButton_jpg.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".jpg";
            else if (radioButton_bmp.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".bmp";
            else if (radioButton_png.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".png";
            else if (radioButton_gif.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".gif";
            else if (radioButton_tiff.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".tiff";
            else if (radioButton_emf.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".emf";
            else if (radioButton_wmf.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".wmf";
            else if (radioButton_exif.Checked)
                RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = ".exif";
            RenderersCore.SettingsManager.SaveSettings();
            Close();
        }
        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        //defaults
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox_adapter.SelectedIndex = comboBox_fullscreenRes.SelectedIndex = 0;
            numericUpDown1.Value = 2;
            checkBox_hideLines.Checked = true;
            checkBox_imMode.Checked = true;
            checkBox_fullscreen.Checked = false;
        }
    }
}
