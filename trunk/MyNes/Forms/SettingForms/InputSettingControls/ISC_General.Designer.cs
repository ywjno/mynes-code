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
    partial class ISC_General
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox_4players = new System.Windows.Forms.CheckBox();
            this.checkBox_zapper = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // checkBox_4players
            // 
            this.checkBox_4players.AutoSize = true;
            this.checkBox_4players.Location = new System.Drawing.Point(3, 3);
            this.checkBox_4players.Name = "checkBox_4players";
            this.checkBox_4players.Size = new System.Drawing.Size(113, 17);
            this.checkBox_4players.TabIndex = 0;
            this.checkBox_4players.Text = "Connect 4 players";
            this.checkBox_4players.UseVisualStyleBackColor = true;
            // 
            // checkBox_zapper
            // 
            this.checkBox_zapper.AutoSize = true;
            this.checkBox_zapper.Location = new System.Drawing.Point(3, 26);
            this.checkBox_zapper.Name = "checkBox_zapper";
            this.checkBox_zapper.Size = new System.Drawing.Size(103, 17);
            this.checkBox_zapper.TabIndex = 1;
            this.checkBox_zapper.Text = "Connect Zapper";
            this.checkBox_zapper.UseVisualStyleBackColor = true;
            // 
            // ISC_General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_zapper);
            this.Controls.Add(this.checkBox_4players);
            this.Name = "ISC_General";
            this.Size = new System.Drawing.Size(256, 142);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_4players;
        private System.Windows.Forms.CheckBox checkBox_zapper;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
