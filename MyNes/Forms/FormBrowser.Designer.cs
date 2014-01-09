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
namespace MyNes
{
    partial class FormBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBrowser));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_AddFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_deleteFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_rebuildCache = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_refreshRoms = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_detectSnapshots = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_detectCovers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_detectInfoTexts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_play = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TextBox_find = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.matchcaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_romsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_folders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshRomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.detectSnapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectCoversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectInfoTextFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_folders = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.snapshotsViewer_snapshots = new MyNes.SnapshotsViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.snapshotsViewer_covers = new MyNes.SnapshotsViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.infoTextViewer1 = new MyNes.InfoTextViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.managedListView1 = new MLV.ManagedListView();
            this.contextMenuStrip_normal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_files = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip_columns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer_search = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_folders.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip_normal.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_AddFolder,
            this.toolStripButton_deleteFolder,
            this.toolStripSeparator1,
            this.toolStripButton_rebuildCache,
            this.toolStripButton_refreshRoms,
            this.toolStripSeparator5,
            this.toolStripButton_detectSnapshots,
            this.toolStripButton_detectCovers,
            this.toolStripButton_detectInfoTexts,
            this.toolStripSeparator2,
            this.toolStripButton_play,
            this.toolStripSeparator4,
            this.TextBox_find,
            this.toolStripSplitButton1,
            this.toolStripSeparator9,
            this.toolStripSplitButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(702, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_AddFolder
            // 
            this.toolStripButton_AddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddFolder.Image = global::MyNes.Properties.Resources.folder_add;
            this.toolStripButton_AddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddFolder.Name = "toolStripButton_AddFolder";
            this.toolStripButton_AddFolder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddFolder.Text = "Add new folder";
            this.toolStripButton_AddFolder.Click += new System.EventHandler(this.AddNewFolder);
            // 
            // toolStripButton_deleteFolder
            // 
            this.toolStripButton_deleteFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_deleteFolder.Enabled = false;
            this.toolStripButton_deleteFolder.Image = global::MyNes.Properties.Resources.folder_delete;
            this.toolStripButton_deleteFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_deleteFolder.Name = "toolStripButton_deleteFolder";
            this.toolStripButton_deleteFolder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_deleteFolder.Text = "REmove selected folder";
            this.toolStripButton_deleteFolder.Click += new System.EventHandler(this.DeleteFolder);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_rebuildCache
            // 
            this.toolStripButton_rebuildCache.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_rebuildCache.Enabled = false;
            this.toolStripButton_rebuildCache.Image = global::MyNes.Properties.Resources.folder_explore;
            this.toolStripButton_rebuildCache.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_rebuildCache.Name = "toolStripButton_rebuildCache";
            this.toolStripButton_rebuildCache.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_rebuildCache.Text = "Rebuild cache";
            this.toolStripButton_rebuildCache.ToolTipText = "Rebuild cache of selected folder";
            this.toolStripButton_rebuildCache.Click += new System.EventHandler(this.RebuildCacheOfSelectedFolder);
            // 
            // toolStripButton_refreshRoms
            // 
            this.toolStripButton_refreshRoms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_refreshRoms.Enabled = false;
            this.toolStripButton_refreshRoms.Image = global::MyNes.Properties.Resources.folder_go;
            this.toolStripButton_refreshRoms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_refreshRoms.Name = "toolStripButton_refreshRoms";
            this.toolStripButton_refreshRoms.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_refreshRoms.Text = "Refresh roms";
            this.toolStripButton_refreshRoms.ToolTipText = "Refresh roms...\r\n(Reload the roms from selected folder\r\nwithout rebuilding cache)" +
    "";
            this.toolStripButton_refreshRoms.Click += new System.EventHandler(this.toolStripButton_refreshRoms_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_detectSnapshots
            // 
            this.toolStripButton_detectSnapshots.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_detectSnapshots.Enabled = false;
            this.toolStripButton_detectSnapshots.Image = global::MyNes.Properties.Resources.folder_image;
            this.toolStripButton_detectSnapshots.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_detectSnapshots.Name = "toolStripButton_detectSnapshots";
            this.toolStripButton_detectSnapshots.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_detectSnapshots.Text = "Detect snapshots of selected folder";
            this.toolStripButton_detectSnapshots.ToolTipText = "Detect snapshots for the rom(s) of selected folder....";
            this.toolStripButton_detectSnapshots.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // toolStripButton_detectCovers
            // 
            this.toolStripButton_detectCovers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_detectCovers.Enabled = false;
            this.toolStripButton_detectCovers.Image = global::MyNes.Properties.Resources.folder_picture;
            this.toolStripButton_detectCovers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_detectCovers.Name = "toolStripButton_detectCovers";
            this.toolStripButton_detectCovers.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_detectCovers.Text = "Detect covers for roms of selected folder....";
            this.toolStripButton_detectCovers.Click += new System.EventHandler(this.DetectCovers);
            // 
            // toolStripButton_detectInfoTexts
            // 
            this.toolStripButton_detectInfoTexts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_detectInfoTexts.Enabled = false;
            this.toolStripButton_detectInfoTexts.Image = global::MyNes.Properties.Resources.folder_page;
            this.toolStripButton_detectInfoTexts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_detectInfoTexts.Name = "toolStripButton_detectInfoTexts";
            this.toolStripButton_detectInfoTexts.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_detectInfoTexts.Text = "Detect info text files for selected folder";
            this.toolStripButton_detectInfoTexts.ToolTipText = "Detect info text files for the rom(s) of selected folder...";
            this.toolStripButton_detectInfoTexts.Click += new System.EventHandler(this.DetectInfoTexts);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_play
            // 
            this.toolStripButton_play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_play.Enabled = false;
            this.toolStripButton_play.Image = global::MyNes.Properties.Resources.control_play;
            this.toolStripButton_play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_play.Name = "toolStripButton_play";
            this.toolStripButton_play.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_play.Text = "Play selected rom";
            this.toolStripButton_play.Click += new System.EventHandler(this.PlaySelectedRom);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // TextBox_find
            // 
            this.TextBox_find.Name = "TextBox_find";
            this.TextBox_find.Size = new System.Drawing.Size(200, 25);
            this.TextBox_find.ToolTipText = resources.GetString("TextBox_find.ToolTipText");
            this.TextBox_find.TextChanged += new System.EventHandler(this.TextBox_find_TextChanged);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.advancedSearchToolStripMenuItem,
            this.toolStripSeparator3,
            this.matchcaseToolStripMenuItem,
            this.matchwordToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::MyNes.Properties.Resources.find;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "Find roms..";
            this.toolStripSplitButton1.ToolTipText = "Find roms..\r\n(Click to perform a quick search for rom name ....)";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.QuickSearch);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            this.searchToolStripMenuItem.ToolTipText = "Perform a quick search with these parameters:\r\n* Search for rom name\r\n* Match wor" +
    "d determines the condition:\r\n  True = Is, false = Contains.";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.QuickSearch);
            // 
            // advancedSearchToolStripMenuItem
            // 
            this.advancedSearchToolStripMenuItem.Name = "advancedSearchToolStripMenuItem";
            this.advancedSearchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.advancedSearchToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.advancedSearchToolStripMenuItem.Text = "Advanced search...";
            this.advancedSearchToolStripMenuItem.ToolTipText = "Do an advanced search with all possible options.";
            this.advancedSearchToolStripMenuItem.Click += new System.EventHandler(this.AdvancedSearch);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(210, 6);
            // 
            // matchcaseToolStripMenuItem
            // 
            this.matchcaseToolStripMenuItem.CheckOnClick = true;
            this.matchcaseToolStripMenuItem.Name = "matchcaseToolStripMenuItem";
            this.matchcaseToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.matchcaseToolStripMenuItem.Text = "Match &case";
            // 
            // matchwordToolStripMenuItem
            // 
            this.matchwordToolStripMenuItem.CheckOnClick = true;
            this.matchwordToolStripMenuItem.Name = "matchwordToolStripMenuItem";
            this.matchwordToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.matchwordToolStripMenuItem.Text = "Match &word";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.thumbnailsToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::MyNes.Properties.Resources.application_view_tile;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton2.Text = "List view mode";
            this.toolStripSplitButton2.ToolTipText = "List view mode";
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.toolStripSplitButton2_ButtonClick);
            this.toolStripSplitButton2.DropDownOpening += new System.EventHandler(this.toolStripSplitButton2_DropDownOpening);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.detailsToolStripMenuItem.Text = "&Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // thumbnailsToolStripMenuItem
            // 
            this.thumbnailsToolStripMenuItem.Name = "thumbnailsToolStripMenuItem";
            this.thumbnailsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thumbnailsToolStripMenuItem.Text = "&Thumbnails";
            this.thumbnailsToolStripMenuItem.Click += new System.EventHandler(this.thumbnailsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgressBar1,
            this.toolStripStatusLabel1,
            this.StatusLabel_romsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(702, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(42, 17);
            this.StatusLabel.Text = "Ready.";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.ProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Enabled = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // StatusLabel_romsCount
            // 
            this.StatusLabel_romsCount.Name = "StatusLabel_romsCount";
            this.StatusLabel_romsCount.Size = new System.Drawing.Size(30, 17);
            this.StatusLabel_romsCount.Text = "0 / 0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(702, 367);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(212, 367);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 192);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folders";
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip_folders;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList_folders;
            this.treeView1.Location = new System.Drawing.Point(3, 16);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(206, 173);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip_folders
            // 
            this.contextMenuStrip_folders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator6,
            this.refreshRomsToolStripMenuItem,
            this.rebuildCacheToolStripMenuItem,
            this.toolStripSeparator7,
            this.detectSnapshotsToolStripMenuItem,
            this.detectCoversToolStripMenuItem,
            this.detectInfoTextFilesToolStripMenuItem});
            this.contextMenuStrip_folders.Name = "contextMenuStrip_folders";
            this.contextMenuStrip_folders.Size = new System.Drawing.Size(179, 170);
            this.contextMenuStrip_folders.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_folders_Opening);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addFolderToolStripMenuItem.Text = "Add folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.AddNewFolder);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteFolder);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(175, 6);
            // 
            // refreshRomsToolStripMenuItem
            // 
            this.refreshRomsToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_go;
            this.refreshRomsToolStripMenuItem.Name = "refreshRomsToolStripMenuItem";
            this.refreshRomsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.refreshRomsToolStripMenuItem.Text = "Refresh roms";
            this.refreshRomsToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton_refreshRoms_Click);
            // 
            // rebuildCacheToolStripMenuItem
            // 
            this.rebuildCacheToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_explore;
            this.rebuildCacheToolStripMenuItem.Name = "rebuildCacheToolStripMenuItem";
            this.rebuildCacheToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.rebuildCacheToolStripMenuItem.Text = "Rebuild cache";
            this.rebuildCacheToolStripMenuItem.Click += new System.EventHandler(this.RebuildCacheOfSelectedFolder);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(175, 6);
            // 
            // detectSnapshotsToolStripMenuItem
            // 
            this.detectSnapshotsToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_image;
            this.detectSnapshotsToolStripMenuItem.Name = "detectSnapshotsToolStripMenuItem";
            this.detectSnapshotsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.detectSnapshotsToolStripMenuItem.Text = "Detect snapshots";
            this.detectSnapshotsToolStripMenuItem.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // detectCoversToolStripMenuItem
            // 
            this.detectCoversToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_picture;
            this.detectCoversToolStripMenuItem.Name = "detectCoversToolStripMenuItem";
            this.detectCoversToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.detectCoversToolStripMenuItem.Text = "Detect covers";
            this.detectCoversToolStripMenuItem.Click += new System.EventHandler(this.DetectCovers);
            // 
            // detectInfoTextFilesToolStripMenuItem
            // 
            this.detectInfoTextFilesToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_page;
            this.detectInfoTextFilesToolStripMenuItem.Name = "detectInfoTextFilesToolStripMenuItem";
            this.detectInfoTextFilesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.detectInfoTextFilesToolStripMenuItem.Text = "Detect info text files";
            this.detectInfoTextFilesToolStripMenuItem.Click += new System.EventHandler(this.DetectInfoTexts);
            // 
            // imageList_folders
            // 
            this.imageList_folders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_folders.ImageStream")));
            this.imageList_folders.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_folders.Images.SetKeyName(0, "folder.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(212, 171);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.snapshotsViewer_snapshots);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(204, 145);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Snapshots";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // snapshotsViewer_snapshots
            // 
            this.snapshotsViewer_snapshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snapshotsViewer_snapshots.Location = new System.Drawing.Point(3, 3);
            this.snapshotsViewer_snapshots.Name = "snapshotsViewer_snapshots";
            this.snapshotsViewer_snapshots.Size = new System.Drawing.Size(198, 139);
            this.snapshotsViewer_snapshots.TabIndex = 0;
            this.snapshotsViewer_snapshots.RequestAddImage += new System.EventHandler(this.snapshotsViewer_snapshots_RequestAddImage);
            this.snapshotsViewer_snapshots.RequestRemoveImage += new System.EventHandler(this.snapshotsViewer_snapshots_RequestRemoveImage);
            this.snapshotsViewer_snapshots.RequestEditList += new System.EventHandler(this.snapshotsViewer_snapshots_RequestEditList);
            this.snapshotsViewer_snapshots.RequestPreviuosImage += new System.EventHandler(this.snapshotsViewer_snapshots_RequestPreviuosImage);
            this.snapshotsViewer_snapshots.RequestNextImage += new System.EventHandler(this.snapshotsViewer_snapshots_RequestNextImage);
            this.snapshotsViewer_snapshots.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.snapshotsViewer_snapshots_MouseDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.snapshotsViewer_covers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(204, 145);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Covers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // snapshotsViewer_covers
            // 
            this.snapshotsViewer_covers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snapshotsViewer_covers.Location = new System.Drawing.Point(3, 3);
            this.snapshotsViewer_covers.Name = "snapshotsViewer_covers";
            this.snapshotsViewer_covers.Size = new System.Drawing.Size(198, 139);
            this.snapshotsViewer_covers.TabIndex = 0;
            this.snapshotsViewer_covers.RequestAddImage += new System.EventHandler(this.snapshotsViewer_covers_RequestAddImage);
            this.snapshotsViewer_covers.RequestRemoveImage += new System.EventHandler(this.snapshotsViewer_covers_RequestRemoveImage);
            this.snapshotsViewer_covers.RequestEditList += new System.EventHandler(this.snapshotsViewer_covers_RequestEditList);
            this.snapshotsViewer_covers.RequestPreviuosImage += new System.EventHandler(this.snapshotsViewer_covers_RequestPreviuosImage);
            this.snapshotsViewer_covers.RequestNextImage += new System.EventHandler(this.snapshotsViewer_covers_RequestNextImage);
            this.snapshotsViewer_covers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.snapshotsViewer_covers_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.infoTextViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(204, 145);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // infoTextViewer1
            // 
            this.infoTextViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTextViewer1.Location = new System.Drawing.Point(3, 3);
            this.infoTextViewer1.Name = "infoTextViewer1";
            this.infoTextViewer1.Size = new System.Drawing.Size(198, 139);
            this.infoTextViewer1.TabIndex = 0;
            this.infoTextViewer1.RequestAddFile += new System.EventHandler(this.infoTextViewer1_RequestAddFile);
            this.infoTextViewer1.RequestRemoveFile += new System.EventHandler(this.infoTextViewer1_RequestRemoveFile);
            this.infoTextViewer1.RequestEditList += new System.EventHandler(this.infoTextViewer1_RequestEditList);
            this.infoTextViewer1.RequestPreviuosFile += new System.EventHandler(this.infoTextViewer1_RequestPreviuosFile);
            this.infoTextViewer1.RequestNextFile += new System.EventHandler(this.infoTextViewer1_RequestNextFile);
            this.infoTextViewer1.RequestEditFile += new System.EventHandler(this.infoTextViewer1_RequestEditFile);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.managedListView1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 367);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // managedListView1
            // 
            this.managedListView1.AllowColumnsReorder = true;
            this.managedListView1.AllowItemsDragAndDrop = true;
            this.managedListView1.AutoSetWheelScrollSpeed = true;
            this.managedListView1.ChangeColumnSortModeWhenClick = true;
            this.managedListView1.ColumnClickColor = System.Drawing.Color.PaleVioletRed;
            this.managedListView1.ColumnColor = System.Drawing.Color.Silver;
            this.managedListView1.ColumnHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView1.ContextMenuStrip = this.contextMenuStrip_normal;
            this.managedListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedListView1.DrawHighlight = true;
            this.managedListView1.ImagesList = this.imageList_files;
            this.managedListView1.ItemHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView1.ItemMouseOverColor = System.Drawing.Color.LightGray;
            this.managedListView1.ItemSpecialColor = System.Drawing.Color.YellowGreen;
            this.managedListView1.Location = new System.Drawing.Point(3, 16);
            this.managedListView1.Name = "managedListView1";
            this.managedListView1.Size = new System.Drawing.Size(480, 318);
            this.managedListView1.StretchThumbnailsToFit = false;
            this.managedListView1.TabIndex = 0;
            this.managedListView1.ThunmbnailsHeight = 50;
            this.managedListView1.ThunmbnailsWidth = 50;
            this.managedListView1.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.managedListView1.WheelScrollSpeed = 18;
            this.managedListView1.DrawItem += new System.EventHandler<MLV.ManagedListViewItemDrawArgs>(this.managedListView1_DrawItem);
            this.managedListView1.SelectedIndexChanged += new System.EventHandler(this.managedListView1_SelectedIndexChanged);
            this.managedListView1.ColumnClicked += new System.EventHandler<MLV.ManagedListViewColumnClickArgs>(this.managedListView1_ColumnClicked);
            this.managedListView1.EnterPressed += new System.EventHandler(this.managedListView1_EnterPressed);
            this.managedListView1.SwitchToColumnsContextMenu += new System.EventHandler(this.managedListView1_SwitchToColumnsContextMenu);
            this.managedListView1.SwitchToNormalContextMenu += new System.EventHandler(this.managedListView1_SwitchToNormalContextMenu);
            this.managedListView1.AfterColumnResize += new System.EventHandler(this.managedListView1_AfterColumnResize);
            this.managedListView1.AfterColumnReorder += new System.EventHandler(this.managedListView1_AfterColumnReorder);
            this.managedListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.managedListView1_MouseDoubleClick);
            // 
            // contextMenuStrip_normal
            // 
            this.contextMenuStrip_normal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.toolStripSeparator8,
            this.openFileLocationToolStripMenuItem});
            this.contextMenuStrip_normal.Name = "contextMenuStrip_normal";
            this.contextMenuStrip_normal.Size = new System.Drawing.Size(169, 54);
            this.contextMenuStrip_normal.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_normal_Opening);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Enabled = false;
            this.playToolStripMenuItem.Image = global::MyNes.Properties.Resources.control_play;
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.PlaySelectedRom);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Enabled = false;
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open file location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // imageList_files
            // 
            this.imageList_files.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_files.ImageStream")));
            this.imageList_files.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_files.Images.SetKeyName(0, "INES.ico");
            this.imageList_files.Images.SetKeyName(1, "compress.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 30);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(130, 6);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Minimum = 25;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(123, 21);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Auto",
            "Snapshot",
            "Cover"});
            this.comboBox1.Location = new System.Drawing.Point(3, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // contextMenuStrip_columns
            // 
            this.contextMenuStrip_columns.Name = "contextMenuStrip_columns";
            this.contextMenuStrip_columns.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_columns.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_columns_Opening);
            this.contextMenuStrip_columns.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_columns_ItemClicked);
            // 
            // timer_search
            // 
            this.timer_search.Tick += new System.EventHandler(this.timer_search_Tick);
            // 
            // FormBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 414);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FormBrowser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "My Nes Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBrowser_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip_folders.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip_normal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddFolder;
        private System.Windows.Forms.TreeView treeView1;
        private MLV.ManagedListView managedListView1;
        private System.Windows.Forms.ImageList imageList_folders;
        private System.Windows.Forms.ToolStripButton toolStripButton_deleteFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox TextBox_find;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem matchcaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchwordToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_normal;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_columns;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_romsCount;
        private System.Windows.Forms.ImageList imageList_files;
        private System.Windows.Forms.ToolStripButton toolStripButton_rebuildCache;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_play;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem advancedSearchToolStripMenuItem;
        private System.Windows.Forms.Timer timer_search;
        private System.Windows.Forms.ToolStripButton toolStripButton_detectSnapshots;
        private System.Windows.Forms.ToolStripButton toolStripButton_detectInfoTexts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_folders;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem rebuildCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem detectSnapshotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectInfoTextFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_refreshRoms;
        private System.Windows.Forms.ToolStripMenuItem refreshRomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_detectCovers;
        private System.Windows.Forms.ToolStripMenuItem detectCoversToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private SnapshotsViewer snapshotsViewer_snapshots;
        private SnapshotsViewer snapshotsViewer_covers;
        private InfoTextViewer infoTextViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thumbnailsToolStripMenuItem;
    }
}