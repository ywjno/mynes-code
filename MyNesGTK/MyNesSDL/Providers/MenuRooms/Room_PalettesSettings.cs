//
//  Room_PalettesSettings.cs
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
    [RoomBaseAttributes("Palettes Settings")]
    public class Room_PalettesSettings:RoomBase
    {
        public Room_PalettesSettings()
            : base()
        {
            Items.Add(new MenuItem_PaletteSelection());
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_NTSCBrightness());
            for (double i = 500; i < 2001; i += 10)// 0.5 -> 2.0
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_NTSCContrast());
            for (double i = 500; i < 2001; i += 10)// 0.5 -> 2.0
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_NTSCGamma());
            for (double i = 1000; i < 2501; i += 10)// 1.0 -> 2.5
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_NTSCHue());
            for (double i = -1000; i < 1001; i += 10)// - 1.0 -> 1.0
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_NTSCSaturation());
            for (double i = 0; i < 5001; i += 10)// 0.0 -> 5
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items[Items.Count - 1].SpaceAfter = true;
            Items.Add(new MenuItem_PALBBrightness());
            for (double i = 500; i < 2001; i += 10)// 0.5 -> 2.0
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_PALBContrast());
            for (double i = 500; i < 2001; i += 10)// 0.5 -> 2.0
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_PALBGamma());
            for (double i = 1000; i < 2501; i += 10)// 1.0 -> 2.5
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_PALBHue());
            for (double i = -1000; i < 1001; i += 10)// - 1.0 -> 1.0
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items.Add(new MenuItem_PALBSaturation());
            for (double i = 0; i < 5001; i += 10)// 0.0 -> 5
            {
                Items[Items.Count - 1].Options.Add((i / 1000).ToString());
            }
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_ResetToDefaults(this));
            Items[Items.Count - 1].SpaceAfter = true;

            Items.Add(new MenuItem_ApplySettings(this));
            Items.Add(new MenuItem_DiscardSettings());
        }

        public override void OnOpen()
        {
            NesEmu.EmulationPaused = false;
            // Palette selection
            if (Settings.Palette_AutoSelect)
                Items[0].SelectedOptionIndex = 0;
            else
            {
                if (Settings.Palette_UseNTSCPalette)
                    Items[0].SelectedOptionIndex = 1;
                else
                    Items[0].SelectedOptionIndex = 2;
            }
            LoadValue(1, Settings.Palette_NTSC_brightness);
            LoadValue(2, Settings.Palette_NTSC_contrast);
            LoadValue(3, Settings.Palette_NTSC_gamma);
            LoadValue(4, Settings.Palette_NTSC_hue_tweak);
            LoadValue(5, Settings.Palette_NTSC_saturation);
            LoadValue(6, Settings.Palette_PALB_brightness);
            LoadValue(7, Settings.Palette_PALB_contrast);
            LoadValue(8, Settings.Palette_PALB_gamma);
            LoadValue(9, Settings.Palette_PALB_hue_tweak);
            LoadValue(10, Settings.Palette_PALB_saturation);
        }

        public override void OnTabResume()
        {
            Program.InitializePalette();// In case we tested the palette ...

            Program.SelectRoom("settings");
            NesEmu.EmulationPaused = true;
            Program.PausedShowMenu = true;
        }

        protected override void OnMenuOptionChanged()
        {
            switch (SelectedMenuIndex)
            {
                case 1:
                    float.TryParse(Items[1].Options[Items[1].SelectedOptionIndex], 
                        out NTSCPaletteGenerator.brightness);
                    TestNTSCPalette();
                    break;
                case 2:
                    float.TryParse(Items[2].Options[Items[2].SelectedOptionIndex],
                        out NTSCPaletteGenerator.contrast);
                    TestNTSCPalette();
                    break;
                case 3:
                    float.TryParse(Items[3].Options[Items[3].SelectedOptionIndex],
                        out NTSCPaletteGenerator.gamma);
                    TestNTSCPalette();
                    break;
                case 4:
                    float.TryParse(Items[4].Options[Items[4].SelectedOptionIndex],
                        out  NTSCPaletteGenerator.hue_tweak);
                    TestNTSCPalette();
                    break;
                case 5:
                    float.TryParse(Items[5].Options[Items[5].SelectedOptionIndex],
                        out   NTSCPaletteGenerator.saturation);
                    TestNTSCPalette();
                    break;
                case 6:
                    float.TryParse(Items[6].Options[Items[6].SelectedOptionIndex],
                        out PALBPaletteGenerator.brightness);
                    TestPALBPalette();
                    break;
                case 7:
                    float.TryParse(Items[7].Options[Items[7].SelectedOptionIndex],
                        out PALBPaletteGenerator.contrast);
                    TestPALBPalette();
                    break;
                case 8:
                    float.TryParse(Items[8].Options[Items[8].SelectedOptionIndex],
                        out  PALBPaletteGenerator.gamma);
                    TestPALBPalette();
                    break;
                case 9:
                    float.TryParse(Items[9].Options[Items[9].SelectedOptionIndex],
                        out PALBPaletteGenerator.hue_tweak);
                    TestPALBPalette();
                    break;
                case 10:
                    float.TryParse(Items[10].Options[Items[10].SelectedOptionIndex],
                        out  PALBPaletteGenerator.saturation);
                    TestPALBPalette();
                    break;
            }
        }

        private void TestNTSCPalette()
        {
            NesEmu.SetPalette(NTSCPaletteGenerator.GeneratePalette());
        }

        private void TestPALBPalette()
        {
            NesEmu.SetPalette(PALBPaletteGenerator.GeneratePalette());
        }

        public void LoadValue(int itemIndex, float Value)
        {
            for (int i = 0; i < Items[itemIndex].Options.Count; i++)
            {
                if (Items[itemIndex].Options[i] == Value.ToString().Replace("f", ""))
                {
                    Items[itemIndex].SelectedOptionIndex = i;
                    break;
                }
            }
        }

        [MenuItemAttribute("Apply And Back", false, 0, new string[0], false)]
        class MenuItem_ApplySettings:MenuItem
        {
            public MenuItem_ApplySettings(Room_PalettesSettings page)
                : base()
            {
                this.page = page;
            }

            private Room_PalettesSettings page;

            public override void Execute()
            {
                NesEmu.EmulationPaused = true;
                switch (page.Items[0].SelectedOptionIndex)
                {
                    case 0:
                        Settings.Palette_AutoSelect = true;
                        break;
                    case 1:
                        Settings.Palette_AutoSelect = false;
                        Settings.Palette_UseNTSCPalette = true;
                        break;
                    case 2:
                        Settings.Palette_AutoSelect = false;
                        Settings.Palette_UseNTSCPalette = false;
                        break;
                }
                float.TryParse(page.Items[1].Options[page.Items[1].SelectedOptionIndex], 
                    out  Settings.Palette_NTSC_brightness);
                float.TryParse(page.Items[2].Options[page.Items[2].SelectedOptionIndex],
                    out  Settings.Palette_NTSC_contrast);
                float.TryParse(page.Items[3].Options[page.Items[3].SelectedOptionIndex],
                    out  Settings.Palette_NTSC_gamma);
                float.TryParse(page.Items[4].Options[page.Items[4].SelectedOptionIndex],
                    out  Settings.Palette_NTSC_hue_tweak);
                float.TryParse(page.Items[5].Options[page.Items[5].SelectedOptionIndex],
                    out  Settings.Palette_NTSC_saturation);
                float.TryParse(page.Items[6].Options[page.Items[6].SelectedOptionIndex],
                    out  Settings.Palette_PALB_brightness);
                float.TryParse(page.Items[7].Options[page.Items[7].SelectedOptionIndex],
                    out  Settings.Palette_PALB_contrast);
                float.TryParse(page.Items[8].Options[page.Items[8].SelectedOptionIndex],
                    out  Settings.Palette_PALB_gamma);
                float.TryParse(page.Items[9].Options[page.Items[9].SelectedOptionIndex],
                    out  Settings.Palette_PALB_hue_tweak);
                float.TryParse(page.Items[10].Options[page.Items[10].SelectedOptionIndex],
                    out  Settings.Palette_PALB_saturation);

                Program.InitializePalette();

                Settings.SaveSettings();
                Program.SelectRoom("settings");
            }
        }

        [MenuItemAttribute("Reset To Defaults", false, 0, new string[0], false)]
        class MenuItem_ResetToDefaults:MenuItem
        {
            public MenuItem_ResetToDefaults(Room_PalettesSettings page)
                : base()
            {
                this.page = page;
            }

            private Room_PalettesSettings page;

            public override void Execute()
            {
                page.Items[0].SelectedOptionIndex = 0;
                page.LoadValue(1, NTSCPaletteGenerator.default_brightness);
                page.LoadValue(2, NTSCPaletteGenerator.default_contrast);
                page.LoadValue(3, NTSCPaletteGenerator.default_gamma);
                page.LoadValue(4, NTSCPaletteGenerator.default_hue_tweak);
                page.LoadValue(5, NTSCPaletteGenerator.default_saturation);
                page.LoadValue(6, NTSCPaletteGenerator.default_brightness);
                page.LoadValue(7, NTSCPaletteGenerator.default_contrast);
                page.LoadValue(8, NTSCPaletteGenerator.default_gamma);
                page.LoadValue(9, NTSCPaletteGenerator.default_hue_tweak);
                page.LoadValue(10, NTSCPaletteGenerator.default_saturation);

                Program.InitializePalette();// In case we tested the palette ...
            }
        }

        [MenuItemAttribute("Discard And Back", false, 0, new string[0], false)]
        class MenuItem_DiscardSettings:MenuItem
        {
            public override void Execute()
            {
                Program.InitializePalette();// In case we tested the palette ...
                NesEmu.EmulationPaused = true;
                Program.SelectRoom("settings");
            }
        }

        [MenuItemAttribute("Palette Selection", true, 0, new string[]{ "AUTO", "Use NTSC Palette Generator", "Use PALB Palette Generator"  }, false)]
        class MenuItem_PaletteSelection:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[NTSC] Brightness", true, 0, new string[0], false)]
        class MenuItem_NTSCBrightness:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[NTSC] Contrast", true, 0, new string[0], false)]
        class MenuItem_NTSCContrast:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[NTSC] Gamma", true, 0, new string[0], false)]
        class MenuItem_NTSCGamma:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[NTSC] Hue", true, 0, new string[0], false)]
        class MenuItem_NTSCHue:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[NTSC] Saturation", true, 0, new string[0], false)]
        class MenuItem_NTSCSaturation:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[PALB] Brightness", true, 0, new string[0], false)]
        class MenuItem_PALBBrightness:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[PALB] Contrast", true, 0, new string[0], false)]
        class MenuItem_PALBContrast:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[PALB] Gamma", true, 0, new string[0], false)]
        class MenuItem_PALBGamma:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[PALB] Hue", true, 0, new string[0], false)]
        class MenuItem_PALBHue:MenuItem
        {
            public override void Execute()
            {
            }
        }

        [MenuItemAttribute("[PALB] Saturation", true, 0, new string[0], false)]
        class MenuItem_PALBSaturation:MenuItem
        {
            public override void Execute()
            {
            }
        }
    }
}

