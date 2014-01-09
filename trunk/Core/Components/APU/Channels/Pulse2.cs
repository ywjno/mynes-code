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
namespace MyNes.Core.APU.Channels
{
    public class Pulse2 : ISoundChannel
    {
        private readonly byte[][] DutyForms =
        {
            new byte[] {  0, 1, 0, 0, 0, 0, 0, 0 }, // 12.5%
            new byte[] {  0, 1, 1, 0, 0, 0, 0, 0 }, // 25.0%
            new byte[] {  0, 1, 1, 1, 1, 0, 0, 0 }, // 50.0%
            new byte[] {  1, 0, 0, 1, 1, 1, 1, 1 }, // 75.0% (25.0% negated)
        };
        private int dutyForm;
        private int dutyStep;
        private int SweepDeviderPeriod = 0;
        private int SweepShiftCount = 0;
        private int SweepCounter = 0;
        private bool SweepEnable = false;
        private bool SweepReload = false;
        private bool SweepNegateFlag = false;

        public override void HardReset()
        {
            base.HardReset();
            dutyForm = 0;
            dutyStep = 0;
            SweepDeviderPeriod = 0;
            SweepShiftCount = 0;
            SweepCounter = 0;
            output = 0;
            SweepEnable = false;
            SweepReload = false;
            SweepNegateFlag = false;
        }

        private void ClockSweep()
        {
            SweepCounter--;
            if (SweepCounter == 0)
            {
                SweepCounter = SweepDeviderPeriod + 1;
                if (SweepEnable && (SweepShiftCount > 0) && IsValidFrequency())
                {
                    int sweep = frequency >> SweepShiftCount;
                    frequency += SweepNegateFlag ? -sweep : sweep;
                }
            }
            if (SweepReload)
            {
                SweepReload = false;
                SweepCounter = SweepDeviderPeriod + 1;
            }
            UpdateFrequency();
        }
        public override void ClockLengthCounter()
        {
            base.ClockLengthCounter();
            ClockSweep();
        }
        private void UpdateFrequency()
        {
            freqTimer = (frequency + 1) * 2;
        }
        private bool IsValidFrequency()
        {
            return (frequency >= 0x8) && ((SweepNegateFlag) || (((frequency + (frequency >> SweepShiftCount)) & 0x800) == 0));
        }
        public void Write4004(byte value)
        {
            base.Write1(value);
            dutyForm = (value & 0xC0) >> 6;
        }
        public void Write4005(byte value)
        {
            SweepEnable = (value & 0x80) == 0x80;
            SweepDeviderPeriod = (value >> 4) & 7;
            SweepNegateFlag = (value & 0x8) == 0x8;
            SweepShiftCount = value & 7;
            SweepReload = true;
        }
        public void Write4006(byte value)
        {
            frequency = (frequency & 0x700) | value;

            UpdateFrequency();
        }
        public void Write4007(byte value)
        {
            base.Write4(value);
            frequency = (frequency & 0x00FF) | ((value & 7) << 8);

            UpdateFrequency();
            dutyStep = 0;
        }

        public override byte GetSample()
        {
            if (DurationCounter > 0 && IsValidFrequency())
                return output;
            return 0;
        }
        public override void ClockSingle(bool isClockingLength)
        {
            base.ClockSingle(isClockingLength);
            if (--cycles <= 0)
            {
                cycles = freqTimer;
                dutyStep = (dutyStep + 1) & 0x7;
                if (DurationCounter > 0 && IsValidFrequency())
                {
                    output = (byte)(DutyForms[dutyForm][dutyStep] * EnvelopeSound);
                }
                else
                    output = 0;
            }
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(dutyForm);
            stream.Write(dutyStep);
            stream.Write(SweepDeviderPeriod);
            stream.Write(SweepShiftCount);
            stream.Write(SweepCounter);
            stream.Write(SweepEnable);
            stream.Write(SweepReload);
            stream.Write(SweepNegateFlag);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            dutyForm = stream.ReadInt32();
            dutyStep = stream.ReadInt32();
            SweepDeviderPeriod = stream.ReadInt32();
            SweepShiftCount = stream.ReadInt32();
            SweepCounter = stream.ReadInt32();
            SweepEnable = stream.ReadBoolean();
            SweepReload = stream.ReadBoolean();
            SweepNegateFlag = stream.ReadBoolean();
        }
    }
}
