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
    partial class ISC_VSUnisystem
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
            this.textBox_CreditServiceButton = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_CreditLeftCoinSlot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_CreditRightCoinSlot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_DIPSwitch8 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_CreditServiceButton
            // 
            this.textBox_CreditServiceButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CreditServiceButton.Location = new System.Drawing.Point(118, 3);
            this.textBox_CreditServiceButton.Name = "textBox_CreditServiceButton";
            this.textBox_CreditServiceButton.ReadOnly = true;
            this.textBox_CreditServiceButton.Size = new System.Drawing.Size(212, 22);
            this.textBox_CreditServiceButton.TabIndex = 3;
            this.textBox_CreditServiceButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CreditServiceButton_KeyDown);
            this.textBox_CreditServiceButton.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_CreditServiceButton_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Credit Service Button";
            // 
            // textBox_CreditLeftCoinSlot
            // 
            this.textBox_CreditLeftCoinSlot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CreditLeftCoinSlot.Location = new System.Drawing.Point(118, 31);
            this.textBox_CreditLeftCoinSlot.Name = "textBox_CreditLeftCoinSlot";
            this.textBox_CreditLeftCoinSlot.ReadOnly = true;
            this.textBox_CreditLeftCoinSlot.Size = new System.Drawing.Size(212, 22);
            this.textBox_CreditLeftCoinSlot.TabIndex = 5;
            this.textBox_CreditLeftCoinSlot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CreditLeftCoinSlot_KeyDown);
            this.textBox_CreditLeftCoinSlot.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_CreditLeftCoinSlot_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Credit Left Coin Slot";
            // 
            // textBox_CreditRightCoinSlot
            // 
            this.textBox_CreditRightCoinSlot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CreditRightCoinSlot.Location = new System.Drawing.Point(118, 59);
            this.textBox_CreditRightCoinSlot.Name = "textBox_CreditRightCoinSlot";
            this.textBox_CreditRightCoinSlot.ReadOnly = true;
            this.textBox_CreditRightCoinSlot.Size = new System.Drawing.Size(212, 22);
            this.textBox_CreditRightCoinSlot.TabIndex = 7;
            this.textBox_CreditRightCoinSlot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CreditRightCoinSlot_KeyDown);
            this.textBox_CreditRightCoinSlot.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_CreditRightCoinSlot_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Credit Right Coin Slot";
            // 
            // textBox_DIPSwitch1
            // 
            this.textBox_DIPSwitch1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch1.Location = new System.Drawing.Point(118, 87);
            this.textBox_DIPSwitch1.Name = "textBox_DIPSwitch1";
            this.textBox_DIPSwitch1.ReadOnly = true;
            this.textBox_DIPSwitch1.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch1.TabIndex = 9;
            this.textBox_DIPSwitch1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch1_KeyDown);
            this.textBox_DIPSwitch1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch1_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "DIP Switch 1";
            // 
            // textBox_DIPSwitch2
            // 
            this.textBox_DIPSwitch2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch2.Location = new System.Drawing.Point(118, 115);
            this.textBox_DIPSwitch2.Name = "textBox_DIPSwitch2";
            this.textBox_DIPSwitch2.ReadOnly = true;
            this.textBox_DIPSwitch2.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch2.TabIndex = 11;
            this.textBox_DIPSwitch2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch2_KeyDown);
            this.textBox_DIPSwitch2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch2_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "DIP Switch 2";
            // 
            // textBox_DIPSwitch3
            // 
            this.textBox_DIPSwitch3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch3.Location = new System.Drawing.Point(118, 143);
            this.textBox_DIPSwitch3.Name = "textBox_DIPSwitch3";
            this.textBox_DIPSwitch3.ReadOnly = true;
            this.textBox_DIPSwitch3.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch3.TabIndex = 13;
            this.textBox_DIPSwitch3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch3_KeyDown);
            this.textBox_DIPSwitch3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch3_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "DIP Switch 3";
            // 
            // textBox_DIPSwitch4
            // 
            this.textBox_DIPSwitch4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch4.Location = new System.Drawing.Point(118, 171);
            this.textBox_DIPSwitch4.Name = "textBox_DIPSwitch4";
            this.textBox_DIPSwitch4.ReadOnly = true;
            this.textBox_DIPSwitch4.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch4.TabIndex = 15;
            this.textBox_DIPSwitch4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch4_KeyDown);
            this.textBox_DIPSwitch4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch4_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "DIP Switch 4";
            // 
            // textBox_DIPSwitch5
            // 
            this.textBox_DIPSwitch5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch5.Location = new System.Drawing.Point(118, 199);
            this.textBox_DIPSwitch5.Name = "textBox_DIPSwitch5";
            this.textBox_DIPSwitch5.ReadOnly = true;
            this.textBox_DIPSwitch5.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch5.TabIndex = 17;
            this.textBox_DIPSwitch5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch5_KeyDown);
            this.textBox_DIPSwitch5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch5_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "DIP Switch 5";
            // 
            // textBox_DIPSwitch6
            // 
            this.textBox_DIPSwitch6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch6.Location = new System.Drawing.Point(118, 227);
            this.textBox_DIPSwitch6.Name = "textBox_DIPSwitch6";
            this.textBox_DIPSwitch6.ReadOnly = true;
            this.textBox_DIPSwitch6.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch6.TabIndex = 19;
            this.textBox_DIPSwitch6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch6_KeyDown);
            this.textBox_DIPSwitch6.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch6_MouseDoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "DIP Switch 6";
            // 
            // textBox_DIPSwitch7
            // 
            this.textBox_DIPSwitch7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch7.Location = new System.Drawing.Point(118, 255);
            this.textBox_DIPSwitch7.Name = "textBox_DIPSwitch7";
            this.textBox_DIPSwitch7.ReadOnly = true;
            this.textBox_DIPSwitch7.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch7.TabIndex = 21;
            this.textBox_DIPSwitch7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch7_KeyDown);
            this.textBox_DIPSwitch7.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch7_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "DIP Switch 7";
            // 
            // textBox_DIPSwitch8
            // 
            this.textBox_DIPSwitch8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DIPSwitch8.Location = new System.Drawing.Point(118, 283);
            this.textBox_DIPSwitch8.Name = "textBox_DIPSwitch8";
            this.textBox_DIPSwitch8.ReadOnly = true;
            this.textBox_DIPSwitch8.Size = new System.Drawing.Size(212, 22);
            this.textBox_DIPSwitch8.TabIndex = 23;
            this.textBox_DIPSwitch8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_DIPSwitch8_KeyDown);
            this.textBox_DIPSwitch8.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DIPSwitch8_MouseDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "DIP Switch 8";
            // 
            // ISC_VSUnisystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_DIPSwitch8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_DIPSwitch7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_DIPSwitch6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_DIPSwitch5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_DIPSwitch4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_DIPSwitch3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_DIPSwitch2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_DIPSwitch1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_CreditRightCoinSlot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_CreditLeftCoinSlot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_CreditServiceButton);
            this.Controls.Add(this.label1);
            this.Name = "ISC_VSUnisystem";
            this.Size = new System.Drawing.Size(333, 326);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_CreditServiceButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_CreditLeftCoinSlot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_CreditRightCoinSlot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DIPSwitch1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_DIPSwitch2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_DIPSwitch3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DIPSwitch4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_DIPSwitch5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_DIPSwitch6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_DIPSwitch7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_DIPSwitch8;
        private System.Windows.Forms.Label label11;
    }
}
