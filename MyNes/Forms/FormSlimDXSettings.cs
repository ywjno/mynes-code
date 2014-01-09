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
using SlimDX.Direct3D9;
namespace MyNes
{
    public partial class FormSlimDXSettings : Form
    {
        public FormSlimDXSettings()
        {
            InitializeComponent();

            switch (Program.Settings.VideoDirect9Filter)
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

            comboBox_VertexProcessing.SelectedIndex = Program.Settings.VideoDirect9IsHardwareVertexProcessing ? 1 : 0;
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
                case 0: Program.Settings.VideoDirect9Filter = TextureFilter.None; break;
                case 1: Program.Settings.VideoDirect9Filter = TextureFilter.Linear; break;
                case 2: Program.Settings.VideoDirect9Filter = TextureFilter.Point; break;
            }

            Program.Settings.VideoDirect9IsHardwareVertexProcessing = comboBox_VertexProcessing.SelectedIndex == 1;
            Close();
        }
    }
}
