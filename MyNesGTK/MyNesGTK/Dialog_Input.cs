//
//  Dialog_Input.cs
//
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
//
//  Copyright (c) 2009 - 2013 Ala Ibrahim Hadid 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using Gtk;
using MyNes.Renderers;

namespace MyNesGTK
{
	public partial class Dialog_Input : Gtk.Dialog
	{
		public Dialog_Input ()
		{
			this.Build ();
			RefreshProfiles ();
		}

		private void RefreshProfiles ()
		{
			ListStore ClearList = new ListStore (typeof(string), typeof(string));
			combobox_profiles.Model = ClearList;
			// load profiles
			foreach (ControlProfile profile in RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection) {
				combobox_profiles.AppendText (profile.Name);
			}
			combobox_profiles.Active = RenderersCore.SettingsManager.Settings.Controls_ProfileIndex;
			// load inputs
			LoadSettings ();
		}

		private void LoadSettings ()
		{
			ControlProfile profile =
				RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection
					[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex];
			// options
			checkbutton_4players.Active = profile.Connect4Players;
			checkbutton_zapper.Active = profile.ConnectZapper;
			// player 1
			entry_p1_a.Text = profile.Player1.A;
			entry_p1_b.Text = profile.Player1.B;
			entry_p1_start.Text = profile.Player1.Start;
			entry_p1_select.Text = profile.Player1.Select;
			entry_p1_up.Text = profile.Player1.Up;
			entry_p1_left.Text = profile.Player1.Left;
			entry_p1_right.Text = profile.Player1.Right;
			entry_p1_down.Text = profile.Player1.Down;
			// player 2
			entry_p2_a.Text = profile.Player2.A;
			entry_p2_b.Text = profile.Player2.B;
			entry_p2_start.Text = profile.Player2.Start;
			entry_p2_select.Text = profile.Player2.Select;
			entry_p2_up.Text = profile.Player2.Up;
			entry_p2_left.Text = profile.Player2.Left;
			entry_p2_right.Text = profile.Player2.Right;
			entry_p2_down.Text = profile.Player2.Down;
			// player 3
			entry_p3_a.Text = profile.Player3.A;
			entry_p3_b.Text = profile.Player3.B;
			entry_p3_start.Text = profile.Player3.Start;
			entry_p3_select.Text = profile.Player3.Select;
			entry_p3_up.Text = profile.Player3.Up;
			entry_p3_left.Text = profile.Player3.Left;
			entry_p3_right.Text = profile.Player3.Right;
			entry_p3_down.Text = profile.Player3.Down;
			// player 4
			entry_p4_a.Text = profile.Player4.A;
			entry_p4_b.Text = profile.Player4.B;
			entry_p4_start.Text = profile.Player4.Start;
			entry_p4_select.Text = profile.Player4.Select;
			entry_p4_up.Text = profile.Player4.Up;
			entry_p4_left.Text = profile.Player4.Left;
			entry_p4_right.Text = profile.Player4.Right;
			entry_p4_down.Text = profile.Player4.Down;
			// vs
			entry_vs_CreditServiceButton.Text = profile.VSunisystemDIP.CreditServiceButton;
			entry_vs_CreditLeftCoinSlot.Text = profile.VSunisystemDIP.CreditLeftCoinSlot;
			entry_vs_CreditRightCoinSlot.Text = profile.VSunisystemDIP.CreditRightCoinSlot;
			entry_vs_switch1.Text = profile.VSunisystemDIP.DIPSwitch1;
			entry_vs_switch2.Text = profile.VSunisystemDIP.DIPSwitch2;
			entry_vs_switch3.Text = profile.VSunisystemDIP.DIPSwitch3;
			entry_vs_switch4.Text = profile.VSunisystemDIP.DIPSwitch4;
			entry_vs_switch5.Text = profile.VSunisystemDIP.DIPSwitch5;
			entry_vs_switch6.Text = profile.VSunisystemDIP.DIPSwitch6;
			entry_vs_switch7.Text = profile.VSunisystemDIP.DIPSwitch7;
			entry_vs_switch8.Text = profile.VSunisystemDIP.DIPSwitch8;
			// shortcuts
			entry_sh_saveState.Text = profile.Shortcuts.SaveState;
			entry_loadState.Text = profile.Shortcuts.LoadState;
			entry_hardReset.Text = profile.Shortcuts.HardReset;
			entry_softReset.Text = profile.Shortcuts.SoftReset;
			entry_shutdownEmu.Text = profile.Shortcuts.ShutdownEmulation;
			entry_takeSnap.Text = profile.Shortcuts.TakeSnapshot;
			entry_toggleLimitter.Text = profile.Shortcuts.ToggleLimiter;
			entry_pauseEmu.Text = profile.Shortcuts.PauseEmulation;
			entry_resumeEmu.Text = profile.Shortcuts.ResumeEmulation;
			entry_fullscreen.Text = profile.Shortcuts.Fullscreen;
			entry_slot.Text = profile.Shortcuts.SelecteSlot0;
			entry_slot1.Text = profile.Shortcuts.SelecteSlot1;
			entry_slot2.Text = profile.Shortcuts.SelecteSlot2;
			entry_slot3.Text = profile.Shortcuts.SelecteSlot3;
			entry_slot4.Text = profile.Shortcuts.SelecteSlot4;
			entry_slot5.Text = profile.Shortcuts.SelecteSlot5;
			entry_slot6.Text = profile.Shortcuts.SelecteSlot6;
			entry_slot7.Text = profile.Shortcuts.SelecteSlot7;
			entry_slot8.Text = profile.Shortcuts.SelecteSlot8;
			entry_slot9.Text = profile.Shortcuts.SelecteSlot9;
		}

		public void SaveSettings ()
		{
			ApplySettings ();
			RenderersCore.SettingsManager.SaveSettings ();
		}

		private void ApplySettings ()
		{
			ControlProfile profile =
				RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection
					[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex];
			// options
			profile.Connect4Players = checkbutton_4players.Active;
			profile.ConnectZapper = checkbutton_zapper.Active;
			// player 1
			profile.Player1.A = entry_p1_a.Text;
			profile.Player1.B = entry_p1_b.Text;
			profile.Player1.Start = entry_p1_start.Text;
			profile.Player1.Select = entry_p1_select.Text;
			profile.Player1.Up = entry_p1_up.Text;
			profile.Player1.Left = entry_p1_left.Text;
			profile.Player1.Right = entry_p1_right.Text;
			profile.Player1.Down = entry_p1_down.Text;
			// player 2
			profile.Player2.A = entry_p2_a.Text;
			profile.Player2.B = entry_p2_b.Text;
			profile.Player2.Start = entry_p2_start.Text;
			profile.Player2.Select = entry_p2_select.Text;
			profile.Player2.Up = entry_p2_up.Text;
			profile.Player2.Left = entry_p2_left.Text;
			profile.Player2.Right = entry_p2_right.Text;
			profile.Player2.Down = entry_p2_down.Text;
			// player 3
			profile.Player3.A = entry_p3_a.Text;
			profile.Player3.B = entry_p3_b.Text;
			profile.Player3.Start = entry_p3_start.Text;
			profile.Player3.Select = entry_p3_select.Text;
			profile.Player3.Up = entry_p3_up.Text;
			profile.Player3.Left = entry_p3_left.Text;
			profile.Player3.Right = entry_p3_right.Text;
			profile.Player3.Down = entry_p3_down.Text;
			// player 4
			profile.Player4.A = entry_p4_a.Text;
			profile.Player4.B = entry_p4_b.Text;
			profile.Player4.Start = entry_p4_start.Text;
			profile.Player4.Select = entry_p4_select.Text;
			profile.Player4.Up = entry_p4_up.Text;
			profile.Player4.Left = entry_p4_left.Text;
			profile.Player4.Right = entry_p4_right.Text;
			profile.Player4.Down = entry_p4_down.Text;
			// vs
			profile.VSunisystemDIP.CreditServiceButton = entry_vs_CreditServiceButton.Text;
			profile.VSunisystemDIP.CreditLeftCoinSlot = entry_vs_CreditLeftCoinSlot.Text;
			profile.VSunisystemDIP.CreditRightCoinSlot = entry_vs_CreditRightCoinSlot.Text;
			profile.VSunisystemDIP.DIPSwitch1 = entry_vs_switch1.Text;
			profile.VSunisystemDIP.DIPSwitch2 = entry_vs_switch2.Text;
			profile.VSunisystemDIP.DIPSwitch3 = entry_vs_switch3.Text;
			profile.VSunisystemDIP.DIPSwitch4 = entry_vs_switch4.Text;
			profile.VSunisystemDIP.DIPSwitch5 = entry_vs_switch5.Text;
			profile.VSunisystemDIP.DIPSwitch6 = entry_vs_switch6.Text;
			profile.VSunisystemDIP.DIPSwitch7 = entry_vs_switch7.Text;
			profile.VSunisystemDIP.DIPSwitch8 = entry_vs_switch8.Text;
			// shortcuts
			profile.Shortcuts.SaveState = entry_sh_saveState.Text;
			profile.Shortcuts.LoadState = entry_loadState.Text;
			profile.Shortcuts.HardReset = entry_hardReset.Text;
			profile.Shortcuts.SoftReset = entry_softReset.Text;
			profile.Shortcuts.ShutdownEmulation = entry_shutdownEmu.Text;
			profile.Shortcuts.TakeSnapshot = entry_takeSnap.Text;
			profile.Shortcuts.ToggleLimiter = entry_toggleLimitter.Text;
			profile.Shortcuts.PauseEmulation = entry_pauseEmu.Text;
			profile.Shortcuts.ResumeEmulation = entry_resumeEmu.Text;
			profile.Shortcuts.Fullscreen = entry_fullscreen.Text;
			profile.Shortcuts.SelecteSlot0 = entry_slot.Text;
			profile.Shortcuts.SelecteSlot1 = entry_slot1.Text;
			profile.Shortcuts.SelecteSlot2 = entry_slot2.Text;
			profile.Shortcuts.SelecteSlot3 = entry_slot3.Text;
			profile.Shortcuts.SelecteSlot4 = entry_slot4.Text;
			profile.Shortcuts.SelecteSlot5 = entry_slot5.Text;
			profile.Shortcuts.SelecteSlot6 = entry_slot6.Text;
			profile.Shortcuts.SelecteSlot7 = entry_slot7.Text;
			profile.Shortcuts.SelecteSlot8 = entry_slot8.Text;
			profile.Shortcuts.SelecteSlot9 = entry_slot9.Text;
		}

		protected void OnComboboxProfilesChanged (object sender, EventArgs e)
		{
			try {
				RenderersCore.SettingsManager.Settings.Controls_ProfileIndex = combobox_profiles.Active;
				this.Title = "Input settings [profile= " + RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection
				[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Name + "]";
				LoadSettings ();
			} catch {
			}
		}

		protected void OnEntry1KeyReleaseEvent (object o, Gtk.KeyReleaseEventArgs args)
		{
			string old = ((Gtk.Entry)o).Text;
			if (RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection
			    [RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Name == "<Default>") {
				((Gtk.Entry)o).Text = old;
				Gtk.MessageDialog dialog = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
				                                                  Gtk.MessageType.Info,
				                                                  Gtk.ButtonsType.Ok, "You can't edit the Default profile. To edit, please create new profile, go to Profiles page.");

				dialog.Run ();
				dialog.Destroy ();
				return;
			}
			// Do some fixes
			string inputText = args.Event.Key.ToString ();
			inputText = inputText.Replace ("Up", "UpArrow");
			inputText = inputText.Replace ("Down", "DownArrow");
			inputText = inputText.Replace ("Left", "LeftArrow");
			inputText = inputText.Replace ("Right", "RightArrow");
			inputText = inputText.Replace ("KP_", "NumberPad");
			inputText = inputText.Replace ("Key_", "D");

			((Gtk.Entry)o).Text = "Keyboard." + inputText;
			ApplySettings ();
		}
		// add profile
		protected void OnButton12Clicked (object sender, EventArgs e)
		{
			Dialog_AddProfile dialog = new Dialog_AddProfile ();
			dialog.Modal = true;
			if (dialog.Run () == (int)ResponseType.Ok) {
				if (dialog.EnteredName == "") {
					Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
					                                               Gtk.MessageType.Info,
					                                               Gtk.ButtonsType.Ok,
					                                               "The profile name can't be empty.");
					
					msg.Run ();
					msg.Destroy ();
					return;
				}
				foreach (ControlProfile prf in RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection) {
					if (prf.Name.ToLower () == dialog.EnteredName.ToLower ()) {
						Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
						                                               Gtk.MessageType.Info,
						                                               Gtk.ButtonsType.Ok,
						                                               "The profile name already taken");
						
						msg.Run ();
						msg.Destroy ();
						return;
					}
				}
				// let's do it
				ControlProfile newProfile = new ControlProfile ();
				newProfile.Name = dialog.EnteredName;
				ControlProfile copyFrom = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection
					[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex];
				// options
				newProfile.Connect4Players = copyFrom.Connect4Players;
				newProfile.ConnectZapper = copyFrom.ConnectZapper;
				// player 1
				newProfile.Player1.A = copyFrom.Player1.A;
				newProfile.Player1.B = copyFrom.Player1.B;
				newProfile.Player1.Down = copyFrom.Player1.Down;
				newProfile.Player1.Left = copyFrom.Player1.Left;
				newProfile.Player1.Right = copyFrom.Player1.Right;
				newProfile.Player1.Select = copyFrom.Player1.Select;
				newProfile.Player1.Start = copyFrom.Player1.Start;
				newProfile.Player1.TurboA = copyFrom.Player1.TurboA;
				newProfile.Player1.TurboB = copyFrom.Player1.TurboB;
				// player 2
				newProfile.Player2.A = copyFrom.Player2.A;
				newProfile.Player2.B = copyFrom.Player2.B;
				newProfile.Player2.Down = copyFrom.Player2.Down;
				newProfile.Player2.Left = copyFrom.Player2.Left;
				newProfile.Player2.Right = copyFrom.Player2.Right;
				newProfile.Player2.Select = copyFrom.Player2.Select;
				newProfile.Player2.Start = copyFrom.Player2.Start;
				newProfile.Player2.TurboA = copyFrom.Player2.TurboA;
				newProfile.Player2.TurboB = copyFrom.Player2.TurboB;
				// player 3
				newProfile.Player3.A = copyFrom.Player3.A;
				newProfile.Player3.B = copyFrom.Player3.B;
				newProfile.Player3.Down = copyFrom.Player3.Down;
				newProfile.Player3.Left = copyFrom.Player3.Left;
				newProfile.Player3.Right = copyFrom.Player3.Right;
				newProfile.Player3.Select = copyFrom.Player3.Select;
				newProfile.Player3.Start = copyFrom.Player3.Start;
				newProfile.Player3.TurboA = copyFrom.Player3.TurboA;
				newProfile.Player3.TurboB = copyFrom.Player3.TurboB;
				// player 4
				newProfile.Player4.A = copyFrom.Player4.A;
				newProfile.Player4.B = copyFrom.Player4.B;
				newProfile.Player4.Down = copyFrom.Player4.Down;
				newProfile.Player4.Left = copyFrom.Player4.Left;
				newProfile.Player4.Right = copyFrom.Player4.Right;
				newProfile.Player4.Select = copyFrom.Player4.Select;
				newProfile.Player4.Start = copyFrom.Player4.Start;
				newProfile.Player4.TurboA = copyFrom.Player4.TurboA;
				newProfile.Player4.TurboB = copyFrom.Player4.TurboB;
				// vs unisystem
				newProfile.VSunisystemDIP.CreditLeftCoinSlot = copyFrom.VSunisystemDIP.CreditLeftCoinSlot;
				newProfile.VSunisystemDIP.CreditRightCoinSlot = copyFrom.VSunisystemDIP.CreditRightCoinSlot;
				newProfile.VSunisystemDIP.CreditServiceButton = copyFrom.VSunisystemDIP.CreditServiceButton;
				newProfile.VSunisystemDIP.DIPSwitch1 = copyFrom.VSunisystemDIP.DIPSwitch1;
				newProfile.VSunisystemDIP.DIPSwitch2 = copyFrom.VSunisystemDIP.DIPSwitch2;
				newProfile.VSunisystemDIP.DIPSwitch3 = copyFrom.VSunisystemDIP.DIPSwitch3;
				newProfile.VSunisystemDIP.DIPSwitch4 = copyFrom.VSunisystemDIP.DIPSwitch4;
				newProfile.VSunisystemDIP.DIPSwitch5 = copyFrom.VSunisystemDIP.DIPSwitch5;
				newProfile.VSunisystemDIP.DIPSwitch6 = copyFrom.VSunisystemDIP.DIPSwitch6;
				newProfile.VSunisystemDIP.DIPSwitch7 = copyFrom.VSunisystemDIP.DIPSwitch7;
				newProfile.VSunisystemDIP.DIPSwitch8 = copyFrom.VSunisystemDIP.DIPSwitch8;
				// shortcuts
				newProfile.Shortcuts.Fullscreen = copyFrom.Shortcuts.Fullscreen;
				newProfile.Shortcuts.HardReset = copyFrom.Shortcuts.HardReset;
				newProfile.Shortcuts.LoadState = copyFrom.Shortcuts.LoadState;
				newProfile.Shortcuts.PauseEmulation = copyFrom.Shortcuts.PauseEmulation;
				newProfile.Shortcuts.ResumeEmulation = copyFrom.Shortcuts.ResumeEmulation;
				newProfile.Shortcuts.SaveState = copyFrom.Shortcuts.SaveState;
				newProfile.Shortcuts.SelecteSlot0 = copyFrom.Shortcuts.SelecteSlot0;
				newProfile.Shortcuts.SelecteSlot1 = copyFrom.Shortcuts.SelecteSlot1;
				newProfile.Shortcuts.SelecteSlot2 = copyFrom.Shortcuts.SelecteSlot2;
				newProfile.Shortcuts.SelecteSlot3 = copyFrom.Shortcuts.SelecteSlot3;
				newProfile.Shortcuts.SelecteSlot4 = copyFrom.Shortcuts.SelecteSlot4;
				newProfile.Shortcuts.SelecteSlot5 = copyFrom.Shortcuts.SelecteSlot5;
				newProfile.Shortcuts.SelecteSlot6 = copyFrom.Shortcuts.SelecteSlot6;
				newProfile.Shortcuts.SelecteSlot7 = copyFrom.Shortcuts.SelecteSlot7;
				newProfile.Shortcuts.SelecteSlot8 = copyFrom.Shortcuts.SelecteSlot8;
				newProfile.Shortcuts.SelecteSlot9 = copyFrom.Shortcuts.SelecteSlot9;
				newProfile.Shortcuts.ShutdownEmulation = copyFrom.Shortcuts.ShutdownEmulation;
				newProfile.Shortcuts.SoftReset = copyFrom.Shortcuts.SoftReset;
				newProfile.Shortcuts.TakeSnapshot = copyFrom.Shortcuts.TakeSnapshot;
				newProfile.Shortcuts.ToggleLimiter = copyFrom.Shortcuts.ToggleLimiter;
				// now add the profile !
				RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.Add (newProfile);
				// refresh
				RefreshProfiles ();
				// select the last one
				combobox_profiles.Active = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.Count - 1;
				LoadSettings ();
			}
			dialog.Destroy ();
		}
		// remove
		protected void OnButton13Clicked (object sender, EventArgs e)
		{
			if (RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection
			    [RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Name == "<Default>") {
				Gtk.MessageDialog dialog = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
				                                                  Gtk.MessageType.Info,
				                                                  Gtk.ButtonsType.Ok, "You can't delete the Default profile.");
				
				dialog.Run ();
				dialog.Destroy ();
				return;
			}
			Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
			                                               Gtk.MessageType.Question,
			                                               Gtk.ButtonsType.YesNo, "Are you sure ? This can't be undone.");
			
			if (msg.Run () == (int)ResponseType.Yes) {
				RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.RemoveAt (combobox_profiles.Active);
				RenderersCore.SettingsManager.Settings.Controls_ProfileIndex = 0;
				RefreshProfiles ();
				combobox_profiles.Active = 0;
				LoadSettings ();
			}
			msg.Destroy ();
			return;
		}
	}
}

