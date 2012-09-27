﻿/* This file is part of My Nes
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
using System.Collections.Generic;
namespace MyNes.Core.APU
{
    public class Apu : ProcessorBase
    {
        public ChannelSq1 sq1;
        public ChannelSq2 sq2;
        public ChannelTri tri;
        public ChannelNoi noi;
        public ChannelDmc dmc;
        public Channel[] extraChannels;

        private int Cycles = 0;
        private bool SequencingMode;
        /*From PAL NES APU Tests (google it !)
        Mode 0: 4-step sequence

        Action      Envelopes &     Length Counter& Interrupt   Delay to next
                    Linear Counter  Sweep Units     Flag        NTSC     PAL
        - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        $4017=$00   -               -               -           7459    8315
        Step 1      Clock           -               -           7456    8314
        Step 2      Clock           Clock           -           7458    8312
        Step 3      Clock           -               -           7458    8314
        Step 4      Clock           Clock       Set if enabled  7458    8314


        Mode 1: 5-step sequence

        Action      Envelopes &     Length Counter& Interrupt   Delay to next
                    Linear Counter  Sweep Units     Flag        NTSC     PAL
        - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        $4017=$80   -               -               -              1       1
        Step 1      Clock           Clock           -           7458    8314
        Step 2      Clock           -               -           7456    8314
        Step 3      Clock           Clock           -           7458    8312
        Step 4      Clock           -               -           7458    8314
        Step 5      -               -               -           7452    8312
        */
        //TODO: Dendy system values for Apu. It acts like PAL here for now.
        private int[][] SequenceMode0 =
        { 
            new int[] { 7459, 7456, 7458, 7457, 1, 1, 7457 }, // NTSC
            new int[] { 8315, 8314, 8312, 8313, 1, 1, 8313 }, // PALB
            new int[] { 8315, 8314, 8312, 8313, 1, 1, 8313  }, // DENDY ??
        };
        private int[][] SequenceMode1 = 
        { 
            new int[] { 1, 7458, 7456, 7458, 14910 } , // NTSC
            new int[] { 1, 8314, 8314, 8312, 16626 } , // PALB
            new int[] { 1, 8314, 8314, 8312, 16626 } , // DENDY ??
        };
        private int systemIndex = 0;//0=NTSC, 1=PALB, 2=DENDY
        private byte CurrentSeq = 0;
        private bool oddCycle = false;
        private bool isClockingDuration = false;
        private bool FrameIrqEnabled;
        private bool FrameIrqFlag;
        private bool EXenabled = false;//extra channels enable

        //PLAYBACK
        private int rPos;
        private int wPos;
        private int[] soundBuffer = new int[44100];

        private float ClockFreq = 1789772f;
        private float sampleDelay = (1789772f / 44100.00f);
        private float sampleTimer;
        private ApuMixerType mixer = ApuMixerType.Implementation;

        public Apu(TimingInfo.System system)
            : base(system)
        {
            timing.period = system.Master;
            timing.single = system.Spu;

            sq1 = new ChannelSq1(system);
            sq2 = new ChannelSq2(system);
            tri = new ChannelTri(system);
            noi = new ChannelNoi(system);
            dmc = new ChannelDmc(system);
        }

        public override void Initialize()
        {
            sq1.Hook(0x4000);
            sq2.Hook(0x4004);
            tri.Hook(0x4008);
            noi.Hook(0x400C);
            dmc.Hook(0x4010);

            Nes.CpuMemory.Hook(0x4015, Peek4015, Poke4015);
            Nes.CpuMemory.Hook(0x4017, Poke4017);

            HardReset();
        }
        public override void HardReset()
        {
            if (system.Master == TimingInfo.NTSC.Master)
                systemIndex = 0;
            else if (system.Master == TimingInfo.PALB.Master)
                systemIndex = 1;
            else if (system.Master == TimingInfo.DENDY.Master)
                systemIndex = 2;

            Cycles = SequenceMode0[systemIndex][0] - 10;
            FrameIrqFlag = false;
            FrameIrqEnabled = true;
            SequencingMode = false;
            CurrentSeq = 0;
            oddCycle = false;
            isClockingDuration = false;
            wPos = rPos = 0;
            soundBuffer = new int[soundBuffer.Length];
            sampleTimer = 0;

            sq1.HardReset();
            sq2.HardReset();
            tri.HardReset();
            noi.HardReset();
            dmc.HardReset();

            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.HardReset();
            }
        }
        public override void SoftReset()
        {
            sq1.SoftReset();
            sq2.SoftReset();
            tri.SoftReset();
            noi.SoftReset();
            dmc.SoftReset();
            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.SoftReset();
            }
            FrameIrqFlag = false;
            FrameIrqEnabled = true;
            Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Apu, false);
            Cycles = SequenceMode0[systemIndex][0] - 10;
            SequencingMode = false;
            CurrentSeq = 0;
            oddCycle = false;
        }
        public override void Shutdown() { }

        public void SetupPlayback(ApuPlaybackDescription des)
        {
            ClockFreq = system.Master / system.Cpu;
            sampleDelay = (ClockFreq / des.Frequency) - 1.1f;

            soundBuffer = new int[des.Frequency];
            this.mixer = des.MixerType;
        }
        public void AddExtraChannels(APU.Channel[] channels)
        {
            EXenabled = true;
            extraChannels = channels;
        }

        private void ClockDuration()
        {
            ClockEnvelope();

            sq1.ClockDuration();
            sq2.ClockDuration();
            noi.ClockDuration();
            tri.ClockDuration();
            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.ClockDuration();
            }
        }
        private void ClockEnvelope()
        {
            sq1.ClockEnvelope();
            sq2.ClockEnvelope();
            noi.ClockEnvelope();
            tri.ClockEnvelope();
            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.ClockEnvelope();
            }
        }
        private void ClockSingle()
        {
            sq1.ClockSingle(isClockingDuration);
            sq2.ClockSingle(isClockingDuration);
            tri.ClockSingle(isClockingDuration);
            noi.ClockSingle(isClockingDuration);
            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.ClockSingle(isClockingDuration);
            }
        }
        private void UpdatePlayback()
        {
            if (sampleTimer > 0)
            {
                sampleTimer--;
            }
            else
            {
                sampleTimer += sampleDelay;
                AddSample(sampleDelay);
            }
        }

        private void CheckIrq()
        {
            if (FrameIrqEnabled)
                FrameIrqFlag = true;
            if (FrameIrqFlag)
                Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Apu, true);
        }

        public override void Update(int cycles)
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
            ClockSingle();
            UpdatePlayback();
            base.Update(cycles);
        }
        public override void Update()
        {
            sq1.Update(timing.single);
            sq2.Update(timing.single);
            noi.Update(timing.single);
            tri.Update(timing.single);
            dmc.Update(timing.single);
            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.Update(timing.single);
            }
        }

        private byte Peek4015(int addr)
        {
            byte data = 0;

            if (sq1.Status) data |= 0x01;
            if (sq2.Status) data |= 0x02;
            if (tri.Status) data |= 0x04;
            if (noi.Status) data |= 0x08;
            if (dmc.Status) data |= 0x10;
            if (FrameIrqFlag) data |= 0x40;
            if (dmc.DeltaIrqOccur) data |= 0x80;

            FrameIrqFlag = false;
            Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Apu, false);

            return data;
        }
        private void Poke4015(int address, byte data)
        {
            sq1.Status = (data & 0x01) != 0;
            sq2.Status = (data & 0x02) != 0;
            tri.Status = (data & 0x04) != 0;
            noi.Status = (data & 0x08) != 0;
            dmc.Status = (data & 0x10) != 0;
        }
        private void Poke4017(int addr, byte data)
        {
            SequencingMode = (data & 0x80) != 0;
            FrameIrqEnabled = (data & 0x40) == 0;

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
                Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Apu, false);
            }
        }

        private void AddSample(float sampleRate)
        {
            int output = (int)(MixSamples());

            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    output += chn.GetSample();
            }

            //if (output > 128)
            //    output = 128;
            //if (output < 0)
            //    output = 0;

            this.soundBuffer[wPos++ % this.soundBuffer.Length] = output;
        }
        public int PullSample()
        {
            while (rPos >= wPos)
            {
                AddSample(sampleDelay);
            }
            return soundBuffer[rPos++ % soundBuffer.Length];
        }
        private float MixSamples()
        {
            float tndSample = 0;
            float sqrSample = 0;
            switch (mixer)
            {
                case ApuMixerType.Implementation:
                    sqrSample += Nes.Apu.sq1.GetSample();
                    sqrSample += Nes.Apu.sq2.GetSample();

                    tndSample += Nes.Apu.tri.GetSample() * 3;
                    tndSample += Nes.Apu.noi.GetSample() * 2;
                    tndSample += Nes.Apu.dmc.GetSample() * 1;

                    return ((95.52f / (8128.00f / sqrSample + 100)) + (163.67f / (24329.00f / tndSample + 100))) * 128;

                case ApuMixerType.LinearApproximation:
                    sqrSample += Nes.Apu.sq1.GetSample();
                    sqrSample += Nes.Apu.sq2.GetSample();

                    tndSample += Nes.Apu.tri.GetSample() * 0.00851f;
                    tndSample += Nes.Apu.noi.GetSample() * 0.00494f;
                    tndSample += Nes.Apu.dmc.GetSample() * 0.00335f;

                    return ((0.00752f * sqrSample) + tndSample) * 128;

                case ApuMixerType.Normal:
                    sqrSample += Nes.Apu.sq1.GetSample();
                    sqrSample += Nes.Apu.sq2.GetSample();

                    tndSample += Nes.Apu.tri.GetSample();
                    tndSample += Nes.Apu.noi.GetSample();
                    tndSample += Nes.Apu.dmc.GetSample();

                    return (sqrSample + tndSample);
            }
            return 0;
        }

        public override void SaveState(Types.StateStream stream)
        {
            base.SaveState(stream);
            sq1.SaveState(stream);
            sq2.SaveState(stream);
            tri.SaveState(stream);
            noi.SaveState(stream);
            dmc.SaveState(stream);

            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.SaveState(stream);
            }

            stream.Write(Cycles);
            stream.Write(CurrentSeq);
            stream.Write(SequencingMode, oddCycle, isClockingDuration, FrameIrqEnabled, FrameIrqFlag);
        }
        public override void LoadState(Types.StateStream stream)
        {
            base.LoadState(stream);
            sq1.LoadState(stream);
            sq2.LoadState(stream);
            tri.LoadState(stream);
            noi.LoadState(stream);
            dmc.LoadState(stream);

            if (EXenabled)
            {
                foreach (Channel chn in extraChannels)
                    chn.LoadState(stream);
            }

            Cycles = stream.ReadInt32();
            CurrentSeq = stream.ReadByte();
            bool[] flags = stream.ReadBooleans();
            SequencingMode = flags[0];
            oddCycle = flags[1];
            isClockingDuration = flags[2];
            FrameIrqEnabled = flags[3];
            FrameIrqFlag = flags[4];
        }
    }
}