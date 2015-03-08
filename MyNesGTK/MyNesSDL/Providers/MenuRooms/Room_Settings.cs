//
//  Room_Settings.cs
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

namespace MyNesSDL
{
    [RoomBaseAttributes("Settings")]
    public class Room_Settings:RoomBase
    {
        public Room_Settings()
            : base()
        {
            Items.Add(new MenuItem_Region());
            Items.Add(new MenuItem_Connect4Player());
            Items.Add(new MenuItem_ConnectZapper());
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_Video());
            Items.Add(new MenuItem_Audio());
            Items.Add(new MenuItem_Input());
            Items.Add(new MenuItem_Palettes());
            Items.Add(new MenuItem_Preferences());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_BackToMainMenu());
        }

        public override void OnTabResume()
        {
            Program.SelectRoom("main menu");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        public override void OnOpen()
        {
            switch (Settings.TvSystemSetting.ToLower())
            {
                case "auto":
                    Items[0].SelectedOptionIndex = 0;
                    break;
                case "ntsc":
                    Items[0].SelectedOptionIndex = 1;
                    break;
                case "palb":
                    Items[0].SelectedOptionIndex = 2;
                    break;
                case "dendy":
                    Items[0].SelectedOptionIndex = 3;
                    break;
            }         
            Items[1].SelectedOptionIndex = Settings.Key_Connect4Players ? 1 : 0;
            Items[2].SelectedOptionIndex = Settings.Key_ConnectZapper ? 1 : 0;
        }

        protected override void OnMenuOptionChanged()
        {
            switch (SelectedMenuIndex)
            {
                case 0:// Region
                    {
                        switch (Items[0].SelectedOptionIndex)
                        {
                            case 0:
                                Settings.TvSystemSetting = "auto";
                                break;
                            case 1:
                                Settings.TvSystemSetting = "ntsc";
                                break;
                            case 2:
                                Settings.TvSystemSetting = "palb";
                                break;
                            case 3:
                                Settings.TvSystemSetting = "dendy";
                                break;
                        }
                        break;
                    }
                case 1:// Connect 4 players
                    {
                        Settings.Key_Connect4Players = Items[1].SelectedOptionIndex == 1;
                        NesEmu.IsFourPlayers = Settings.Key_Connect4Players;
                        break;
                    }
                case 2:// Connect Zapper
                    {
                        Settings.Key_ConnectZapper = Items[2].SelectedOptionIndex == 1;
                        NesEmu.IsZapperConnected = Settings.Key_ConnectZapper;
                        if (NesEmu.IsZapperConnected)
                        {
                            NesEmu.SetupZapper(new SDLZapper());
                            SdlDotNet.Input.Mouse.ShowCursor = true;
                        }
                        break;
                    }
            }
        }

        [MenuItemAttribute("Video", false, 0, new string[0], false)]
        class MenuItem_Video:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("video settings");
            }
        }

        [MenuItemAttribute("Audio", false, 0, new string[0], false)]
        class MenuItem_Audio:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("audio settings");
            }
        }

        [MenuItemAttribute("Input", false, 0, new string[0], false)]
        class MenuItem_Input:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings");
            }
        }

        [MenuItemAttribute("Preferences", false, 0, new string[0], false)]
        class MenuItem_Preferences:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("preferences settings");
            }
        }

        [MenuItemAttribute("Palettes", false, 0, new string[0], false)]
        class MenuItem_Palettes:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("palettes settings");
            }
        }

        [MenuItemAttribute("Region (Hard reset required)", true, 0, new string[]{ "AUTO", "Force NTSC", "Force PALB", "Force DENDY" }, false)]
        class MenuItem_Region:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Connect 4 Players", true, 0, new string[]{ "NO", "YES" }, false)]
        class MenuItem_Connect4Player:MenuItem
        {
            public override void Execute()
            {
              
            }
        }

        [MenuItemAttribute("Connect Zapper", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_ConnectZapper:MenuItem
        {
            public override void Execute()
            {
            }
        }
    }
}

