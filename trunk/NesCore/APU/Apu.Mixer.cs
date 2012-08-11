using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myNES.Core.APU
{
    public partial class Apu
    {
        public const int OUTPUT_MAX = +32767;
        public const int OUTPUT_MIN = -32767;

        public class Mixer
        {
            private const float NLN_SQR_DIV = 8128F;
            private const float NLN_TND_DIV = 24329F;

            private const float NLN_SQR_BASE = 95.52F * OUTPUT_MAX;
            private const float NLN_TND_BASE = 163.67F * OUTPUT_MAX;

            private static short[][] sqrTable;
            private static short[][][] tndTable;
            private static int acc;
            private static int prev_sample;
            private static int prev_output;

            static Mixer()
            {
                sqrTable = new short[15 * 1 + 1][];
                tndTable = new short[15 * 3 + 1][][];

                for (int i = 0; i < sqrTable.Length; i++)
                {
                    sqrTable[i] = new short[15 * 1 + 1];

                    for (int j = 0; j < sqrTable[i].Length; j++)
                    {
                        int div = (i + j);

                        if (div == 0)
                            continue;

                        sqrTable[i][j] = (short)(NLN_SQR_BASE / ((NLN_SQR_DIV / div) + 100));
                    }
                }

                for (int i = 0; i < tndTable.Length; i++)
                {
                    tndTable[i] = new short[15 * 2 + 1][];

                    for (int j = 0; j < tndTable[i].Length; j++)
                    {
                        tndTable[i][j] = new short[127 * 1 + 1];

                        for (int k = 0; k < tndTable[i][j].Length; k++)
                        {
                            int div = (i + j + k);

                            if (div == 0)
                                continue;

                            tndTable[i][j][k] = (short)(NLN_TND_BASE / ((NLN_TND_DIV / div) + 100));
                        }
                    }
                }
            }

            private static short Filter(int sample)
            {
                const int pole = (int)(32767 * (1.0 - 0.9999));

                acc -= prev_sample;
                acc += prev_sample = sample << 15;
                acc -= prev_output * pole;
                prev_output = acc >> 15; // quantization happens here

                return (short)prev_output;
            }

            public static short MixSamples(int sq1, int sq2, int tri, int noi, int dpm, int ext = 0)
            {
                return Filter(
                    sqrTable[sq1 * 1][sq2 * 1] +
                    tndTable[tri * 3][noi * 2][dpm * 1] + ext);
            }
        }
    }
}