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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyNes.Core.ROM;
using MyNes.Core.Database;
using MLV;
using Console = MyNes.Core.Console;

namespace MyNes
{
    public partial class FormINESFilesFixer : Form
    {
        public FormINESFilesFixer()
        {
            InitializeComponent();
            InitializeListView();
        }
        public FormINESFilesFixer(string[] files)
        {
            InitializeComponent();
            InitializeListView();
            foreach (string file in files)
                if (Path.GetExtension(file).ToLower() == ".nes")
                    AddFile(file);
        }
        private Thread mainThread;
        private string _databasePath = "";
        private string _targetFolder = "";
        private bool _fixMapper = false;
        private bool _fixChr = false;
        private bool _fixPrg = false;
        private bool _fixTv = false;
        private bool _replaceSameRom = false;
        private bool _move;
        private List<string> files = new List<string>();
        private NesDatabaseObject dbo;
        private int progress = 0;
        private string status = "";

        private void PROGRESS()
        {
            Console.WriteLine(status = "Starting fix progress ....");
            // read database
            Console.WriteLine("Reading the database...");
            dbo = new NesDatabaseObject();
            dbo.LoadDatabase(_databasePath);
            Console.WriteLine("Database OK.", Core.DebugCode.Good);
            // fix roms
            Console.WriteLine("Fixing roms...");
            int i = 0;
            foreach (string file in files)
            {
                // look inside database for this file
                RomInfo info = new RomInfo(file, dbo);
                if (info.DatabaseGameInfo.Game_Name != null)
                {
                    // read the header
                    INESHeader header = new INESHeader(file);

                    if (header.IsValid)
                    {
                        // now make fixes
                        if (_fixChr)
                        {
                            if (info.DatabaseGameInfo.CHR_size != null
                                &&  info.DatabaseGameInfo.CHR_size != "")
                            {
                                string size = info.DatabaseGameInfo.CHR_size.Replace("k", "");
                                int siz = int.Parse(size);
                                header.ChrPages = (byte)(siz / 8);
                            }
                            else
                            {
                                header.ChrPages = 0;
                            }
                        }
                        if (_fixMapper)
                        {
                            header.Mapper = byte.Parse(info.DatabaseGameInfo.Board_Mapper);
                        }
                        if (_fixPrg)
                        {
                            if (info.DatabaseGameInfo.PRG_size != "")
                            {
                                string size = info.DatabaseGameInfo.PRG_size.Replace("k", "");
                                int siz = int.Parse(size);
                                header.PrgPages = (byte)(siz / 16);
                            }
                            else
                            {
                                header.PrgPages = 0;
                            }
                        }
                        if (_fixTv)
                        {
                            if (info.DatabaseCartInfo.System != null)
                            {
                                if (info.DatabaseCartInfo.System.ToUpper().Contains("PAL"))
                                    header.TVSystem = INESRVSystem.PAL;
                                else
                                    header.TVSystem = INESRVSystem.NTSC;
                            }
                        }
                        // save the file.
                        if (_replaceSameRom)
                        {
                            header.SaveFile(file);
                            Console.WriteLine("Rom fixed: " + file, Core.DebugCode.Good);
                        }
                        else
                        {
                            header.SaveAs(file, _targetFolder + "\\" + Path.GetFileName(file));
                            if (_move)
                            {
                                try
                                {
                                    File.Delete(file);
                                }
                                catch (Exception ex) { Console.WriteLine("Can't move file: " + file + " [" + ex.Message + "]"); }
                            }
                            Console.WriteLine("Rom fixed: " + file, Core.DebugCode.Good);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Rom skipped, can't read the header: " + file, Core.DebugCode.Error);
                    }
                }
                else// drop the file.
                {
                    Console.WriteLine("Rom skipped, can't be found at the database: " + file, Core.DebugCode.Warning);
                }
                progress = (i * 100) / files.Count;
                status = "Fixing .... " + progress + " %";
                i++;
            }
            Console.WriteLine("Done. Type 'save' to save log.");
            Done();
        }
        private void Done()
        {
            if (!this.InvokeRequired)
                Done1();
            else
                this.Invoke(new Action(Done1));
        }
        private void Done1()
        {
            textBox_MoveToFolder.Enabled = textBox1.Enabled = true;
            managedListView1.Enabled = true;
            button_start.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button6.Enabled = true;
            radioButton_replaceFile.Enabled = radioButton1.Enabled = true;
            checkBox_fixChr.Enabled = checkBox_FixMapper.Enabled = checkBox_fixPrg.Enabled
                = checkBox_fixTv.Enabled = checkBox1.Enabled = true;
            timer1.Stop();

            progressBar1.Value = 100;
            label_status.Text = "Done.";
        }
        private void InitializeListView()
        {
            textBox1.Text = Path.GetFullPath(".\\database.xml");
            ManagedListViewColumn column = new ManagedListViewColumn();
            column.HeaderText = "Name";
            column.ID = "name";
            column.Width = 120;
            managedListView1.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Size";
            column.ID = "size";
            column.Width = 70;
            managedListView1.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Path";
            column.ID = "path";
            column.Width = 200;
            managedListView1.Columns.Add(column);
        }
        private void AddFile(string FilePath)
        {
            ManagedListViewItem item = new ManagedListViewItem();

            ManagedListViewSubItem subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "name";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = Path.GetFileName(FilePath);
            item.SubItems.Add(subitem);

            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "size";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = Helper.GetFileSize(FilePath);
            item.SubItems.Add(subitem);

            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "path";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = FilePath;
            item.SubItems.Add(subitem);

            managedListView1.Items.Add(item);
        }
        // add files
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "INES rom (*.nes)|*.nes";
            op.Title = "Add INES files";
            op.Multiselect = true;
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in op.FileNames)
                {
                    bool exist = false;
                    foreach (ManagedListViewItem item in managedListView1.Items)
                    {
                        if (item.GetSubItemByID("path").Text == file)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                        AddFile(file);
                }
            }
        }
        // remove selected items
        private void button2_Click(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you usre ?", "Remove selected roms from the list",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < managedListView1.SelectedItems.Count; i++)
                    {
                        managedListView1.Items.Remove(managedListView1.SelectedItems[i]);
                        i--;
                    }
                }
            }
        }
        // change database
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "NoCart DB Database File (*.xml)|*.xml";
            op.Title = "Open database file";
            op.FileName = textBox1.Text;
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = op.FileName;
            }
        }
        // change folder
        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Browse for folder";
            folder.ShowNewFolderButton = true;
            folder.SelectedPath = textBox_MoveToFolder.Text;
            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_MoveToFolder.Text = folder.SelectedPath;
            }
        }
        // start
        private void button4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("The database file is not exist.");
                return;
            }
            if (!radioButton_replaceFile.Checked)
            {
                if (!Directory.Exists(textBox_MoveToFolder.Text))
                {
                    MessageBox.Show("The target folder is not exist.");
                    return;
                }
            }
            if (managedListView1.Items.Count == 0)
            {
                MessageBox.Show("There is no file to fix !");
                return;
            }
            if (!checkBox_fixChr.Checked && !checkBox_FixMapper.Checked &&
                !checkBox_fixPrg.Checked && !checkBox_fixTv.Checked)
            {
                MessageBox.Show("Nothing to fix !! Please select one fix option at least.");
                return;
            }
            // options
            _databasePath = textBox1.Text;
            _targetFolder = textBox_MoveToFolder.Text;
            _fixMapper = checkBox_FixMapper.Checked;
            _fixChr = checkBox_fixChr.Checked;
            _fixPrg = checkBox_fixPrg.Checked;
            _fixTv = checkBox_fixTv.Checked;
            _replaceSameRom = radioButton_replaceFile.Checked;
            _move = checkBox1.Checked;
            files = new List<string>();
            foreach (ManagedListViewItem item in managedListView1.Items)
            {
                files.Add(item.GetSubItemByID("path").Text);
            }
            progressBar1.Visible = label_status.Visible = true;
            button_close.Text = "&Cancel";
            timer1.Start();
            // disable things
            textBox_MoveToFolder.Enabled = textBox1.Enabled = false;
            managedListView1.Enabled = false;
            button_start.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button6.Enabled = false;
            radioButton_replaceFile.Enabled = radioButton1.Enabled = false;
            checkBox_fixChr.Enabled = checkBox_FixMapper.Enabled = checkBox_fixPrg.Enabled
                = checkBox_fixTv.Enabled = checkBox1.Enabled = false;
            // show console
            FormConsole frm = new FormConsole();
            frm.Show();
            // start thread
            mainThread = new Thread(new ThreadStart(PROGRESS));
            mainThread.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progress;
            label_status.Text = status;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormINESFilesFixer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainThread != null)
            {
                if (mainThread.IsAlive)
                {
                    if (MessageBox.Show("Are you sure you want to stop ?", "Abort", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        mainThread.Abort();
                        Console.WriteLine("Abort by user. Type 'save' to save log.", Core.DebugCode.Error);
                        Done1();
                    }
                }
            }
        }
    }
}
