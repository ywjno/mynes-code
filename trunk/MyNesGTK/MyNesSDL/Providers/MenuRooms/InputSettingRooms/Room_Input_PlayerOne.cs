//
//  Room_Input_PlayerOne.cs
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
using SdlDotNet.Core;
using SdlDotNet.Input;
using MyNes.Core;

namespace MyNesSDL
{
    [RoomBaseAttributes("Input Settings - Player One")]
    public class Room_Input_PlayerOne:RoomBase
    {
        public Room_Input_PlayerOne()
            : base()
        {
            Items.Add(new MenuItem_UseJoystick());
            Items.Add(new MenuItem_JoystickIndex());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_A(this));
            Items.Add(new MenuItem_B(this));
            Items.Add(new MenuItem_TurboA(this));
            Items.Add(new MenuItem_TurboB(this));
            Items.Add(new MenuItem_Start(this));
            Items.Add(new MenuItem_Select(this));
            Items.Add(new MenuItem_Up(this));
            Items.Add(new MenuItem_Down(this));
            Items.Add(new MenuItem_Left(this));
            Items.Add(new MenuItem_Right(this));
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
                        Items[2].Options.Add(Settings.Key_P1_ButtonA);
                        Items[3].Options.Clear();
                        Items[3].Options.Add(Settings.Key_P1_ButtonB);
                        Items[4].Options.Clear();
                        Items[4].Options.Add(Settings.Key_P1_ButtonTurboA);
                        Items[5].Options.Clear();
                        Items[5].Options.Add(Settings.Key_P1_ButtonTurboB);
                        Items[6].Options.Clear();
                        Items[6].Options.Add(Settings.Key_P1_ButtonStart);
                        Items[7].Options.Clear();
                        Items[7].Options.Add(Settings.Key_P1_ButtonSelect);
                        Items[8].Options.Clear();
                        Items[8].Options.Add(Settings.Key_P1_ButtonUp);
                        Items[9].Options.Clear();
                        Items[9].Options.Add(Settings.Key_P1_ButtonDown);
                        Items[10].Options.Clear();
                        Items[10].Options.Add(Settings.Key_P1_ButtonLeft);
                        Items[11].Options.Clear();
                        Items[11].Options.Add(Settings.Key_P1_ButtonRight);
                    }
                    else
                    {
                        useJoystick = true;
                        Items[2].Options.Clear();
                        Items[2].Options.Add(Settings.JoyKey_P1_ButtonA);
                        Items[3].Options.Clear();
                        Items[3].Options.Add(Settings.JoyKey_P1_ButtonB);
                        Items[4].Options.Clear();
                        Items[4].Options.Add(Settings.JoyKey_P1_ButtonTurboA);
                        Items[5].Options.Clear();
                        Items[5].Options.Add(Settings.JoyKey_P1_ButtonTurboB);
                        Items[6].Options.Clear();
                        Items[6].Options.Add(Settings.JoyKey_P1_ButtonStart);
                        Items[7].Options.Clear();
                        Items[7].Options.Add(Settings.JoyKey_P1_ButtonSelect);
                        Items[8].Options.Clear();
                        Items[8].Options.Add(Settings.JoyKey_P1_ButtonUp);
                        Items[9].Options.Clear();
                        Items[9].Options.Add(Settings.JoyKey_P1_ButtonDown);
                        Items[10].Options.Clear();
                        Items[10].Options.Add(Settings.JoyKey_P1_ButtonLeft);
                        Items[11].Options.Clear();
                        Items[11].Options.Add(Settings.JoyKey_P1_ButtonRight);
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
                Items[0].SelectedOptionIndex = Settings.Key_P1_UseJoystick ? 1 : 0;
                useJoystick = Settings.Key_P1_UseJoystick;
                Items[1].Options.Clear();
                if (Settings.Key_P1_JoystickIndex < Joysticks.NumberOfJoysticks)
                {
                    for (int i = 0; i < Joysticks.NumberOfJoysticks; i++)
                    {
                        Items[1].Options.Add(i.ToString());
                    }
                    Items[1].SelectedOptionIndex = Settings.Key_P1_JoystickIndex;
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
            if (!(joyKeys && Settings.Key_P1_UseJoystick))
            {
                Items[2].Options.Clear();
                Items[2].Options.Add(Settings.Key_P1_ButtonA);
                Items[3].Options.Clear();
                Items[3].Options.Add(Settings.Key_P1_ButtonB);
                Items[4].Options.Clear();
                Items[4].Options.Add(Settings.Key_P1_ButtonTurboA);
                Items[5].Options.Clear();
                Items[5].Options.Add(Settings.Key_P1_ButtonTurboB);
                Items[6].Options.Clear();
                Items[6].Options.Add(Settings.Key_P1_ButtonStart);
                Items[7].Options.Clear();
                Items[7].Options.Add(Settings.Key_P1_ButtonSelect);
                Items[8].Options.Clear();
                Items[8].Options.Add(Settings.Key_P1_ButtonUp);
                Items[9].Options.Clear();
                Items[9].Options.Add(Settings.Key_P1_ButtonDown);
                Items[10].Options.Clear();
                Items[10].Options.Add(Settings.Key_P1_ButtonLeft);
                Items[11].Options.Clear();
                Items[11].Options.Add(Settings.Key_P1_ButtonRight);
            }
            else
            {
                Items[2].Options.Clear();
                Items[2].Options.Add(Settings.JoyKey_P1_ButtonA);
                Items[3].Options.Clear();
                Items[3].Options.Add(Settings.JoyKey_P1_ButtonB);
                Items[4].Options.Clear();
                Items[4].Options.Add(Settings.JoyKey_P1_ButtonTurboA);
                Items[5].Options.Clear();
                Items[5].Options.Add(Settings.JoyKey_P1_ButtonTurboB);
                Items[6].Options.Clear();
                Items[6].Options.Add(Settings.JoyKey_P1_ButtonStart);
                Items[7].Options.Clear();
                Items[7].Options.Add(Settings.JoyKey_P1_ButtonSelect);
                Items[8].Options.Clear();
                Items[8].Options.Add(Settings.JoyKey_P1_ButtonUp);
                Items[9].Options.Clear();
                Items[9].Options.Add(Settings.JoyKey_P1_ButtonDown);
                Items[10].Options.Clear();
                Items[10].Options.Add(Settings.JoyKey_P1_ButtonLeft);
                Items[11].Options.Clear();
                Items[11].Options.Add(Settings.JoyKey_P1_ButtonRight);
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
            public MenuItem_ApplyAndBack(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                if (page.Items[0].Options.Count == 1)
                    Settings.Key_P1_UseJoystick = false;
                else
                    Settings.Key_P1_UseJoystick = page.Items[0].SelectedOptionIndex == 1;
                Settings.Key_P1_JoystickIndex = page.Items[1].SelectedOptionIndex;
                if (!Settings.Key_P1_UseJoystick)
                {
                    Settings.Key_P1_ButtonA = page.Items[2].Options[0];
                    Settings.Key_P1_ButtonB = page.Items[3].Options[0];
                    Settings.Key_P1_ButtonTurboA = page.Items[4].Options[0];
                    Settings.Key_P1_ButtonTurboB = page.Items[5].Options[0];
                    Settings.Key_P1_ButtonStart = page.Items[6].Options[0];
                    Settings.Key_P1_ButtonSelect = page.Items[7].Options[0];
                    Settings.Key_P1_ButtonUp = page.Items[8].Options[0];
                    Settings.Key_P1_ButtonDown = page.Items[9].Options[0];
                    Settings.Key_P1_ButtonLeft = page.Items[10].Options[0];
                    Settings.Key_P1_ButtonRight = page.Items[11].Options[0];
                }
                else
                {
                    Settings.JoyKey_P1_ButtonA = page.Items[2].Options[0];
                    Settings.JoyKey_P1_ButtonB = page.Items[3].Options[0];
                    Settings.JoyKey_P1_ButtonTurboA = page.Items[4].Options[0];
                    Settings.JoyKey_P1_ButtonTurboB = page.Items[5].Options[0];
                    Settings.JoyKey_P1_ButtonStart = page.Items[6].Options[0];
                    Settings.JoyKey_P1_ButtonSelect = page.Items[7].Options[0];
                    Settings.JoyKey_P1_ButtonUp = page.Items[8].Options[0];
                    Settings.JoyKey_P1_ButtonDown = page.Items[9].Options[0];
                    Settings.JoyKey_P1_ButtonLeft = page.Items[10].Options[0];
                    Settings.JoyKey_P1_ButtonRight = page.Items[11].Options[0];
                }
                Program.InitializeInput();
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
            public MenuItem_ResetDefaults(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.Items[0].SelectedOptionIndex = 0;
                page.Items[1].SelectedOptionIndex = 0;
                page.useJoystick = false;
                page.Items[2].Options.Clear();
                page.Items[2].Options.Add("X");
                page.Items[3].Options.Clear();
                page.Items[3].Options.Add("Z");
                page.Items[4].Options.Clear();
                page.Items[4].Options.Add("A");
                page.Items[5].Options.Clear();
                page.Items[5].Options.Add("S");
                page.Items[6].Options.Clear();
                page.Items[6].Options.Add("V");
                page.Items[7].Options.Clear();
                page.Items[7].Options.Add("C");
                page.Items[8].Options.Clear();
                page.Items[8].Options.Add("UpArrow");
                page.Items[9].Options.Clear();
                page.Items[9].Options.Add("DownArrow");
                page.Items[10].Options.Clear();
                page.Items[10].Options.Add("LeftArrow");
                page.Items[11].Options.Clear();
                page.Items[11].Options.Add("RightArrow");
            }
        }

        [MenuItemAttribute("Button A", true, 0, new string[0], false)]
        class MenuItem_A:MenuItem
        {
            public MenuItem_A(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button B", true, 0, new string[0], false)]
        class MenuItem_B:MenuItem
        {
            public MenuItem_B(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button TurboA", true, 0, new string[0], false)]
        class MenuItem_TurboA:MenuItem
        {
            public MenuItem_TurboA(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button TurboB", true, 0, new string[0], false)]
        class MenuItem_TurboB:MenuItem
        {
            public MenuItem_TurboB(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button Start", true, 0, new string[0], false)]
        class MenuItem_Start:MenuItem
        {
            public MenuItem_Start(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button Select", true, 0, new string[0], false)]
        class MenuItem_Select:MenuItem
        {
            public MenuItem_Select(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button Up", true, 0, new string[0], false)]
        class MenuItem_Up:MenuItem
        {
            public MenuItem_Up(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button Down", true, 0, new string[0], false)]
        class MenuItem_Down:MenuItem
        {
            public MenuItem_Down(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button Left", true, 0, new string[0], false)]
        class MenuItem_Left:MenuItem
        {
            public MenuItem_Left(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Button Right", true, 0, new string[0], false)]
        class MenuItem_Right:MenuItem
        {
            public MenuItem_Right(Room_Input_PlayerOne page)
            {
                this.page = page;
            }

            Room_Input_PlayerOne page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }
    }
}

