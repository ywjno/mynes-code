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
namespace MyNes.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            MLV.ManagedListViewColumnsCollection managedListViewColumnsCollection1 = new MLV.ManagedListViewColumnsCollection();
            MLV.ManagedListViewItemsCollection managedListViewItemsCollection1 = new MLV.ManagedListViewItemsCollection();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opendatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.recordSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.rebuildcacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.detectsnapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectCoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectinfoTextsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.romInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.softResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameGenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rendererToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.connectZapperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connect4PlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.emulationSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.nTSCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dENDYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNESHeaderEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulationSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMyNesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripSnapshot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.openContainerFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripCover = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.locateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_romsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ManagedListView1 = new MLV.ManagedListView();
            this.contextMenuStrip_roms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.locateOnDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.resetPlaydTimesCounterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetRatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.setSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
            this.romInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_thumbnailsPanel = new System.Windows.Forms.Panel();
            this.label_thumbnailsSize = new System.Windows.Forms.Label();
            this.trackBar_thumbnailsZoom = new System.Windows.Forms.TrackBar();
            this.comboBox_thumbnailsMode = new System.Windows.Forms.ComboBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonCreateFolder = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.buttonPad = new System.Windows.Forms.ToolStripButton();
            this.buttonPpu = new System.Windows.Forms.ToolStripButton();
            this.buttonApu = new System.Windows.Forms.ToolStripButton();
            this.buttonPalette = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonConsole = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imageViewer_snaps = new MyNes.ImageViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageViewer_covers = new MyNes.ImageViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox_romInfo = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_folders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.rebuildCacheToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.detectSnapshotsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.detectCoversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectInfoTextsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ComboBox_filter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ComboBox_filterBy = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.FilterOption_MatchCase = new System.Windows.Forms.ToolStripButton();
            this.FilterOption_MachWord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.ThumbnailsViewSwitch = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip_columns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editINESHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.contextMenuStripSnapshot.SuspendLayout();
            this.contextMenuStripCover.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_roms.SuspendLayout();
            this.panel_thumbnailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_thumbnailsZoom)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip_folders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "cartridge.png");
            this.imageList.Images.SetKeyName(2, "page_white_zip.png");
            this.imageList.Images.SetKeyName(3, "image.png");
            this.imageList.Images.SetKeyName(4, "camera.png");
            this.imageList.Images.SetKeyName(5, "information.png");
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.browserToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.emulationToolStripMenuItem,
            this.stateToolStripMenuItem,
            this.gameGenieToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRomToolStripMenuItem,
            this.opendatabaseToolStripMenuItem1,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator14,
            this.saveDatabaseToolStripMenuItem1,
            this.saveDatabaseasToolStripMenuItem1,
            this.toolStripSeparator9,
            this.recordSoundToolStripMenuItem,
            this.toolStripSeparator15,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // openRomToolStripMenuItem
            // 
            this.openRomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openRomToolStripMenuItem.Image")));
            this.openRomToolStripMenuItem.Name = "openRomToolStripMenuItem";
            this.openRomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openRomToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.openRomToolStripMenuItem.Text = "&Open ROM";
            this.openRomToolStripMenuItem.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // opendatabaseToolStripMenuItem1
            // 
            this.opendatabaseToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("opendatabaseToolStripMenuItem1.Image")));
            this.opendatabaseToolStripMenuItem1.Name = "opendatabaseToolStripMenuItem1";
            this.opendatabaseToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.opendatabaseToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.opendatabaseToolStripMenuItem1.Text = "Open &Database";
            this.opendatabaseToolStripMenuItem1.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("recentFilesToolStripMenuItem.Image")));
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.recentFilesToolStripMenuItem.Text = "&Recent";
            this.recentFilesToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.recentFilesToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(226, 6);
            // 
            // saveDatabaseToolStripMenuItem1
            // 
            this.saveDatabaseToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveDatabaseToolStripMenuItem1.Image")));
            this.saveDatabaseToolStripMenuItem1.Name = "saveDatabaseToolStripMenuItem1";
            this.saveDatabaseToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveDatabaseToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.saveDatabaseToolStripMenuItem1.Text = "&Save Database";
            this.saveDatabaseToolStripMenuItem1.Click += new System.EventHandler(this.saveDatabaseToolStripMenuItem_Click);
            // 
            // saveDatabaseasToolStripMenuItem1
            // 
            this.saveDatabaseasToolStripMenuItem1.Name = "saveDatabaseasToolStripMenuItem1";
            this.saveDatabaseasToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.saveDatabaseasToolStripMenuItem1.Text = "Save Database &As...";
            this.saveDatabaseasToolStripMenuItem1.Click += new System.EventHandler(this.saveDatabaseAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(226, 6);
            // 
            // recordSoundToolStripMenuItem
            // 
            this.recordSoundToolStripMenuItem.Enabled = false;
            this.recordSoundToolStripMenuItem.Name = "recordSoundToolStripMenuItem";
            this.recordSoundToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.recordSoundToolStripMenuItem.Text = "Re&cord sound";
            this.recordSoundToolStripMenuItem.Click += new System.EventHandler(this.recordSoundToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(226, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem,
            this.deleteFolderToolStripMenuItem,
            this.toolStripSeparator8,
            this.rebuildcacheToolStripMenuItem,
            this.toolStripSeparator17,
            this.detectsnapshotsToolStripMenuItem,
            this.detectCoverToolStripMenuItem,
            this.detectinfoTextsToolStripMenuItem});
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.browserToolStripMenuItem.Text = "&Browser";
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFolderToolStripMenuItem.Image")));
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addFolderToolStripMenuItem.Text = "&Add folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Enabled = false;
            this.deleteFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFolderToolStripMenuItem.Image")));
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteFolderToolStripMenuItem.Text = "&Delete folder";
            this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(161, 6);
            // 
            // rebuildcacheToolStripMenuItem
            // 
            this.rebuildcacheToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rebuildcacheToolStripMenuItem.Image")));
            this.rebuildcacheToolStripMenuItem.Name = "rebuildcacheToolStripMenuItem";
            this.rebuildcacheToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rebuildcacheToolStripMenuItem.Text = "Rebuild &cache";
            this.rebuildcacheToolStripMenuItem.Click += new System.EventHandler(this.rebuildCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(161, 6);
            // 
            // detectsnapshotsToolStripMenuItem
            // 
            this.detectsnapshotsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("detectsnapshotsToolStripMenuItem.Image")));
            this.detectsnapshotsToolStripMenuItem.Name = "detectsnapshotsToolStripMenuItem";
            this.detectsnapshotsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.detectsnapshotsToolStripMenuItem.Text = "Detect &snapshots";
            this.detectsnapshotsToolStripMenuItem.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // detectCoverToolStripMenuItem
            // 
            this.detectCoverToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("detectCoverToolStripMenuItem.Image")));
            this.detectCoverToolStripMenuItem.Name = "detectCoverToolStripMenuItem";
            this.detectCoverToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.detectCoverToolStripMenuItem.Text = "Detect co&ver";
            this.detectCoverToolStripMenuItem.Click += new System.EventHandler(this.DetectCovers);
            // 
            // detectinfoTextsToolStripMenuItem
            // 
            this.detectinfoTextsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("detectinfoTextsToolStripMenuItem.Image")));
            this.detectinfoTextsToolStripMenuItem.Name = "detectinfoTextsToolStripMenuItem";
            this.detectinfoTextsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.detectinfoTextsToolStripMenuItem.Text = "Detect &info texts";
            this.detectinfoTextsToolStripMenuItem.Click += new System.EventHandler(this.DetectInfoTexts);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsToolStripMenuItem,
            this.toolStripSeparator29,
            this.toolStripToolStripMenuItem,
            this.menuStripToolStripMenuItem,
            this.toolStripSeparator11,
            this.romInfoToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.columnsToolStripMenuItem.Text = "&Columns";
            this.columnsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.columnsToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripToolStripMenuItem
            // 
            this.toolStripToolStripMenuItem.Checked = true;
            this.toolStripToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripToolStripMenuItem.Name = "toolStripToolStripMenuItem";
            this.toolStripToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.toolStripToolStripMenuItem.Text = "Toolstrip";
            this.toolStripToolStripMenuItem.CheckedChanged += new System.EventHandler(this.toolStripToolStripMenuItem_CheckedChanged);
            this.toolStripToolStripMenuItem.Click += new System.EventHandler(this.toolStripToolStripMenuItem_Click);
            // 
            // menuStripToolStripMenuItem
            // 
            this.menuStripToolStripMenuItem.Checked = true;
            this.menuStripToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuStripToolStripMenuItem.Name = "menuStripToolStripMenuItem";
            this.menuStripToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.menuStripToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.menuStripToolStripMenuItem.Text = "Menustrip";
            this.menuStripToolStripMenuItem.CheckedChanged += new System.EventHandler(this.menuStripToolStripMenuItem_CheckedChanged);
            this.menuStripToolStripMenuItem.Click += new System.EventHandler(this.menuStripToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(199, 6);
            // 
            // romInfoToolStripMenuItem
            // 
            this.romInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("romInfoToolStripMenuItem.Image")));
            this.romInfoToolStripMenuItem.Name = "romInfoToolStripMenuItem";
            this.romInfoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.romInfoToolStripMenuItem.Text = "&ROM Information";
            this.romInfoToolStripMenuItem.Click += new System.EventHandler(this.romInfoToolStripMenuItem_Click);
            // 
            // emulationToolStripMenuItem
            // 
            this.emulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resumeToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator7,
            this.softResetToolStripMenuItem,
            this.hardResetToolStripMenuItem});
            this.emulationToolStripMenuItem.Name = "emulationToolStripMenuItem";
            this.emulationToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.emulationToolStripMenuItem.Text = "&Emulation";
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resumeToolStripMenuItem.Image")));
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.resumeToolStripMenuItem.Text = "&Toggle Pause";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.stopToolStripMenuItem.Text = "&Turn Off";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(161, 6);
            // 
            // softResetToolStripMenuItem
            // 
            this.softResetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("softResetToolStripMenuItem.Image")));
            this.softResetToolStripMenuItem.Name = "softResetToolStripMenuItem";
            this.softResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.softResetToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.softResetToolStripMenuItem.Text = "So&ft Reset";
            this.softResetToolStripMenuItem.Click += new System.EventHandler(this.softResetToolStripMenuItem_Click);
            // 
            // hardResetToolStripMenuItem
            // 
            this.hardResetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hardResetToolStripMenuItem.Image")));
            this.hardResetToolStripMenuItem.Name = "hardResetToolStripMenuItem";
            this.hardResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.hardResetToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.hardResetToolStripMenuItem.Text = "Ha&rd Reset";
            this.hardResetToolStripMenuItem.Click += new System.EventHandler(this.hardResetToolStripMenuItem_Click);
            // 
            // stateToolStripMenuItem
            // 
            this.stateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slotToolStripMenuItem,
            this.toolStripSeparator12,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator13,
            this.loadToolStripMenuItem,
            this.loadAsToolStripMenuItem});
            this.stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            this.stateToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.stateToolStripMenuItem.Text = "S&tate";
            this.stateToolStripMenuItem.DropDownOpening += new System.EventHandler(this.stateToolStripMenuItem_DropDownOpening);
            // 
            // slotToolStripMenuItem
            // 
            this.slotToolStripMenuItem.Name = "slotToolStripMenuItem";
            this.slotToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.slotToolStripMenuItem.Text = "&Slot";
            this.slotToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.slotToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(168, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveToolStripMenuItem.Text = "Sa&ve";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(168, 6);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadAsToolStripMenuItem
            // 
            this.loadAsToolStripMenuItem.Name = "loadAsToolStripMenuItem";
            this.loadAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F9)));
            this.loadAsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.loadAsToolStripMenuItem.Text = "Load As...";
            this.loadAsToolStripMenuItem.Click += new System.EventHandler(this.loadAsToolStripMenuItem_Click);
            // 
            // gameGenieToolStripMenuItem
            // 
            this.gameGenieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.configureToolStripMenuItem1});
            this.gameGenieToolStripMenuItem.Name = "gameGenieToolStripMenuItem";
            this.gameGenieToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.gameGenieToolStripMenuItem.Text = "&Game Genie";
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.activeToolStripMenuItem.Text = "&Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.activeToolStripMenuItem_Click);
            // 
            // configureToolStripMenuItem1
            // 
            this.configureToolStripMenuItem1.Image = global::MyNes.Properties.Resources.GG;
            this.configureToolStripMenuItem1.Name = "configureToolStripMenuItem1";
            this.configureToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.configureToolStripMenuItem1.Text = "&Configure";
            this.configureToolStripMenuItem1.Click += new System.EventHandler(this.configureToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rendererToolStripMenuItem,
            this.inputToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.soundToolStripMenuItem,
            this.pathsToolStripMenuItem,
            this.paletteToolStripMenuItem,
            this.toolStripSeparator3,
            this.emulationSystemToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // rendererToolStripMenuItem
            // 
            this.rendererToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rendererToolStripMenuItem.Image")));
            this.rendererToolStripMenuItem.Name = "rendererToolStripMenuItem";
            this.rendererToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.rendererToolStripMenuItem.Text = "Renderer";
            this.rendererToolStripMenuItem.Click += new System.EventHandler(this.rendererToolStripMenuItem_Click);
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.toolStripSeparator16,
            this.connectZapperToolStripMenuItem,
            this.connect4PlayersToolStripMenuItem});
            this.inputToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inputToolStripMenuItem.Image")));
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.inputToolStripMenuItem.Text = "&Input";
            this.inputToolStripMenuItem.DropDownOpening += new System.EventHandler(this.inputToolStripMenuItem_DropDownOpening);
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.profileToolStripMenuItem.Text = "&Profile";
            this.profileToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.profileToolStripMenuItem_DropDownItemClicked);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.configureToolStripMenuItem.Text = "&Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(165, 6);
            // 
            // connectZapperToolStripMenuItem
            // 
            this.connectZapperToolStripMenuItem.Name = "connectZapperToolStripMenuItem";
            this.connectZapperToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.connectZapperToolStripMenuItem.Text = "Connect &Zapper";
            this.connectZapperToolStripMenuItem.Click += new System.EventHandler(this.connectZapperToolStripMenuItem_Click);
            // 
            // connect4PlayersToolStripMenuItem
            // 
            this.connect4PlayersToolStripMenuItem.Name = "connect4PlayersToolStripMenuItem";
            this.connect4PlayersToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.connect4PlayersToolStripMenuItem.Text = "Connect 4 p&layers";
            this.connect4PlayersToolStripMenuItem.Click += new System.EventHandler(this.connect4PlayersToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("videoToolStripMenuItem.Image")));
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.videoToolStripMenuItem.Text = "&Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("soundToolStripMenuItem.Image")));
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.soundToolStripMenuItem.Text = "&Audio";
            this.soundToolStripMenuItem.Click += new System.EventHandler(this.soundToolStripMenuItem_Click);
            // 
            // pathsToolStripMenuItem
            // 
            this.pathsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pathsToolStripMenuItem.Image")));
            this.pathsToolStripMenuItem.Name = "pathsToolStripMenuItem";
            this.pathsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.pathsToolStripMenuItem.Text = "&Paths";
            this.pathsToolStripMenuItem.Click += new System.EventHandler(this.pathsToolStripMenuItem_Click);
            // 
            // paletteToolStripMenuItem
            // 
            this.paletteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("paletteToolStripMenuItem.Image")));
            this.paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
            this.paletteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.paletteToolStripMenuItem.Text = "Pa&lette";
            this.paletteToolStripMenuItem.Click += new System.EventHandler(this.paletteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(166, 6);
            // 
            // emulationSystemToolStripMenuItem
            // 
            this.emulationSystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.toolStripSeparator24,
            this.nTSCToolStripMenuItem,
            this.pALToolStripMenuItem,
            this.dENDYToolStripMenuItem});
            this.emulationSystemToolStripMenuItem.Name = "emulationSystemToolStripMenuItem";
            this.emulationSystemToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.emulationSystemToolStripMenuItem.Text = "&Emulation System";
            this.emulationSystemToolStripMenuItem.DropDownOpening += new System.EventHandler(this.emulationSystemToolStripMenuItem_DropDownOpening);
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.autoToolStripMenuItem.Text = "&Auto-detect";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(135, 6);
            // 
            // nTSCToolStripMenuItem
            // 
            this.nTSCToolStripMenuItem.Name = "nTSCToolStripMenuItem";
            this.nTSCToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.nTSCToolStripMenuItem.Text = "&NTSC";
            this.nTSCToolStripMenuItem.Click += new System.EventHandler(this.nTSCToolStripMenuItem_Click);
            // 
            // pALToolStripMenuItem
            // 
            this.pALToolStripMenuItem.Name = "pALToolStripMenuItem";
            this.pALToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.pALToolStripMenuItem.Text = "&PAL";
            this.pALToolStripMenuItem.Click += new System.EventHandler(this.pALToolStripMenuItem_Click);
            // 
            // dENDYToolStripMenuItem
            // 
            this.dENDYToolStripMenuItem.Name = "dENDYToolStripMenuItem";
            this.dENDYToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.dENDYToolStripMenuItem.Text = "&DENDY";
            this.dENDYToolStripMenuItem.Click += new System.EventHandler(this.dENDYToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNESHeaderEditorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // iNESHeaderEditorToolStripMenuItem
            // 
            this.iNESHeaderEditorToolStripMenuItem.Name = "iNESHeaderEditorToolStripMenuItem";
            this.iNESHeaderEditorToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.iNESHeaderEditorToolStripMenuItem.Text = "INES Header Editor";
            this.iNESHeaderEditorToolStripMenuItem.Click += new System.EventHandler(this.iNESHeaderEditorToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.emulationSpeedToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "&Debug";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consoleToolStripMenuItem.Image")));
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.consoleToolStripMenuItem.Text = "&Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // emulationSpeedToolStripMenuItem
            // 
            this.emulationSpeedToolStripMenuItem.Name = "emulationSpeedToolStripMenuItem";
            this.emulationSpeedToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.emulationSpeedToolStripMenuItem.Text = "&Emulation Speed";
            this.emulationSpeedToolStripMenuItem.Click += new System.EventHandler(this.emulationSpeedToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentToolStripMenuItem,
            this.toolStripSeparator4,
            this.aboutMyNesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentToolStripMenuItem
            // 
            this.contentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contentToolStripMenuItem.Image")));
            this.contentToolStripMenuItem.Name = "contentToolStripMenuItem";
            this.contentToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.contentToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.contentToolStripMenuItem.Text = "&Content";
            this.contentToolStripMenuItem.Click += new System.EventHandler(this.ShowHelp);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(144, 6);
            // 
            // aboutMyNesToolStripMenuItem
            // 
            this.aboutMyNesToolStripMenuItem.Image = global::MyNes.Properties.Resources.MyNes;
            this.aboutMyNesToolStripMenuItem.Name = "aboutMyNesToolStripMenuItem";
            this.aboutMyNesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.aboutMyNesToolStripMenuItem.Text = "&About MyNes";
            this.aboutMyNesToolStripMenuItem.Click += new System.EventHandler(this.aboutMyNesToolStripMenuItem_Click);
            // 
            // contextMenuStripSnapshot
            // 
            this.contextMenuStripSnapshot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator19,
            this.openContainerFolderToolStripMenuItem});
            this.contextMenuStripSnapshot.Name = "contextMenuStrip_snapshot";
            this.contextMenuStripSnapshot.Size = new System.Drawing.Size(191, 54);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(187, 6);
            // 
            // openContainerFolderToolStripMenuItem
            // 
            this.openContainerFolderToolStripMenuItem.Name = "openContainerFolderToolStripMenuItem";
            this.openContainerFolderToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openContainerFolderToolStripMenuItem.Text = "Open container folder";
            this.openContainerFolderToolStripMenuItem.Click += new System.EventHandler(this.openContainerFolderToolStripMenuItem_Click);
            // 
            // contextMenuStripCover
            // 
            this.contextMenuStripCover.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator20,
            this.toolStripMenuItem2});
            this.contextMenuStripCover.Name = "contextMenuStrip_snapshot";
            this.contextMenuStripCover.Size = new System.Drawing.Size(191, 54);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem1.Text = "Open";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem2.Text = "Open container folder";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.toolStripSeparator27,
            this.locateToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip_roms";
            this.contextMenuStrip.Size = new System.Drawing.Size(110, 54);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(106, 6);
            // 
            // locateToolStripMenuItem
            // 
            this.locateToolStripMenuItem.Name = "locateToolStripMenuItem";
            this.locateToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.locateToolStripMenuItem.Text = "Locate";
            this.locateToolStripMenuItem.Click += new System.EventHandler(this.locateToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgressBar1,
            this.toolStripStatusLabel2,
            this.StatusLabel_romsCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 420);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(624, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // StatusLabel_romsCount
            // 
            this.StatusLabel_romsCount.Name = "StatusLabel_romsCount";
            this.StatusLabel_romsCount.Size = new System.Drawing.Size(43, 17);
            this.StatusLabel_romsCount.Text = "0 roms";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(883, 481);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ManagedListView1);
            this.groupBox2.Controls.Add(this.panel_thumbnailsPanel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 346);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Roms list";
            // 
            // ManagedListView1
            // 
            this.ManagedListView1.AllowColumnsReorder = true;
            this.ManagedListView1.AllowItemsDragAndDrop = true;
            this.ManagedListView1.ChangeColumnSortModeWhenClick = false;
            this.ManagedListView1.Columns = managedListViewColumnsCollection1;
            this.ManagedListView1.ContextMenuStrip = this.contextMenuStrip_roms;
            this.ManagedListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManagedListView1.DrawHighlight = true;
            this.ManagedListView1.ImagesList = this.imageList;
            this.ManagedListView1.Items = managedListViewItemsCollection1;
            this.ManagedListView1.Location = new System.Drawing.Point(3, 16);
            this.ManagedListView1.Name = "ManagedListView1";
            this.ManagedListView1.Size = new System.Drawing.Size(406, 296);
            this.ManagedListView1.TabIndex = 0;
            this.ManagedListView1.ThunmbnailsHeight = 36;
            this.ManagedListView1.ThunmbnailsWidth = 36;
            this.ManagedListView1.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.ManagedListView1.WheelScrollSpeed = 40;
            this.ManagedListView1.DrawItem += new System.EventHandler<MLV.ManagedListViewItemDrawArgs>(this.ManagedListView1_DrawItem);
            this.ManagedListView1.SelectedIndexChanged += new System.EventHandler(this.ManagedListView1_SelectedIndexChanged);
            this.ManagedListView1.ColumnClicked += new System.EventHandler<MLV.ManagedListViewColumnClickArgs>(this.ManagedListView1_ColumnClicked);
            this.ManagedListView1.EnterPressed += new System.EventHandler(this.ManagedListView1_EnterPressed);
            this.ManagedListView1.ItemDoubleClick += new System.EventHandler<MLV.ManagedListViewItemDoubleClickArgs>(this.ManagedListView1_ItemDoubleClick);
            this.ManagedListView1.SwitchToColumnsContextMenu += new System.EventHandler(this.ManagedListView1_SwitchToColumnsContextMenu);
            this.ManagedListView1.SwitchToNormalContextMenu += new System.EventHandler(this.ManagedListView1_SwitchToNormalContextMenu);
            this.ManagedListView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManagedListView1_KeyDown);
            // 
            // contextMenuStrip_roms
            // 
            this.contextMenuStrip_roms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem1,
            this.toolStripSeparator31,
            this.locateOnDiskToolStripMenuItem,
            this.toolStripSeparator32,
            this.resetPlaydTimesCounterToolStripMenuItem,
            this.resetRatingToolStripMenuItem,
            this.toolStripSeparator33,
            this.setSnapshotToolStripMenuItem,
            this.setCoverToolStripMenuItem,
            this.toolStripSeparator35,
            this.romInfoToolStripMenuItem1,
            this.editINESHeaderToolStripMenuItem});
            this.contextMenuStrip_roms.Name = "contextMenuStrip_roms";
            this.contextMenuStrip_roms.Size = new System.Drawing.Size(220, 226);
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.Image = global::MyNes.Properties.Resources.control_play;
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.playToolStripMenuItem1.Text = "Play";
            this.playToolStripMenuItem1.Click += new System.EventHandler(this.playToolStripMenuItem1_Click);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(216, 6);
            // 
            // locateOnDiskToolStripMenuItem
            // 
            this.locateOnDiskToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("locateOnDiskToolStripMenuItem.Image")));
            this.locateOnDiskToolStripMenuItem.Name = "locateOnDiskToolStripMenuItem";
            this.locateOnDiskToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.locateOnDiskToolStripMenuItem.Text = "Locate on disk";
            this.locateOnDiskToolStripMenuItem.Click += new System.EventHandler(this.locateOnDiskToolStripMenuItem_Click);
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(216, 6);
            // 
            // resetPlaydTimesCounterToolStripMenuItem
            // 
            this.resetPlaydTimesCounterToolStripMenuItem.Name = "resetPlaydTimesCounterToolStripMenuItem";
            this.resetPlaydTimesCounterToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.resetPlaydTimesCounterToolStripMenuItem.Text = "Reset played times counter ";
            this.resetPlaydTimesCounterToolStripMenuItem.Click += new System.EventHandler(this.resetPlaydTimesCounterToolStripMenuItem_Click);
            // 
            // resetRatingToolStripMenuItem
            // 
            this.resetRatingToolStripMenuItem.Name = "resetRatingToolStripMenuItem";
            this.resetRatingToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.resetRatingToolStripMenuItem.Text = "Reset rating";
            this.resetRatingToolStripMenuItem.Click += new System.EventHandler(this.resetRatingToolStripMenuItem_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(216, 6);
            // 
            // setSnapshotToolStripMenuItem
            // 
            this.setSnapshotToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setSnapshotToolStripMenuItem.Image")));
            this.setSnapshotToolStripMenuItem.Name = "setSnapshotToolStripMenuItem";
            this.setSnapshotToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.setSnapshotToolStripMenuItem.Text = "Set snapshot";
            this.setSnapshotToolStripMenuItem.Click += new System.EventHandler(this.setSnapshotToolStripMenuItem_Click);
            // 
            // setCoverToolStripMenuItem
            // 
            this.setCoverToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setCoverToolStripMenuItem.Image")));
            this.setCoverToolStripMenuItem.Name = "setCoverToolStripMenuItem";
            this.setCoverToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.setCoverToolStripMenuItem.Text = "Set cover";
            this.setCoverToolStripMenuItem.Click += new System.EventHandler(this.setCoverToolStripMenuItem_Click);
            // 
            // toolStripSeparator35
            // 
            this.toolStripSeparator35.Name = "toolStripSeparator35";
            this.toolStripSeparator35.Size = new System.Drawing.Size(216, 6);
            // 
            // romInfoToolStripMenuItem1
            // 
            this.romInfoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("romInfoToolStripMenuItem1.Image")));
            this.romInfoToolStripMenuItem1.Name = "romInfoToolStripMenuItem1";
            this.romInfoToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.romInfoToolStripMenuItem1.Text = "Rom info";
            this.romInfoToolStripMenuItem1.Click += new System.EventHandler(this.romInfoToolStripMenuItem1_Click);
            // 
            // panel_thumbnailsPanel
            // 
            this.panel_thumbnailsPanel.Controls.Add(this.label_thumbnailsSize);
            this.panel_thumbnailsPanel.Controls.Add(this.trackBar_thumbnailsZoom);
            this.panel_thumbnailsPanel.Controls.Add(this.comboBox_thumbnailsMode);
            this.panel_thumbnailsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_thumbnailsPanel.Location = new System.Drawing.Point(3, 312);
            this.panel_thumbnailsPanel.Name = "panel_thumbnailsPanel";
            this.panel_thumbnailsPanel.Size = new System.Drawing.Size(406, 31);
            this.panel_thumbnailsPanel.TabIndex = 1;
            this.panel_thumbnailsPanel.Visible = false;
            // 
            // label_thumbnailsSize
            // 
            this.label_thumbnailsSize.AutoSize = true;
            this.label_thumbnailsSize.Location = new System.Drawing.Point(281, 8);
            this.label_thumbnailsSize.Name = "label_thumbnailsSize";
            this.label_thumbnailsSize.Size = new System.Drawing.Size(43, 13);
            this.label_thumbnailsSize.TabIndex = 2;
            this.label_thumbnailsSize.Text = "50 x 50";
            // 
            // trackBar_thumbnailsZoom
            // 
            this.trackBar_thumbnailsZoom.AutoSize = false;
            this.trackBar_thumbnailsZoom.Location = new System.Drawing.Point(151, 5);
            this.trackBar_thumbnailsZoom.Maximum = 400;
            this.trackBar_thumbnailsZoom.Minimum = 50;
            this.trackBar_thumbnailsZoom.Name = "trackBar_thumbnailsZoom";
            this.trackBar_thumbnailsZoom.Size = new System.Drawing.Size(124, 20);
            this.trackBar_thumbnailsZoom.TabIndex = 1;
            this.trackBar_thumbnailsZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_thumbnailsZoom.Value = 50;
            this.trackBar_thumbnailsZoom.Scroll += new System.EventHandler(this.trackBar_thumbnailsZoom_Scroll);
            // 
            // comboBox_thumbnailsMode
            // 
            this.comboBox_thumbnailsMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_thumbnailsMode.FormattingEnabled = true;
            this.comboBox_thumbnailsMode.Items.AddRange(new object[] {
            "Auto",
            "Snapshots",
            "Covers"});
            this.comboBox_thumbnailsMode.Location = new System.Drawing.Point(3, 5);
            this.comboBox_thumbnailsMode.Name = "comboBox_thumbnailsMode";
            this.comboBox_thumbnailsMode.Size = new System.Drawing.Size(142, 21);
            this.comboBox_thumbnailsMode.TabIndex = 0;
            this.comboBox_thumbnailsMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_thumbnailsMode_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton8,
            this.toolStripButton7,
            this.toolStripSeparator5,
            this.buttonCreateFolder,
            this.buttonDeleteFolder,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton15,
            this.toolStripSeparator22,
            this.toolStripButton6,
            this.toolStripSeparator23,
            this.toolStripButton10,
            this.buttonPad,
            this.buttonPpu,
            this.buttonApu,
            this.buttonPalette,
            this.toolStripSeparator6,
            this.toolStripButton11,
            this.toolStripSeparator26,
            this.buttonConsole,
            this.toolStripSeparator10,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(624, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Open rom";
            this.toolStripButton1.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "Open database";
            this.toolStripButton8.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Save database";
            this.toolStripButton7.Click += new System.EventHandler(this.saveDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonCreateFolder
            // 
            this.buttonCreateFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCreateFolder.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreateFolder.Image")));
            this.buttonCreateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCreateFolder.Name = "buttonCreateFolder";
            this.buttonCreateFolder.Size = new System.Drawing.Size(23, 22);
            this.buttonCreateFolder.Text = "Create folder";
            this.buttonCreateFolder.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // buttonDeleteFolder
            // 
            this.buttonDeleteFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDeleteFolder.Enabled = false;
            this.buttonDeleteFolder.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteFolder.Image")));
            this.buttonDeleteFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteFolder.Name = "buttonDeleteFolder";
            this.buttonDeleteFolder.Size = new System.Drawing.Size(23, 22);
            this.buttonDeleteFolder.Text = "Delete folder";
            this.buttonDeleteFolder.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
            this.buttonDeleteFolder.EnabledChanged += new System.EventHandler(this.buttonDeleteFolder_EnabledChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Rebuild cache of seleted folder";
            this.toolStripButton3.Click += new System.EventHandler(this.rebuildCacheToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Detect snapshots";
            this.toolStripButton4.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "Detect covers";
            this.toolStripButton5.Click += new System.EventHandler(this.DetectCovers);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton15.Text = "toolStripButton15";
            this.toolStripButton15.ToolTipText = "Detect info texts";
            this.toolStripButton15.Click += new System.EventHandler(this.DetectInfoTexts);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::MyNes.Properties.Resources.GG;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Configure Game Genie";
            this.toolStripButton6.Click += new System.EventHandler(this.configureToolStripMenuItem1_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "toolStripButton10";
            this.toolStripButton10.ToolTipText = "Select renderer";
            this.toolStripButton10.Click += new System.EventHandler(this.rendererToolStripMenuItem_Click);
            // 
            // buttonPad
            // 
            this.buttonPad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPad.Image = ((System.Drawing.Image)(resources.GetObject("buttonPad.Image")));
            this.buttonPad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPad.Name = "buttonPad";
            this.buttonPad.Size = new System.Drawing.Size(23, 22);
            this.buttonPad.Text = "Input Configuration";
            this.buttonPad.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // buttonPpu
            // 
            this.buttonPpu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPpu.Image = ((System.Drawing.Image)(resources.GetObject("buttonPpu.Image")));
            this.buttonPpu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPpu.Name = "buttonPpu";
            this.buttonPpu.Size = new System.Drawing.Size(23, 22);
            this.buttonPpu.Text = "Video Configuration";
            this.buttonPpu.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // buttonApu
            // 
            this.buttonApu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonApu.Image = ((System.Drawing.Image)(resources.GetObject("buttonApu.Image")));
            this.buttonApu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonApu.Name = "buttonApu";
            this.buttonApu.Size = new System.Drawing.Size(23, 22);
            this.buttonApu.Text = "Audio Configuration";
            this.buttonApu.Click += new System.EventHandler(this.soundToolStripMenuItem_Click);
            // 
            // buttonPalette
            // 
            this.buttonPalette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPalette.Image = ((System.Drawing.Image)(resources.GetObject("buttonPalette.Image")));
            this.buttonPalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPalette.Name = "buttonPalette";
            this.buttonPalette.Size = new System.Drawing.Size(23, 22);
            this.buttonPalette.Text = "Palette Configuration";
            this.buttonPalette.Click += new System.EventHandler(this.paletteToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "toolStripButton11";
            this.toolStripButton11.ToolTipText = "View current rom information or open a rom for information";
            this.toolStripButton11.Click += new System.EventHandler(this.romInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonConsole
            // 
            this.buttonConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonConsole.Image = ((System.Drawing.Image)(resources.GetObject("buttonConsole.Image")));
            this.buttonConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonConsole.Name = "buttonConsole";
            this.buttonConsole.Size = new System.Drawing.Size(23, 22);
            this.buttonConsole.Text = "Console";
            this.buttonConsole.CheckedChanged += new System.EventHandler(this.buttonConsole_CheckedChanged);
            this.buttonConsole.Click += new System.EventHandler(this.buttonConsole_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Help";
            this.toolStripButton2.Click += new System.EventHandler(this.ShowHelp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(208, 215);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.imageViewer_snaps);
            this.tabPage1.ImageIndex = 4;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(200, 188);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Snapshot";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imageViewer_snaps
            // 
            this.imageViewer_snaps.BackColor = System.Drawing.Color.White;
            this.imageViewer_snaps.ContextMenuStrip = this.contextMenuStripSnapshot;
            this.imageViewer_snaps.DefaultImage = global::MyNes.Properties.Resources.MyNesImage;
            this.imageViewer_snaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer_snaps.ImageToView = null;
            this.imageViewer_snaps.Location = new System.Drawing.Point(3, 3);
            this.imageViewer_snaps.Name = "imageViewer_snaps";
            this.imageViewer_snaps.Size = new System.Drawing.Size(194, 182);
            this.imageViewer_snaps.TabIndex = 0;
            this.imageViewer_snaps.Text = "imageViewer1";
            this.imageViewer_snaps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageViewer_snaps_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.imageViewer_covers);
            this.tabPage2.ImageIndex = 3;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 188);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cover";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageViewer_covers
            // 
            this.imageViewer_covers.BackColor = System.Drawing.Color.White;
            this.imageViewer_covers.ContextMenuStrip = this.contextMenuStripCover;
            this.imageViewer_covers.DefaultImage = global::MyNes.Properties.Resources.MyNesImage;
            this.imageViewer_covers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer_covers.ImageToView = null;
            this.imageViewer_covers.Location = new System.Drawing.Point(3, 3);
            this.imageViewer_covers.Name = "imageViewer_covers";
            this.imageViewer_covers.Size = new System.Drawing.Size(194, 182);
            this.imageViewer_covers.TabIndex = 0;
            this.imageViewer_covers.Text = "imageViewer1";
            this.imageViewer_covers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageViewer_covers_MouseDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox_romInfo);
            this.tabPage3.Controls.Add(this.toolStrip2);
            this.tabPage3.ImageIndex = 5;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(200, 188);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox_romInfo
            // 
            this.richTextBox_romInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_romInfo.Location = new System.Drawing.Point(3, 28);
            this.richTextBox_romInfo.Name = "richTextBox_romInfo";
            this.richTextBox_romInfo.Size = new System.Drawing.Size(194, 157);
            this.richTextBox_romInfo.TabIndex = 1;
            this.richTextBox_romInfo.Text = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton12,
            this.toolStripButton13,
            this.toolStripSeparator34,
            this.toolStripButton14});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(194, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton12.Text = "toolStripButton12";
            this.toolStripButton12.ToolTipText = "Get from file";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton13.Text = "toolStripButton13";
            this.toolStripButton13.ToolTipText = "Save to selected rom(s)";
            this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton14.Text = "toolStripButton14";
            this.toolStripButton14.ToolTipText = "Save to file";
            this.toolStripButton14.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip_folders;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(3, 16);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(202, 108);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // contextMenuStrip_folders
            // 
            this.contextMenuStrip_folders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator18,
            this.rebuildCacheToolStripMenuItem1,
            this.toolStripSeparator21,
            this.detectSnapshotsToolStripMenuItem1,
            this.detectCoversToolStripMenuItem,
            this.detectInfoTextsToolStripMenuItem1,
            this.toolStripSeparator28,
            this.openToolStripMenuItem1});
            this.contextMenuStrip_folders.Name = "contextMenuStrip_folders";
            this.contextMenuStrip_folders.Size = new System.Drawing.Size(165, 176);
            // 
            // addFolderToolStripMenuItem1
            // 
            this.addFolderToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("addFolderToolStripMenuItem1.Image")));
            this.addFolderToolStripMenuItem1.Name = "addFolderToolStripMenuItem1";
            this.addFolderToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.addFolderToolStripMenuItem1.Text = "Add folder";
            this.addFolderToolStripMenuItem1.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(161, 6);
            // 
            // rebuildCacheToolStripMenuItem1
            // 
            this.rebuildCacheToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("rebuildCacheToolStripMenuItem1.Image")));
            this.rebuildCacheToolStripMenuItem1.Name = "rebuildCacheToolStripMenuItem1";
            this.rebuildCacheToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.rebuildCacheToolStripMenuItem1.Text = "Rebuild cache";
            this.rebuildCacheToolStripMenuItem1.Click += new System.EventHandler(this.rebuildCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(161, 6);
            // 
            // detectSnapshotsToolStripMenuItem1
            // 
            this.detectSnapshotsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("detectSnapshotsToolStripMenuItem1.Image")));
            this.detectSnapshotsToolStripMenuItem1.Name = "detectSnapshotsToolStripMenuItem1";
            this.detectSnapshotsToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.detectSnapshotsToolStripMenuItem1.Text = "Detect snapshots";
            this.detectSnapshotsToolStripMenuItem1.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // detectCoversToolStripMenuItem
            // 
            this.detectCoversToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("detectCoversToolStripMenuItem.Image")));
            this.detectCoversToolStripMenuItem.Name = "detectCoversToolStripMenuItem";
            this.detectCoversToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.detectCoversToolStripMenuItem.Text = "Detect covers";
            this.detectCoversToolStripMenuItem.Click += new System.EventHandler(this.DetectCovers);
            // 
            // detectInfoTextsToolStripMenuItem1
            // 
            this.detectInfoTextsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("detectInfoTextsToolStripMenuItem1.Image")));
            this.detectInfoTextsToolStripMenuItem1.Name = "detectInfoTextsToolStripMenuItem1";
            this.detectInfoTextsToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.detectInfoTextsToolStripMenuItem1.Text = "Detect info texts";
            this.detectInfoTextsToolStripMenuItem1.Click += new System.EventHandler(this.DetectInfoTexts);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(161, 6);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(624, 346);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 5;
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
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(208, 346);
            this.splitContainer2.SplitterDistance = 127;
            this.splitContainer2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ComboBox_filter,
            this.toolStripLabel2,
            this.ComboBox_filterBy,
            this.toolStripButton9,
            this.toolStripSeparator25,
            this.FilterOption_MatchCase,
            this.FilterOption_MachWord,
            this.toolStripSeparator30,
            this.ThumbnailsViewSwitch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 49);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Filter:";
            // 
            // ComboBox_filter
            // 
            this.ComboBox_filter.Name = "ComboBox_filter";
            this.ComboBox_filter.Size = new System.Drawing.Size(121, 25);
            this.ComboBox_filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_filter_KeyDown);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(23, 22);
            this.toolStripLabel2.Text = "By:";
            // 
            // ComboBox_filterBy
            // 
            this.ComboBox_filterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_filterBy.Items.AddRange(new object[] {
            "Name",
            "Mapper #"});
            this.ComboBox_filterBy.Name = "ComboBox_filterBy";
            this.ComboBox_filterBy.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.ToolTipText = "Go";
            this.toolStripButton9.Click += new System.EventHandler(this.DoFilter);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(6, 25);
            // 
            // FilterOption_MatchCase
            // 
            this.FilterOption_MatchCase.CheckOnClick = true;
            this.FilterOption_MatchCase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FilterOption_MatchCase.Image = ((System.Drawing.Image)(resources.GetObject("FilterOption_MatchCase.Image")));
            this.FilterOption_MatchCase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterOption_MatchCase.Name = "FilterOption_MatchCase";
            this.FilterOption_MatchCase.Size = new System.Drawing.Size(23, 22);
            this.FilterOption_MatchCase.Text = "toolStripButton10";
            this.FilterOption_MatchCase.ToolTipText = "Match case";
            // 
            // FilterOption_MachWord
            // 
            this.FilterOption_MachWord.CheckOnClick = true;
            this.FilterOption_MachWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FilterOption_MachWord.Image = ((System.Drawing.Image)(resources.GetObject("FilterOption_MachWord.Image")));
            this.FilterOption_MachWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterOption_MachWord.Name = "FilterOption_MachWord";
            this.FilterOption_MachWord.Size = new System.Drawing.Size(23, 22);
            this.FilterOption_MachWord.Text = "toolStripButton10";
            this.FilterOption_MachWord.ToolTipText = "Match word";
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(6, 25);
            // 
            // ThumbnailsViewSwitch
            // 
            this.ThumbnailsViewSwitch.CheckOnClick = true;
            this.ThumbnailsViewSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ThumbnailsViewSwitch.Image = ((System.Drawing.Image)(resources.GetObject("ThumbnailsViewSwitch.Image")));
            this.ThumbnailsViewSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThumbnailsViewSwitch.Name = "ThumbnailsViewSwitch";
            this.ThumbnailsViewSwitch.Size = new System.Drawing.Size(23, 22);
            this.ThumbnailsViewSwitch.Text = "toolStripButton12";
            this.ThumbnailsViewSwitch.ToolTipText = "Switch to thumbnails view";
            this.ThumbnailsViewSwitch.CheckedChanged += new System.EventHandler(this.ThumbnailsViewSwitch_CheckedChanged);
            // 
            // contextMenuStrip_columns
            // 
            this.contextMenuStrip_columns.Name = "contextMenuStrip_columns";
            this.contextMenuStrip_columns.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_columns.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_columns_Opening);
            this.contextMenuStrip_columns.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_columns_ItemClicked);
            // 
            // editINESHeaderToolStripMenuItem
            // 
            this.editINESHeaderToolStripMenuItem.Name = "editINESHeaderToolStripMenuItem";
            this.editINESHeaderToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.editINESHeaderToolStripMenuItem.Text = "Edit INES header";
            this.editINESHeaderToolStripMenuItem.Click += new System.EventHandler(this.editINESHeaderToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Nes [BETA]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStripSnapshot.ResumeLayout(false);
            this.contextMenuStripCover.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip_roms.ResumeLayout(false);
            this.panel_thumbnailsPanel.ResumeLayout(false);
            this.panel_thumbnailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_thumbnailsZoom)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip_folders.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem aboutMyNesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emulationSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem softResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardResetToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem opendatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem romInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem emulationSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nTSCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pALToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameGenieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem connectZapperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connect4PlayersToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSnapshot;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem openContainerFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCover;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.ToolStripMenuItem dENDYToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonCreateFolder;
        private System.Windows.Forms.ToolStripButton buttonDeleteFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripButton buttonPad;
        private System.Windows.Forms.ToolStripButton buttonPpu;
        private System.Windows.Forms.ToolStripButton buttonApu;
        private System.Windows.Forms.ToolStripButton buttonPalette;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ImageViewer imageViewer_snaps;
        private System.Windows.Forms.TabPage tabPage2;
        private ImageViewer imageViewer_covers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton buttonConsole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripMenuItem browserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem rebuildcacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem detectsnapshotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectCoverToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_folders;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem rebuildCacheToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem detectSnapshotsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem detectCoversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ComboBox_filter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox ComboBox_filterBy;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.ToolStripButton FilterOption_MatchCase;
        private System.Windows.Forms.ToolStripButton FilterOption_MachWord;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_romsCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem rendererToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripMenuItem locateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator28;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private MLV.ManagedListView ManagedListView1;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator30;
        private System.Windows.Forms.ToolStripButton ThumbnailsViewSwitch;
        private System.Windows.Forms.Panel panel_thumbnailsPanel;
        private System.Windows.Forms.ComboBox comboBox_thumbnailsMode;
        private System.Windows.Forms.Label label_thumbnailsSize;
        private System.Windows.Forms.TrackBar trackBar_thumbnailsZoom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_roms;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem locateOnDiskToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_columns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator31;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator32;
        private System.Windows.Forms.ToolStripMenuItem resetPlaydTimesCounterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetRatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator33;
        private System.Windows.Forms.ToolStripMenuItem setSnapshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCoverToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.RichTextBox richTextBox_romInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator34;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripMenuItem detectinfoTextsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripMenuItem detectInfoTextsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNESHeaderEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator35;
        private System.Windows.Forms.ToolStripMenuItem romInfoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editINESHeaderToolStripMenuItem;
    }
}

