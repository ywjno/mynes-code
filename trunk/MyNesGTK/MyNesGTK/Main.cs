//
//  Main.cs
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
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.using System;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Gtk;
using System.Diagnostics;
using MyNes.Core;
using MyNes.Core.Database;
using MyNes.Renderers;

namespace MyNesGTK
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //try
            //{
            Application.Init();
            RenderersCore.Initialize();
            // Trace
            Trace.Listeners.Add(new DefaultTraceListener());
            //Trace.Listeners.Add(new TextWriterTraceListener
            //	                     (Path.Combine(RenderersCore.StartupFolder, "ERROR.txt")));
            if (!File.Exists(Path.Combine(RenderersCore.StartupFolder, "modes.txt")))
            {
                Trace.WriteLine("Listing video mode ...");
                Process.Start(Path.Combine(RenderersCore.StartupFolder, 
                                               "GenerateVideoModes.exe"));
            }
            Trace.WriteLine("Initializing application...");
            // load settings
            Trace.WriteLine("Loading settings ...");
            LoadSettings();
            // load renderers settings
            RenderersCore.SettingsManager.LoadSettings();
            if (RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection.Count == 0)
                ControlProfile.BuildDefaultProfile();
            if (!Directory.Exists(Path.GetFullPath(RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder)))
            {
                Directory.CreateDirectory(Path.GetFullPath(RenderersCore.SettingsManager.Settings.Folders_SnapshotsFolder));
            }
            if (!Directory.Exists(Path.GetFullPath(RenderersCore.SettingsManager.Settings.Folders_StateFolder)))
            {
                Directory.CreateDirectory(Path.GetFullPath(RenderersCore.SettingsManager.Settings.Folders_StateFolder));
            }
            // find renderers
            Trace.WriteLine("Searching for renderers ...");
            RenderersCore.FindRenderers();
            // add default commands for the console
            ConsoleCommands.AddDefaultCommands();
            // launch the core
            Nes.StartUp();

            // launch window
            MainWindow win = new MainWindow();
            win.Show();
            #region Run commandlines
            if (args != null)
            {
                if (args.Length > 0)
                {
                    // First command must be the rom path
                    string romPath = args[0];
                    for (int i=1; i<args.Length; i++)
                    {
                        switch (args[i].ToLower())
                        {
                            case "/fullscreen":
                                {
                                    RenderersCore.SettingsManager.Settings.Video_Fullscreen = true;
                                    break;
                                }
                            case "/sound":
                                {
                                    i++;
                                    if (i < args.Length)
                                        RenderersCore.SettingsManager.Settings.Sound_Enabled = args[i] == "1";
                                    break;
                                }
                            case "/limiter":
                                {
                                    i++;
                                    if (i < args.Length)
                                        Nes.SpeedLimiter.ON = args[i] == "1";
                                    break;
                                }
                            case "/tv":
                                {
                                    i++;
                                    if (i < args.Length)
                                    {
                                        switch (args[i].ToLower())
                                        {
                                            case "auto":
                                                settings.EmulationSystem = MyNes.Core.Types.EmulationSystem.AUTO;
                                                break;
                                            case "ntsc":
                                                settings.EmulationSystem = MyNes.Core.Types.EmulationSystem.NTSC;
                                                break;
                                            case "palb":
                                                settings.EmulationSystem = MyNes.Core.Types.EmulationSystem.PALB;
                                                break;
                                            case "dendy":
                                                settings.EmulationSystem = MyNes.Core.Types.EmulationSystem.DENDY;
                                                break;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                    // Do commandlines, the rom load at last.
                    win.LoadRom(romPath);
                }
            }
            #endregion
            Application.Run();
            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine(ex.Message);
            //    Trace.WriteLine(ex.ToString());
            //    Trace.Flush();
            //}
        }

        private static Settings settings;

        public static void LoadSettings()
        {
            string path = Path.Combine(RenderersCore.DocumentsFolder, "GTKsettings.xml");
            try
            {
                XmlSerializer SER = new XmlSerializer(typeof(Settings));
                Stream STR = new FileStream(path, FileMode.Open, FileAccess.Read);
                settings = (Settings)SER.Deserialize(STR);
                STR.Close();
            }
            catch
            { 
                settings = new Settings();
            }
        }

        public static void SaveSettings()
        {
            string path = Path.Combine(RenderersCore.DocumentsFolder, "GTKsettings.xml");
            XmlSerializer SER = new XmlSerializer(typeof(Settings));
            Stream STR = new FileStream(path, FileMode.Create);
            SER.Serialize(STR, settings);
            STR.Close();
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public static Settings Settings
		{ get { return settings; } }
    }
}
