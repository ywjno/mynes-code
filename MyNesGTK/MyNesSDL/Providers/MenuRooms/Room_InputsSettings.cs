//
//  Room_InputsSettings.cs
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
    [RoomBaseAttributes("Input Settings")]
    public class Room_InputsSettings:RoomBase
    {
        public Room_InputsSettings()
            : base()
        {
            Items.Add(new MenuItem_Input_Shortcuts());
            Items.Add(new MenuItem_Input_PlayerOne());
            Items.Add(new MenuItem_Input_PlayerTwo());
            Items.Add(new MenuItem_Input_PlayerThree());
            Items.Add(new MenuItem_Input_PlayerFour());
            Items.Add(new MenuItem_Input_VS());
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_Back());
        }

        public override void OnTabResume()
        {
            Program.SelectRoom("settings");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        [MenuItemAttribute("Shortcuts", false, 0, new string[0], false)]
        class MenuItem_Input_Shortcuts:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings - shortcuts");
            }
        }

        [MenuItemAttribute("Player One", false, 0, new string[0], false)]
        class MenuItem_Input_PlayerOne:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings - player one");
            }
        }

        [MenuItemAttribute("Player Two", false, 0, new string[0], false)]
        class MenuItem_Input_PlayerTwo:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings - player two");
            }
        }

        [MenuItemAttribute("Player Three", false, 0, new string[0], false)]
        class MenuItem_Input_PlayerThree:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings - player three");
            }
        }

        [MenuItemAttribute("Player Four", false, 0, new string[0], false)]
        class MenuItem_Input_PlayerFour:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings - player four");
            }
        }

        [MenuItemAttribute("VS Unisystem PID", false, 0, new string[0], false)]
        class MenuItem_Input_VS:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("input settings - vs unisystem dip");
            }
        }

        [MenuItemAttribute("Back", false, 0, new string[0], false)]
        class MenuItem_Back:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("settings");
            }
        }
    }
}

