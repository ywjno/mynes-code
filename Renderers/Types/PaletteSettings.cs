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
namespace MyNes.Renderers
{
    [System.Serializable()]
    public class PaletteSettings
    {
        public float NTSC_saturation = 1.0F;
        public float NTSC_hue_tweak = 0.0F;
        public float NTSC_contrast = 1.0F;
        public float NTSC_brightness = 1.0F;
        public float NTSC_gamma = 1.8F;

        public float PALB_saturation = 1.0F;
        public float PALB_hue_tweak = 0.0F;
        public float PALB_contrast = 1.0F;
        public float PALB_brightness = 1.0F;
        public float PALB_gamma = 1.8F;
    }
}
