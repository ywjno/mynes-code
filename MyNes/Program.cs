/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.IO;
using System.Windows.Forms;
using MyNes.Properties;
using MyNes.Forms;
using MyNes.Core;
using MyNes.Core.Database;

namespace MyNes
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            settings.Reload();
            FixDefaultSettings();

            Nes.StartUp();

            Application.Run(new FormMain(args));
        }

        private static BDatabaseManager bdatabase = new BDatabaseManager();
        private static Properties.Settings settings = new Settings();
        //properties
        public static Settings Settings
        { get { return settings; } }
        public static BDatabaseManager BDatabaseManager
        { get { return bdatabase; } set { bdatabase = value; } }
        //methods
        public static void FixDefaultSettings()
        {
            //fix paths
            if (Program.Settings.StateFolder.Substring(0, 2) == @".\")
                Program.Settings.StateFolder = Path.GetFullPath(Program.Settings.StateFolder);
            if (Program.Settings.SnapshotsFolder.Substring(0, 2) == @".\")
                Program.Settings.SnapshotsFolder = Path.GetFullPath(Program.Settings.SnapshotsFolder);
            if (Program.Settings.FoldersDatabasePath.Substring(0, 2) == @".\")
                Program.Settings.FoldersDatabasePath = Path.GetFullPath(Program.Settings.FoldersDatabasePath);
            Directory.CreateDirectory(Program.Settings.StateFolder);
            Directory.CreateDirectory(Program.Settings.SnapshotsFolder);
            //build default controls profile if nesseccary
            ControlProfile.BuildDefaultProfile();
            //fix palette settings
            if (settings.PaletteSettings == null)
                settings.PaletteSettings = new PaletteSettings();
        }
    }
}