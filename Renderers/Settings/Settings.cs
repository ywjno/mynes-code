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
using MyNes.Core.Types;
namespace MyNes.Renderers
{
    [System.Serializable()]
    public class SettingsData
    {
        public EmulationSystem Emu_EmulationSystem = EmulationSystem.AUTO;

        public string Folders_StateFolder = @".\StateSaves";
        public string Folders_SnapshotsFolder = @".\Snapshots";

        public int Controls_ProfileIndex = 0;
        public ControlProfilesCollection Controls_ProfilesCollection = new ControlProfilesCollection();

        public int Sound_Volume = 0;
        public int Sound_PlaybackFreq = 44100;
        public bool Sound_Enabled = true;
        public int Sound_Latency = 50;

        public int Video_ResIndex = 0;
        public bool Video_ImmediateMode = true;
        public bool Video_HideLines = true;
        public PaletteSettings Video_Palette = new PaletteSettings();
        public bool Video_Fullscreen = false;
        public bool Video_OpenGL = false;
        public string Video_SnapshotFormat = ".png";
        public int Video_StretchMultiply = 2;
        public bool Video_ShowFPS = false;
        public bool Video_ShowNotifications = true;
        public bool Video_KeepAspectRationOnStretch = true;
    }
}
