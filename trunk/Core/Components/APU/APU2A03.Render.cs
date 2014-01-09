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
        private int[][] SequenceMode0 =
        { 
            new int[] { 7459, 7456, 7458, 7457, 1, 1, 7457 }, // NTSC
            new int[] { 8315, 8314, 8312, 8313, 1, 1, 8313 }, // PALB
            new int[] { 7459, 7456, 7458, 7457, 1, 1, 7457 }, // DENDY (acts like NTSC)
        };
        private int[][] SequenceMode1 = 
        { 
            new int[] { 1, 7458, 7456, 7458, 14910 } , // NTSC
            new int[] { 1, 8314, 8314, 8312, 16626 } , // PALB
            new int[] { 1, 7458, 7456, 7458, 14910 } , // DENDY (acts like NTSC)
        };
        private int Cycles = 0;
        private bool SequencingMode;
        private byte CurrentSeq = 0;
        private bool oddCycle = false;
        private bool isClockingDuration = false;
        private bool FrameIrqEnabled;
        private bool FrameIrqFlag;
        private int systemIndex = 0;

        private void ClockDuration()
        {
            ClockEnvelope();

            channel_pulse1.ClockLengthCounter();
            channel_pulse2.ClockLengthCounter();
            channel_triangle.ClockLengthCounter();
            channel_noise.ClockLengthCounter();
        }
        private void ClockEnvelope()
        {
            channel_pulse1.ClockEnvelope();
            channel_pulse2.ClockEnvelope();
            channel_triangle.ClockEnvelope();
            channel_noise.ClockEnvelope();
        }

        private void CheckIrq()
        {
            if (FrameIrqEnabled)
                FrameIrqFlag = true;
            if (FrameIrqFlag)
                NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.APU, true);
        }
        public override void Clock()
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
                        case 0: ClockEnvelope(); break;
                        case 1: ClockDuration(); isClockingDuration = true; break;
                        case 2: ClockEnvelope(); break;
                        case 3: CheckIrq(); break;
                        case 4: CheckIrq(); ClockDuration(); isClockingDuration = true; break;
                        case 5: CheckIrq(); break;
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
                        case 2: ClockDuration(); isClockingDuration = true; break;
                        case 1:
                        case 3: ClockEnvelope(); break;
                    }
                    CurrentSeq++;
                    Cycles = SequenceMode1[systemIndex][CurrentSeq];
                    if (CurrentSeq == 4)
                        CurrentSeq = 0;
                }
            }
            // Clock single
            channel_pulse1.ClockSingle(isClockingDuration);
            channel_pulse2.ClockSingle(isClockingDuration);
            channel_triangle.ClockSingle(isClockingDuration);
            channel_noise.ClockSingle(isClockingDuration);
            channel_dmc.ClockSingle();
            // Playback
            UpdatePlayback();
        }
    }
}
