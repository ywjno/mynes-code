//
//  Room_GameGenie.cs
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
using MyNes.Core;
using System.IO;
using System.Collections.Generic;
using SdlDotNet.Input;

namespace MyNesSDL
{
    [RoomBaseAttributes("Game Genie")]
    public class Room_GameGenie:RoomBase
    {
        public Room_GameGenie()
            : base()
        {
            gameGenie = new GameGenie();
            Items.Add(new MenuItem_EnableGameGenie());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_AddCode(this));
            Items.Add(new MenuItem_RemoveCode(this));
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_CurrentCodeIndex());
            Items.Add(new MenuItem_TheCode(this));
            Items.Add(new MenuItem_Address());
            Items.Add(new MenuItem_Value());
            Items.Add(new MenuItem_Compare());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_SaveFile(this));
            Items.Add(new MenuItem_LoadFile(this));
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_ApplySettings(this));
            Items.Add(new MenuItem_DiscardSettings());
        }

        private string inputString;
        public bool _gameGenieEnabled;
        public List<GameGenieCode> _gameGenieCodes;
        private GameGenie gameGenie;

        public override void OnOpen()
        {
            if (!NesEmu.EmulationON)
            { 
                Program.SelectRoom("main menu");
                return;
            }
            _gameGenieEnabled = NesEmu.IsGameGenieActive;
            _gameGenieCodes = new List<GameGenieCode>();
            if (NesEmu.GameGenieCodes != null)
            {
                _gameGenieCodes = new List<GameGenieCode>(NesEmu.GameGenieCodes);
            }
            // The enable button
            Items[0].SelectedOptionIndex = NesEmu.IsGameGenieActive ? 1 : 0;
            if (_gameGenieCodes.Count == 0)
            {
                // Make all items N/A
                Items[3].Options.Clear();
                Items[3].Options.Add("N/A");
                Items[3].SelectedOptionIndex = 0;
                Items[4].Options.Clear();
                Items[4].Options.Add("N/A");
                Items[4].SelectedOptionIndex = 0;
                Items[5].Options.Clear();
                Items[5].Options.Add("N/A");
                Items[5].SelectedOptionIndex = 0;
                Items[6].Options.Clear();
                Items[6].Options.Add("N/A");
                Items[6].SelectedOptionIndex = 0;
                Items[7].Options.Clear();
                Items[7].Options.Add("N/A");
                Items[7].SelectedOptionIndex = 0;
            }
            else
            {
                Items[3].Options.Clear();
                Items[4].Options.Clear();
                Items[5].Options.Clear();
                Items[6].Options.Clear();
                Items[7].Options.Clear();
                for (int i = 0; i < _gameGenieCodes.Count; i++)
                {
                    Items[3].Options.Add(i.ToString());
                    Items[4].Options.Add(_gameGenieCodes[i].Name);
                    Items[5].Options.Add(_gameGenieCodes[i].Address.ToString("X4"));
                    Items[6].Options.Add(_gameGenieCodes[i].Value.ToString("X2"));
                    Items[7].Options.Add(_gameGenieCodes[i].Compare.ToString("X2"));
                }
            }
            Items[3].SelectedOptionIndex = 0;
            Items[4].SelectedOptionIndex = 0;
            Items[5].SelectedOptionIndex = 0;
            Items[6].SelectedOptionIndex = 0;
            Items[7].SelectedOptionIndex = 0;
        }

        protected override void OnMenuOptionChanged()
        {
            if (SelectedMenuIndex >= 3 && SelectedMenuIndex <= 7)
            {
                if (Items[SelectedMenuIndex].Options[0] != "N/A")
                {
                    inputString = Items[4].Options[Items[4].SelectedOptionIndex];
                    Items[3].SelectedOptionIndex = Items[SelectedMenuIndex].SelectedOptionIndex;
                    Items[4].SelectedOptionIndex = Items[SelectedMenuIndex].SelectedOptionIndex;
                    Items[5].SelectedOptionIndex = Items[SelectedMenuIndex].SelectedOptionIndex;
                    Items[6].SelectedOptionIndex = Items[SelectedMenuIndex].SelectedOptionIndex;
                    Items[7].SelectedOptionIndex = Items[SelectedMenuIndex].SelectedOptionIndex;
                }
            }
        }

        public void SelectLastCode()
        {
            int last = Items[3].Options.Count - 1;
            if (last >= 0)
            {
                Items[3].SelectedOptionIndex = last;
                Items[4].SelectedOptionIndex = last;
                Items[5].SelectedOptionIndex = last;
                Items[6].SelectedOptionIndex = last;
                Items[7].SelectedOptionIndex = last;
            }
        }

        public override void OnTabResume()
        {
            Program.SelectRoom("main menu");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        public override void DoKeyDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
            base.DoKeyDown(e);
            if (SelectedMenuIndex == 4)
            {
                if (Items[4].Options[Items[4].SelectedOptionIndex] == "N/A")
                    return;
                if (Items[4].SelectedOptionIndex < Items[4].Options.Count)
                    inputString = Items[4].Options[Items[4].SelectedOptionIndex];
                else
                    inputString = "";
                switch (e.Key)
                {
                    case SdlDotNet.Input.Key.A:
                    case SdlDotNet.Input.Key.P:
                    case SdlDotNet.Input.Key.Z:
                    case SdlDotNet.Input.Key.L:
                    case SdlDotNet.Input.Key.G:
                    case SdlDotNet.Input.Key.I:
                    case SdlDotNet.Input.Key.T:
                    case SdlDotNet.Input.Key.Y:
                    case SdlDotNet.Input.Key.E:
                    case SdlDotNet.Input.Key.O:
                    case SdlDotNet.Input.Key.X:
                    case SdlDotNet.Input.Key.U:
                    case SdlDotNet.Input.Key.K:
                    case SdlDotNet.Input.Key.S:
                    case SdlDotNet.Input.Key.V:
                    case SdlDotNet.Input.Key.N:
                        {
                            if (inputString.Length < 8)
                            {
                                inputString += e.Key.ToString();
                            
                                Items[4].Options[Items[4].SelectedOptionIndex] = inputString;
                                UpdateValues(inputString);
                            }
                            break;
                        }
                    case Key.Backspace:
                        {
                            if (inputString.Length > 0)
                            {
                                inputString = inputString.Substring(0, inputString.Length - 1);
                            
                                Items[4].Options[Items[4].SelectedOptionIndex] = inputString;
                                UpdateValues(inputString);
                            }
                            break;
                        }
                }
            }
        }

        private void UpdateValues(string code)
        {
            if (Items[4].Options[Items[4].SelectedOptionIndex] == "N/A")
                return;

            // Update address, value and compare ..
            if (code.Length == 6)
            {
                Items[5].Options[Items[5].SelectedOptionIndex] =
                    string.Format("{0:X4}", gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(code), 6));
                Items[6].Options[Items[6].SelectedOptionIndex] = 
                    string.Format("{0:X2}", gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(code), 6));
                Items[7].Options[Items[7].SelectedOptionIndex] = "00";
            }
            else if (code.Length == 8)//8 code length
            {
                Items[5].Options[Items[5].SelectedOptionIndex] =
                    string.Format("{0:X4}", gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(code), 8));
                Items[6].Options[Items[6].SelectedOptionIndex] = 
                    string.Format("{0:X2}", gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(code), 8));
                Items[7].Options[Items[7].SelectedOptionIndex] =
                    string.Format("{0:X2}", gameGenie.GetGGCompareValue(gameGenie.GetCodeAsHEX(code)));
            }
            else//code incomplete
            {
                Items[5].Options[Items[5].SelectedOptionIndex] =
                    Items[6].Options[Items[6].SelectedOptionIndex] = 
                        Items[7].Options[Items[7].SelectedOptionIndex] = "ERROR";
            }
        }

        [MenuItemAttribute("Apply And Back", false, 0, new string[0], false)]
        class MenuItem_ApplySettings:MenuItem
        {
            public MenuItem_ApplySettings(Room_GameGenie page)
                : base()
            {
                this.page = page;
                gameGenie = new GameGenie();
            }

            private Room_GameGenie page;
            private GameGenie gameGenie;

            public override void Execute()
            {
                // Apply all codes !
                page._gameGenieCodes = new List<GameGenieCode>();
                bool enabled = page.Items[0].SelectedOptionIndex == 1;
                if (page.Items[3].Options[0] != "N/A")
                {
                    for (int i = 0; i < page.Items[3].Options.Count; i++)
                    {
                        if (page.Items[4].Options[0] != "" &&
                            page.Items[5].Options[0] != "ERROR")
                        {
                            GameGenieCode newcode = new GameGenieCode();
                            newcode.Enabled = true; 
                            string code = page.Items[4].Options[0];
                            newcode.Name = code;
                            if (code.Length == 6)
                            {
                                newcode.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(code), 6) | 0x8000;
                                newcode.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(code), 6);
                                newcode.IsCompare = false;
                            }
                            else
                            {
                                newcode.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(code), 8) | 0x8000;
                                newcode.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(code), 8);
                                newcode.Compare = gameGenie.GetGGCompareValue(gameGenie.GetCodeAsHEX(code));
                                newcode.IsCompare = true;
                            }
                            page._gameGenieCodes.Add(newcode);
                        }
                    }
                }

                NesEmu.SetupGameGenie(enabled, page._gameGenieCodes.ToArray());

                Program.SelectRoom("main menu");
            }
        }

        [MenuItemAttribute("Discard And Back", false, 0, new string[0], false)]
        class MenuItem_DiscardSettings:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("main menu");
            }
        }

        [MenuItemAttribute("Enable Game Genie", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_EnableGameGenie:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Add Code", false, 0, new string[0], false)]
        class MenuItem_AddCode:MenuItem
        {
            public MenuItem_AddCode(Room_GameGenie page)
                : base()
            {
                this.page = page;
            }

            private Room_GameGenie page;

            public override void Execute()
            {
                GameGenieCode newcode = new GameGenieCode();
                newcode.Address = 0;
                newcode.Compare = 0;
                newcode.Descreption = "";
                newcode.IsCompare = false;
                newcode.Name = "";
                newcode.Value = 0;
                page._gameGenieCodes.Add(newcode);
                if (page.Items[3].Options[0] == "N/A")
                {
                    page.Items[3].Options.Clear();
                    page.Items[4].Options.Clear();
                    page.Items[5].Options.Clear();
                    page.Items[6].Options.Clear();
                    page.Items[7].Options.Clear();
                }
                int last = page._gameGenieCodes.Count - 1;

                page.Items[3].Options.Add(last.ToString());
                page.Items[4].Options.Add(page._gameGenieCodes[last].Name);
                page.Items[5].Options.Add(page._gameGenieCodes[last].Address.ToString("X4"));
                page.Items[6].Options.Add(page._gameGenieCodes[last].Value.ToString("X2"));
                page.Items[7].Options.Add(page._gameGenieCodes[last].Compare.ToString("X2"));

                page.Items[3].SelectedOptionIndex = last;
                page.Items[4].SelectedOptionIndex = last;
                page.Items[5].SelectedOptionIndex = last;
                page.Items[6].SelectedOptionIndex = last;
                page.Items[7].SelectedOptionIndex = last;
            }
        }

        [MenuItemAttribute("Remove Code", false, 0, new string[0], false)]
        class MenuItem_RemoveCode:MenuItem
        {
            public MenuItem_RemoveCode(Room_GameGenie page)
                : base()
            {
                this.page = page;
            }

            private Room_GameGenie page;

            public override void Execute()
            {
                if (page.Items[3].Options[0] == "N/A")
                    return;

                int index = 0;
                int.TryParse(page.Items[3].Options[page.Items[3].SelectedOptionIndex], out index);
                page._gameGenieCodes.RemoveAt(index);

                page.Items[3].Options.RemoveAt(index);
                page.Items[4].Options.RemoveAt(index);
                page.Items[5].Options.RemoveAt(index);
                page.Items[6].Options.RemoveAt(index);
                page.Items[7].Options.RemoveAt(index);
                // Fix indexes
                for (int i = 0; i < page.Items[3].Options.Count; i++)
                {
                    page.Items[3].Options[i] = i.ToString();
                }
                if (page.Items[3].Options.Count == 0)
                {
                    page.Items[3].Options.Clear();
                    page.Items[3].Options.Add("N/A");
                    page.Items[3].SelectedOptionIndex = 0;
                    page.Items[4].Options.Clear();
                    page.Items[4].Options.Add("N/A");
                    page.Items[4].SelectedOptionIndex = 0;
                    page.Items[5].Options.Clear();
                    page.Items[5].Options.Add("N/A");
                    page.Items[5].SelectedOptionIndex = 0;
                    page.Items[6].Options.Clear();
                    page.Items[6].Options.Add("N/A");
                    page.Items[6].SelectedOptionIndex = 0;
                    page.Items[7].Options.Clear();
                    page.Items[7].Options.Add("N/A");
                    page.Items[7].SelectedOptionIndex = 0;
                }
                page.SelectLastCode();
            }
        }

        [MenuItemAttribute("Current Code Index", true, 0, new string[0], false)]
        class MenuItem_CurrentCodeIndex:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("The Code", true, 0, new string[0], false)]
        class MenuItem_TheCode:MenuItem
        {
            public MenuItem_TheCode(Room_GameGenie page)
                : base()
            {
                this.page = page;
            }

            private Room_GameGenie page;

            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Address", true, 0, new string[0], false)]
        class MenuItem_Address:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Value", true, 0, new string[0], false)]
        class MenuItem_Value:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Compare", true, 0, new string[0], false)]
        class MenuItem_Compare:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Save File", false, 0, new string[0], false)]
        class MenuItem_SaveFile:MenuItem
        {
            public MenuItem_SaveFile(Room_GameGenie page)
                : base()
            {
                this.page = page;
            }

            private Room_GameGenie page;

            public override void Execute()
            {
                try
                {
                    string filePath = Path.Combine(Settings.Folder_GameGenieCodes,
                                      Path.GetFileNameWithoutExtension(Program.CurrentGameFile) + ".ggc");
                    List<string> lines = new List<string>();
                    if (page.Items[3].Options[0] != "N/A")
                    {
                        for (int i = 0; i < page.Items[3].Options.Count; i++)
                        {
                            if (page.Items[4].Options[0] != "" &&
                            page.Items[5].Options[0] != "ERROR")
                            {
                                lines.Add(page.Items[4].Options[0]);
                            }
                        }
                    }
                    File.WriteAllLines(filePath, lines.ToArray());
                    Program.VIDEO.WriteNotification("Game Genie File Saved !!", 200, System.Drawing.Color.Lime);
                }
                catch
                {
                    Program.VIDEO.WriteNotification("Game Genie file can't be saved !!", 200, System.Drawing.Color.Red);
                }
            }
        }

        [MenuItemAttribute("Load File", false, 0, new string[0], false)]
        class MenuItem_LoadFile:MenuItem
        {
            public MenuItem_LoadFile(Room_GameGenie page)
                : base()
            {
                this.page = page;
                gameGenie = new GameGenie();
            }

            private Room_GameGenie page;
            private GameGenie gameGenie;

            public override void Execute()
            {
                string filePath = Path.Combine(Settings.Folder_GameGenieCodes,
                                      Path.GetFileNameWithoutExtension(Program.CurrentGameFile) + ".ggc");
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    // Clear all
                    if (lines.Length > 0)
                    {
                        page.Items[3].Options.Clear();
                        page.Items[4].Options.Clear();
                        page.Items[5].Options.Clear();
                        page.Items[6].Options.Clear();
                        page.Items[7].Options.Clear();
                        // Add code by code
                        for (int i = 0; i < lines.Length; i++)
                        {
                            GameGenieCode newcode = new GameGenieCode();
                            newcode.Enabled = true; 
                            newcode.Name = lines[i];
                            if (lines[i].Length == 6)
                            {
                                newcode.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(lines[i]), 6);
                                newcode.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(lines[i]), 6);
                                newcode.IsCompare = false;
                            }
                            else
                            {
                                newcode.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(lines[i]), 8);
                                newcode.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(lines[i]), 8);
                                newcode.Compare = gameGenie.GetGGCompareValue(gameGenie.GetCodeAsHEX(lines[i]));
                                newcode.IsCompare = true;
                            }
                            page.Items[3].Options.Add(i.ToString());
                            page.Items[4].Options.Add(lines[i]);
                            page.Items[5].Options.Add(newcode.Address.ToString("X4"));
                            page.Items[6].Options.Add(newcode.Value.ToString("X2"));
                            page.Items[7].Options.Add(newcode.Compare.ToString("X2"));
                        }

                        page.SelectLastCode();

                        Program.VIDEO.WriteNotification("Game Genie File Loaded !!", 200, System.Drawing.Color.Lime);
                    }
                    else
                    {    
                        Program.VIDEO.WriteNotification("Game Genie file is empty.", 200, System.Drawing.Color.Red);
                    }
                }
                else
                {    
                    Program.VIDEO.WriteNotification("Game Genie file is not found.", 200, System.Drawing.Color.Red);
                }
            }
        }
    }
}

