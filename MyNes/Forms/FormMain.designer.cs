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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonCreateFolder = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonPad = new System.Windows.Forms.ToolStripButton();
            this.buttonPpu = new System.Windows.Forms.ToolStripButton();
            this.buttonApu = new System.Windows.Forms.ToolStripButton();
            this.buttonPalette = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonConsole = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rebuildCacheToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.detectSnapshotsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.detectCoversToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opendatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.rebuildCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.detectsnapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectCoversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.romInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulationSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMyNesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imageViewer_snaps = new MyNes.ImageViewer();
            this.contextMenuStrip_snapshot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.openContainerFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageViewer_covers = new MyNes.ImageViewer();
            this.contextMenuStrip_cover = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_mapper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_mirroring = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_hasTrainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_isBattery = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_isPc10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_isVsunisystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_roms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip_snapshot.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip_cover.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_roms.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.buttonCreateFolder,
            this.buttonDeleteFolder,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator15,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator22,
            this.toolStripButton6,
            this.toolStripSeparator23,
            this.buttonPad,
            this.buttonPpu,
            this.buttonApu,
            this.buttonPalette,
            this.toolStripSeparator6,
            this.buttonConsole,
            this.toolStripSeparator10,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(472, 35);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MyNes.Properties.Resources.folder;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(32, 32);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Open rom";
            this.toolStripButton1.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
            // 
            // buttonCreateFolder
            // 
            this.buttonCreateFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCreateFolder.Image = global::MyNes.Properties.Resources.folder_add;
            this.buttonCreateFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCreateFolder.Name = "buttonCreateFolder";
            this.buttonCreateFolder.Size = new System.Drawing.Size(32, 32);
            this.buttonCreateFolder.Text = "Create folder";
            this.buttonCreateFolder.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // buttonDeleteFolder
            // 
            this.buttonDeleteFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDeleteFolder.Enabled = false;
            this.buttonDeleteFolder.Image = global::MyNes.Properties.Resources.folder_delete;
            this.buttonDeleteFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteFolder.Name = "buttonDeleteFolder";
            this.buttonDeleteFolder.Size = new System.Drawing.Size(32, 32);
            this.buttonDeleteFolder.Text = "Delete folder";
            this.buttonDeleteFolder.Click += new System.EventHandler(this.buttonDeleteFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::MyNes.Properties.Resources.folder_rebuildCache;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(32, 32);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Rebuild cache of seleted folder";
            this.toolStripButton3.Click += new System.EventHandler(this.rebuildCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::MyNes.Properties.Resources.folder_detectImages;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(32, 32);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Detect snapshots";
            this.toolStripButton4.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::MyNes.Properties.Resources.folder_detectImages;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(32, 32);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "Detect covers";
            this.toolStripButton5.Click += new System.EventHandler(this.DetectCovers);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::MyNes.Properties.Resources.FileGame_genie_nes_front;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(32, 32);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Configure Game Genie";
            this.toolStripButton6.Click += new System.EventHandler(this.configureToolStripMenuItem1_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(6, 35);
            // 
            // buttonPad
            // 
            this.buttonPad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPad.Image = global::MyNes.Properties.Resources.Joy;
            this.buttonPad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPad.Name = "buttonPad";
            this.buttonPad.Size = new System.Drawing.Size(32, 32);
            this.buttonPad.Text = "Input Configuration";
            this.buttonPad.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // buttonPpu
            // 
            this.buttonPpu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPpu.Image = global::MyNes.Properties.Resources.monitor;
            this.buttonPpu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPpu.Name = "buttonPpu";
            this.buttonPpu.Size = new System.Drawing.Size(32, 32);
            this.buttonPpu.Text = "Video Configuration";
            this.buttonPpu.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // buttonApu
            // 
            this.buttonApu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonApu.Image = global::MyNes.Properties.Resources.sound;
            this.buttonApu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonApu.Name = "buttonApu";
            this.buttonApu.Size = new System.Drawing.Size(32, 32);
            this.buttonApu.Text = "Audio Configuration";
            this.buttonApu.Click += new System.EventHandler(this.soundToolStripMenuItem_Click);
            // 
            // buttonPalette
            // 
            this.buttonPalette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPalette.Image = global::MyNes.Properties.Resources.full_palette_1;
            this.buttonPalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPalette.Name = "buttonPalette";
            this.buttonPalette.Size = new System.Drawing.Size(32, 32);
            this.buttonPalette.Text = "Palette Configuration";
            this.buttonPalette.Click += new System.EventHandler(this.paletteToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
            // 
            // buttonConsole
            // 
            this.buttonConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonConsole.Image = ((System.Drawing.Image)(resources.GetObject("buttonConsole.Image")));
            this.buttonConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonConsole.Name = "buttonConsole";
            this.buttonConsole.Size = new System.Drawing.Size(32, 32);
            this.buttonConsole.Text = "Console";
            this.buttonConsole.CheckedChanged += new System.EventHandler(this.buttonConsole_CheckedChanged);
            this.buttonConsole.Click += new System.EventHandler(this.buttonConsole_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::MyNes.Properties.Resources.Help;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(32, 32);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Help";
            this.toolStripButton2.Click += new System.EventHandler(this.ShowHelp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.rebuildCacheToolStripMenuItem1,
            this.toolStripSeparator21,
            this.detectSnapshotsToolStripMenuItem1,
            this.detectCoversToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 126);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addFolderToolStripMenuItem.Text = "Add folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.buttonDeleteFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // rebuildCacheToolStripMenuItem1
            // 
            this.rebuildCacheToolStripMenuItem1.Image = global::MyNes.Properties.Resources.folder_rebuildCache;
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
            this.detectSnapshotsToolStripMenuItem1.Image = global::MyNes.Properties.Resources.folder_detectImages;
            this.detectSnapshotsToolStripMenuItem1.Name = "detectSnapshotsToolStripMenuItem1";
            this.detectSnapshotsToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.detectSnapshotsToolStripMenuItem1.Text = "Detect snapshots";
            this.detectSnapshotsToolStripMenuItem1.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // detectCoversToolStripMenuItem1
            // 
            this.detectCoversToolStripMenuItem1.Image = global::MyNes.Properties.Resources.folder_detectImages;
            this.detectCoversToolStripMenuItem1.Name = "detectCoversToolStripMenuItem1";
            this.detectCoversToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.detectCoversToolStripMenuItem1.Text = "Detect covers";
            this.detectCoversToolStripMenuItem1.Click += new System.EventHandler(this.DetectCovers);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "page.png");
            this.imageList.Images.SetKeyName(2, "nes_j.ico");
            this.imageList.Images.SetKeyName(3, "File_RAR.ico");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.browserToolStripMenuItem,
            this.emulationToolStripMenuItem,
            this.stateToolStripMenuItem,
            this.gameGenieToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRomToolStripMenuItem,
            this.opendatabaseToolStripMenuItem1,
            this.toolStripSeparator14,
            this.saveDatabaseToolStripMenuItem1,
            this.saveDatabaseasToolStripMenuItem1,
            this.toolStripSeparator9,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator17,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // openRomToolStripMenuItem
            // 
            this.openRomToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder;
            this.openRomToolStripMenuItem.Name = "openRomToolStripMenuItem";
            this.openRomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openRomToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.openRomToolStripMenuItem.Text = "&Open Rom";
            this.openRomToolStripMenuItem.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // opendatabaseToolStripMenuItem1
            // 
            this.opendatabaseToolStripMenuItem1.Name = "opendatabaseToolStripMenuItem1";
            this.opendatabaseToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.opendatabaseToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.opendatabaseToolStripMenuItem1.Text = "Open &Database";
            this.opendatabaseToolStripMenuItem1.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
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
            this.saveDatabaseasToolStripMenuItem1.Text = "Save Database &As";
            this.saveDatabaseasToolStripMenuItem1.Click += new System.EventHandler(this.saveDatabaseAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(226, 6);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.recentFilesToolStripMenuItem.Text = "&Recent files";
            this.recentFilesToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.recentFilesToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(226, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem1,
            this.deleteFolderToolStripMenuItem,
            this.toolStripSeparator8,
            this.rebuildCacheToolStripMenuItem,
            this.toolStripSeparator18,
            this.detectsnapshotsToolStripMenuItem,
            this.detectCoversToolStripMenuItem});
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.browserToolStripMenuItem.Text = "&Browser";
            // 
            // addFolderToolStripMenuItem1
            // 
            this.addFolderToolStripMenuItem1.Image = global::MyNes.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem1.Name = "addFolderToolStripMenuItem1";
            this.addFolderToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addFolderToolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.addFolderToolStripMenuItem1.Text = "&Add folder";
            this.addFolderToolStripMenuItem1.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Enabled = false;
            this.deleteFolderToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_delete;
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            this.deleteFolderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.deleteFolderToolStripMenuItem.Text = "&Delete folder";
            this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
            this.deleteFolderToolStripMenuItem.EnabledChanged += new System.EventHandler(this.deleteFolderToolStripMenuItem_EnabledChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(224, 6);
            // 
            // rebuildCacheToolStripMenuItem
            // 
            this.rebuildCacheToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_rebuildCache;
            this.rebuildCacheToolStripMenuItem.Name = "rebuildCacheToolStripMenuItem";
            this.rebuildCacheToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.rebuildCacheToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.rebuildCacheToolStripMenuItem.Text = "Rebuild cache";
            this.rebuildCacheToolStripMenuItem.Click += new System.EventHandler(this.rebuildCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(224, 6);
            // 
            // detectsnapshotsToolStripMenuItem
            // 
            this.detectsnapshotsToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_detectImages;
            this.detectsnapshotsToolStripMenuItem.Name = "detectsnapshotsToolStripMenuItem";
            this.detectsnapshotsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.detectsnapshotsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.detectsnapshotsToolStripMenuItem.Text = "Detect &snapshots";
            this.detectsnapshotsToolStripMenuItem.Click += new System.EventHandler(this.DetectSnapshots);
            // 
            // detectCoversToolStripMenuItem
            // 
            this.detectCoversToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_detectImages;
            this.detectCoversToolStripMenuItem.Name = "detectCoversToolStripMenuItem";
            this.detectCoversToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.detectCoversToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.detectCoversToolStripMenuItem.Text = "Detect covers";
            this.detectCoversToolStripMenuItem.Click += new System.EventHandler(this.DetectCovers);
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
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.resumeToolStripMenuItem.Text = "&Toggle halt";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripMenuItem.Image")));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.stopToolStripMenuItem.Text = "&Turn off";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(150, 6);
            // 
            // softResetToolStripMenuItem
            // 
            this.softResetToolStripMenuItem.Name = "softResetToolStripMenuItem";
            this.softResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.softResetToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.softResetToolStripMenuItem.Text = "So&ft reset";
            this.softResetToolStripMenuItem.Click += new System.EventHandler(this.softResetToolStripMenuItem_Click);
            // 
            // hardResetToolStripMenuItem
            // 
            this.hardResetToolStripMenuItem.Name = "hardResetToolStripMenuItem";
            this.hardResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.hardResetToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.hardResetToolStripMenuItem.Text = "Ha&rd reset";
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
            this.slotToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.slotToolStripMenuItem.Text = "&Slot";
            this.slotToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.slotToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(157, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveToolStripMenuItem.Text = "Sa&ve";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(157, 6);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadAsToolStripMenuItem
            // 
            this.loadAsToolStripMenuItem.Name = "loadAsToolStripMenuItem";
            this.loadAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F9)));
            this.loadAsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadAsToolStripMenuItem.Text = "Load as";
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
            this.configureToolStripMenuItem1.Name = "configureToolStripMenuItem1";
            this.configureToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.configureToolStripMenuItem1.Text = "&Configure";
            this.configureToolStripMenuItem1.Click += new System.EventHandler(this.configureToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripToolStripMenuItem,
            this.menuStripToolStripMenuItem,
            this.toolStripSeparator11,
            this.romInfoToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // toolStripToolStripMenuItem
            // 
            this.toolStripToolStripMenuItem.Checked = true;
            this.toolStripToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripToolStripMenuItem.Name = "toolStripToolStripMenuItem";
            this.toolStripToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.toolStripToolStripMenuItem.Text = "Tool strip";
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
            this.menuStripToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.menuStripToolStripMenuItem.Text = "Menu strip";
            this.menuStripToolStripMenuItem.CheckedChanged += new System.EventHandler(this.menuStripToolStripMenuItem_CheckedChanged);
            this.menuStripToolStripMenuItem.Click += new System.EventHandler(this.menuStripToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(202, 6);
            // 
            // romInfoToolStripMenuItem
            // 
            this.romInfoToolStripMenuItem.Name = "romInfoToolStripMenuItem";
            this.romInfoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.romInfoToolStripMenuItem.Text = "&Rom info";
            this.romInfoToolStripMenuItem.Click += new System.EventHandler(this.romInfoToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.toolStripSeparator16,
            this.connectZapperToolStripMenuItem,
            this.connect4PlayersToolStripMenuItem});
            this.inputToolStripMenuItem.Image = global::MyNes.Properties.Resources.Joy;
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
            this.videoToolStripMenuItem.Image = global::MyNes.Properties.Resources.monitor;
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.videoToolStripMenuItem.Text = "&Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.Image = global::MyNes.Properties.Resources.sound;
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.soundToolStripMenuItem.Text = "&Audio";
            this.soundToolStripMenuItem.Click += new System.EventHandler(this.soundToolStripMenuItem_Click);
            // 
            // pathsToolStripMenuItem
            // 
            this.pathsToolStripMenuItem.Name = "pathsToolStripMenuItem";
            this.pathsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.pathsToolStripMenuItem.Text = "&Paths";
            this.pathsToolStripMenuItem.Click += new System.EventHandler(this.pathsToolStripMenuItem_Click);
            // 
            // paletteToolStripMenuItem
            // 
            this.paletteToolStripMenuItem.Image = global::MyNes.Properties.Resources.full_palette_1;
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
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoToolStripMenuItem.Text = "&Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(149, 6);
            // 
            // nTSCToolStripMenuItem
            // 
            this.nTSCToolStripMenuItem.Name = "nTSCToolStripMenuItem";
            this.nTSCToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nTSCToolStripMenuItem.Text = "&NTSC";
            this.nTSCToolStripMenuItem.Click += new System.EventHandler(this.nTSCToolStripMenuItem_Click);
            // 
            // pALToolStripMenuItem
            // 
            this.pALToolStripMenuItem.Name = "pALToolStripMenuItem";
            this.pALToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pALToolStripMenuItem.Text = "&PAL";
            this.pALToolStripMenuItem.Click += new System.EventHandler(this.pALToolStripMenuItem_Click);
            // 
            // dENDYToolStripMenuItem
            // 
            this.dENDYToolStripMenuItem.Name = "dENDYToolStripMenuItem";
            this.dENDYToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dENDYToolStripMenuItem.Text = "&DENDY";
            this.dENDYToolStripMenuItem.Click += new System.EventHandler(this.dENDYToolStripMenuItem_Click);
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
            this.contentToolStripMenuItem.Image = global::MyNes.Properties.Resources.Help;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(701, 318);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer2.Size = new System.Drawing.Size(190, 318);
            this.splitContainer2.SplitterDistance = 131;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(3, 16);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(184, 112);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(190, 183);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.imageViewer_snaps);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(182, 157);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Snapshot";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imageViewer_snaps
            // 
            this.imageViewer_snaps.BackColor = System.Drawing.Color.White;
            this.imageViewer_snaps.ContextMenuStrip = this.contextMenuStrip_snapshot;
            this.imageViewer_snaps.DefaultImage = global::MyNes.Properties.Resources.MyNesImage;
            this.imageViewer_snaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer_snaps.ImageToView = null;
            this.imageViewer_snaps.Location = new System.Drawing.Point(3, 3);
            this.imageViewer_snaps.Name = "imageViewer_snaps";
            this.imageViewer_snaps.Size = new System.Drawing.Size(176, 151);
            this.imageViewer_snaps.TabIndex = 0;
            this.imageViewer_snaps.Text = "imageViewer1";
            this.imageViewer_snaps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageViewer_snaps_MouseDoubleClick);
            // 
            // contextMenuStrip_snapshot
            // 
            this.contextMenuStrip_snapshot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator19,
            this.openContainerFolderToolStripMenuItem});
            this.contextMenuStrip_snapshot.Name = "contextMenuStrip_snapshot";
            this.contextMenuStrip_snapshot.Size = new System.Drawing.Size(191, 54);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.imageViewer_covers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(182, 157);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cover";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageViewer_covers
            // 
            this.imageViewer_covers.BackColor = System.Drawing.Color.White;
            this.imageViewer_covers.ContextMenuStrip = this.contextMenuStrip_cover;
            this.imageViewer_covers.DefaultImage = global::MyNes.Properties.Resources.MyNesImage;
            this.imageViewer_covers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer_covers.ImageToView = null;
            this.imageViewer_covers.Location = new System.Drawing.Point(3, 3);
            this.imageViewer_covers.Name = "imageViewer_covers";
            this.imageViewer_covers.Size = new System.Drawing.Size(176, 151);
            this.imageViewer_covers.TabIndex = 0;
            this.imageViewer_covers.Text = "imageViewer1";
            this.imageViewer_covers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageViewer_covers_MouseDoubleClick);
            // 
            // contextMenuStrip_cover
            // 
            this.contextMenuStrip_cover.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator20,
            this.toolStripMenuItem2});
            this.contextMenuStrip_cover.Name = "contextMenuStrip_snapshot";
            this.contextMenuStrip_cover.Size = new System.Drawing.Size(191, 54);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(182, 157);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(176, 151);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 318);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Roms list";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_name,
            this.columnHeader_size,
            this.columnHeader_mapper,
            this.columnHeader_mirroring,
            this.columnHeader_hasTrainer,
            this.columnHeader_isBattery,
            this.columnHeader_isPc10,
            this.columnHeader_isVsunisystem,
            this.columnHeader_path});
            this.listView1.ContextMenuStrip = this.contextMenuStrip_roms;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(501, 299);
            this.listView1.SmallImageList = this.imageList;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader_name
            // 
            this.columnHeader_name.Text = "Name";
            this.columnHeader_name.Width = 183;
            // 
            // columnHeader_size
            // 
            this.columnHeader_size.Text = "Size";
            // 
            // columnHeader_mapper
            // 
            this.columnHeader_mapper.Text = "Mapper/Board";
            this.columnHeader_mapper.Width = 71;
            // 
            // columnHeader_mirroring
            // 
            this.columnHeader_mirroring.Text = "Mirroring";
            // 
            // columnHeader_hasTrainer
            // 
            this.columnHeader_hasTrainer.Text = "Has Trainer";
            // 
            // columnHeader_isBattery
            // 
            this.columnHeader_isBattery.Text = "Is Battery Baked";
            // 
            // columnHeader_isPc10
            // 
            this.columnHeader_isPc10.Text = "Is PC10";
            // 
            // columnHeader_isVsunisystem
            // 
            this.columnHeader_isVsunisystem.Text = "Is VsUnisystem";
            // 
            // columnHeader_path
            // 
            this.columnHeader_path.Text = "Path";
            // 
            // contextMenuStrip_roms
            // 
            this.contextMenuStrip_roms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem});
            this.contextMenuStrip_roms.Name = "contextMenuStrip_roms";
            this.contextMenuStrip_roms.Size = new System.Drawing.Size(97, 26);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 377);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(701, 22);
            this.statusStrip1.TabIndex = 4;
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
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(701, 318);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(701, 353);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 399);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Nes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip_snapshot.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip_cover.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip_roms.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonCreateFolder;
        private System.Windows.Forms.ToolStripButton buttonDeleteFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonConsole;
        private System.Windows.Forms.ToolStripButton buttonPalette;
        private System.Windows.Forms.ToolStripButton buttonPad;
        private System.Windows.Forms.ToolStripButton buttonPpu;
        private System.Windows.Forms.ToolStripButton buttonApu;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem1;
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
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem emulationSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem softResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardResetToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_name;
        private System.Windows.Forms.ColumnHeader columnHeader_size;
        private System.Windows.Forms.ColumnHeader columnHeader_mapper;
        private System.Windows.Forms.ColumnHeader columnHeader_hasTrainer;
        private System.Windows.Forms.ColumnHeader columnHeader_isBattery;
        private System.Windows.Forms.ColumnHeader columnHeader_isPc10;
        private System.Windows.Forms.ColumnHeader columnHeader_isVsunisystem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar1;
        private System.Windows.Forms.ColumnHeader columnHeader_mirroring;
        private System.Windows.Forms.ColumnHeader columnHeader_path;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opendatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem rebuildCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem rebuildCacheToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gameGenieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem connectZapperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connect4PlayersToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_roms;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem detectsnapshotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectCoversToolStripMenuItem;
        private ImageViewer imageViewer_snaps;
        private ImageViewer imageViewer_covers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_snapshot;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem openContainerFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_cover;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem detectSnapshotsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem detectCoversToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.ToolStripMenuItem dENDYToolStripMenuItem;
    }
}

