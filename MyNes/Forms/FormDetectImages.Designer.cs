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
namespace MyNes
{
    partial class FormDetectImages
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_matchFileName = new System.Windows.Forms.CheckBox();
            this.checkBox_caseSensitive = new System.Windows.Forms.CheckBox();
            this.checkBox_includeSubfolders = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.status_label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "&Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(294, 134);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_matchFileName);
            this.groupBox2.Controls.Add(this.checkBox_caseSensitive);
            this.groupBox2.Controls.Add(this.checkBox_includeSubfolders);
            this.groupBox2.Location = new System.Drawing.Point(12, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // checkBox_matchFileName
            // 
            this.checkBox_matchFileName.AutoSize = true;
            this.checkBox_matchFileName.Location = new System.Drawing.Point(227, 19);
            this.checkBox_matchFileName.Name = "checkBox_matchFileName";
            this.checkBox_matchFileName.Size = new System.Drawing.Size(101, 17);
            this.checkBox_matchFileName.TabIndex = 6;
            this.checkBox_matchFileName.Text = "Match file name";
            this.checkBox_matchFileName.UseVisualStyleBackColor = true;
            // 
            // checkBox_caseSensitive
            // 
            this.checkBox_caseSensitive.AutoSize = true;
            this.checkBox_caseSensitive.Location = new System.Drawing.Point(126, 19);
            this.checkBox_caseSensitive.Name = "checkBox_caseSensitive";
            this.checkBox_caseSensitive.Size = new System.Drawing.Size(95, 17);
            this.checkBox_caseSensitive.TabIndex = 5;
            this.checkBox_caseSensitive.Text = "Case sensitive";
            this.checkBox_caseSensitive.UseVisualStyleBackColor = true;
            // 
            // checkBox_includeSubfolders
            // 
            this.checkBox_includeSubfolders.AutoSize = true;
            this.checkBox_includeSubfolders.Checked = true;
            this.checkBox_includeSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_includeSubfolders.Location = new System.Drawing.Point(6, 19);
            this.checkBox_includeSubfolders.Name = "checkBox_includeSubfolders";
            this.checkBox_includeSubfolders.Size = new System.Drawing.Size(114, 17);
            this.checkBox_includeSubfolders.TabIndex = 4;
            this.checkBox_includeSubfolders.Text = "Include subfolders";
            this.checkBox_includeSubfolders.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(311, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "&Ok";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(230, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "&Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // status_label1
            // 
            this.status_label1.AutoSize = true;
            this.status_label1.Location = new System.Drawing.Point(12, 229);
            this.status_label1.Name = "status_label1";
            this.status_label1.Size = new System.Drawing.Size(38, 13);
            this.status_label1.TabIndex = 7;
            this.status_label1.Text = "Ready";
            this.status_label1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 245);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(195, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormDetectImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 280);
            this.Controls.Add(this.status_label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetectImages";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detect Images";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox_matchFileName;
        private System.Windows.Forms.CheckBox checkBox_caseSensitive;
        private System.Windows.Forms.CheckBox checkBox_includeSubfolders;
        private System.Windows.Forms.Label status_label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}