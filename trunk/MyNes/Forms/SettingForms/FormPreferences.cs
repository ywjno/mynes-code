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
    public partial class FormPreferences : Form
    {
        public FormPreferences()
        {
            InitializeComponent();
            // Load
            checkBox_autoMinimizeBrowser.Checked = Program.Settings.BrowserMinimizeWindowOnRomLoad;
            checkBox_saveSram.Checked = Program.Settings.SaveSRAMOnShutdown;
            checkBox_pauseEmu.Checked = Program.Settings.MainWindowAutoPauseOnFocusLost;
            checkBox_autoHideMouse.Checked = Program.Settings.AutoHideMouse;
            numericUpDown_autohideCursorPeriod.Value = Program.Settings.AutoHideMousePeriod;
        }
        // Defaults
        private void button3_Click(object sender, EventArgs e)
        {
            checkBox_autoMinimizeBrowser.Checked = true;
            checkBox_saveSram.Checked = true;
            checkBox_pauseEmu.Checked = true;
            checkBox_autoHideMouse.Checked = true;
            numericUpDown_autohideCursorPeriod.Value = 2;
        }
        // Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Save
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.MainWindowAutoPauseOnFocusLost = checkBox_pauseEmu.Checked;
            Program.Settings.BrowserMinimizeWindowOnRomLoad = checkBox_autoMinimizeBrowser.Checked;
            Program.Settings.SaveSRAMOnShutdown = checkBox_saveSram.Checked;
            Program.Settings.AutoHideMouse = checkBox_autoHideMouse.Checked;
            Program.Settings.AutoHideMousePeriod = (int)numericUpDown_autohideCursorPeriod.Value;
            Program.Settings.Save();

            Close();
        }
    }
}
