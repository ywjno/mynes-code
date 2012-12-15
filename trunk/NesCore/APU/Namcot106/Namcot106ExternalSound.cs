/* This file is part of My Nes
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
using MyNes.Core.APU;
namespace MyNes.Core.APU.Namcot106
{
    class Namcot106ExternalSound:IApuExternalChannelsMixer
    {
        public Namcot106ExternalSound()
        {
            channels = new Namcot106SoundChannel[8];
            for (int i = 0; i < 8; i++)
                channels[i] = new Namcot106SoundChannel(Nes.emuSystem);
        }
        private Namcot106SoundChannel[] channels;
        private byte[] exram = new byte[128];//for ex sound
        private byte sndReg = 0;
        public void Poke4800(int address, byte data)
        {
            exram[sndReg & 0x7F] = data;
            if ((sndReg & 0x80) == 0x80)
                sndReg = (byte)(((sndReg + 1) & 0x7F) | 0x80);
            // write registers
        }
        public void PokeF800(int address, byte data)
        {
            sndReg = data;
        }
        public byte Peek4800(int address)
        {
            byte val = exram[sndReg & 0x7F];
            if ((sndReg & 0x80) == 0x80)
                sndReg = (byte)(((sndReg + 1) & 0x7F) | 0x80);
            return val;
        }
        public short Mix(short internalChannelsOutput)
        {
            throw new System.NotImplementedException();
        }

        public void HardReset()
        {
            throw new System.NotImplementedException();
        }

        public void SoftReset()
        {
            throw new System.NotImplementedException();
        }

        public void ClockDuration()
        {
            throw new System.NotImplementedException();
        }

        public void ClockEnvelope()
        {
            throw new System.NotImplementedException();
        }

        public void ClockSingle(bool isClockingDuration)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int cycles)
        {
            throw new System.NotImplementedException();
        }

        public void SaveState(Types.StateStream stream)
        {
            throw new System.NotImplementedException();
        }

        public void LoadState(Types.StateStream stream)
        {
            throw new System.NotImplementedException();
        }
    }
}
