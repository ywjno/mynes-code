namespace myNES.Forms
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
            this.buttonModifyFolder = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonPlay = new System.Windows.Forms.ToolStripButton();
            this.buttonHalt = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonConsole = new System.Windows.Forms.ToolStripButton();
            this.buttonPalette = new System.Windows.Forms.ToolStripButton();
            this.buttonPad = new System.Windows.Forms.ToolStripButton();
            this.buttonCpu = new System.Windows.Forms.ToolStripButton();
            this.buttonPpu = new System.Windows.Forms.ToolStripButton();
            this.buttonApu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMyNesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulationSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.buttonCreateFolder,
            this.buttonModifyFolder,
            this.buttonDeleteFolder,
            this.toolStripSeparator1,
            this.buttonPlay,
            this.buttonHalt,
            this.buttonStop,
            this.toolStripSeparator2,
            this.buttonConsole,
            this.buttonPalette,
            this.buttonPad,
            this.buttonCpu,
            this.buttonPpu,
            this.buttonApu,
            this.toolStripSeparator6,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(503, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Open rom";
            this.toolStripButton1.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
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
            // buttonModifyFolder
            // 
            this.buttonModifyFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonModifyFolder.Enabled = false;
            this.buttonModifyFolder.Image = ((System.Drawing.Image)(resources.GetObject("buttonModifyFolder.Image")));
            this.buttonModifyFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonModifyFolder.Name = "buttonModifyFolder";
            this.buttonModifyFolder.Size = new System.Drawing.Size(23, 22);
            this.buttonModifyFolder.Text = "Modifty folder";
            this.buttonModifyFolder.Click += new System.EventHandler(this.buttonModifyFolder_Click);
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
            this.buttonDeleteFolder.Click += new System.EventHandler(this.buttonDeleteFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonPlay
            // 
            this.buttonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlay.Enabled = false;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(23, 22);
            this.buttonPlay.Text = "Play";
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonHalt
            // 
            this.buttonHalt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonHalt.Enabled = false;
            this.buttonHalt.Image = ((System.Drawing.Image)(resources.GetObject("buttonHalt.Image")));
            this.buttonHalt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonHalt.Name = "buttonHalt";
            this.buttonHalt.Size = new System.Drawing.Size(23, 22);
            this.buttonHalt.Text = "Halt";
            this.buttonHalt.Click += new System.EventHandler(this.buttonHalt_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStop.Enabled = false;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(23, 22);
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // buttonPalette
            // 
            this.buttonPalette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPalette.Image = ((System.Drawing.Image)(resources.GetObject("buttonPalette.Image")));
            this.buttonPalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPalette.Name = "buttonPalette";
            this.buttonPalette.Size = new System.Drawing.Size(23, 22);
            this.buttonPalette.Text = "Palette";
            this.buttonPalette.Click += new System.EventHandler(this.buttonPalette_Click);
            // 
            // buttonPad
            // 
            this.buttonPad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPad.Image = ((System.Drawing.Image)(resources.GetObject("buttonPad.Image")));
            this.buttonPad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPad.Name = "buttonPad";
            this.buttonPad.Size = new System.Drawing.Size(23, 22);
            this.buttonPad.Text = "Pad Configuration";
            this.buttonPad.Click += new System.EventHandler(this.buttonPad_Click);
            // 
            // buttonCpu
            // 
            this.buttonCpu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCpu.Enabled = false;
            this.buttonCpu.Image = ((System.Drawing.Image)(resources.GetObject("buttonCpu.Image")));
            this.buttonCpu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCpu.Name = "buttonCpu";
            this.buttonCpu.Size = new System.Drawing.Size(23, 22);
            this.buttonCpu.Text = "CPU debugger";
            this.buttonCpu.Click += new System.EventHandler(this.buttonCpu_Click);
            // 
            // buttonPpu
            // 
            this.buttonPpu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPpu.Enabled = false;
            this.buttonPpu.Image = ((System.Drawing.Image)(resources.GetObject("buttonPpu.Image")));
            this.buttonPpu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPpu.Name = "buttonPpu";
            this.buttonPpu.Size = new System.Drawing.Size(23, 22);
            this.buttonPpu.Text = "PPU debugger";
            this.buttonPpu.Click += new System.EventHandler(this.buttonPpu_Click);
            // 
            // buttonApu
            // 
            this.buttonApu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonApu.Enabled = false;
            this.buttonApu.Image = ((System.Drawing.Image)(resources.GetObject("buttonApu.Image")));
            this.buttonApu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonApu.Name = "buttonApu";
            this.buttonApu.Size = new System.Drawing.Size(23, 22);
            this.buttonApu.Text = "APU debugger";
            this.buttonApu.Click += new System.EventHandler(this.buttonApu_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
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
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(0, 49);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(503, 332);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "page.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.browserToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.emulationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(503, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRomToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openRomToolStripMenuItem
            // 
            this.openRomToolStripMenuItem.Name = "openRomToolStripMenuItem";
            this.openRomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openRomToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openRomToolStripMenuItem.Text = "&Open rom";
            this.openRomToolStripMenuItem.Click += new System.EventHandler(this.openRomToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem1});
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.browserToolStripMenuItem.Text = "&Browser";
            // 
            // addFolderToolStripMenuItem1
            // 
            this.addFolderToolStripMenuItem1.Name = "addFolderToolStripMenuItem1";
            this.addFolderToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addFolderToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.addFolderToolStripMenuItem1.Text = "&Add folder";
            this.addFolderToolStripMenuItem1.Click += new System.EventHandler(this.buttonCreateFolder_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripToolStripMenuItem,
            this.menuStripToolStripMenuItem});
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
            // emulationToolStripMenuItem
            // 
            this.emulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resumeToolStripMenuItem,
            this.haltToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.emulationToolStripMenuItem.Name = "emulationToolStripMenuItem";
            this.emulationToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.emulationToolStripMenuItem.Text = "&Emulation";
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.resumeToolStripMenuItem.Text = "&Resume";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // haltToolStripMenuItem
            // 
            this.haltToolStripMenuItem.Name = "haltToolStripMenuItem";
            this.haltToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.haltToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.haltToolStripMenuItem.Text = "&Halt";
            this.haltToolStripMenuItem.Click += new System.EventHandler(this.buttonHalt_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.stopToolStripMenuItem.Text = "&Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
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
            this.contentToolStripMenuItem.Name = "contentToolStripMenuItem";
            this.contentToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.contentToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.contentToolStripMenuItem.Text = "&Content";
            this.contentToolStripMenuItem.Click += new System.EventHandler(this.ShowHelp);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // aboutMyNesToolStripMenuItem
            // 
            this.aboutMyNesToolStripMenuItem.Name = "aboutMyNesToolStripMenuItem";
            this.aboutMyNesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.aboutMyNesToolStripMenuItem.Text = "&About myNES";
            this.aboutMyNesToolStripMenuItem.Click += new System.EventHandler(this.aboutMyNesToolStripMenuItem_Click);
            // 
            // emulationSpeedToolStripMenuItem
            // 
            this.emulationSpeedToolStripMenuItem.Name = "emulationSpeedToolStripMenuItem";
            this.emulationSpeedToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.emulationSpeedToolStripMenuItem.Text = "&Emulation Speed";
            this.emulationSpeedToolStripMenuItem.Click += new System.EventHandler(this.emulationSpeedToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 381);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "myNES v5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonCreateFolder;
        private System.Windows.Forms.ToolStripButton buttonModifyFolder;
        private System.Windows.Forms.ToolStripButton buttonDeleteFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonPlay;
        private System.Windows.Forms.ToolStripButton buttonHalt;
        private System.Windows.Forms.ToolStripButton buttonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonConsole;
        private System.Windows.Forms.ToolStripButton buttonPalette;
        private System.Windows.Forms.ToolStripButton buttonPad;
        private System.Windows.Forms.ToolStripButton buttonCpu;
        private System.Windows.Forms.ToolStripButton buttonPpu;
        private System.Windows.Forms.ToolStripButton buttonApu;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
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
        private System.Windows.Forms.ToolStripMenuItem haltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem emulationSpeedToolStripMenuItem;
    }
}

