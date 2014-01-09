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
    partial class FormMemoryWatcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMemoryWatcher));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_prg = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton_SRAM = new System.Windows.Forms.RadioButton();
            this.radioButton_WRAM = new System.Windows.Forms.RadioButton();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.memoryWathcerPanel1 = new MyNes.MemoryWathcerPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.radioButton_prg);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.radioButton_SRAM);
            this.panel1.Controls.Add(this.radioButton_WRAM);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 35);
            this.panel1.TabIndex = 0;
            // 
            // radioButton_prg
            // 
            this.radioButton_prg.AutoSize = true;
            this.radioButton_prg.ForeColor = System.Drawing.Color.Black;
            this.radioButton_prg.Location = new System.Drawing.Point(134, 6);
            this.radioButton_prg.Name = "radioButton_prg";
            this.radioButton_prg.Size = new System.Drawing.Size(45, 17);
            this.radioButton_prg.TabIndex = 3;
            this.radioButton_prg.Text = "PRG";
            this.toolTip1.SetToolTip(this.radioButton_prg, "PRG ($8000 - $FFFF)");
            this.radioButton_prg.UseVisualStyleBackColor = true;
            this.radioButton_prg.CheckedChanged += new System.EventHandler(this.radioButton_prg_CheckedChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(481, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "LOCK";
            this.toolTip1.SetToolTip(this.button1, "Lock the window to update every 100 milliseconds");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton_SRAM
            // 
            this.radioButton_SRAM.AutoSize = true;
            this.radioButton_SRAM.ForeColor = System.Drawing.Color.Black;
            this.radioButton_SRAM.Location = new System.Drawing.Point(75, 6);
            this.radioButton_SRAM.Name = "radioButton_SRAM";
            this.radioButton_SRAM.Size = new System.Drawing.Size(53, 17);
            this.radioButton_SRAM.TabIndex = 1;
            this.radioButton_SRAM.Text = "SRAM";
            this.toolTip1.SetToolTip(this.radioButton_SRAM, "Save-RAM ($6000 - $7FFF)");
            this.radioButton_SRAM.UseVisualStyleBackColor = true;
            this.radioButton_SRAM.CheckedChanged += new System.EventHandler(this.radioButton_SRAM_CheckedChanged);
            // 
            // radioButton_WRAM
            // 
            this.radioButton_WRAM.AutoSize = true;
            this.radioButton_WRAM.Checked = true;
            this.radioButton_WRAM.ForeColor = System.Drawing.Color.Black;
            this.radioButton_WRAM.Location = new System.Drawing.Point(12, 6);
            this.radioButton_WRAM.Name = "radioButton_WRAM";
            this.radioButton_WRAM.Size = new System.Drawing.Size(57, 17);
            this.radioButton_WRAM.TabIndex = 0;
            this.radioButton_WRAM.TabStop = true;
            this.radioButton_WRAM.Text = "WRAM";
            this.toolTip1.SetToolTip(this.radioButton_WRAM, "Work RAM ($0000 - $1FFF)");
            this.radioButton_WRAM.UseVisualStyleBackColor = true;
            this.radioButton_WRAM.CheckedChanged += new System.EventHandler(this.radioButton_WRAM_CheckedChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(551, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 408);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // memoryWathcerPanel1
            // 
            this.memoryWathcerPanel1.BackColor = System.Drawing.Color.Black;
            this.memoryWathcerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoryWathcerPanel1.Location = new System.Drawing.Point(0, 0);
            this.memoryWathcerPanel1.Name = "memoryWathcerPanel1";
            this.memoryWathcerPanel1.Size = new System.Drawing.Size(551, 408);
            this.memoryWathcerPanel1.TabIndex = 2;
            this.memoryWathcerPanel1.Text = "memoryWathcerPanel1";
            this.memoryWathcerPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.memoryWathcerPanel1_MouseMove);
            this.memoryWathcerPanel1.Resize += new System.EventHandler(this.Form_MemoryWatcher_Resize);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(400, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Refresh";
            this.toolTip1.SetToolTip(this.button2, "Update memory monitor");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMemoryWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 443);
            this.Controls.Add(this.memoryWathcerPanel1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(584, 481);
            this.Name = "FormMemoryWatcher";
            this.ShowInTaskbar = false;
            this.Text = "Memory Watcher";
            this.Resize += new System.EventHandler(this.Form_MemoryWatcher_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.RadioButton radioButton_SRAM;
        private System.Windows.Forms.RadioButton radioButton_WRAM;
        private System.Windows.Forms.ToolTip toolTip1;
        private MemoryWathcerPanel memoryWathcerPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton radioButton_prg;
        private System.Windows.Forms.Button button2;
    }
}