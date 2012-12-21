/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Renderers;
namespace MyNes
{
    public partial class ISC_General : InputSettingsControl
    {
        public ISC_General()
        {
            InitializeComponent();
            checkBox_4players.Checked = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Connect4Players;
            checkBox_zapper.Checked = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].ConnectZapper;
        }
        public override void SaveSettings()
        {
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Connect4Players = checkBox_4players.Checked;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].ConnectZapper = checkBox_zapper.Checked;
        }
        public override void DefaultSettings()
        {
            checkBox_4players.Checked = false;
            checkBox_zapper.Checked = false;
        }
    }
}
