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
    /// <summary>
    /// Represents APU channel
    /// </summary>
    public abstract class ISoundChannel : INesComponent
    {
        protected byte systemIndex;
        protected int freqTimer;
        protected int cycles;
        protected int frequency;
        protected byte output;
        // Length
        protected byte[] DurationTable = 
        {
            0x0A, 0xFE, 0x14, 0x02, 0x28, 0x04, 0x50, 0x06, 0xA0, 0x08, 0x3C, 0x0A, 0x0E, 0x0C, 0x1A, 0x0E,
            0x0C, 0x10, 0x18, 0x12, 0x30, 0x14, 0x60, 0x16, 0xC0, 0x18, 0x48, 0x1A, 0x10, 0x1C, 0x20, 0x1E,
        };
        protected bool DurationHalt = false;
        protected bool DurationHaltRequset = false;
        protected byte DurationCounter;
        protected bool DurationReloadEnabled;
        protected byte DurationReload = 0;
        protected bool DurationReloadRequst = false;
        // Envelope
        protected bool EnvelopeLooping;
        protected bool EnvelopeEnabled;
        protected byte EnvelopeVolume;
        protected byte EnvelopeCount;
        protected byte EnvelopeDelay;
        protected bool EnvelopeRefresh;
        protected byte EnvelopeTimer;
        protected byte EnvelopeSound
        {
            get
            {
                if (EnvelopeEnabled)
                {
                    return EnvelopeVolume;
                }
                else
                {
                    return EnvelopeCount;
                }
            }
            set
            {
                EnvelopeDelay = value;
                if (EnvelopeEnabled)
                    EnvelopeVolume = EnvelopeDelay;
                else
                    EnvelopeVolume = EnvelopeCount;
            }
        }

        public override void HardReset()
        {
            base.HardReset();
            switch (NesCore.TV)
            {
                case TVSystem.NTSC: systemIndex = 0; break;
                case TVSystem.PALB: systemIndex = 1; break;
                case TVSystem.DENDY: systemIndex = 2; break;
            }
            cycles = 0;
            freqTimer = 0; 
            frequency = 0;
            DurationHalt = false;
            DurationHaltRequset = false;
            DurationCounter = 0;
            DurationReloadEnabled = false;
            DurationReload = 0;
            DurationReloadRequst = false;

            EnvelopeLooping = false;
            EnvelopeEnabled = false;
            EnvelopeVolume = 0;
            EnvelopeCount = 0;
            EnvelopeDelay = 0;
            EnvelopeRefresh = false;
            EnvelopeTimer = 0;
        }
        public override void SoftReset()
        {
            base.SoftReset();
            DurationReloadEnabled = false;
            DurationCounter = 0;
        }


        /// <summary>
        /// Clock the channel a single clock (cpu clock)
        /// </summary>
        /// <param name="isClockingLength">Indicate if the current clock is a length counter clock</param>
        public virtual void ClockSingle(bool isClockingLength)
        {
            DurationHalt = DurationHaltRequset;
            if (isClockingLength && DurationCounter > 0)
                DurationReloadRequst = false;
            if (DurationReloadRequst)
            {
                if (DurationReloadEnabled)
                    DurationCounter = DurationReload;
                DurationReloadRequst = false;
            }
        }
        /// <summary>
        /// Clock the Envelopes / triangle's linear counter
        /// </summary>
        public virtual void ClockEnvelope()
        {
            if (EnvelopeRefresh)
            {
                EnvelopeRefresh = false;
                EnvelopeTimer = EnvelopeDelay;
                EnvelopeCount = 0x0F;
            }
            else
            {
                if (EnvelopeTimer != 0)
                {
                    EnvelopeTimer--;
                }
                else
                {
                    EnvelopeTimer = EnvelopeDelay;

                    if (EnvelopeLooping || EnvelopeCount != 0)
                        EnvelopeCount = (byte)((EnvelopeCount - 1) & 0x0F);
                }
            }
        }
        /// <summary>
        /// Length counters & sweep units
        /// </summary>
        public virtual void ClockLengthCounter()
        {
            if (!DurationHalt)
            {
                if (DurationCounter > 0)
                {
                    DurationCounter--;
                }
            }
        }
        /// <summary>
        /// Get or set if the channels is enabled via 4015
        /// </summary>
        public virtual bool Enabled
        {
            get { return DurationCounter > 0; }
            set
            {
                DurationReloadEnabled = value;
                if (!DurationReloadEnabled)
                    DurationCounter = 0;
            }
        }
        /// <summary>
        /// Get a sample
        /// </summary>
        /// <returns></returns>
        public virtual byte GetSample()
        {
            return 0;
        }
        /// <summary>
        /// Write length counter halt, constant volume/envelope flag, and volume/envelope divider period
        /// </summary>
        /// <param name="value">The value to write</param>
        protected virtual void Write1(byte value)
        {
            DurationHaltRequset = (value & 0x20) != 0;
            EnvelopeLooping = (value & 0x20) != 0;
            EnvelopeEnabled = (value & 0x10) != 0;
            EnvelopeSound = (byte)(value & 0x0F);
        }
        /// <summary>
        /// Write length counter load and timer high (write) 
        /// </summary>
        /// <param name="value">The value to write</param>
        protected virtual void Write4(byte value)
        {
            DurationReload = DurationTable[value >> 3];
            DurationReloadRequst = true;
            EnvelopeRefresh = true;
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(freqTimer);
            stream.Write(cycles);
            stream.Write(frequency);
            stream.Write(output);
            stream.Write(DurationHalt);
            stream.Write(DurationHaltRequset);
            stream.Write(DurationCounter);
            stream.Write(DurationReloadEnabled);
            stream.Write(DurationReload);
            stream.Write(DurationReloadRequst);
            stream.Write(EnvelopeLooping);
            stream.Write(EnvelopeEnabled);
            stream.Write(EnvelopeVolume);
            stream.Write(EnvelopeCount);
            stream.Write(EnvelopeDelay);
            stream.Write(EnvelopeRefresh);
            stream.Write(EnvelopeTimer);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            freqTimer = stream.ReadInt32();
            cycles = stream.ReadInt32();
            frequency = stream.ReadInt32();
            output = stream.ReadByte();
            DurationHalt = stream.ReadBoolean();
            DurationHaltRequset = stream.ReadBoolean();
            DurationCounter = stream.ReadByte();
            DurationReloadEnabled = stream.ReadBoolean();
            DurationReload = stream.ReadByte();
            DurationReloadRequst = stream.ReadBoolean();
            EnvelopeLooping = stream.ReadBoolean();
            EnvelopeEnabled = stream.ReadBoolean();
            EnvelopeVolume = stream.ReadByte();
            EnvelopeCount = stream.ReadByte();
            EnvelopeDelay = stream.ReadByte();
            EnvelopeRefresh = stream.ReadBoolean();
            EnvelopeTimer = stream.ReadByte();
        }
    }
}
