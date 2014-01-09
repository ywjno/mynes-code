/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
    public partial class ISC_Shortcuts : InputSettingsControl
    {
        public ISC_Shortcuts()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void LoadSettings()
        {
            textBox_hardReset.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.HardReset;
            textBox_loadState.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.LoadState;
            textBox_saveState.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SaveState;
            textBox_shutdownEmu.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ShutdownEmulation;
            textBox_slot0.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot0;
            textBox_slot1.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot1;
            textBox_slot2.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot2;
            textBox_slot3.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot3;
            textBox_slot4.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot4;
            textBox_slot5.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot5;
            textBox_slot6.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot6;
            textBox_slot7.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot7;
            textBox_slot8.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot8;
            textBox_slot9.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot9;
            textBox_softReset.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SoftReset;
            textBox_takeSnapshot.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.TakeSnapshot;
            textBox_toggleLimiter.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ToggleLimiter;
            textBox_togglePause.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.PauseEmulation;
            textBox_resumeEmu.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ResumeEmulation;
            textBox_fullscreen.Text = RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.Fullscreen;
        }
        public override void SaveSettings()
        {
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.HardReset = textBox_hardReset.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.LoadState = textBox_loadState.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SaveState = textBox_saveState.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ShutdownEmulation = textBox_shutdownEmu.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot0 = textBox_slot0.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot1 = textBox_slot1.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot2 = textBox_slot2.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot3 = textBox_slot3.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot4 = textBox_slot4.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot5 = textBox_slot5.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot6 = textBox_slot6.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot7 = textBox_slot7.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot8 = textBox_slot8.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SelecteSlot9 = textBox_slot9.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.SoftReset = textBox_softReset.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.TakeSnapshot = textBox_takeSnapshot.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ToggleLimiter = textBox_toggleLimiter.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.PauseEmulation = textBox_togglePause.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.ResumeEmulation = textBox_resumeEmu.Text;
            RenderersCore.SettingsManager.Settings.Controls_ProfilesCollection[RenderersCore.SettingsManager.Settings.Controls_ProfileIndex].Shortcuts.Fullscreen = textBox_fullscreen.Text;
        }
        public override void OnSettingsSelect()
        {
            LoadSettings();
        }
        public override void DefaultSettings()
        {
            textBox_resumeEmu.Text = "Keyboard.F1";
            textBox_togglePause.Text = "Keyboard.F2";
            textBox_softReset.Text = "Keyboard.F3";
            textBox_hardReset.Text = "Keyboard.F4";
            textBox_takeSnapshot.Text = "Keyboard.F5";
            textBox_saveState.Text = "Keyboard.F6";
            textBox_toggleLimiter.Text = "Keyboard.F7";
            textBox_loadState.Text = "Keyboard.F9";
            textBox_fullscreen.Text = "Keyboard.F12";
            textBox_slot0.Text = "Keyboard.D0";
            textBox_slot1.Text = "Keyboard.D1";
            textBox_slot2.Text = "Keyboard.D2";
            textBox_slot3.Text = "Keyboard.D3";
            textBox_slot4.Text = "Keyboard.D4";
            textBox_slot5.Text = "Keyboard.D5";
            textBox_slot6.Text = "Keyboard.D6";
            textBox_slot7.Text = "Keyboard.D7";
            textBox_slot8.Text = "Keyboard.D8";
            textBox_slot9.Text = "Keyboard.D9";
            textBox_shutdownEmu.Text = "Keyboard.Escape";
        }
        private void ChangeControlMapping(TextBox button)
        {
            if (RenderersCore.SettingsManager.Settings.Controls_ProfileIndex == 0)
            {
                MessageBox.Show("You can't change mapping of default profile. To do so, select profiles page, add new profile then select this page again to change mapping.");
                return;
            }
            FormKey kk = new FormKey();

            kk.Location = new Point(this.Parent.Parent.Parent.Location.X + this.Parent.Parent.Location.X + button.Location.X,
                this.Parent.Parent.Parent.Location.Y + this.Parent.Parent.Location.Y + button.Location.Y + 30);

            if (kk.ShowDialog(this) == DialogResult.OK)
                button.Text = kk.InputName;

            SaveSettings();
        }

        private void textBox_hardReset_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_hardReset);
        }
        private void textBox_hardReset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_hardReset);
        }
        private void textBox_softReset_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_softReset);
        }
        private void textBox_softReset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_softReset);
        }
        private void textBox_saveState_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_saveState);
        }
        private void textBox_saveState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_saveState);
        }
        private void textBox_loadState_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_loadState);
        }
        private void textBox_loadState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_loadState);
        }
        private void textBox_shutdownEmu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_shutdownEmu);
        }
        private void textBox_shutdownEmu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_shutdownEmu);
        }
        private void textBox_takeSnapshot_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_takeSnapshot);
        }
        private void textBox_takeSnapshot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_takeSnapshot);
        }
        private void textBox_toggleLimiter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_toggleLimiter);
        }
        private void textBox_toggleLimiter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_toggleLimiter);
        }
        private void textBox_togglePause_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_togglePause);
        }
        private void textBox_togglePause_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_togglePause);
        }
        private void textBox_slot0_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot0);
        }
        private void textBox_slot0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot0);
        }
        private void textBox_slot1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot1);
        }
        private void textBox_slot1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot1);
        }
        private void textBox_slot2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot2);
        }
        private void textBox_slot2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot2);
        }
        private void textBox_slot3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot3);
        }
        private void textBox_slot3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot3);
        }
        private void textBox_slot4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot4);
        }
        private void textBox_slot4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot4);
        }
        private void textBox_slot5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot5);
        }
        private void textBox_slot5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot5);
        }
        private void textBox_slot6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot6);
        }
        private void textBox_slot6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot6);
        }
        private void textBox_slot7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot7);
        }
        private void textBox_slot7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot7);
        }
        private void textBox_slot8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot8);
        }
        private void textBox_slot8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot8);
        }
        private void textBox_slot9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_slot9);
        }
        private void textBox_slot9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_slot9);
        }
        private void textBox_resumeEmu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_resumeEmu);
        }
        private void textBox_resumeEmu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_resumeEmu);
        }
        private void textBox_fullscreen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeControlMapping(textBox_fullscreen);
        }
        private void textBox_fullscreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                ChangeControlMapping(textBox_fullscreen);
        }
    }
}
