namespace myNES
{
    partial class FormConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsole));
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.panel = new System.Windows.Forms.Panel();
            this.consolePanel = new myNES.ConsolePanel();
            this.comboBoxHistory = new System.Windows.Forms.ComboBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(583, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 389);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.vScrollBar);
            this.panel.Controls.Add(this.consolePanel);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(600, 389);
            this.panel.TabIndex = 2;
            // 
            // consolePanel
            // 
            this.consolePanel.BackColor = System.Drawing.Color.Black;
            this.consolePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolePanel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consolePanel.ForeColor = System.Drawing.Color.Lime;
            this.consolePanel.Location = new System.Drawing.Point(0, 0);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Size = new System.Drawing.Size(600, 389);
            this.consolePanel.TabIndex = 1;
            this.consolePanel.DebugLinesUpdated += new System.EventHandler(this.consolePanel1_DebugLinesUpdated);
            this.consolePanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            // 
            // comboBoxHistory
            // 
            this.comboBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHistory.FormattingEnabled = true;
            this.comboBoxHistory.Location = new System.Drawing.Point(93, 409);
            this.comboBoxHistory.Name = "comboBoxHistory";
            this.comboBoxHistory.Size = new System.Drawing.Size(519, 21);
            this.comboBoxHistory.TabIndex = 1;
            this.comboBoxHistory.Text = "Enter command...";
            this.comboBoxHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEnter.Location = new System.Drawing.Point(12, 407);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(75, 23);
            this.buttonEnter.TabIndex = 0;
            this.buttonEnter.Text = "&Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.comboBoxHistory);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "myNES v5 - Console";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Console_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            this.Resize += new System.EventHandler(this.Frm_Console_Resize);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private ConsolePanel consolePanel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox comboBoxHistory;
        private System.Windows.Forms.Button buttonEnter;
    }
}