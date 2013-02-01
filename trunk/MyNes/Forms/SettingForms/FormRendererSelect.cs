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
namespace MyNes
{
    public partial class FormRendererSelect : Form
    {
        public FormRendererSelect()
        {
            InitializeComponent();
            // fill renderers
            foreach (IRenderer renderer in RenderersCore.AvailableRenderers)
                comboBox1.Items.Add(renderer.Name);
            // select the chosen one
            if (Program.Settings.CurrentRendererIndex < comboBox1.Items.Count)
                comboBox1.SelectedIndex = Program.Settings.CurrentRendererIndex;
        }
        // ok
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.CurrentRendererIndex = comboBox1.SelectedIndex;
            Program.Settings.Save();
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < RenderersCore.AvailableRenderers.Length)
                richTextBox1.Text = RenderersCore.AvailableRenderers[comboBox1.SelectedIndex].Description;
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try { System.Diagnostics.Process.Start(e.LinkText); }
            catch { }
        }
    }
}
