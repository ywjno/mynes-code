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
using System.IO;
using System.Reflection;
using MyNes.Core.Database;

namespace MyNes.Core.Debug.DefaultCommands
{
    class RomInfoCommands : ConsoleCommand
    {
        public override string Method
        {
            get { return "rom"; }
        }

        public override string Description
        {
            get { return "Show rom info, use parameters for more options"; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[]{
                   new ConsoleCommandParameter("sha1","Show SHA 1 of the rom"),
                   new ConsoleCommandParameter("flags","Show rom flags (mirroring, is battery backed, is vs system...etc)"),
                   new ConsoleCommandParameter("banks","Show rom banks information"),
                   new ConsoleCommandParameter("all","Show all rom information (this will disable all parameters)"),
                };
            }
        }
        public override void Execute(string parameters)
        {
            if (!NesCore.ON)
            {
                Console.WriteLine("Emulation is OFF, no rom loaded.", DebugCode.Error);
                return;
            }
            Console.WriteLine("Rom name: " + Path.GetFileNameWithoutExtension(NesCore.RomInfo.RomPath));
            FileInfo inf = new FileInfo(NesCore.RomInfo.RomPath);
            long size = inf.Length - 16;
            Console.WriteLine("Rom size: " + ((float)size / 1024).ToString("F3") + "KB");
            if (parameters.Length > 0)
            {
                string[] codes = parameters.Split(new char[] { ' ' });
                for (int i = 0; i < codes.Length; i++)
                {
                    if (codes[i] == "all")
                    {
                        Console.WriteLine("SHA1: " + NesCore.RomInfo.SHA1);
                        Console.WriteLine("PRGs: " + NesCore.RomInfo.PRGcount + " (" + (NesCore.RomInfo.PRGcount * 16) + " KB)");
                        Console.WriteLine("CHRs: " + NesCore.RomInfo.CHRcount + " (" + (NesCore.RomInfo.CHRcount * 8) + " KB)");
                        Console.WriteLine("Mirroring: " + NesCore.RomInfo.Mirroring);
                        Console.WriteLine("Is Battery Backed: " + (NesCore.RomInfo.HasSaveRam ? "Yes" : "No"));
                        Console.WriteLine("Is VsUnisystem: " + (NesCore.RomInfo.VSUnisystem ? "Yes" : "No"));
                        Console.WriteLine("Is Playchoice10: " + (NesCore.RomInfo.IsPlaychoice10 ? "Yes" : "No"));
                        Console.WriteLine("Mapper/Board: " + NesCore.RomInfo.MapperBoard);
                        Console.WriteLine("Rom info from database:");
                        if (NesCore.RomInfo.DatabaseGameInfo.Game_Name != null)
                        {
                            Console.WriteLine("Game info:", DebugCode.Good);
                            FieldInfo[] Fields = typeof(NesDatabaseGameInfo).GetFields(BindingFlags.Public | BindingFlags.Instance);
                            for (int j = 0; j < Fields.Length; j++)
                            {
                                if (Fields[j].FieldType == typeof(System.String))
                                {
                                    string name = Fields[j].Name.Replace("_", " ");
                                    string val = "";
                                    try
                                    {
                                        val = Fields[j].GetValue(NesCore.RomInfo.DatabaseGameInfo).ToString();
                                    }
                                    catch
                                    {

                                    }
                                    Console.WriteLine(name + ": " + val);
                                }
                            }
                            Console.WriteLine("Chips:", DebugCode.Good);
                            if (NesCore.RomInfo.DatabaseGameInfo.chip_type != null)
                            {
                                for (int j = 0; j < NesCore.RomInfo.DatabaseGameInfo.chip_type.Count; j++)
                                {
                                    string name = "Chip " + (j + 1);
                                    string val = NesCore.RomInfo.DatabaseGameInfo.chip_type[j];
                                    Console.WriteLine(name + ": " + val);
                                }
                            }
                            Console.WriteLine("Cartridge:", DebugCode.Good);
                            Fields = typeof(NesDatabaseCartridgeInfo).GetFields(BindingFlags.Public | BindingFlags.Instance);
                            for (int j = 0; j < Fields.Length; j++)
                            {
                                if (Fields[j].FieldType == typeof(System.String))
                                {
                                    string name = Fields[j].Name.Replace("_", " ");
                                    string val = "";
                                    try
                                    {
                                        val = Fields[j].GetValue(NesCore.RomInfo.DatabaseCartInfo).ToString();
                                    }
                                    catch
                                    {

                                    }
                                    Console.WriteLine(name + ": " + val);
                                }
                            }
                            Console.WriteLine("DataBase:", DebugCode.Good);
                            Fields = typeof(NesDatabase).GetFields(BindingFlags.Public | BindingFlags.Static);
                            for (int j = 0; j < Fields.Length; j++)
                            {
                                if (Fields[i].FieldType == typeof(System.String))
                                {
                                    string name = Fields[i].Name.Remove(0, 2);
                                    string val = "";
                                    try
                                    {
                                        val = Fields[j].GetValue(NesCore.RomInfo.DatabaseCartInfo).ToString();
                                    }
                                    catch
                                    {
                                    }
                                    Console.WriteLine(name + ": " + val);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Can't find rom info in database.", DebugCode.Error);
                        }
                        return;
                    }
                    if (codes[i] == "sha1")
                    {
                        Console.WriteLine("SHA1: " + NesCore.RomInfo.SHA1);
                    }
                    else if (codes[i] == "banks")
                    {
                        Console.WriteLine("PRGs: " + NesCore.RomInfo.PRGcount + " (" + (NesCore.RomInfo.PRGcount * 4) + " KB)");
                        Console.WriteLine("CHRs: " + NesCore.RomInfo.CHRcount + " (" + NesCore.RomInfo.CHRcount + " KB)");
                    }
                    else if (codes[i] == "flags")
                    {
                        Console.WriteLine("Mirroring: " + NesCore.RomInfo.Mirroring);
                        Console.WriteLine("Is Battery Backed: " + (NesCore.RomInfo.HasSaveRam ? "Yes" : "No"));
                        Console.WriteLine("Is VsUnisystem: " + (NesCore.RomInfo.VSUnisystem ? "Yes" : "No"));
                        Console.WriteLine("Is Playchoice10: " + (NesCore.RomInfo.IsPlaychoice10 ? "Yes" : "No"));
                        Console.WriteLine("Mapper/Board: " + NesCore.RomInfo.MapperBoard);
                    }
                }
            }
        }
    }
}
