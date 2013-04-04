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
    public partial class FormPathSettings : Form
    {
        public FormPathSettings()
        {
            InitializeComponent();

            textBox_snapshots.Text = RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder;
            textBox_statesFolder.Text = RenderersCore.SettingsManager.Settings.Folders_StateFolder;
            textBox_browserDatabase.Text = Program.Settings.FoldersDatabasePath;
        }
        private bool refreshBrowser = false;

        public bool RefreshBrowser
        { get { return refreshBrowser; } }
        //save and close
        private void button3_Click(object sender, EventArgs e)
        {
            RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder = textBox_snapshots.Text;
            RenderersCore.SettingsManager.Settings.Folders_StateFolder = textBox_statesFolder.Text;
            Program.Settings.FoldersDatabasePath = textBox_browserDatabase.Text;
            RenderersCore.SettingsManager.SaveSettings();
            Program.Settings.Save();
            // create directories
            System.IO.Directory.CreateDirectory(textBox_snapshots.Text);
            System.IO.Directory.CreateDirectory(textBox_statesFolder.Text);
            Close();
        }
        //cancel
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        //defaults
        private void button5_Click(object sender, EventArgs e)
        {
            textBox_snapshots.Text = System.IO.Path.GetFullPath(@".\Snapshots");
            textBox_statesFolder.Text = System.IO.Path.GetFullPath(@".\StateSaves");
            textBox_browserDatabase.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\folders.fl";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = "Browse for state saves folder";
            fol.SelectedPath = textBox_statesFolder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                textBox_statesFolder.Text = fol.SelectedPath;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = "Browse for snapshots folder";
            fol.SelectedPath = textBox_snapshots.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                textBox_snapshots.Text = fol.SelectedPath;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open MyNes folders database";
            op.Filter = "MyNes folders database (*.fl)|*.fl";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                refreshBrowser = true;
                textBox_browserDatabase.Text = op.FileName;
            }
        }
    }
}
