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
    public partial class ISC_Profiles : InputSettingsControl
    {
        public ISC_Profiles()
        {
            InitializeComponent();
            RefreshProfiles();
        }
        private void RefreshProfiles()
        {
            listBox1.Items.Clear();
            foreach (ControlProfile profile in Program.Settings.ControlProfiles)
                listBox1.Items.Add(profile.Name);
            listBox1.SelectedIndex = Program.Settings.ControlProfileIndex;
        }
        public event EventHandler ProfileChanged;
        //add profile
        private void button1_Click(object sender, EventArgs e)
        {
            FormAddControlsProfile frm = new FormAddControlsProfile();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ControlProfile profile = new ControlProfile();
                profile.Name = frm.ProfileName;
                //copy settings
                profile.Connect4Players = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Connect4Players;
                profile.ConnectZapper = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].ConnectZapper;

                profile.Player1.A = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.A;
                profile.Player1.B = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.B;
                profile.Player1.Down = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.Down;
                profile.Player1.Left = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.Left;
                profile.Player1.Right = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.Right;
                profile.Player1.Select = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.Select;
                profile.Player1.Start = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.Start;
                profile.Player1.Up = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player1.Up;

                profile.Player2.A = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.A;
                profile.Player2.B = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.B;
                profile.Player2.Down = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.Down;
                profile.Player2.Left = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.Left;
                profile.Player2.Right = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.Right;
                profile.Player2.Select = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.Select;
                profile.Player2.Start = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.Start;
                profile.Player2.Up = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player2.Up;

                profile.Player3.A = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.A;
                profile.Player3.B = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.B;
                profile.Player3.Down = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.Down;
                profile.Player3.Left = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.Left;
                profile.Player3.Right = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.Right;
                profile.Player3.Select = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.Select;
                profile.Player3.Start = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.Start;
                profile.Player3.Up = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player3.Up;

                profile.Player4.A = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.A;
                profile.Player4.B = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.B;
                profile.Player4.Down = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.Down;
                profile.Player4.Left = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.Left;
                profile.Player4.Right = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.Right;
                profile.Player4.Select = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.Select;
                profile.Player4.Start = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.Start;
                profile.Player4.Up = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Player4.Up;

                profile.Shortcuts.HardReset = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.HardReset;
                profile.Shortcuts.LoadState = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.LoadState;
                profile.Shortcuts.SaveState = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SaveState;
                profile.Shortcuts.SelecteSlot0 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot0;
                profile.Shortcuts.SelecteSlot1 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot1;
                profile.Shortcuts.SelecteSlot2 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot2;
                profile.Shortcuts.SelecteSlot3 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot3;
                profile.Shortcuts.SelecteSlot4 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot4;
                profile.Shortcuts.SelecteSlot5 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot5;
                profile.Shortcuts.SelecteSlot6 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot6;
                profile.Shortcuts.SelecteSlot7 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot7;
                profile.Shortcuts.SelecteSlot8 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot8;
                profile.Shortcuts.SelecteSlot9 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot9;
                profile.Shortcuts.ShutdownEmulation = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.ShutdownEmulation;
                profile.Shortcuts.SoftReset = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.SoftReset;
                profile.Shortcuts.TakeSnapshot = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.TakeSnapshot;
                profile.Shortcuts.ToggleLimiter = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.ToggleLimiter;
                profile.Shortcuts.PauseEmulation = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.PauseEmulation;
                profile.Shortcuts.ResumeEmulation = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.ResumeEmulation;
                profile.Shortcuts.Fullscreen = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].Shortcuts.Fullscreen;

                profile.VSunisystemDIP.CreditLeftCoinSlot = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditLeftCoinSlot;
                profile.VSunisystemDIP.CreditRightCoinSlot = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditRightCoinSlot;
                profile.VSunisystemDIP.CreditServiceButton = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditServiceButton;
                profile.VSunisystemDIP.DIPSwitch1 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch1;
                profile.VSunisystemDIP.DIPSwitch2 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch2;
                profile.VSunisystemDIP.DIPSwitch3 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch3;
                profile.VSunisystemDIP.DIPSwitch4 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch4;
                profile.VSunisystemDIP.DIPSwitch5 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch5;
                profile.VSunisystemDIP.DIPSwitch6 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch6;
                profile.VSunisystemDIP.DIPSwitch7 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch7;
                profile.VSunisystemDIP.DIPSwitch8 = Program.Settings.ControlProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch8;

                Program.Settings.ControlProfiles.Add(profile);
                Program.Settings.ControlProfileIndex = Program.Settings.ControlProfiles.Count - 1;
                RefreshProfiles();
                Program.Settings.Save();
            }
        }
        //select profile
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_edit.Enabled = button_remove.Enabled = (listBox1.SelectedItem.ToString().ToLower() != "<default>");
            Program.Settings.ControlProfileIndex = listBox1.SelectedIndex;
            if (ProfileChanged != null)
                ProfileChanged(this, null);
            Program.Settings.Save();
        }
        //remove
        private void button_remove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            if (MessageBox.Show("Are you sure ?", "Remove profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.Settings.ControlProfiles.RemoveAt(listBox1.SelectedIndex);
                Program.Settings.ControlProfileIndex = 0;
                RefreshProfiles();
                Program.Settings.Save();
            }
        }
        //edit
        private void button_edit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            EnterNameForm frm = new EnterNameForm("Enter profile name", listBox1.SelectedItem.ToString(), true, false);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                Program.Settings.ControlProfiles[listBox1.SelectedIndex].Name = frm.EnteredName;
                RefreshProfiles();
                Program.Settings.Save();
            }
        }
    }
}
