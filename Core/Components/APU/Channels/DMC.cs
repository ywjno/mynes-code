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
    /// <summary>
    /// The DMC channel
    /// </summary>
    public class DMC : ISoundChannel
    {
        private static readonly int[][] FrequencyTable = 
        { 
            new int[]//NTSC
            { 
               428, 380, 340, 320, 286, 254, 226, 214, 190, 160, 142, 128, 106,  84,  72,  54
            },
            new int[]//PAL
            { 
               398, 354, 316, 298, 276, 236, 210, 198, 176, 148, 132, 118,  98,  78,  66,  50
            },  
            new int[]//DENDY (same as ntsc for now)
            { 
               428, 380, 340, 320, 286, 254, 226, 214, 190, 160, 142, 128, 106,  84,  72,  54
            },
        };
        public bool DeltaIrqOccur;
        private bool IrqEnabled;
        private bool dmaLooping;
        private bool dmaEnabled;
        private bool bufferFull = false;
        private int dmaAddrRefresh;
        private int dmaSizeRefresh;
        private int dmaSize;
        private int dmaBits = 0;
        private byte dmaByte = 0;
        private int dmaAddr = 0;
        private byte dmaBuffer = 0;

        public override void HardReset()
        {
            base.HardReset();
            DeltaIrqOccur = false;
            IrqEnabled = false;
            dmaLooping = false;
            dmaEnabled = false;
            bufferFull = false;
            output = 0;
            dmaAddr = dmaAddrRefresh = 0xC000;
            dmaSizeRefresh = 0;
            dmaSize = 0;
            dmaBits = 1;
            dmaByte = 1;
            dmaAddr = 0;
            dmaBuffer = 0;
            cycles = FrequencyTable[systemIndex][freqTimer];
        }
        public void Write4010(byte value)
        {
            IrqEnabled = (value & 0x80) != 0;
            dmaLooping = (value & 0x40) != 0;

            if (!IrqEnabled)
            {
                DeltaIrqOccur = false;
                NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.DMC, false);
            }
            freqTimer = value & 0x0F;
        }
        public void Write4011(byte value)
        {
            output = (byte)(value & 0x7F);
        }
        public void Write4012(byte value)
        {
            dmaAddrRefresh = (value << 6) | 0xC000;
        }
        public void Write4013(byte value)
        {
            dmaSizeRefresh = (value << 4) | 0x0001;
        }
        public override bool Enabled
        {
            get
            {
                return dmaSize > 0;
            }
            set
            {
                if (value)
                {
                    if (dmaSize == 0)
                    {
                        dmaSize = dmaSizeRefresh;
                        dmaAddr = dmaAddrRefresh;
                    }
                }
                else
                {
                    dmaSize = 0;
                }
                // Disable DMC IRQ
                DeltaIrqOccur = false;
                NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.DMC, false);
                // RDY ?
                if (!bufferFull && dmaSize > 0)
                {
                    NesCore.CPU.AssertRDY(CPU.CPU6502.RDYType.DMC);
                }
            }
        }
        public void DoDMA()
        {
            bufferFull = true;

            dmaBuffer = NesCore.CPU.Read(dmaAddr);

            if (++dmaAddr == 0x10000)
                dmaAddr = 0x8000;
            if (dmaSize > 0)
                dmaSize--;

            if (dmaSize == 0)
            {
                if (dmaLooping)
                {
                    dmaAddr = dmaAddrRefresh;
                    dmaSize = dmaSizeRefresh;
                }
                else if (IrqEnabled)
                {
                    NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.DMC, true);
                    DeltaIrqOccur = true;
                }
            }
        }
        public override byte GetSample()
        {
            return output;
        }
        public void ClockSingle()
        {
            if (--cycles <= 0)
            {
                cycles = FrequencyTable[systemIndex][freqTimer];
                if (dmaEnabled)
                {
                    if ((dmaByte & 0x01) != 0)
                    {
                        if (output <= 0x7D)
                            output += 2;
                    }
                    else
                    {
                        if (output >= 0x02)
                            output -= 2;
                    }
                    dmaByte >>= 1;
                }
                dmaBits--;
                if (dmaBits == 0)
                {
                    dmaBits = 8;
                    if (bufferFull)
                    {
                        bufferFull = false;
                        dmaEnabled = true;
                        dmaByte = dmaBuffer;
                        // RDY ?
                        if (dmaSize > 0)
                        {
                            NesCore.CPU.AssertRDY(CPU.CPU6502.RDYType.DMC);
                        }
                    }
                    else
                    {
                        dmaEnabled = false;
                    }
                }
            }
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(DeltaIrqOccur);
            stream.Write(IrqEnabled);
            stream.Write(dmaLooping);
            stream.Write(dmaEnabled);
            stream.Write(bufferFull);
            stream.Write(dmaAddrRefresh);
            stream.Write(dmaSizeRefresh);
            stream.Write(dmaSize);
            stream.Write(dmaBits);
            stream.Write(dmaByte);
            stream.Write(dmaAddr);
            stream.Write(dmaBuffer);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            DeltaIrqOccur = stream.ReadBoolean();
            IrqEnabled = stream.ReadBoolean();
            dmaLooping = stream.ReadBoolean();
            dmaEnabled = stream.ReadBoolean();
            bufferFull = stream.ReadBoolean();
            dmaAddrRefresh = stream.ReadInt32();
            dmaSizeRefresh = stream.ReadInt32();
            dmaSize = stream.ReadInt32();
            dmaBits = stream.ReadInt32();
            dmaByte = stream.ReadByte();
            dmaAddr = stream.ReadInt32();
            dmaBuffer = stream.ReadByte();
        }
    }
}
