﻿/* This file is part of My Nes
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

namespace MyNes.Core.PPU
{
    public class PALBPaletteGenerator
    {
        // Voltage levels, relative to synch voltage
        const float black = 0.518F;
        const float white = 1.962F;
        const float attenuation = 0.746F;

        public static float saturation = 1.0F;
        public static float hue_tweak = 0.0F;
        public static float contrast = 1.0F;
        public static float brightness = 1.0F;
        public static float gamma = 1.8F;

        static float[] levels = 
        {
            0.350F, 0.518F, 0.962F, 1.550F, // Signal low
            1.094F, 1.506F, 1.962F, 1.962F  // Signal high
        };

        static int wave(int p, int color)
        {
            return ((color + p + 8) % 12 < 6) ? 1 : 0;
        }
        static float gammafix(float f, float gamma)
        {
            return (float)(f < 0.0f ? 0.0f : Math.Pow(f, 2.2f / gamma));
        }
        static int clamp(float v)
        {
            return (int)(v < 0 ? 0 : v > 255 ? 255 : v);
        }

        public static int MakeRGBcolor(int pixel)
        {
            // The input value is a NES color index (with de-emphasis bits).
            // We need RGB values. Convert the index into RGB.
            // For most part, this process is described at:
            //    http://wiki.nesdev.com/w/index.php/NTSC_video

            // Decode the color index
            int color = (pixel & 0x0F);
            int level = color < 0xE ? (pixel >> 4) & 3 : 1;

            var lo_and_hi = new[]
            {
                levels[level + ((color == 0x0) ? 4 : 0)],
                levels[level + ((color <= 0xC) ? 4 : 0)]
            };

            // Calculate the luma and chroma by emulating the relevant circuits:
            float y = 0.0f, i = 0.0f, q = 0.0f;

            for (int p = 0; p < 12; p++) // 12 clock cycles per pixel.
            {
                // NES NTSC modulator (square wave between two voltage levels):
                var spot = lo_and_hi[wave(p, color)];

                // De-emphasis bits attenuate a part of the signal:
                if ((pixel & 0x040) != 0 && wave(p, 0xC) == 1 ||
                    (pixel & 0x080) != 0 && wave(p, 0x4) == 1 ||
                    (pixel & 0x100) != 0 && wave(p, 0x8) == 1) spot *= attenuation;

                // Normalize:
                float v = (spot - black) / (white - black);

                // Ideal TV NTSC demodulator:
                // Apply contrast/brightness
                v = (v - 0.5F) * contrast + 0.5F;
                v *= brightness / 12.0F;

                y += v;
                i += (float)(v * Math.Cos((Math.PI / 6.0) * (p + hue_tweak)));
                q += (float)(v * Math.Sin((Math.PI / 6.0) * (p + hue_tweak)));
            }

            i *= saturation;
            q *= saturation;

            // Convert YIQ into RGB according to FCC-sanctioned conversion matrix.
            return
                0x10000 * clamp(255 * gammafix(y + 0.946882F * i + 0.623557F * q, gamma)) +
                0x00100 * clamp(255 * gammafix(y - 0.274788F * i - 0.635691F * q, gamma)) +
                0x00001 * clamp(255 * gammafix(y - 1.108545F * i + 1.709007F * q, gamma));
        }
        public static int[] GeneratePalette()
        {
            int[] pal = new int[512];

            for (int i = 0; i < 512; i++)
                pal[i] = MakeRGBcolor(i);

            return pal;
        }
    }
}