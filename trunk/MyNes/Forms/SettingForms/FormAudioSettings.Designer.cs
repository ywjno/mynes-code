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
    partial class FormAudioSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAudioSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_freq = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox_bits = new System.Windows.Forms.ComboBox();
            this.radioButton_mono = new System.Windows.Forms.RadioButton();
            this.radioButton_stereo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_volume = new System.Windows.Forms.TrackBar();
            this.label_volumeLevel = new System.Windows.Forms.Label();
            this.label_latency = new System.Windows.Forms.Label();
            this.trackBar_latency = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox_soundEnable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_renderer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_latency)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frequency:";
            // 
            // comboBox_freq
            // 
            this.comboBox_freq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_freq.FormattingEnabled = true;
            this.comboBox_freq.Location = new System.Drawing.Point(96, 46);
            this.comboBox_freq.Name = "comboBox_freq";
            this.comboBox_freq.Size = new System.Drawing.Size(228, 21);
            this.comboBox_freq.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBox_freq, "Select the playback frequency.\r\nSmaller frequency may improve performance but\r\nre" +
        "duce quality. High frequency means high quality\r\nbut less performance (need more" +
        " pc power).");
            // 
            // comboBox_bits
            // 
            this.comboBox_bits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bits.FormattingEnabled = true;
            this.comboBox_bits.Location = new System.Drawing.Point(96, 73);
            this.comboBox_bits.Name = "comboBox_bits";
            this.comboBox_bits.Size = new System.Drawing.Size(228, 21);
            this.comboBox_bits.TabIndex = 3;
            this.toolTip1.SetToolTip(this.comboBox_bits, "Select the bits per sample.\r\nHigh value means high quality but less performance (" +
        "need more pc power).");
            // 
            // radioButton_mono
            // 
            this.radioButton_mono.AutoSize = true;
            this.radioButton_mono.Checked = true;
            this.radioButton_mono.Location = new System.Drawing.Point(96, 102);
            this.radioButton_mono.Name = "radioButton_mono";
            this.radioButton_mono.Size = new System.Drawing.Size(51, 17);
            this.radioButton_mono.TabIndex = 4;
            this.radioButton_mono.TabStop = true;
            this.radioButton_mono.Text = "Mono";
            this.toolTip1.SetToolTip(this.radioButton_mono, "Mono mode (1 channel)\r\nNES is mono by default. Recommended choice.");
            this.radioButton_mono.UseVisualStyleBackColor = true;
            // 
            // radioButton_stereo
            // 
            this.radioButton_stereo.AutoSize = true;
            this.radioButton_stereo.Location = new System.Drawing.Point(153, 102);
            this.radioButton_stereo.Name = "radioButton_stereo";
            this.radioButton_stereo.Size = new System.Drawing.Size(57, 17);
            this.radioButton_stereo.TabIndex = 5;
            this.radioButton_stereo.Text = "Stereo";
            this.toolTip1.SetToolTip(this.radioButton_stereo, resources.GetString("radioButton_stereo.ToolTip"));
            this.radioButton_stereo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bits Per Sample:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Volume:";
            // 
            // trackBar_volume
            // 
            this.trackBar_volume.AutoSize = false;
            this.trackBar_volume.Location = new System.Drawing.Point(57, 19);
            this.trackBar_volume.Maximum = 100;
            this.trackBar_volume.Name = "trackBar_volume";
            this.trackBar_volume.Size = new System.Drawing.Size(184, 21);
            this.trackBar_volume.TabIndex = 7;
            this.trackBar_volume.Value = 100;
            this.trackBar_volume.Scroll += new System.EventHandler(this.trackBar_volume_Scroll);
            // 
            // label_volumeLevel
            // 
            this.label_volumeLevel.AutoSize = true;
            this.label_volumeLevel.Location = new System.Drawing.Point(247, 19);
            this.label_volumeLevel.Name = "label_volumeLevel";
            this.label_volumeLevel.Size = new System.Drawing.Size(36, 13);
            this.label_volumeLevel.TabIndex = 8;
            this.label_volumeLevel.Text = "100%";
            // 
            // label_latency
            // 
            this.label_latency.AutoSize = true;
            this.label_latency.Location = new System.Drawing.Point(247, 46);
            this.label_latency.Name = "label_latency";
            this.label_latency.Size = new System.Drawing.Size(77, 13);
            this.label_latency.TabIndex = 11;
            this.label_latency.Text = "50 Milliseconds";
            // 
            // trackBar_latency
            // 
            this.trackBar_latency.AutoSize = false;
            this.trackBar_latency.Location = new System.Drawing.Point(57, 46);
            this.trackBar_latency.Maximum = 100;
            this.trackBar_latency.Name = "trackBar_latency";
            this.trackBar_latency.Size = new System.Drawing.Size(184, 21);
            this.trackBar_latency.TabIndex = 10;
            this.trackBar_latency.Value = 50;
            this.trackBar_latency.Scroll += new System.EventHandler(this.trackBar_latency_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Latency:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(269, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(188, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(12, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "&Defaults";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox_soundEnable
            // 
            this.checkBox_soundEnable.AutoSize = true;
            this.checkBox_soundEnable.Checked = true;
            this.checkBox_soundEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_soundEnable.Location = new System.Drawing.Point(12, 12);
            this.checkBox_soundEnable.Name = "checkBox_soundEnable";
            this.checkBox_soundEnable.Size = new System.Drawing.Size(135, 17);
            this.checkBox_soundEnable.TabIndex = 16;
            this.checkBox_soundEnable.Text = "Enable &sound playback";
            this.checkBox_soundEnable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_renderer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_freq);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_bits);
            this.groupBox1.Controls.Add(this.radioButton_mono);
            this.groupBox1.Controls.Add(this.radioButton_stereo);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 123);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playback (and record)";
            // 
            // comboBox_renderer
            // 
            this.comboBox_renderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_renderer.FormattingEnabled = true;
            this.comboBox_renderer.Items.AddRange(new object[] {
            "DirectSound [SlimDX]"});
            this.comboBox_renderer.Location = new System.Drawing.Point(96, 19);
            this.comboBox_renderer.Name = "comboBox_renderer";
            this.comboBox_renderer.Size = new System.Drawing.Size(228, 21);
            this.comboBox_renderer.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Renderer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mode:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.trackBar_volume);
            this.groupBox2.Controls.Add(this.label_volumeLevel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.trackBar_latency);
            this.groupBox2.Controls.Add(this.label_latency);
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 81);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Levels";
            // 
            // FormAudioSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 295);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_soundEnable);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAudioSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_latency)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_freq;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox_bits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_mono;
        private System.Windows.Forms.RadioButton radioButton_stereo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar_volume;
        private System.Windows.Forms.Label label_volumeLevel;
        private System.Windows.Forms.Label label_latency;
        private System.Windows.Forms.TrackBar trackBar_latency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox_soundEnable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_renderer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}