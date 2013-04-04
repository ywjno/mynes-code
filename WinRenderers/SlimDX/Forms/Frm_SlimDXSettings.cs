/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
namespace MyNes.WinRenderers
{
    public partial class Frm_SlimDXSettings : Form
    {
        public Frm_SlimDXSettings()
        {
            InitializeComponent();
            // load settings
            if (SlimDXRenderer.Settings == null)
            {
                object settingsObject = SettingsManager.LoadSettingsObject("slimdxconfig", typeof(SlimDXSettings));
                if (settingsObject != null)
                    SlimDXRenderer.Settings = (SlimDXSettings)settingsObject;
                else
                    SlimDXRenderer.Settings = new SlimDXSettings();
            }
            switch (SlimDXRenderer.Settings.Video_TextureFilter)
            { 
                case SlimDX.Direct3D9.TextureFilter.None:
                    comboBox_filter.SelectedIndex = 0;
                    break;
                case SlimDX.Direct3D9.TextureFilter.Linear:
                    comboBox_filter.SelectedIndex = 1;
                    break;
                case SlimDX.Direct3D9.TextureFilter.Point:
                    comboBox_filter.SelectedIndex = 2;
                    break;
            }

            comboBox_VertexProcessing.SelectedIndex = SlimDXRenderer.Settings.Video_IsHardwareVertexProcessing ? 1 : 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save settings
            switch (comboBox_filter.SelectedIndex)
            {
                case 0: SlimDXRenderer.Settings.Video_TextureFilter = SlimDX.Direct3D9.TextureFilter.None; break;
                case 1: SlimDXRenderer.Settings.Video_TextureFilter = SlimDX.Direct3D9.TextureFilter.Linear; break;
                case 2: SlimDXRenderer.Settings.Video_TextureFilter = SlimDX.Direct3D9.TextureFilter.Point; break;
            }

            SlimDXRenderer.Settings.Video_IsHardwareVertexProcessing = comboBox_VertexProcessing.SelectedIndex == 1;
            SettingsManager.SaveSettingsObject("slimdxconfig", SlimDXRenderer.Settings);
            Close();
        }
    }
}
