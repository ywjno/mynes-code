//
//  Settings.cs
//
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
//
//  Copyright (c) 2009 - 2013 Ala Ibrahim Hadid 
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
using System.Drawing;
using MyNes.Core;
using MyNes.Core.Types;

namespace MyNesGTK
{
	[Serializable()]
	public class Settings
	{
		public int CurrentRendererIndex = 0;
		public int win_x = 10;
		public int win_y = 10;
		public int win_width = 800;
		public int win_height = 600;
		public string CurrentFilePath = "";
		public EmulationSystem EmulationSystem = EmulationSystem.AUTO;
	}
}

