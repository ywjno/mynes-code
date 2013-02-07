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
namespace MyNes
{
    partial class FormINESFilesFixer
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
            MLV.ManagedListViewColumnsCollection managedListViewColumnsCollection2 = new MLV.ManagedListViewColumnsCollection();
            MLV.ManagedListViewItemsCollection managedListViewItemsCollection2 = new MLV.ManagedListViewItemsCollection();
            this.managedListView1 = new MLV.ManagedListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_FixMapper = new System.Windows.Forms.CheckBox();
            this.checkBox_fixTv = new System.Windows.Forms.CheckBox();
            this.checkBox_fixChr = new System.Windows.Forms.CheckBox();
            this.checkBox_fixPrg = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_status = new System.Windows.Forms.Label();
            this.radioButton_replaceFile = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox_MoveToFolder = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // managedListView1
            // 
            this.managedListView1.AllowColumnsReorder = false;
            this.managedListView1.AllowItemsDragAndDrop = false;
            this.managedListView1.ChangeColumnSortModeWhenClick = false;
            this.managedListView1.Columns = managedListViewColumnsCollection2;
            this.managedListView1.DrawHighlight = true;
            this.managedListView1.Items = managedListViewItemsCollection2;
            this.managedListView1.Location = new System.Drawing.Point(12, 51);
            this.managedListView1.Name = "managedListView1";
            this.managedListView1.Size = new System.Drawing.Size(414, 228);
            this.managedListView1.TabIndex = 0;
            this.managedListView1.ThunmbnailsHeight = 36;
            this.managedListView1.ThunmbnailsWidth = 36;
            this.managedListView1.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.managedListView1.WheelScrollSpeed = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Add files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(432, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "&Remove selected";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_FixMapper
            // 
            this.checkBox_FixMapper.AutoSize = true;
            this.checkBox_FixMapper.Checked = true;
            this.checkBox_FixMapper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_FixMapper.Location = new System.Drawing.Point(432, 160);
            this.checkBox_FixMapper.Name = "checkBox_FixMapper";
            this.checkBox_FixMapper.Size = new System.Drawing.Size(90, 17);
            this.checkBox_FixMapper.TabIndex = 3;
            this.checkBox_FixMapper.Text = "Fix mapper #";
            this.checkBox_FixMapper.UseVisualStyleBackColor = true;
            // 
            // checkBox_fixTv
            // 
            this.checkBox_fixTv.AutoSize = true;
            this.checkBox_fixTv.Checked = true;
            this.checkBox_fixTv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_fixTv.Location = new System.Drawing.Point(432, 229);
            this.checkBox_fixTv.Name = "checkBox_fixTv";
            this.checkBox_fixTv.Size = new System.Drawing.Size(90, 17);
            this.checkBox_fixTv.TabIndex = 4;
            this.checkBox_fixTv.Text = "Fix tv system";
            this.checkBox_fixTv.UseVisualStyleBackColor = true;
            // 
            // checkBox_fixChr
            // 
            this.checkBox_fixChr.AutoSize = true;
            this.checkBox_fixChr.Checked = true;
            this.checkBox_fixChr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_fixChr.Location = new System.Drawing.Point(432, 206);
            this.checkBox_fixChr.Name = "checkBox_fixChr";
            this.checkBox_fixChr.Size = new System.Drawing.Size(88, 17);
            this.checkBox_fixChr.TabIndex = 5;
            this.checkBox_fixChr.Text = "Fix chr count";
            this.checkBox_fixChr.UseVisualStyleBackColor = true;
            // 
            // checkBox_fixPrg
            // 
            this.checkBox_fixPrg.AutoSize = true;
            this.checkBox_fixPrg.Checked = true;
            this.checkBox_fixPrg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_fixPrg.Location = new System.Drawing.Point(432, 183);
            this.checkBox_fixPrg.Name = "checkBox_fixPrg";
            this.checkBox_fixPrg.Size = new System.Drawing.Size(89, 17);
            this.checkBox_fixPrg.TabIndex = 6;
            this.checkBox_fixPrg.Text = "Fix prg count";
            this.checkBox_fixPrg.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Database:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(414, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(432, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "&Change";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(432, 403);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(97, 23);
            this.button_start.TabIndex = 10;
            this.button_start.Text = "&Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(351, 403);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 11;
            this.button_close.Text = "C&lose";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 403);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(333, 23);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // label_status
            // 
            this.label_status.Location = new System.Drawing.Point(12, 386);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(333, 14);
            this.label_status.TabIndex = 13;
            this.label_status.Text = "Ready.";
            this.label_status.Visible = false;
            // 
            // radioButton_replaceFile
            // 
            this.radioButton_replaceFile.AutoSize = true;
            this.radioButton_replaceFile.Location = new System.Drawing.Point(12, 285);
            this.radioButton_replaceFile.Name = "radioButton_replaceFile";
            this.radioButton_replaceFile.Size = new System.Drawing.Size(513, 17);
            this.radioButton_replaceFile.TabIndex = 14;
            this.radioButton_replaceFile.Text = "&Replace the original rom files (keep them in the same path(s) after fix complete" +
    ". This can\'t be undone)";
            this.radioButton_replaceFile.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 308);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(188, 17);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "&Copy fixed rom files to this folder:";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(432, 329);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "&Change";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox_MoveToFolder
            // 
            this.textBox_MoveToFolder.Location = new System.Drawing.Point(12, 331);
            this.textBox_MoveToFolder.Name = "textBox_MoveToFolder";
            this.textBox_MoveToFolder.ReadOnly = true;
            this.textBox_MoveToFolder.Size = new System.Drawing.Size(414, 20);
            this.textBox_MoveToFolder.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 357);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(261, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Delete original files after copy (make them move)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormINESFilesFixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 438);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox_MoveToFolder);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioButton_replaceFile);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_fixPrg);
            this.Controls.Add(this.checkBox_fixChr);
            this.Controls.Add(this.checkBox_fixTv);
            this.Controls.Add(this.checkBox_FixMapper);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.managedListView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormINESFilesFixer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INES Files Fixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormINESFilesFixer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MLV.ManagedListView managedListView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox_FixMapper;
        private System.Windows.Forms.CheckBox checkBox_fixTv;
        private System.Windows.Forms.CheckBox checkBox_fixChr;
        private System.Windows.Forms.CheckBox checkBox_fixPrg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.RadioButton radioButton_replaceFile;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox_MoveToFolder;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}