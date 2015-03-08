//
//  Dialog_About.cs
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
using System.Reflection;
using System.IO;

namespace MyNesGTK
{
    public partial class Dialog_About : Gtk.Dialog
    {
        public Dialog_About()
        {
            this.Build();
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            label_gtkVersion.Text = "My Nes GTK Version: " + ver.Major + "." + ver.Minor +
                "." + ver.Build + " Revision " + ver.Revision;

            Assembly asm = Assembly.LoadFile(System.IO.Path.Combine(MainClass.ApplicationFolder, "Core.dll"));

            ver = asm.GetName().Version;

            label_coreVersion.Text = "My Nes Core version: " + ver.Major + "." + ver.Minor + "."
                + ver.Build + " Revision " + ver.Revision;

            asm = Assembly.LoadFile(System.IO.Path.Combine(MainClass.ApplicationFolder, "MyNesSDL.exe"));

            ver = asm.GetName().Version;

            label_sdlVersion.Text = "My Nes SDL version: " + ver.Major + "." + ver.Minor + "."
                + ver.Build + " Revision " + ver.Revision;

            label_name.Markup =
                @"<span weight=""bold"" color=""blue"" size=""xx-large"">MY NES gtk edition</span>";
        }
    }
}

