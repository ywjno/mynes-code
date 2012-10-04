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
    public partial class ISC_Player : InputSettingsControl
    {
        private int playerIndex;
        public ISC_Player(int playerIndex)
        {
            this.playerIndex = playerIndex;
            InitializeComponent();
            LoadSetting();
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
            switch (playerIndex)
            {
                case 1:
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Up = textBox_up.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Down = textBox_down.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Left = textBox_left.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Right = textBox_right.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.A = textBox_a.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.B = textBox_b.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.TurboA = textBox_turboA.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.TurboB = textBox_turboB.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Select = textBox_select.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Start = textBox_start.Text;
                    break;
                case 2:
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Up = textBox_up.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Down = textBox_down.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Left = textBox_left.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Right = textBox_right.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.A = textBox_a.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.B = textBox_b.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.TurboA = textBox_turboA.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.TurboB = textBox_turboB.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Select = textBox_select.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Start = textBox_start.Text;
                    break;
                case 3:
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Up = textBox_up.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Down = textBox_down.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Left = textBox_left.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Right = textBox_right.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.A = textBox_a.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.B = textBox_b.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.TurboA = textBox_turboA.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.TurboB = textBox_turboB.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Select = textBox_select.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Start = textBox_start.Text;
                    break;
                case 4:
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Up = textBox_up.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Down = textBox_down.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Left = textBox_left.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Right = textBox_right.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.A = textBox_a.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.B = textBox_b.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.TurboA = textBox_turboA.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.TurboB = textBox_turboB.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Select = textBox_select.Text;
                    Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Start = textBox_start.Text;
                    break;
            }
        }
        public override void DefaultSettings()
        {
            switch (playerIndex)
            {
                case 1:
                    textBox_up.Text = "Keyboard.UpArrow";
                    textBox_down.Text = "Keyboard.DownArrow";
                    textBox_left.Text = "Keyboard.LeftArrow";
                    textBox_right.Text = "Keyboard.RightArrow";
                    textBox_a.Text = "Keyboard.X";
                    textBox_b.Text = "Keyboard.Z";
                    textBox_turboA.Text = "Keyboard.S";
                    textBox_turboB .Text= "Keyboard.A";
                    textBox_select.Text = "Keyboard.C";
                    textBox_start.Text = "Keyboard.V";
                    break;
                case 2:
                    textBox_up.Text = "Keyboard.W";
                    textBox_down.Text = "Keyboard.S";
                    textBox_left.Text = "Keyboard.A";
                    textBox_right.Text = "Keyboard.D";
                    textBox_a.Text = "Keyboard.K";
                    textBox_b.Text = "Keyboard.J";
                    textBox_turboA.Text = "Keyboard.I";
                    textBox_turboB .Text= "Keyboard.U";
                    textBox_select.Text = "Keyboard.Q";
                    textBox_start.Text = "Keyboard.E";
                    break;
                case 3:
                    textBox_up.Text = "";
                    textBox_down.Text = "";
                    textBox_left.Text = "";
                    textBox_right.Text = "";
                    textBox_a.Text = "";
                    textBox_b.Text = "";
                    textBox_turboA.Text = "";
                    textBox_turboB .Text= "";
                    textBox_select.Text = "";
                    textBox_start.Text = "";
                    break;
                case 4:
                    textBox_up.Text = "";
                    textBox_down.Text = "";
                    textBox_left.Text = "";
                    textBox_right.Text = "";
                    textBox_a.Text = "";
                    textBox_b.Text = "";
                    textBox_turboA.Text = "";
                    textBox_turboB .Text= "";
                    textBox_select.Text = "";
                    textBox_start.Text = "";
                    break;
            }
            SaveSettings();
        }
        public override void OnSettingsSelect()
        {
            LoadSetting();
        }
        private void LoadSetting()
        {
            switch (playerIndex)
            {
                case 1:
                    textBox_up.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Up;
                    textBox_down.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Down;
                    textBox_left.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Left;
                    textBox_right.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Right;
                    textBox_a.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.A;
                    textBox_b.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.B;
                    textBox_select.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Select;
                    textBox_start.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.Start;
                    textBox_turboA.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.TurboA;
                    textBox_turboB.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player1.TurboB;
                    break;
                case 2:
                    textBox_up.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Up;
                    textBox_down.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Down;
                    textBox_left.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Left;
                    textBox_right.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Right;
                    textBox_a.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.A;
                    textBox_b.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.B;
                    textBox_select.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Select;
                    textBox_start.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.Start;
                    textBox_turboA.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.TurboA;
                    textBox_turboB.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player2.TurboB;
                    break;
                case 3:
                    textBox_up.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Up;
                    textBox_down.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Down;
                    textBox_left.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Left;
                    textBox_right.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Right;
                    textBox_a.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.A;
                    textBox_b.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.B;
                    textBox_select.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Select;
                    textBox_start.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.Start;
                    textBox_turboA.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.TurboA;
                    textBox_turboB.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player3.TurboB;
                    break;
                case 4:
                    textBox_up.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Up;
                    textBox_down.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Down;
                    textBox_left.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Left;
                    textBox_right.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Right;
                    textBox_a.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.A;
                    textBox_b.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.B;
                    textBox_select.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Select;
                    textBox_start.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.Start;
                    textBox_turboA.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.TurboA;
                    textBox_turboB.Text = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Player4.TurboB;
                    break;
            }
        }

        private void textBox_up_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_up);
        }
        private void textBox_up_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_up);
        }
        private void textBox_right_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_right);
        }
        private void textBox_right_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_right);
        }
        private void textBox_down_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_down);
        }
        private void textBox_down_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_down);
        }
        private void textBox_left_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_left);
        }
        private void textBox_left_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_left);
        }
        private void textBox_select_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_select);
        }
        private void textBox_select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_select);
        }
        private void textBox_start_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_start);
        }
        private void textBox_start_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_start);
        }
        private void textBox_b_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_b);
        }
        private void textBox_b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_b);
        }
        private void textBox_a_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_a);
        }
        private void textBox_a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_a);
        }
        private void textBox_turboB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_turboB);
        }
        private void textBox_turboB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_turboB);
        }
        private void textBox_turboA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_turboA);
        }
        private void textBox_turboA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_turboA);
        }
    }
}
