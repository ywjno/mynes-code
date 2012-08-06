namespace MyNes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxHistory = new System.Windows.Forms.ComboBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.consolePanel = new MyNes.ConsolePanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(607, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 421);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxHistory);
            this.panel1.Controls.Add(this.buttonEnter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 21);
            this.panel1.TabIndex = 2;
            // 
            // comboBoxHistory
            // 
            this.comboBoxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxHistory.FormattingEnabled = true;
            this.comboBoxHistory.Location = new System.Drawing.Point(52, 0);
            this.comboBoxHistory.Name = "comboBoxHistory";
            this.comboBoxHistory.Size = new System.Drawing.Size(572, 21);
            this.comboBoxHistory.TabIndex = 1;
            this.comboBoxHistory.Text = "Enter command...";
            this.comboBoxHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEnter.Location = new System.Drawing.Point(0, 0);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(52, 21);
            this.buttonEnter.TabIndex = 0;
            this.buttonEnter.Text = "&Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // consolePanel
            // 
            this.consolePanel.BackColor = System.Drawing.Color.Black;
            this.consolePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolePanel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consolePanel.ForeColor = System.Drawing.Color.Lime;
            this.consolePanel.Location = new System.Drawing.Point(0, 0);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Size = new System.Drawing.Size(607, 421);
            this.consolePanel.TabIndex = 1;
            this.consolePanel.DebugLinesUpdated += new System.EventHandler(this.consolePanel1_DebugLinesUpdated);
            this.consolePanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            // 
            // Frm_Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.consolePanel);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Console";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "My NES - Console";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Console_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Console_KeyDown);
            this.Resize += new System.EventHandler(this.Frm_Console_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private ConsolePanel consolePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxHistory;
        private System.Windows.Forms.Button buttonEnter;
    }
}