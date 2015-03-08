//
//  Dialog_Preferences.cs
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
    public partial class Dialog_Preferences : Gtk.Dialog
    {
        public Dialog_Preferences()
        {
            this.Build();
            MyNesSDL.Settings.LoadSettings(System.IO.Path.Combine(MainClass.WorkingFolder, "SDLSettings.conf"));
            switch (MyNesSDL.Settings.TvSystemSetting.ToLower())
            {
                case "auto":
                    combobox_region.Active = 0;
                    break;
                case "ntsc":
                    combobox_region.Active = 1;
                    break;
                case "palb":
                    combobox_region.Active = 2;
                    break;
                case "dendy":
                    combobox_region.Active = 3;
                    break;
            }
            checkbutton_saveSram.Active = MyNesSDL.Settings.SaveSRAMOnShutdown;
            checkbutton_snapReplace.Active = MyNesSDL.Settings.SnapReplace;
            switch (MyNesSDL.Settings.SnapsFormat.ToLower())
            {
                case ".png":
                    combobox2.Active = 0;
                    break;
                case ".jpg":
                    combobox2.Active = 1;
                    break;
                case ".bmp":
                    combobox2.Active = 2;
                    break;
            }
            checkbutton_connectFourPlayers.Active = MyNesSDL.Settings.Key_Connect4Players;
            checkbutton_connectZapper.Active = MyNesSDL.Settings.Key_ConnectZapper;
        }

        public void SaveSettings()
        {
            switch (combobox_region.Active)
            {
                case 0:
                    MyNesSDL.Settings.TvSystemSetting = "auto";
                    break;
                case 1:
                    MyNesSDL.Settings.TvSystemSetting = "ntsc";
                    break;
                case 2:
                    MyNesSDL.Settings.TvSystemSetting = "palb";
                    break;
                case 3:
                    MyNesSDL.Settings.TvSystemSetting = "dendy";
                    break;
            }
            MyNesSDL.Settings.SaveSRAMOnShutdown = checkbutton_saveSram.Active;
            MyNesSDL.Settings.SnapReplace = checkbutton_snapReplace.Active;
            switch (combobox2.Active)
            {
                case 0:
                    MyNesSDL.Settings.SnapsFormat = ".png";
                    break;
                case 1:
                    MyNesSDL.Settings.SnapsFormat = ".jpg";
                    break;
                case 2:
                    MyNesSDL.Settings.SnapsFormat = ".bmp";
                    break;
            }
            MyNesSDL.Settings.Key_Connect4Players = checkbutton_connectFourPlayers.Active;
            MyNesSDL.Settings.Key_ConnectZapper = checkbutton_connectZapper.Active;
        }

        protected void OnButton98Pressed(object sender, EventArgs e)
        {
            combobox_region.Active = 0;
            checkbutton_saveSram.Active = true;
            checkbutton_snapReplace.Active = false;
            combobox2.Active = 0;
            checkbutton_connectFourPlayers.Active = false;
            checkbutton_connectZapper.Active = false;
        }
    }
}

