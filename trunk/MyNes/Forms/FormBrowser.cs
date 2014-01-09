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
using MyNes.Core;
using MyNes.Core.ROM;
using MLV;
using MMB;
namespace MyNes
{
    public partial class FormBrowser : Form
    {
        public FormBrowser()
        {
            InitializeComponent();
            this.Tag = "Browser";
            LoadSettings();
            RefreshColumns();
            Program.DBManager.LoadDatabase();
            RefreshFolders();
        }

        private bool SaveDB;
        // Search
        private int searchTimer;
        private bool doSearch;
        private SearchParameters searchParameters;
        // Viewers
        private int snapshotIndex = 0;
        private int coverIndex = 0;
        private int infoTextIndex = 0;

        private void LoadSettings()
        {
            this.Location = Program.Settings.BrowserWindowLocation;
            this.Size = Program.Settings.BrowserWindowSize;
            trackBar1.Value = managedListView1.ThunmbnailsWidth =
                managedListView1.ThunmbnailsHeight = Program.Settings.BrowserThumbnailSize;
            comboBox1.SelectedIndex = Program.Settings.BrowserThumbnailModeIndex;
            managedListView1.ViewMode = Program.Settings.BrowserViewMode;
        }
        private void SaveSettings()
        {
            Program.Settings.BrowserWindowLocation = this.Location;
            Program.Settings.BrowserWindowSize = this.Size;
            Program.Settings.BrowserThumbnailModeIndex = comboBox1.SelectedIndex;
            Program.Settings.BrowserThumbnailSize = trackBar1.Value;
            Program.Settings.BrowserViewMode = managedListView1.ViewMode;
            Program.Settings.Save();
        }
        private void RefreshColumns()
        {
            if (Program.Settings.DBColumns == null)
                Program.Settings.DBColumns = new DBColumnCollection(DBColumn.BuildDefaultCollection());
            if (Program.Settings.DBColumns.Count == 0)
                Program.Settings.DBColumns = new DBColumnCollection(DBColumn.BuildDefaultCollection());
            managedListView1.Columns.Clear();
            foreach (DBColumn c in Program.Settings.DBColumns)
            {
                if (c.Visible)
                {
                    ManagedListViewColumn col = new ManagedListViewColumn();
                    col.HeaderText = c.Name;
                    col.ID = c.ColumnID;
                    col.Width = c.Width;

                    managedListView1.Columns.Add(col);
                }
            }
        }
        private void SaveColumns()
        {
            List<DBColumn> oldCollection = Program.Settings.DBColumns;
            //create new, save the visible columns first
            Program.Settings.DBColumns = new DBColumnCollection();
            foreach (ManagedListViewColumn column in managedListView1.Columns)
            {
                DBColumn item = new DBColumn();
                item.ColumnID = column.ID;
                item.Name = column.HeaderText;
                item.Visible = true;
                item.Width = column.Width;

                Program.Settings.DBColumns.Add(item);
                // look for the same item in the old collection then remove it
                foreach (DBColumn olditem in oldCollection)
                {
                    if (olditem.ColumnID == column.ID)
                    {
                        oldCollection.Remove(olditem);
                        break;
                    }
                }
            }
            //now add the rest of the items (not visible)
            foreach (DBColumn olditem in oldCollection)
            {
                DBColumn item = new DBColumn();
                item.ColumnID = olditem.ColumnID;
                item.Name = olditem.Name;
                item.Visible = false;
                item.Width = olditem.Width;
                Program.Settings.DBColumns.Add(item);
            }
        }
        private void RefreshFolders()
        {
            // Clear sort modes
            foreach (ManagedListViewColumn cl in managedListView1.Columns)
                cl.SortMode = ManagedListViewSortMode.None;
            // Clear folders
            treeView1.Nodes.Clear();
            // Refresh...
            foreach (DBFolder fol in Program.DBManager.DB.Folders)
            {
                TreeNodeFolder tr = new TreeNodeFolder();
                tr.DBFolder = fol;
                tr.SelectedImageIndex = tr.ImageIndex = 0;
                tr.RefreshFolders();
                treeView1.Nodes.Add(tr);
            }
        }
        private void RefreshFilesFromFolder(DBFolder folder)
        {
            managedListView1.Items.Clear();
            managedListView1.Visible = false;
            ProgressBar1.Visible = true;
            StatusLabel.Text = Program.ResourceManager.GetString("Status_LoadingRomsList");
            statusStrip1.Refresh();
            int x = 0;
            foreach (DBFile rom in folder.Files)
            {
                bool addThisRom = true;

                if (doSearch)
                    addThisRom = FilterSearch(rom, searchParameters);

                if (addThisRom)
                    AddFileToList(rom);

                ProgressBar1.Value = (x * 100) / folder.Files.Count;
                x++;
            }
            ProgressBar1.Visible = false;
            managedListView1.Visible = true;
            StatusLabel.Text = Program.ResourceManager.GetString("Status_Ready");
            string st = " " + Program.ResourceManager.GetString("Status_Roms");
            if (managedListView1.Items.Count == 1)
                st = " " + Program.ResourceManager.GetString("Status_Rom");
            StatusLabel_romsCount.Text = managedListView1.Items.Count + st;
        }
        private void AddFileToList(DBFile file)
        {
            ManagedListViewItem item = new ManagedListViewItem();
            item.DrawMode = ManagedListViewItemDrawMode.UserDraw;
            item.Text = Path.GetFileName(file.Path);
            item.Tag = file;
            // Add sub items
            // Name
            ManagedListViewSubItem sub = new ManagedListViewSubItem();
            sub.ColumnID = "name";
            sub.DrawMode = ManagedListViewItemDrawMode.TextAndImage;
            sub.Text = Path.GetFileName(file.Path);
            switch (file.Format)
            {
                case DBFileFormat.INES: sub.ImageIndex = 0; break;
                case DBFileFormat.Archive: sub.ImageIndex = 1; break;
            }
            item.SubItems.Add(sub);
            // Size
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "size";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.SizeLabel;
            item.SubItems.Add(sub);
            // File type
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "file type";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = Path.GetExtension(file.Path);
            item.SubItems.Add(sub);
            // Played times
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "played times";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.PlayedTimes.ToString();
            item.SubItems.Add(sub);
            // Rating
            ManagedListViewRatingSubItem ratingSubItem = new ManagedListViewRatingSubItem();
            ratingSubItem.ColumnID = "rating";
            ratingSubItem.RatingChanged += ratingSubItem_RatingChanged;
            ratingSubItem.UpdateRatingRequest += ratingSubItem_UpdateRatingRequest;
            ratingSubItem.Rating = file.Rating;
            item.SubItems.Add(ratingSubItem);
            // Path
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "path";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.Path;
            item.SubItems.Add(sub);
            // Board name
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "board";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.BoardName;
            item.SubItems.Add(sub);
            // Mapper number
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "mapper";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.MapperNumber.ToString();
            item.SubItems.Add(sub);
            // PRG size
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "prg";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.PRGSize;
            item.SubItems.Add(sub);
            // CHR size
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "chr";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.CHRSize;
            item.SubItems.Add(sub);
            // Has trainer
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "trainer";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.HasTrainer ?
                Program.ResourceManager.GetString("Status_Yes") :
                Program.ResourceManager.GetString("Status_No");
            item.SubItems.Add(sub);
            // Has save-ram
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "save ram";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.HasSaveRam ?
                Program.ResourceManager.GetString("Status_Yes") :
                Program.ResourceManager.GetString("Status_No");
            item.SubItems.Add(sub);
            // Mirroring
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "mirroring";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.Mirroring;
            item.SubItems.Add(sub);
            // Is VS System
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "vs system";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.IsVSSystem ?
                Program.ResourceManager.GetString("Status_Yes") :
                Program.ResourceManager.GetString("Status_No");
            item.SubItems.Add(sub);
            // Is Playchoice 10
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "pc10";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.IsPlaychoice10 ?
                Program.ResourceManager.GetString("Status_Yes") :
                Program.ResourceManager.GetString("Status_No");
            item.SubItems.Add(sub);
            // TV System
            sub = new ManagedListViewSubItem();
            sub.ColumnID = "tv";
            sub.DrawMode = ManagedListViewItemDrawMode.Text;
            sub.Text = file.TvSystem;
            item.SubItems.Add(sub);
            // Add the item...
            managedListView1.Items.Add(item);
        }
        private bool FilterSearch(DBFile rom, SearchParameters parameters)
        {
            if (parameters == null)
                return false;
            // Let's see what's the mode
            string searchWord = parameters.CaseSensitive ? parameters.SearchWhat : parameters.SearchWhat.ToLower();
            bool isNumberSearch = false;
            string searchTargetText = "";
            long searchTargetNumber = 0;
            // Determine the target
            switch (parameters.SearchMode)
            {
                case SearchMode.Name:
                    {
                        isNumberSearch = false;
                        searchTargetText = Path.GetFileName(rom.Path);
                        break;
                    }
                case SearchMode.FileType:
                    {
                        isNumberSearch = false;
                        searchTargetText = Path.GetExtension(rom.Path).Replace(".", "");
                        break;
                    }
                case SearchMode.Path:
                    {
                        isNumberSearch = false;
                        searchTargetText = rom.Path;
                        break;
                    }
                case SearchMode.Board:
                    {
                        isNumberSearch = false;
                        searchTargetText = rom.BoardName;
                        break;
                    }
                case SearchMode.CHR:
                    {
                        isNumberSearch = true;
                        searchTargetNumber = rom.CHR;
                        break;
                    }
                case SearchMode.Mapper:
                    {
                        isNumberSearch = true;
                        searchTargetNumber = rom.MapperNumber;
                        break;
                    }
                case SearchMode.Mirroring:
                    {
                        isNumberSearch = false;
                        searchTargetText = rom.Mirroring;
                        break;
                    }
                case SearchMode.PRG:
                    {
                        isNumberSearch = true;
                        searchTargetNumber = rom.PRG;
                        break;
                    }
                case SearchMode.TVSystem:
                    {
                        isNumberSearch = false;
                        searchTargetText = rom.TvSystem;
                        break;
                    }
                case SearchMode.Rating:
                    {
                        isNumberSearch = true;
                        searchTargetNumber = rom.Rating;
                        break;
                    }
                case SearchMode.Size:
                    {
                        isNumberSearch = true;
                        searchTargetNumber = rom.Size;
                        break;
                    }
                case SearchMode.PlayedTimes:
                    {
                        isNumberSearch = true;
                        searchTargetNumber = rom.PlayedTimes;
                        break;
                    }
            }

            if (!isNumberSearch)
            {
                if (!parameters.CaseSensitive)
                    searchTargetText = searchTargetText.ToLower();
                // Decode user code
                string[] searchCodes = searchWord.Split(new char[] { '+' });
                // Do the search
                switch (parameters.ConditionForText)
                {
                    case TextSearchCondition.Contains:// The target contains the search word
                        {
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText.Contains(s))
                                    return true;
                            }
                            return false;
                        }
                    case TextSearchCondition.DoesNotContain:// The target doesn't contain the search word
                        {
                            bool add = true;
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText.Contains(s))
                                {
                                    add = false; break;
                                }
                            }
                            return add;
                        }
                    case TextSearchCondition.Is:// Match the word !
                        {
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText == s)
                                    return true;
                            }
                            return false;
                        }
                    case TextSearchCondition.IsNot:// Don't match the word !
                        {
                            bool add = true;
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText == s)
                                {
                                    add = false; break;
                                }
                            }
                            return add;
                        }
                    case TextSearchCondition.StartWith:// The target starts the search word
                        {
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText.StartsWith(s))
                                    return true;
                            }
                            return false;
                        }
                    case TextSearchCondition.DoesNotStartWith:// The target doesn't start the search word
                        {
                            bool add = true;
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText.StartsWith(s))
                                {
                                    add = false; break;
                                }
                            }
                            return add;
                        }
                    case TextSearchCondition.EndWith:// The target ends the search word
                        {
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText.EndsWith(s))
                                    return true;
                            }
                            return false;
                        }
                    case TextSearchCondition.DoesNotEndWith:// The target doesn't end with the search word
                        {
                            bool add = true;
                            foreach (string s in searchCodes)
                            {
                                if (searchTargetText.EndsWith(s))
                                {
                                    add = false; break;
                                }
                            }
                            return add;
                        }
                }
            }
            else// Number search
            {
                long searchNumber = DecodeSizeLabel(searchWord);
                switch (parameters.ConditionForNumber)
                {
                    case NumberSearchCondition.Equal:
                        {
                            if (searchTargetNumber == searchNumber)
                                return true;
                            break;
                        }
                    case NumberSearchCondition.DoesNotEqual:
                        {
                            if (searchTargetNumber != searchNumber)
                                return true;
                            break;
                        }
                    case NumberSearchCondition.EqualSmaller:
                        {
                            if (searchTargetNumber <= searchNumber)
                                return true;
                            break;
                        }
                    case NumberSearchCondition.EuqalLarger:
                        {
                            if (searchTargetNumber >= searchNumber)
                                return true;
                            break;
                        }
                    case NumberSearchCondition.Larger:
                        {
                            if (searchTargetNumber > searchNumber)
                                return true;
                            break;
                        }
                    case NumberSearchCondition.Smaller:
                        {
                            if (searchTargetNumber < searchNumber)
                                return true;
                            break;
                        }
                }
            }
            return false;
        }
        private long DecodeSizeLabel(string sizeLabel)
        {
            // Let's see given parameter (size)
            string t = sizeLabel.ToLower();
            t = t.Replace("kb", "");
            t = t.Replace("mb", "");
            t = t.Replace("gb", "");
            t = t.Replace(" ", "");
            double value = 0;
            double.TryParse(t, out value);

            if (sizeLabel.ToLower().Contains("kb"))
                value *= 1024;
            else if (sizeLabel.ToLower().Contains("mb"))
                value *= 1024 * 1024;
            else if (sizeLabel.ToLower().Contains("gb"))
                value *= 1024 * 1024 * 1024;

            return (long)value;
        }
        private void LoadViewers()
        {
            snapshotIndex = 0;
            coverIndex = 0;
            infoTextIndex = 0;
            if (managedListView1.SelectedItems.Count != 1)
            {
                ClearViewers();
            }
            else
            {
                ViewSnapshot();
                ViewCover();
                ViewInfoText();
            }
        }
        private void ClearViewers()
        {
            snapshotsViewer_covers.ClearAll();
            snapshotsViewer_snapshots.ClearAll();
            infoTextViewer1.ClearAll();
        }
        private void ViewSnapshot()
        {
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.Snapshots == null)
            {
                // Clear
                snapshotsViewer_snapshots.ClearAll();
                return;
            }
            // Get the image we need to view
            if (f.Snapshots.Count > 0)
            {
                if (snapshotIndex < f.Snapshots.Count)
                {
                    string path = f.Snapshots[snapshotIndex];
                    if (File.Exists(path))
                    {
                        // Get the image
                        try
                        {
                            snapshotsViewer_snapshots.ViewImage((Bitmap)Image.FromFile(path));
                            // Update status
                            snapshotsViewer_snapshots.UpdateStatus((snapshotIndex + 1).ToString() + "/" + f.Snapshots.Count);
                        }
                        catch { snapshotsViewer_snapshots.ClearImage(); }
                    }
                    else { snapshotsViewer_snapshots.ClearImage(); }
                }
                else
                { snapshotsViewer_snapshots.ClearImage(); }
            }
            else
            {
                // Clear
                snapshotsViewer_snapshots.ClearAll();
            }
        }
        private void ViewCover()
        {
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.Covers == null)
            {
                // Clear
                snapshotsViewer_covers.ClearAll();
                return;
            }
            // Get the image we need to view
            if (f.Covers.Count > 0)
            {
                if (coverIndex < f.Covers.Count)
                {
                    string path = f.Covers[snapshotIndex];
                    if (File.Exists(path))
                    {
                        // Get the image
                        try
                        {
                            snapshotsViewer_covers.ViewImage((Bitmap)Image.FromFile(path));
                            // Update status
                            snapshotsViewer_covers.UpdateStatus((coverIndex + 1).ToString() + "/" + f.Covers.Count);

                        }
                        catch { snapshotsViewer_covers.ClearImage(); }
                    }
                    else { snapshotsViewer_covers.ClearImage(); }
                }
                else
                { snapshotsViewer_covers.ClearImage(); }
            }
            else
            {
                // Clear
                snapshotsViewer_covers.ClearAll();
            }
        }
        private void ViewInfoText()
        {
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.InfoTexts == null)
            {
                // Clear
                infoTextViewer1.ClearAll();
                return;
            }
            // Get the files we need to view
            if (f.InfoTexts.Count > 0)
            {
                if (infoTextIndex < f.InfoTexts.Count)
                {
                    string path = f.InfoTexts[infoTextIndex];
                    if (File.Exists(path))
                    {
                        // Get the file
                        try
                        {
                            infoTextViewer1.ViewText(File.ReadAllText(path));
                            // Update status
                            infoTextViewer1.UpdateStatus((infoTextIndex + 1).ToString() + "/" + f.InfoTexts.Count);
                        }
                        catch { infoTextViewer1.ClearText(); }
                    }
                    else { infoTextViewer1.ClearText(); }
                }
                else
                { infoTextViewer1.ClearText(); }
            }
            else
            {
                // Clear
                infoTextViewer1.ClearAll();
            }
        }

        private void BuildCacheForFolder(DBFolder folder)
        {
            ProgressBar1.Visible = true;
            StatusLabel.Text = Program.ResourceManager.GetString("Status_BuildingCache");
            statusStrip1.Refresh();

            List<string> files = new List<string>(Directory.GetFiles(folder.Path));
            List<DBFile> oldBromCollection = folder.Files;
            folder.Files = new List<DBFile>();

            int x = 0;
            foreach (string file in files)
            {
                // First let's see if this rom already exists
                // This way, we keep old rom information like ratings, covers...etc
                foreach (DBFile oldRom in oldBromCollection)
                {
                    if (oldRom.Path == file)
                    {
                        // Update size just in case
                        oldRom.Size = HelperTools.GetSizeAsBytes(file);
                        oldRom.SizeLabel = HelperTools.GetFileSize(file);
                        folder.Files.Add(oldRom);
                        goto Advance;
                    }
                }
                DBFile rom = new DBFile();
                rom.Path = file;
                rom.Size = HelperTools.GetSizeAsBytes(file);
                rom.SizeLabel = HelperTools.GetFileSize(file);
                #region INES
                if (Path.GetExtension(file).ToLower() == ".nes")
                {
                    rom.Format = DBFileFormat.INES;
                    // Load 
                    RomInfo inf = new RomInfo(file);
                    switch (inf.ReadStatus)
                    {
                        case RomReadResult.Invalid:
                            {
                                rom.BoardName = rom.Mirroring = rom.CHRSize =
                                rom.PRGSize = rom.TvSystem =
                                "N/A (" + Program.ResourceManager.GetString("Status_InvalidRom") + ")";
                                rom.HasSaveRam = false;
                                rom.HasTrainer = false;
                                rom.IsPlaychoice10 = false;
                                rom.IsVSSystem = false;
                                rom.MapperNumber = rom.PRG = rom.CHR = 0;
                                break;
                            }
                        case RomReadResult.Success:
                        case RomReadResult.NotSupportedBoard:
                            {
                                rom.TvSystem = inf.TVSystem.ToString();
                                rom.PRGSize = HelperTools.GetSize(inf.PRGcount * 0x4000);
                                rom.PRG = inf.PRGcount * 0x4000;
                                rom.CHRSize = HelperTools.GetSize(inf.CHRcount * 0x2000);
                                rom.CHR = inf.CHRcount * 0x2000;
                                rom.MapperNumber = inf.INESMapperNumber;
                                rom.Mirroring = inf.Mirroring.ToString();
                                rom.BoardName = inf.MapperBoard;
                                rom.HasSaveRam = inf.HasSaveRam;
                                rom.HasTrainer = inf.HasTrainer;
                                rom.IsPlaychoice10 = inf.IsPlaychoice10;
                                rom.IsVSSystem = inf.IsVSUnisystem;
                                break;
                            }
                    }
                }
                #endregion
                #region Archive
                else if (Path.GetExtension(file).ToLower() == ".rar" ||
                         Path.GetExtension(file).ToLower() == ".zip" ||
                         Path.GetExtension(file).ToLower() == ".7z" ||
                         Path.GetExtension(file).ToLower() == ".tar")
                {
                    rom.Format = DBFileFormat.Archive;
                    rom.BoardName = rom.Mirroring = rom.CHRSize =
                    rom.PRGSize = rom.TvSystem = "N/A";
                    rom.HasSaveRam = false;
                    rom.HasTrainer = false;
                    rom.IsPlaychoice10 = false;
                    rom.IsVSSystem = false;
                    rom.MapperNumber = rom.PRG = rom.CHR = 0;
                }
                #endregion
                folder.Files.Add(rom);

            Advance:
                ProgressBar1.Value = (x * 100) / files.Count;
                x++;
            }
            folder.CacheBuilt = true;
            SaveDB = true;
            ProgressBar1.Visible = false;
            StatusLabel.Text = Program.ResourceManager.GetString("Status_Ready");
        }
        private void ClearControls()
        {
            managedListView1.Items.Clear();
        }
        private void AddNewFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = Program.ResourceManager.GetString("Descreption_BrowseForRomsFolder");
            if (folder.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (!Program.DBManager.DB.IsFolderExist(folder.SelectedPath))
                {
                    DBFolder bfolder = new DBFolder();
                    bfolder.Path = folder.SelectedPath;
                    bfolder.RefreshFolders();
                    Program.DBManager.DB.Folders.Add(bfolder);
                    SaveDB = true;
                    RefreshFolders();
                }
            }
        }
        private void DeleteFolder(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            if (MessageBox.Show(Program.ResourceManager.GetString("Message_AreYouSureYouWantToDeleteSelectedFolderFromTheList"),
                Program.ResourceManager.GetString("MessageCaption_MyNesBrowser"),
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Program.DBManager.DB.Folders.Remove(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
                RefreshFolders();
                ClearControls();
                SaveDB = true;
            }
        }
        private void PlaySelectedRom(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneRomFirst"),
                    Program.ResourceManager.GetString("MessageCaption_PlayRom"));
                return;
            }
            string path = ((DBFile)managedListView1.SelectedItems[0].Tag).Path;
            if (!File.Exists(path))
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThisFileIsNotExist"),
                    Program.ResourceManager.GetString("MessageCaption_PlayRom"));
                return;
            }
            Program.FormMain.Select();
            Program.FormMain.BringToFront();
            // Advance play count
            ((DBFile)managedListView1.SelectedItems[0].Tag).PlayedTimes++;
            // Update
            managedListView1.SelectedItems[0].GetSubItemByID("played times").Text =
                 ((DBFile)managedListView1.SelectedItems[0].Tag).PlayedTimes.ToString();
            Program.FormMain.LoadRom(path, true);

            if (NesCore.ON && Program.Settings.BrowserMinimizeWindowOnRomLoad)
                this.WindowState = FormWindowState.Minimized;
        }

        private void FormBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SaveSettings();
            if (SaveDB)
            {
                Program.DBManager.SaveDatabase();
                SaveDB = false;
            }
        }
        private void ratingSubItem_UpdateRatingRequest(object sender, ManagedListViewRatingChangedArgs e)
        {
            // Get the original value
            ((ManagedListViewRatingSubItem)managedListView1.Items[e.ItemIndex].GetSubItemByID("rating")).Rating =
                ((DBFile)managedListView1.Items[e.ItemIndex].Tag).Rating;
        }
        private void ratingSubItem_RatingChanged(object sender, ManagedListViewRatingChangedArgs e)
        {
            ((DBFile)managedListView1.Items[e.ItemIndex].Tag).Rating =
                ((ManagedListViewRatingSubItem)managedListView1.Items[e.ItemIndex].GetSubItemByID("rating")).Rating;
            SaveDB = true;
        }
        private void managedListView1_AfterColumnReorder(object sender, EventArgs e)
        {
            SaveColumns();
        }
        private void managedListView1_AfterColumnResize(object sender, EventArgs e)
        {
            SaveColumns();
        }
        private void managedListView1_SwitchToColumnsContextMenu(object sender, EventArgs e)
        {
            managedListView1.ContextMenuStrip = contextMenuStrip_columns;
        }
        private void managedListView1_SwitchToNormalContextMenu(object sender, EventArgs e)
        {
            managedListView1.ContextMenuStrip = contextMenuStrip_normal;
        }
        private void contextMenuStrip_columns_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip_columns.Items.Clear();

            foreach (DBColumn item in Program.Settings.DBColumns)
            {
                ToolStripMenuItem mitem = new ToolStripMenuItem();
                mitem.Text = item.Name;
                mitem.Checked = item.Visible;
                contextMenuStrip_columns.Items.Add(mitem);
            }
        }
        private void contextMenuStrip_columns_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int i = 0;
            foreach (DBColumn item in Program.Settings.DBColumns)
            {
                if (item.Name == e.ClickedItem.Text)
                {
                    item.Visible = !item.Visible;
                    ((ToolStripMenuItem)e.ClickedItem).Checked = item.Visible;
                    RefreshColumns();
                    break;
                }
                i++;
            }
            managedListView1.Invalidate();
            SaveColumns();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearViewers();
            if (treeView1.SelectedNode == null)
            {
                toolStripButton_detectInfoTexts.Enabled = toolStripButton_detectSnapshots.Enabled =
             toolStripButton_rebuildCache.Enabled = toolStripButton_deleteFolder.Enabled =
             toolStripButton_refreshRoms.Enabled = toolStripButton_detectCovers.Enabled = false;
                ClearControls();
                return;
            }
            toolStripButton_detectInfoTexts.Enabled = toolStripButton_detectSnapshots.Enabled =
              toolStripButton_detectCovers.Enabled = toolStripButton_refreshRoms.Enabled =
              toolStripButton_rebuildCache.Enabled = true;
            toolStripButton_deleteFolder.Enabled = treeView1.SelectedNode.Parent == null;

            if (((TreeNodeFolder)treeView1.SelectedNode).DBFolder.CacheBuilt)
            {
                RefreshFilesFromFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
            }
            else
            {
                BuildCacheForFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
                RefreshFilesFromFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
                SaveDB = true;
            }
        }
        private void RebuildCacheOfSelectedFolder(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            BuildCacheForFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
            ClearControls();
            RefreshFilesFromFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
            SaveDB = true;
        }
        private void managedListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButton_play.Enabled = managedListView1.SelectedItems.Count == 1;
            LoadViewers();
        }
        private void contextMenuStrip_normal_Opening(object sender, CancelEventArgs e)
        {
            playToolStripMenuItem.Enabled = openFileLocationToolStripMenuItem.Enabled
                = managedListView1.SelectedItems.Count == 1;
        }
        private void managedListView1_EnterPressed(object sender, EventArgs e)
        {
            PlaySelectedRom(this, null);
        }
        private void managedListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PlaySelectedRom(this, null);
        }
        private void managedListView1_ColumnClicked(object sender, ManagedListViewColumnClickArgs e)
        {
            ManagedListViewColumn column = managedListView1.Columns.GetColumnByID(e.ColumnID);
            if (column == null) return;
            bool az = false;
            switch (column.SortMode)
            {
                case ManagedListViewSortMode.AtoZ: az = false; break;
                case ManagedListViewSortMode.None:
                case ManagedListViewSortMode.ZtoA: az = true; break;
            }
            foreach (ManagedListViewColumn cl in managedListView1.Columns)
                cl.SortMode = ManagedListViewSortMode.None;
            // Sort ..
            ((TreeNodeFolder)treeView1.SelectedNode).DBFolder.Files.Sort(new DBFilesComparer(az, e.ColumnID));
            SaveDB = true;
            // Refresh !
            RefreshFilesFromFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
            if (az)
                managedListView1.Columns.GetColumnByID(e.ColumnID).SortMode = ManagedListViewSortMode.AtoZ;
            else
                managedListView1.Columns.GetColumnByID(e.ColumnID).SortMode = ManagedListViewSortMode.ZtoA;
        }
        private void TextBox_find_TextChanged(object sender, EventArgs e)
        {
            if (TextBox_find.Text.Length == 0)
            {
                // Refresh folder
                treeView1_AfterSelect(this, null);
            }
            else
            {
                if (treeView1.SelectedNode == null) return;
                // Start the search timer
                searchTimer = 5;
                timer_search.Start();
            }
        }
        // The search timer
        private void timer_search_Tick(object sender, EventArgs e)
        {
            if (searchTimer > 0)
                searchTimer--;
            else
            {
                timer_search.Stop();
                doSearch = true;
                searchParameters = new SearchParameters(TextBox_find.Text, SearchMode.Name,
                    matchwordToolStripMenuItem.Checked ? TextSearchCondition.Is : TextSearchCondition.Contains,
                     NumberSearchCondition.None, matchcaseToolStripMenuItem.Checked);
                // Do refresh
                RefreshFilesFromFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
                doSearch = false;
            }
        }
        private void QuickSearch(object sender, EventArgs e)
        {
            doSearch = true;
            searchParameters = new SearchParameters(TextBox_find.Text, SearchMode.Name,
                matchwordToolStripMenuItem.Checked ? TextSearchCondition.Is : TextSearchCondition.Contains,
                 NumberSearchCondition.None, matchcaseToolStripMenuItem.Checked);
            // Do refresh
            RefreshFilesFromFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
            doSearch = false;
        }
        private void AdvancedSearch(object sender, EventArgs e)
        {
            foreach (Form f in this.OwnedForms)
            {
                if (f.Tag.ToString() == "find")
                {
                    f.Select();
                    break;
                }
            }
            FormFindRoms frm = new FormFindRoms();
            frm.DoTheSearch += frm_DoTheSearch;
            frm.Show(this);
        }
        private void frm_DoTheSearch(object sender, SearchParameters e)
        {
            doSearch = true;
            searchParameters = e.Clone();
            // Do refresh
            RefreshFilesFromFolder(((TreeNodeFolder)treeView1.SelectedNode).DBFolder);
            doSearch = false;
        }
        private void DetectSnapshots(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_PleaseSelectFolderFirst"),
                   Program.ResourceManager.GetString("MessageCaption_MyNesBrowser"));
                return;
            }
            if (NesCore.ON)
                NesCore.PAUSED = true;
            FormDetectImages frm = new FormDetectImages(((TreeNodeFolder)treeView1.SelectedNode).DBFolder,
                DetectorDetectMode.Snapshots);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveDB = true;
            }
            if (NesCore.ON)
                NesCore.PAUSED = false;
        }
        private void DetectCovers(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_PleaseSelectFolderFirst"),
                Program.ResourceManager.GetString("MessageCaption_MyNesBrowser"));
                return;
            }
            if (NesCore.ON)
                NesCore.PAUSED = true;
            FormDetectImages frm = new FormDetectImages(((TreeNodeFolder)treeView1.SelectedNode).DBFolder,
                DetectorDetectMode.Covers);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveDB = true;
            }
            if (NesCore.ON)
                NesCore.PAUSED = false;
        }
        private void DetectInfoTexts(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_PleaseSelectFolderFirst"),
                Program.ResourceManager.GetString("MessageCaption_MyNesBrowser"));
                return;
            }
            if (NesCore.ON)
                NesCore.PAUSED = true;
            FormDetectImages frm = new FormDetectImages(((TreeNodeFolder)treeView1.SelectedNode).DBFolder,
                DetectorDetectMode.InfoTexts);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SaveDB = true;
            }
            if (NesCore.ON)
                NesCore.PAUSED = false;
        }
        private void contextMenuStrip_folders_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                deleteToolStripMenuItem.Enabled = rebuildCacheToolStripMenuItem.Enabled =
           refreshRomsToolStripMenuItem.Enabled = detectInfoTextFilesToolStripMenuItem.Enabled =
         detectCoversToolStripMenuItem.Enabled = detectSnapshotsToolStripMenuItem.Enabled = false;
                return;
            }
            detectSnapshotsToolStripMenuItem.Enabled = rebuildCacheToolStripMenuItem.Enabled =
           refreshRomsToolStripMenuItem.Enabled = detectInfoTextFilesToolStripMenuItem.Enabled =
           detectCoversToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = treeView1.SelectedNode.Parent == null;
        }
        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneRomFirst"),
                    Program.ResourceManager.GetString("MessageCaption_OpenFileLocation"));
                return;
            }
            string path = ((DBFile)managedListView1.SelectedItems[0].Tag).Path;
            if (!File.Exists(path))
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThisFileIsNotExist"),
                    Program.ResourceManager.GetString("MessageCaption_OpenFileLocation"));
                return;
            }
            try { System.Diagnostics.Process.Start("explorer.exe", @"/select, " + "\"" + path + "\""); }
            catch { }
        }
        private void toolStripButton_refreshRoms_Click(object sender, EventArgs e)
        {
            treeView1_AfterSelect(this, null);
        }
        private void snapshotsViewer_snapshots_RequestAddImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = Program.ResourceManager.GetString("Filter_Image");
            op.Title = Program.ResourceManager.GetString("Title_AddImage");
            op.Multiselect = true;
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

                if (f.Snapshots == null)
                    f.Snapshots = new List<string>();

                foreach (string p in op.FileNames)
                    if (!f.Snapshots.Contains(p))
                        f.Snapshots.Add(p);

                SaveDB = true;

                snapshotIndex = 0;
                ViewSnapshot();
            }
        }
        private void snapshotsViewer_snapshots_RequestEditList(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.Snapshots == null)
                f.Snapshots = new List<string>();
            if (f.Snapshots.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }

            FormEditFilesList frm = new FormEditFilesList(f.Snapshots.ToArray());
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                f.Snapshots = new List<string>(frm.ListItems);

                SaveDB = true;

                snapshotIndex = 0;
                ViewSnapshot();
            }
        }
        private void snapshotsViewer_snapshots_RequestNextImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.Snapshots == null)
            {
                return;
            }
            snapshotIndex = (snapshotIndex + 1) % f.Snapshots.Count;
            ViewSnapshot();
        }
        private void snapshotsViewer_snapshots_RequestPreviuosImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.Snapshots == null)
            {
                return;
            }
            snapshotIndex--;
            if (snapshotIndex < 0)
                snapshotIndex = f.Snapshots.Count - 1;
            ViewSnapshot();
        }
        private void snapshotsViewer_snapshots_RequestRemoveImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.Snapshots == null)
                f.Snapshots = new List<string>();

            if (f.Snapshots.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }
            ManagedMessageBoxResult r = ManagedMessageBox.ShowMessage(
              Program.ResourceManager.GetString("Message_AreYouSureYouWantToRemoveThisSnapshotFromTheList"),
              Program.ResourceManager.GetString("MessageCaption_RemoveSnapshot"),
              new string[] { 
              Program.ResourceManager.GetString("Button_Yes"),
              Program.ResourceManager.GetString("Button_No")
              }, 0, ManagedMessageBoxIcon.Question, false, false, "");
            if (r.ClickedButtonIndex == 0)// Yes
            {
                f.Snapshots.RemoveAt(snapshotIndex);

                SaveDB = true;

                snapshotIndex = 0;
                ViewSnapshot();
            }
        }
        private void snapshotsViewer_snapshots_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.Snapshots == null)
                f.Snapshots = new List<string>();
            if (f.Snapshots.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }

            try { System.Diagnostics.Process.Start(f.Snapshots[snapshotIndex]); }
            catch (Exception ex)
            {
                ManagedMessageBox.ShowErrorMessage(ex.Message);
            }
        }
        private void snapshotsViewer_covers_RequestAddImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = Program.ResourceManager.GetString("Filter_Image");
            op.Title = Program.ResourceManager.GetString("Title_AddImage");
            op.Multiselect = true;
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

                if (f.Covers == null)
                    f.Covers = new List<string>();

                foreach (string p in op.FileNames)
                    if (!f.Covers.Contains(p))
                        f.Covers.Add(p);

                SaveDB = true;

                coverIndex = 0;
                ViewCover();
            }
        }
        private void snapshotsViewer_covers_RequestEditList(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.Covers == null)
                f.Covers = new List<string>();
            if (f.Covers.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }

            FormEditFilesList frm = new FormEditFilesList(f.Covers.ToArray());
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                f.Covers = new List<string>(frm.ListItems);

                SaveDB = true;

                coverIndex = 0;
                ViewCover();
            }
        }
        private void snapshotsViewer_covers_RequestNextImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.Covers == null)
            {
                return;
            }
            coverIndex = (coverIndex + 1) % f.Covers.Count;
            ViewCover();
        }
        private void snapshotsViewer_covers_RequestPreviuosImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.Covers == null)
            {
                return;
            }
            coverIndex--;
            if (coverIndex < 0)
                coverIndex = f.Covers.Count - 1;
            ViewCover();
        }
        private void snapshotsViewer_covers_RequestRemoveImage(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.Covers == null)
                f.Covers = new List<string>();

            if (f.Covers.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }
            ManagedMessageBoxResult r = ManagedMessageBox.ShowMessage(
              Program.ResourceManager.GetString("Message_AreYouSureYouWantToRemoveThisCoverFromTheList"),
              Program.ResourceManager.GetString("MessageCaption_RemoveCover"),
              new string[] { 
              Program.ResourceManager.GetString("Button_Yes"),
              Program.ResourceManager.GetString("Button_No")
              }, 0, ManagedMessageBoxIcon.Question, false, false, "");
            if (r.ClickedButtonIndex == 0)// Yes
            {
                f.Covers.RemoveAt(coverIndex);

                SaveDB = true;

                coverIndex = 0;
                ViewCover();
            }
        }
        private void snapshotsViewer_covers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.Covers == null)
                f.Covers = new List<string>();
            if (f.Covers.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }

            try { System.Diagnostics.Process.Start(f.Covers[coverIndex]); }
            catch (Exception ex)
            {
                ManagedMessageBox.ShowErrorMessage(ex.Message);
            }
        }
        private void infoTextViewer1_RequestAddFile(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = Program.ResourceManager.GetString("Filter_InfoText");
            op.Title = Program.ResourceManager.GetString("Title_AddInfoTextFile");
            op.Multiselect = true;
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

                if (f.InfoTexts == null)
                    f.InfoTexts = new List<string>();

                foreach (string p in op.FileNames)
                    if (!f.InfoTexts.Contains(p))
                        f.InfoTexts.Add(p);

                SaveDB = true;

                infoTextIndex = 0;
                ViewInfoText();
            }
        }
        private void infoTextViewer1_RequestEditFile(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.InfoTexts == null)
                f.InfoTexts = new List<string>();
            if (f.InfoTexts.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }

            try { System.Diagnostics.Process.Start(f.InfoTexts[infoTextIndex]); }
            catch (Exception ex)
            {
                ManagedMessageBox.ShowErrorMessage(ex.Message);
            }
        }
        private void infoTextViewer1_RequestEditList(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_YouMustSelectOneFileFromTheListFirst"));
                return;
            }
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.InfoTexts == null)
                f.InfoTexts = new List<string>();
            if (f.InfoTexts.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }

            FormEditFilesList frm = new FormEditFilesList(f.InfoTexts.ToArray());
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                f.InfoTexts = new List<string>(frm.ListItems);

                SaveDB = true;

                infoTextIndex = 0;
                ViewInfoText();
            }
        }
        private void infoTextViewer1_RequestNextFile(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.InfoTexts == null)
            {
                return;
            }
            infoTextIndex = (infoTextIndex + 1) % f.InfoTexts.Count;
            ViewInfoText();
        }
        private void infoTextViewer1_RequestPreviuosFile(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            // Get the dbfile
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;
            if (f.InfoTexts == null)
            {
                return;
            }
            infoTextIndex--;
            if (infoTextIndex < 0)
                infoTextIndex = f.InfoTexts.Count - 1;
            ViewInfoText();
        }
        private void infoTextViewer1_RequestRemoveFile(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
                return;
            DBFile f = (DBFile)managedListView1.SelectedItems[0].Tag;

            if (f.InfoTexts == null)
                f.InfoTexts = new List<string>();

            if (f.InfoTexts.Count == 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_ThereIsNoFileInTheList"));
                return;
            }
            ManagedMessageBoxResult r = ManagedMessageBox.ShowMessage(
              Program.ResourceManager.GetString("Message_AreYouSureYouWantToRemoveThisInfoTextFileFromTheList"),
              Program.ResourceManager.GetString("MessageCaption_RemoveInfoText"),
              new string[] { 
              Program.ResourceManager.GetString("Button_Yes"),
              Program.ResourceManager.GetString("Button_No")
              }, 0, ManagedMessageBoxIcon.Question, false, false, "");
            if (r.ClickedButtonIndex == 0)// Yes
            {
                f.InfoTexts.RemoveAt(infoTextIndex);

                SaveDB = true;

                infoTextIndex = 0;
                ViewInfoText();
            }
        }
        private void toolStripSplitButton2_DropDownOpening(object sender, EventArgs e)
        {
            switch (managedListView1.ViewMode)
            {
                case ManagedListViewViewMode.Details:
                    {
                        detailsToolStripMenuItem.Checked = true;
                        thumbnailsToolStripMenuItem.Checked = false;
                        break;
                    }
                case ManagedListViewViewMode.Thumbnails:
                    {
                        detailsToolStripMenuItem.Checked = false;
                        thumbnailsToolStripMenuItem.Checked = true;
                        break;
                    }
            }
        }
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managedListView1.ViewMode = ManagedListViewViewMode.Details;
            panel1.Visible = false;
        }
        private void thumbnailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managedListView1.ViewMode = ManagedListViewViewMode.Thumbnails;
            panel1.Visible = true;
        }
        // Draw        
        private void managedListView1_DrawItem(object sender, ManagedListViewItemDrawArgs e)
        {
            DBFile f = (DBFile)managedListView1.Items[e.ItemIndex].Tag;
            e.TextToDraw = Path.GetFileName(f.Path);
            switch (comboBox1.SelectedIndex)
            {
                case 0:// Auto
                    {
                        // In this case we show thumb using priority
                        // Get the dbfile

                        if (f.Snapshots != null)
                        {
                            if (f.Snapshots.Count > 0)
                            {
                                // First file
                                try
                                {
                                    e.ImageToDraw = Image.FromFile(f.Snapshots[0]);
                                    return;
                                }
                                catch
                                {

                                }
                            }
                        }
                        // Reached here so use covers !
                        if (f.Covers != null)
                        {
                            if (f.Covers.Count > 0)
                            {
                                // First file
                                try
                                {
                                    e.ImageToDraw = Image.FromFile(f.Covers[0]);
                                    return;
                                }
                                catch
                                {

                                }
                            }
                        }

                        break;
                    }
                case 1:// Snapshot
                    {
                        if (f.Snapshots != null)
                        {
                            if (f.Snapshots.Count > 0)
                            {
                                // First file
                                try
                                {
                                    e.ImageToDraw = Image.FromFile(f.Snapshots[0]);
                                    return;
                                }
                                catch
                                {

                                }
                            }
                        }
                        break;
                    }
                case 2:// Cover
                    {
                        if (f.Covers != null)
                        {
                            if (f.Covers.Count > 0)
                            {
                                // First file
                                try
                                {
                                    e.ImageToDraw = Image.FromFile(f.Covers[0]);
                                    return;
                                }
                                catch
                                {

                                }
                            }
                        }
                        break;
                    }
            }
            // Reached here; no image to use so use default image
            switch (f.Format)
            {
                case DBFileFormat.INES: e.ImageToDraw = imageList_files.Images[0]; break;
                case DBFileFormat.Archive: e.ImageToDraw = imageList_files.Images[1]; break;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            managedListView1.ThunmbnailsHeight = managedListView1.ThunmbnailsWidth = trackBar1.Value;
        }
        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            switch (managedListView1.ViewMode)
            {
                case ManagedListViewViewMode.Details: managedListView1.ViewMode = ManagedListViewViewMode.Thumbnails; break;
                case ManagedListViewViewMode.Thumbnails: managedListView1.ViewMode = ManagedListViewViewMode.Details; break;
            }
        }
    }
}
