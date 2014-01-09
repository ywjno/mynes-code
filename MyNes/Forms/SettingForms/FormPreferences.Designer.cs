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
    partial class FormPreferences
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_autoMinimizeBrowser = new System.Windows.Forms.CheckBox();
            this.checkBox_saveSram = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox_pauseEmu = new System.Windows.Forms.CheckBox();
            this.checkBox_autoHideMouse = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_autohideCursorPeriod = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_autohideCursorPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(258, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Save";
            this.toolTip1.SetToolTip(this.button1, "Save, apply and close.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(177, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "&Cancel";
            this.toolTip1.SetToolTip(this.button2, "Discard changes and close");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_autoMinimizeBrowser
            // 
            this.checkBox_autoMinimizeBrowser.AutoSize = true;
            this.checkBox_autoMinimizeBrowser.Location = new System.Drawing.Point(12, 12);
            this.checkBox_autoMinimizeBrowser.Name = "checkBox_autoMinimizeBrowser";
            this.checkBox_autoMinimizeBrowser.Size = new System.Drawing.Size(272, 17);
            this.checkBox_autoMinimizeBrowser.TabIndex = 2;
            this.checkBox_autoMinimizeBrowser.Text = "&Auto minimize the browser window when rom open.";
            this.toolTip1.SetToolTip(this.checkBox_autoMinimizeBrowser, "If enabled, My Nes will auto minimize the browser\r\nif opened once a game loaded.");
            this.checkBox_autoMinimizeBrowser.UseVisualStyleBackColor = true;
            // 
            // checkBox_saveSram
            // 
            this.checkBox_saveSram.AutoSize = true;
            this.checkBox_saveSram.Location = new System.Drawing.Point(12, 35);
            this.checkBox_saveSram.Name = "checkBox_saveSram";
            this.checkBox_saveSram.Size = new System.Drawing.Size(241, 17);
            this.checkBox_saveSram.TabIndex = 3;
            this.checkBox_saveSram.Text = "Auto &save save-ram on emulation shutdown.";
            this.toolTip1.SetToolTip(this.checkBox_saveSram, "Check this to enable auto S-RAM save on emulation\r\nshutdown if the game is batter" +
        "y backed.\r\nThe S-RAM files will be saved at the SaveRAM folder\r\nwhich can be cha" +
        "nged in the Paths settings.");
            this.checkBox_saveSram.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(12, 154);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "&Defaults";
            this.toolTip1.SetToolTip(this.button3, "Restore defaults");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox_pauseEmu
            // 
            this.checkBox_pauseEmu.AutoSize = true;
            this.checkBox_pauseEmu.Location = new System.Drawing.Point(12, 58);
            this.checkBox_pauseEmu.Name = "checkBox_pauseEmu";
            this.checkBox_pauseEmu.Size = new System.Drawing.Size(268, 17);
            this.checkBox_pauseEmu.TabIndex = 5;
            this.checkBox_pauseEmu.Text = "&Pause emulation on focus lost of the main window.";
            this.toolTip1.SetToolTip(this.checkBox_pauseEmu, "Enable auto pause emulation when My Nes window\r\nis no longer the active form on d" +
        "esktop.");
            this.checkBox_pauseEmu.UseVisualStyleBackColor = true;
            // 
            // checkBox_autoHideMouse
            // 
            this.checkBox_autoHideMouse.AutoSize = true;
            this.checkBox_autoHideMouse.Location = new System.Drawing.Point(12, 81);
            this.checkBox_autoHideMouse.Name = "checkBox_autoHideMouse";
            this.checkBox_autoHideMouse.Size = new System.Drawing.Size(246, 17);
            this.checkBox_autoHideMouse.TabIndex = 6;
            this.checkBox_autoHideMouse.Text = "Auto hide mouse cursor on emulation run-time";
            this.toolTip1.SetToolTip(this.checkBox_autoHideMouse, "Enable the auto mouse cursor hiding. This will\r\nmake My Nes hide the cursor after" +
        " launching a\r\ngame after a period of time you specify in the\r\nfield below.");
            this.checkBox_autoHideMouse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hide mouse cursor after:";
            // 
            // numericUpDown_autohideCursorPeriod
            // 
            this.numericUpDown_autohideCursorPeriod.Location = new System.Drawing.Point(141, 104);
            this.numericUpDown_autohideCursorPeriod.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_autohideCursorPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_autohideCursorPeriod.Name = "numericUpDown_autohideCursorPeriod";
            this.numericUpDown_autohideCursorPeriod.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown_autohideCursorPeriod.TabIndex = 8;
            this.toolTip1.SetToolTip(this.numericUpDown_autohideCursorPeriod, "How many seconds My Nes should wait to hide\r\nthe mouse cursor if auto mouse curso" +
        "r hiding is \r\nenabled.");
            this.numericUpDown_autohideCursorPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Second(s)";
            // 
            // FormPreferences
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 189);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_autohideCursorPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_autoHideMouse);
            this.Controls.Add(this.checkBox_pauseEmu);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox_saveSram);
            this.Controls.Add(this.checkBox_autoMinimizeBrowser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_autohideCursorPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox_autoMinimizeBrowser;
        private System.Windows.Forms.CheckBox checkBox_saveSram;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox_pauseEmu;
        private System.Windows.Forms.CheckBox checkBox_autoHideMouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_autohideCursorPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}