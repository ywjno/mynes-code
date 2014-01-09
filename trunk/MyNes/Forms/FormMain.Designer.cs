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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentRomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.recordSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takesnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.softResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.saveStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStateAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStateAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.quickSaveStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickLoadStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSRAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSRAMAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSRAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSRAMAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameGenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMenuStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolsStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStatusStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.regionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aUTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nTSCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pALBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dENDYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.connectZapperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connect4PlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.frameskippingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSForNTSCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSForNTSCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSForNTSCToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.turboSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMyNesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_surface = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton_recents = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton_stateSlot = new System.Windows.Forms.ToolStripSplitButton();
            this.stateSlot0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateSlot9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.activeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.aUTOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nTSCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pALBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dENDYToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.profileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.connectZapperToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connect4PlayersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel_emulation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_tv = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_GameGenie = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_notifications = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_status = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.nesToolStripMenuItem,
            this.stateToolStripMenuItem,
            this.gameGenieToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(623, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MenuActivate += new System.EventHandler(this.menuStrip1_MenuActivate);
            this.menuStrip1.MenuDeactivate += new System.EventHandler(this.menuStrip1_MenuDeactivate);
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.recentRomsToolStripMenuItem,
            this.toolStripSeparator1,
            this.browserToolStripMenuItem,
            this.toolStripSeparator11,
            this.recordSoundToolStripMenuItem,
            this.takesnapshotToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            this.fileToolStripMenuItem.DropDownOpened += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpened);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.ToolTipText = "Open rom file.";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenRom);
            // 
            // recentRomsToolStripMenuItem
            // 
            this.recentRomsToolStripMenuItem.Name = "recentRomsToolStripMenuItem";
            this.recentRomsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.recentRomsToolStripMenuItem.Text = "Open recently played";
            this.recentRomsToolStripMenuItem.ToolTipText = "Open recently played rom file and start emulation.\r\nThis will apply all settings." +
    "";
            this.recentRomsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.recentRomsToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.Image = global::MyNes.Properties.Resources.application_view_gallery;
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.browserToolStripMenuItem.Text = "&Browser";
            this.browserToolStripMenuItem.ToolTipText = "Show My Nes Browser which allows to organize\r\nroms, manage rom folders, filter ro" +
    "ms ... etc";
            this.browserToolStripMenuItem.Click += new System.EventHandler(this.ShowBrowser);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(183, 6);
            // 
            // recordSoundToolStripMenuItem
            // 
            this.recordSoundToolStripMenuItem.Image = global::MyNes.Properties.Resources.Record;
            this.recordSoundToolStripMenuItem.Name = "recordSoundToolStripMenuItem";
            this.recordSoundToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.recordSoundToolStripMenuItem.Text = "&Record sound";
            this.recordSoundToolStripMenuItem.Click += new System.EventHandler(this.recordSoundToolStripMenuItem_Click);
            // 
            // takesnapshotToolStripMenuItem
            // 
            this.takesnapshotToolStripMenuItem.Image = global::MyNes.Properties.Resources.camera;
            this.takesnapshotToolStripMenuItem.Name = "takesnapshotToolStripMenuItem";
            this.takesnapshotToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.takesnapshotToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.takesnapshotToolStripMenuItem.Text = "Take &snapshot";
            this.takesnapshotToolStripMenuItem.ToolTipText = "Take a snapshot of render screen and save it to\r\nthe snapshots folder.\r\nTo change" +
    " the snapshots folder, go to Settings>Paths.";
            this.takesnapshotToolStripMenuItem.Click += new System.EventHandler(this.TakeSnapshot);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::MyNes.Properties.Resources.door_in;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.ToolTipText = "Exit My Nes.";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // nesToolStripMenuItem
            // 
            this.nesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.togglePauseToolStripMenuItem,
            this.toolStripSeparator3,
            this.softResetToolStripMenuItem,
            this.hardResetToolStripMenuItem,
            this.toolStripSeparator4,
            this.shutdownToolStripMenuItem});
            this.nesToolStripMenuItem.Name = "nesToolStripMenuItem";
            this.nesToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.nesToolStripMenuItem.Text = "&Nes";
            // 
            // togglePauseToolStripMenuItem
            // 
            this.togglePauseToolStripMenuItem.Image = global::MyNes.Properties.Resources.control_pause;
            this.togglePauseToolStripMenuItem.Name = "togglePauseToolStripMenuItem";
            this.togglePauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.togglePauseToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.togglePauseToolStripMenuItem.Text = "&Toggle pause";
            this.togglePauseToolStripMenuItem.ToolTipText = "Toggle emulation pause.";
            this.togglePauseToolStripMenuItem.Click += new System.EventHandler(this.TogglePause);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
            // 
            // softResetToolStripMenuItem
            // 
            this.softResetToolStripMenuItem.Image = global::MyNes.Properties.Resources.control_repeat_blue;
            this.softResetToolStripMenuItem.Name = "softResetToolStripMenuItem";
            this.softResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.softResetToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.softResetToolStripMenuItem.Text = "&Soft reset";
            this.softResetToolStripMenuItem.ToolTipText = "Soft reset emulation.\r\n(i.e. press the Nes reset button)";
            this.softResetToolStripMenuItem.Click += new System.EventHandler(this.SoftReset);
            // 
            // hardResetToolStripMenuItem
            // 
            this.hardResetToolStripMenuItem.Image = global::MyNes.Properties.Resources.control_repeat;
            this.hardResetToolStripMenuItem.Name = "hardResetToolStripMenuItem";
            this.hardResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.hardResetToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.hardResetToolStripMenuItem.Text = "&Hard reset";
            this.hardResetToolStripMenuItem.ToolTipText = "Hard reset the emulation.\r\n(i.e. shutdown emulation then reload the same rom)";
            this.hardResetToolStripMenuItem.Click += new System.EventHandler(this.HardReset);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(171, 6);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Image = global::MyNes.Properties.Resources.stop;
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.shutdownToolStripMenuItem.Text = "&Shutdown";
            this.shutdownToolStripMenuItem.ToolTipText = "Shutdown the emulation.";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // stateToolStripMenuItem
            // 
            this.stateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slotToolStripMenuItem,
            this.toolStripSeparator9,
            this.saveStateToolStripMenuItem,
            this.saveStateAsToolStripMenuItem,
            this.loadStateToolStripMenuItem,
            this.loadStateAsToolStripMenuItem,
            this.toolStripSeparator10,
            this.quickSaveStateToolStripMenuItem,
            this.quickLoadStateToolStripMenuItem,
            this.toolStripSeparator12,
            this.saveSRAMToolStripMenuItem,
            this.saveSRAMAsToolStripMenuItem,
            this.loadSRAMToolStripMenuItem,
            this.loadSRAMAsToolStripMenuItem});
            this.stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            this.stateToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.stateToolStripMenuItem.Text = "S&tate";
            this.stateToolStripMenuItem.DropDownOpening += new System.EventHandler(this.stateToolStripMenuItem_DropDownOpening);
            // 
            // slotToolStripMenuItem
            // 
            this.slotToolStripMenuItem.Name = "slotToolStripMenuItem";
            this.slotToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.slotToolStripMenuItem.Text = "&Slot";
            this.slotToolStripMenuItem.ToolTipText = "Choose state slot where to save game state(s).\r\nState files will be saved at stat" +
    "es folder which can\r\nbe changed via settings. To change this folder,\r\nGo to Sett" +
    "ings>Paths.";
            this.slotToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.slotToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(185, 6);
            // 
            // saveStateToolStripMenuItem
            // 
            this.saveStateToolStripMenuItem.Image = global::MyNes.Properties.Resources.disk;
            this.saveStateToolStripMenuItem.Name = "saveStateToolStripMenuItem";
            this.saveStateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.saveStateToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveStateToolStripMenuItem.Text = "&Save state";
            this.saveStateToolStripMenuItem.ToolTipText = "Save current game state at selected slot.\r\nThe state file will be saved at state " +
    "folder, to change\r\nthe state folder, go to Settings>Paths";
            this.saveStateToolStripMenuItem.Click += new System.EventHandler(this.SaveState);
            // 
            // saveStateAsToolStripMenuItem
            // 
            this.saveStateAsToolStripMenuItem.Name = "saveStateAsToolStripMenuItem";
            this.saveStateAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
            this.saveStateAsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveStateAsToolStripMenuItem.Text = "Save state as";
            this.saveStateAsToolStripMenuItem.ToolTipText = "Save current game state to file";
            this.saveStateAsToolStripMenuItem.Click += new System.EventHandler(this.SaveStateAs);
            // 
            // loadStateToolStripMenuItem
            // 
            this.loadStateToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_page_white;
            this.loadStateToolStripMenuItem.Name = "loadStateToolStripMenuItem";
            this.loadStateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.loadStateToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.loadStateToolStripMenuItem.Text = "&Load state";
            this.loadStateToolStripMenuItem.ToolTipText = "Load current game state from selected slot.\r\nThe state file will be loaded from s" +
    "tate folder,\r\nto change the state folder, go to Settings>Paths";
            this.loadStateToolStripMenuItem.Click += new System.EventHandler(this.LoadState);
            // 
            // loadStateAsToolStripMenuItem
            // 
            this.loadStateAsToolStripMenuItem.Name = "loadStateAsToolStripMenuItem";
            this.loadStateAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F9)));
            this.loadStateAsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.loadStateAsToolStripMenuItem.Text = "Load state as";
            this.loadStateAsToolStripMenuItem.ToolTipText = "Load current game state from file";
            this.loadStateAsToolStripMenuItem.Click += new System.EventHandler(this.LoadStateAs);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(185, 6);
            // 
            // quickSaveStateToolStripMenuItem
            // 
            this.quickSaveStateToolStripMenuItem.Name = "quickSaveStateToolStripMenuItem";
            this.quickSaveStateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.quickSaveStateToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quickSaveStateToolStripMenuItem.Text = "Quick save state";
            this.quickSaveStateToolStripMenuItem.ToolTipText = resources.GetString("quickSaveStateToolStripMenuItem.ToolTipText");
            this.quickSaveStateToolStripMenuItem.Click += new System.EventHandler(this.QuickSaveState);
            // 
            // quickLoadStateToolStripMenuItem
            // 
            this.quickLoadStateToolStripMenuItem.Name = "quickLoadStateToolStripMenuItem";
            this.quickLoadStateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.quickLoadStateToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quickLoadStateToolStripMenuItem.Text = "Quick load state";
            this.quickLoadStateToolStripMenuItem.ToolTipText = "Load the quick state that saved in memory.";
            this.quickLoadStateToolStripMenuItem.Click += new System.EventHandler(this.QuickLoadState);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(185, 6);
            // 
            // saveSRAMToolStripMenuItem
            // 
            this.saveSRAMToolStripMenuItem.Name = "saveSRAMToolStripMenuItem";
            this.saveSRAMToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveSRAMToolStripMenuItem.Text = "Save S-&RAM";
            this.saveSRAMToolStripMenuItem.ToolTipText = "Save current game Save-RAM if available";
            this.saveSRAMToolStripMenuItem.Click += new System.EventHandler(this.SaveSRAM);
            // 
            // saveSRAMAsToolStripMenuItem
            // 
            this.saveSRAMAsToolStripMenuItem.Name = "saveSRAMAsToolStripMenuItem";
            this.saveSRAMAsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveSRAMAsToolStripMenuItem.Text = "Save S-RAM as";
            this.saveSRAMAsToolStripMenuItem.ToolTipText = "Save current game Save-RAM if available to file";
            this.saveSRAMAsToolStripMenuItem.Click += new System.EventHandler(this.SaveSRAMAs);
            // 
            // loadSRAMToolStripMenuItem
            // 
            this.loadSRAMToolStripMenuItem.Name = "loadSRAMToolStripMenuItem";
            this.loadSRAMToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.loadSRAMToolStripMenuItem.Text = "Loa&d S-RAM";
            this.loadSRAMToolStripMenuItem.ToolTipText = "Load current game Save-RAM if available";
            this.loadSRAMToolStripMenuItem.Click += new System.EventHandler(this.LoadSRAM);
            // 
            // loadSRAMAsToolStripMenuItem
            // 
            this.loadSRAMAsToolStripMenuItem.Name = "loadSRAMAsToolStripMenuItem";
            this.loadSRAMAsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.loadSRAMAsToolStripMenuItem.Text = "Load S-RAM as";
            this.loadSRAMAsToolStripMenuItem.ToolTipText = "Load current game Save-RAM if available from file";
            this.loadSRAMAsToolStripMenuItem.Click += new System.EventHandler(this.LoadSRAMAs);
            // 
            // gameGenieToolStripMenuItem
            // 
            this.gameGenieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.configureToolStripMenuItem2});
            this.gameGenieToolStripMenuItem.Name = "gameGenieToolStripMenuItem";
            this.gameGenieToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.gameGenieToolStripMenuItem.Text = "&Game Genie";
            this.gameGenieToolStripMenuItem.DropDownOpening += new System.EventHandler(this.gameGenieToolStripMenuItem_DropDownOpening);
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.activeToolStripMenuItem.Text = "&Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.ActiveGameGenie);
            // 
            // configureToolStripMenuItem2
            // 
            this.configureToolStripMenuItem2.Image = global::MyNes.Properties.Resources.FileGame_genie_nes_front;
            this.configureToolStripMenuItem2.Name = "configureToolStripMenuItem2";
            this.configureToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.configureToolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.configureToolStripMenuItem2.Text = "&Configure";
            this.configureToolStripMenuItem2.Click += new System.EventHandler(this.ConfigureGameGenie);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMenuStripToolStripMenuItem,
            this.showToolsStripToolStripMenuItem,
            this.showStatusStripToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // showMenuStripToolStripMenuItem
            // 
            this.showMenuStripToolStripMenuItem.Checked = true;
            this.showMenuStripToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMenuStripToolStripMenuItem.Name = "showMenuStripToolStripMenuItem";
            this.showMenuStripToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.showMenuStripToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.showMenuStripToolStripMenuItem.Text = "Show menu strip";
            this.showMenuStripToolStripMenuItem.Click += new System.EventHandler(this.showMenuStripToolStripMenuItem_Click);
            // 
            // showToolsStripToolStripMenuItem
            // 
            this.showToolsStripToolStripMenuItem.Checked = true;
            this.showToolsStripToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToolsStripToolStripMenuItem.Name = "showToolsStripToolStripMenuItem";
            this.showToolsStripToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.showToolsStripToolStripMenuItem.Text = "Show tools strip";
            this.showToolsStripToolStripMenuItem.Click += new System.EventHandler(this.showToolsStripToolStripMenuItem_Click);
            // 
            // showStatusStripToolStripMenuItem
            // 
            this.showStatusStripToolStripMenuItem.Checked = true;
            this.showStatusStripToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStatusStripToolStripMenuItem.Name = "showStatusStripToolStripMenuItem";
            this.showStatusStripToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.showStatusStripToolStripMenuItem.Text = "Show status strip";
            this.showStatusStripToolStripMenuItem.Click += new System.EventHandler(this.showStatusStripToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.toolStripSeparator14,
            this.regionToolStripMenuItem,
            this.inputToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.paletteToolStripMenuItem,
            this.audioToolStripMenuItem,
            this.pathsToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.toolStripSeparator8,
            this.fullscreenToolStripMenuItem,
            this.toolStripSeparator13,
            this.frameskippingToolStripMenuItem,
            this.toolStripSeparator15,
            this.turboSpeedToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.toolsToolStripMenuItem.Text = "&Settings";
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolsToolStripMenuItem_DropDownOpening);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.languageToolStripMenuItem.Text = "&Language";
            this.languageToolStripMenuItem.ToolTipText = "Choose the interface language";
            this.languageToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.languageToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(162, 6);
            // 
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aUTOToolStripMenuItem,
            this.nTSCToolStripMenuItem,
            this.pALBToolStripMenuItem,
            this.dENDYToolStripMenuItem});
            this.regionToolStripMenuItem.Image = global::MyNes.Properties.Resources.world;
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.regionToolStripMenuItem.Text = "&Region";
            this.regionToolStripMenuItem.ToolTipText = "Select the region (TV System)\r\nYou\'ll need to HARD RESET to apply region setting." +
    "";
            this.regionToolStripMenuItem.DropDownOpening += new System.EventHandler(this.regionToolStripMenuItem_DropDownOpening);
            // 
            // aUTOToolStripMenuItem
            // 
            this.aUTOToolStripMenuItem.Checked = true;
            this.aUTOToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aUTOToolStripMenuItem.Name = "aUTOToolStripMenuItem";
            this.aUTOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.aUTOToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.aUTOToolStripMenuItem.Text = "&AUTO";
            this.aUTOToolStripMenuItem.ToolTipText = "Auto detect tv format depending on database \r\nif presented or rom file header.\r\n\r" +
    "\nYou\'ll need to hard reset game to apply region selection.";
            this.aUTOToolStripMenuItem.Click += new System.EventHandler(this.aUTOToolStripMenuItem_Click);
            // 
            // nTSCToolStripMenuItem
            // 
            this.nTSCToolStripMenuItem.Name = "nTSCToolStripMenuItem";
            this.nTSCToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.nTSCToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nTSCToolStripMenuItem.Text = "&NTSC";
            this.nTSCToolStripMenuItem.ToolTipText = "Force NTSC tv system.\r\nThis may not work well with PAL roms (e.i Europe\r\nregion r" +
    "om)\r\n\r\nYou\'ll need to hard reset game to apply region selection.";
            this.nTSCToolStripMenuItem.Click += new System.EventHandler(this.nTSCToolStripMenuItem_Click);
            // 
            // pALBToolStripMenuItem
            // 
            this.pALBToolStripMenuItem.Name = "pALBToolStripMenuItem";
            this.pALBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.pALBToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pALBToolStripMenuItem.Text = "&PALB";
            this.pALBToolStripMenuItem.ToolTipText = "Force PAL tv system.\r\nThis may not work well with NTSC  roms (e.i USA,\r\nUK .. reg" +
    "ions rom)\r\n\r\nYou\'ll need to hard reset game to apply region selection.";
            this.pALBToolStripMenuItem.Click += new System.EventHandler(this.pALBToolStripMenuItem_Click);
            // 
            // dENDYToolStripMenuItem
            // 
            this.dENDYToolStripMenuItem.Name = "dENDYToolStripMenuItem";
            this.dENDYToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.dENDYToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.dENDYToolStripMenuItem.Text = "&DENDY";
            this.dENDYToolStripMenuItem.ToolTipText = "Force DENDY tv format.\r\n\r\nYou\'ll need to hard reset game to apply region selectio" +
    "n.";
            this.dENDYToolStripMenuItem.Click += new System.EventHandler(this.dENDYToolStripMenuItem_Click);
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.toolStripSeparator7,
            this.connectZapperToolStripMenuItem,
            this.connect4PlayersToolStripMenuItem});
            this.inputToolStripMenuItem.Image = global::MyNes.Properties.Resources.controller;
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.inputToolStripMenuItem.Text = "&Input";
            this.inputToolStripMenuItem.ToolTipText = "Click to configure input settings.\r\n(i.e. configure Nes keys mapping)";
            this.inputToolStripMenuItem.DropDownOpening += new System.EventHandler(this.inputToolStripMenuItem_DropDownOpening);
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.ShowInputSetting);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.profileToolStripMenuItem.Text = "&Profile";
            this.profileToolStripMenuItem.ToolTipText = "Select the profile to use for input...\r\nTo configure profiles, click on Configure" +
    ".";
            this.profileToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.profileToolStripMenuItem_DropDownItemClicked);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.configureToolStripMenuItem.Text = "&Configure";
            this.configureToolStripMenuItem.ToolTipText = "Configure input settings such as profiles, mappings ...";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.ShowInputSetting);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(206, 6);
            // 
            // connectZapperToolStripMenuItem
            // 
            this.connectZapperToolStripMenuItem.Name = "connectZapperToolStripMenuItem";
            this.connectZapperToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.connectZapperToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.connectZapperToolStripMenuItem.Text = "Connect &Zapper";
            this.connectZapperToolStripMenuItem.ToolTipText = "Connect Zapper....\r\nThis will be saved to current profile.";
            this.connectZapperToolStripMenuItem.Click += new System.EventHandler(this.connectZapperToolStripMenuItem_Click);
            // 
            // connect4PlayersToolStripMenuItem
            // 
            this.connect4PlayersToolStripMenuItem.Name = "connect4PlayersToolStripMenuItem";
            this.connect4PlayersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.connect4PlayersToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.connect4PlayersToolStripMenuItem.Text = "Connect 4 P&layers";
            this.connect4PlayersToolStripMenuItem.ToolTipText = "Connect 4 players....\r\nThis will be saved to current profile.";
            this.connect4PlayersToolStripMenuItem.Click += new System.EventHandler(this.connect4PlayersToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Image = global::MyNes.Properties.Resources.monitor;
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.videoToolStripMenuItem.Text = "&Video";
            this.videoToolStripMenuItem.ToolTipText = "Configure video rendering settings.";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.ShowVideoSettings);
            // 
            // paletteToolStripMenuItem
            // 
            this.paletteToolStripMenuItem.Image = global::MyNes.Properties.Resources.color_wheel;
            this.paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
            this.paletteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.paletteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.paletteToolStripMenuItem.Text = "&Palette";
            this.paletteToolStripMenuItem.ToolTipText = "Configure palette settings.\r\nThis will not pause the emulation so settings\r\ncan b" +
    "e viewed directly on renderd image during\r\nplay-time.";
            this.paletteToolStripMenuItem.Click += new System.EventHandler(this.ShowPaletteSettings);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.Image = global::MyNes.Properties.Resources.sound;
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.audioToolStripMenuItem.Text = "&Audio";
            this.audioToolStripMenuItem.ToolTipText = "Cofigure audio settings.";
            this.audioToolStripMenuItem.Click += new System.EventHandler(this.ShowAudioSettings);
            // 
            // pathsToolStripMenuItem
            // 
            this.pathsToolStripMenuItem.Image = global::MyNes.Properties.Resources.folder_wrench;
            this.pathsToolStripMenuItem.Name = "pathsToolStripMenuItem";
            this.pathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.pathsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.pathsToolStripMenuItem.Text = "&Paths";
            this.pathsToolStripMenuItem.ToolTipText = "Configure paths settings.\r\nSuch as state folder, snapshots folder ...etc";
            this.pathsToolStripMenuItem.Click += new System.EventHandler(this.ShowPathsSettings);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Image = global::MyNes.Properties.Resources.wrench1;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences ....";
            this.preferencesToolStripMenuItem.ToolTipText = "Configure My Nes settings like emulation auto pause...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(162, 6);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.fullscreenToolStripMenuItem.Text = "&Fullscreen";
            this.fullscreenToolStripMenuItem.ToolTipText = "Switch fullscreen/windowed mode";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.SwitchToFullscreen);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(162, 6);
            // 
            // frameskippingToolStripMenuItem
            // 
            this.frameskippingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableToolStripMenuItem,
            this.fPSForNTSCToolStripMenuItem,
            this.fPSForNTSCToolStripMenuItem1,
            this.fPSForNTSCToolStripMenuItem2,
            this.toolStripMenuItem2});
            this.frameskippingToolStripMenuItem.Name = "frameskippingToolStripMenuItem";
            this.frameskippingToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.frameskippingToolStripMenuItem.Text = "Frame &skipping";
            this.frameskippingToolStripMenuItem.ToolTipText = resources.GetString("frameskippingToolStripMenuItem.ToolTipText");
            this.frameskippingToolStripMenuItem.DropDownOpening += new System.EventHandler(this.frameskippingToolStripMenuItem_DropDownOpening);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.disableToolStripMenuItem.Text = "&Disable";
            this.disableToolStripMenuItem.ToolTipText = "No frame skip.";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // fPSForNTSCToolStripMenuItem
            // 
            this.fPSForNTSCToolStripMenuItem.Name = "fPSForNTSCToolStripMenuItem";
            this.fPSForNTSCToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.fPSForNTSCToolStripMenuItem.Text = "1 (30 FPS for NTSC, 25 FPS for PAL)";
            this.fPSForNTSCToolStripMenuItem.Click += new System.EventHandler(this.fPSForNTSCToolStripMenuItem_Click);
            // 
            // fPSForNTSCToolStripMenuItem1
            // 
            this.fPSForNTSCToolStripMenuItem1.Name = "fPSForNTSCToolStripMenuItem1";
            this.fPSForNTSCToolStripMenuItem1.Size = new System.Drawing.Size(267, 22);
            this.fPSForNTSCToolStripMenuItem1.Text = "2 (15 FPS for NTSC, 12.5 FPS for PAL)";
            this.fPSForNTSCToolStripMenuItem1.Click += new System.EventHandler(this.fPSForNTSCToolStripMenuItem1_Click);
            // 
            // fPSForNTSCToolStripMenuItem2
            // 
            this.fPSForNTSCToolStripMenuItem2.Name = "fPSForNTSCToolStripMenuItem2";
            this.fPSForNTSCToolStripMenuItem2.Size = new System.Drawing.Size(267, 22);
            this.fPSForNTSCToolStripMenuItem2.Text = "3 (10 FPS for NTSC, 8.3 FPS for PAL)";
            this.fPSForNTSCToolStripMenuItem2.Click += new System.EventHandler(this.fPSForNTSCToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(267, 22);
            this.toolStripMenuItem2.Text = "4 (7 FPS for NTSC, 6.25 FPS for PAL)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(162, 6);
            // 
            // turboSpeedToolStripMenuItem
            // 
            this.turboSpeedToolStripMenuItem.Name = "turboSpeedToolStripMenuItem";
            this.turboSpeedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.turboSpeedToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.turboSpeedToolStripMenuItem.Text = "Turbo speed";
            this.turboSpeedToolStripMenuItem.ToolTipText = "Disable the speed limiter to run emulation in maximum\r\nspeed. \r\nDisabled on Hard " +
    "reset and game load.";
            this.turboSpeedToolStripMenuItem.Click += new System.EventHandler(this.ToggleTurbo);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.memoryToolStripMenuItem,
            this.speedToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "&Debug";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.consoleToolStripMenuItem.Text = "&Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.ShowConsole);
            // 
            // memoryToolStripMenuItem
            // 
            this.memoryToolStripMenuItem.Name = "memoryToolStripMenuItem";
            this.memoryToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.memoryToolStripMenuItem.Text = "&Memory";
            this.memoryToolStripMenuItem.Click += new System.EventHandler(this.ShowMemoryWatcher);
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.speedToolStripMenuItem.Text = "&Speed";
            this.speedToolStripMenuItem.Click += new System.EventHandler(this.ShowSpeed);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripSeparator2,
            this.aboutMyNesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = global::MyNes.Properties.Resources.help;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.ToolTipText = "View help document contents.";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.ShowHelp);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // aboutMyNesToolStripMenuItem
            // 
            this.aboutMyNesToolStripMenuItem.Image = global::MyNes.Properties.Resources.MyNes;
            this.aboutMyNesToolStripMenuItem.Name = "aboutMyNesToolStripMenuItem";
            this.aboutMyNesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutMyNesToolStripMenuItem.Text = "&About My Nes";
            this.aboutMyNesToolStripMenuItem.ToolTipText = "Show My Nes about box";
            this.aboutMyNesToolStripMenuItem.Click += new System.EventHandler(this.aboutMyNesToolStripMenuItem_Click);
            // 
            // panel_surface
            // 
            this.panel_surface.BackColor = System.Drawing.Color.Black;
            this.panel_surface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_surface.Location = new System.Drawing.Point(0, 49);
            this.panel_surface.Name = "panel_surface";
            this.panel_surface.Size = new System.Drawing.Size(623, 401);
            this.panel_surface.TabIndex = 1;
            this.panel_surface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton_recents,
            this.toolStripButton2,
            this.toolStripSeparator6,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton3,
            this.toolStripButton6,
            this.toolStripSeparator16,
            this.toolStripSplitButton_stateSlot,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator17,
            this.toolStripSplitButton3,
            this.toolStripSeparator20,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2,
            this.toolStripButton11,
            this.toolStripButton10,
            this.toolStripButton12,
            this.toolStripButton13,
            this.toolStripButton1,
            this.toolStripSeparator18,
            this.toolStripButton14});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(623, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton_recents
            // 
            this.toolStripSplitButton_recents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton_recents.Image = global::MyNes.Properties.Resources.folder;
            this.toolStripSplitButton_recents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_recents.Name = "toolStripSplitButton_recents";
            this.toolStripSplitButton_recents.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton_recents.Text = "toolStripSplitButton3";
            this.toolStripSplitButton_recents.ToolTipText = "Open rom file.";
            this.toolStripSplitButton_recents.ButtonClick += new System.EventHandler(this.OpenRom);
            this.toolStripSplitButton_recents.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.recentRomsToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::MyNes.Properties.Resources.application_view_gallery;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Show browser";
            this.toolStripButton2.ToolTipText = "Show My Nes Browser which allows to organize\r\nroms, manage rom folders, filter ro" +
    "ms ... etc";
            this.toolStripButton2.Click += new System.EventHandler(this.ShowBrowser);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::MyNes.Properties.Resources.control_repeat;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Hard reset";
            this.toolStripButton4.ToolTipText = "Hard reset the emulation.\r\n(i.e. shutdown emulation then reload the same rom)";
            this.toolStripButton4.Click += new System.EventHandler(this.HardReset);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::MyNes.Properties.Resources.control_repeat_blue;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Soft reset";
            this.toolStripButton5.ToolTipText = "Soft reset emulation.\r\n(i.e. press the Nes reset button)";
            this.toolStripButton5.Click += new System.EventHandler(this.SoftReset);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::MyNes.Properties.Resources.control_pause;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Toggle emulation pause";
            this.toolStripButton3.Click += new System.EventHandler(this.TogglePause);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::MyNes.Properties.Resources.stop;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Shutdown emulation";
            this.toolStripButton6.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton_stateSlot
            // 
            this.toolStripSplitButton_stateSlot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton_stateSlot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stateSlot0ToolStripMenuItem,
            this.stateSlot1ToolStripMenuItem,
            this.stateSlot2ToolStripMenuItem,
            this.stateSlot3ToolStripMenuItem,
            this.stateSlot4ToolStripMenuItem,
            this.stateSlot5ToolStripMenuItem,
            this.stateSlot6ToolStripMenuItem,
            this.stateSlot7ToolStripMenuItem,
            this.stateSlot8ToolStripMenuItem,
            this.stateSlot9ToolStripMenuItem});
            this.toolStripSplitButton_stateSlot.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_stateSlot.Image")));
            this.toolStripSplitButton_stateSlot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_stateSlot.Name = "toolStripSplitButton_stateSlot";
            this.toolStripSplitButton_stateSlot.Size = new System.Drawing.Size(81, 22);
            this.toolStripSplitButton_stateSlot.Text = "State Slot 0";
            this.toolStripSplitButton_stateSlot.ToolTipText = "Choose state slot where to save game state(s).\r\nState files will be saved at stat" +
    "es folder which can\r\nbe changed via settings. To change this folder,\r\nGo to Sett" +
    "ings>Paths.";
            this.toolStripSplitButton_stateSlot.ButtonClick += new System.EventHandler(this.toolStripSplitButton_stateSlot_ButtonClick);
            this.toolStripSplitButton_stateSlot.DropDownOpening += new System.EventHandler(this.toolStripSplitButton2_DropDownOpening);
            this.toolStripSplitButton_stateSlot.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripSplitButton2_DropDownItemClicked);
            // 
            // stateSlot0ToolStripMenuItem
            // 
            this.stateSlot0ToolStripMenuItem.Name = "stateSlot0ToolStripMenuItem";
            this.stateSlot0ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot0ToolStripMenuItem.Text = "State Slot 0";
            // 
            // stateSlot1ToolStripMenuItem
            // 
            this.stateSlot1ToolStripMenuItem.Name = "stateSlot1ToolStripMenuItem";
            this.stateSlot1ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot1ToolStripMenuItem.Text = "State Slot 1";
            // 
            // stateSlot2ToolStripMenuItem
            // 
            this.stateSlot2ToolStripMenuItem.Name = "stateSlot2ToolStripMenuItem";
            this.stateSlot2ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot2ToolStripMenuItem.Text = "State Slot 2";
            // 
            // stateSlot3ToolStripMenuItem
            // 
            this.stateSlot3ToolStripMenuItem.Name = "stateSlot3ToolStripMenuItem";
            this.stateSlot3ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot3ToolStripMenuItem.Text = "State Slot 3";
            // 
            // stateSlot4ToolStripMenuItem
            // 
            this.stateSlot4ToolStripMenuItem.Name = "stateSlot4ToolStripMenuItem";
            this.stateSlot4ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot4ToolStripMenuItem.Text = "State Slot 4";
            // 
            // stateSlot5ToolStripMenuItem
            // 
            this.stateSlot5ToolStripMenuItem.Name = "stateSlot5ToolStripMenuItem";
            this.stateSlot5ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot5ToolStripMenuItem.Text = "State Slot 5";
            // 
            // stateSlot6ToolStripMenuItem
            // 
            this.stateSlot6ToolStripMenuItem.Name = "stateSlot6ToolStripMenuItem";
            this.stateSlot6ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot6ToolStripMenuItem.Text = "State Slot 6";
            // 
            // stateSlot7ToolStripMenuItem
            // 
            this.stateSlot7ToolStripMenuItem.Name = "stateSlot7ToolStripMenuItem";
            this.stateSlot7ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot7ToolStripMenuItem.Text = "State Slot 7";
            // 
            // stateSlot8ToolStripMenuItem
            // 
            this.stateSlot8ToolStripMenuItem.Name = "stateSlot8ToolStripMenuItem";
            this.stateSlot8ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot8ToolStripMenuItem.Text = "State Slot 8";
            // 
            // stateSlot9ToolStripMenuItem
            // 
            this.stateSlot9ToolStripMenuItem.Name = "stateSlot9ToolStripMenuItem";
            this.stateSlot9ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.stateSlot9ToolStripMenuItem.Text = "State Slot 9";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::MyNes.Properties.Resources.disk;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Save state at current state slot";
            this.toolStripButton7.ToolTipText = "Save current game state at selected slot.\r\nThe state file will be saved at state " +
    "folder, to change\r\nthe state folder, go to Settings>Paths";
            this.toolStripButton7.Click += new System.EventHandler(this.SaveState);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::MyNes.Properties.Resources.folder_page_white;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Load state from current state slot";
            this.toolStripButton8.ToolTipText = "Load current game state from selected slot.\r\nThe state file will be loaded from s" +
    "tate folder,\r\nto change the state folder, go to Settings>Paths";
            this.toolStripButton8.Click += new System.EventHandler(this.LoadState);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem1,
            this.configureToolStripMenuItem3});
            this.toolStripSplitButton3.Image = global::MyNes.Properties.Resources.FileGame_genie_nes_front;
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton3.Text = "Game Genie";
            this.toolStripSplitButton3.ToolTipText = "Game Genie\r\nClick to configure for current game (must be running)";
            this.toolStripSplitButton3.ButtonClick += new System.EventHandler(this.ConfigureGameGenie);
            this.toolStripSplitButton3.DropDownOpening += new System.EventHandler(this.toolStripSplitButton3_DropDownOpening);
            // 
            // activeToolStripMenuItem1
            // 
            this.activeToolStripMenuItem1.Name = "activeToolStripMenuItem1";
            this.activeToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.activeToolStripMenuItem1.Text = "&Active";
            this.activeToolStripMenuItem1.Click += new System.EventHandler(this.ActiveGameGenie);
            // 
            // configureToolStripMenuItem3
            // 
            this.configureToolStripMenuItem3.Image = global::MyNes.Properties.Resources.FileGame_genie_nes_front;
            this.configureToolStripMenuItem3.Name = "configureToolStripMenuItem3";
            this.configureToolStripMenuItem3.Size = new System.Drawing.Size(127, 22);
            this.configureToolStripMenuItem3.Text = "&Configure";
            this.configureToolStripMenuItem3.Click += new System.EventHandler(this.ConfigureGameGenie);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aUTOToolStripMenuItem1,
            this.nTSCToolStripMenuItem1,
            this.pALBToolStripMenuItem1,
            this.dENDYToolStripMenuItem1});
            this.toolStripSplitButton1.Image = global::MyNes.Properties.Resources.world;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "Region";
            this.toolStripSplitButton1.ToolTipText = "Select the region (TV System)\r\nYou\'ll need to HARD RESET to apply region setting." +
    "";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            this.toolStripSplitButton1.DropDownOpening += new System.EventHandler(this.toolStripSplitButton1_DropDownOpening);
            // 
            // aUTOToolStripMenuItem1
            // 
            this.aUTOToolStripMenuItem1.Name = "aUTOToolStripMenuItem1";
            this.aUTOToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.aUTOToolStripMenuItem1.Text = "AUTO";
            this.aUTOToolStripMenuItem1.Click += new System.EventHandler(this.aUTOToolStripMenuItem_Click);
            // 
            // nTSCToolStripMenuItem1
            // 
            this.nTSCToolStripMenuItem1.Name = "nTSCToolStripMenuItem1";
            this.nTSCToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.nTSCToolStripMenuItem1.Text = "NTSC";
            this.nTSCToolStripMenuItem1.Click += new System.EventHandler(this.nTSCToolStripMenuItem_Click);
            // 
            // pALBToolStripMenuItem1
            // 
            this.pALBToolStripMenuItem1.Name = "pALBToolStripMenuItem1";
            this.pALBToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.pALBToolStripMenuItem1.Text = "PALB";
            this.pALBToolStripMenuItem1.Click += new System.EventHandler(this.pALBToolStripMenuItem_Click);
            // 
            // dENDYToolStripMenuItem1
            // 
            this.dENDYToolStripMenuItem1.Name = "dENDYToolStripMenuItem1";
            this.dENDYToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.dENDYToolStripMenuItem1.Text = "DENDY";
            this.dENDYToolStripMenuItem1.Click += new System.EventHandler(this.dENDYToolStripMenuItem_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem1,
            this.configureToolStripMenuItem1,
            this.toolStripSeparator19,
            this.connectZapperToolStripMenuItem1,
            this.connect4PlayersToolStripMenuItem1});
            this.toolStripSplitButton2.Image = global::MyNes.Properties.Resources.controller;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton2.Text = "Input settings.";
            this.toolStripSplitButton2.ToolTipText = "Input settings.\r\nClick to configure input.";
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.ShowInputSetting);
            this.toolStripSplitButton2.DropDownOpening += new System.EventHandler(this.toolStripSplitButton2_DropDownOpening_1);
            // 
            // profileToolStripMenuItem1
            // 
            this.profileToolStripMenuItem1.Name = "profileToolStripMenuItem1";
            this.profileToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.profileToolStripMenuItem1.Text = "&Profile";
            this.profileToolStripMenuItem1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.profileToolStripMenuItem_DropDownItemClicked);
            // 
            // configureToolStripMenuItem1
            // 
            this.configureToolStripMenuItem1.Name = "configureToolStripMenuItem1";
            this.configureToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.configureToolStripMenuItem1.Text = "&Configure";
            this.configureToolStripMenuItem1.Click += new System.EventHandler(this.ShowInputSetting);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(165, 6);
            // 
            // connectZapperToolStripMenuItem1
            // 
            this.connectZapperToolStripMenuItem1.Name = "connectZapperToolStripMenuItem1";
            this.connectZapperToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.connectZapperToolStripMenuItem1.Text = "Connect &Zapper";
            this.connectZapperToolStripMenuItem1.Click += new System.EventHandler(this.connectZapperToolStripMenuItem_Click);
            // 
            // connect4PlayersToolStripMenuItem1
            // 
            this.connect4PlayersToolStripMenuItem1.Name = "connect4PlayersToolStripMenuItem1";
            this.connect4PlayersToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.connect4PlayersToolStripMenuItem1.Text = "Connect 4 P&layers";
            this.connect4PlayersToolStripMenuItem1.Click += new System.EventHandler(this.connect4PlayersToolStripMenuItem_Click);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = global::MyNes.Properties.Resources.sound;
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "Audio configuration";
            this.toolStripButton11.ToolTipText = "Cofigure audio settings.";
            this.toolStripButton11.Click += new System.EventHandler(this.ShowAudioSettings);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = global::MyNes.Properties.Resources.monitor;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "Video configuration";
            this.toolStripButton10.ToolTipText = "Configure video rendering settings.";
            this.toolStripButton10.Click += new System.EventHandler(this.ShowVideoSettings);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = global::MyNes.Properties.Resources.color_wheel;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton12.Text = "Palette configuration";
            this.toolStripButton12.ToolTipText = "Configure palette settings.\r\nThis will not pause the emulation so settings\r\ncan b" +
    "e viewed directly on renderd image during\r\nplay-time.";
            this.toolStripButton12.Click += new System.EventHandler(this.ShowPaletteSettings);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = global::MyNes.Properties.Resources.folder_wrench;
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton13.Text = "Paths configuration";
            this.toolStripButton13.ToolTipText = "Configure paths settings.\r\nSuch as state folder, snapshots folder ...etc";
            this.toolStripButton13.Click += new System.EventHandler(this.ShowPathsSettings);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MyNes.Properties.Resources.wrench;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Preferences";
            this.toolStripButton1.ToolTipText = "Configure My Nes settings like emulation auto pause...";
            this.toolStripButton1.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = global::MyNes.Properties.Resources.help;
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton14.Text = "Show help";
            this.toolStripButton14.ToolTipText = "Show help document contents";
            this.toolStripButton14.Click += new System.EventHandler(this.ShowHelp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel_emulation,
            this.toolStripStatusLabel1,
            this.StatusLabel_tv,
            this.toolStripStatusLabel2,
            this.StatusLabel_GameGenie,
            this.toolStripStatusLabel3,
            this.StatusLabel_notifications});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(623, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel_emulation
            // 
            this.StatusLabel_emulation.AutoSize = false;
            this.StatusLabel_emulation.Name = "StatusLabel_emulation";
            this.StatusLabel_emulation.Size = new System.Drawing.Size(110, 17);
            this.StatusLabel_emulation.Text = "Emulation: OFF";
            this.StatusLabel_emulation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Enabled = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // StatusLabel_tv
            // 
            this.StatusLabel_tv.AutoSize = false;
            this.StatusLabel_tv.Name = "StatusLabel_tv";
            this.StatusLabel_tv.Size = new System.Drawing.Size(50, 17);
            this.StatusLabel_tv.Text = "NTSC";
            this.StatusLabel_tv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Enabled = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // StatusLabel_GameGenie
            // 
            this.StatusLabel_GameGenie.AutoSize = false;
            this.StatusLabel_GameGenie.ForeColor = System.Drawing.Color.Green;
            this.StatusLabel_GameGenie.Name = "StatusLabel_GameGenie";
            this.StatusLabel_GameGenie.Size = new System.Drawing.Size(71, 17);
            this.StatusLabel_GameGenie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Enabled = false;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // StatusLabel_notifications
            // 
            this.StatusLabel_notifications.Name = "StatusLabel_notifications";
            this.StatusLabel_notifications.Size = new System.Drawing.Size(0, 17);
            // 
            // timer_status
            // 
            this.timer_status.Enabled = true;
            this.timer_status.Interval = 1000;
            this.timer_status.Tick += new System.EventHandler(this.timer_status_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 472);
            this.Controls.Add(this.panel_surface);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "My Nes [v6 beta]";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.FormMain_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutMyNesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.Panel panel_surface;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aUTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nTSCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pALBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dENDYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem togglePauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem hardResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem recentRomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem recordSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem connectZapperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connect4PlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takesnapshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem fullscreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slotToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem saveStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStateAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStateAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem quickSaveStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickLoadStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem saveSRAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSRAMAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSRAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSRAMAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem turboSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem frameskippingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fPSForNTSCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fPSForNTSCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fPSForNTSCToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMenuStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolsStripToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem aUTOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nTSCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pALBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dENDYToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_stateSlot;
        private System.Windows.Forms.ToolStripMenuItem stateSlot0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateSlot9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_recents;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_emulation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_tv;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer_status;
        private System.Windows.Forms.ToolStripMenuItem showStatusStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_notifications;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem connectZapperToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connect4PlayersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gameGenieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_GameGenie;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}

