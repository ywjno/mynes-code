//
//  Dialog_GameGenieConfigure.cs
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
using System.Xml;
using System.Collections.Generic;
using Gtk;
using MyNes.Core;
using MyNes.Core.GameGenie;

namespace MyNesGTK
{
	public partial class Dialog_GameGenieConfigure : Gtk.Dialog
	{
		public Dialog_GameGenieConfigure ()
		{
			this.Build ();
			gameGenie = new GameGenie ();
			checkbutton1.Active = Nes.Board.IsGameGenieActive;
			// refresh list
			codes = new Dictionary<string,string > ();
			if (Nes.Board.GameGenieCodes != null) {
				foreach (GameGenieCode code in Nes.Board.GameGenieCodes) {
					codes.Add (code.Name, code.Descreption);
					combobox1.AppendText (code.Name + ": " + code.Descreption);
				}
			}
			combobox1.Active = 0;
		}

		public void SaveSettings ()
		{
			if (codes.Count == 0) {
				Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
				                                             Gtk.MessageType.Info,
				                                             Gtk.ButtonsType.Ok, "There is no code in the list to apply !");
				
				msg.Run ();
				msg.Destroy ();
				return;
			}
			Nes.Board.IsGameGenieActive = checkbutton1.Active;
			List<GameGenieCode> Tcodes = new List<GameGenieCode> ();
			gameGenie = new GameGenie ();
			foreach (string item in codes.Keys) {
				GameGenieCode code = new GameGenieCode ();
				code.Enabled = true;
				code.Name = item;
				code.Descreption = codes [item];
				if (item.Length == 6) {
					code.Address = gameGenie.GetGGAddress (gameGenie.GetCodeAsHEX (item), 6) | 0x8000;
					code.Value = gameGenie.GetGGValue (gameGenie.GetCodeAsHEX (item), 6);
					code.IsCompare = false;
				} else {
					code.Address = gameGenie.GetGGAddress (gameGenie.GetCodeAsHEX (item), 8) | 0x8000;
					code.Value = gameGenie.GetGGValue (gameGenie.GetCodeAsHEX (item), 8);
					code.Compare = gameGenie.GetGGCompareValue (gameGenie.GetCodeAsHEX (item));
					code.IsCompare = true;
				}
				//add to active list
				Tcodes.Add (code);
			}
			Nes.Board.GameGenieCodes = Tcodes.ToArray ();
		}

		void ShowValues ()
		{
			if (entry_code.Text.Length == 6) {
				entry_address.Text = string.Format ("{0:X4}", gameGenie.GetGGAddress (gameGenie.GetCodeAsHEX (entry_code.Text), 6));
				entry_value.Text = string.Format ("{0:X2}", gameGenie.GetGGValue (gameGenie.GetCodeAsHEX (entry_code.Text), 6));
				entry_coompare.Text = "00";
			} else if (entry_code.Text.Length == 8) {//8 code length
				entry_address.Text = string.Format ("{0:X4}", gameGenie.GetGGAddress (gameGenie.GetCodeAsHEX (entry_code.Text), 8));
				entry_value.Text = string.Format ("{0:X2}", gameGenie.GetGGValue (gameGenie.GetCodeAsHEX (entry_code.Text), 8));
				entry_coompare.Text = string.Format ("{0:X2}", gameGenie.GetGGCompareValue (gameGenie.GetCodeAsHEX (entry_code.Text)));
			} else {//code incomplete
				entry_address.Text = "ERROR";
				entry_value.Text = entry_coompare.Text = "ERROR";
			}
		}

		GameGenie gameGenie;
		Dictionary<string,string> codes = new Dictionary<string,string > ();

		protected void OnButton112Clicked (object sender, EventArgs e)
		{
			if (entry_code.Text.Length < 8)
				entry_code.Text += ((Gtk.Button)sender).Label;
			ShowValues ();
		}

		protected void OnButton128Clicked (object sender, EventArgs e)
		{
			if (entry_code.Text.Length > 0)
				entry_code.Text = entry_code.Text.Substring (0, entry_code.Text.Length - 1);
		}

		protected void OnButton129Clicked (object sender, EventArgs e)
		{
			entry_code.Text = "";
		}

		protected void OnEntryCodeKeyReleaseEvent (object o, Gtk.KeyReleaseEventArgs args)
		{
			entry_code.Text = entry_code.Text.ToUpper ();
			entry_code.Text.Replace (" ", "A");
			entry_code.Text.Replace ("B", "A");
			entry_code.Text.Replace ("C", "A");
			entry_code.Text.Replace ("D", "A");
			entry_code.Text.Replace ("F", "A");
			entry_code.Text.Replace ("H", "A");
			entry_code.Text.Replace ("J", "A");
			entry_code.Text.Replace ("M", "A");
			entry_code.Text.Replace ("Q", "A");
			entry_code.Text.Replace ("R", "A");
			entry_code.Text.Replace ("W", "A");
			entry_code.Text.Replace ("Z", "A");
			if (entry_code.Text.Length > 8)
				entry_code.Text = entry_code.Text.Substring (0, 8);
			ShowValues ();
		}
		// add
		protected void OnButton130Clicked (object sender, EventArgs e)
		{
			if (entry_code.Text.Length != 6 && entry_code.Text.Length != 8) {
				Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
				                                             Gtk.MessageType.Info,
				                                             Gtk.ButtonsType.Ok, "Invailed code !");
				
				msg.Run ();
				msg.Destroy ();
				return;
			}
			if (entry_code.Text.Contains (" ")) {
				Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
				                                             Gtk.MessageType.Info,
				                                             Gtk.ButtonsType.Ok, "Invailed code !");
				
				msg.Run ();
				msg.Destroy ();
				return;
			}
			if (codes.ContainsKey (entry_code.Text)) {
				Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
				                                             Gtk.MessageType.Info,
				                                             Gtk.ButtonsType.Ok, "Code already exists !");
				
				msg.Run ();
				msg.Destroy ();
				return;
			}
			//((ListStore)combobox1.Model).
			Dialog_AddGameGenieCode dialog = new Dialog_AddGameGenieCode ();
			dialog.Modal = true;
			if (dialog.Run () == (int)ResponseType.Ok) {
				codes.Add (entry_code.Text, dialog.EnteredComment);
				combobox1.AppendText (entry_code.Text + ": " + dialog.EnteredComment);
				combobox1.Active = 0;
			}
			dialog.Destroy ();
		}
		// remove
		protected void OnButton131Clicked (object sender, EventArgs e)
		{
			if (combobox1.Active >= 0) {
				string key = combobox1.ActiveText.Split (new char[] { ' ' }) [0];
				codes.Remove (key);
				combobox1.RemoveText (combobox1.Active);
				try {
					combobox1.Active = 0;
				} catch {
				}
			}
		}
		// load
		protected void OnButton132Clicked (object sender, EventArgs e)
		{
			FileChooserDialog openD = new FileChooserDialog ("Open My Nes Game Genie codes list file",
			                                              this, FileChooserAction.Open,
			                                              Stock.Cancel, ResponseType.Cancel,
			                                              Stock.Open, ResponseType.Accept);
			FileFilter filter = new FileFilter ();
			filter.Name = "XML (*.xml)";
			filter.AddMimeType ("xml");
			filter.AddPattern ("*.xml");
			openD.AddFilter (filter);
			if (openD.Run () == (int)ResponseType.Accept) {
				XmlReaderSettings sett = new XmlReaderSettings ();
				sett.DtdProcessing = DtdProcessing.Ignore;
				sett.IgnoreWhitespace = true;
				XmlReader XMLread = XmlReader.Create (openD.Filename, sett);
				XMLread.Read ();//Reads the XML definition <XML>
				XMLread.Read ();//Reads the header
				if (XMLread.Name != "MyNesGameGenieCodesList") {
					Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
					                                             Gtk.MessageType.Info,
					                                             Gtk.ButtonsType.Ok, "This file is not My Nes Game Genie codes list file");
					
					msg.Run ();
					msg.Destroy ();
					XMLread.Close ();
					return;
				}
				ListStore ClearList = new ListStore (typeof(string), typeof(string));
				combobox1.Model = ClearList;
				codes = new Dictionary<string,string > ();
				while (XMLread.Read()) {
					if (XMLread.Name == "Code") {
						string code = "";
						string comment = "";
						XMLread.MoveToAttribute ("code");
						code = XMLread.Value.ToString ();
						XMLread.MoveToAttribute ("comment");
						comment = XMLread.Value.ToString ();

						codes.Add (code, comment);
						combobox1.AppendText (code + ": " + comment);
					}
				}
				XMLread.Close ();
				try {
					combobox1.Active = 0;
				} catch {
				}
			}
			openD.Destroy ();
		}
		// save
		protected void OnButton133Clicked (object sender, EventArgs e)
		{
			if (codes.Count == 0) {
				Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.DestroyWithParent,
				                                             Gtk.MessageType.Info,
				                                             Gtk.ButtonsType.Ok, "There is no code in the list to save !");
				
				msg.Run ();
				msg.Destroy ();
				return;
			}
			FileChooserDialog save = new FileChooserDialog ("Save My Nes Game Genie codes list file",
			                                             this, FileChooserAction.Save,
			                                             Stock.Cancel, ResponseType.Cancel,
			                                             Stock.Save, ResponseType.Accept);
			FileFilter filter = new FileFilter ();
			filter.Name = "XML (*.xml)";
			filter.AddMimeType ("xml");
			filter.AddPattern ("*.xml");
			save.AddFilter (filter);
			if (save.Run () == (int)ResponseType.Accept) {
				XmlWriterSettings sett = new XmlWriterSettings ();
				sett.Indent = true;
				XmlWriter XMLwrt = XmlWriter.Create (save.Filename, sett);
				XMLwrt.WriteStartElement ("MyNesGameGenieCodesList");//header
				foreach (string item in codes.Keys) {
					XMLwrt.WriteStartElement ("Code");
					XMLwrt.WriteAttributeString ("code", item);
					XMLwrt.WriteAttributeString ("comment", codes [item]);
					XMLwrt.WriteEndElement ();//Code end
				}
				XMLwrt.WriteEndElement ();//header end
				XMLwrt.Flush ();
				XMLwrt.Close ();
			}
			save.Destroy ();
		}
	}
}

