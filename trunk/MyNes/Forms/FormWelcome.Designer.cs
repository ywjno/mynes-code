/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
    partial class FormWelcome
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
            MLV.ManagedListViewColumnsCollection managedListViewColumnsCollection3 = new MLV.ManagedListViewColumnsCollection();
            MLV.ManagedListViewItemsCollection managedListViewItemsCollection3 = new MLV.ManagedListViewItemsCollection();
            MLV.ManagedListViewColumnsCollection managedListViewColumnsCollection1 = new MLV.ManagedListViewColumnsCollection();
            MLV.ManagedListViewItemsCollection managedListViewItemsCollection1 = new MLV.ManagedListViewItemsCollection();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.managedListView_states = new MLV.ManagedListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.managedListView1 = new MLV.ManagedListView();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 302);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.managedListView_states);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(451, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recent states";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // managedListView_states
            // 
            this.managedListView_states.AllowColumnsReorder = true;
            this.managedListView_states.AllowItemsDragAndDrop = true;
            this.managedListView_states.ChangeColumnSortModeWhenClick = true;
            this.managedListView_states.Columns = managedListViewColumnsCollection3;
            this.managedListView_states.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedListView_states.DrawHighlight = true;
            this.managedListView_states.Items = managedListViewItemsCollection3;
            this.managedListView_states.Location = new System.Drawing.Point(3, 3);
            this.managedListView_states.Name = "managedListView_states";
            this.managedListView_states.Size = new System.Drawing.Size(445, 270);
            this.managedListView_states.TabIndex = 0;
            this.managedListView_states.ThunmbnailsHeight = 120;
            this.managedListView_states.ThunmbnailsWidth = 120;
            this.managedListView_states.ViewMode = MLV.ManagedListViewViewMode.Thumbnails;
            this.managedListView_states.WheelScrollSpeed = 19;
            this.managedListView_states.DrawItem += new System.EventHandler<MLV.ManagedListViewItemDrawArgs>(this.managedListView_states_DrawItem);
            this.managedListView_states.ItemDoubleClick += new System.EventHandler<MLV.ManagedListViewItemDoubleClickArgs>(this.managedListView_states_ItemDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.managedListView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(451, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Recent roms";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // managedListView1
            // 
            this.managedListView1.AllowColumnsReorder = false;
            this.managedListView1.AllowItemsDragAndDrop = false;
            this.managedListView1.ChangeColumnSortModeWhenClick = false;
            this.managedListView1.Columns = managedListViewColumnsCollection1;
            this.managedListView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.managedListView1.DrawHighlight = true;
            this.managedListView1.Items = managedListViewItemsCollection1;
            this.managedListView1.Location = new System.Drawing.Point(3, 3);
            this.managedListView1.Name = "managedListView1";
            this.managedListView1.Size = new System.Drawing.Size(445, 333);
            this.managedListView1.TabIndex = 0;
            this.managedListView1.ThunmbnailsHeight = 36;
            this.managedListView1.ThunmbnailsWidth = 36;
            this.managedListView1.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.managedListView1.WheelScrollSpeed = 19;
            this.managedListView1.ItemDoubleClick += new System.EventHandler<MLV.ManagedListViewItemDoubleClickArgs>(this.managedListView1_ItemDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 333);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(162, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "&Show this window at startup";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Open";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormWelcome
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 364);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWelcome";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to My Nes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWelcome_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private MLV.ManagedListView managedListView_states;
        private MLV.ManagedListView managedListView1;
        private System.Windows.Forms.Button button2;
    }
}