//
//  MenuItem_BackToMainMenu.cs
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

namespace MyNesSDL
{
    [MenuItemAttribute("Back To Main Menu", false, 0, new string[0], false)]
    public class MenuItem_BackToMainMenu:MenuItem
    {
        public MenuItem_BackToMainMenu()
            : base()
        {
        }


        public override void Execute()
        {
            Program.SelectRoom("main menu");
        }

    }
}

