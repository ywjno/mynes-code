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
        public void Write4000(byte value)
        {
            channel_pulse1.Write4000(value);
        }
        public void Write4001(byte value)
        {
            channel_pulse1.Write4001(value);
        }
        public void Write4002(byte value)
        {
            channel_pulse1.Write4002(value);
        }
        public void Write4003(byte value)
        {
            channel_pulse1.Write4003(value);
        }

        public void Write4004(byte value)
        {
            channel_pulse2.Write4004(value);
        }
        public void Write4005(byte value)
        {
            channel_pulse2.Write4005(value);
        }
        public void Write4006(byte value)
        {
            channel_pulse2.Write4006(value);
        }
        public void Write4007(byte value)
        {
            channel_pulse2.Write4007(value);
        }

        public void Write4008(byte value)
        {
            channel_triangle.Write4008(value);
        }
        public void Write400A(byte value)
        {
            channel_triangle.Write400A(value);
        }
        public void Write400B(byte value)
        {
            channel_triangle.Write400B(value);
        }

        public void Write400C(byte value)
        {
            channel_noise.Write400C(value);
        }
        public void Write400E(byte value)
        {
            channel_noise.Write400E(value);
        }
        public void Write400F(byte value)
        {
            channel_noise.Write400F(value);
        }

        public void Write4010(byte value)
        {
            channel_dmc.Write4010(value);
        }
        public void Write4011(byte value)
        {
            channel_dmc.Write4011(value);
        }
        public void Write4012(byte value)
        {
            channel_dmc.Write4012(value);
        }
        public void Write4013(byte value)
        {
            channel_dmc.Write4013(value);
        }

        public void Write4015(byte value)
        {
            channel_pulse1.Enabled = (value & 0x01) != 0;
            channel_pulse2.Enabled = (value & 0x02) != 0;
            channel_triangle.Enabled = (value & 0x04) != 0;
            channel_noise.Enabled = (value & 0x08) != 0;
            channel_dmc.Enabled = (value & 0x10) != 0;
        }
        public byte Read4015()
        {
            byte data = 0;
            // Channels enable
            if (channel_pulse1.Enabled) data |= 0x01;
            if (channel_pulse2.Enabled) data |= 0x02;
            if (channel_triangle.Enabled) data |= 0x04;
            if (channel_noise.Enabled) data |= 0x08;
            if (channel_dmc.Enabled) data |= 0x10;
            // IRQ
            if (FrameIrqFlag) data |= 0x40;
            if (channel_dmc.DeltaIrqOccur) data |= 0x80;

            FrameIrqFlag = false;
            NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.APU, false);

            return data;
        }
        public void Write4017(byte value)
        {
            SequencingMode = (value & 0x80) != 0;
            FrameIrqEnabled = (value & 0x40) == 0;

            CurrentSeq = 0;

            if (!SequencingMode)
                Cycles = SequenceMode0[systemIndex][0];
            else
                Cycles = SequenceMode1[systemIndex][0];

            if (!oddCycle)
                Cycles++;
            else
                Cycles += 2;

            if (!FrameIrqEnabled)
            {
                FrameIrqFlag = false;
                NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.APU, false);
            }
        }
    }
}
