/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Threading;
using System.Resources;
using System.Reflection;
using MyNes.Core;

namespace MyNes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Enable trace
            bool addTextWritterLogger = false;
            if (Args != null)
                if (Args.Contains("/logger"))
                    addTextWritterLogger = true;
            DefineLoggers(addTextWritterLogger);
            Trace.WriteLine("My Nes launched at " + DateTime.Now.ToLocalTime());
            Trace.WriteLine("--------------------------------");
            if (addTextWritterLogger) Trace.WriteLine("Text Logger enabled !");

            // Create the working folders
            Trace.WriteLine("Creating working folders ...", "My Nes Win GUI");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MyNes\\");
            Directory.CreateDirectory("Logs");
            Trace.WriteLine("Working folders created successfully.", "My Nes Win GUI");

            // Settings
            Trace.WriteLine("Loading settings ...", "My Nes Win GUI");
            settings = new Properties.Settings();
            settings.Reload();

            FixSettings();

            // Language resources
            Trace.WriteLine("Loading user-interface language resources ...", "My Nes Win GUI");
            DetectSupportedLanguages();
            resources = new ResourceManager("MyNes.LanguageResources.Resource", Assembly.GetExecutingAssembly());
            Language = settings.Language;

            // Misc ...
            dbManager = new MyNes.DBManager(settings.FileDB);

            // Nes emulation engine start up
            Trace.WriteLine("Nes emulation engine warm up ...", "My Nes Win GUI");
            NesCore.StartUp();

            // Run main form
            Trace.WriteLine("Running main window.", "My Nes Win GUI");
            mainForm = new FormMain();
            Application.Run(mainForm);
        }

        private static Properties.Settings settings;
        private static string[,] supportedLanguages; // This should filled at startup
        private static ResourceManager resources;
        private static DBManager dbManager;
        private static FormMain mainForm;

        /// <summary>
        /// Get the application settings
        /// </summary>
        public static Properties.Settings Settings
        { get { return settings; } }
        /// <summary>
        /// Get the supported languages.
        /// </summary>
        public static string[,] SupportedLanguages
        { get { return supportedLanguages; } }
        /// <summary>
        /// Get or set the selected language
        /// </summary>
        public static string Language
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.NativeName;
            }
            set
            {
                for (int i = 0; i < SupportedLanguages.Length / 3; i++)
                {
                    if (SupportedLanguages[i, 0] == value)
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(SupportedLanguages[i, 1]);
                        Trace.WriteLine("Language set to: " + supportedLanguages[i, 0], "My Nes Win GUI");
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Get or set current CultureInfo
        /// </summary>
        public static CultureInfo CultureInfo
        { get { return Thread.CurrentThread.CurrentUICulture; } }
        /// <summary>
        /// Get the ResourceManager
        /// </summary>
        public static ResourceManager ResourceManager
        { get { return resources; } }
        /// <summary>
        /// Get the folders database manager object
        /// </summary>
        public static DBManager DBManager
        { get { return dbManager; } }
        /// <summary>
        /// Get the main form
        /// </summary>
        public static FormMain FormMain
        { get { return mainForm; } }

        private static void DefineLoggers(bool AddTextWriter)
        {
            //Trace.AutoFlush = true;
            Trace.Listeners.Clear();
            // Add console listener
            Trace.Listeners.Add(new ConsoleTraceListener());
            // add text writer listener
            if (AddTextWriter)
                Trace.Listeners.Add(new TextWriterTraceListener(".\\Logs\\log.txt"));
        }
        private static void DetectSupportedLanguages()
        {
            string[] langsFolders = Directory.GetDirectories(Application.StartupPath);
            List<string> ids = new List<string>();
            List<string> englishNames = new List<string>();
            List<string> NativeNames = new List<string>();
            foreach (string folder in langsFolders)
            {
                try
                {
                    CultureInfo inf = new CultureInfo(Path.GetFileName(folder));
                    // no errors lol add the id
                    ids.Add(Path.GetFileName(folder));
                    englishNames.Add(inf.EnglishName);
                    NativeNames.Add(inf.NativeName);
                    Trace.WriteLine("Language pack added: " + inf.EnglishName, "My Nes Win GUI");
                }
                catch
                {
                    Trace.WriteLine("Can't add language pack (" + folder + ")", "My Nes Win GUI");
                }
            }
            if (ids.Count > 0)
            {
                supportedLanguages = new string[ids.Count, 3];
                for (int i = 0; i < ids.Count; i++)
                {
                    supportedLanguages[i, 0] = englishNames[i];
                    supportedLanguages[i, 1] = ids[i];
                    supportedLanguages[i, 2] = NativeNames[i];
                }
            }
        }
        private static void FixSettings()
        {
            Trace.Write("Creating folders ...", "My Nes Win GUI");
            if (settings.FolderSnapshots == "")
                settings.FolderSnapshots = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\Snapshots\\";
            if (settings.FolderSrams == "")
                settings.FolderSrams = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\SramSaves\\";
            if (settings.FolderStates == "")
                settings.FolderStates = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\StateSaves\\";
            if (settings.FileDB == "")
                settings.FileDB = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\FoldersDatabase.fdb";

            Directory.CreateDirectory(Path.GetFullPath(settings.FolderSnapshots));
            Directory.CreateDirectory(Path.GetFullPath(settings.FolderSrams));
            Directory.CreateDirectory(Path.GetFullPath(settings.FolderStates));
            Trace.Write("Folders created successfully.", "My Nes Win GUI");
        }
    }
}
