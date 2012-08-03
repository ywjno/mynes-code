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
using MyNes.Core;

namespace MyNes
{
    public partial class Frm_Console : Form
    {
        public Frm_Console()
        {
            InitializeComponent();
            LoadSettings();
            //add default commands
            ConsoleCommands.AddDefaultCommands();
        }

        void LoadSettings()
        {
            this.Location = Program.Settings.console_location;
            this.Size = Program.Settings.console_size;
        }
        void SaveSettings()
        {
            Program.Settings.console_location = this.Location;
            Program.Settings.console_size = this.Size;
        }
        void UpdateVscroll()
        {
            if (consolePanel1.StringHeight < consolePanel1.Height)
            {
                vScrollBar1.Maximum = 1;
                vScrollBar1.Value = 0;
                vScrollBar1.Enabled = false;
                consolePanel1.ScrollOffset = 0;
            }
            else
            {
                vScrollBar1.Enabled = true;
                vScrollBar1.Maximum = consolePanel1.StringHeight - consolePanel1.Height + 15;
                vScrollBar1.Value = vScrollBar1.Maximum - 1;
                consolePanel1.ScrollOffset = vScrollBar1.Value;
            }
            consolePanel1.Invalidate();
        }

        void ExecuteCommand()
        {
            if (!this.InvokeRequired)
            {
                this.DoCommand();
            }
            else
            {
                this.Invoke(new CONSOLE.WriteDebugLineDelegate(DoCommand));
            }
        }
        void DoCommand()
        {
            //refresh commands list
            if (!comboBox1.Items.Contains(comboBox1.Text))
                comboBox1.Items.Add(comboBox1.Text);
            //detect command
            bool found = false;
            bool showCommandHelp = false;
            string[] code = comboBox1.Text.Split(new char[] { ' ' });
            foreach (ConsoleCommand command in ConsoleCommands.AvailableCommands)
            {
                if (command.Method == code[0])
                {
                    if (command.Parameters.Length == 0 && code.Length > 1)
                    {
                        CONSOLE.WriteLine("] " + comboBox1.Text + ": THIS COMAND HAS NO PARAMETER", DebugCode.Warning);
                        showCommandHelp = true;
                    }
                    else if (command.Parameters.Length > 0 && code.Length == 1)
                    {
                        CONSOLE.WriteLine("] " + comboBox1.Text + ": THIS COMAND HAVE PARAMETERS AND NO PARAMETER PASSED", DebugCode.Error);
                        showCommandHelp = true;
                    }
                    else
                    {
                        CONSOLE.WriteLine("] " + comboBox1.Text);
                        command.Execute(comboBox1.Text);
                    }
                    found = true;
                    if (showCommandHelp)
                    {
                        string line = "> " + command.Method + " ";
                        foreach (string par in command.Parameters)
                            line += par + " ";
                        line += command.Description;
                        CONSOLE.WriteLine("HELP:" + line);
                    }
                    break;
                }
            }
            if (!found)
            {
                CONSOLE.WriteLine("] " + comboBox1.Text + ": COMMAND NOT FOUND", DebugCode.Error);
            }
        }

        private void consolePanel1_DebugLinesUpdated(object sender, EventArgs e)
        {
            UpdateVscroll();
        }
        private void Frm_Console_Resize(object sender, EventArgs e)
        {
            UpdateVscroll();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            consolePanel1.ScrollOffset = vScrollBar1.Value;
            consolePanel1.Invalidate();
        }
        private void Frm_Console_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteCommand();
        }
        private void Frm_Console_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                ExecuteCommand();
        }
    }
}
