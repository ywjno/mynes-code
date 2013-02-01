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
using System.IO;
using System.Windows.Forms;
using System.Threading;
namespace MyNes
{
    public partial class FormDetectImages : Form
    {
        public FormDetectImages(BFolder bfolder, DetectorDetectMode mode)
        {
            InitializeComponent();
            this.bfolder = bfolder;
            this.mode = mode;
            switch (mode)
            {
                case DetectorDetectMode.Covers: this.Text = "Detect Covers"; break;
                case DetectorDetectMode.Snapshots: this.Text = "Detect Snapshots"; break;
                case DetectorDetectMode.InfoTexts: this.Text = "Detect Info Texts"; break;
            }
        }
        private DetectorDetectMode mode;
        private BFolder bfolder;
        private Thread mainThread;
        private bool progresDone = false;
        private bool includeSubFolders = false;
        private bool caseSensitive = false;
        private bool matchFileName = false;
        private int currentPrec = 0;
        private string currentStatus = "";
        private string GetString(string[] lines)
        {
            string value = "";
            foreach (string line in lines)
                value += line + "\n";
            return value;
        }
        private void DONE()
        {
            if (!this.InvokeRequired)
                DONE1();
            else
                this.Invoke(new Action(DONE1));
        }
        private void DONE1()
        {
            progresDone = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        private void Progress()
        {
            currentStatus = "Calculating ...";
            currentPrec = 0;
            //add files
            List<string> folders = new List<string>();
            foreach (string folder in listBox1.Items)
            {
                folders.Add(folder);
            }
            List<string> files = new List<string>();
            foreach (string folder in folders)
            {
                if (includeSubFolders)
                    files.AddRange(Directory.GetFiles(folder, "*", SearchOption.AllDirectories));
                else
                    files.AddRange(Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly));
            }
            //do the detect, loop through roms and detect the files depending on the extensions
            int i = 0;
            string[] extensions = new string[] { ".jpg", ".bmp", ".png", ".gif", ".tiff", ".emf", ".wmf", ".exif" };
            if (mode == DetectorDetectMode.InfoTexts)
                extensions = new string[] { ".txt" };
            foreach (BRom rom in bfolder.BRoms)
            {
                // loop through files
                foreach (string file in files)
                {
                    if (!extensions.Contains(Path.GetExtension(file).ToLower()))
                        continue;
                    string imageFileName = Path.GetFileNameWithoutExtension(file);
                    string romFileName = Path.GetFileNameWithoutExtension(rom.Path);
                    bool thisIsIt = false;
                    //case sensitive ?
                    if (!caseSensitive)
                    {
                        imageFileName = imageFileName.ToLower();
                        romFileName = romFileName.ToLower();
                    }
                    //the match
                    if (matchFileName)
                    {
                        if (imageFileName == romFileName)
                            thisIsIt = true;
                    }
                    else
                        if (imageFileName.Contains(romFileName))
                            thisIsIt = true;
                    if (thisIsIt)
                    {
                        //now add the image/text info to the item
                        switch (mode)
                        {
                            case DetectorDetectMode.Covers: rom.CoverPath = file; break;
                            case DetectorDetectMode.Snapshots: rom.SnapshotPath = file; break;
                            case DetectorDetectMode.InfoTexts: rom.InfoText = GetString(File.ReadAllLines(file)); break;
                        }
                        //remove the file for turbo !?
                        files.Remove(file);
                        break;
                    }
                }
                //set progress bar info
                currentPrec = (i * 100) / bfolder.BRoms.Count;
                currentStatus = "Detecting " + (i + 1).ToString() + "/" + bfolder.BRoms.Count + " (" + currentPrec + "%)";
                i++;
            }
            DONE();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (!listBox1.Items.Contains(folder.SelectedPath))
                    listBox1.Items.Add(folder.SelectedPath);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        //ok
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select folder first");
                return;
            }
            //get options
            includeSubFolders = checkBox_includeSubfolders.Checked;
            caseSensitive = checkBox_caseSensitive.Checked;
            matchFileName = checkBox_matchFileName.Checked;
            //enable and disable things
            status_label1.Visible = progressBar1.Visible = true;
            button3.Enabled = button4.Enabled = groupBox1.Enabled = groupBox2.Enabled = false;
            //start
            timer1.Start();
            mainThread = new Thread(new ThreadStart(Progress));
            mainThread.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            status_label1.Text = currentStatus;
            progressBar1.Value = currentPrec;
        }
    }
    public enum DetectorDetectMode
    { Snapshots, Covers, InfoTexts }
}
