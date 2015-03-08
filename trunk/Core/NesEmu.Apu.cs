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
        private static int audio_playback_buffer_timer;
        private static int audio_playback_buffer_timer_reload;
        private const int audio_playback_max_peek = 120;
        private const int audio_playback_min_peek = -120;
        private static byte[] audio_playback_buffer = new byte[44100];
        private static int audio_playback_bufferSize;
        private static bool audio_playback_first_render;
        private static bool audio_playback_buffer_sumbit_enabled;
        public static int audio_playback_w_pos = 0;//Write position
        public static int audio_playback_latency = 0;//Write position
        private static int audio_playback_out;
        // DAC
        private const double audio_playback_amplitude = 256;
        private static double[] dac_sqr_table;
        private static double[] dac_tnd_table;
        // DC Blocker Filter.
        private static double x, x_1, y, y_1;

        /*Channels configuration*/
        public static bool audio_playback_sq1_enabled;
        public static bool audio_playback_sq2_enabled;
        public static bool audio_playback_dmc_enabled;
        public static bool audio_playback_trl_enabled;
        public static bool audio_playback_noz_enabled;

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
            if (audio_playback_buffer == null) return;
            // Noise on shutdown; MISC
            Random r = new Random();
            for (int i = 0; i < audio_playback_buffer.Length; i++)
                audio_playback_buffer[i] = (byte)r.Next(0, 20);
        }
        public static void CalculateAudioPlaybackValues()
        {
            // Playback buffer
            audio_playback_buffer_timer = 0;
            audio_playback_buffer_timer_reload = cpuSpeedInHz / audio_playback_buffer_frequency;
            audio_playback_first_render = true;
        }
        private static void InitializeDACTables()
        {
            // Squares table
            dac_sqr_table = new double[32];
            for (int i = 0; i < 32; i++)
            {
                dac_sqr_table[i] = 95.52 / (8128.0 / i + 100);
            }
            // TND table
            dac_tnd_table = new double[204];
            for (int i = 0; i < 204; i++)
            {
                dac_tnd_table[i] = 163.67 / (24329.0 / i + 100);
            }
        }

        /// <summary>
        /// Setup audio playback (using buffer submit at the end of each frame).
        /// </summary>
        /// <param name="AudioOutput">The audio provider (AudioOut.AddSample(ref sample) 
        /// MUST be implemented, AudioOut.SubmitBuffer(ref buff) is ignored)</param>
        /// <param name="soundEnabled">Indicates if the sound playbakc is enabled or not.</param>
        /// <param name="frequency">The sound playback frequency in Hz. Prefered value is 44100 Hz</param>
        public static void SetupSoundPlayback(IAudioProvider AudioOutput, bool soundEnabled, int frequency)
        {
            SetupSoundPlayback(AudioOutput, soundEnabled, frequency, 0, 0, false);
        }
        /// <summary>
        /// Setup audio playback.
        /// </summary>
        /// <param name="AudioOutput">The audio provider.</param>
        /// <param name="soundEnabled">Indicates if the sound playbakc is enabled or not.</param>
        /// <param name="frequency">The sound playback frequency in Hz. Prefered value is 44100 Hz</param>
        /// <param name="bufferSize">The buffer size in bytes.</param>
        /// <param name="latencyInBytes">The latency in bytes (number of samples * 2 for latency)</param>
        /// <param name="enable_buffer_submit">If set, the engine will use AudioOut.SubmitBuffer(ref buff)
        /// otherwise AudioOut.AddSample(ref sample) will be used.</param>
        public static void SetupSoundPlayback(IAudioProvider AudioOutput, bool soundEnabled, int frequency, int bufferSize,
            int latencyInBytes, bool enable_buffer_submit)
        {
            audio_playback_latency = latencyInBytes;
            audio_playback_bufferSize = bufferSize;
            audio_playback_buffer_frequency = frequency;
            AudioOut = AudioOutput;
            SoundEnabled = soundEnabled;
            x = x_1 = y = y_1 = 0;
            audio_playback_first_render = true;
            audio_playback_buffer = new byte[audio_playback_bufferSize];
            audio_playback_buffer_sumbit_enabled = enable_buffer_submit;
        }
        private static void APUUpdatePlayback()
        {
            audio_playback_buffer_timer++;
            if (audio_playback_buffer_timer >= audio_playback_buffer_timer_reload)
            {
                audio_playback_buffer_timer -= audio_playback_buffer_timer_reload;

                #region Collect channel outputs

                // SQ1
                if (sq1_pl_clocks > 0)
                    sq1_pl_output = sq1_pl_output_av / sq1_pl_clocks;
                sq1_pl_clocks = sq1_pl_output_av = 0;

                // SQ2
                if (sq2_pl_clocks > 0)
                    sq2_pl_output = sq2_pl_output_av / sq2_pl_clocks;
                sq2_pl_clocks = sq2_pl_output_av = 0;

                // NOZ
                if (noz_pl_clocks > 0)
                    noz_pl_output = noz_pl_output_av / noz_pl_clocks;
                noz_pl_clocks = noz_pl_output_av = 0;

                // TRL
                if (trl_pl_clocks > 0)
                    trl_pl_output = trl_pl_output_av / trl_pl_clocks;
                trl_pl_clocks = trl_pl_output_av = 0;

                // DMC
                if (dmc_pl_clocks > 0)
                    dmc_pl_output = dmc_pl_output_av / dmc_pl_clocks;
                dmc_pl_clocks = dmc_pl_output_av = 0;

                #endregion

                #region DC Blocker Filter

                // X[n] is the current NES DAC sample.
                x = (dac_sqr_table[sq1_pl_output + sq2_pl_output] +
                     dac_tnd_table[(3 * trl_pl_output) + (2 * noz_pl_output) + dmc_pl_output] +
                   (board.enable_external_sound ? board.APUGetSamples() : 0)) * audio_playback_amplitude;

                // Apply the formula. 
                // Y[n] is the current sample that output into buffer.
                y = x - x_1 + (0.995 * y_1);// y[n] = x[n] - x[n - 1] + R * y[n - 1]; R = 0.995 for 44100 Hz
                x_1 = x;
                y_1 = y;
                // Convert from double to int32.
                audio_playback_out = Convert.ToInt32(Math.Round(y));

                #endregion

                #region Limit peek (this nesseccary for external channels)
                if (audio_playback_out > audio_playback_max_peek)
                    audio_playback_out = audio_playback_max_peek;
                else if (audio_playback_out < audio_playback_min_peek)
                    audio_playback_out = audio_playback_min_peek;
                #endregion

                #region Add sample to the buffer.
                if (audio_playback_buffer_sumbit_enabled)
                {
                    if (audio_playback_first_render)
                    {
                        audio_playback_first_render = false;
                        audio_playback_w_pos = AudioOut.CurrentWritePosition;
                    }
                    // 16 Bit samples
                    if (audio_playback_w_pos >= audio_playback_bufferSize)
                        audio_playback_w_pos = 0;
                    audio_playback_buffer[audio_playback_w_pos] = (byte)((audio_playback_out & 0xFF00) >> 8);
                    audio_playback_w_pos++;

                    if (audio_playback_w_pos >= audio_playback_bufferSize)
                        audio_playback_w_pos = 0;
                    audio_playback_buffer[audio_playback_w_pos] = (byte)(audio_playback_out & 0xFF);
                    audio_playback_w_pos++;
                }
                else
                {
                    AudioOut.AddSample(ref audio_playback_out);
                }
                if (AudioOut.IsRecording)
                    AudioOut.RecorderAddSample(ref audio_playback_out);
                #endregion
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

