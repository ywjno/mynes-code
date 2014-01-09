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
    public class Noise : ISoundChannel
    {
        private readonly int[][] FrequencyTable = 
        { 
            new int [] //NTSC
            {  
                4, 8, 16, 32, 64, 96, 128, 160, 202, 254, 380, 508, 762, 1016, 2034, 4068
            },
            new int [] //PAL
            {  
                4, 8, 14, 30, 60, 88, 118, 148, 188, 236, 354, 472, 708,  944, 1890, 3778
            },
            new int [] //DENDY (same as ntsc for now)
            {  
                4, 8, 16, 32, 64, 96, 128, 160, 202, 254, 380, 508, 762, 1016, 2034, 4068
            }
        };
        private bool ModeFlag = false;
        private int ShiftRegister = 1;

        public override void HardReset()
        {
            base.HardReset();
            ModeFlag = false;
            ShiftRegister = 1;
        }
        public void Write400C(byte value)
        {
            base.Write1(value);
        }
        public void Write400E(byte value)
        {
            freqTimer = value & 0x0F;
            ModeFlag = (value & 0x80) == 0x80;
        }
        public void Write400F(byte value)
        {
            base.Write4(value);
        }
        public override byte GetSample()
        {
            if (DurationCounter > 0 && (ShiftRegister & 1) == 0)
                return EnvelopeSound;
            return 0;
        }
        public override void ClockSingle(bool isClockingLength)
        {
            base.ClockSingle(isClockingLength);
            if (--cycles <= 0)
            {
                cycles = FrequencyTable[systemIndex][freqTimer];
                if (ModeFlag)
                    ShiftRegister = (ShiftRegister << 1) | (((ShiftRegister >> 14) ^ (ShiftRegister >> 8)) & 0x1);
                else
                    ShiftRegister = (ShiftRegister << 1) | (((ShiftRegister >> 14) ^ (ShiftRegister >> 13)) & 0x1);
            }
        }
        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(ModeFlag);
            stream.Write(ShiftRegister);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            ModeFlag = stream.ReadBoolean();
            ShiftRegister = stream.ReadInt32();
        }
    }
}
