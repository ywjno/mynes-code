﻿/* This file is part of My Nes
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
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;

namespace MyNes
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            label_version.Text = "Version: " + ver.Major + "." + ver.Minor + " Build " + ver.Build;

            Assembly asm = Assembly.LoadFile
                (System.IO.Path.Combine(Application.StartupPath,
                    "NesCore.dll"));

            ver = asm.GetName().Version;

            label_coreVersion.Text = "Core version: " + ver.Major + "." + ver.Minor + " Build " + ver.Build;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
