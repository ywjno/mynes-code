﻿namespace myNES
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
            this.textBox_fps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_dead = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FrameTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_min_max
            // 
            this.label_min_max.AutoSize = true;
            this.label_min_max.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_min_max.Location = new System.Drawing.Point(96, 113);
            this.label_min_max.Name = "label_min_max";
            this.label_min_max.Size = new System.Drawing.Size(35, 13);
            this.label_min_max.TabIndex = 19;
            this.label_min_max.Text = "label5";
            // 
            // textBox_fpsCanMake
            // 
            this.textBox_fpsCanMake.Location = new System.Drawing.Point(99, 90);
            this.textBox_fpsCanMake.Name = "textBox_fpsCanMake";
            this.textBox_fpsCanMake.ReadOnly = true;
            this.textBox_fpsCanMake.Size = new System.Drawing.Size(162, 20);
            this.textBox_fpsCanMake.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "FPS";
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(186, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox_fps
            // 
            this.textBox_fps.Location = new System.Drawing.Point(99, 38);
            this.textBox_fps.Name = "textBox_fps";
            this.textBox_fps.ReadOnly = true;
            this.textBox_fps.Size = new System.Drawing.Size(162, 20);
            this.textBox_fps.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Des Frame time";
            // 
            // textBox_dead
            // 
            this.textBox_dead.Location = new System.Drawing.Point(99, 64);
            this.textBox_dead.Name = "textBox_dead";
            this.textBox_dead.ReadOnly = true;
            this.textBox_dead.Size = new System.Drawing.Size(162, 20);
            this.textBox_dead.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dead Time";
            // 
            // textBox_FrameTime
            // 
            this.textBox_FrameTime.Location = new System.Drawing.Point(99, 12);
            this.textBox_FrameTime.Name = "textBox_FrameTime";
            this.textBox_FrameTime.ReadOnly = true;
            this.textBox_FrameTime.Size = new System.Drawing.Size(162, 20);
            this.textBox_FrameTime.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Frame Time";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 197);
            this.Controls.Add(this.label_min_max);
            this.Controls.Add(this.textBox_fpsCanMake);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_fps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_dead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_FrameTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSpeed";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Emulation Speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_min_max;
        private System.Windows.Forms.TextBox textBox_fpsCanMake;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_fps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_dead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FrameTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}