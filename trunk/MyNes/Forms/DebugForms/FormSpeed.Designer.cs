﻿/* This file is part of My Nes
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
    partial class FormSpeed
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
            this.label_min_max = new System.Windows.Forms.Label();
            this.textBox_fpsCanMake = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Targetfps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_dead = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FrameTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_FPS = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_min_max
            // 
            this.label_min_max.AutoSize = true;
            this.label_min_max.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_min_max.Location = new System.Drawing.Point(113, 133);
            this.label_min_max.Name = "label_min_max";
            this.label_min_max.Size = new System.Drawing.Size(49, 26);
            this.label_min_max.TabIndex = 19;
            this.label_min_max.Text = "Min = 0\r\nMax = 0";
            // 
            // textBox_fpsCanMake
            // 
            this.textBox_fpsCanMake.Location = new System.Drawing.Point(119, 81);
            this.textBox_fpsCanMake.Name = "textBox_fpsCanMake";
            this.textBox_fpsCanMake.ReadOnly = true;
            this.textBox_fpsCanMake.Size = new System.Drawing.Size(153, 20);
            this.textBox_fpsCanMake.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 26);
            this.label4.TabIndex = 17;
            this.label4.Text = "Possible FPS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(197, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Targetfps
            // 
            this.textBox_Targetfps.Location = new System.Drawing.Point(119, 29);
            this.textBox_Targetfps.Name = "textBox_Targetfps";
            this.textBox_Targetfps.ReadOnly = true;
            this.textBox_Targetfps.Size = new System.Drawing.Size(153, 20);
            this.textBox_Targetfps.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Frame Time Target";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_dead
            // 
            this.textBox_dead.Location = new System.Drawing.Point(119, 55);
            this.textBox_dead.Name = "textBox_dead";
            this.textBox_dead.ReadOnly = true;
            this.textBox_dead.Size = new System.Drawing.Size(153, 20);
            this.textBox_dead.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Idle Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FrameTime
            // 
            this.textBox_FrameTime.Location = new System.Drawing.Point(119, 3);
            this.textBox_FrameTime.Name = "textBox_FrameTime";
            this.textBox_FrameTime.ReadOnly = true;
            this.textBox_FrameTime.Size = new System.Drawing.Size(153, 20);
            this.textBox_FrameTime.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Frame Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Limiter";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(116, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "ON";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.19718F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.80282F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_FrameTime, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Targetfps, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_fpsCanMake, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_dead, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_FPS, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 130);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 26);
            this.label6.TabIndex = 19;
            this.label6.Text = "FPS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FPS
            // 
            this.textBox_FPS.Location = new System.Drawing.Point(119, 107);
            this.textBox_FPS.Name = "textBox_FPS";
            this.textBox_FPS.ReadOnly = true;
            this.textBox_FPS.Size = new System.Drawing.Size(153, 20);
            this.textBox_FPS.TabIndex = 20;
            // 
            // FormSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 209);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_min_max);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSpeed";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Emulation Speed";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_min_max;
        private System.Windows.Forms.TextBox textBox_fpsCanMake;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_Targetfps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_dead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FrameTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_FPS;
    }
}