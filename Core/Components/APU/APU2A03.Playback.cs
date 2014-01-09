/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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

namespace MyNes.Core.APU
{
    public partial class APU2A03 : IProcesserBase
    {
        private static double[][][][][] mix_table;
        private int rPos;
        private int wPos;
        private int[] soundBuffer = new int[44100];
        // default to 44.1KHz settings
        private int sampleCycles;
        private int sampleSingle = 77;
        private int samplePeriod = 3125;

        private void InitializeMixTable()
        {
            mix_table = new double[16][][][][];

            for (int sq1 = 0; sq1 < 16; sq1++)
            {
                mix_table[sq1] = new double[16][][][];

                for (int sq2 = 0; sq2 < 16; sq2++)
                {
                    mix_table[sq1][sq2] = new double[16][][];

                    for (int tri = 0; tri < 16; tri++)
                    {
                        mix_table[sq1][sq2][tri] = new double[16][];

                        for (int noi = 0; noi < 16; noi++)
                        {
                            mix_table[sq1][sq2][tri][noi] = new double[128];

                            for (int dmc = 0; dmc < 128; dmc++)
                            {
                                double sqr = (95.88 / (8128.0 / (sq1 + sq2) + 100));
                                double tnd = (159.79 / (1.0 / ((tri / 8227.0) + (noi / 12241.0) + (dmc / 22638.0)) + 100));

                                mix_table[sq1][sq2][tri][noi][dmc] = ((sqr + tnd) * 128);
                            }
                        }
                    }
                }
            }
        }
        public void SetupPlayback(int frequency)
        {
            sampleSingle = frequency;

            soundBuffer = new int[frequency];
        }
        private void UpdatePlayback()
        {
            sampleCycles += sampleSingle;

            if (sampleCycles >= samplePeriod)
            {
                sampleCycles -= samplePeriod;
                AddSample();
            }
        }
        private void AddSample()
        {
            this.soundBuffer[wPos++ % this.soundBuffer.Length] = 
              (int)mix_table[channel_pulse1.GetSample()]
                            [channel_pulse2.GetSample()]
                            [channel_triangle.GetSample()]
                            [channel_noise.GetSample()]
                            [channel_dmc.GetSample()];
        }
        public void ResetBuffer()
        {
            rPos = 0;
            wPos = 0;
        }
        public int PullSample()
        {
            while (rPos >= wPos)
            {
                AddSample();
            }
            return soundBuffer[rPos++ % soundBuffer.Length];
        }
    }
}
