/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNes
{
    public partial class ISC_VSUnisystem : InputSettingsControl
    {
        public ISC_VSUnisystem()
        {
            InitializeComponent(); LoadSetting();
        }
        private void ChangeControlMapping(TextBox button)
        {
            if (Program.Settings.ControlProfileIndex == 0)
            {
                MessageBox.Show("You can't change mapping of default profile. To do so, select profiles page, add new profile then select this page again to change mapping.");
                return;
            }
            FormKey kk = new FormKey();

            kk.Location = new Point(this.Parent.Parent.Parent.Location.X + this.Parent.Parent.Location.X + button.Location.X,
                this.Parent.Parent.Parent.Location.Y + this.Parent.Parent.Location.Y + button.Location.Y + 30);

            if (kk.ShowDialog(this) == DialogResult.OK)
                button.Text = kk.InputName;

            SaveSettings();
        }
        public override void SaveSettings()
        {
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditLeftCoinSlot = textBox_CreditLeftCoinSlot.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditRightCoinSlot = textBox_CreditRightCoinSlot.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditServiceButton = textBox_CreditServiceButton.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch1 = textBox_DIPSwitch1.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch2 = textBox_DIPSwitch2.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch3 = textBox_DIPSwitch3.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch4 = textBox_DIPSwitch4.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch5 = textBox_DIPSwitch5.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch6 = textBox_DIPSwitch6.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch7 = textBox_DIPSwitch7.Text;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch8 = textBox_DIPSwitch8.Text;
        }
        public override void DefaultSettings()
        {
            textBox_CreditServiceButton.Text = "Keyboard.End";
            textBox_DIPSwitch1.Text = "Keyboard.NumberPad1";
            textBox_DIPSwitch2.Text = "Keyboard.NumberPad2";
            textBox_DIPSwitch3.Text = "Keyboard.NumberPad3";
            textBox_DIPSwitch4.Text = "Keyboard.NumberPad4";
            textBox_DIPSwitch5.Text = "Keyboard.NumberPad5";
            textBox_DIPSwitch6.Text = "Keyboard.NumberPad6";
            textBox_DIPSwitch7.Text = "Keyboard.NumberPad7";
            textBox_DIPSwitch8.Text = "Keyboard.NumberPad8";
            textBox_CreditLeftCoinSlot.Text = "Keyboard.Insert";
            textBox_CreditRightCoinSlot.Text = "Keyboard.Home";
        }
        public override void OnSettingsSelect()
        {
            LoadSetting();
        }
        private void LoadSetting()
        {
            textBox_CreditLeftCoinSlot.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditLeftCoinSlot;
            textBox_CreditRightCoinSlot.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditRightCoinSlot;
            textBox_CreditServiceButton.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.CreditServiceButton;
            textBox_DIPSwitch1.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch1;
            textBox_DIPSwitch2.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch2;
            textBox_DIPSwitch3.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch3;
            textBox_DIPSwitch4.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch4;
            textBox_DIPSwitch5.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch5;
            textBox_DIPSwitch6.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch6;
            textBox_DIPSwitch7.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch7;
            textBox_DIPSwitch8.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].VSunisystemDIP.DIPSwitch8;
        }

        private void textBox_CreditServiceButton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_CreditServiceButton);
        }

        private void textBox_CreditServiceButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_CreditServiceButton);
        }

        private void textBox_CreditLeftCoinSlot_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_CreditLeftCoinSlot);
        }

        private void textBox_CreditLeftCoinSlot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_CreditLeftCoinSlot);
        }

        private void textBox_CreditRightCoinSlot_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_CreditRightCoinSlot);
        }

        private void textBox_CreditRightCoinSlot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_CreditRightCoinSlot);
        }

        private void textBox_DIPSwitch1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch1);
        }

        private void textBox_DIPSwitch1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch1);
        }

        private void textBox_DIPSwitch2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch2);
        }

        private void textBox_DIPSwitch2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch2);
        }

        private void textBox_DIPSwitch3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch3);
        }

        private void textBox_DIPSwitch3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch3);
        }

        private void textBox_DIPSwitch4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch4);
        }

        private void textBox_DIPSwitch4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch4);
        }

        private void textBox_DIPSwitch5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch5);
        }

        private void textBox_DIPSwitch5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch5);
        }

        private void textBox_DIPSwitch6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch6);
        }

        private void textBox_DIPSwitch6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch6);
        }

        private void textBox_DIPSwitch7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch7);
        }

        private void textBox_DIPSwitch7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch7);
        }

        private void textBox_DIPSwitch8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_DIPSwitch8);
        }

        private void textBox_DIPSwitch8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_DIPSwitch8);
        }
    }
}
