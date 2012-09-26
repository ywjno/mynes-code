namespace MyNes
{
    partial class FormSoundSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSoundSettings));
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_bitrate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_volLevel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox_enableSound = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_Normal = new System.Windows.Forms.RadioButton();
            this.radioButton_Linear = new System.Windows.Forms.RadioButton();
            this.radioButton_Implementation = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.trackBar_latency = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_latency = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_latency)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(6, 19);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Minimum = -3000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(251, 33);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 200;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Frequency:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(74, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hz, Bitdepth:";
            // 
            // comboBox_bitrate
            // 
            this.comboBox_bitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bitrate.FormattingEnabled = true;
            this.comboBox_bitrate.Location = new System.Drawing.Point(226, 19);
            this.comboBox_bitrate.Name = "comboBox_bitrate";
            this.comboBox_bitrate.Size = new System.Drawing.Size(48, 21);
            this.comboBox_bitrate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bit";
            // 
            // label_volLevel
            // 
            this.label_volLevel.AutoSize = true;
            this.label_volLevel.Location = new System.Drawing.Point(262, 28);
            this.label_volLevel.Name = "label_volLevel";
            this.label_volLevel.Size = new System.Drawing.Size(36, 13);
            this.label_volLevel.TabIndex = 7;
            this.label_volLevel.Text = "100%";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "&Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "&Defaults";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.linkLabel5);
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_bitrate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 78);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playback";
            this.toolTip1.SetToolTip(this.groupBox1, "Adjust playback quality. Lower values produce lower sound \r\nquality but may impro" +
        "ve performance.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Profiles:";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(71, 51);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(68, 13);
            this.linkLabel5.TabIndex = 11;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Performance";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(204, 51);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(37, 13);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Studio";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(171, 51);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(27, 13);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "DVD";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(145, 51);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(21, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "CD";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox_enableSound
            // 
            this.checkBox_enableSound.AutoSize = true;
            this.checkBox_enableSound.Location = new System.Drawing.Point(12, 10);
            this.checkBox_enableSound.Name = "checkBox_enableSound";
            this.checkBox_enableSound.Size = new System.Drawing.Size(90, 17);
            this.checkBox_enableSound.TabIndex = 12;
            this.checkBox_enableSound.Text = "Enable sound";
            this.toolTip1.SetToolTip(this.checkBox_enableSound, "Check to enable sound playback");
            this.checkBox_enableSound.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_Normal);
            this.groupBox2.Controls.Add(this.radioButton_Linear);
            this.groupBox2.Controls.Add(this.radioButton_Implementation);
            this.groupBox2.Location = new System.Drawing.Point(12, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 49);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mixer";
            // 
            // radioButton_Normal
            // 
            this.radioButton_Normal.AutoSize = true;
            this.radioButton_Normal.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Normal.Name = "radioButton_Normal";
            this.radioButton_Normal.Size = new System.Drawing.Size(58, 17);
            this.radioButton_Normal.TabIndex = 2;
            this.radioButton_Normal.TabStop = true;
            this.radioButton_Normal.Text = "Normal";
            this.toolTip1.SetToolTip(this.radioButton_Normal, "Use no mixer, just sum the channel outputs for a sample");
            this.radioButton_Normal.UseVisualStyleBackColor = true;
            // 
            // radioButton_Linear
            // 
            this.radioButton_Linear.AutoSize = true;
            this.radioButton_Linear.Location = new System.Drawing.Point(175, 19);
            this.radioButton_Linear.Name = "radioButton_Linear";
            this.radioButton_Linear.Size = new System.Drawing.Size(126, 17);
            this.radioButton_Linear.TabIndex = 1;
            this.radioButton_Linear.TabStop = true;
            this.radioButton_Linear.Text = "Linear Approximation";
            this.toolTip1.SetToolTip(this.radioButton_Linear, resources.GetString("radioButton_Linear.ToolTip"));
            this.radioButton_Linear.UseVisualStyleBackColor = true;
            // 
            // radioButton_Implementation
            // 
            this.radioButton_Implementation.AutoSize = true;
            this.radioButton_Implementation.Checked = true;
            this.radioButton_Implementation.Location = new System.Drawing.Point(70, 19);
            this.radioButton_Implementation.Name = "radioButton_Implementation";
            this.radioButton_Implementation.Size = new System.Drawing.Size(99, 17);
            this.radioButton_Implementation.TabIndex = 0;
            this.radioButton_Implementation.TabStop = true;
            this.radioButton_Implementation.Text = "Implementation";
            this.toolTip1.SetToolTip(this.radioButton_Implementation, resources.GetString("radioButton_Implementation.ToolTip"));
            this.radioButton_Implementation.UseVisualStyleBackColor = true;
            // 
            // trackBar_latency
            // 
            this.trackBar_latency.AutoSize = false;
            this.trackBar_latency.Location = new System.Drawing.Point(6, 19);
            this.trackBar_latency.Maximum = 100;
            this.trackBar_latency.Minimum = 1;
            this.trackBar_latency.Name = "trackBar_latency";
            this.trackBar_latency.Size = new System.Drawing.Size(251, 33);
            this.trackBar_latency.TabIndex = 1;
            this.trackBar_latency.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.toolTip1.SetToolTip(this.trackBar_latency, "Adjust the latency in milliseconds. This required for some\r\nplayback profiles.");
            this.trackBar_latency.Value = 1;
            this.trackBar_latency.Scroll += new System.EventHandler(this.trackBar_latency_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.label_volLevel);
            this.groupBox3.Location = new System.Drawing.Point(12, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 60);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Volume";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBar_latency);
            this.groupBox4.Controls.Add(this.label_latency);
            this.groupBox4.Location = new System.Drawing.Point(12, 154);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(305, 60);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Latency (milliseconds)";
            // 
            // label_latency
            // 
            this.label_latency.AutoSize = true;
            this.label_latency.Location = new System.Drawing.Point(262, 28);
            this.label_latency.Name = "label_latency";
            this.label_latency.Size = new System.Drawing.Size(19, 13);
            this.label_latency.TabIndex = 7;
            this.label_latency.Text = "10";
            // 
            // FormSoundSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 368);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox_enableSound);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSoundSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sound Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_latency)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_bitrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_volLevel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_enableSound;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_Implementation;
        private System.Windows.Forms.RadioButton radioButton_Linear;
        private System.Windows.Forms.RadioButton radioButton_Normal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trackBar_latency;
        private System.Windows.Forms.Label label_latency;
    }
}