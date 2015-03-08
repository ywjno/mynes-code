//
//  Dialog_VideoSettings.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using SdlDotNet.Graphics;

namespace MyNesGTK
{
    public partial class Dialog_VideoSettings : Gtk.Dialog
    {
        public Dialog_VideoSettings()
        {
            this.Build();

            Video.Initialize();
            Size[] modeSizes = Video.ListModes();
            List<string> modes = new List<string>();
            for (int i = 0; i < modeSizes.Length; i++)
            {
                modes.Add(modeSizes[i].Width + " x " + modeSizes[i].Height);
            }
            // resolutions
            foreach (string mode in modes)
            {
                combobox_fullscreenRes.AppendText(mode);
            }
            MyNesSDL.Settings.LoadSettings(System.IO.Path.Combine(MainClass.WorkingFolder, "SDLSettings.conf"));
            // load settings
            checkbutton_autoResizeToFitEmu.Active = MyNesSDL.Settings.Video_AutoResizeToFitEmu;
            checkbutton_startFullScreen.Active = MyNesSDL.Settings.Video_StartInFullscreen;
            checkbutton_keepAspectRatio.Active = MyNesSDL.Settings.Video_KeepAspectRatio;
            checkbutton_hideLines.Active = MyNesSDL.Settings.Video_HideLinesForNTSCAndPAL;
            checkbutton_showNotification.Active = MyNesSDL.Settings.Video_ShowNotification;
            checkbutton_showFPS.Active = MyNesSDL.Settings.Video_ShowFPS;
            spinbutton_stretchMulti.Value = MyNesSDL.Settings.Video_StretchMulti;
            combobox_fullscreenRes.Active = MyNesSDL.Settings.Video_FullScreenModeIndex;
        }

        public void SaveSettings()
        {
            // save
            MyNesSDL.Settings.Video_FullScreenModeIndex = combobox_fullscreenRes.Active;
            MyNesSDL.Settings.Video_AutoResizeToFitEmu = checkbutton_autoResizeToFitEmu.Active;
            MyNesSDL.Settings.Video_StartInFullscreen = checkbutton_startFullScreen.Active;
            MyNesSDL.Settings.Video_KeepAspectRatio = checkbutton_keepAspectRatio.Active;
            MyNesSDL.Settings.Video_HideLinesForNTSCAndPAL = checkbutton_hideLines.Active;
            MyNesSDL.Settings.Video_ShowNotification = checkbutton_showNotification.Active;
            MyNesSDL.Settings.Video_ShowFPS = checkbutton_showFPS.Active;
            MyNesSDL.Settings.Video_StretchMulti = (int)spinbutton_stretchMulti.Value;
            MyNesSDL.Settings.SaveSettings();
        }
        // Defaults
        protected void OnButton107Activated(object sender, EventArgs e)
        {
       
        }

        protected void OnButton107Pressed(object sender, EventArgs e)
        {
            combobox_fullscreenRes.Active = 0;
            checkbutton_autoResizeToFitEmu.Active = true;
            checkbutton_startFullScreen.Active = false;
            checkbutton_keepAspectRatio.Active = false;
            checkbutton_hideLines.Active = true;
            checkbutton_showNotification.Active = true;
            checkbutton_showFPS.Active = false;
            spinbutton_stretchMulti.Value = 2;
        }
    }
}

