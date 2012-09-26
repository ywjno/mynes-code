namespace MyNes
{
    partial class FormPaletteSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaletteSettings));
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hScrollBar_saturation = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.hScrollBar_hue_tweak = new System.Windows.Forms.HScrollBar();
            this.label_gamma = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_bright = new System.Windows.Forms.Label();
            this.hScrollBar_contrast = new System.Windows.Forms.HScrollBar();
            this.label_const = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_hue = new System.Windows.Forms.Label();
            this.hScrollBar_brightness = new System.Windows.Forms.HScrollBar();
            this.label_satur = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.hScrollBar_gamma = new System.Windows.Forms.HScrollBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_palb = new System.Windows.Forms.RadioButton();
            this.radioButton_ntsc = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button9
            // 
            this.button9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button9.Location = new System.Drawing.Point(12, 258);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(59, 23);
            this.button9.TabIndex = 29;
            this.button9.Text = "Load";
            this.toolTip1.SetToolTip(this.button9, "Load values from file");
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(338, 374);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(125, 23);
            this.button7.TabIndex = 27;
            this.button7.Text = "Save Palette As .Pal";
            this.toolTip1.SetToolTip(this.button7, "Save palette as .pal file");
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button8.Location = new System.Drawing.Point(77, 258);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(59, 23);
            this.button8.TabIndex = 28;
            this.button8.Text = "Save";
            this.toolTip1.SetToolTip(this.button8, "Save values as file");
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(273, 258);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(59, 23);
            this.button6.TabIndex = 26;
            this.button6.Text = "Flat";
            this.toolTip1.SetToolTip(this.button6, "Flat levels");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hScrollBar_saturation);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.hScrollBar_hue_tweak);
            this.groupBox4.Controls.Add(this.label_gamma);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label_bright);
            this.groupBox4.Controls.Add(this.hScrollBar_contrast);
            this.groupBox4.Controls.Add(this.label_const);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label_hue);
            this.groupBox4.Controls.Add(this.hScrollBar_brightness);
            this.groupBox4.Controls.Add(this.label_satur);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.hScrollBar_gamma);
            this.groupBox4.Location = new System.Drawing.Point(12, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(320, 190);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Colors";
            // 
            // hScrollBar_saturation
            // 
            this.hScrollBar_saturation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hScrollBar_saturation.Location = new System.Drawing.Point(72, 22);
            this.hScrollBar_saturation.Maximum = 5000;
            this.hScrollBar_saturation.Name = "hScrollBar_saturation";
            this.hScrollBar_saturation.Size = new System.Drawing.Size(205, 21);
            this.hScrollBar_saturation.TabIndex = 5;
            this.hScrollBar_saturation.Value = 1000;
            this.hScrollBar_saturation.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_saturation_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saturation";
            // 
            // hScrollBar_hue_tweak
            // 
            this.hScrollBar_hue_tweak.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hScrollBar_hue_tweak.Location = new System.Drawing.Point(72, 56);
            this.hScrollBar_hue_tweak.Maximum = 1000;
            this.hScrollBar_hue_tweak.Minimum = -1000;
            this.hScrollBar_hue_tweak.Name = "hScrollBar_hue_tweak";
            this.hScrollBar_hue_tweak.Size = new System.Drawing.Size(205, 21);
            this.hScrollBar_hue_tweak.TabIndex = 7;
            this.hScrollBar_hue_tweak.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_hue_tweak_Scroll);
            // 
            // label_gamma
            // 
            this.label_gamma.AutoSize = true;
            this.label_gamma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_gamma.Location = new System.Drawing.Point(280, 162);
            this.label_gamma.Name = "label_gamma";
            this.label_gamma.Size = new System.Drawing.Size(23, 13);
            this.label_gamma.TabIndex = 19;
            this.label_gamma.Text = "1.8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hue";
            // 
            // label_bright
            // 
            this.label_bright.AutoSize = true;
            this.label_bright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_bright.Location = new System.Drawing.Point(280, 128);
            this.label_bright.Name = "label_bright";
            this.label_bright.Size = new System.Drawing.Size(13, 13);
            this.label_bright.TabIndex = 18;
            this.label_bright.Text = "1";
            // 
            // hScrollBar_contrast
            // 
            this.hScrollBar_contrast.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hScrollBar_contrast.Location = new System.Drawing.Point(72, 90);
            this.hScrollBar_contrast.Maximum = 2000;
            this.hScrollBar_contrast.Minimum = 500;
            this.hScrollBar_contrast.Name = "hScrollBar_contrast";
            this.hScrollBar_contrast.Size = new System.Drawing.Size(205, 21);
            this.hScrollBar_contrast.TabIndex = 9;
            this.hScrollBar_contrast.Value = 1000;
            this.hScrollBar_contrast.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_contrast_Scroll);
            // 
            // label_const
            // 
            this.label_const.AutoSize = true;
            this.label_const.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_const.Location = new System.Drawing.Point(280, 94);
            this.label_const.Name = "label_const";
            this.label_const.Size = new System.Drawing.Size(13, 13);
            this.label_const.TabIndex = 17;
            this.label_const.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Contrast";
            // 
            // label_hue
            // 
            this.label_hue.AutoSize = true;
            this.label_hue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_hue.Location = new System.Drawing.Point(280, 60);
            this.label_hue.Name = "label_hue";
            this.label_hue.Size = new System.Drawing.Size(13, 13);
            this.label_hue.TabIndex = 16;
            this.label_hue.Text = "0";
            // 
            // hScrollBar_brightness
            // 
            this.hScrollBar_brightness.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hScrollBar_brightness.Location = new System.Drawing.Point(72, 124);
            this.hScrollBar_brightness.Maximum = 2000;
            this.hScrollBar_brightness.Minimum = 500;
            this.hScrollBar_brightness.Name = "hScrollBar_brightness";
            this.hScrollBar_brightness.Size = new System.Drawing.Size(205, 21);
            this.hScrollBar_brightness.TabIndex = 11;
            this.hScrollBar_brightness.Value = 1000;
            this.hScrollBar_brightness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_brightness_Scroll);
            // 
            // label_satur
            // 
            this.label_satur.AutoSize = true;
            this.label_satur.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_satur.Location = new System.Drawing.Point(280, 26);
            this.label_satur.Name = "label_satur";
            this.label_satur.Size = new System.Drawing.Size(13, 13);
            this.label_satur.TabIndex = 15;
            this.label_satur.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(12, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Brightness";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(12, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Gamma";
            // 
            // hScrollBar_gamma
            // 
            this.hScrollBar_gamma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hScrollBar_gamma.Location = new System.Drawing.Point(72, 158);
            this.hScrollBar_gamma.Maximum = 2500;
            this.hScrollBar_gamma.Minimum = 1000;
            this.hScrollBar_gamma.Name = "hScrollBar_gamma";
            this.hScrollBar_gamma.Size = new System.Drawing.Size(205, 21);
            this.hScrollBar_gamma.TabIndex = 13;
            this.hScrollBar_gamma.Value = 1800;
            this.hScrollBar_gamma.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_gamma_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(338, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(303, 356);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 337);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "&Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(485, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_palb);
            this.groupBox1.Controls.Add(this.radioButton_ntsc);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 44);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit palette of";
            this.toolTip1.SetToolTip(this.groupBox1, "Select the tv format you want to edit palette for");
            // 
            // radioButton_palb
            // 
            this.radioButton_palb.AutoSize = true;
            this.radioButton_palb.Location = new System.Drawing.Point(63, 19);
            this.radioButton_palb.Name = "radioButton_palb";
            this.radioButton_palb.Size = new System.Drawing.Size(49, 17);
            this.radioButton_palb.TabIndex = 1;
            this.radioButton_palb.Text = "PALB";
            this.radioButton_palb.UseVisualStyleBackColor = true;
            // 
            // radioButton_ntsc
            // 
            this.radioButton_ntsc.AutoSize = true;
            this.radioButton_ntsc.Checked = true;
            this.radioButton_ntsc.Location = new System.Drawing.Point(6, 19);
            this.radioButton_ntsc.Name = "radioButton_ntsc";
            this.radioButton_ntsc.Size = new System.Drawing.Size(51, 17);
            this.radioButton_ntsc.TabIndex = 0;
            this.radioButton_ntsc.TabStop = true;
            this.radioButton_ntsc.Text = "NTSC";
            this.radioButton_ntsc.UseVisualStyleBackColor = true;
            // 
            // FormPaletteSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 409);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPaletteSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette Settings";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.HScrollBar hScrollBar_saturation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar_hue_tweak;
        private System.Windows.Forms.Label label_gamma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_bright;
        private System.Windows.Forms.HScrollBar hScrollBar_contrast;
        private System.Windows.Forms.Label label_const;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_hue;
        private System.Windows.Forms.HScrollBar hScrollBar_brightness;
        private System.Windows.Forms.Label label_satur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.HScrollBar hScrollBar_gamma;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_palb;
        private System.Windows.Forms.RadioButton radioButton_ntsc;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}