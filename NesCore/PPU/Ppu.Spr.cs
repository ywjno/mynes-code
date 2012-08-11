using System;

namespace myNES.Core.PPU
{
    public partial class Ppu
    {
        private static int[] reverseLookup = new int[]
        { 
            0x00, 0x80, 0x40, 0xC0, 0x20, 0xA0, 0x60, 0xE0, 0x10, 0x90, 0x50, 0xD0, 0x30, 0xB0, 0x70, 0xF0,
            0x08, 0x88, 0x48, 0xC8, 0x28, 0xA8, 0x68, 0xE8, 0x18, 0x98, 0x58, 0xD8, 0x38, 0xB8, 0x78, 0xF8,
            0x04, 0x84, 0x44, 0xC4, 0x24, 0xA4, 0x64, 0xE4, 0x14, 0x94, 0x54, 0xD4, 0x34, 0xB4, 0x74, 0xF4,
            0x0C, 0x8C, 0x4C, 0xCC, 0x2C, 0xAC, 0x6C, 0xEC, 0x1C, 0x9C, 0x5C, 0xDC, 0x3C, 0xBC, 0x7C, 0xFC,
            0x02, 0x82, 0x42, 0xC2, 0x22, 0xA2, 0x62, 0xE2, 0x12, 0x92, 0x52, 0xD2, 0x32, 0xB2, 0x72, 0xF2,
            0x0A, 0x8A, 0x4A, 0xCA, 0x2A, 0xAA, 0x6A, 0xEA, 0x1A, 0x9A, 0x5A, 0xDA, 0x3A, 0xBA, 0x7A, 0xFA,
            0x06, 0x86, 0x46, 0xC6, 0x26, 0xA6, 0x66, 0xE6, 0x16, 0x96, 0x56, 0xD6, 0x36, 0xB6, 0x76, 0xF6,
            0x0E, 0x8E, 0x4E, 0xCE, 0x2E, 0xAE, 0x6E, 0xEE, 0x1E, 0x9E, 0x5E, 0xDE, 0x3E, 0xBE, 0x7E, 0xFE,
            0x01, 0x81, 0x41, 0xC1, 0x21, 0xA1, 0x61, 0xE1, 0x11, 0x91, 0x51, 0xD1, 0x31, 0xB1, 0x71, 0xF1,
            0x09, 0x89, 0x49, 0xC9, 0x29, 0xA9, 0x69, 0xE9, 0x19, 0x99, 0x59, 0xD9, 0x39, 0xB9, 0x79, 0xF9,
            0x05, 0x85, 0x45, 0xC5, 0x25, 0xA5, 0x65, 0xE5, 0x15, 0x95, 0x55, 0xD5, 0x35, 0xB5, 0x75, 0xF5,
            0x0D, 0x8D, 0x4D, 0xCD, 0x2D, 0xAD, 0x6D, 0xED, 0x1D, 0x9D, 0x5D, 0xDD, 0x3D, 0xBD, 0x7D, 0xFD,
            0x03, 0x83, 0x43, 0xC3, 0x23, 0xA3, 0x63, 0xE3, 0x13, 0x93, 0x53, 0xD3, 0x33, 0xB3, 0x73, 0xF3,
            0x0B, 0x8B, 0x4B, 0xCB, 0x2B, 0xAB, 0x6B, 0xEB, 0x1B, 0x9B, 0x5B, 0xDB, 0x3B, 0xBB, 0x7B, 0xFB,
            0x07, 0x87, 0x47, 0xC7, 0x27, 0xA7, 0x67, 0xE7, 0x17, 0x97, 0x57, 0xD7, 0x37, 0xB7, 0x77, 0xF7,
            0x0F, 0x8F, 0x4F, 0xCF, 0x2F, 0xAF, 0x6F, 0xEF, 0x1F, 0x9F, 0x5F, 0xDF, 0x3F, 0xBF, 0x7F, 0xFF
        };

        private void EvaluatePhase0()
        {
            if (hclock <= 0x40)
            {
                switch (hclock >> 1 & 3)
                {
                case 0: oam.output[hclock >> 3].YPos = 0xFF; break;
                case 1: oam.output[hclock >> 3].Name = 0xFF; break;
                case 2: oam.output[hclock >> 3].Attr = 0xFF; break;
                case 3: oam.output[hclock >> 3].XPos = 0xFF; break;
                }
            }
        }
        private void EvaluatePhase1()
        {
            this.oam.Count++;
            int num = (this.vclock - this.oam.Data) & int.MaxValue;

            if (num >= this.oam.rasters)
            {
                if (this.oam.Count != 0x40)
                {
                    this.oam.MemoryAddr = (this.oam.Count != 2) ? ((byte)(this.oam.MemoryAddr + 4)) : ((byte)8);
                }
                else
                {
                    this.oam.MemoryAddr = 0;
                    this.oam.action = new Action(this.EvaluatePhase9);
                }
            }
            else
            {
                this.oam.action = new Action(this.EvaluatePhase2);
                this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
                this.oam.output[this.oam.OutputAddr].YPos = this.oam.Data;
            }
        }
        private void EvaluatePhase2()
        {
            this.oam.action = new Action(this.EvaluatePhase3);
            this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
            this.oam.output[this.oam.OutputAddr].Name = this.oam.Data;
        }
        private void EvaluatePhase3()
        {
            this.oam.action = new Action(this.EvaluatePhase4);
            this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
            this.oam.output[this.oam.OutputAddr].Attr = this.oam.Data | ((this.oam.Count == 1) ? 0x10 : 0);
        }
        private void EvaluatePhase4()
        {
            this.oam.output[this.oam.OutputAddr].XPos = this.oam.Data;
            this.oam.OutputAddr++;
            if (this.oam.Count != 0x40)
            {
                this.oam.action = (this.oam.OutputAddr != 8) ? new Action(this.EvaluatePhase1) : new Action(this.EvaluatePhase5);
                if (this.oam.Count != 2)
                {
                    this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
                }
                else
                {
                    this.oam.MemoryAddr = 8;
                }
            }
            else
            {
                this.oam.MemoryAddr = 0;
                this.oam.action = new Action(this.EvaluatePhase9);
            }
        }
        private void EvaluatePhase5()
        {
            int num = (this.vclock - this.oam.Data) & int.MaxValue;

            if (num >= this.oam.rasters)
            {
                this.oam.MemoryAddr = ((this.oam.MemoryAddr + 4) & 0xfc) + ((this.oam.MemoryAddr + 1) & 3);
                if (this.oam.MemoryAddr <= 5)
                {
                    this.oam.action = new Action(this.EvaluatePhase9);
                    this.oam.MemoryAddr &= 0xfc;
                }
            }
            else
            {
                this.oam.action = new Action(this.EvaluatePhase6);
                this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
                this.sprFlow = true;
            }
        }
        private void EvaluatePhase6()
        {
            this.oam.action = new Action(this.EvaluatePhase7);
            this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
        }
        private void EvaluatePhase7()
        {
            this.oam.action = new Action(this.EvaluatePhase8);
            this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
        }
        private void EvaluatePhase8()
        {
            this.oam.action = new Action(this.EvaluatePhase9);
            this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
            if ((this.oam.MemoryAddr & 3) == 3)
            {
                this.oam.MemoryAddr = (this.oam.MemoryAddr + 1) & 0xff;
            }
            this.oam.MemoryAddr &= 0xfc;
        }
        private void EvaluatePhase9()
        {
            this.oam.MemoryAddr = (this.oam.MemoryAddr + 4) & 0xff;
        }

        private void EvaluateStep0()
        {
            if (vclock < 240)
                oam.Data = oam.Memory[oam.MemoryAddr];
        }
        private void EvaluateStep1()
        {
            if (vclock < 240)
                oam.action();
        }

        private void EvaluateBegin()
        {
            this.oam.action = new Action(this.EvaluatePhase1);
            this.oam.OutputAddr = 0;
            this.oam.Count = 0;
        }
        private void EvaluateReset()
        {
            this.oam.action = new Action(this.EvaluatePhase0);
            this.oam.OutputAddr = 0;
            this.oam.MemoryAddr = this.oam.MemoryAddrLatch;
            this.oam.Count = 0;
            for (int i = 0; i < 0x100; i++)
            {
                this.spr.pixels[i] = 0x3f00;
            }
        }

        private void FetchSprBit0_0()
        {
            var sprite = oam.output[hclock >> 3 & 7];
            var raster = (vclock - sprite.YPos) ^ (((sprite.Attr & 0x80) != 0) ? 15 : 0);

            if (oam.rasters == 0x10)
            {
                fetch.name = ((((sprite.Name << 12) & 0x1000) | ((sprite.Name << 4) & 0xfe0)) | ((raster << 1) & 0x10)) | (raster & 7);
            }
            else
            {
                fetch.name = (spr.address | ((sprite.Name << 4) & 0xff0)) | (raster & 7);
            }

            fetch.addr = fetch.name | 0x00;
        }
        private void FetchSprBit0_1()
        {
            var sprite = oam.output[hclock >> 3 & 7];

            if (sprite.XPos == 0xFF)
            {
                fetch.bit0 = 0;
            }
            else
            {
                fetch.bit0 = Nes.PpuMemory[fetch.addr];
            }

            if ((sprite.Attr & 0x40) != 0)
                fetch.bit0 = reverseLookup[fetch.bit0];
        }
        private void FetchSprBit1_0()
        {
            fetch.addr = fetch.name | 0x08;
        }
        private void FetchSprBit1_1()
        {
            var sprite = oam.output[hclock >> 3 & 7];

            if (sprite.XPos == 0xFF)
            {
                fetch.bit1 = 0;
            }
            else
            {
                fetch.bit1 = Nes.PpuMemory[fetch.addr];
            }

            if ((sprite.Attr & 0x40) != 0)
                fetch.bit1 = reverseLookup[fetch.bit1];
        }

        public class Oam
        {
            public Action action;
            public Object[] output = new Object[8];
            public byte[] Memory = new byte[0x100];
            public int Count;
            public int Data = 0;
            public int MemoryAddr = 0;
            public int MemoryAddrLatch;
            public int OutputAddr = 0;
            public int rasters = 8;

            public struct Object
            {
                public int Attr;
                public int Name;
                public int XPos;
                public int YPos;
            }
        }
    }
}