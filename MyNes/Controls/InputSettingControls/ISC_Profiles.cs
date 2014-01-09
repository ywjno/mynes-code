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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Renderers;
using MMB;
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
            foreach (ControlProfile profile in Program.Settings.InputProfiles)
                listBox1.Items.Add(profile.Name);
            listBox1.SelectedIndex = Program.Settings.InputProfileIndex;
        }
        public event EventHandler ProfileChanged;
        public event EventHandler BeforeProfileChange;
        //add profile
        private void button1_Click(object sender, EventArgs e)
        {
            FormAddControlsProfile frm = new FormAddControlsProfile();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ControlProfile profile = new ControlProfile();
                profile.Name = frm.ProfileName;
                //copy settings
                profile.Connect4Players = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Connect4Players;
                profile.ConnectZapper = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].ConnectZapper;

                profile.Player1.A = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.A;
                profile.Player1.B = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.B;
                profile.Player1.Down = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.Down;
                profile.Player1.Left = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.Left;
                profile.Player1.Right = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.Right;
                profile.Player1.Select = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.Select;
                profile.Player1.Start = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.Start;
                profile.Player1.Up = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.Up;
                profile.Player1.TurboA = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.TurboA;
                profile.Player1.TurboB = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player1.TurboB;

                profile.Player2.A = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.A;
                profile.Player2.B = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.B;
                profile.Player2.Down = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.Down;
                profile.Player2.Left = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.Left;
                profile.Player2.Right = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.Right;
                profile.Player2.Select = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.Select;
                profile.Player2.Start = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.Start;
                profile.Player2.Up = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.Up;
                profile.Player2.TurboA = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.TurboA;
                profile.Player2.TurboB = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player2.TurboB;

                profile.Player3.A = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.A;
                profile.Player3.B = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.B;
                profile.Player3.Down = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.Down;
                profile.Player3.Left = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.Left;
                profile.Player3.Right = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.Right;
                profile.Player3.Select = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.Select;
                profile.Player3.Start = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.Start;
                profile.Player3.Up = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.Up;
                profile.Player3.TurboA = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.TurboA;
                profile.Player3.TurboB = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player3.TurboB;

                profile.Player4.A = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.A;
                profile.Player4.B = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.B;
                profile.Player4.Down = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.Down;
                profile.Player4.Left = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.Left;
                profile.Player4.Right = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.Right;
                profile.Player4.Select = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.Select;
                profile.Player4.Start = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.Start;
                profile.Player4.Up = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.Up;
                profile.Player4.TurboA = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.TurboA;
                profile.Player4.TurboB = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].Player4.TurboB;

                profile.VSunisystemDIP.CreditLeftCoinSlot = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditLeftCoinSlot;
                profile.VSunisystemDIP.CreditRightCoinSlot = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditRightCoinSlot;
                profile.VSunisystemDIP.CreditServiceButton = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditServiceButton;
                profile.VSunisystemDIP.DIPSwitch1 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch1;
                profile.VSunisystemDIP.DIPSwitch2 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch2;
                profile.VSunisystemDIP.DIPSwitch3 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch3;
                profile.VSunisystemDIP.DIPSwitch4 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch4;
                profile.VSunisystemDIP.DIPSwitch5 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch5;
                profile.VSunisystemDIP.DIPSwitch6 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch6;
                profile.VSunisystemDIP.DIPSwitch7 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch7;
                profile.VSunisystemDIP.DIPSwitch8 = Program.Settings.InputProfiles[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch8;

                Program.Settings.InputProfiles.Add(profile);
                Program.Settings.InputProfileIndex = Program.Settings.InputProfiles.Count - 1;
                // Save
                RefreshProfiles();
            }
        }
        //select profile
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_edit.Enabled = button_remove.Enabled = (listBox1.SelectedItem.ToString().ToLower() != "<default>");
            if (BeforeProfileChange != null)
                BeforeProfileChange(this, null);
            Program.Settings.InputProfileIndex = listBox1.SelectedIndex;
            if (ProfileChanged != null)
                ProfileChanged(this, null);
        }
        //remove
        private void button_remove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            ManagedMessageBoxResult res = ManagedMessageBox.ShowQuestionMessage(Program.ResourceManager.GetString("Message_AreYouSureToDeleteProfile"),
                Program.ResourceManager.GetString("MessageCaption_RemoveProfile"));
            if (res.ClickedButtonIndex == 0)
            {
                // Remove
                Program.Settings.InputProfiles.RemoveAt(listBox1.SelectedIndex);
                // Save
                Program.Settings.InputProfileIndex = 0;
                // Refresh
                listBox1.SelectedIndex = 0;
                RefreshProfiles();
            }
        }
        //edit
        private void button_edit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            FormEnterName frm = new FormEnterName(Program.ResourceManager.GetString("Message_EnterProfileName"),
                listBox1.SelectedItem.ToString(), true, false);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // Get current profile index
                Program.Settings.InputProfiles[listBox1.SelectedIndex].Name = frm.EnteredName;
                RefreshProfiles();
            }
        }
    }
}
