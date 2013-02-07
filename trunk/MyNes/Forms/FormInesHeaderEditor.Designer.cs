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
    partial class FormInesHeaderEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInesHeaderEditor));
            this.textBox_romPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_size = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_sha1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_version = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_tvSystem = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_trainer = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox_isBattery = new System.Windows.Forms.CheckBox();
            this.checkBox_pc10 = new System.Windows.Forms.CheckBox();
            this.checkBox_VSUnisystem = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown_chrCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_prgCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_mapper = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_chrCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_prgCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mapper)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_romPath
            // 
            this.textBox_romPath.Location = new System.Drawing.Point(45, 12);
            this.textBox_romPath.Name = "textBox_romPath";
            this.textBox_romPath.ReadOnly = true;
            this.textBox_romPath.Size = new System.Drawing.Size(194, 20);
            this.textBox_romPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Change";
            this.toolTip1.SetToolTip(this.button1, "Change the file");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size:";
            // 
            // textBox_size
            // 
            this.textBox_size.Location = new System.Drawing.Point(45, 38);
            this.textBox_size.Name = "textBox_size";
            this.textBox_size.ReadOnly = true;
            this.textBox_size.Size = new System.Drawing.Size(93, 20);
            this.textBox_size.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sha1:";
            // 
            // textBox_sha1
            // 
            this.textBox_sha1.Location = new System.Drawing.Point(185, 38);
            this.textBox_sha1.Name = "textBox_sha1";
            this.textBox_sha1.ReadOnly = true;
            this.textBox_sha1.Size = new System.Drawing.Size(127, 20);
            this.textBox_sha1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_version);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.comboBox_tvSystem);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.checkBox_trainer);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.checkBox_isBattery);
            this.groupBox1.Controls.Add(this.checkBox_pc10);
            this.groupBox1.Controls.Add(this.checkBox_VSUnisystem);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.numericUpDown_chrCount);
            this.groupBox1.Controls.Add(this.numericUpDown_prgCount);
            this.groupBox1.Controls.Add(this.numericUpDown_mapper);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(15, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 275);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INES header";
            // 
            // comboBox_version
            // 
            this.comboBox_version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_version.FormattingEnabled = true;
            this.comboBox_version.Items.AddRange(new object[] {
            "1.0",
            "2.0"});
            this.comboBox_version.Location = new System.Drawing.Point(84, 19);
            this.comboBox_version.Name = "comboBox_version";
            this.comboBox_version.Size = new System.Drawing.Size(207, 21);
            this.comboBox_version.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "INES version:";
            // 
            // comboBox_tvSystem
            // 
            this.comboBox_tvSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tvSystem.FormattingEnabled = true;
            this.comboBox_tvSystem.Items.AddRange(new object[] {
            "NTSC",
            "PAL",
            "Dual Compatible"});
            this.comboBox_tvSystem.Location = new System.Drawing.Point(84, 151);
            this.comboBox_tvSystem.Name = "comboBox_tvSystem";
            this.comboBox_tvSystem.Size = new System.Drawing.Size(207, 21);
            this.comboBox_tvSystem.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "TV System:";
            // 
            // checkBox_trainer
            // 
            this.checkBox_trainer.AutoSize = true;
            this.checkBox_trainer.Location = new System.Drawing.Point(6, 178);
            this.checkBox_trainer.Name = "checkBox_trainer";
            this.checkBox_trainer.Size = new System.Drawing.Size(81, 17);
            this.checkBox_trainer.TabIndex = 30;
            this.checkBox_trainer.Text = "Has Trainer";
            this.checkBox_trainer.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "&Reload file";
            this.toolTip1.SetToolTip(this.button3, "Relaod the file. This will discard any changes.");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox_isBattery
            // 
            this.checkBox_isBattery.AutoSize = true;
            this.checkBox_isBattery.Location = new System.Drawing.Point(6, 247);
            this.checkBox_isBattery.Name = "checkBox_isBattery";
            this.checkBox_isBattery.Size = new System.Drawing.Size(111, 17);
            this.checkBox_isBattery.TabIndex = 29;
            this.checkBox_isBattery.Text = "Is battery backed";
            this.checkBox_isBattery.UseVisualStyleBackColor = true;
            // 
            // checkBox_pc10
            // 
            this.checkBox_pc10.AutoSize = true;
            this.checkBox_pc10.Location = new System.Drawing.Point(6, 224);
            this.checkBox_pc10.Name = "checkBox_pc10";
            this.checkBox_pc10.Size = new System.Drawing.Size(94, 17);
            this.checkBox_pc10.TabIndex = 28;
            this.checkBox_pc10.Text = "PlayChoice-10";
            this.checkBox_pc10.UseVisualStyleBackColor = true;
            // 
            // checkBox_VSUnisystem
            // 
            this.checkBox_VSUnisystem.AutoSize = true;
            this.checkBox_VSUnisystem.Location = new System.Drawing.Point(6, 201);
            this.checkBox_VSUnisystem.Name = "checkBox_VSUnisystem";
            this.checkBox_VSUnisystem.Size = new System.Drawing.Size(90, 17);
            this.checkBox_VSUnisystem.TabIndex = 27;
            this.checkBox_VSUnisystem.Text = "VS Unisystem";
            this.checkBox_VSUnisystem.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "&Fix using database";
            this.toolTip1.SetToolTip(this.button2, "This will search the database for this rom to get the information.\r\nThis will set" +
        " prg, chr, mapper and tv system.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown_chrCount
            // 
            this.numericUpDown_chrCount.Location = new System.Drawing.Point(84, 72);
            this.numericUpDown_chrCount.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_chrCount.Name = "numericUpDown_chrCount";
            this.numericUpDown_chrCount.Size = new System.Drawing.Size(207, 20);
            this.numericUpDown_chrCount.TabIndex = 25;
            this.toolTip1.SetToolTip(this.numericUpDown_chrCount, "The chr banks count = chr size in KBytes");
            // 
            // numericUpDown_prgCount
            // 
            this.numericUpDown_prgCount.Location = new System.Drawing.Point(84, 46);
            this.numericUpDown_prgCount.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_prgCount.Name = "numericUpDown_prgCount";
            this.numericUpDown_prgCount.Size = new System.Drawing.Size(207, 20);
            this.numericUpDown_prgCount.TabIndex = 24;
            this.toolTip1.SetToolTip(this.numericUpDown_prgCount, "The prg banks  count = (PRG size in KBytes) / 8");
            // 
            // numericUpDown_mapper
            // 
            this.numericUpDown_mapper.Location = new System.Drawing.Point(84, 98);
            this.numericUpDown_mapper.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_mapper.Name = "numericUpDown_mapper";
            this.numericUpDown_mapper.Size = new System.Drawing.Size(207, 20);
            this.numericUpDown_mapper.TabIndex = 20;
            this.toolTip1.SetToolTip(this.numericUpDown_mapper, "The INES mapper #");
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical",
            "Four-Screen"});
            this.comboBox1.Location = new System.Drawing.Point(84, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mapper #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mirroring:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "CHR count:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "PRG count:";
            // 
            // label8
            // 
            this.label8.Image = global::MyNes.Properties.Resources.Warning;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label8.Location = new System.Drawing.Point(12, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(298, 144);
            this.label8.TabIndex = 26;
            this.label8.Text = resources.GetString("label8.Text");
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_save
            // 
            this.button_save.Enabled = false;
            this.button_save.Location = new System.Drawing.Point(189, 477);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(123, 23);
            this.button_save.TabIndex = 23;
            this.button_save.Text = "&Save changes";
            this.toolTip1.SetToolTip(this.button_save, "Save changes to the file. Be carefull ! this can\'t be undone.");
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(108, 477);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 27;
            this.button5.Text = "&Close";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormInesHeaderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 512);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_sha1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_size);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_romPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInesHeaderEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INES Header Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_chrCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_prgCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mapper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_romPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_size;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_sha1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_mapper;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.NumericUpDown numericUpDown_chrCount;
        private System.Windows.Forms.NumericUpDown numericUpDown_prgCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_trainer;
        private System.Windows.Forms.CheckBox checkBox_isBattery;
        private System.Windows.Forms.CheckBox checkBox_pc10;
        private System.Windows.Forms.CheckBox checkBox_VSUnisystem;
        private System.Windows.Forms.ComboBox comboBox_tvSystem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_version;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}