//
//  Settings.cs
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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MyNesGTK
{
    public class Settings
    {
        static Settings()
        {
            BuildCommands();
            SettingsFilePath = Path.Combine(MainClass.WorkingFolder, "GTKSettings.conf");
        }

        private static string SettingsFilePath;
        public static string LastUsedFile;
        public static int WindowWidth;
        public static int WindowHeight;
        public static int WindowX;
        public static int WindowY;
        public static int PanePosition;
        public static int VPanePosition;
        // Commands base !
        private static Dictionary<string, string> commands;
        private static FieldInfo[] Fields;

        /* !! IMPORTANT !!
         * When you add new settings value, just register it
         * here in this method.
         * Only string, bool, float and int are supported.
         * */
        private static void BuildCommands()
        {
            commands = new Dictionary<string, string>();
            commands.Add("last_opened_file", "LastUsedFile");
            commands.Add("window_width", "WindowWidth");
            commands.Add("window_height", "WindowHeight");
            commands.Add("window_x", "WindowX");
            commands.Add("window_y", "WindowY");
            commands.Add("pane_pos", "PanePosition");
            commands.Add("vpane_pos", "VPanePosition");
        }

        public static void ExecuteCommands(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string command = args[i];
                if (commands.ContainsKey(command))
                {
                    string val = "";
                    i++;
                    if (i < args.Length)
                    {
                        val = args[i];
                        SetField(commands[command], val);
                    }
                }
            }
        }

        public static void ResetDefaults()
        {
            LastUsedFile = "";  
            WindowWidth = 1227;
            WindowHeight = 663;
            WindowX = 10;
            WindowY = 10;
            PanePosition = 761;
            VPanePosition = 310;
        }

        public static void LoadSettings()
        {
            Fields = typeof(Settings).GetFields();
            string[] readLines;
            List<string> lines = new List<string>();
            if (File.Exists(SettingsFilePath))
            {
                readLines = File.ReadAllLines(SettingsFilePath);

                for (int i = 0; i < readLines.Length; i++)
                {
                    string[] codes = readLines[i].Split('=');
                    if (codes != null)
                    {
                        if (codes.Length == 2)
                        {
                            lines.Add(codes[0]);
                            lines.Add(codes[1]);
                        }
                    }
                }
            }
            else
            {
                ResetDefaults();
                return;
            }

            ExecuteCommands(lines.ToArray());
        }

        public static void SaveSettings()
        {
            Fields = typeof(Settings).GetFields();
            List<string> lines = new List<string>();
            foreach (string key in commands.Keys)
            {
                lines.Add(key + "=" + GetFieldValue(commands[key]));
            }
            File.WriteAllLines(SettingsFilePath, lines.ToArray());
        }

        private static void SetField(string fieldName, string val)
        {
            for (int i = 0; i < Fields.Length; i++)
            {
                if (Fields[i].Name == fieldName)
                {
                    if (Fields[i].FieldType == typeof(String))
                    {
                        Fields[i].SetValue(null, val);
                    }
                    else if (Fields[i].FieldType == typeof(Boolean))
                    {
                        Fields[i].SetValue(null, val == "1");
                    }
                    else if (Fields[i].FieldType == typeof(Int32))
                    {
                        int num = 0;
                        if (int.TryParse(val, out num))
                            Fields[i].SetValue(null, num);
                    }
                    else if (Fields[i].FieldType == typeof(Single))
                    {
                        float num = 0;
                        if (float.TryParse(val, out num))
                            Fields[i].SetValue(null, num);
                    }
                    break;
                }
            }
        }

        private static string GetFieldValue(string fieldName)
        {
            for (int i = 0; i < Fields.Length; i++)
            {
                if (Fields[i].Name == fieldName)
                {
                    object val = Fields[i].GetValue(null);
                    if (Fields[i].FieldType == typeof(String))
                    {
                        return val.ToString();
                    }
                    else if (Fields[i].FieldType == typeof(Boolean))
                    {
                        return (bool)val ? "1" : "0";
                    }
                    else if (Fields[i].FieldType == typeof(Int32))
                    {
                        return val.ToString();
                    }
                    else if (Fields[i].FieldType == typeof(Single))
                    {
                        return val.ToString();
                    }
                    break;
                }
            }
            return "";
        }
    }
}

