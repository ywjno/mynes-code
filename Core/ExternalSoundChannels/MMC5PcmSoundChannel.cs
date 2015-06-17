﻿/* This file is part of My Nes
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

namespace MyNes.Core
{
    class MMC5PcmSoundChannel
    {
        public byte output;
        private bool readMode;
        private bool PCMIRQenable;
        private bool irqTrip;

        public void HardReset()
        {
            output = 0;
            readMode = false;
            PCMIRQenable = false;
            irqTrip = false;
        }
        public void SoftReset()
        {
            HardReset();
        }
        public void Write5010(byte data)
        {
            readMode = (data & 0x1) == 0x1;
            PCMIRQenable = (data & 0x80) == 0x80;
            // Update irq
            if (PCMIRQenable && irqTrip)
                NesEmu.IRQFlags |= NesEmu.IRQ_BOARD;
        }
        public byte Read5010()
        {
            byte data = (byte)((irqTrip & PCMIRQenable) ? 0x80 : 0);

            irqTrip = false;
            NesEmu.IRQFlags &= ~NesEmu.IRQ_BOARD;
            return data;
        }
        public void Write5011(byte data)
        {
            if (!readMode)
            {
                if (data == 0)
                {
                    irqTrip = true;
                }
                else
                {
                    irqTrip = false;
                    output = data;
                }
                // Update irq
                if (PCMIRQenable && irqTrip)
                    NesEmu.IRQFlags |= NesEmu.IRQ_BOARD;
            }
        }

        /// <summary>
        /// Save state
        /// </summary>
        /// <param name="stream">The stream that should be used to write data</param>
        public virtual void SaveState(System.IO.BinaryWriter stream)
        {
            stream.Write(readMode);
            stream.Write(PCMIRQenable);
            stream.Write(irqTrip);
        }
        /// <summary>
        /// Load state
        /// </summary>
        /// <param name="stream">The stream that should be used to read data</param>
        public virtual void LoadState(System.IO.BinaryReader stream)
        {
            readMode = stream.ReadBoolean();
            PCMIRQenable = stream.ReadBoolean();
            irqTrip = stream.ReadBoolean();
        }
    }
}
