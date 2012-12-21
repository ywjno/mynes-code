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
using MyNes.Renderers;
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
            foreach (ControlProfile profile in RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection)
                listBox1.Items.Add(profile.Name);
            listBox1.SelectedIndex = RenderersCore.SettingsManager.Settings.Controls_ProfileIndex;
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
                profile.Connect4Players = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Connect4Players;
                profile.ConnectZapper = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].ConnectZapper;

                profile.Player1.A = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.A;
                profile.Player1.B = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.B;
                profile.Player1.Down = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.Down;
                profile.Player1.Left = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.Left;
                profile.Player1.Right = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.Right;
                profile.Player1.Select = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.Select;
                profile.Player1.Start = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.Start;
                profile.Player1.Up = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.Up;
                profile.Player1.TurboA = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.TurboA;
                profile.Player1.TurboB = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player1.TurboB;

                profile.Player2.A = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.A;
                profile.Player2.B = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.B;
                profile.Player2.Down = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.Down;
                profile.Player2.Left = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.Left;
                profile.Player2.Right = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.Right;
                profile.Player2.Select = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.Select;
                profile.Player2.Start = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.Start;
                profile.Player2.Up = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.Up;
                profile.Player2.TurboA = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.TurboA;
                profile.Player2.TurboB = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player2.TurboB;

                profile.Player3.A = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.A;
                profile.Player3.B = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.B;
                profile.Player3.Down = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.Down;
                profile.Player3.Left = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.Left;
                profile.Player3.Right = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.Right;
                profile.Player3.Select = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.Select;
                profile.Player3.Start = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.Start;
                profile.Player3.Up = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.Up;
                profile.Player3.TurboA = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.TurboA;
                profile.Player3.TurboB = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player3.TurboB;

                profile.Player4.A = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.A;
                profile.Player4.B = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.B;
                profile.Player4.Down = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.Down;
                profile.Player4.Left = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.Left;
                profile.Player4.Right = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.Right;
                profile.Player4.Select = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.Select;
                profile.Player4.Start = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.Start;
                profile.Player4.Up = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.Up;
                profile.Player4.TurboA = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.TurboA;
                profile.Player4.TurboB = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Player4.TurboB;

                profile.Shortcuts.HardReset = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.HardReset;
                profile.Shortcuts.LoadState = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.LoadState;
                profile.Shortcuts.SaveState = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SaveState;
                profile.Shortcuts.SelecteSlot0 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot0;
                profile.Shortcuts.SelecteSlot1 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot1;
                profile.Shortcuts.SelecteSlot2 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot2;
                profile.Shortcuts.SelecteSlot3 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot3;
                profile.Shortcuts.SelecteSlot4 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot4;
                profile.Shortcuts.SelecteSlot5 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot5;
                profile.Shortcuts.SelecteSlot6 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot6;
                profile.Shortcuts.SelecteSlot7 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot7;
                profile.Shortcuts.SelecteSlot8 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot8;
                profile.Shortcuts.SelecteSlot9 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SelecteSlot9;
                profile.Shortcuts.ShutdownEmulation = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.ShutdownEmulation;
                profile.Shortcuts.SoftReset = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.SoftReset;
                profile.Shortcuts.TakeSnapshot = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.TakeSnapshot;
                profile.Shortcuts.ToggleLimiter = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.ToggleLimiter;
                profile.Shortcuts.PauseEmulation = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.PauseEmulation;
                profile.Shortcuts.ResumeEmulation = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.ResumeEmulation;
                profile.Shortcuts.Fullscreen = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].Shortcuts.Fullscreen;

                profile.VSunisystemDIP.CreditLeftCoinSlot = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditLeftCoinSlot;
                profile.VSunisystemDIP.CreditRightCoinSlot = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditRightCoinSlot;
                profile.VSunisystemDIP.CreditServiceButton = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.CreditServiceButton;
                profile.VSunisystemDIP.DIPSwitch1 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch1;
                profile.VSunisystemDIP.DIPSwitch2 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch2;
                profile.VSunisystemDIP.DIPSwitch3 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch3;
                profile.VSunisystemDIP.DIPSwitch4 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch4;
                profile.VSunisystemDIP.DIPSwitch5 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch5;
                profile.VSunisystemDIP.DIPSwitch6 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch6;
                profile.VSunisystemDIP.DIPSwitch7 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch7;
                profile.VSunisystemDIP.DIPSwitch8 = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[frm.ProfileIndexToCopyFrom].VSunisystemDIP.DIPSwitch8;

                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.Add(profile);
                RenderersCore.SettingsManager.Settings.Controls_ProfileIndex = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.Count - 1;
                RefreshProfiles();
                RenderersCore.SettingsManager.SaveSettings();
            }
        }
        //select profile
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_edit.Enabled = button_remove.Enabled = (listBox1.SelectedItem.ToString().ToLower() != "<default>");
            RenderersCore.SettingsManager.Settings.Controls_ProfileIndex = listBox1.SelectedIndex;
            if (ProfileChanged != null)
                ProfileChanged(this, null);
            RenderersCore.SettingsManager.SaveSettings();
        }
        //remove
        private void button_remove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;
            if (MessageBox.Show("Are you sure ?", "Remove profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.RemoveAt(listBox1.SelectedIndex);
                RenderersCore.SettingsManager.Settings.Controls_ProfileIndex = 0;
                RefreshProfiles();
                RenderersCore.SettingsManager.SaveSettings();
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
                RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[listBox1.SelectedIndex].Name = frm.EnteredName;
                RefreshProfiles();
                RenderersCore.SettingsManager.SaveSettings();
            }
        }
    }
}
