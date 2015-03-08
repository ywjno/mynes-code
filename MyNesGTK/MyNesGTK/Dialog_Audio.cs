//
//  Dialog_Audio.cs
//
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
//
//  Copyright (c) 2009 - 2015 Ala Ibrahim Hadid
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

namespace MyNesGTK
{
    public partial class Dialog_Audio : Gtk.Dialog
    {
        public Dialog_Audio()
        {
            this.Build();
            MyNesSDL.Settings.LoadSettings(System.IO.Path.Combine(MainClass.WorkingFolder, "SDLSettings.conf"));
            checkbutton_enablePlayback.Active = MyNesSDL.Settings.Audio_PlaybackEnabled;
            hscale_volume.Value = MyNesSDL.Settings.Audio_PlaybackVolume;
            combobox_fequency.Active = MyNesSDL.Settings.Audio_PlaybackFrequency == 48000 ? 1 : 0;
            checkbutton_sq1.Active = MyNesSDL.Settings.Audio_playback_sq1_enabled;
            checkbutton_sq2.Active = MyNesSDL.Settings.Audio_playback_sq2_enabled;
            checkbutton_trl.Active = MyNesSDL.Settings.Audio_playback_trl_enabled;
            checkbutton_noz.Active = MyNesSDL.Settings.Audio_playback_noz_enabled;
            checkbutton_dmc.Active = MyNesSDL.Settings.Audio_playback_dmc_enabled;
        }

        public void SaveSettings()
        {
            MyNesSDL.Settings.Audio_PlaybackEnabled = checkbutton_enablePlayback.Active;
            MyNesSDL.Settings.Audio_PlaybackVolume = (int)hscale_volume.Value;
            MyNesSDL.Settings.Audio_PlaybackFrequency = combobox_fequency.Active == 1 ? 48000 : 44100;
            MyNesSDL.Settings.Audio_playback_sq1_enabled = checkbutton_sq1.Active;
            MyNesSDL.Settings.Audio_playback_sq2_enabled = checkbutton_sq2.Active;
            MyNesSDL.Settings.Audio_playback_trl_enabled = checkbutton_trl.Active;
            MyNesSDL.Settings.Audio_playback_noz_enabled = checkbutton_noz.Active;
            MyNesSDL.Settings.Audio_playback_dmc_enabled = checkbutton_dmc.Active;
            MyNesSDL.Settings.SaveSettings();
        }

        protected void OnButton162Pressed(object sender, EventArgs e)
        {
            checkbutton_enablePlayback.Active = true;
            hscale_volume.Value = 100;
            combobox_fequency.Active = 0;
            checkbutton_sq1.Active = true;
            checkbutton_sq2.Active = true;
            checkbutton_trl.Active = true;
            checkbutton_noz.Active = true;
            checkbutton_dmc.Active = true;
        }
    }
}

