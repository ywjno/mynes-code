using System;

namespace myNES.Core
{
    public class NTSCPaletteGenerator
    {
        public static float saturation = 1.0f;
        public static float hue_tweak = 0.0f;
        public static float contrast = 1.0f;
        public static float brightness = 1.0f;
        public static float gamma = 1.8f;

        // Voltage levels, relative to synch voltage
        const float black = .518f;
        const float white = 1.962f;
        const float attenuation = .746f;
        static float[] levels = 
        {
               0.350f, 0.518f, 0.962f, 1.550f,  // Signal low
               1.094f, 1.506f, 1.962f, 1.962f   // Signal high
        };

        public static int MakeRGBcolor(int pixel)
        {
            // The input value is a NES color index (with de-emphasis bits).
            // We need RGB values. Convert the index into RGB.
            // For most part, this process is described at:
            //    http://wiki.nesdev.com/w/index.php/NTSC_video

            // Decode the color index
            int color = (pixel & 0x0F), level = color < 0xE ? (pixel >> 4) & 3 : 1;

            float[] lo_and_hi = { levels[level + 4 *( (color == 0x0)?1:0)],
                               levels[level + 4 * ((color <  0xD)?1:0)] };

            // Calculate the luma and chroma by emulating the relevant circuits:
            float y = 0.0f, i = 0.0f, q = 0.0f;
            for (int p = 0; p < 12; ++p) // 12 clock cycles per pixel.
            {
                // NES NTSC modulator (square wave between two voltage levels):
                float spot = lo_and_hi[wave(p, color)];

                // De-emphasis bits attenuate a part of the signal:
                if ((((pixel & 0x40) == 0x40) && (wave(p, 12) == 1))
                || (((pixel & 0x80) == 0x80) && (wave(p, 4) == 1))
                || (((pixel & 0x100) == 0x100) && (wave(p, 8) == 1)))
                    spot *= attenuation;

                // Normalize:
                float v = (spot - black) / (white - black);

                // Ideal TV NTSC demodulator:
                // Apply contrast/brightness
                v = (v - .5f) * contrast + .5f;
                v *= brightness / 12.0f;

                y += v;
                i += (float)(v * Math.Cos((double)((3.141592653f / 6.0f) * (p + hue_tweak))));
                q += (float)(v * Math.Sin((3.141592653f / 6.0f) * (p + hue_tweak)));
            }

            i *= saturation;
            q *= saturation;

            // Convert YIQ into RGB according to FCC-sanctioned conversion matrix.
            int rgb = 0x10000 * clamp(255 * gammafix(y + 0.946882f * i + 0.623557f * q, gamma))
                         + 0x00100 * clamp(255 * gammafix(y + -0.274788f * i + -0.635691f * q, gamma))
                         + 0x00001 * clamp(255 * gammafix(y + -1.108545f * i + 1.709007f * q, gamma));
            return rgb;
        }
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

        public static int[] GeneratePalette()
        {
            int[] pal = new int[512];
            for (int i = 0; i < 512; i++)
                pal[i] = MakeRGBcolor(i);
            return pal;
        }
    }
}
