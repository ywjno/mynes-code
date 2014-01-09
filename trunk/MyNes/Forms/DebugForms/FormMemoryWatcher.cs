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
using MyNes.Core;
namespace MyNes
{
    public partial class FormMemoryWatcher : Form
    {
        public FormMemoryWatcher()
        {
            InitializeComponent();
            this.Tag = "Memory";
            UpdateScroll(true);
        }
        private string currentTooltip = "";
        private void UpdateScroll(bool reset)
        {
            if (radioButton_WRAM.Checked)
            {
                memoryWathcerPanel1.memOffset = 0x0000;
                memoryWathcerPanel1.max = 0x800;
                vScrollBar1.Maximum = 0x800 / 16;
                if (reset)
                    memoryWathcerPanel1.scroll = vScrollBar1.Value = 0;
            }
            else if (radioButton_SRAM.Checked)
            {
                memoryWathcerPanel1.memOffset = 0x6000;
                memoryWathcerPanel1.max = 0x2000;
                vScrollBar1.Maximum = 0x2000 / 16;
                if (reset)
                    memoryWathcerPanel1.scroll = vScrollBar1.Value = 0;
            }
            else if (radioButton_prg.Checked)
            {
                memoryWathcerPanel1.memOffset = 0x8000;
                memoryWathcerPanel1.max = 0x8000;
                vScrollBar1.Maximum = 0x8000 / 16;
                if (reset)
                    memoryWathcerPanel1.scroll = vScrollBar1.Value = 0;
            }
        }

        private void Form_MemoryWatcher_Resize(object sender, EventArgs e)
        {
            UpdateScroll(false); 
            memoryWathcerPanel1.Invalidate();
        }
        private void radioButton_WRAM_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScroll(true);
            memoryWathcerPanel1.Invalidate();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            memoryWathcerPanel1.scroll = vScrollBar1.Value;
            memoryWathcerPanel1.Invalidate();
        }
        private void radioButton_SRAM_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScroll(true);
            memoryWathcerPanel1.Invalidate();
        }
        private void panel_surface_MouseMove(object sender, MouseEventArgs e)
        {
            string t = memoryWathcerPanel1.GetAddressOnPoint(e.Location);
            if (t != currentTooltip)
                toolTip1.SetToolTip(memoryWathcerPanel1, t);
            currentTooltip = t;
        }
        private void memoryWathcerPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            string t = memoryWathcerPanel1.GetAddressOnPoint(e.Location);
            if (t != currentTooltip)
                toolTip1.SetToolTip(memoryWathcerPanel1, t);
            currentTooltip = t;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            memoryWathcerPanel1.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
                button1.FlatStyle = FlatStyle.Flat;
                button1.ForeColor = Color.Green;
            }
            else
            {
                timer1.Stop();
                button1.FlatStyle = FlatStyle.Standard;
                button1.ForeColor = Color.Black;
            }
        }
        private void radioButton_prg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScroll(true);
            memoryWathcerPanel1.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            memoryWathcerPanel1.Invalidate();
        }
    }
}
