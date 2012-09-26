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
using System.IO;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using MyNes.Core;
using MyNes.Core.ROM;
using MyNes.Core.Types;
using MyNes.Core.Exceptions;
namespace MyNes.Forms
{
    public partial class FormMain : Form
    {
        private FormConsole consoleForm;
        private FormSpeed speedForm;
        private Thread gameThread;
        private bool savedb;
        private bool sortAZ = true;
        private bool SaveDB
        {
            get { return savedb; }
            set
            {
                savedb = value;
                if (value)
                    this.Text = "MyNes* 5";
                else
                    this.Text = "MyNes 5";
            }
        }

        public FormMain(string[] args)
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            this.Location = Program.Settings.MainFormLocation;
            this.Size = Program.Settings.MainFormSize;
            //database
            if (File.Exists(Program.Settings.FoldersDatabasePath))
            {
                if (Program.BDatabaseManager.Load(Program.Settings.FoldersDatabasePath))
                {
                    RefreshFolders();
                }
            }
            //columns
            if (Program.Settings.ColumnWidths == null)
                Program.Settings.ColumnWidths = new ColumnWidthsCollection();
            for (int w = 0; w < Program.Settings.ColumnWidths.Count; w++)
            {
                listView1.Columns[w].Width = Program.Settings.ColumnWidths[w];
            }
            //spliters
            splitContainer1.SplitterDistance = Program.Settings.SplitContainer1;
            splitContainer2.SplitterDistance = Program.Settings.SplitContainer2;
        }
        private void SaveSettings()
        {
            Program.Settings.MainFormLocation = this.Location;
            Program.Settings.MainFormSize = this.Size;
            //spliters
            Program.Settings.SplitContainer1 = splitContainer1.SplitterDistance;
            Program.Settings.SplitContainer2 = splitContainer2.SplitterDistance;
            //database
            if (Program.BDatabaseManager.FilePath == "")
                Program.BDatabaseManager.FilePath = @".\fdb.fl";
            Program.BDatabaseManager.FilePath = Path.GetFullPath(Program.BDatabaseManager.FilePath);
            Program.Settings.FoldersDatabasePath = Program.BDatabaseManager.FilePath;
            if (savedb)
            {
                if (Program.BDatabaseManager.Save(Program.BDatabaseManager.FilePath))
                    savedb = false;
            }
            //columns
            Program.Settings.ColumnWidths = new ColumnWidthsCollection();
            for (int w = 0; w < listView1.Columns.Count; w++)
            {
                Program.Settings.ColumnWidths.Add(listView1.Columns[w].Width);
            }
            //save
            Program.Settings.Save();
        }
        private void PlaySelectedRom()
        {
            if (listView1.SelectedItems.Count != 1)
                return;

            string path = ((ListViewItemBRom)listView1.SelectedItems[0]).BRom.Path;

            if (File.Exists(path))
                OpenRom(path);
        }
        public void OpenRom(string FileName)
        {
            Nes.Shutdown();//this will end the thread
            #region Check if archive
            SevenZip.SevenZipExtractor EXTRACTOR;
            if (Path.GetExtension(FileName).ToLower() != ".nes")
            {
                try
                {
                    EXTRACTOR = new SevenZip.SevenZipExtractor(FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (EXTRACTOR.ArchiveFileData.Count == 1)
                {
                    if (EXTRACTOR.ArchiveFileData[0].FileName.Substring(EXTRACTOR.ArchiveFileData[0].FileName.Length - 4, 4).ToLower() == ".nes")
                    {
                        EXTRACTOR.ExtractArchive(Path.GetTempPath());
                        FileName = Path.GetTempPath() + EXTRACTOR.ArchiveFileData[0].FileName;
                    }
                }
                else
                {
                    List<string> filenames = new List<string>();
                    foreach (SevenZip.ArchiveFileInfo file in EXTRACTOR.ArchiveFileData)
                    {
                        filenames.Add(file.FileName);
                    }
                    FormFilesList ar = new FormFilesList(filenames.ToArray());
                    if (ar.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        string[] fil = { ar.SelectedRom };
                        EXTRACTOR.ExtractFiles(Path.GetTempPath(), fil);
                        FileName = Path.GetTempPath() + ar.SelectedRom;
                    }
                    else
                    { return; }
                }
            }
            #endregion
            try
            {
                Nes.CreateNew(FileName, Program.Settings.EmuSystem);
            }
            catch (NotSupportedMapperException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (ReadRomFailedException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.ToString());
                return;
            }
            //the renderer (or the host) will setup input and output
            LaunchTheRenderer();
            //turn on
            Nes.TurnOn();
            //launch thread
            gameThread = new Thread(new ThreadStart(Nes.Run));
            gameThread.Start();

            AddRecent(FileName);
        }
        private void RefreshFolders()
        {
            treeView.Nodes.Clear();
            listView1.Items.Clear();

            foreach (BFolder folder in Program.BDatabaseManager.BrowserDatabase.Folders)
            {
                TreeNodeBFolder tr = new TreeNodeBFolder();
                tr.BFolder = folder;
                tr.ImageIndex = 0;
                tr.SelectedImageIndex = 0;
                tr.RefreshFolders(0, 0);
                treeView.Nodes.Add(tr);
            }
        }
        private void BuildCachForFolder(BFolder folder)
        {
            ProgressBar1.Visible = true;
            StatusLabel.Text = "Building cache, please wait ..";
            statusStrip1.Refresh();

            List<string> files = new List<string>(Directory.GetFiles(folder.Path));
            folder.BRoms = new List<BRom>();

            ProgressBar1.Maximum = files.Count;
            int x = 0;
            foreach (string file in files)
            {
                #region INES
                if (Path.GetExtension(file).ToLower() == ".nes")
                {
                    BRom rom = new BRom();
                    rom.BRomType = BRomType.INES;
                    rom.Name = Path.GetFileName(file);
                    rom.Size = Helper.GetFileSize(file);
                    rom.Path = file;
                    //INES header
                    INESHeader header = new INESHeader(file);
                    if (header.IsValid)
                    {
                        rom.HasTrainer = header.HasTrainer ? "Yes" : "No";
                        rom.IsBattery = header.HasSaveRam ? "Yes" : "No";
                        rom.IsPc10 = header.IsPlaychoice10 ? "Yes" : "No";
                        rom.IsVsUnisystem = header.IsVSUnisystem ? "Yes" : "No";
                        rom.Mapper = header.Mapper.ToString();
                        switch (header.Mirroring)
                        {
                            case Mirroring.Mode1ScA: rom.Mirroring = "One-Screen A"; break;
                            case Mirroring.Mode1ScB: rom.Mirroring = "One-Screen B"; break;
                            case Mirroring.ModeFull: rom.Mirroring = "4-Screen"; break;
                            case Mirroring.ModeHorz: rom.Mirroring = "Horizontal"; break;
                            case Mirroring.ModeVert: rom.Mirroring = "Vertical"; break;
                        }
                    }
                    else
                    {
                        rom.HasTrainer = "N/A";
                        rom.IsBattery = "N/A";
                        rom.IsPc10 = "N/A";
                        rom.IsVsUnisystem = "N/A";
                        rom.Mapper = "N/A";
                        rom.Mirroring = "N/A";
                    }
                    folder.BRoms.Add(rom);
                }
                #endregion
                #region Archive
                else if (Path.GetExtension(file).ToLower() == ".rar" ||
                         Path.GetExtension(file).ToLower() == ".zip" ||
                         Path.GetExtension(file).ToLower() == ".7z" ||
                         Path.GetExtension(file).ToLower() == ".tar")
                {
                    BRom rom = new BRom();
                    rom.BRomType = BRomType.Archive;
                    rom.Name = Path.GetFileName(file);
                    rom.Size = Helper.GetFileSize(file);
                    rom.Path = file;
                    rom.HasTrainer = "N/A";
                    rom.IsBattery = "N/A";
                    rom.IsPc10 = "N/A";
                    rom.IsVsUnisystem = "N/A";
                    rom.Mapper = "N/A";
                    rom.Mirroring = "N/A";
                    folder.BRoms.Add(rom);
                }
                #endregion

                ProgressBar1.Value = x;
                x++;
            }
            folder.CacheBuilt = true;
            SaveDB = true;
            ProgressBar1.Visible = false;
            StatusLabel.Text = "Ready.";
        }
        private void RefreshFilesFromFolder(BFolder folder)
        {
            listView1.Items.Clear();
            listView1.Visible = false;
            ProgressBar1.Visible = true;
            StatusLabel.Text = "Loading roms list ..";
            statusStrip1.Refresh();
            ProgressBar1.Maximum = folder.BRoms.Count;
            int x = 0;
            foreach (BRom rom in folder.BRoms)
            {
                ListViewItemBRom item = new ListViewItemBRom();
                item.BRom = rom;
                item.ImageIndex = (Path.GetExtension(rom.Path).ToLower() == ".nes") ? 2 : 3;
                item.SubItems.Add(rom.Size);
                item.SubItems.Add(rom.Mapper);
                item.SubItems.Add(rom.Mirroring);
                item.SubItems.Add(rom.HasTrainer);
                item.SubItems.Add(rom.IsBattery);
                item.SubItems.Add(rom.IsPc10);
                item.SubItems.Add(rom.IsVsUnisystem);
                item.SubItems.Add(rom.Path);
                listView1.Items.Add(item);

                ProgressBar1.Value = x;
                x++;
            }
            listView1.Visible = true;
            ProgressBar1.Visible = false;
            StatusLabel.Text = "Ready.";
        }
        private void LaunchTheRenderer()
        {
            switch (Program.Settings.CurrentRenderer)
            {
                case SupportedRenderers.SlimDX:
                    RendererFormSlimDX frm = new RendererFormSlimDX();
                    frm.Show();
                    break;
            }
        }
        private void AddRecent(string fileName)
        {
            if (Program.Settings.RecentFiles == null)
                Program.Settings.RecentFiles = new System.Collections.Specialized.StringCollection();
            for (int i = 0; i < Program.Settings.RecentFiles.Count; i++)
            {
                if (fileName == Program.Settings.RecentFiles[i])
                { Program.Settings.RecentFiles.Remove(fileName); }
            }
            Program.Settings.RecentFiles.Insert(0, fileName);
            //limit to 9 elements
            if (Program.Settings.RecentFiles.Count > 9)
                Program.Settings.RecentFiles.RemoveAt(9);
        }
        private void DetectSnapshots(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select folder first");
                return;
            }
            if (Nes.ON)
                Nes.TogglePause(true);
            FormDetectImages frm = new FormDetectImages(((TreeNodeBFolder)treeView.SelectedNode).BFolder, true);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveDB = true;
            }
            if (Nes.ON)
                Nes.TogglePause(false);
        }
        private void DetectCovers(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select folder first");
                return;
            }
            if (Nes.ON)
                Nes.TogglePause(true);
            FormDetectImages frm = new FormDetectImages(((TreeNodeBFolder)treeView.SelectedNode).BFolder, false);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveDB = true;
            }
            if (Nes.ON)
                Nes.TogglePause(false);
        }

        private void buttonCreateFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = "Add roms folder";
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (!Program.BDatabaseManager.BrowserDatabase.IsFolderExist(fol.SelectedPath))
                {
                    BFolder bfolder = new BFolder();
                    bfolder.Path = fol.SelectedPath;
                    bfolder.RefreshFolders();
                    Program.BDatabaseManager.BrowserDatabase.Folders.Add(bfolder);
                    SaveDB = true;
                    RefreshFolders();
                }
            }
        }
        private void buttonModifyFolder_Click(object sender, EventArgs e) { }
        private void buttonDeleteFolder_Click(object sender, EventArgs e) { }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Nes.Pause = !Nes.Pause;
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            Nes.Shutdown();
        }
        private void buttonConsole_Click(object sender, EventArgs e)
        {
            if (consoleForm != null)
            {
                buttonConsole.Checked = false;
                consoleForm.Close();
                consoleForm = null;
            }
            else
            {
                buttonConsole.Checked = true;
                consoleForm = new FormConsole();
                consoleForm.FormClosed += new FormClosedEventHandler(consoleForm_FormClosed);
                consoleForm.Show();
            }
        }
        private void consoleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            consoleForm = null;
            buttonConsole.Checked = false;
        }
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            deleteFolderToolStripMenuItem.Enabled = false;
            if (treeView.SelectedNode == null)
                return;

            deleteFolderToolStripMenuItem.Enabled = (treeView.SelectedNode.Parent == null);

            if (((TreeNodeBFolder)treeView.SelectedNode).BFolder.CacheBuilt)
            {
                RefreshFilesFromFolder(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
            }
            else
            {
                BuildCachForFolder(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
                RefreshFilesFromFolder(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
                SaveDB = true;
            }
        }
        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PlaySelectedRom();
        }
        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonConsole_Click(sender, e);
        }
        private void buttonConsole_CheckedChanged(object sender, EventArgs e)
        {
            consoleToolStripMenuItem.Checked = buttonConsole.Checked;
        }
        private void toolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripToolStripMenuItem.Checked = !toolStripToolStripMenuItem.Checked;
        }
        private void menuStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStripToolStripMenuItem.Checked = !menuStripToolStripMenuItem.Checked;
        }
        private void toolStripToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            toolStrip.Visible = toolStripToolStripMenuItem.Checked;
        }
        private void menuStripToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.Visible = menuStripToolStripMenuItem.Checked;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nes.Shutdown();
            Close();
        }
        private void ShowHelp(object sender, EventArgs e)
        {
            Help.ShowHelp(this, ".\\Help.chm", HelpNavigator.TableOfContents);
        }
        private void openRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "INES (*.nes)|*.nes;*.NES";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OpenRom(op.FileName);
            }
        }
        private void aboutMyNesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout(Application.ProductVersion);
            frm.ShowDialog(this);
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Nes.Shutdown();
        }
        private void emulationSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (speedForm != null)
            {
                emulationSpeedToolStripMenuItem.Checked = false;
                speedForm.Close();
                speedForm = null;
            }
            else
            {
                emulationSpeedToolStripMenuItem.Checked = true;
                speedForm = new FormSpeed();
                speedForm.FormClosed += new FormClosedEventHandler(speedForm_FormClosed);
                speedForm.Show();
            }
        }
        private void speedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            speedForm = null;
            emulationSpeedToolStripMenuItem.Checked = false;
        }
        private void softResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nes.SoftReset();
        }
        private void saveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.BDatabaseManager.FilePath == "")
                Program.BDatabaseManager.FilePath = @".\fdb.fl";
            Program.BDatabaseManager.FilePath = Path.GetFullPath(Program.BDatabaseManager.FilePath);
            if (Program.BDatabaseManager.Save(Program.BDatabaseManager.FilePath))
            {
                SaveDB = false;
                StatusLabel.Text = "Folders database saved success";
            }
            else
                MessageBox.Show("Unable to save !!");
        }
        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open MyNes folders database";
            op.Filter = "MyNes folders database (*.fl)|*.fl";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (savedb)
                {
                    if (MessageBox.Show("Do you want to save current database first ?", "MyNes",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Program.BDatabaseManager.Save(Program.BDatabaseManager.FilePath))
                            savedb = false;
                        else
                        { MessageBox.Show("Unable to save !!"); return; }
                    }
                }
                if (Program.BDatabaseManager.Load(op.FileName))
                {
                    savedb = false;
                    RefreshFolders();
                }
            }
        }
        private void saveDatabaseAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save MyNes folders database";
            save.Filter = "MyNes folders database (*.fl)|*.fl";
            if (save.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (Program.BDatabaseManager.Save(save.FileName))
                    savedb = false;
                else
                    MessageBox.Show("Unable to save !!");
            }
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PlaySelectedRom();
        }
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                PlaySelectedRom();
            if (e.KeyData == Keys.D0)
                Nes.StateSlot = 0;
            if (e.KeyData == Keys.D1)
                Nes.StateSlot = 1;
            if (e.KeyData == Keys.D2)
                Nes.StateSlot = 2;
            if (e.KeyData == Keys.D3)
                Nes.StateSlot = 3;
            if (e.KeyData == Keys.D4)
                Nes.StateSlot = 4;
            if (e.KeyData == Keys.D5)
                Nes.StateSlot = 5;
            if (e.KeyData == Keys.D6)
                Nes.StateSlot = 6;
            if (e.KeyData == Keys.D7)
                Nes.StateSlot = 7;
            if (e.KeyData == Keys.D8)
                Nes.StateSlot = 8;
            if (e.KeyData == Keys.D9)
                Nes.StateSlot = 9;
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAZ);
            sortAZ = !sortAZ;
        }
        private void rebuildCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
                return;
            BuildCachForFolder(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
            RefreshFilesFromFolder(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
            SaveDB = true;
        }
        private void deleteFolderToolStripMenuItem_EnabledChanged(object sender, EventArgs e)
        {
            deleteToolStripMenuItem.Enabled = buttonDeleteFolder.Enabled = deleteFolderToolStripMenuItem.Enabled;
        }
        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete selected folder from the list ?", "My Nes",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (treeView.SelectedNode == null)
                    return;
                Program.BDatabaseManager.BrowserDatabase.Folders.Remove(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
                RefreshFolders();
                SaveDB = true;
            }
        }
        private void romInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRomInfo frm = new FormRomInfo();
            frm.ShowDialog(this);
        }
        private void stateToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            slotToolStripMenuItem.DropDownItems.Clear();
            for (int i = 0; i < 10; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(i.ToString());
                item.Checked = (Nes.StateSlot == i);
                slotToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        private void slotToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Nes.StateSlot = int.Parse(e.ClickedItem.Text.Substring(0, 1));
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON && Directory.Exists(Program.Settings.StateFolder))
                Nes.SaveState(Program.Settings.StateFolder);
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON && Directory.Exists(Program.Settings.StateFolder))
                Nes.LoadState(Program.Settings.StateFolder);
        }
        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);
            FormInput frm = new FormInput();
            frm.ShowDialog(this);
            //to apply setting, shutdown the renderer then re-launch it !!
            if (Nes.ON)
            {
                Nes.OnRendererShutdown();
                LaunchTheRenderer();

                Nes.TogglePause(false);
            }
        }
        private void inputToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            profileToolStripMenuItem.DropDownItems.Clear();
            for (int i = 0; i < Program.Settings.ControlProfiles.Count; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = Program.Settings.ControlProfiles[i].Name;
                item.Checked = i == Program.Settings.ControlProfileIndex;
                profileToolStripMenuItem.DropDownItems.Add(item);
            }
            connect4PlayersToolStripMenuItem.Checked = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Connect4Players;
            connectZapperToolStripMenuItem.Checked = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].ConnectZapper;
        }
        private void profileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < Program.Settings.ControlProfiles.Count; i++)
            {
                if (e.ClickedItem.Text == Program.Settings.ControlProfiles[i].Name)
                {
                    Program.Settings.ControlProfileIndex = i;
                    //to apply setting, shutdown the renderer then re-launch it !!
                    if (Nes.ON)
                    {
                        Nes.OnRendererShutdown();
                        LaunchTheRenderer();

                        Nes.TogglePause(false);
                    }
                    break;
                }
            }
        }
        private void pathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);
            FormPathSettings frm = new FormPathSettings();
            frm.ShowDialog(this);
            if (frm.RefreshBrowser)
            {
                if (savedb)
                {
                    if (MessageBox.Show("Browser database file changed and it will be loaded now. Do you want to save current database first ?", "MyNes",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Program.BDatabaseManager.Save(Program.BDatabaseManager.FilePath))
                            savedb = false;
                        else
                        { MessageBox.Show("Unable to save !!"); return; }
                    }
                }
                if (Program.BDatabaseManager.Load(Program.Settings.FoldersDatabasePath))
                {
                    savedb = false;
                    RefreshFolders();
                }
            }
            if (Nes.ON)
                Nes.TogglePause(false);
        }
        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);
            FormSoundSettings frm = new FormSoundSettings();
            frm.ShowDialog(this);
            //to apply setting, shutdown the renderer then re-launch it !!
            if (Nes.ON)
            {
                Nes.OnRendererShutdown();
                LaunchTheRenderer();

                Nes.TogglePause(false);
            }
        }
        private void emulationSystemToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            switch (Program.Settings.EmuSystem)
            {
                case EmulationSystem.AUTO:
                    autoToolStripMenuItem.Checked = true;
                    nTSCToolStripMenuItem.Checked = false;
                    pALToolStripMenuItem.Checked = false;
                    dANDYToolStripMenuItem.Checked = false;
                    break;
                case EmulationSystem.NTSC:
                    autoToolStripMenuItem.Checked = false;
                    nTSCToolStripMenuItem.Checked = true;
                    pALToolStripMenuItem.Checked = false;
                    dANDYToolStripMenuItem.Checked = false;
                    break;
                case EmulationSystem.PALB:
                    autoToolStripMenuItem.Checked = false;
                    nTSCToolStripMenuItem.Checked = false;
                    pALToolStripMenuItem.Checked = true;
                    dANDYToolStripMenuItem.Checked = false;
                    break;
                case EmulationSystem.DANDY:
                    autoToolStripMenuItem.Checked = false;
                    nTSCToolStripMenuItem.Checked = false;
                    pALToolStripMenuItem.Checked = false;
                    dANDYToolStripMenuItem.Checked = true;
                    break;
            }
        }
        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.EmuSystem = EmulationSystem.AUTO;
        }
        private void nTSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.EmuSystem = EmulationSystem.NTSC;
        }
        private void pALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.EmuSystem = EmulationSystem.PALB;
        }
        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);
            FormVideoSettings frm = new FormVideoSettings();
            frm.ShowDialog(this);
            //to apply setting, shutdown the renderer then re-launch it !!
            if (Nes.ON)
            {
                Nes.OnRendererShutdown();
                LaunchTheRenderer();

                Nes.TogglePause(false);
            }
        }
        private void paletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPaletteSettings frm = new FormPaletteSettings();
            frm.Show();
        }
        private void configureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);
            try
            {
                FormGameGenie frm = new FormGameGenie();
                frm.ShowDialog(this);
            }
            catch { }
            if (Nes.ON)
                Nes.TogglePause(false);
        }
        //active game genie
        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
            {
                Nes.TogglePause(true);
                if (!Nes.Board.IsGameGenieActive && Nes.Board.GameGenieCodes == null)
                {
                    //configure
                    FormGameGenie frm = new FormGameGenie();
                    frm.ShowDialog(this);
                    activeToolStripMenuItem.Checked = Nes.Board.IsGameGenieActive;
                }
                else
                {
                    Nes.Board.IsGameGenieActive = !Nes.Board.IsGameGenieActive;
                    activeToolStripMenuItem.Checked = Nes.Board.IsGameGenieActive;
                }
                Nes.TogglePause(false);
            }
            else
            { activeToolStripMenuItem.Checked = false; }
        }
        private void connectZapperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);

            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].ConnectZapper = !
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].ConnectZapper;
            //reset renderer to apply
            if (Nes.ON)
            {
                Nes.OnRendererShutdown();
                LaunchTheRenderer();

                Nes.TogglePause(false);
            }
        }
        private void connect4PlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);

            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Connect4Players = !
                Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Connect4Players;
            //reset renderer to apply
            if (Nes.ON)
            {
                Nes.OnRendererShutdown();
                LaunchTheRenderer();

                Nes.TogglePause(false);
            }
        }
        private void hardResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nes.HardReset();
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaySelectedRom();
        }
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (Program.Settings.RecentFiles == null)
                Program.Settings.RecentFiles = new System.Collections.Specialized.StringCollection();

            recentFilesToolStripMenuItem.DropDownItems.Clear();
            foreach (string file in Program.Settings.RecentFiles)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = Path.GetFileName(file);
                item.ToolTipText = file;
                recentFilesToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        private void recentFilesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (File.Exists(e.ClickedItem.ToolTipText))
            {
                OpenRom(e.ClickedItem.ToolTipText);
                AddRecent(e.ClickedItem.ToolTipText);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                imageViewer_covers.ImageToView = imageViewer_snaps.ImageToView = null;
                return;
            }
            BRom rom = ((ListViewItemBRom)listView1.SelectedItems[0]).BRom;
            if (File.Exists(rom.CoverPath))
                imageViewer_covers.ImageToView = (Bitmap)Image.FromFile(rom.CoverPath);
            else
                imageViewer_covers.ImageToView = null;
            if (File.Exists(rom.SnapshotPath))
                imageViewer_snaps.ImageToView = (Bitmap)Image.FromFile(rom.SnapshotPath);
            else
                imageViewer_snaps.ImageToView = null;
        }
        private void imageViewer_snaps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openContainerFolderToolStripMenuItem_Click(sender, null);
        }
        private void imageViewer_covers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            toolStripMenuItem2_Click(sender, null);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ListViewItemBRom)listView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start(rom.SnapshotPath); }
            catch { }
        }
        private void openContainerFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ListViewItemBRom)listView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start("explorer.exe", @"/select, " + rom.SnapshotPath); }
            catch { }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ListViewItemBRom)listView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start(rom.CoverPath); }
            catch { }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ListViewItemBRom)listView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start("explorer.exe", @"/select, " + rom.CoverPath); }
            catch { }
        }
        private void dANDYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.EmuSystem = EmulationSystem.DANDY;
        }
    }
}