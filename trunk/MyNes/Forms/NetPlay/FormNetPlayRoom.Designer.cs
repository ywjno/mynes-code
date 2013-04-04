namespace MyNes
{
    partial class FormNetPlayRoom
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.managedListView1 = new MLV.ManagedListView();
            this.groupBox_gameObtions = new System.Windows.Forms.GroupBox();
            this.textBox_romSha1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_ready = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chatPanel1 = new MyNes.ChatPanel();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox_serverStatus = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_kick = new System.Windows.Forms.Button();
            this.button_ban = new System.Windows.Forms.Button();
            this.button_setPlayer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox_gameObtions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_serverStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_setPlayer);
            this.groupBox1.Controls.Add(this.button_ban);
            this.groupBox1.Controls.Add(this.button_kick);
            this.groupBox1.Controls.Add(this.managedListView1);
            this.groupBox1.Location = new System.Drawing.Point(491, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Players";
            // 
            // managedListView1
            // 
            this.managedListView1.AllowColumnsReorder = false;
            this.managedListView1.AllowItemsDragAndDrop = false;
            this.managedListView1.ChangeColumnSortModeWhenClick = false;
            this.managedListView1.Columns = managedListViewColumnsCollection2;
            this.managedListView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.managedListView1.DrawHighlight = true;
            this.managedListView1.Items = managedListViewItemsCollection2;
            this.managedListView1.Location = new System.Drawing.Point(3, 48);
            this.managedListView1.Name = "managedListView1";
            this.managedListView1.Size = new System.Drawing.Size(271, 310);
            this.managedListView1.TabIndex = 0;
            this.managedListView1.ThunmbnailsHeight = 36;
            this.managedListView1.ThunmbnailsWidth = 36;
            this.managedListView1.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.managedListView1.WheelScrollSpeed = 19;
            // 
            // groupBox_gameObtions
            // 
            this.groupBox_gameObtions.Controls.Add(this.groupBox_serverStatus);
            this.groupBox_gameObtions.Controls.Add(this.textBox_romSha1);
            this.groupBox_gameObtions.Controls.Add(this.label4);
            this.groupBox_gameObtions.Location = new System.Drawing.Point(12, 12);
            this.groupBox_gameObtions.Name = "groupBox_gameObtions";
            this.groupBox_gameObtions.Size = new System.Drawing.Size(473, 130);
            this.groupBox_gameObtions.TabIndex = 1;
            this.groupBox_gameObtions.TabStop = false;
            this.groupBox_gameObtions.Text = "Game options";
            // 
            // textBox_romSha1
            // 
            this.textBox_romSha1.Location = new System.Drawing.Point(6, 32);
            this.textBox_romSha1.Name = "textBox_romSha1";
            this.textBox_romSha1.ReadOnly = true;
            this.textBox_romSha1.Size = new System.Drawing.Size(461, 20);
            this.textBox_romSha1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Rom sha 1:";
            // 
            // button_ready
            // 
            this.button_ready.Location = new System.Drawing.Point(661, 382);
            this.button_ready.Name = "button_ready";
            this.button_ready.Size = new System.Drawing.Size(107, 32);
            this.button_ready.TabIndex = 2;
            this.button_ready.Text = "&Start the game !";
            this.button_ready.UseVisualStyleBackColor = true;
            this.button_ready.Click += new System.EventHandler(this.button_ready_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(585, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Log out";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chatPanel1);
            this.groupBox3.Controls.Add(this.textBox_message);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.vScrollBar1);
            this.groupBox3.Location = new System.Drawing.Point(12, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(473, 225);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chat";
            // 
            // chatPanel1
            // 
            this.chatPanel1.BackColor = System.Drawing.Color.White;
            this.chatPanel1.Location = new System.Drawing.Point(9, 19);
            this.chatPanel1.Name = "chatPanel1";
            this.chatPanel1.Size = new System.Drawing.Size(441, 174);
            this.chatPanel1.TabIndex = 4;
            this.chatPanel1.Text = "chatPanel1";
            // 
            // textBox_message
            // 
            this.textBox_message.Location = new System.Drawing.Point(6, 198);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(380, 20);
            this.textBox_message.TabIndex = 3;
            this.textBox_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_message_KeyDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(392, 196);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(450, 20);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 173);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // groupBox_serverStatus
            // 
            this.groupBox_serverStatus.Controls.Add(this.label3);
            this.groupBox_serverStatus.Controls.Add(this.textBox_status);
            this.groupBox_serverStatus.Controls.Add(this.textBox_port);
            this.groupBox_serverStatus.Controls.Add(this.label2);
            this.groupBox_serverStatus.Controls.Add(this.textBox_ip);
            this.groupBox_serverStatus.Controls.Add(this.label1);
            this.groupBox_serverStatus.Location = new System.Drawing.Point(6, 58);
            this.groupBox_serverStatus.Name = "groupBox_serverStatus";
            this.groupBox_serverStatus.Size = new System.Drawing.Size(461, 64);
            this.groupBox_serverStatus.TabIndex = 5;
            this.groupBox_serverStatus.TabStop = false;
            this.groupBox_serverStatus.Text = "Server status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status:";
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(313, 38);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.Size = new System.Drawing.Size(142, 20);
            this.textBox_status.TabIndex = 4;
            // 
            // textBox_port
            // 
            this.textBox_port.BackColor = System.Drawing.Color.White;
            this.textBox_port.Location = new System.Drawing.Point(175, 38);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.ReadOnly = true;
            this.textBox_port.Size = new System.Drawing.Size(67, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.BackColor = System.Drawing.Color.White;
            this.textBox_ip.Location = new System.Drawing.Point(6, 38);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.ReadOnly = true;
            this.textBox_ip.Size = new System.Drawing.Size(163, 20);
            this.textBox_ip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_kick
            // 
            this.button_kick.Location = new System.Drawing.Point(6, 19);
            this.button_kick.Name = "button_kick";
            this.button_kick.Size = new System.Drawing.Size(75, 23);
            this.button_kick.TabIndex = 1;
            this.button_kick.Text = "&Kick out";
            this.button_kick.UseVisualStyleBackColor = true;
            this.button_kick.Click += new System.EventHandler(this.button_kick_Click);
            // 
            // button_ban
            // 
            this.button_ban.Location = new System.Drawing.Point(87, 19);
            this.button_ban.Name = "button_ban";
            this.button_ban.Size = new System.Drawing.Size(75, 23);
            this.button_ban.TabIndex = 2;
            this.button_ban.Text = "&Set banned";
            this.button_ban.UseVisualStyleBackColor = true;
            this.button_ban.Click += new System.EventHandler(this.button_ban_Click);
            // 
            // button_setPlayer
            // 
            this.button_setPlayer.Location = new System.Drawing.Point(168, 19);
            this.button_setPlayer.Name = "button_setPlayer";
            this.button_setPlayer.Size = new System.Drawing.Size(103, 23);
            this.button_setPlayer.TabIndex = 3;
            this.button_setPlayer.Text = "Set &player #";
            this.button_setPlayer.UseVisualStyleBackColor = true;
            this.button_setPlayer.Click += new System.EventHandler(this.button_setPlayer_Click);
            // 
            // FormNetPlayRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 426);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_ready);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_gameObtions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNetPlayRoom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetPlay Room";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNetPlayRoom_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox_gameObtions.ResumeLayout(false);
            this.groupBox_gameObtions.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_serverStatus.ResumeLayout(false);
            this.groupBox_serverStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_gameObtions;
        private System.Windows.Forms.Button button_ready;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.GroupBox groupBox_serverStatus;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_romSha1;
        private System.Windows.Forms.Label label4;
        private MLV.ManagedListView managedListView1;
        private ChatPanel chatPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_setPlayer;
        private System.Windows.Forms.Button button_ban;
        private System.Windows.Forms.Button button_kick;
    }
}