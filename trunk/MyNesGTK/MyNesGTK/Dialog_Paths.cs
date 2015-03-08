//
//  Dialog_Paths.cs
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
using Gtk;

namespace MyNesGTK
{
    public partial class Dialog_Paths : Gtk.Dialog
    {
        public Dialog_Paths()
        {
            this.Build();
            MyNesSDL.Settings.LoadSettings(System.IO.Path.Combine(MainClass.WorkingFolder, "SDLSettings.conf"));
            entry_state.Text = MyNesSDL.Settings.Folder_STATE;
            entry_sram.Text = MyNesSDL.Settings.Folder_SRAM;
            entry_snaps.Text = MyNesSDL.Settings.Folder_SNAPS;
            entry_sounds.Text = MyNesSDL.Settings.Folder_SoundRecords;
            entry_gg.Text = MyNesSDL.Settings.Folder_GameGenieCodes;
        }

        protected void OnButton185Pressed(object sender, EventArgs e)
        {
            FileChooserDialog dialog = new FileChooserDialog("Change state saves folder",
                                           this, FileChooserAction.SelectFolder,
                                           Stock.Cancel, ResponseType.Cancel,
                                           Stock.Open, ResponseType.Accept);
            if (dialog.Run() == (int)ResponseType.Accept)
            {
                entry_state.Text = dialog.Filename;
            }
            dialog.Destroy();
        }

        protected void OnButton186Pressed(object sender, EventArgs e)
        {
            FileChooserDialog dialog = new FileChooserDialog("Change Save-Ram folder",
                                           this, FileChooserAction.SelectFolder,
                                           Stock.Cancel, ResponseType.Cancel,
                                           Stock.Open, ResponseType.Accept);
            if (dialog.Run() == (int)ResponseType.Accept)
            {
                entry_sram.Text = dialog.Filename;
            }
            dialog.Destroy();
        }

        protected void OnButton187Pressed(object sender, EventArgs e)
        {
            FileChooserDialog dialog = new FileChooserDialog("Change snapshots folder",
                                           this, FileChooserAction.SelectFolder,
                                           Stock.Cancel, ResponseType.Cancel,
                                           Stock.Open, ResponseType.Accept);
            if (dialog.Run() == (int)ResponseType.Accept)
            {
                entry_snaps.Text = dialog.Filename;
            }
            dialog.Destroy();
        }

        protected void OnButton188Pressed(object sender, EventArgs e)
        {
            FileChooserDialog dialog = new FileChooserDialog("Change sound records folder",
                                           this, FileChooserAction.SelectFolder,
                                           Stock.Cancel, ResponseType.Cancel,
                                           Stock.Open, ResponseType.Accept);
            if (dialog.Run() == (int)ResponseType.Accept)
            {
                entry_sounds.Text = dialog.Filename;
            }
            dialog.Destroy();
        }

        protected void OnButton189Pressed(object sender, EventArgs e)
        {
            FileChooserDialog dialog = new FileChooserDialog("Change Game Genie codes folder",
                                           this, FileChooserAction.SelectFolder,
                                           Stock.Cancel, ResponseType.Cancel,
                                           Stock.Open, ResponseType.Accept);
            if (dialog.Run() == (int)ResponseType.Accept)
            {
                entry_gg.Text = dialog.Filename;
            }
            dialog.Destroy();
        }

        public void SaveSettings()
        {
            MyNesSDL.Settings.Folder_STATE = entry_state.Text;
            MyNesSDL.Settings.Folder_SRAM = entry_sram.Text;
            MyNesSDL.Settings.Folder_SNAPS = entry_snaps.Text;
            MyNesSDL.Settings.Folder_SoundRecords = entry_sounds.Text;
            MyNesSDL.Settings.Folder_GameGenieCodes = entry_gg.Text;
            MyNesSDL.Settings.SaveSettings();
        }

        protected void OnButton190Pressed(object sender, EventArgs e)
        {
            entry_state.Text = System.IO.Path.Combine(MainClass.WorkingFolder, "STATE");
            entry_sram.Text = System.IO.Path.Combine(MainClass.WorkingFolder, "SRAM");
            entry_snaps.Text = System.IO.Path.Combine(MainClass.WorkingFolder, "SNAPS");
            entry_sounds.Text = System.IO.Path.Combine(MainClass.WorkingFolder, "SoundRecords");
            entry_gg.Text = System.IO.Path.Combine(MainClass.WorkingFolder, "GameGenieCodes");
        }
    }
}

