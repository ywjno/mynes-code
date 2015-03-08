//
//  Room_PreferencesSettings.cs
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
    [RoomBaseAttributes("Preferences Settings")]
    public class Room_PreferencesSettings:RoomBase
    {
        public Room_PreferencesSettings()
            : base()
        {
            Items.Add(new MenuItem_SaveSRAMOnShutdown());
            Items.Add(new MenuItem_SaveSnapReplace());   
            Items.Add(new MenuItem_SnapFormat());
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_FrameSkipEnabled());
            Items.Add(new MenuItem_FrameSkipCount());
            for (int i = 1; i < 10; i++)
            {
                Items[Items.Count - 1].Options.Add(i.ToString());
            }
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_ApplySettings(this));
            Items.Add(new MenuItem_DiscardSettings());
        }

        public override void OnOpen()
        {
            base.OnOpen();
            Items[0].SelectedOptionIndex = Settings.SaveSRAMOnShutdown ? 1 : 0;
            Items[1].SelectedOptionIndex = Settings.SnapReplace ? 1 : 0;
            switch (Settings.SnapsFormat.ToLower())
            {
                case ".png":
                    Items[2].SelectedOptionIndex = 0;
                    break;
                case ".jpg":
                    Items[2].SelectedOptionIndex = 1;
                    break;
                case ".bmp":
                    Items[2].SelectedOptionIndex = 2;
                    break;
            }
            Items[3].SelectedOptionIndex = Settings.FrameSkipEnabled ? 1 : 0;
            Items[4].SelectedOptionIndex = Settings.FrameSkipCount - 1;
        }

        public override void OnTabResume()
        {
            Program.SelectRoom("settings");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        [MenuItemAttribute("Apply And Back", false, 0, new string[0], false)]
        class MenuItem_ApplySettings:MenuItem
        {
            public MenuItem_ApplySettings(Room_PreferencesSettings page)
                : base()
            {
                this.page = page;
            }

            private Room_PreferencesSettings page;

            public override void Execute()
            {
                Settings.SaveSRAMOnShutdown = page.Items[0].SelectedOptionIndex == 1; 
                Settings.SnapReplace = page.Items[1].SelectedOptionIndex == 1;
                switch (page.Items[2].SelectedOptionIndex)
                {
                    case 0:
                        Settings.SnapsFormat = ".png";
                        break;
                    case 1:
                        Settings.SnapsFormat = ".jpg";
                        break;
                    case 2:
                        Settings.SnapsFormat = ".bmp";
                        break;
                }
                Settings.FrameSkipEnabled = page.Items[3].SelectedOptionIndex == 1; 
                Settings.FrameSkipCount = page.Items[4].SelectedOptionIndex + 1;

                Program.ApplyEmuSettings();

                Settings.SaveSettings();
                Program.SelectRoom("settings");
            }
        }

        [MenuItemAttribute("Discard And Back", false, 0, new string[0], false)]
        class MenuItem_DiscardSettings:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("settings");
            }
        }

        [MenuItemAttribute("Save Game SRAM On Shutdown", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_SaveSRAMOnShutdown:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Snapshot Replace When Taken", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_SaveSnapReplace:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Snapshot Format", true, 0, new string[]{ ".png", ".jpg", ".bmp"  }, false)]
        class MenuItem_SnapFormat:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Enable Frame Skip", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_FrameSkipEnabled:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Frame Skip Count", true, 0, new string[0], false)]
        class MenuItem_FrameSkipCount:MenuItem
        {
            public override void Execute()
            {
            }
        }
    }
}

