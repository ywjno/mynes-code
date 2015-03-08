//
//  Room_Input_Shortcuts.cs
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
using System.Drawing;
using SdlDotNet.Core;
using SdlDotNet.Input;
using MyNes.Core;

namespace MyNesSDL
{
    [RoomBaseAttributes("Input Settings - Shortcuts")]
    public class Room_Input_Shortcuts:RoomBase
    {
        public Room_Input_Shortcuts()
            : base()
        {   
            Items.Add(new MenuItem_UseJoystick());
            Items.Add(new MenuItem_JoystickIndex());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_HardReset(this));
            Items.Add(new MenuItem_SoftReset(this));
            Items.Add(new MenuItem_SwitchFullscreen(this));
            Items.Add(new MenuItem_TakeSnap(this));
            Items.Add(new MenuItem_SaveState(this));
            Items.Add(new MenuItem_LoadState(this));
            Items.Add(new MenuItem_ShutdownEmu(this));
            Items.Add(new MenuItem_TogglePause(this));
            Items.Add(new MenuItem_ToggleTurbo(this));
            Items.Add(new MenuItem_RecordSound(this));
            Items.Add(new MenuItem_ToggleFrameSkip(this));
            Items.Add(new MenuItem_StateSlot0(this));
            Items.Add(new MenuItem_StateSlot1(this));
            Items.Add(new MenuItem_StateSlot2(this));
            Items.Add(new MenuItem_StateSlot3(this));
            Items.Add(new MenuItem_StateSlot4(this));
            Items.Add(new MenuItem_StateSlot5(this));
            Items.Add(new MenuItem_StateSlot6(this));
            Items.Add(new MenuItem_StateSlot7(this));
            Items.Add(new MenuItem_StateSlot8(this));
            Items.Add(new MenuItem_StateSlot9(this));
            Items.Add(new MenuItem_ShowEmulationStatus(this));
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_ResetDefaults(this));
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_ApplyAndBack(this));
            Items.Add(new MenuItem_Back());
        }

        private string orginal;
        private bool lockKeys;
        private bool lockKeysJoystick;
        public bool useJoystick;
        private Joystick joystick;

        public override void DoKeyDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (!lockKeys)
                base.DoKeyDown(e);
            else
            {
                lockKeys = false;
                if (e.Key != SdlDotNet.Input.Key.Return)
                {
                    Items[SelectedMenuIndex].Options.Clear();
                    Items[SelectedMenuIndex].Options.Add(e.Key.ToString());
                }
                else
                {
                    // Cancel
                    Items[SelectedMenuIndex].Options.Clear();
                    Items[SelectedMenuIndex].Options.Add(orginal);
                }
            }
        }

        protected override void OnMenuOptionChanged()
        {
            if (SelectedMenuIndex == 0)
            {
                if (Items[0].Options[0] != "N/A")
                {
                    if (Items[0].SelectedOptionIndex == 0)// NO
                    {
                        useJoystick = false;
                        Items[2].Options.Clear();
                        Items[2].Options.Add(Settings.Key_HardReset);
                        Items[3].Options.Clear();
                        Items[3].Options.Add(Settings.Key_SoftReset);
                        Items[4].Options.Clear();
                        Items[4].Options.Add(Settings.Key_SwitchFullscreen);
                        Items[5].Options.Clear();
                        Items[5].Options.Add(Settings.Key_TakeSnap);
                        Items[6].Options.Clear();
                        Items[6].Options.Add(Settings.Key_SaveState);
                        Items[7].Options.Clear();
                        Items[7].Options.Add(Settings.Key_LoadState);
                        Items[8].Options.Clear();
                        Items[8].Options.Add(Settings.Key_ShutdownEmu);
                        Items[9].Options.Clear();
                        Items[9].Options.Add(Settings.Key_TogglePause);
                        Items[10].Options.Clear();
                        Items[10].Options.Add(Settings.Key_ToggleTurbo);
                        Items[11].Options.Clear();
                        Items[11].Options.Add(Settings.Key_RecordSound);
                        Items[12].Options.Clear();
                        Items[12].Options.Add(Settings.Key_ToggleFrameSkip);
                        Items[13].Options.Clear();
                        Items[13].Options.Add(Settings.Key_StateSlot0);
                        Items[14].Options.Clear();
                        Items[14].Options.Add(Settings.Key_StateSlot1);
                        Items[15].Options.Clear();
                        Items[15].Options.Add(Settings.Key_StateSlot2);
                        Items[16].Options.Clear();
                        Items[16].Options.Add(Settings.Key_StateSlot3);
                        Items[17].Options.Clear();
                        Items[17].Options.Add(Settings.Key_StateSlot4);
                        Items[18].Options.Clear();
                        Items[18].Options.Add(Settings.Key_StateSlot5);
                        Items[19].Options.Clear();
                        Items[19].Options.Add(Settings.Key_StateSlot6);
                        Items[20].Options.Clear();
                        Items[20].Options.Add(Settings.Key_StateSlot7);
                        Items[21].Options.Clear();
                        Items[21].Options.Add(Settings.Key_StateSlot8);
                        Items[22].Options.Clear();
                        Items[22].Options.Add(Settings.Key_StateSlot9);
                        Items[23].Options.Clear();
                        Items[23].Options.Add(Settings.Key_ShowGameStatus);
                    }
                    else
                    {
                        useJoystick = true;
                        Items[2].Options.Clear();
                        Items[2].Options.Add(Settings.JoyKey_HardReset);
                        Items[3].Options.Clear();
                        Items[3].Options.Add(Settings.JoyKey_SoftReset);
                        Items[4].Options.Clear();
                        Items[4].Options.Add(Settings.JoyKey_SwitchFullscreen);
                        Items[5].Options.Clear();
                        Items[5].Options.Add(Settings.JoyKey_TakeSnap);
                        Items[6].Options.Clear();
                        Items[6].Options.Add(Settings.JoyKey_SaveState);
                        Items[7].Options.Clear();
                        Items[7].Options.Add(Settings.JoyKey_LoadState);
                        Items[8].Options.Clear();
                        Items[8].Options.Add(Settings.JoyKey_ShutdownEmu);
                        Items[9].Options.Clear();
                        Items[9].Options.Add(Settings.JoyKey_TogglePause);
                        Items[10].Options.Clear();
                        Items[10].Options.Add(Settings.JoyKey_ToggleTurbo);
                        Items[11].Options.Clear();
                        Items[11].Options.Add(Settings.JoyKey_RecordSound);
                        Items[12].Options.Clear();
                        Items[12].Options.Add(Settings.JoyKey_ToggleFrameSkip);
                        Items[13].Options.Clear();
                        Items[13].Options.Add(Settings.JoyKey_StateSlot0);
                        Items[14].Options.Clear();
                        Items[14].Options.Add(Settings.JoyKey_StateSlot1);
                        Items[15].Options.Clear();
                        Items[15].Options.Add(Settings.JoyKey_StateSlot2);
                        Items[16].Options.Clear();
                        Items[16].Options.Add(Settings.JoyKey_StateSlot3);
                        Items[17].Options.Clear();
                        Items[17].Options.Add(Settings.JoyKey_StateSlot4);
                        Items[18].Options.Clear();
                        Items[18].Options.Add(Settings.JoyKey_StateSlot5);
                        Items[19].Options.Clear();
                        Items[19].Options.Add(Settings.JoyKey_StateSlot6);
                        Items[20].Options.Clear();
                        Items[20].Options.Add(Settings.JoyKey_StateSlot7);
                        Items[21].Options.Clear();
                        Items[21].Options.Add(Settings.JoyKey_StateSlot8);
                        Items[22].Options.Clear();
                        Items[22].Options.Add(Settings.JoyKey_StateSlot9);
                        Items[23].Options.Clear();
                        Items[23].Options.Add(Settings.JoyKey_ShowGameStatus);
                    }
                }
            }
            if (SelectedMenuIndex == 1)
            {
                if (Items[1].Options[0] != "N/A")
                {
                    joystick = Joysticks.OpenJoystick(Items[1].SelectedOptionIndex);
                }
            }
        }

        public override void DoJoystickButtonDown(SdlDotNet.Input.JoystickButtonEventArgs e)
        {
            if (!lockKeysJoystick)
                base.DoJoystickButtonDown(e);
            else
            {
                lockKeysJoystick = false;

                Items[SelectedMenuIndex].Options.Clear();
                Items[SelectedMenuIndex].Options.Add(e.Button.ToString());
            }
        }

        public override void DoJoystickAxisMove(JoystickAxisEventArgs e)
        {
            //Console.WriteLine(joystick.GetAxisPosition(JoystickAxis.Horizontal).ToString());
            if (!lockKeysJoystick)
                base.DoJoystickAxisMove(e);
            else
            {
                lockKeysJoystick = false;

                Items[SelectedMenuIndex].Options.Clear();
                if (e.AxisIndex == 0)
                    Items[SelectedMenuIndex].Options.Add((e.AxisValue > 0) ? "+X" : "-X");
                else
                    Items[SelectedMenuIndex].Options.Add((e.AxisValue > 0) ? "+Y" : "-Y");
            }
        }

        public override void OnOpen()
        {
            // Load joystick stuff
            Joysticks.Initialize();
            bool joyKeys = false;
            if (Joysticks.NumberOfJoysticks > 0)
            {
                Items[0].Options.Clear();
                Items[0].Options.Add("NO");
                Items[0].Options.Add("YES");
                Items[0].SelectedOptionIndex = Settings.Key_Shortcuts_UseJoystick ? 1 : 0;
                useJoystick = Settings.Key_Shortcuts_UseJoystick;
                Items[1].Options.Clear();
                if (Settings.Key_Shortcuts_JoystickIndex < Joysticks.NumberOfJoysticks)
                {
                    for (int i = 0; i < Joysticks.NumberOfJoysticks; i++)
                    {
                        Items[1].Options.Add(i.ToString());
                    }
                    Items[1].SelectedOptionIndex = Settings.Key_Shortcuts_JoystickIndex;
                }
                else
                {
                    Items[1].SelectedOptionIndex = 0;
                }
                joystick = Joysticks.OpenJoystick(Items[1].SelectedOptionIndex);
                joyKeys = true;
            }
            else
            {
                useJoystick = false;
                Items[0].Options.Clear();
                Items[0].Options.Add("N/A");
                Items[0].SelectedOptionIndex = 0;
                Items[1].Options.Clear();
                Items[1].Options.Add("N/A");
                Items[1].SelectedOptionIndex = 0;
            }
            if (!(joyKeys && Settings.Key_Shortcuts_UseJoystick))
            {
                Items[2].Options.Clear();
                Items[2].Options.Add(Settings.Key_HardReset);
                Items[3].Options.Clear();
                Items[3].Options.Add(Settings.Key_SoftReset);
                Items[4].Options.Clear();
                Items[4].Options.Add(Settings.Key_SwitchFullscreen);
                Items[5].Options.Clear();
                Items[5].Options.Add(Settings.Key_TakeSnap);
                Items[6].Options.Clear();
                Items[6].Options.Add(Settings.Key_SaveState);
                Items[7].Options.Clear();
                Items[7].Options.Add(Settings.Key_LoadState);
                Items[8].Options.Clear();
                Items[8].Options.Add(Settings.Key_ShutdownEmu);
                Items[9].Options.Clear();
                Items[9].Options.Add(Settings.Key_TogglePause);
                Items[10].Options.Clear();
                Items[10].Options.Add(Settings.Key_ToggleTurbo);
                Items[11].Options.Clear();
                Items[11].Options.Add(Settings.Key_RecordSound);
                Items[12].Options.Clear();
                Items[12].Options.Add(Settings.Key_ToggleFrameSkip);
                Items[13].Options.Clear();
                Items[13].Options.Add(Settings.Key_StateSlot0);
                Items[14].Options.Clear();
                Items[14].Options.Add(Settings.Key_StateSlot1);
                Items[15].Options.Clear();
                Items[15].Options.Add(Settings.Key_StateSlot2);
                Items[16].Options.Clear();
                Items[16].Options.Add(Settings.Key_StateSlot3);
                Items[17].Options.Clear();
                Items[17].Options.Add(Settings.Key_StateSlot4);
                Items[18].Options.Clear();
                Items[18].Options.Add(Settings.Key_StateSlot5);
                Items[19].Options.Clear();
                Items[19].Options.Add(Settings.Key_StateSlot6);
                Items[20].Options.Clear();
                Items[20].Options.Add(Settings.Key_StateSlot7);
                Items[21].Options.Clear();
                Items[21].Options.Add(Settings.Key_StateSlot8);
                Items[22].Options.Clear();
                Items[22].Options.Add(Settings.Key_StateSlot9);
                Items[23].Options.Clear();
                Items[23].Options.Add(Settings.Key_ShowGameStatus);
            }
            else
            {
                Items[2].Options.Clear();
                Items[2].Options.Add(Settings.JoyKey_HardReset);
                Items[3].Options.Clear();
                Items[3].Options.Add(Settings.JoyKey_SoftReset);
                Items[4].Options.Clear();
                Items[4].Options.Add(Settings.JoyKey_SwitchFullscreen);
                Items[5].Options.Clear();
                Items[5].Options.Add(Settings.JoyKey_TakeSnap);
                Items[6].Options.Clear();
                Items[6].Options.Add(Settings.JoyKey_SaveState);
                Items[7].Options.Clear();
                Items[7].Options.Add(Settings.JoyKey_LoadState);
                Items[8].Options.Clear();
                Items[8].Options.Add(Settings.JoyKey_ShutdownEmu);
                Items[9].Options.Clear();
                Items[9].Options.Add(Settings.JoyKey_TogglePause);
                Items[10].Options.Clear();
                Items[10].Options.Add(Settings.JoyKey_ToggleTurbo);
                Items[11].Options.Clear();
                Items[11].Options.Add(Settings.JoyKey_RecordSound);
                Items[12].Options.Clear();
                Items[12].Options.Add(Settings.JoyKey_ToggleFrameSkip);
                Items[13].Options.Clear();
                Items[13].Options.Add(Settings.JoyKey_StateSlot0);
                Items[14].Options.Clear();
                Items[14].Options.Add(Settings.JoyKey_StateSlot1);
                Items[15].Options.Clear();
                Items[15].Options.Add(Settings.JoyKey_StateSlot2);
                Items[16].Options.Clear();
                Items[16].Options.Add(Settings.JoyKey_StateSlot3);
                Items[17].Options.Clear();
                Items[17].Options.Add(Settings.JoyKey_StateSlot4);
                Items[18].Options.Clear();
                Items[18].Options.Add(Settings.JoyKey_StateSlot5);
                Items[19].Options.Clear();
                Items[19].Options.Add(Settings.JoyKey_StateSlot6);
                Items[20].Options.Clear();
                Items[20].Options.Add(Settings.JoyKey_StateSlot7);
                Items[21].Options.Clear();
                Items[21].Options.Add(Settings.JoyKey_StateSlot8);
                Items[22].Options.Clear();
                Items[22].Options.Add(Settings.JoyKey_StateSlot9);
                Items[23].Options.Clear();
                Items[23].Options.Add(Settings.JoyKey_ShowGameStatus);
            }
        }

        public override void OnTabResume()
        {     
            Program.SelectRoom("input settings");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        public void LockKeysToInput()
        {
            if (!useJoystick)
            {
                lockKeys = true;
            }
            else
            {
                lockKeysJoystick = true;
            }
            orginal = Items[SelectedMenuIndex].Options[0];
        }


        [MenuItemAttribute("Use Joystick", true, 0, new string[]{ "NO", "YES" }, false)]
        class MenuItem_UseJoystick:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Joystick Index", true, 0, new string[]{ "0" }, false)]
        class MenuItem_JoystickIndex:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Apply And Back", false, 0, new string[0], false)]
        class MenuItem_ApplyAndBack:MenuItem
        {
            public MenuItem_ApplyAndBack(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                if (page.Items[0].Options.Count == 1)
                    Settings.Key_Shortcuts_UseJoystick = false;
                else
                    Settings.Key_Shortcuts_UseJoystick = page.Items[0].SelectedOptionIndex == 1;
                Settings.Key_Shortcuts_JoystickIndex = page.Items[1].SelectedOptionIndex;
                if (!Settings.Key_Shortcuts_UseJoystick)
                {
                    Settings.Key_HardReset = page.Items[2].Options[0];
                    Settings.Key_SoftReset = page.Items[3].Options[0];
                    Settings.Key_SwitchFullscreen = page.Items[4].Options[0];
                    Settings.Key_TakeSnap = page.Items[5].Options[0];
                    Settings.Key_SaveState = page.Items[6].Options[0];
                    Settings.Key_LoadState = page.Items[7].Options[0];
                    Settings.Key_ShutdownEmu = page.Items[8].Options[0];
                    Settings.Key_TogglePause = page.Items[9].Options[0];
                    Settings.Key_ToggleTurbo = page.Items[10].Options[0];
                    Settings.Key_RecordSound = page.Items[11].Options[0];
                    Settings.Key_ToggleFrameSkip = page.Items[12].Options[0];
                    Settings.Key_StateSlot0 = page.Items[13].Options[0];
                    Settings.Key_StateSlot1 = page.Items[14].Options[0];
                    Settings.Key_StateSlot2 = page.Items[15].Options[0];
                    Settings.Key_StateSlot3 = page.Items[16].Options[0];
                    Settings.Key_StateSlot4 = page.Items[17].Options[0];
                    Settings.Key_StateSlot5 = page.Items[18].Options[0];
                    Settings.Key_StateSlot6 = page.Items[19].Options[0];
                    Settings.Key_StateSlot7 = page.Items[20].Options[0];
                    Settings.Key_StateSlot8 = page.Items[21].Options[0];
                    Settings.Key_StateSlot9 = page.Items[22].Options[0];
                    Settings.Key_ShowGameStatus = page.Items[23].Options[0];
                }
                else
                {
                    Settings.JoyKey_HardReset = page.Items[2].Options[0];
                    Settings.JoyKey_SoftReset = page.Items[3].Options[0];
                    Settings.JoyKey_SwitchFullscreen = page.Items[4].Options[0];
                    Settings.JoyKey_TakeSnap = page.Items[5].Options[0];
                    Settings.JoyKey_SaveState = page.Items[6].Options[0];
                    Settings.JoyKey_LoadState = page.Items[7].Options[0];
                    Settings.JoyKey_ShutdownEmu = page.Items[8].Options[0];
                    Settings.JoyKey_TogglePause = page.Items[9].Options[0];
                    Settings.JoyKey_ToggleTurbo = page.Items[10].Options[0];
                    Settings.JoyKey_RecordSound = page.Items[11].Options[0];
                    Settings.JoyKey_ToggleFrameSkip = page.Items[12].Options[0];
                    Settings.JoyKey_StateSlot0 = page.Items[13].Options[0];
                    Settings.JoyKey_StateSlot1 = page.Items[14].Options[0];
                    Settings.JoyKey_StateSlot2 = page.Items[15].Options[0];
                    Settings.JoyKey_StateSlot3 = page.Items[16].Options[0];
                    Settings.JoyKey_StateSlot4 = page.Items[17].Options[0];
                    Settings.JoyKey_StateSlot5 = page.Items[18].Options[0];
                    Settings.JoyKey_StateSlot6 = page.Items[19].Options[0];
                    Settings.JoyKey_StateSlot7 = page.Items[20].Options[0];
                    Settings.JoyKey_StateSlot8 = page.Items[21].Options[0];
                    Settings.JoyKey_StateSlot9 = page.Items[22].Options[0];
                    Settings.JoyKey_ShowGameStatus = page.Items[23].Options[0];
                }
                Program.LoadShortcuts();
                Program.SelectRoom("input settings");
            }
        }

        [MenuItemAttribute("Discard And Back", false, 0, new string[0], false)]
        class MenuItem_Back:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings");
            }
        }

        [MenuItemAttribute("Reset To Defaults", false, 0, new string[0], false)]
        class MenuItem_ResetDefaults:MenuItem
        {
            public MenuItem_ResetDefaults(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {  
                page.Items[0].SelectedOptionIndex = 0;
                page.Items[1].SelectedOptionIndex = 0;
                page.useJoystick = false;
                page.Items[2].Options.Clear();
                page.Items[2].Options.Add("F4");
                page.Items[3].Options.Clear();
                page.Items[3].Options.Add("F3");
                page.Items[4].Options.Clear();
                page.Items[4].Options.Add("F12");
                page.Items[5].Options.Clear();
                page.Items[5].Options.Add("F5");
                page.Items[6].Options.Clear();
                page.Items[6].Options.Add("F6");
                page.Items[7].Options.Clear();
                page.Items[7].Options.Add("F9");
                page.Items[8].Options.Clear();
                page.Items[8].Options.Add("F2");
                page.Items[9].Options.Clear();
                page.Items[9].Options.Add("F1");
                page.Items[10].Options.Clear();
                page.Items[10].Options.Add("F11");
                page.Items[11].Options.Clear();
                page.Items[11].Options.Add("F7");
                page.Items[12].Options.Clear();
                page.Items[12].Options.Add("F8");
                page.Items[13].Options.Clear();
                page.Items[13].Options.Add("Zero");
                page.Items[14].Options.Clear();
                page.Items[14].Options.Add("One");
                page.Items[15].Options.Clear();
                page.Items[15].Options.Add("Two");
                page.Items[16].Options.Clear();
                page.Items[16].Options.Add("Three");
                page.Items[17].Options.Clear();
                page.Items[17].Options.Add("Four");
                page.Items[18].Options.Clear();
                page.Items[18].Options.Add("Five");
                page.Items[19].Options.Clear();
                page.Items[19].Options.Add("Six");
                page.Items[20].Options.Clear();
                page.Items[20].Options.Add("Seven");
                page.Items[21].Options.Clear();
                page.Items[21].Options.Add("Eight");
                page.Items[22].Options.Clear();
                page.Items[22].Options.Add("Nine");
            }
        }

        [MenuItemAttribute("Hard Reset", true, 0, new string[0], false)]
        class MenuItem_HardReset:MenuItem
        {
            public MenuItem_HardReset(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Soft Reset", true, 0, new string[0], false)]
        class MenuItem_SoftReset:MenuItem
        {
            public MenuItem_SoftReset(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Switch Fullscreen", true, 0, new string[0], false)]
        class MenuItem_SwitchFullscreen:MenuItem
        {
            public MenuItem_SwitchFullscreen(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Take Snapshot", true, 0, new string[0], false)]
        class MenuItem_TakeSnap:MenuItem
        {
            public MenuItem_TakeSnap(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Save State", true, 0, new string[0], false)]
        class MenuItem_SaveState:MenuItem
        {
            public MenuItem_SaveState(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Load State", true, 0, new string[0], false)]
        class MenuItem_LoadState:MenuItem
        {
            public MenuItem_LoadState(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Shutdown Emu", true, 0, new string[0], false)]
        class MenuItem_ShutdownEmu:MenuItem
        {
            public MenuItem_ShutdownEmu(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Toggle Pause", true, 0, new string[0], false)]
        class MenuItem_TogglePause:MenuItem
        {
            public MenuItem_TogglePause(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Toggle Turbo", true, 0, new string[0], false)]
        class MenuItem_ToggleTurbo:MenuItem
        {
            public MenuItem_ToggleTurbo(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Record Sound", true, 0, new string[0], false)]
        class MenuItem_RecordSound:MenuItem
        {
            public MenuItem_RecordSound(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Toggle Frame Skip", true, 0, new string[0], false)]
        class MenuItem_ToggleFrameSkip:MenuItem
        {
            public MenuItem_ToggleFrameSkip(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 0", true, 0, new string[0], false)]
        class MenuItem_StateSlot0:MenuItem
        {
            public MenuItem_StateSlot0(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 1", true, 0, new string[0], false)]
        class MenuItem_StateSlot1:MenuItem
        {
            public MenuItem_StateSlot1(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 2", true, 0, new string[0], false)]
        class MenuItem_StateSlot2:MenuItem
        {
            public MenuItem_StateSlot2(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 3", true, 0, new string[0], false)]
        class MenuItem_StateSlot3:MenuItem
        {
            public MenuItem_StateSlot3(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 4", true, 0, new string[0], false)]
        class MenuItem_StateSlot4:MenuItem
        {
            public MenuItem_StateSlot4(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 5", true, 0, new string[0], false)]
        class MenuItem_StateSlot5:MenuItem
        {
            public MenuItem_StateSlot5(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 6", true, 0, new string[0], false)]
        class MenuItem_StateSlot6:MenuItem
        {
            public MenuItem_StateSlot6(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 7", true, 0, new string[0], false)]
        class MenuItem_StateSlot7:MenuItem
        {
            public MenuItem_StateSlot7(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 8", true, 0, new string[0], false)]
        class MenuItem_StateSlot8:MenuItem
        {
            public MenuItem_StateSlot8(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Set State Slot 9", true, 0, new string[0], false)]
        class MenuItem_StateSlot9:MenuItem
        {
            public MenuItem_StateSlot9(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Show Emulation Status", true, 0, new string[0], false)]
        class MenuItem_ShowEmulationStatus:MenuItem
        {
            public MenuItem_ShowEmulationStatus(Room_Input_Shortcuts page)
            {
                this.page = page;
            }

            Room_Input_Shortcuts page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }
    }
}

