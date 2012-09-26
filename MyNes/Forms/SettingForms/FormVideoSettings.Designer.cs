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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_currentRenderer = new System.Windows.Forms.ComboBox();
            this.comboBox_fullscreenRes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_imMode = new System.Windows.Forms.CheckBox();
            this.checkBox_hideLines = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_fullscreen = new System.Windows.Forms.CheckBox();
            this.comboBox_adapter = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_jpg = new System.Windows.Forms.RadioButton();
            this.radioButton_bmp = new System.Windows.Forms.RadioButton();
            this.radioButton_png = new System.Windows.Forms.RadioButton();
            this.radioButton_gif = new System.Windows.Forms.RadioButton();
            this.radioButton_tiff = new System.Windows.Forms.RadioButton();
            this.radioButton_emf = new System.Windows.Forms.RadioButton();
            this.radioButton_wmf = new System.Windows.Forms.RadioButton();
            this.radioButton_exif = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current renderer:";
            // 
            // comboBox_currentRenderer
            // 
            this.comboBox_currentRenderer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_currentRenderer.FormattingEnabled = true;
            this.comboBox_currentRenderer.Location = new System.Drawing.Point(6, 32);
            this.comboBox_currentRenderer.Name = "comboBox_currentRenderer";
            this.comboBox_currentRenderer.Size = new System.Drawing.Size(259, 21);
            this.comboBox_currentRenderer.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBox_currentRenderer, "Select the renderer (or the host).\r\nEach renderer uses different resources and ma" +
        "y produce\r\ndifferent qualities.");
            // 
            // comboBox_fullscreenRes
            // 
            this.comboBox_fullscreenRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fullscreenRes.FormattingEnabled = true;
            this.comboBox_fullscreenRes.Location = new System.Drawing.Point(6, 112);
            this.comboBox_fullscreenRes.Name = "comboBox_fullscreenRes";
            this.comboBox_fullscreenRes.Size = new System.Drawing.Size(259, 21);
            this.comboBox_fullscreenRes.TabIndex = 3;
            this.toolTip1.SetToolTip(this.comboBox_fullscreenRes, "Select the video adapter resolution that will be used when\r\nswitching to fullscre" +
        "en.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fullscreen resolution:";
            // 
            // checkBox_imMode
            // 
            this.checkBox_imMode.AutoSize = true;
            this.checkBox_imMode.Location = new System.Drawing.Point(6, 40);
            this.checkBox_imMode.Name = "checkBox_imMode";
            this.checkBox_imMode.Size = new System.Drawing.Size(105, 17);
            this.checkBox_imMode.TabIndex = 4;
            this.checkBox_imMode.Text = "Immediate mode";
            this.toolTip1.SetToolTip(this.checkBox_imMode, "Don\'t wait for current frame to complete before rendering\r\nanother one. This opti" +
        "on may improve performance but may \r\ncause shattering in the image specialy in f" +
        "ullscreen.");
            this.checkBox_imMode.UseVisualStyleBackColor = true;
            // 
            // checkBox_hideLines
            // 
            this.checkBox_hideLines.AutoSize = true;
            this.checkBox_hideLines.Location = new System.Drawing.Point(6, 63);
            this.checkBox_hideLines.Name = "checkBox_hideLines";
            this.checkBox_hideLines.Size = new System.Drawing.Size(260, 17);
            this.checkBox_hideLines.TabIndex = 5;
            this.checkBox_hideLines.Text = "Hide upper and lower lines (8 in NTSC, 1 in PALB)";
            this.checkBox_hideLines.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_fullscreen
            // 
            this.checkBox_fullscreen.AutoSize = true;
            this.checkBox_fullscreen.Location = new System.Drawing.Point(6, 17);
            this.checkBox_fullscreen.Name = "checkBox_fullscreen";
            this.checkBox_fullscreen.Size = new System.Drawing.Size(74, 17);
            this.checkBox_fullscreen.TabIndex = 9;
            this.checkBox_fullscreen.Text = "Fullscreen";
            this.toolTip1.SetToolTip(this.checkBox_fullscreen, "Launch game in fullscreen. To switch to fullscreen any\r\ntime, press the fullscree" +
        "n button (see input settings>emulation).");
            this.checkBox_fullscreen.UseVisualStyleBackColor = true;
            // 
            // comboBox_adapter
            // 
            this.comboBox_adapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_adapter.FormattingEnabled = true;
            this.comboBox_adapter.Location = new System.Drawing.Point(6, 72);
            this.comboBox_adapter.Name = "comboBox_adapter";
            this.comboBox_adapter.Size = new System.Drawing.Size(259, 21);
            this.comboBox_adapter.TabIndex = 11;
            this.toolTip1.SetToolTip(this.comboBox_adapter, "Select the video adapter.");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(330, 223);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "&Defaults";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Adpater:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "None-Fullscreen image stretch:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 152);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "n x 256, n x 240 while n is entered value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_fullscreen);
            this.groupBox1.Controls.Add(this.checkBox_imMode);
            this.groupBox1.Controls.Add(this.checkBox_hideLines);
            this.groupBox1.Location = new System.Drawing.Point(296, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 93);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_currentRenderer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.comboBox_fullscreenRes);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_adapter);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 185);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_exif);
            this.groupBox3.Controls.Add(this.radioButton_wmf);
            this.groupBox3.Controls.Add(this.radioButton_emf);
            this.groupBox3.Controls.Add(this.radioButton_tiff);
            this.groupBox3.Controls.Add(this.radioButton_gif);
            this.groupBox3.Controls.Add(this.radioButton_png);
            this.groupBox3.Controls.Add(this.radioButton_bmp);
            this.groupBox3.Controls.Add(this.radioButton_jpg);
            this.groupBox3.Location = new System.Drawing.Point(296, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 86);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Snapshot image format";
            // 
            // radioButton_jpg
            // 
            this.radioButton_jpg.AutoSize = true;
            this.radioButton_jpg.Location = new System.Drawing.Point(23, 25);
            this.radioButton_jpg.Name = "radioButton_jpg";
            this.radioButton_jpg.Size = new System.Drawing.Size(40, 17);
            this.radioButton_jpg.TabIndex = 0;
            this.radioButton_jpg.Text = "jpg";
            this.radioButton_jpg.UseVisualStyleBackColor = true;
            // 
            // radioButton_bmp
            // 
            this.radioButton_bmp.AutoSize = true;
            this.radioButton_bmp.Location = new System.Drawing.Point(69, 25);
            this.radioButton_bmp.Name = "radioButton_bmp";
            this.radioButton_bmp.Size = new System.Drawing.Size(45, 17);
            this.radioButton_bmp.TabIndex = 1;
            this.radioButton_bmp.Text = "bmp";
            this.radioButton_bmp.UseVisualStyleBackColor = true;
            // 
            // radioButton_png
            // 
            this.radioButton_png.AutoSize = true;
            this.radioButton_png.Checked = true;
            this.radioButton_png.Location = new System.Drawing.Point(120, 25);
            this.radioButton_png.Name = "radioButton_png";
            this.radioButton_png.Size = new System.Drawing.Size(43, 17);
            this.radioButton_png.TabIndex = 2;
            this.radioButton_png.TabStop = true;
            this.radioButton_png.Text = "png";
            this.radioButton_png.UseVisualStyleBackColor = true;
            // 
            // radioButton_gif
            // 
            this.radioButton_gif.AutoSize = true;
            this.radioButton_gif.Location = new System.Drawing.Point(169, 25);
            this.radioButton_gif.Name = "radioButton_gif";
            this.radioButton_gif.Size = new System.Drawing.Size(37, 17);
            this.radioButton_gif.TabIndex = 3;
            this.radioButton_gif.Text = "gif";
            this.radioButton_gif.UseVisualStyleBackColor = true;
            // 
            // radioButton_tiff
            // 
            this.radioButton_tiff.AutoSize = true;
            this.radioButton_tiff.Location = new System.Drawing.Point(212, 25);
            this.radioButton_tiff.Name = "radioButton_tiff";
            this.radioButton_tiff.Size = new System.Drawing.Size(39, 17);
            this.radioButton_tiff.TabIndex = 4;
            this.radioButton_tiff.Text = "tiff";
            this.radioButton_tiff.UseVisualStyleBackColor = true;
            // 
            // radioButton_emf
            // 
            this.radioButton_emf.AutoSize = true;
            this.radioButton_emf.Location = new System.Drawing.Point(23, 48);
            this.radioButton_emf.Name = "radioButton_emf";
            this.radioButton_emf.Size = new System.Drawing.Size(43, 17);
            this.radioButton_emf.TabIndex = 5;
            this.radioButton_emf.Text = "emf";
            this.radioButton_emf.UseVisualStyleBackColor = true;
            // 
            // radioButton_wmf
            // 
            this.radioButton_wmf.AutoSize = true;
            this.radioButton_wmf.Location = new System.Drawing.Point(69, 48);
            this.radioButton_wmf.Name = "radioButton_wmf";
            this.radioButton_wmf.Size = new System.Drawing.Size(45, 17);
            this.radioButton_wmf.TabIndex = 6;
            this.radioButton_wmf.Text = "wmf";
            this.radioButton_wmf.UseVisualStyleBackColor = true;
            // 
            // radioButton_exif
            // 
            this.radioButton_exif.AutoSize = true;
            this.radioButton_exif.Location = new System.Drawing.Point(120, 48);
            this.radioButton_exif.Name = "radioButton_exif";
            this.radioButton_exif.Size = new System.Drawing.Size(43, 17);
            this.radioButton_exif.TabIndex = 7;
            this.radioButton_exif.Text = "exif";
            this.radioButton_exif.UseVisualStyleBackColor = true;
            // 
            // FormVideoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 258);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVideoSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_currentRenderer;
        private System.Windows.Forms.ComboBox comboBox_fullscreenRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_imMode;
        private System.Windows.Forms.CheckBox checkBox_hideLines;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox_fullscreen;
        private System.Windows.Forms.ComboBox comboBox_adapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_png;
        private System.Windows.Forms.RadioButton radioButton_bmp;
        private System.Windows.Forms.RadioButton radioButton_jpg;
        private System.Windows.Forms.RadioButton radioButton_tiff;
        private System.Windows.Forms.RadioButton radioButton_gif;
        private System.Windows.Forms.RadioButton radioButton_emf;
        private System.Windows.Forms.RadioButton radioButton_wmf;
        private System.Windows.Forms.RadioButton radioButton_exif;
    }
}