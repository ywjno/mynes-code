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
using MyNes.Core;
using MyNes.Core.Exceptions;
using MyNes.Core.ROM;
using MyNes.Core.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MyNes.Renderers;
using MyNes.Core.Boards;
using MLV;
namespace MyNes.Forms
{
    public partial class FormMain : Form
    {
        private FormConsole consoleForm;
        private FormSpeed speedForm;
        private Thread gameThread;
        private bool savedb;
        private bool SaveDB
        {
            get { return savedb; }
            set
            {
                savedb = value;
                if (value)
                    this.Text = "My Nes 5 ALPHA * ";
                else
                    this.Text = "My Nes 5 ALPHA";
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
            RefreshColumns();
            //spliters
            splitContainer1.SplitterDistance = Program.Settings.SplitContainer1;
            splitContainer2.SplitterDistance = Program.Settings.SplitContainer2;
            //filter
            ComboBox_filterBy.SelectedIndex = Program.Settings.FilterIndex;
            if (Program.Settings.FilterLatestItems == null)
                Program.Settings.FilterLatestItems = new System.Collections.Specialized.StringCollection();
            ComboBox_filter.Items.Clear();
            foreach (string item in Program.Settings.FilterLatestItems)
            {
                ComboBox_filter.Items.Add(item);
            }
            if (ComboBox_filter.Items.Count > 0)
                ComboBox_filter.SelectedIndex = ComboBox_filter.Items.Count - 1;
            //view
            ThumbnailsViewSwitch.Checked = Program.Settings.IsThumbnailsView;
            ManagedListView1.ThunmbnailsHeight = ManagedListView1.ThunmbnailsWidth = trackBar_thumbnailsZoom.Value =
                Program.Settings.ThumbnailsSize;
            label_thumbnailsSize.Text = Program.Settings.ThumbnailsSize + " x " + Program.Settings.ThumbnailsSize;
            comboBox_thumbnailsMode.SelectedIndex = Program.Settings.ThumbnailsModeSelection;
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
                Program.BDatabaseManager.FilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\folders.fl";

            Program.BDatabaseManager.FilePath = Path.GetFullPath(Program.BDatabaseManager.FilePath);
            Program.Settings.FoldersDatabasePath = Program.BDatabaseManager.FilePath;
            if (savedb)
            {
                if (Program.BDatabaseManager.Save(Program.BDatabaseManager.FilePath))
                    savedb = false;
            }
            //columns
            SaveColumns();
            //filter
            Program.Settings.FilterIndex = ComboBox_filterBy.SelectedIndex;
            Program.Settings.FilterLatestItems = new System.Collections.Specialized.StringCollection();
            foreach (string item in ComboBox_filter.Items)
            {
                Program.Settings.FilterLatestItems.Add(item);
            }
            Program.Settings.ThumbnailsModeSelection = comboBox_thumbnailsMode.SelectedIndex;
            //save
            Program.Settings.Save();
        }
        private void PlaySelectedRom()
        {
            if (ManagedListView1.SelectedItems.Count != 1)
            { MessageBox.Show("Select one rom please."); return; }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            if (File.Exists(rom.Path))
                OpenRom(rom.Path);

            rom.PlayedTimes++;
            ManagedListView1.SelectedItems[0].GetSubItemByID("played times").Text = rom.PlayedTimes.ToString() + " time(s)";

            SaveDB = true;
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
                Nes.CreateNew(FileName, RenderersCore.SettingsManager.Settings.Emu_EmulationSystem);
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
            // turn on
            Nes.TurnOn();
            // pause the emulation so the renderer should continue once it's ready
            Nes.Pause = true;
            // the renderer (or the host) will setup input and output
            LaunchTheRenderer();
            // launch thread
            gameThread = new Thread(new ThreadStart(Nes.Run));
            gameThread.Start();

            AddRecent(FileName);
        }
        private void RefreshFolders()
        {
            treeView.Nodes.Clear();
            ManagedListView1.Items.Clear();

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
            statusStrip.Refresh();

            List<string> files = new List<string>(Directory.GetFiles(folder.Path));
            List<BRom> oldBromCollection = folder.BRoms;
            folder.BRoms = new List<BRom>();

            ProgressBar1.Maximum = files.Count;
            int x = 0;
            foreach (string file in files)
            {
                // First let's see if this rom already exists
                // This way, we keep old rom information like ratings, covers...etc
                foreach (BRom oldRom in oldBromCollection)
                {
                    if (oldRom.Path == file)
                    {
                        folder.BRoms.Add(oldRom);
                        goto Advance;
                    }
                }
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
                        foreach (Board brd in BoardsManager.AvailableBoards)
                        {
                            if (brd.INESMapperNumber == header.Mapper)
                            {
                                rom.Board = brd.Name;
                                break;
                            }
                        }
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
                        rom.Board = "N/A";
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

            Advance:
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
            ManagedListView1.Items.Clear();
            ManagedListView1.Visible = false;
            ProgressBar1.Visible = true;
            StatusLabel.Text = "Loading roms list ..";
            statusStrip.Refresh();
            ProgressBar1.Maximum = folder.BRoms.Count;
            int x = 0;
            foreach (BRom rom in folder.BRoms)
            {
                AddRomToList(rom);

                ProgressBar1.Value = x;
                x++;
            }
            ProgressBar1.Visible = false;
            ManagedListView1.Visible = true;
            StatusLabel.Text = "Ready.";
            string st = " roms";
            if (ManagedListView1.Items.Count == 1)
                st = " rom";
            StatusLabel_romsCount.Text = ManagedListView1.Items.Count + st;
        }
        private void LaunchTheRenderer()
        {
            try
            {
                RenderersCore.AvailableRenderers[Program.Settings.CurrentRendererIndex].Start();
            }
            catch { }
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
            FormDetectImages frm = new FormDetectImages(((TreeNodeBFolder)treeView.SelectedNode).BFolder, DetectorDetectMode.Snapshots);
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
            FormDetectImages frm = new FormDetectImages(((TreeNodeBFolder)treeView.SelectedNode).BFolder, DetectorDetectMode.Covers);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveDB = true;
            }
            if (Nes.ON)
                Nes.TogglePause(false);
        }
        private void DetectInfoTexts(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select folder first");
                return;
            }
            if (Nes.ON)
                Nes.TogglePause(true);
            FormDetectImages frm = new FormDetectImages(((TreeNodeBFolder)treeView.SelectedNode).BFolder, DetectorDetectMode.InfoTexts);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveDB = true;
            }
            if (Nes.ON)
                Nes.TogglePause(false);
        }
        private void AddRomToList(BRom rom)
        {
            ManagedListViewItem_BRom item = new ManagedListViewItem_BRom();
            item.BRom = rom;
            item.DrawMode = ManagedListViewItemDrawMode.UserDraw;
            //add subitems
            //name
            ManagedListViewSubItem subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "name";
            subitem.DrawMode = ManagedListViewItemDrawMode.TextAndImage;
            subitem.Text = rom.Name;
            switch (rom.BRomType)
            {
                /*
                     * 1: cartidge
                     * 2: zip file
                     */
                case BRomType.Archive: subitem.ImageIndex = 2; break;
                case BRomType.INES: subitem.ImageIndex = 1; break;
            }
            item.SubItems.Add(subitem);
            //file size
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "size";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.Size;
            item.SubItems.Add(subitem);
            //file type
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "file type";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = Path.GetExtension(rom.Path);
            item.SubItems.Add(subitem);
            //played times
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "played times";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.PlayedTimes.ToString() + " time(s)";
            item.SubItems.Add(subitem);
            //rating
            ManagedListViewRatingSubItem ratingItem = new ManagedListViewRatingSubItem();
            ratingItem.Rating = rom.Rating;
            ratingItem.RatingChanged += ratingItem_RatingChanged;
            ratingItem.UpdateRatingRequest += ratingItem_UpdateRatingRequest;
            ratingItem.ColumnID = "rating";
            item.SubItems.Add(ratingItem);
            //path
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "path";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.Path;
            if (!File.Exists(rom.Path))
            {
                subitem.Text = @"[/!\ Not Exist] " + rom.Path;
                subitem.Color = Color.Red;
            }
            item.SubItems.Add(subitem);
            //mapper
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "mapper";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.Mapper;
            item.SubItems.Add(subitem);
            //board
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "board";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.Board;
            item.SubItems.Add(subitem);
            //has trainer
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "trainer";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.HasTrainer;
            switch (rom.HasTrainer.ToLower())
            {
                case "yes": subitem.Color = Color.Green; break;
                case "no": subitem.Color = Color.Red; break;
            }
            item.SubItems.Add(subitem);
            //is battery packed
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "battery";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.IsBattery;
            switch (rom.IsBattery.ToLower())
            {
                case "yes": subitem.Color = Color.Green; break;
                case "no": subitem.Color = Color.Red; break;
            }
            item.SubItems.Add(subitem);
            //is pc10
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "pc10";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.IsPc10;
            switch (rom.IsPc10.ToLower())
            {
                case "yes": subitem.Color = Color.Green; break;
                case "no": subitem.Color = Color.Red; break;
            }
            item.SubItems.Add(subitem);
            //is vsunisystem
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "vs";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.IsVsUnisystem;
            switch (rom.IsVsUnisystem.ToLower())
            {
                case "yes": subitem.Color = Color.Green; break;
                case "no": subitem.Color = Color.Red; break;
            }
            item.SubItems.Add(subitem);
            //mirroing
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "mirroring";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.Mirroring;
            item.SubItems.Add(subitem);
            //has snapshot
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "snapshot";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = File.Exists(rom.SnapshotPath) ? "Yes" : "No";
            switch (subitem.Text.ToLower())
            {
                case "yes": subitem.Color = Color.Green; break;
                case "no": subitem.Color = Color.Red; break;
            }
            item.SubItems.Add(subitem);
            //has cover
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "cover";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = File.Exists(rom.CoverPath) ? "Yes" : "No";
            switch (subitem.Text.ToLower())
            {
                case "yes": subitem.Color = Color.Green; break;
                case "no": subitem.Color = Color.Red; break;
            }
            item.SubItems.Add(subitem);
            //has info text
            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "info";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = rom.InfoText.Length > 0 ? "Yes" : "No";
            switch (subitem.Text.ToLower())
            {
                case "yes": subitem.Color = Color.Green; break;
                case "no": subitem.Color = Color.Red; break;
            }
            item.SubItems.Add(subitem);
            //add the item !
            ManagedListView1.Items.Add(item);
        }

        void ratingItem_UpdateRatingRequest(object sender, ManagedListViewRatingChangedArgs e)
        {
            ((ManagedListViewRatingSubItem)ManagedListView1.Items[e.ItemIndex].GetSubItemByID("rating")).Rating =
            ((ManagedListViewItem_BRom)ManagedListView1.Items[e.ItemIndex]).BRom.Rating;
        }
        void ratingItem_RatingChanged(object sender, ManagedListViewRatingChangedArgs e)
        {
            ((ManagedListViewItem_BRom)ManagedListView1.Items[e.ItemIndex]).BRom.Rating = e.Rating; ;
            SaveDB = true;
        }
        private void DoFilter(object sender, EventArgs e)
        {
            if (ComboBox_filter.Text == "")
            {
                MessageBox.Show("Please enter a text first !");
                return;
            }
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a folder first !");
                return;
            }
            if (!ComboBox_filter.Items.Contains(ComboBox_filter.Text))
                ComboBox_filter.Items.Add(ComboBox_filter.Text);
            if (ComboBox_filter.Items.Count > 100)
                ComboBox_filter.Items.RemoveAt(0);//limit to 100 items.
            // do the filter !
            BFolder folder = ((TreeNodeBFolder)treeView.SelectedNode).BFolder;

            ManagedListView1.Items.Clear();
            ProgressBar1.Visible = true;
            StatusLabel.Text = "Filtering ..";
            statusStrip.Refresh();
            ProgressBar1.Maximum = folder.BRoms.Count;
            int x = 0;

            string FindWhat = ComboBox_filter.Text;
            bool matchCase = FilterOption_MatchCase.Checked;
            bool matchWord = FilterOption_MachWord.Checked;
            foreach (BRom rom in folder.BRoms)
            {
                switch (ComboBox_filterBy.SelectedIndex)
                {
                    case 0:// name ?
                        if (rom.Name.Length >= FindWhat.Length)
                        {
                            if (!matchWord)
                            {
                                for (int SearchWordIndex = 0; SearchWordIndex <
                                        (rom.Name.Length - FindWhat.Length) + 1; SearchWordIndex++)
                                {
                                    string Ser = rom.Name.Substring(SearchWordIndex, FindWhat.Length);
                                    if (!matchCase)
                                    {
                                        if (Ser.ToLower() == FindWhat.ToLower())
                                        {
                                            //this is it !
                                            AddRomToList(rom);
                                        }
                                    }
                                    else
                                    {
                                        if (Ser == FindWhat)
                                        {
                                            //this is it !
                                            AddRomToList(rom);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string[] wordToFind = FindWhat.Split(new char[] { ' ' });
                                string[] texts = rom.Name.Split(new char[] { ' ' });
                                int matched = 0;
                                for (int j = 0; j < texts.Length; j++)
                                {
                                    for (int h = 0; h < wordToFind.Length; h++)
                                    {
                                        if (!matchCase)
                                        {
                                            if (texts[j].ToLower() == wordToFind[h].ToLower())
                                            {
                                                matched++;
                                                wordToFind[h] = "";
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (texts[j] == wordToFind[h])
                                            {
                                                wordToFind[h] = "";
                                                matched++;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (matched >= wordToFind.Length)
                                {
                                    //this is it !
                                    AddRomToList(rom);
                                }
                            }
                        }
                        break;
                    case 1:// mapper #
                        if (rom.Mapper == FindWhat)
                        {
                            //this is it !
                            AddRomToList(rom);
                        }
                        break;
                }

                ProgressBar1.Value = x;
                x++;
            }
            ProgressBar1.Visible = false;
            StatusLabel.Text = "Done.";
            string st = " roms";
            if (ManagedListView1.Items.Count == 1)
                st = " rom";
            StatusLabel_romsCount.Text = ManagedListView1.Items.Count + st;
        }
        private void RefreshColumns()
        {
            ManagedListView1.Columns = new ManagedListViewColumnsCollection();
            columnsToolStripMenuItem.DropDownItems.Clear();
            ComboBox_filter.Items.Clear();
            foreach (ColumnItem item in Program.Settings.ColumnsManager.Columns)
            {
                if (item.Visible)
                {
                    ManagedListViewColumn column = new ManagedListViewColumn();
                    column.HeaderText = item.ColumnName;
                    column.ID = item.ColumnID;
                    column.Width = item.Width;
                    column.SortMode = ManagedListViewSortMode.None;
                    ManagedListView1.Columns.Add(column);
                }

                ToolStripMenuItem mitem = new ToolStripMenuItem();
                mitem.Text = item.ColumnName;
                mitem.Checked = item.Visible;
                columnsToolStripMenuItem.DropDownItems.Add(mitem);
            }
            if (ComboBox_filter.Items.Count > 0)
                ComboBox_filter.SelectedIndex = 0;
        }
        private void SaveColumns()
        {
            List<ColumnItem> oldCollection = Program.Settings.ColumnsManager.Columns;
            //create new, save the visible columns first
            Program.Settings.ColumnsManager.Columns = new List<ColumnItem>();
            foreach (ManagedListViewColumn column in ManagedListView1.Columns)
            {
                ColumnItem item = new ColumnItem();
                item.ColumnID = column.ID;
                item.ColumnName = column.HeaderText;
                item.Visible = true;
                item.Width = column.Width;

                Program.Settings.ColumnsManager.Columns.Add(item);
                //look for the same item in the old collection then remove it
                foreach (ColumnItem olditem in oldCollection)
                {
                    if (olditem.ColumnID == column.ID)
                    {
                        oldCollection.Remove(olditem);
                        break;
                    }
                }
            }
            //now add the rest of the items (not visible)
            foreach (ColumnItem olditem in oldCollection)
            {
                ColumnItem item = new ColumnItem();
                item.ColumnID = olditem.ColumnID;
                item.ColumnName = olditem.ColumnName;
                item.Visible = false;
                item.Width = olditem.Width;
                Program.Settings.ColumnsManager.Columns.Add(item);
            }
        }
        private void SwitchViewMode()
        {
            ManagedListView1.ViewMode = Program.Settings.IsThumbnailsView ?
                ManagedListViewViewMode.Thumbnails : ManagedListViewViewMode.Details;
            panel_thumbnailsPanel.Visible = Program.Settings.IsThumbnailsView;

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
            buttonDeleteFolder.Enabled = false;

            if (treeView.SelectedNode == null)
                return;

            buttonDeleteFolder.Enabled = (treeView.SelectedNode.Parent == null);

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
            openToolStripMenuItem1_Click(sender, e);
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
            menuStrip.Visible = menuStripToolStripMenuItem.Checked;
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
            op.Filter = "All Supported Files |*.nes;*.NES;*.7z;*.7Z;*.rar;*.RAR;*.zip;*.ZIP|INES rom (*.nes)|*.nes;*.NES|Archives (*.7z *.rar *.zip)|*.7z;*.7Z;*.rar;*.RAR;*.zip;*.ZIP";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OpenRom(op.FileName);
            }
        }
        private void aboutMyNesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
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
                Program.BDatabaseManager.FilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\folders.fl";

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
        private void rebuildCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
                return;
            BuildCachForFolder(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
            RefreshFilesFromFolder(((TreeNodeBFolder)treeView.SelectedNode).BFolder);
            SaveDB = true;
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
            if (Nes.ON && Directory.Exists(RenderersCore.SettingsManager.Settings.Folders_StateFolder))
                Nes.SaveState(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON && Directory.Exists(RenderersCore.SettingsManager.Settings.Folders_StateFolder))
                Nes.LoadState(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
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
            for (int i = 0; i < RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.Count; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[i].Name;
                item.Checked = i == RenderersCore.SettingsManager.Settings.Controls_ProfileIndex;
                profileToolStripMenuItem.DropDownItems.Add(item);
            }
            connect4PlayersToolStripMenuItem.Checked = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Connect4Players;
            connectZapperToolStripMenuItem.Checked = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].ConnectZapper;
        }
        private void profileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.Count; i++)
            {
                if (e.ClickedItem.Text == RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[i].Name)
                {
                    RenderersCore.SettingsManager.Settings.Controls_ProfileIndex = i;
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
            switch (RenderersCore.SettingsManager.Settings.Emu_EmulationSystem)
            {
                case EmulationSystem.AUTO:
                    autoToolStripMenuItem.Checked = true;
                    nTSCToolStripMenuItem.Checked = false;
                    pALToolStripMenuItem.Checked = false;
                    dENDYToolStripMenuItem.Checked = false;
                    break;
                case EmulationSystem.NTSC:
                    autoToolStripMenuItem.Checked = false;
                    nTSCToolStripMenuItem.Checked = true;
                    pALToolStripMenuItem.Checked = false;
                    dENDYToolStripMenuItem.Checked = false;
                    break;
                case EmulationSystem.PALB:
                    autoToolStripMenuItem.Checked = false;
                    nTSCToolStripMenuItem.Checked = false;
                    pALToolStripMenuItem.Checked = true;
                    dENDYToolStripMenuItem.Checked = false;
                    break;
                case EmulationSystem.DENDY:
                    autoToolStripMenuItem.Checked = false;
                    nTSCToolStripMenuItem.Checked = false;
                    pALToolStripMenuItem.Checked = false;
                    dENDYToolStripMenuItem.Checked = true;
                    break;
            }
        }
        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderersCore.SettingsManager.Settings.Emu_EmulationSystem = EmulationSystem.AUTO;
        }
        private void nTSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderersCore.SettingsManager.Settings.Emu_EmulationSystem = EmulationSystem.NTSC;
        }
        private void pALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderersCore.SettingsManager.Settings.Emu_EmulationSystem = EmulationSystem.PALB;
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

            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].ConnectZapper = !
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].ConnectZapper;
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

            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Connect4Players = !
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Connect4Players;
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

            //others
            if (Nes.ON)
            {
                recordSoundToolStripMenuItem.Enabled = true;
                recordSoundToolStripMenuItem.Text = Nes.AudioDevice.IsRecording ? "Stop re&codring sound" : "Re&cord sound";
            }
            else
            {
                recordSoundToolStripMenuItem.Enabled = false;
                recordSoundToolStripMenuItem.Text = "Re&cord sound";
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
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start(rom.SnapshotPath); }
            catch { }
        }
        private void openContainerFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start("explorer.exe", @"/select, " + rom.SnapshotPath); }
            catch { }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start(rom.CoverPath); }
            catch { }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start("explorer.exe", @"/select, " + rom.CoverPath); }
            catch { }
        }
        private void dENDYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenderersCore.SettingsManager.Settings.Emu_EmulationSystem = EmulationSystem.DENDY;
        }
        private void buttonDeleteFolder_EnabledChanged(object sender, EventArgs e)
        {
            deleteToolStripMenuItem.Enabled = deleteFolderToolStripMenuItem.Enabled = buttonDeleteFolder.Enabled;
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
            {
                SaveFileDialog sav = new SaveFileDialog();
                sav.Title = "Save state as";
                sav.Filter = "My Nes State (*.mns)|*.mns";
                if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Nes.SaveStateAs(sav.FileName);
                }
            }
        }
        private void loadAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Load state as";
                op.Filter = "My Nes State (*.mns)|*.mns";
                if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Nes.LoadStateAs(op.FileName);
                }
            }
        }
        private void recordSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
            {
                Nes.TogglePause(true);
                if (Nes.AudioDevice.IsRecording)
                {
                    Nes.AudioDevice.RecordStop();
                }
                else
                {
                    SaveFileDialog sav = new SaveFileDialog();
                    sav.Title = "Save wav file";
                    sav.Filter = "PCM Wav (*.wav)|*.wav";
                    if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        Nes.AudioDevice.Record(sav.FileName);
                }
                Nes.TogglePause(false);
            }
        }
        private void ComboBox_filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                DoFilter(this, new EventArgs());
        }
        private void rendererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(true);
            FormRendererSelect frm = new FormRendererSelect();
            frm.ShowDialog(this);
            //to apply setting, shutdown the renderer then re-launch it !!
            if (Nes.ON)
            {
                Nes.OnRendererShutdown();
                LaunchTheRenderer();

                Nes.TogglePause(false);
            }
        }
        private void locateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count != 1)
                return;

            string path = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom.Path;

            if (File.Exists(path))
                System.Diagnostics.Process.Start("explorer.exe", @"/select, " + path);
        }
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
                return;
            string path = ((TreeNodeBFolder)treeView.SelectedNode).BFolder.Path;
            if (Directory.Exists(path))
                System.Diagnostics.Process.Start(path);
        }
        private void ManagedListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                richTextBox_romInfo.Text = "";
                imageViewer_covers.ImageToView = imageViewer_snaps.ImageToView = null;
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;
            if (File.Exists(rom.CoverPath))
                imageViewer_covers.ImageToView = (Bitmap)Image.FromFile(rom.CoverPath);
            else
                imageViewer_covers.ImageToView = null;
            if (File.Exists(rom.SnapshotPath))
                imageViewer_snaps.ImageToView = (Bitmap)Image.FromFile(rom.SnapshotPath);
            else
                imageViewer_snaps.ImageToView = null;
            richTextBox_romInfo.Text = rom.InfoText;
        }
        private void ManagedListView1_ItemDoubleClick(object sender, ManagedListViewItemDoubleClickArgs e)
        {
            PlaySelectedRom();
        }
        private void ManagedListView1_KeyDown(object sender, KeyEventArgs e)
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
        private void ManagedListView1_EnterPressed(object sender, EventArgs e)
        {
            PlaySelectedRom();
        }
        // Draw thumbnails
        private void ManagedListView1_DrawItem(object sender, ManagedListViewItemDrawArgs e)
        {
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.Items[e.ItemIndex]).BRom;
            e.TextToDraw = rom.Name;
            switch (comboBox_thumbnailsMode.SelectedIndex)
            {
                case 0:// auto
                    if (File.Exists(rom.SnapshotPath))
                    {
                        e.ImageToDraw = Image.FromFile(rom.SnapshotPath);
                    }
                    else if (File.Exists(rom.CoverPath))
                    {
                        e.ImageToDraw = Image.FromFile(rom.CoverPath);
                    }
                    else// draw cart image or compressed file image
                    {
                        switch (rom.BRomType)
                        {
                            case BRomType.INES: e.ImageToDraw = imageList.Images[1]; break;
                            case BRomType.Archive: e.ImageToDraw = imageList.Images[2]; break;
                        }
                    }
                    break;
                case 1:// snapshot
                    if (File.Exists(rom.SnapshotPath))
                    {
                        e.ImageToDraw = Image.FromFile(rom.SnapshotPath);
                    }
                    else// draw cart image or compressed file image
                    {
                        switch (rom.BRomType)
                        {
                            case BRomType.INES: e.ImageToDraw = imageList.Images[1]; break;
                            case BRomType.Archive: e.ImageToDraw = imageList.Images[2]; break;
                        }
                    }
                    break;
                case 2: //cover
                    if (File.Exists(rom.CoverPath))
                    {
                        e.ImageToDraw = Image.FromFile(rom.CoverPath);
                    }
                    else// draw cart image or compressed file image
                    {
                        switch (rom.BRomType)
                        {
                            case BRomType.INES: e.ImageToDraw = imageList.Images[1]; break;
                            case BRomType.Archive: e.ImageToDraw = imageList.Images[2]; break;
                        }
                    }
                    break;
            }
        }
        private void ThumbnailsViewSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.IsThumbnailsView = ThumbnailsViewSwitch.Checked;
            SwitchViewMode();
        }
        private void trackBar_thumbnailsZoom_Scroll(object sender, EventArgs e)
        {
            Program.Settings.ThumbnailsSize = trackBar_thumbnailsZoom.Value;
            ManagedListView1.ThunmbnailsHeight = ManagedListView1.ThunmbnailsWidth = Program.Settings.ThumbnailsSize;
            label_thumbnailsSize.Text = Program.Settings.ThumbnailsSize + " x " + Program.Settings.ThumbnailsSize;

            ManagedListView1.Invalidate();
        }
        private void comboBox_thumbnailsMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManagedListView1.Invalidate();
        }
        // columns show/hide
        private void columnsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int i = 0;
            foreach (ColumnItem item in Program.Settings.ColumnsManager.Columns)
            {
                if (item.ColumnName == e.ClickedItem.Text)
                {
                    item.Visible = !item.Visible;
                    ((ToolStripMenuItem)e.ClickedItem).Checked = item.Visible;
                    RefreshColumns();
                    break;
                }
                i++;
            }
            ManagedListView1.Invalidate();
            SaveColumns();
        }
        private void contextMenuStrip_columns_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip_columns.Items.Clear();

            foreach (ColumnItem item in Program.Settings.ColumnsManager.Columns)
            {
                ToolStripMenuItem mitem = new ToolStripMenuItem();
                mitem.Text = item.ColumnName;
                mitem.Checked = item.Visible;
                contextMenuStrip_columns.Items.Add(mitem);
            }
        }
        private void contextMenuStrip_columns_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int i = 0;
            foreach (ColumnItem item in Program.Settings.ColumnsManager.Columns)
            {
                if (item.ColumnName == e.ClickedItem.Text)
                {
                    item.Visible = !item.Visible;
                    ((ToolStripMenuItem)e.ClickedItem).Checked = item.Visible;
                    RefreshColumns();
                    break;
                }
                i++;
            }
            ManagedListView1.Invalidate();
            SaveColumns();
        }
        private void ManagedListView1_SwitchToColumnsContextMenu(object sender, EventArgs e)
        {
            ManagedListView1.ContextMenuStrip = contextMenuStrip_columns;
        }
        private void ManagedListView1_SwitchToNormalContextMenu(object sender, EventArgs e)
        {
            ManagedListView1.ContextMenuStrip = contextMenuStrip_roms;
        }
        private void playToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PlaySelectedRom();
        }
        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("Select one rom please.");
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            try { System.Diagnostics.Process.Start("explorer.exe", @"/select, " + rom.Path); }
            catch { }
        }
        private void resetPlaydTimesCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select rom(s) please.");
                return;
            }
            foreach (ManagedListViewItem_BRom item in ManagedListView1.SelectedItems)
            {
                item.BRom.PlayedTimes = 0;
                item.GetSubItemByID("played times").Text = "0 time(s)";
            }
            ManagedListView1.Invalidate();
            SaveDB = true;
        }
        private void resetRatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select rom(s) please.");
                return;
            }
            foreach (ManagedListViewItem_BRom item in ManagedListView1.SelectedItems)
            {
                item.BRom.Rating = 0;
                ((ManagedListViewRatingSubItem)item.GetSubItemByID("rating")).Rating = 0;

            }
            ManagedListView1.Invalidate();
            SaveDB = true;
        }
        private void setSnapshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select rom(s) please.");
                return;
            }
            OpenFileDialog Op = new OpenFileDialog();
            Op.Title = "Set snapshot for rom";
            Op.Filter = "Image file (*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tiff;*.tga;)|*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tiff;*.tga;";
            Op.Multiselect = false;
            if (Op.ShowDialog(this) == DialogResult.OK)
            {
                foreach (ManagedListViewItem_BRom item in ManagedListView1.SelectedItems)
                {
                    item.BRom.SnapshotPath = Op.FileName;
                }
                ManagedListView1.Invalidate();
                SaveDB = true;
            }
        }
        private void setCoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select rom(s) please.");
                return;
            }
            OpenFileDialog Op = new OpenFileDialog();
            Op.Title = "Set cover for rom";
            Op.Filter = "Image file (*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tiff;*.tga;)|*.jpg;*.png;*.bmp;*.gif;*.jpeg;*.tiff;*.tga;";
            Op.Multiselect = false;
            if (Op.ShowDialog(this) == DialogResult.OK)
            {
                foreach (ManagedListViewItem_BRom item in ManagedListView1.SelectedItems)
                {
                    item.BRom.CoverPath = Op.FileName;
                }
                ManagedListView1.Invalidate();
                SaveDB = true;
            }
        }
        // Sort when click column
        private void ManagedListView1_ColumnClicked(object sender, ManagedListViewColumnClickArgs e)
        {
            if (treeView.SelectedNode == null)
                return;
            //get column and detect sort information
            ManagedListViewColumn column = ManagedListView1.Columns.GetColumnByID(e.ColumnID);
            if (column == null) return;
            bool az = false;
            switch (column.SortMode)
            {
                case ManagedListViewSortMode.AtoZ: az = false; break;
                case ManagedListViewSortMode.None:
                case ManagedListViewSortMode.ZtoA: az = true; break;
            }
            foreach (ManagedListViewColumn cl in ManagedListView1.Columns)
                cl.SortMode = ManagedListViewSortMode.None;
            // do sort
            BFolder folder = ((TreeNodeBFolder)treeView.SelectedNode).BFolder;
            folder.BRoms.Sort(new RomsComparer(az, column.ID));

            if (az)
                column.SortMode = ManagedListViewSortMode.AtoZ;
            else
                column.SortMode = ManagedListViewSortMode.ZtoA;

            RefreshFilesFromFolder(folder);
            SaveDB = true;
        }
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            foreach (ManagedListViewItem_BRom item in ManagedListView1.SelectedItems)
            {
                item.BRom.InfoText = richTextBox_romInfo.Text;
            }
            SaveDB = true;
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Title = "Get information from text file";
            Op.Filter = "Text file (*.txt)|*.txt;";
            Op.Multiselect = false;
            if (Op.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox_romInfo.Lines = File.ReadAllLines(Op.FileName);
            }
        }
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            OpenFileDialog save = new OpenFileDialog();
            save.Title = "Save information to text file";
            save.Filter = "Text file (*.txt)|*.txt;";
            if (ManagedListView1.SelectedItems.Count == 1)
            {
                save.FileName =
                      Path.GetFileNameWithoutExtension(ManagedListView1.SelectedItems[0].GetSubItemByID("name").Text) + ".txt";
            }
            if (save.ShowDialog(this) == DialogResult.OK)
            {
                File.WriteAllLines(save.FileName, richTextBox_romInfo.Lines);
            }
        }
        private void iNESHeaderEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
            {
                MessageBox.Show("Please close current game first. Can't edit while emulation is on.");
                return;
            }
            FormInesHeaderEditor frm = new FormInesHeaderEditor();
            frm.ShowDialog(this);
        }
        private void romInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("Select one rom please.");
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            if (Nes.ON)
            { Nes.TogglePause(true); }

            FormRomInfo frm = new FormRomInfo(rom.Path);
            frm.ShowDialog(this);

            if (Nes.ON)
            { Nes.TogglePause(false); }
        }
        private void editINESHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Nes.ON)
            {
                MessageBox.Show("Please close current game first. Can't edit while emulation is on.");
                return;
            }
            if (ManagedListView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("Select one rom please.");
                return;
            }
            BRom rom = ((ManagedListViewItem_BRom)ManagedListView1.SelectedItems[0]).BRom;

            FormInesHeaderEditor frm = new FormInesHeaderEditor(rom.Path);
            frm.ShowDialog(this);
        }
    }
}