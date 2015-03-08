//
//  Room_MainMenu.cs
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
using MyNes.Core;

namespace MyNesSDL
{
    [RoomBaseAttributes("Main Menu")]
    class Room_MainMenu:RoomBase
    {
        public Room_MainMenu()
            : base()
        {
            // Build the menu items
            Items.Add(new MenuItem_Resume());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_HardReset());
            Items.Add(new MenuItem_SoftReset());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_SaveState());
            Items.Add(new MenuItem_LoadState());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_TakeSnapshot());
            Items.Add(new MenuItem_RecordSound());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_GameGenie());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_Shutdown());
            Items.Add(new MenuItem_Settings());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_About());
            Items.Add(new MenuItem_Quit());
        }

        [MenuItemAttribute("Resume", false, 0, new string[0], false)]
        class MenuItem_Resume:MenuItem
        {
            public override void Execute()
            {
                Program.PausedShowMenu = false;
                NesEmu.EmulationPaused = false;
            }
        }

        [MenuItemAttribute("Save State", false, 0, new string[0], false)]
        class MenuItem_SaveState:MenuItem
        {
            public override void Execute()
            {
                if (NesEmu.EmulationON)
                {
                    NesEmu.SaveState();
                    Program.PausedShowMenu = false;
                    NesEmu.EmulationPaused = false;
                }
                else
                {
                    Program.VIDEO.WriteNotification("EMULATION IS OFF !!", 120, System.Drawing.Color.Red);
                }
            }
        }

        [MenuItemAttribute("Load State", false, 0, new string[0], false)]
        class MenuItem_LoadState:MenuItem
        {
            public override void Execute()
            {
                if (NesEmu.EmulationON)
                {
                    NesEmu.LoadState();
                    Program.PausedShowMenu = false;
                    NesEmu.EmulationPaused = false;
                }
                else
                {
                    Program.VIDEO.WriteNotification("EMULATION IS OFF !!", 120, System.Drawing.Color.Red);
                }
            }
        }

        [MenuItemAttribute("Hard Reset / Turn On", false, 0, new string[0], false)]
        class MenuItem_HardReset:MenuItem
        {
            public override void Execute()
            {
                if (NesEmu.EmulationON)
                {
                    NesEmu.EMUHardReset();
                }
                else
                {
                    if (Program.CurrentGameFile != "")
                    {
                        if (File.Exists(Program.CurrentGameFile))
                        {
                            Program.LoadRom(Program.CurrentGameFile);
                            Program.VIDEO.WriteNotification("HARD RESET", 120, System.Drawing.Color.Red);
                            NesEmu.EmulationPaused = false;
                            Program.PausedShowMenu = false;
                        }
                        else
                        {
                            Program.VIDEO.WriteNotification("NO GAME LOADED !!", 120, System.Drawing.Color.Red);
                        }
                    }
                    else
                    {
                        Program.VIDEO.WriteNotification("NO GAME LOADED !!", 120, System.Drawing.Color.Red);
                    }
                }
            }
        }

        [MenuItemAttribute("Soft Reset", false, 0, new string[0], false)]
        class MenuItem_SoftReset:MenuItem
        {
            public override void Execute()
            {
                if (NesEmu.EmulationON)
                {
                    NesEmu.EMUSoftReset();
                    Program.PausedShowMenu = false;
                    NesEmu.EmulationPaused = false;
                }
                else
                {
                    Program.VIDEO.WriteNotification("EMULATION IS OFF !!", 120, System.Drawing.Color.Red);
                }
            }
        }

        [MenuItemAttribute("Settings", false, 0, new string[0], false)]
        class MenuItem_Settings:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("settings");
            }
        }

        [MenuItemAttribute("Game Genie", false, 0, new string[0], false)]
        class MenuItem_GameGenie:MenuItem
        {
            public override void Execute()
            {
                if (NesEmu.EmulationON)
                {
                    Program.SelectRoom("game genie");
                }
                else
                {
                    Program.VIDEO.WriteNotification("EMULATION IS OFF !!", 120, System.Drawing.Color.Red);
                }
            }
        }

        [MenuItemAttribute("Quit My Nes SDL", false, 0, new string[0], false)]
        class MenuItem_Quit:MenuItem
        {
            public override void Execute()
            {
                Program.Quit();
            }
        }

        [MenuItemAttribute("Take Snapshot", false, 0, new string[0], false)]
        class MenuItem_TakeSnapshot:MenuItem
        {
            public override void Execute()
            {
                if (NesEmu.EmulationON)
                {
                    NesEmu.TakeSnapshot();
                    Program.PausedShowMenu = false;
                    NesEmu.EmulationPaused = false;
                }
                else
                {
                    Program.VIDEO.WriteNotification("EMULATION IS OFF !!", 120, System.Drawing.Color.Red);
                }
            }
        }

        [MenuItemAttribute("Record Sound", false, 0, new string[0], false)]
        class MenuItem_RecordSound:MenuItem
        {
            public override void Execute()
            {
                if (NesEmu.EmulationON)
                {
                    if (Program.AUDIO.IsRecording)
                        Program.AUDIO.StopRecord();
                    else
                        Program.AUDIO.Record();
                    Program.PausedShowMenu = false;
                    NesEmu.EmulationPaused = false;
                }
                else
                {
                    Program.VIDEO.WriteNotification("EMULATION IS OFF !!", 120, System.Drawing.Color.Red);
                }
            }
        }

        [MenuItemAttribute("About", false, 0, new string[0], false)]
        class MenuItem_About:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("About My Nes SDL");
            }
        }

        [MenuItemAttribute("Shutdown", false, 0, new string[0], false)]
        class MenuItem_Shutdown:MenuItem
        {
            public override void Execute()
            {
                Program.PausedShowMenu = false;
                NesEmu.EmulationON = false;
            }
        }
    }
}

