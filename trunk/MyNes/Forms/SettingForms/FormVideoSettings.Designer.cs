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
    partial class FormVideoSettings
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
            this.checkBox_fullscreen = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_keepAspectRatio = new System.Windows.Forms.CheckBox();
            this.checkBox_showNot = new System.Windows.Forms.CheckBox();
            this.checkBox_showFps = new System.Windows.Forms.CheckBox();
            this.checkBox_immediateMode = new System.Windows.Forms.CheckBox();
            this.checkBox_hideLines = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_mode = new System.Windows.Forms.ComboBox();
            this.comboBox_fullscreenRes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_snapshotFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_windowSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_stretchWindow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_fullscreen
            // 
            this.checkBox_fullscreen.AutoSize = true;
            this.checkBox_fullscreen.Location = new System.Drawing.Point(12, 52);
            this.checkBox_fullscreen.Name = "checkBox_fullscreen";
            this.checkBox_fullscreen.Size = new System.Drawing.Size(149, 17);
            this.checkBox_fullscreen.TabIndex = 0;
            this.checkBox_fullscreen.Text = "Launch game in &fullscreen";
            this.toolTip1.SetToolTip(this.checkBox_fullscreen, "If enabled, the game will launch in fullscreen.\r\nYou can switch to fullscreen mod" +
        "e anytime, just\r\npress F12.");
            this.checkBox_fullscreen.UseVisualStyleBackColor = true;
            // 
            // checkBox_keepAspectRatio
            // 
            this.checkBox_keepAspectRatio.AutoSize = true;
            this.checkBox_keepAspectRatio.Location = new System.Drawing.Point(12, 193);
            this.checkBox_keepAspectRatio.Name = "checkBox_keepAspectRatio";
            this.checkBox_keepAspectRatio.Size = new System.Drawing.Size(274, 17);
            this.checkBox_keepAspectRatio.TabIndex = 1;
            this.checkBox_keepAspectRatio.Text = "Keep &aspect ratio when stretching rendering image.";
            this.toolTip1.SetToolTip(this.checkBox_keepAspectRatio, "If enabled, the rendered image will keep\r\naspect ratio of 4:3 (nes default).\r\nOth" +
        "erwise, image drawed stretched to the \r\nrender window size. ");
            this.checkBox_keepAspectRatio.UseVisualStyleBackColor = true;
            // 
            // checkBox_showNot
            // 
            this.checkBox_showNot.AutoSize = true;
            this.checkBox_showNot.Location = new System.Drawing.Point(12, 291);
            this.checkBox_showNot.Name = "checkBox_showNot";
            this.checkBox_showNot.Size = new System.Drawing.Size(102, 17);
            this.checkBox_showNot.TabIndex = 2;
            this.checkBox_showNot.Text = "Show &messages";
            this.toolTip1.SetToolTip(this.checkBox_showNot, "If enabled, the renderer will show important\r\nmessages in the renderer window suc" +
        "h as \r\nstate save/load notify.");
            this.checkBox_showNot.UseVisualStyleBackColor = true;
            // 
            // checkBox_showFps
            // 
            this.checkBox_showFps.AutoSize = true;
            this.checkBox_showFps.Location = new System.Drawing.Point(120, 291);
            this.checkBox_showFps.Name = "checkBox_showFps";
            this.checkBox_showFps.Size = new System.Drawing.Size(73, 17);
            this.checkBox_showFps.TabIndex = 3;
            this.checkBox_showFps.Text = "Show &FPS";
            this.toolTip1.SetToolTip(this.checkBox_showFps, "If enabled, the renderer will show FPS (frames per seconds)\r\nin the left-top of t" +
        "he render window. ");
            this.checkBox_showFps.UseVisualStyleBackColor = true;
            // 
            // checkBox_immediateMode
            // 
            this.checkBox_immediateMode.AutoSize = true;
            this.checkBox_immediateMode.Location = new System.Drawing.Point(12, 216);
            this.checkBox_immediateMode.Name = "checkBox_immediateMode";
            this.checkBox_immediateMode.Size = new System.Drawing.Size(105, 17);
            this.checkBox_immediateMode.TabIndex = 8;
            this.checkBox_immediateMode.Text = "&Immediate mode";
            this.toolTip1.SetToolTip(this.checkBox_immediateMode, "If enabled, the renderer will not wait for complete\r\nframe image to render.\r\nThis" +
        " option may improve performance but may cause\r\nshettering in render image specia" +
        "lly in fullscreen.");
            this.checkBox_immediateMode.UseVisualStyleBackColor = true;
            // 
            // checkBox_hideLines
            // 
            this.checkBox_hideLines.AutoSize = true;
            this.checkBox_hideLines.Location = new System.Drawing.Point(123, 216);
            this.checkBox_hideLines.Name = "checkBox_hideLines";
            this.checkBox_hideLines.Size = new System.Drawing.Size(191, 17);
            this.checkBox_hideLines.TabIndex = 9;
            this.checkBox_hideLines.Text = "&Hide lines (8 for NTSC, 1 for PALB)";
            this.toolTip1.SetToolTip(this.checkBox_hideLines, "If enabled, the renderer will hide first 8/1 line(s), implementing\r\nthe nes behav" +
        "ior.");
            this.checkBox_hideLines.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "&Settings";
            this.toolTip1.SetToolTip(this.button1, "Show selected mode settings");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(279, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "&Save";
            this.toolTip1.SetToolTip(this.button2, "Save changes and close.\r\nYou\'ll need to reset current game to apply video setting" +
        "s.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(198, 350);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "&Cancel";
            this.toolTip1.SetToolTip(this.button3, "Discard changes and close");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(12, 350);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "&Defaults";
            this.toolTip1.SetToolTip(this.button4, "Reset all video settings to defaults");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mode:";
            // 
            // comboBox_mode
            // 
            this.comboBox_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mode.FormattingEnabled = true;
            this.comboBox_mode.Items.AddRange(new object[] {
            "DirectX9 [SlimDX]"});
            this.comboBox_mode.Location = new System.Drawing.Point(12, 25);
            this.comboBox_mode.Name = "comboBox_mode";
            this.comboBox_mode.Size = new System.Drawing.Size(258, 21);
            this.comboBox_mode.TabIndex = 5;
            // 
            // comboBox_fullscreenRes
            // 
            this.comboBox_fullscreenRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fullscreenRes.FormattingEnabled = true;
            this.comboBox_fullscreenRes.Location = new System.Drawing.Point(12, 88);
            this.comboBox_fullscreenRes.Name = "comboBox_fullscreenRes";
            this.comboBox_fullscreenRes.Size = new System.Drawing.Size(258, 21);
            this.comboBox_fullscreenRes.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fullscreen resolution:";
            // 
            // comboBox_snapshotFormat
            // 
            this.comboBox_snapshotFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_snapshotFormat.FormattingEnabled = true;
            this.comboBox_snapshotFormat.Items.AddRange(new object[] {
            ".bmp",
            ".gif",
            ".jpg",
            ".png",
            ".tiff",
            ".emf",
            ".wmf",
            ".exif"});
            this.comboBox_snapshotFormat.Location = new System.Drawing.Point(12, 264);
            this.comboBox_snapshotFormat.Name = "comboBox_snapshotFormat";
            this.comboBox_snapshotFormat.Size = new System.Drawing.Size(258, 21);
            this.comboBox_snapshotFormat.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Snapshot format:";
            // 
            // comboBox_windowSize
            // 
            this.comboBox_windowSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_windowSize.FormattingEnabled = true;
            this.comboBox_windowSize.Items.AddRange(new object[] {
            "256 x 240     (x1)",
            "512 x 480     (x2)",
            "768 x 720     (x3)",
            "1024 x 960   (x4)",
            "1280 x 1200 (x5)"});
            this.comboBox_windowSize.Location = new System.Drawing.Point(12, 156);
            this.comboBox_windowSize.Name = "comboBox_windowSize";
            this.comboBox_windowSize.Size = new System.Drawing.Size(258, 21);
            this.comboBox_windowSize.TabIndex = 18;
            this.toolTip1.SetToolTip(this.comboBox_windowSize, "Select the window size (windowed mode only)");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Window size:";
            // 
            // checkBox_stretchWindow
            // 
            this.checkBox_stretchWindow.AutoSize = true;
            this.checkBox_stretchWindow.Location = new System.Drawing.Point(12, 120);
            this.checkBox_stretchWindow.Name = "checkBox_stretchWindow";
            this.checkBox_stretchWindow.Size = new System.Drawing.Size(205, 17);
            this.checkBox_stretchWindow.TabIndex = 19;
            this.checkBox_stretchWindow.Text = "&Stretch window to fit the window size";
            this.toolTip1.SetToolTip(this.checkBox_stretchWindow, "If enabled, the program will change the main window size\r\nto fit the value you ch" +
        "oose in the combobox below.");
            this.checkBox_stretchWindow.UseVisualStyleBackColor = true;
            // 
            // FormVideoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 385);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_stretchWindow);
            this.Controls.Add(this.comboBox_windowSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_snapshotFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_hideLines);
            this.Controls.Add(this.checkBox_immediateMode);
            this.Controls.Add(this.comboBox_fullscreenRes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_mode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_showFps);
            this.Controls.Add(this.checkBox_showNot);
            this.Controls.Add(this.checkBox_keepAspectRatio);
            this.Controls.Add(this.checkBox_fullscreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormVideoSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_fullscreen;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_keepAspectRatio;
        private System.Windows.Forms.CheckBox checkBox_showNot;
        private System.Windows.Forms.CheckBox checkBox_showFps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_mode;
        private System.Windows.Forms.ComboBox comboBox_fullscreenRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_immediateMode;
        private System.Windows.Forms.CheckBox checkBox_hideLines;
        private System.Windows.Forms.ComboBox comboBox_snapshotFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox_windowSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_stretchWindow;
    }
}