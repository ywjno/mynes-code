//
//  Dialog_Input.cs
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
using System.Threading;
using Gtk;

namespace MyNesGTK
{
    public partial class Dialog_Input : Gtk.Dialog
    {
        public Dialog_Input()
        {
            this.Build();

            // TODO: input window !!
            LoadPlayer1Settings();
            LoadPlayer2Settings();
            LoadPlayer3Settings();
            LoadPlayer4Settings();
            LoadVSUnisystemSettings();
            LoadShortcutsSettings();
        }

        private Gtk.Entry entrySelected;

        private void LoadPlayer1Settings()
        {

        }

        private void LoadPlayer2Settings()
        {

        }

        private void LoadPlayer3Settings()
        {

        }

        private void LoadPlayer4Settings()
        {

        }

        private void LoadVSUnisystemSettings()
        {

        }

        private void LoadShortcutsSettings()
        {

        }

        public void SaveSettings()
        {

        }

        protected void OnCheckbuttonP1UsejoyToggled(object sender, EventArgs e)
        {
            LoadPlayer1Settings();
        }

        protected void OnEntryP1AFocusInEvent(object o, Gtk.FocusInEventArgs args)
        {
            entrySelected = (Gtk.Entry)o;
        }

        protected void OnButton35Pressed(object sender, EventArgs e)
        {
        }
    }
}

