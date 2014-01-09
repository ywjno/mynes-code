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
    public class Triangle : ISoundChannel
    {
        private readonly byte[] StepSequence =
        {
            0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00,
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
        };
        private byte linearCounter = 0;
        private byte LinearCounterReload;
        private byte Step;
        private bool LinearCounterHalt;
        private bool HALT;

        public override void ClockEnvelope()
        {
            if (HALT)
            {
                linearCounter = LinearCounterReload;
            }
            else
            {
                if (linearCounter != 0)
                {
                    linearCounter--;
                }
            }

            HALT &= LinearCounterHalt;
        }
        private void UpdateFrequency()
        {
            freqTimer = (frequency + 1);
        }
        public void Write4008(byte value)
        {
            LinearCounterHalt = DurationHaltRequset = (value & 0x80) != 0;
            LinearCounterReload = (byte)(value & 0x7F);
        }
        public void Write400A(byte value)
        {
            frequency = (frequency & 0x700) | value;
            UpdateFrequency();
        }
        public void Write400B(byte value)
        {
            frequency = (frequency & 0x00FF) | ((value & 7) << 8);
            UpdateFrequency();

            DurationReload = DurationTable[value >> 3];
            DurationReloadRequst = true;
            HALT = true;
        }
        public override void HardReset()
        {
            base.HardReset();
            linearCounter = 0;
            LinearCounterReload = 0;
            output = 0;
            Step = 0;
            LinearCounterHalt = false;
            HALT = true;
        }
        public override byte GetSample()
        {
            //if (DurationCounter > 0 && linearCounter > 0)
            return output;
            //return 0;
        }
        public override void ClockSingle(bool isClockingLength)
        {
            base.ClockSingle(isClockingLength);
            if (--cycles <= 0)
            {
                cycles = freqTimer;
                if (DurationCounter > 0 && linearCounter > 0)
                {
                    if (frequency >= 4)
                    {
                        Step++;
                        Step &= 0x1F;
                        output = StepSequence[Step];
                    }
                }
            }
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(linearCounter);
            stream.Write(LinearCounterReload);
            stream.Write(Step);
            stream.Write(LinearCounterHalt);
            stream.Write(HALT);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            linearCounter = stream.ReadByte();
            LinearCounterReload = stream.ReadByte();
            Step = stream.ReadByte();
            LinearCounterHalt = stream.ReadBoolean();
            HALT = stream.ReadBoolean();
        }
    }
}
