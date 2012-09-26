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
                    textBox_select.Text = "Keyboard.Q";
                    textBox_start.Text = "Keyboard.E";
                    break;
                case 3:
                    textBox_up.Text = "Keyboard.T";
                    textBox_down.Text = "Keyboard.G";
                    textBox_left.Text = "Keyboard.F";
                    textBox_right.Text = "Keyboard.H";
                    textBox_a.Text = "Keyboard.M";
                    textBox_b.Text = "Keyboard.N";
                    textBox_select.Text = "Keyboard.U";
                    textBox_start.Text = "Keyboard.Y";
                    break;
                case 4:
                    textBox_up.Text = "Keyboard.B";
                    textBox_down.Text = "Keyboard.G";
                    textBox_left.Text = "Keyboard.P";
                    textBox_right.Text = "Keyboard.L";
                    textBox_a.Text = "Keyboard.I";
                    textBox_b.Text = "Keyboard.O";
                    textBox_select.Text = "Keyboard.F11";
                    textBox_start.Text = "Keyboard.R";
                    break;
            }
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
    }
}
