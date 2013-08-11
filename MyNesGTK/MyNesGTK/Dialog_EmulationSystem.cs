//
//  Dialog_EmulationSystem.cs
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
using MyNes.Core;
using MyNes.Core.Types;

namespace MyNesGTK
{
	public partial class Dialog_EmulationSystem : Gtk.Dialog
	{
		public Dialog_EmulationSystem ()
		{
			this.Build ();
			// load
			switch (MainClass.Settings.EmulationSystem) {
			case EmulationSystem.AUTO:
				combobox1.Active = 0;
				break;
			case EmulationSystem.NTSC:
				combobox1.Active = 1;
				break;
			case EmulationSystem.PALB:
				combobox1.Active = 2;
				break;
			case EmulationSystem.DENDY:
				combobox1.Active = 3;
				break;
			}
		}

		public void SaveSettings ()
		{
			switch (combobox1.Active) {
			case 0:
				MainClass.Settings.EmulationSystem = EmulationSystem.AUTO;
				break;
			case 1:
				MainClass.Settings.EmulationSystem = EmulationSystem.NTSC;
				break;
			case 2:
				MainClass.Settings.EmulationSystem = EmulationSystem.PALB;
				break;
			case 3:
				MainClass.Settings.EmulationSystem = EmulationSystem.DENDY;
				break;
			}
		}
	}
}

