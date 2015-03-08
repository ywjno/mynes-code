//
//  Dialog_AddGameGenieCode.cs
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

namespace MyNesGTK
{
    public partial class Dialog_AddGameGenieCode : Gtk.Dialog
    {
        public Dialog_AddGameGenieCode()
        {
            this.Build();
            gameGenie = new GameGenie();
        }

        void ShowValues()
        {
            if (entry_code.Text.Length == 6)
            {
                entry_address.Text = string.Format("{0:X4}", gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(entry_code.Text), 6));
                entry_value.Text = string.Format("{0:X2}", gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(entry_code.Text), 6));
                entry_coompare.Text = "00";
                buttonOk.Visible = true;
            }
            else if (entry_code.Text.Length == 8)
            {
                //8 code length
                entry_address.Text = string.Format("{0:X4}", gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(entry_code.Text), 8));
                entry_value.Text = string.Format("{0:X2}", gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(entry_code.Text), 8));
                entry_coompare.Text = string.Format("{0:X2}", gameGenie.GetGGCompareValue(gameGenie.GetCodeAsHEX(entry_code.Text)));
                buttonOk.Visible = true;
            }
            else
            {
                //code incomplete
                entry_address.Text = "ERROR";
                entry_value.Text = entry_coompare.Text = "ERROR";
                buttonOk.Visible = false;
            }
        }

        GameGenie gameGenie;

        public string CodeEntered
        {
            get
            {
                return entry_code.Text;
            }
        }

        protected void OnButton112Clicked(object sender, EventArgs e)
        {
            if (entry_code.Text.Length < 8)
                entry_code.Text += ((Gtk.Button)sender).Label;
            ShowValues();
        }

        protected void OnButton128Clicked(object sender, EventArgs e)
        {
            if (entry_code.Text.Length > 0)
                entry_code.Text = entry_code.Text.Substring(0, entry_code.Text.Length - 1);
            ShowValues();
        }

        protected void OnButton129Clicked(object sender, EventArgs e)
        {
            entry_code.Text = "";
            ShowValues();
        }

    }
}

