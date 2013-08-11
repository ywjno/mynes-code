//
//  Dialog_VideoSettings.cs
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
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using MyNes.Renderers;
using SdlDotNet;
using SdlDotNet.Graphics;

namespace MyNesGTK
{
	public partial class Dialog_VideoSettings : Gtk.Dialog
	{
		public Dialog_VideoSettings ()
		{
			this.Build ();
			string[] modes = File.ReadAllLines 
				(System.IO.Path.Combine (RenderersCore.StartupFolder, "modes.txt"));
			// load settings
			checkbutton1.Active = RenderersCore.SettingsManager.Settings.Video_KeepAspectRationOnStretch;
			checkbutton2.Active = RenderersCore.SettingsManager.Settings.Video_Fullscreen;
			checkbutton3.Active = RenderersCore.SettingsManager.Settings.Video_ImmediateMode;
			checkbutton4.Active = RenderersCore.SettingsManager.Settings.Video_HideLines;
			checkbutton5.Active = RenderersCore.SettingsManager.Settings.Video_ShowFPS;
			checkbutton6.Active = RenderersCore.SettingsManager.Settings.Video_ShowNotifications;
			spinbutton1.Value = RenderersCore.SettingsManager.Settings.Video_StretchMultiply;
			// snap formats
			combobox2.AppendText (".jpg");
			combobox2.AppendText (".bmp");
			combobox2.AppendText (".png");
			combobox2.AppendText (".gif");
			switch (RenderersCore.SettingsManager.Settings.Video_SnapshotFormat.ToLower ()) {
			case ".jpg":
				combobox2.Active = 0;
				break;
			case ".bmp":
				combobox2.Active = 1;
				break;
			case ".png":
				combobox2.Active = 2;
				break;
			case ".gif":
				combobox2.Active = 3;
				break;
			}
			// resolutions
			foreach (string mode in modes) {
				combobox1.AppendText (mode);
			}
			combobox1.Active = RenderersCore.SettingsManager.Settings.Video_ResIndex;
		}

		public void SaveSettings ()
		{
			// save
			RenderersCore.SettingsManager.Settings.Video_ResIndex = combobox1.Active;
			RenderersCore.SettingsManager.Settings.Video_KeepAspectRationOnStretch = checkbutton1.Active;
			RenderersCore.SettingsManager.Settings.Video_Fullscreen = checkbutton2.Active;
			RenderersCore.SettingsManager.Settings.Video_ImmediateMode = checkbutton3.Active;
			RenderersCore.SettingsManager.Settings.Video_HideLines = checkbutton4.Active;
			RenderersCore.SettingsManager.Settings.Video_ShowFPS = checkbutton5.Active;
			RenderersCore.SettingsManager.Settings.Video_ShowNotifications = checkbutton6.Active;
			RenderersCore.SettingsManager.Settings.Video_StretchMultiply = (int)spinbutton1.Value;
			RenderersCore.SettingsManager.Settings.Video_SnapshotFormat = combobox2.ActiveText;
			RenderersCore.SettingsManager.SaveSettings ();
		}
		// defaults
		protected void OnButton14Clicked (object sender, EventArgs e)
		{
			combobox1.Active = 0;
			checkbutton1.Active = true;
			checkbutton2.Active = false;
			checkbutton3.Active = true;
			checkbutton4.Active = false;
			checkbutton5.Active = false;
			checkbutton6.Active = true;
			spinbutton1.Value = 2;
			combobox2.Active = 2;
		}
	}
}

