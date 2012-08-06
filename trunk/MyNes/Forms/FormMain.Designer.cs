namespace MyNes
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.buttonApu});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(624, 25);
            this.toolStrip.TabIndex = 0;
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
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(624, 417);
            this.treeView.TabIndex = 1;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "page.png");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "myNES v5";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
    }
}

