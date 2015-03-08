//
//  Program.cs
//
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
//
//  Copyright (c) 2015 Ala Ibrahim Hadid
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
using System.IO;
using Gtk;
using MyNes.Core;

namespace MyNesGTK
{
    class MainClass
    {
        public static void Main(string[] args)
        {    
            // Working directory
            WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            WorkingFolder = Path.Combine(WorkingFolder, "MyNes");
            ApplicationFolder = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            Directory.CreateDirectory(WorkingFolder);
            MyNesSDL.Program.WorkingFolder = WorkingFolder;
            // Database
            NesCartDatabase.LoadDatabase(Path.Combine(ApplicationFolder, "database.xml"));
            // Load settings
            MyNesGTK.Settings.LoadSettings();
            // Run GTK !
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
            // Reached here means exist.
            MyNesGTK.Settings.SaveSettings();
        }

        public static string WorkingFolder;
        public static string ApplicationFolder;
    }
}
