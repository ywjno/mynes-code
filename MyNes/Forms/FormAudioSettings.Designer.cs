/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton_size_16kb = new System.Windows.Forms.RadioButton();
            this.radioButton_size_8kb = new System.Windows.Forms.RadioButton();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.radioButton1_sound_enabled = new System.Windows.Forms.RadioButton();
            this.radioButton_sound_disabled = new System.Windows.Forms.RadioButton();
            this.trackBar_latency = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_volume = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_noize = new System.Windows.Forms.CheckBox();
            this.checkBox_triangle = new System.Windows.Forms.CheckBox();
            this.checkBox_dmc = new System.Windows.Forms.CheckBox();
            this.checkBox_sq2 = new System.Windows.Forms.CheckBox();
            this.checkBox_sq1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label_latency = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_latency)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.toolTip1.SetToolTip(this.button1, resources.GetString("button1.ToolTip"));
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.toolTip1.SetToolTip(this.button2, resources.GetString("button2.ToolTip"));
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBar2
            // 
            resources.ApplyResources(this.trackBar2, "trackBar2");
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.toolTip1.SetToolTip(this.trackBar2, resources.GetString("trackBar2.ToolTip"));
            this.trackBar2.Value = 1;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.toolTip1.SetToolTip(this.button3, resources.GetString("button3.ToolTip"));
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButton_size_16kb
            // 
            resources.ApplyResources(this.radioButton_size_16kb, "radioButton_size_16kb");
            this.radioButton_size_16kb.Name = "radioButton_size_16kb";
            this.toolTip1.SetToolTip(this.radioButton_size_16kb, resources.GetString("radioButton_size_16kb.ToolTip"));
            this.radioButton_size_16kb.UseVisualStyleBackColor = true;
            // 
            // radioButton_size_8kb
            // 
            resources.ApplyResources(this.radioButton_size_8kb, "radioButton_size_8kb");
            this.radioButton_size_8kb.Name = "radioButton_size_8kb";
            this.toolTip1.SetToolTip(this.radioButton_size_8kb, resources.GetString("radioButton_size_8kb.ToolTip"));
            this.radioButton_size_8kb.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.toolTip1.SetToolTip(this.linkLabel2, resources.GetString("linkLabel2.ToolTip"));
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.toolTip1.SetToolTip(this.linkLabel1, resources.GetString("linkLabel1.ToolTip"));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // radioButton1_sound_enabled
            // 
            resources.ApplyResources(this.radioButton1_sound_enabled, "radioButton1_sound_enabled");
            this.radioButton1_sound_enabled.Checked = true;
            this.radioButton1_sound_enabled.Name = "radioButton1_sound_enabled";
            this.radioButton1_sound_enabled.TabStop = true;
            this.toolTip1.SetToolTip(this.radioButton1_sound_enabled, resources.GetString("radioButton1_sound_enabled.ToolTip"));
            this.radioButton1_sound_enabled.UseVisualStyleBackColor = true;
            // 
            // radioButton_sound_disabled
            // 
            resources.ApplyResources(this.radioButton_sound_disabled, "radioButton_sound_disabled");
            this.radioButton_sound_disabled.Name = "radioButton_sound_disabled";
            this.toolTip1.SetToolTip(this.radioButton_sound_disabled, resources.GetString("radioButton_sound_disabled.ToolTip"));
            this.radioButton_sound_disabled.UseVisualStyleBackColor = true;
            // 
            // trackBar_latency
            // 
            resources.ApplyResources(this.trackBar_latency, "trackBar_latency");
            this.trackBar_latency.Maximum = 100;
            this.trackBar_latency.Minimum = 1;
            this.trackBar_latency.Name = "trackBar_latency";
            this.toolTip1.SetToolTip(this.trackBar_latency, resources.GetString("trackBar_latency.ToolTip"));
            this.trackBar_latency.Value = 1;
            this.trackBar_latency.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_volume);
            this.groupBox4.Controls.Add(this.trackBar2);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label_volume
            // 
            resources.ApplyResources(this.label_volume, "label_volume");
            this.label_volume.Name = "label_volume";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.checkBox_noize);
            this.groupBox3.Controls.Add(this.checkBox_triangle);
            this.groupBox3.Controls.Add(this.checkBox_dmc);
            this.groupBox3.Controls.Add(this.checkBox_sq2);
            this.groupBox3.Controls.Add(this.checkBox_sq1);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // checkBox_noize
            // 
            resources.ApplyResources(this.checkBox_noize, "checkBox_noize");
            this.checkBox_noize.Name = "checkBox_noize";
            this.checkBox_noize.UseVisualStyleBackColor = true;
            // 
            // checkBox_triangle
            // 
            resources.ApplyResources(this.checkBox_triangle, "checkBox_triangle");
            this.checkBox_triangle.Name = "checkBox_triangle";
            this.checkBox_triangle.UseVisualStyleBackColor = true;
            // 
            // checkBox_dmc
            // 
            resources.ApplyResources(this.checkBox_dmc, "checkBox_dmc");
            this.checkBox_dmc.Name = "checkBox_dmc";
            this.checkBox_dmc.UseVisualStyleBackColor = true;
            // 
            // checkBox_sq2
            // 
            resources.ApplyResources(this.checkBox_sq2, "checkBox_sq2");
            this.checkBox_sq2.Name = "checkBox_sq2";
            this.checkBox_sq2.UseVisualStyleBackColor = true;
            // 
            // checkBox_sq1
            // 
            resources.ApplyResources(this.checkBox_sq1, "checkBox_sq1");
            this.checkBox_sq1.Name = "checkBox_sq1";
            this.checkBox_sq1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_size_8kb);
            this.groupBox1.Controls.Add(this.radioButton_size_16kb);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1_sound_enabled);
            this.groupBox2.Controls.Add(this.radioButton_sound_disabled);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_latency);
            this.groupBox5.Controls.Add(this.trackBar_latency);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // label_latency
            // 
            resources.ApplyResources(this.label_latency, "label_latency");
            this.label_latency.Name = "label_latency";
            // 
            // FormAudioSettings
            // 
            this.AcceptButton = this.button1;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAudioSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_latency)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_volume;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_noize;
        private System.Windows.Forms.CheckBox checkBox_triangle;
        private System.Windows.Forms.CheckBox checkBox_dmc;
        private System.Windows.Forms.CheckBox checkBox_sq2;
        private System.Windows.Forms.CheckBox checkBox_sq1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton radioButton_size_16kb;
        private System.Windows.Forms.RadioButton radioButton_size_8kb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1_sound_enabled;
        private System.Windows.Forms.RadioButton radioButton_sound_disabled;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label_latency;
        private System.Windows.Forms.TrackBar trackBar_latency;
    }
}