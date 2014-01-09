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
using System.IO;
using MMB;
namespace MyNes
{
    public partial class FormPaths : Form
    {
        public FormPaths()
        {
            InitializeComponent();
            // Load
            textBox_snapshots.Text =Program.Settings.FolderSnapshots;
            textBox_state.Text = Program.Settings.FolderStates;
            textBox_sram.Text = Program.Settings.FolderSrams;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = Program.ResourceManager.GetString("Title_SnapshotsFolder");
            fol.SelectedPath = textBox_snapshots.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_snapshots.Text = fol.SelectedPath;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = Program.ResourceManager.GetString("Title_StateFolder");
            fol.SelectedPath = textBox_state.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_state.Text = fol.SelectedPath;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = Program.ResourceManager.GetString("Title_SRAMFolder");
            fol.SelectedPath = textBox_sram.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_sram.Text = fol.SelectedPath;
            }
        }
        // Cancel
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Save
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox_snapshots.Text.Length == 0 || !Directory.Exists(textBox_snapshots.Text))
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_SnapshotsFolderIsNotExist"),
                    Program.ResourceManager.GetString("MessageCaption_PathsSettings"));
                return;
            }
            if (textBox_state.Text.Length == 0 || !Directory.Exists(textBox_state.Text))
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_StatesFolderIsNotExist"),
                    Program.ResourceManager.GetString("MessageCaption_PathsSettings"));
                return;
            }
            if (textBox_sram.Text.Length == 0 || !Directory.Exists(textBox_sram.Text))
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_SRAMFolderIsNotExist"),
                    Program.ResourceManager.GetString("MessageCaption_PathsSettings"));
                return;
            }
            Program.Settings.FolderSnapshots = textBox_snapshots.Text;
            Program.Settings.FolderStates = textBox_state.Text;
            Program.Settings.FolderSrams = textBox_sram.Text;
            Program.Settings.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        // Defaults
        private void button6_Click(object sender, EventArgs e)
        {
            textBox_snapshots.Text = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\Snapshots\\";
            textBox_state.Text = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\StateSaves\\";
            textBox_sram.Text = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\SramSaves\\";
        }
    }
}
