//
//  Dialog_SoundSettings.cs
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
using MyNes.Renderers;

namespace MyNesGTK
{
	public partial class Dialog_SoundSettings : Gtk.Dialog
	{
		public Dialog_SoundSettings ()
		{
			this.Build ();
			combobox1.AppendText ("44100");
			combobox1.AppendText ("48000");
			// load settings
			checkbutton_soundEnabled.Active = RenderersCore.SettingsManager.Settings.Sound_Enabled;
			hscale_vol.Value = RenderersCore.SettingsManager.Settings.Sound_Volume;
			label_vol.Text = ((((100 * (3000 - hscale_vol.Value)) / 3000) - 200) * -1).ToString ("F0") + " %";
			hscale_delay.Value = RenderersCore.SettingsManager.Settings.Sound_Latency / 10;
			label_delay.Text = RenderersCore.SettingsManager.Settings.Sound_Latency.ToString ("F0") + " ms";
			switch (RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq) {
			case 44100:
				combobox1.Active = 0;
				break;
			case 48000:
				combobox1.Active = 1;
				break;
			}
		}

		public void SaveSettings ()
		{
			RenderersCore.SettingsManager.Settings.Sound_Enabled = checkbutton_soundEnabled.Active;
			RenderersCore.SettingsManager.Settings.Sound_Volume = (int)hscale_vol.Value;
			RenderersCore.SettingsManager.Settings.Sound_Latency = (int)(hscale_delay.Value * 10);
			RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq = int.Parse (combobox1.ActiveText);
			RenderersCore.SettingsManager.SaveSettings ();
		}

		protected void OnHscaleVolValueChanged (object sender, EventArgs e)
		{
			label_vol.Text = ((((100 * (3000 - hscale_vol.Value)) / 3000) - 200) * -1).ToString ("F0") + " %";
		}

		protected void OnHscaleDelayValueChanged (object sender, EventArgs e)
		{
			label_delay.Text = (hscale_delay.Value * 10).ToString ("F0") + " ms";
		}
		// defaults
		protected void OnButton9Clicked (object sender, EventArgs e)
		{
			checkbutton_soundEnabled.Active = true;
			combobox1.Active = 0;
			hscale_vol.Value = 0;
			label_vol.Text = "100 %";
			hscale_delay.Value = 5;
			label_delay.Text = "50 ms";
		}
	}
}

