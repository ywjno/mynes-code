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
using MyNes.Core.APU.Channels;

namespace MyNes.Core.APU
{
    /// <summary>
    /// Emulates the nes apu 2A03
    /// </summary>
    public partial class APU2A03 : IProcesserBase
    {
        // Channels
        private Pulse1 channel_pulse1;
        private Pulse2 channel_pulse2;
        private Triangle channel_triangle;
        private Noise channel_noise;
        private DMC channel_dmc;

        public override void Initialize()
        {
            base.Initialize();
            InitializeMixTable();
            channel_pulse1 = new Pulse1();
            channel_pulse2 = new Pulse2();
            channel_triangle = new Triangle();
            channel_noise = new Noise();
            channel_dmc = new DMC();
        }
        public override void HardReset()
        {
            base.HardReset();
            switch (NesCore.TV)
            {
                case TVSystem.NTSC: systemIndex = 0; samplePeriod = 1789772; break;
                case TVSystem.PALB: systemIndex = 1; samplePeriod = 1662607; break;
                case TVSystem.DENDY: systemIndex = 2; samplePeriod = 1773448; break;
            }
            Cycles = SequenceMode0[systemIndex][0] - 10;
            FrameIrqFlag = false;
            FrameIrqEnabled = true;
            SequencingMode = false;
            CurrentSeq = 0;
            oddCycle = false;
            isClockingDuration = false;
            // channels
            channel_pulse1.HardReset();
            channel_pulse2.HardReset();
            channel_triangle.HardReset();
            channel_noise.HardReset();
            channel_dmc.HardReset();
        }
        public override void SoftReset()
        {
            base.SoftReset();
            channel_pulse1.SoftReset();
            channel_pulse2.SoftReset();
            channel_triangle.SoftReset();
            channel_noise.SoftReset();
            channel_dmc.SoftReset();
            FrameIrqFlag = false;
            FrameIrqEnabled = true;
            NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.APU, false);
            Cycles = SequenceMode0[systemIndex][0] - 10;
            SequencingMode = false;
            CurrentSeq = 0;
            oddCycle = false;
        }
        public void DoDMA()
        {
            channel_dmc.DoDMA();
        }

        // State
        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            // Channels
            channel_pulse1.SaveState(stream);
            channel_pulse2.SaveState(stream);
            channel_triangle.SaveState(stream);
            channel_noise.SaveState(stream);
            channel_dmc.SaveState(stream);
            // Values
            stream.Write(Cycles);
            stream.Write(SequencingMode);
            stream.Write(CurrentSeq);
            stream.Write(oddCycle);
            stream.Write(isClockingDuration);
            stream.Write(FrameIrqEnabled);
            stream.Write(FrameIrqFlag);
            // Reset buffer
            ResetBuffer();
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            // Channels
            channel_pulse1.LoadState(stream);
            channel_pulse2.LoadState(stream);
            channel_triangle.LoadState(stream);
            channel_noise.LoadState(stream);
            channel_dmc.LoadState(stream);

            Cycles = stream.ReadInt32();
            SequencingMode = stream.ReadBoolean();
            CurrentSeq = stream.ReadByte();
            oddCycle = stream.ReadBoolean();
            isClockingDuration = stream.ReadBoolean();
            FrameIrqEnabled = stream.ReadBoolean();
            FrameIrqFlag = stream.ReadBoolean();
            // Reset buffer
            ResetBuffer();
        }
    }
}
