//
//  Dialog_PathsSettings.cs
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
	public partial class Dialog_PathsSettings : Gtk.Dialog
	{
		public Dialog_PathsSettings ()
		{
			this.Build ();
			// load settings
			entry_snapsFolder.Text = RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder;
			entry_stateFolder.Text = RenderersCore.SettingsManager.Settings.Folders_StateFolder;
		}

		public void SaveSettings ()
		{
			RenderersCore.SettingsManager.Settings.Folders_StateFolder = entry_stateFolder.Text;
			RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder = entry_snapsFolder.Text;
			RenderersCore.SettingsManager.SaveSettings ();
		}
		// change state folder
		protected void OnButton13Clicked (object sender, EventArgs e)
		{
			FileChooserDialog dialog = new FileChooserDialog ("Open folder",
			                                                  this, FileChooserAction.SelectFolder,
			                                                  Stock.Cancel, ResponseType.Cancel,
			                                                  Stock.Open, ResponseType.Accept);
			if (dialog.Run () == (int)ResponseType.Accept) {
				entry_stateFolder.Text = dialog.Filename;
			}
			dialog.Destroy ();
		}
		// change snapshots folder
		protected void OnButton14Clicked (object sender, EventArgs e)
		{
			
			FileChooserDialog dialog = new FileChooserDialog ("Open folder",
			                                                  this, FileChooserAction.SelectFolder,
			                                                  Stock.Cancel, ResponseType.Cancel,
			                                                  Stock.Open, ResponseType.Accept);
			if (dialog.Run () == (int)ResponseType.Accept) {
				entry_snapsFolder.Text = dialog.Filename;
			}
			dialog.Destroy ();
		}
		// defaults
		protected void OnButton66Clicked (object sender, EventArgs e)
		{
			entry_stateFolder.Text = System.IO.Path.GetFullPath ("StateSaves");
			entry_snapsFolder.Text = System.IO.Path.GetFullPath ("Snapshots");
		}
	}
}

