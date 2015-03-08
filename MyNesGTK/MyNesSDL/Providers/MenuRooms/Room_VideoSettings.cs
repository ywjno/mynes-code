//
//  Room_VideoSettings.cs
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
using System.Collections.Generic;
using MyNes.Core;

namespace MyNesSDL
{
    [RoomBaseAttributes("Video Settings")]
    public class Room_VideoSettings : RoomBase
    {
        public Room_VideoSettings()
            : base()
        {
            Items.Add(new MenuItem_StartInFullscreen());
            Items.Add(new MenuItem_FullscreenResolution());
            for (int i = 0; i < Program.VIDEO.fullscreenModes.Length; i++)
            {
                Items[Items.Count - 1].Options.Add(Program.VIDEO.fullscreenModes[i].Width + " x "
                    + Program.VIDEO.fullscreenModes[i].Height);
            }
           
            Items.Add(new MenuItem_StretchMulti());
            Items.Add(new MenuItem_AutoResizeToFitEmu());
            Items.Add(new MenuItem_KeepAspectRatio());
            Items.Add(new MenuItem_HideLinesForNTSCAndPAL());
            Items.Add(new MenuItem_ShowFPS());
            Items.Add(new MenuItem_ShowNotification());
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_ApplySettings(this));
            Items.Add(new MenuItem_DiscardSettings());
        }

        public override void OnOpen()
        {
            base.OnOpen();
            Items[0].SelectedOptionIndex = Settings.Video_StartInFullscreen ? 1 : 0;
            Items[1].SelectedOptionIndex = Settings.Video_FullScreenModeIndex;
            Items[2].SelectedOptionIndex = Settings.Video_StretchMulti - 1;
            Items[3].SelectedOptionIndex = Settings.Video_AutoResizeToFitEmu ? 1 : 0;
            Items[4].SelectedOptionIndex = Settings.Video_KeepAspectRatio ? 1 : 0;
            Items[5].SelectedOptionIndex = Settings.Video_HideLinesForNTSCAndPAL ? 1 : 0;
            Items[6].SelectedOptionIndex = Settings.Video_ShowFPS ? 1 : 0;
            Items[7].SelectedOptionIndex = Settings.Video_ShowNotification ? 1 : 0;

        }

        public override void OnTabResume()
        {
            Program.SelectRoom("settings");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        [MenuItemAttribute("Apply And Back (some settings require restart)", false, 0, new string[0], false)]
        class MenuItem_ApplySettings:MenuItem
        {
            public MenuItem_ApplySettings(Room_VideoSettings videoPage)
                : base()
            {
                this.videoPage = videoPage;
            }

            private Room_VideoSettings videoPage;

            public override void Execute()
            {
                Settings.Video_StartInFullscreen = videoPage.Items[0].SelectedOptionIndex == 1;
                Settings.Video_FullScreenModeIndex = videoPage.Items[1].SelectedOptionIndex;
                Settings.Video_StretchMulti = videoPage.Items[2].SelectedOptionIndex + 1;
                Settings.Video_AutoResizeToFitEmu = videoPage.Items[3].SelectedOptionIndex == 1;  
                Settings.Video_KeepAspectRatio = videoPage.Items[4].SelectedOptionIndex == 1;  
                Settings.Video_HideLinesForNTSCAndPAL = videoPage.Items[5].SelectedOptionIndex == 1;  
                Settings.Video_ShowFPS = videoPage.Items[6].SelectedOptionIndex == 1; 
                Settings.Video_ShowNotification = videoPage.Items[7].SelectedOptionIndex == 1; 
                Settings.SaveSettings();

                Program.VIDEO.LoadSettings();
                Program.VIDEO.ApplySettings();

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

        [MenuItemAttribute("Auto Resize To Fit Stretch", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_AutoResizeToFitEmu:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Start In Fullscreen", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_StartInFullscreen:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Show FPS", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_ShowFPS:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Show Notifications", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_ShowNotification:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Keep Aspect Ratio", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_KeepAspectRatio:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Hide Lines", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_HideLinesForNTSCAndPAL:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Stretch Multiply", true, 0, new string[]{ "1", "2", "3", "4", "5", "6", "7", "8", "9" }, false)]
        class MenuItem_StretchMulti:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Fullscreen Resolution", true, 0, new string[0], false)]
        class MenuItem_FullscreenResolution:MenuItem
        {
            public override void Execute()
            {
            }
        }
    }
}

