/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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

/*APU section*/
namespace MyNes.Core
{
    public partial class NesEmu
    {
        private static int[][] SequenceMode0 =
        { 
            new int[] { 7459, 7456, 7458, 7457, 1, 1, 7457 }, // NTSC
            new int[] { 8315, 8314, 8312, 8313, 1, 1, 8313 }, // PALB
            new int[] { 7459, 7456, 7458, 7457, 1, 1, 7457 }, // DENDY (acts like NTSC)
        };
        private static int[][] SequenceMode1 = 
        { 
            new int[] { 1, 7458, 7456, 7458, 14910 } , // NTSC
            new int[] { 1, 8314, 8314, 8312, 16626 } , // PALB
            new int[] { 1, 7458, 7456, 7458, 14910 } , // DENDY (acts like NTSC)
        };
        private static byte[] DurationTable = 
        {
            0x0A, 0xFE, 0x14, 0x02, 0x28, 0x04, 0x50, 0x06, 0xA0, 0x08, 0x3C, 0x0A, 0x0E, 0x0C, 0x1A, 0x0E,
            0x0C, 0x10, 0x18, 0x12, 0x30, 0x14, 0x60, 0x16, 0xC0, 0x18, 0x48, 0x1A, 0x10, 0x1C, 0x20, 0x1E,
        };
        private static byte[][] PulseDutyForms =
        {
            new byte[] {  0, 1, 0, 0, 0, 0, 0, 0 }, // 12.5%
            new byte[] {  0, 1, 1, 0, 0, 0, 0, 0 }, // 25.0%
            new byte[] {  0, 1, 1, 1, 1, 0, 0, 0 }, // 50.0%
            new byte[] {  1, 0, 0, 1, 1, 1, 1, 1 }, // 75.0% (25.0% negated)
        };
        private static byte[] TrlStepSequence =
        {
             15, 14, 13, 12, 11, 10,  9,  8,  7,  6,  5,  4,  3,  2,  1,  0,
             0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15
        };
        private static int[][] NozFrequencyTable = 
        { 
            new int [] //NTSC
            {  
                 4, 8, 16, 32, 64, 96, 128, 160, 202, 254, 380, 508, 762, 1016, 2034, 4068
            },
            new int [] //PAL
            {  
                 4, 7, 14, 30, 60, 88, 118, 148, 188, 236, 354, 472, 708,  944, 1890, 3778
            },
            new int [] //DENDY (same as ntsc for now)
            {  
                 4, 8, 16, 32, 64, 96, 128, 160, 202, 254, 380, 508, 762, 1016, 2034, 4068
            }
        };
        private static int[][] DMCFrequencyTable = 
        { 
            new int[]//NTSC
            { 
               428, 380, 340, 320, 286, 254, 226, 214, 190, 160, 142, 128, 106,  84,  72,  54
            },
            new int[]//PAL
            { 
               398, 354, 316, 298, 276, 236, 210, 198, 176, 148, 132, 118,  98,  78,  66,  50
            },  
            new int[]//DENDY (same as ntsc for now)
            { 
               428, 380, 340, 320, 286, 254, 226, 214, 190, 160, 142, 128, 106,  84,  72,  54
            },
        };
        private static int Cycles = 0;
        private static int systemIndex;
        private static bool SequencingMode;
        private static byte CurrentSeq = 0;
        private static bool isClockingDuration = false;
        private static bool FrameIrqEnabled;
        private static bool FrameIrqFlag;
        private static bool oddCycle;
        /*Playback*/
        private static IAudioProvider AudioOut;
        private static bool SoundEnabled;
        // Output playback buffer
        public static int audio_playback_buffer_frequency;
        // DAC
        private const double audio_playback_amplitude = 256;

        private static double[][][][][] dac_table;
        // Output values
        private static double x, x_1;
        private static BlipBufferNative audio_playback_blipbuffer;
        private static uint audio_playback_blipbuffer_timer;
        private static int audio_playback_blipbuffer_size;

        /*Channels configuration*/
        public static bool audio_playback_sq1_enabled;
        public static bool audio_playback_sq2_enabled;
        public static bool audio_playback_dmc_enabled;
        public static bool audio_playback_trl_enabled;
        public static bool audio_playback_noz_enabled;

        private static bool audio_playback_sample_needed;

        private static void APUHardReset()
        {
            CalculateAudioPlaybackValues();

            Cycles = SequenceMode0[systemIndex][0] - 10;
            FrameIrqFlag = false;
            FrameIrqEnabled = true;
            SequencingMode = false;
            CurrentSeq = 0;
            oddCycle = false;
            isClockingDuration = false;

            Sq1HardReset();
            Sq2HardReset();
            TrlHardReset();
            NozHardReset();
            DMCHardReset();
        }
        private static void APUSoftReset()
        {
            Cycles = SequenceMode0[systemIndex][0] - 10;
            FrameIrqFlag = false;
            FrameIrqEnabled = true;
            SequencingMode = false;
            CurrentSeq = 0;
            oddCycle = false;
            isClockingDuration = false;

            Sq1SoftReset();
            Sq2SoftReset();
            TrlSoftReset();
            NozSoftReset();
            DMCSoftReset();
        }
        private static void APUShutdown()
        {
            if (AudioOut != null)
                AudioOut.Shutdown();
        }
        public static void CalculateAudioPlaybackValues()
        {
            // Playback buffer
            audio_playback_blipbuffer = new BlipBufferNative(audio_playback_blipbuffer_size);
            audio_playback_blipbuffer.SetRates(cpuSpeedInHz, audio_playback_buffer_frequency);

            audio_playback_blipbuffer_timer = 0;
            audio_playback_sample_needed = false;
            x = x_1 = 0;
        }
        private static void InitializeDACTables()
        {
            dac_table = new double[16][][][][];
            for (int sq1 = 0; sq1 < 16; sq1++)
            {
                dac_table[sq1] = new double[16][][][];
                for (int sq2 = 0; sq2 < 16; sq2++)
                {
                    dac_table[sq1][sq2] = new double[16][][];
                    for (int trl = 0; trl < 16; trl++)
                    {
                        dac_table[sq1][sq2][trl] = new double[16][];
                        for (int noz = 0; noz < 16; noz++)
                        {
                            dac_table[sq1][sq2][trl][noz] = new double[128];
                            for (int dmc = 0; dmc < 128; dmc++)
                            {
                                double rgroup1_dac_output = (8128.0 / ((double)sq1 + (double)sq2));
                                rgroup1_dac_output = 95.88 / (rgroup1_dac_output + 100.0);

                                double rgroup2_dac_output = 1.0 / (((double)dmc / 22638.0) + ((double)trl / 8827.0) + ((double)noz / 12241.0));
                                rgroup2_dac_output = 159.79 / (rgroup2_dac_output + 100.0);

                                dac_table[sq1][sq2][trl][noz][dmc] = rgroup1_dac_output + rgroup2_dac_output;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Setup audio playback.
        /// </summary>
        /// <param name="AudioOutput">The audio provider.</param>
        /// <param name="soundEnabled">Indicates if the sound playback is enabled or not.</param>
        /// <param name="frequency">The sound playback frequency in Hz. Preferred value is 44100 Hz</param>
        /// <param name="samplesCount">The buffer size in samples (bytes count / 2)</param>
        public static void SetupSoundPlayback(IAudioProvider AudioOutput, bool soundEnabled, int frequency, int samplesCount)
        {
            audio_playback_buffer_frequency = frequency;
            AudioOut = AudioOutput;
            SoundEnabled = soundEnabled;
            audio_playback_blipbuffer_size = samplesCount;
            x = x_1 = 0;
        }
        private static void APUUpdatePlayback()
        {
            audio_playback_blipbuffer_timer++;
            if (audio_playback_sample_needed)
            {
                audio_playback_sample_needed = false;
                if (!audio_playback_sq1_enabled)
                    sq1_pl_output = 0;
                if (!audio_playback_sq2_enabled)
                    sq2_pl_output = 0;
                if (!audio_playback_dmc_enabled)
                    dmc_pl_output = 0;
                if (!audio_playback_trl_enabled)
                    trl_pl_output = 0;
                if (!audio_playback_noz_enabled)
                    noz_pl_output = 0;
                // Collect the sample
                x = (dac_table[sq1_pl_output][sq2_pl_output][trl_pl_output][noz_pl_output][dmc_pl_output] +
                    (board.enable_external_sound ? board.APUGetSamples() : 0)) * audio_playback_amplitude;

                // Add delta to the blip-buffer
                if (x != x_1)
                {
                    audio_playback_blipbuffer.AddDelta(audio_playback_blipbuffer_timer, (int)(x - x_1));
                    x_1 = x;
                }
            }
        }
        private static void APUClockDuration()
        {
            APUClockEnvelope();

            Sq1ClockLengthCounter();
            Sq2ClockLengthCounter();
            TrlClockLengthCounter();
            NozClockLengthCounter();
            if (board.enable_external_sound)
                board.OnAPUClockDuration();
        }
        private static void APUClockEnvelope()
        {
            Sq1ClockEnvelope();
            Sq2ClockEnvelope();
            TrlClockEnvelope();
            NozClockEnvelope();
            if (board.enable_external_sound)
                board.OnAPUClockEnvelope();
        }
        private static void APUCheckIrq()
        {
            if (FrameIrqEnabled)
                FrameIrqFlag = true;
            if (FrameIrqFlag)
                IRQFlags |= IRQ_APU;
        }
        private static void APUClock()
        {
            isClockingDuration = false;
            Cycles--;
            oddCycle = !oddCycle;

            if (Cycles == 0)
            {
                if (!SequencingMode)
                {
                    switch (CurrentSeq)
                    {
                        case 0: APUClockEnvelope(); break;
                        case 1: APUClockDuration(); isClockingDuration = true; break;
                        case 2: APUClockEnvelope(); break;
                        case 3: APUCheckIrq(); break;
                        case 4: APUCheckIrq(); APUClockDuration(); isClockingDuration = true; break;
                        case 5: APUCheckIrq(); break;
                    }
                    CurrentSeq++;
                    Cycles += SequenceMode0[systemIndex][CurrentSeq];
                    if (CurrentSeq == 6)
                        CurrentSeq = 0;
                }
                else
                {
                    switch (CurrentSeq)
                    {
                        case 0:
                        case 2: APUClockDuration(); isClockingDuration = true; break;
                        case 1:
                        case 3: APUClockEnvelope(); break;
                    }
                    CurrentSeq++;
                    Cycles = SequenceMode1[systemIndex][CurrentSeq];
                    if (CurrentSeq == 4)
                        CurrentSeq = 0;
                }
            }
            // Clock single
            Sq1ClockSingle();
            Sq2ClockSingle();
            TrlClockSingle();
            NozClockSingle();
            DMCClockSingle();
            if (board.enable_external_sound)
                board.OnAPUClockSingle(ref isClockingDuration);
            // Playback
            APUUpdatePlayback();
        }
    }
}

