//
//  Room_AudioSettings.cs
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
    [RoomBaseAttributes("Audio Settings")]
    public class Room_AudioSettings:RoomBase
    {
        public Room_AudioSettings()
            : base()
        {
            Items.Add(new MenuItem_EnablePlayback());
            Items.Add(new MenuItem_Volume());
            for (int i = 0; i < 101; i++)
            {
                Items[Items.Count - 1].Options.Add(i + " %");
            }
            Items.Add(new MenuItem_Frequency());

            Items.Add(new MenuItem_SQ1Enabled());
            Items.Add(new MenuItem_SQ2Enabled());
            Items.Add(new MenuItem_DMCEnabled());
            Items.Add(new MenuItem_TRLEnabled());
            Items.Add(new MenuItem_NOZEnabled());
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_ApplySettings(this));
            Items.Add(new MenuItem_DiscardSettings());
        }

        public override void OnOpen()
        {
            base.OnOpen();
            Items[0].SelectedOptionIndex = Settings.Audio_PlaybackEnabled ? 1 : 0;
            Items[1].SelectedOptionIndex = Settings.Audio_PlaybackVolume;
            Items[2].SelectedOptionIndex = Settings.Audio_PlaybackFrequency == 44100 ? 0 : 1;
            Items[3].SelectedOptionIndex = Settings.Audio_playback_sq1_enabled ? 1 : 0;
            Items[4].SelectedOptionIndex = Settings.Audio_playback_sq2_enabled ? 1 : 0;
            Items[5].SelectedOptionIndex = Settings.Audio_playback_dmc_enabled ? 1 : 0;
            Items[6].SelectedOptionIndex = Settings.Audio_playback_trl_enabled ? 1 : 0;
            Items[7].SelectedOptionIndex = Settings.Audio_playback_noz_enabled ? 1 : 0;
        }

        public override void OnTabResume()
        {
            Program.SelectRoom("settings");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        [MenuItemAttribute("Apply And Back", false, 0, new string[0], false)]
        class MenuItem_ApplySettings:MenuItem
        {
            public MenuItem_ApplySettings(Room_AudioSettings audioPage)
                : base()
            {
                this.audioPage = audioPage;
            }

            private Room_AudioSettings audioPage;

            public override void Execute()
            {
                Settings.Audio_PlaybackEnabled = audioPage.Items[0].SelectedOptionIndex == 1;
                Settings.Audio_PlaybackVolume = audioPage.Items[1].SelectedOptionIndex;
                Settings.Audio_PlaybackFrequency = audioPage.Items[2].SelectedOptionIndex == 0 ? 44100 : 48000;
                Settings.Audio_playback_sq1_enabled = audioPage.Items[3].SelectedOptionIndex == 1;
                Settings.Audio_playback_sq2_enabled = audioPage.Items[4].SelectedOptionIndex == 1;
                Settings.Audio_playback_dmc_enabled = audioPage.Items[5].SelectedOptionIndex == 1;
                Settings.Audio_playback_trl_enabled = audioPage.Items[6].SelectedOptionIndex == 1;
                Settings.Audio_playback_noz_enabled = audioPage.Items[7].SelectedOptionIndex == 1;

                // Apply on provider !!
                Program.AUDIO.Enabled = Settings.Audio_PlaybackEnabled;
                Program.AUDIO.Volume = Settings.Audio_PlaybackVolume;

                NesEmu.SetupSoundPlayback(Program.AUDIO, 
                    Settings.Audio_PlaybackEnabled, 
                    Settings.Audio_PlaybackFrequency);
                NesEmu.audio_playback_dmc_enabled = Settings.Audio_playback_dmc_enabled;
                NesEmu.audio_playback_noz_enabled = Settings.Audio_playback_noz_enabled;
                NesEmu.audio_playback_sq1_enabled = Settings.Audio_playback_sq1_enabled;
                NesEmu.audio_playback_sq2_enabled = Settings.Audio_playback_sq2_enabled;
                NesEmu.audio_playback_trl_enabled = Settings.Audio_playback_trl_enabled;

                Settings.SaveSettings();
                Program.SelectRoom("settings");
            }
        }

        [MenuItemAttribute("Discard And Back", false, 0, new string[0], false)]
        class MenuItem_DiscardSettings:MenuItem
        {
            public override void Execute()
            {
                Program.SelectRoom("settings");
            }
        }

        [MenuItemAttribute("Enable Sound Playback", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_EnablePlayback:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Volume", true, 0, new string[0], false)]
        class MenuItem_Volume:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Frequency (Restart Required)", true, 0, new string[]{ "44100", "48000" }, false)]
        class MenuItem_Frequency:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Channel DMC Enabled", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_DMCEnabled:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Channel Square 1 Enabled", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_SQ1Enabled:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Channel Square 2 Enabled", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_SQ2Enabled:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Channel Triangle Enabled", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_TRLEnabled:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("Channel Noise Enabled", true, 0, new string[]{ "NO", "YES"  }, false)]
        class MenuItem_NOZEnabled:MenuItem
        {
            public override void Execute()
            {
            }
        }
    }
}

