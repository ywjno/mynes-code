/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
using System.Threading;
using System.Windows.Forms;
using MyNes.Properties;
using MyNes.Forms;
using MyNes.Core;
using MyNes.Core.Database;
using MyNes.Renderers;
namespace MyNes
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //load settings
            settings.Reload();
            RenderersCore.SettingsManager.LoadSettings();
            FixDefaultSettings();
            //find renderers
            RenderersCore.FindRenderers(Application.StartupPath);
            //add default commands
            ConsoleCommands.AddDefaultCommands();
            //if first time run, choose the slimdx renderer for default
            if (!settings.FirstRun)
            {
                settings.FirstRun = true;
                for (int i = 0; i < RenderersCore.AvailableRenderers.Length; i++)
                {
                    if (RenderersCore.AvailableRenderers[i].Name == "SlimDX Direct3D9")
                    {
                        settings.CurrentRendererIndex = i;
                        break;
                    }
                }
                // make the default browser database at user documents folder.
                Program.Settings.FoldersDatabasePath =
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\folders.fl";
                // load default columns
                settings.ColumnsManager = new ColumnsManager();
                settings.ColumnsManager.BuildDefaultCollection();
                settings.Save();
            }
            //launch the core
            Nes.StartUp();
            //start gui
            Application.Run(mainForm = new FormMain(args));
        }

        private static BDatabaseManager bdatabase = new BDatabaseManager();
        private static Properties.Settings settings = new Settings();
        private static FormMain mainForm;
        //properties
        public static Settings Settings
        { get { return settings; } }
        public static BDatabaseManager BDatabaseManager
        { get { return bdatabase; } set { bdatabase = value; } }
        public static FormMain FormMain
        { get { return mainForm; } set { mainForm = value; } }
        //methods
        public static void FixDefaultSettings()
        {
            //fix paths
            if (RenderersCore.SettingsManager.Settings.Folders_StateFolder.Substring(0, 2) == @".\")
                RenderersCore.SettingsManager.Settings.Folders_StateFolder = Path.GetFullPath(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
            if (RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder.Substring(0, 2) == @".\")
                RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder = Path.GetFullPath(RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder);
            if (Program.Settings.FoldersDatabasePath.Substring(0, 2) == @".\")
                Program.Settings.FoldersDatabasePath = Path.GetFullPath(Program.Settings.FoldersDatabasePath);
            Directory.CreateDirectory(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
            Directory.CreateDirectory(RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder);
            //build default controls profile if nesseccary
            ControlProfile.BuildDefaultProfile();
            RenderersCore.SettingsManager.SaveSettings();
            //fix palette settings
            if (RenderersCore.SettingsManager.Settings.Video_Palette == null)
                RenderersCore.SettingsManager.Settings.Video_Palette = new PaletteSettings();
        }
    }
}