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
            if (!Nes.ON)
            {
                Console.WriteLine("Emulation is OFF, no rom loaded.", DebugCode.Error);
                return;
            }
            Console.WriteLine("Rom name: " + Path.GetFileNameWithoutExtension(Nes.RomInfo.Path));
            FileInfo inf = new FileInfo(Nes.RomInfo.Path);
            Console.WriteLine("Rom size: " + ((float)inf.Length / 1024).ToString("F3") + "KB");
            if (parameters.Length > 0)
            {
                string[] codes = parameters.Split(new char[] { ' ' });
                for (int i = 0; i < codes.Length; i++)
                {
                    if (codes[i] == "all")
                    {
                        Console.WriteLine("SHA1: " + Nes.RomInfo.SHA1);
                        Console.WriteLine("PRGs: " + Nes.RomInfo.PRGcount + " (" + (Nes.RomInfo.PRGcount * 4) + " KB)");
                        Console.WriteLine("CHRs: " + Nes.RomInfo.CHRcount + " (" + Nes.RomInfo.CHRcount + " KB)");
                        Console.WriteLine("Mirroring: " + Nes.RomInfo.Mirroring);
                        Console.WriteLine("Is Battery Backed: " + (Nes.RomInfo.HasSaveRam ? "Yes" : "No"));
                        Console.WriteLine("Is VsUnisystem: " + (Nes.RomInfo.VSUnisystem ? "Yes" : "No"));
                        Console.WriteLine("Is Playchoice10: " + (Nes.RomInfo.PC10 ? "Yes" : "No"));
                        Console.WriteLine("Mapper/Board: " + Nes.RomInfo.MapperBoard);
                        Console.WriteLine("Rom info from database:");
                        if (Nes.RomInfo.DatabaseGameInfo.Game_Name != null)
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
                                        val = Fields[j].GetValue(Nes.RomInfo.DatabaseGameInfo).ToString();
                                    }
                                    catch
                                    {

                                    }
                                    Console.WriteLine(name + ": " + val);
                                }
                            }
                            Console.WriteLine("Chips:", DebugCode.Good);
                            if (Nes.RomInfo.DatabaseGameInfo.chip_type != null)
                            {
                                for (int j = 0; j < Nes.RomInfo.DatabaseGameInfo.chip_type.Count; j++)
                                {
                                    string name = "Chip " + (j + 1);
                                    string val = Nes.RomInfo.DatabaseGameInfo.chip_type[j];
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
                                        val = Fields[j].GetValue(Nes.RomInfo.DatabaseCartInfo).ToString();
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
                                        val = Fields[j].GetValue(Nes.RomInfo.DatabaseCartInfo).ToString();
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
                            Console.WriteLine("Can't find rom info from database.", DebugCode.Error);
                        }
                        return;
                    }
                    if (codes[i] == "sha1")
                    {
                        Console.WriteLine("SHA1: " + Nes.RomInfo.SHA1);
                    }
                    else if (codes[i] == "banks")
                    {
                        Console.WriteLine("PRGs: " + Nes.RomInfo.PRGcount + " (" + (Nes.RomInfo.PRGcount * 4) + " KB)");
                        Console.WriteLine("CHRs: " + Nes.RomInfo.CHRcount + " (" + Nes.RomInfo.CHRcount + " KB)");
                    }
                    else if (codes[i] == "flags")
                    {
                        Console.WriteLine("Mirroring: " + Nes.RomInfo.Mirroring);
                        Console.WriteLine("Is Battery Backed: " + (Nes.RomInfo.HasSaveRam ? "Yes" : "No"));
                        Console.WriteLine("Is VsUnisystem: " + (Nes.RomInfo.VSUnisystem ? "Yes" : "No"));
                        Console.WriteLine("Is Playchoice10: " + (Nes.RomInfo.PC10 ? "Yes" : "No"));
                        Console.WriteLine("Mapper/Board: " + Nes.RomInfo.MapperBoard);
                    }
                }
            }
        }
    }
}
