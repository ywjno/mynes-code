//
//  Dialog_RendererSelect.cs
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
using Gtk;
using MyNes.Renderers;

namespace MyNesGTK
{
	public partial class Dialog_RendererSelect : Gtk.Dialog
	{
		public Dialog_RendererSelect ()
		{
			this.Build ();
			foreach (IRenderer renderer in RenderersCore.AvailableRenderers) {
				combobox1.AppendText (renderer.Name);
			}
			// select renderer
			combobox1.Active = MainClass.Settings.CurrentRendererIndex;
		}

		private void ShowDescription (string text)
		{
			foreach (IRenderer renderer in RenderersCore.AvailableRenderers) {
				if (renderer.Name == text) {
					// show descreption
					textview1.Buffer.Text = renderer.Description;
					textview2.Buffer.Text = renderer.CopyrightMessage;
					break;
				}
			}

		}

		protected void OnCombobox1Changed (object sender, EventArgs e)
		{
			ShowDescription (combobox1.ActiveText);
		}

		public void SaveSettings ()
		{
			MainClass.Settings.CurrentRendererIndex = combobox1.Active;
			MainClass.SaveSettings ();
		}
	}
}

