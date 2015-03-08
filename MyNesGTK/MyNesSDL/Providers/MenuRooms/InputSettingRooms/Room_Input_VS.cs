//
//  Room_Input_VS.cs
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
    [RoomBaseAttributes("Input Settings - VS Unisystem DIP")]
    public class Room_Input_VS:RoomBase
    {
        public Room_Input_VS()
            : base()
        {
            Items.Add(new MenuItem_UseJoystick());
            Items.Add(new MenuItem_JoystickIndex());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_CreditServiceButton(this));
            Items.Add(new MenuItem_DIPSwitch1(this));
            Items.Add(new MenuItem_DIPSwitch2(this));
            Items.Add(new MenuItem_DIPSwitch3(this));
            Items.Add(new MenuItem_DIPSwitch4(this));
            Items.Add(new MenuItem_DIPSwitch5(this));
            Items.Add(new MenuItem_DIPSwitch6(this));
            Items.Add(new MenuItem_DIPSwitch7(this));
            Items.Add(new MenuItem_DIPSwitch8(this));
            Items.Add(new MenuItem_CreditLeftCoinSlot(this));
            Items.Add(new MenuItem_CreditRightCoinSlot(this));

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
                        Items[2].Options.Add(Settings.Key_VS_CreditServiceButton);
                        Items[3].Options.Clear();
                        Items[3].Options.Add(Settings.Key_VS_DIPSwitch1);
                        Items[4].Options.Clear();
                        Items[4].Options.Add(Settings.Key_VS_DIPSwitch2);
                        Items[5].Options.Clear();
                        Items[5].Options.Add(Settings.Key_VS_DIPSwitch3);
                        Items[6].Options.Clear();
                        Items[6].Options.Add(Settings.Key_VS_DIPSwitch4);
                        Items[7].Options.Clear();
                        Items[7].Options.Add(Settings.Key_VS_DIPSwitch5);
                        Items[8].Options.Clear();
                        Items[8].Options.Add(Settings.Key_VS_DIPSwitch6);
                        Items[9].Options.Clear();
                        Items[9].Options.Add(Settings.Key_VS_DIPSwitch7);
                        Items[10].Options.Clear();
                        Items[10].Options.Add(Settings.Key_VS_DIPSwitch8);
                        Items[11].Options.Clear();
                        Items[11].Options.Add(Settings.Key_VS_CreditLeftCoinSlot);
                        Items[12].Options.Clear();
                        Items[12].Options.Add(Settings.Key_VS_CreditRightCoinSlot);
                    }
                    else
                    {
                        useJoystick = true;
                        Items[2].Options.Clear();
                        Items[2].Options.Add(Settings.JoyKey_VS_CreditServiceButton);
                        Items[3].Options.Clear();
                        Items[3].Options.Add(Settings.JoyKey_VS_DIPSwitch1);
                        Items[4].Options.Clear();
                        Items[4].Options.Add(Settings.JoyKey_VS_DIPSwitch2);
                        Items[5].Options.Clear();
                        Items[5].Options.Add(Settings.JoyKey_VS_DIPSwitch3);
                        Items[6].Options.Clear();
                        Items[6].Options.Add(Settings.JoyKey_VS_DIPSwitch4);
                        Items[7].Options.Clear();
                        Items[7].Options.Add(Settings.JoyKey_VS_DIPSwitch5);
                        Items[8].Options.Clear();
                        Items[8].Options.Add(Settings.JoyKey_VS_DIPSwitch6);
                        Items[9].Options.Clear();
                        Items[9].Options.Add(Settings.JoyKey_VS_DIPSwitch7);
                        Items[10].Options.Clear();
                        Items[10].Options.Add(Settings.JoyKey_VS_DIPSwitch8);
                        Items[11].Options.Clear();
                        Items[11].Options.Add(Settings.JoyKey_VS_CreditLeftCoinSlot);
                        Items[12].Options.Clear();
                        Items[12].Options.Add(Settings.JoyKey_VS_CreditRightCoinSlot);
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
                Items[0].SelectedOptionIndex = Settings.Key_VS_UseJoystick ? 1 : 0;
                useJoystick = Settings.Key_P4_UseJoystick;
                Items[1].Options.Clear();
                if (Settings.Key_VS_JoystickIndex < Joysticks.NumberOfJoysticks)
                {
                    for (int i = 0; i < Joysticks.NumberOfJoysticks; i++)
                    {
                        Items[1].Options.Add(i.ToString());
                    }
                    Items[1].SelectedOptionIndex = Settings.Key_VS_JoystickIndex;
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
            if (!(joyKeys && Settings.Key_VS_UseJoystick))
            {
                Items[2].Options.Clear();
                Items[2].Options.Add(Settings.Key_VS_CreditServiceButton);
                Items[3].Options.Clear();
                Items[3].Options.Add(Settings.Key_VS_DIPSwitch1);
                Items[4].Options.Clear();
                Items[4].Options.Add(Settings.Key_VS_DIPSwitch2);
                Items[5].Options.Clear();
                Items[5].Options.Add(Settings.Key_VS_DIPSwitch3);
                Items[6].Options.Clear();
                Items[6].Options.Add(Settings.Key_VS_DIPSwitch4);
                Items[7].Options.Clear();
                Items[7].Options.Add(Settings.Key_VS_DIPSwitch5);
                Items[8].Options.Clear();
                Items[8].Options.Add(Settings.Key_VS_DIPSwitch6);
                Items[9].Options.Clear();
                Items[9].Options.Add(Settings.Key_VS_DIPSwitch7);
                Items[10].Options.Clear();
                Items[10].Options.Add(Settings.Key_VS_DIPSwitch8);
                Items[11].Options.Clear();
                Items[11].Options.Add(Settings.Key_VS_CreditLeftCoinSlot);
                Items[12].Options.Clear();
                Items[12].Options.Add(Settings.Key_VS_CreditRightCoinSlot);
            }
            else
            {
                Items[2].Options.Clear();
                Items[2].Options.Add(Settings.JoyKey_VS_CreditServiceButton);
                Items[3].Options.Clear();
                Items[3].Options.Add(Settings.JoyKey_VS_DIPSwitch1);
                Items[4].Options.Clear();
                Items[4].Options.Add(Settings.JoyKey_VS_DIPSwitch2);
                Items[5].Options.Clear();
                Items[5].Options.Add(Settings.JoyKey_VS_DIPSwitch3);
                Items[6].Options.Clear();
                Items[6].Options.Add(Settings.JoyKey_VS_DIPSwitch4);
                Items[7].Options.Clear();
                Items[7].Options.Add(Settings.JoyKey_VS_DIPSwitch5);
                Items[8].Options.Clear();
                Items[8].Options.Add(Settings.JoyKey_VS_DIPSwitch6);
                Items[9].Options.Clear();
                Items[9].Options.Add(Settings.JoyKey_VS_DIPSwitch7);
                Items[10].Options.Clear();
                Items[10].Options.Add(Settings.JoyKey_VS_DIPSwitch8);
                Items[11].Options.Clear();
                Items[11].Options.Add(Settings.JoyKey_VS_CreditLeftCoinSlot);
                Items[12].Options.Clear();
                Items[12].Options.Add(Settings.JoyKey_VS_CreditRightCoinSlot);
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
            public MenuItem_ApplyAndBack(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                if (page.Items[0].Options.Count == 1)
                    Settings.Key_VS_UseJoystick = false;
                else
                    Settings.Key_VS_UseJoystick = page.Items[0].SelectedOptionIndex == 1;
                Settings.Key_VS_JoystickIndex = page.Items[1].SelectedOptionIndex;
                if (!Settings.Key_VS_UseJoystick)
                {
                    Settings.Key_VS_CreditServiceButton = page.Items[2].Options[0];
                    Settings.Key_VS_DIPSwitch1 = page.Items[3].Options[0];
                    Settings.Key_VS_DIPSwitch2 = page.Items[4].Options[0];
                    Settings.Key_VS_DIPSwitch3 = page.Items[5].Options[0];
                    Settings.Key_VS_DIPSwitch4 = page.Items[6].Options[0];
                    Settings.Key_VS_DIPSwitch5 = page.Items[7].Options[0];
                    Settings.Key_VS_DIPSwitch6 = page.Items[8].Options[0];
                    Settings.Key_VS_DIPSwitch7 = page.Items[9].Options[0];
                    Settings.Key_VS_DIPSwitch8 = page.Items[10].Options[0];
                    Settings.Key_VS_CreditLeftCoinSlot = page.Items[11].Options[0];
                    Settings.Key_VS_CreditRightCoinSlot = page.Items[12].Options[0];
                }
                else
                {
                    Settings.JoyKey_VS_CreditServiceButton = page.Items[2].Options[0];
                    Settings.JoyKey_VS_DIPSwitch1 = page.Items[3].Options[0];
                    Settings.JoyKey_VS_DIPSwitch2 = page.Items[4].Options[0];
                    Settings.JoyKey_VS_DIPSwitch3 = page.Items[5].Options[0];
                    Settings.JoyKey_VS_DIPSwitch4 = page.Items[6].Options[0];
                    Settings.JoyKey_VS_DIPSwitch5 = page.Items[7].Options[0];
                    Settings.JoyKey_VS_DIPSwitch6 = page.Items[8].Options[0];
                    Settings.JoyKey_VS_DIPSwitch7 = page.Items[9].Options[0];
                    Settings.JoyKey_VS_DIPSwitch8 = page.Items[10].Options[0];
                    Settings.JoyKey_VS_CreditLeftCoinSlot = page.Items[11].Options[0];
                    Settings.JoyKey_VS_CreditRightCoinSlot = page.Items[12].Options[0];
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
            public MenuItem_ResetDefaults(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.Items[0].SelectedOptionIndex = 0;
                page.Items[1].SelectedOptionIndex = 0;
                page.useJoystick = false;
                page.Items[2].Options.Clear();
                page.Items[2].Options.Add("End");
                page.Items[3].Options.Clear();
                page.Items[3].Options.Add("Keypad1");
                page.Items[4].Options.Clear();
                page.Items[4].Options.Add("Keypad2");
                page.Items[5].Options.Clear();
                page.Items[5].Options.Add("Keypad3");
                page.Items[6].Options.Clear();
                page.Items[6].Options.Add("Keypad4");
                page.Items[7].Options.Clear();
                page.Items[7].Options.Add("Keypad5");
                page.Items[8].Options.Clear();
                page.Items[8].Options.Add("Keypad6");
                page.Items[9].Options.Clear();
                page.Items[9].Options.Add("Keypad7");
                page.Items[10].Options.Clear();
                page.Items[10].Options.Add("Keypad8");
                page.Items[11].Options.Clear();
                page.Items[11].Options.Add("Insert");
                page.Items[12].Options.Clear();
                page.Items[12].Options.Add("Home");
            }
        }

        [MenuItemAttribute("Credit Service Button", true, 0, new string[0], false)]
        class MenuItem_CreditServiceButton:MenuItem
        {
            public MenuItem_CreditServiceButton(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch1", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch1:MenuItem
        {
            public MenuItem_DIPSwitch1(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch2", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch2:MenuItem
        {
            public MenuItem_DIPSwitch2(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch3", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch3:MenuItem
        {
            public MenuItem_DIPSwitch3(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch4", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch4:MenuItem
        {
            public MenuItem_DIPSwitch4(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch5", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch5:MenuItem
        {
            public MenuItem_DIPSwitch5(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch6", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch6:MenuItem
        {
            public MenuItem_DIPSwitch6(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch7", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch7:MenuItem
        {
            public MenuItem_DIPSwitch7(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("DIPSwitch8", true, 0, new string[0], false)]
        class MenuItem_DIPSwitch8:MenuItem
        {
            public MenuItem_DIPSwitch8(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Credit Left Coin Slot", true, 0, new string[0], false)]
        class MenuItem_CreditLeftCoinSlot:MenuItem
        {
            public MenuItem_CreditLeftCoinSlot(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }

        [MenuItemAttribute("Credit Right Coin Slot", true, 0, new string[0], false)]
        class MenuItem_CreditRightCoinSlot:MenuItem
        {
            public MenuItem_CreditRightCoinSlot(Room_Input_VS page)
            {
                this.page = page;
            }

            Room_Input_VS page;

            public override void Execute()
            {
                page.LockKeysToInput();
                this.Options = new List<string>();
                this.Options.Add("<Press a key or press Enter to cancel>");
            }
        }
    }
}

