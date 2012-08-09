using myNES.Core.CPU;

namespace myNES.Core.PPU
{
    // Emulates the RP2C02/RP2C07 graphics synthesizer
    public class Ppu : ProcessorBase
    {
        private Fetch fetch = new Fetch();
        private Scroll scroll = new Scroll();
        private Sprite[] buffer = new Sprite[8];
        private Unit bkg = new Unit(272);
        private Unit spr = new Unit(256);
        private byte chr;
        private byte[] oam = new byte[256];
        private int clipping;
        private int emphasis;
        private int hclock;
        private int vclock;
        private int oam_address;
        private int[] colors;
        private int[][] screen;
        private bool oddSwap;
        //nmi and vbl
        private bool nmi;
        private bool vbl;
        private bool suppressVbl;
        private bool suppressNmi;
        private byte value2000;

        public Ppu(TimingInfo.System system)
            : base(system)
        {
            timing.period = system.Master;
            timing.single = system.Gpu;

            screen = new int[240][];

            for (int i = 0; i < 240; i++)
                screen[i] = new int[256];
        }

        private void FetchName_0()
        {
            fetch.addr = 0x2000 | (scroll.addr & 0xFFF);
        }
        private void FetchName_1()
        {
            fetch.name = Nes.PpuMemory[fetch.addr];
        }
        private void FetchAttr_0()
        {
            fetch.addr = 0x23C0 | (scroll.addr & 0xC00) | (scroll.addr >> 4 & 0x38) | (scroll.addr >> 2 & 0x7);
        }
        private void FetchAttr_1()
        {
            fetch.attr = Nes.PpuMemory[fetch.addr] >> ((scroll.addr >> 4 & 0x04) | (scroll.addr & 0x02));
        }
        private void FetchBit0_0()
        {
            fetch.addr = bkg.address | (fetch.name << 4) | 0 | (scroll.addr >> 12 & 7);
        }
        private void FetchBit0_1()
        {
            fetch.bit0 = Nes.PpuMemory[fetch.addr];
        }
        private void FetchBit1_0()
        {
            fetch.addr = bkg.address | (fetch.name << 4) | 8 | (scroll.addr >> 12 & 7);
        }
        private void FetchBit1_1()
        {
            fetch.bit1 = Nes.PpuMemory[fetch.addr];
        }

        private byte Peek____(int address) { return 0; }
        private byte Peek2002(int address)
        {
            //Read 1 cycle before vblank should suppress setting flag
            if (vclock == 241 & hclock == 340)
            {
                suppressVbl = true; suppressNmi = true;
            }
            //Read 1 cycle before/after vblank should suppress nmi
            if ((vclock == 242 & hclock < 2))
            {
                suppressNmi = true;
            }
            byte data = 0;

            if (vbl)
                data |= 0x80;

            vbl = false;
            scroll.swap = false;

            return data;
        }
        private byte Peek2004(int address) { return oam[oam_address]; }
        private byte Peek2007(int address)
        {
            byte tmp;

            if ((scroll.addr & 0x3F00) == 0x3F00)
            {
                tmp = Nes.PpuMemory[scroll.addr];
                chr = Nes.PpuMemory[scroll.addr & 0x2FFF];
            }
            else
            {
                tmp = chr;
                chr = Nes.PpuMemory[scroll.addr];
            }

            scroll.addr = (scroll.addr + scroll.step) & 0x7FFF;

            return tmp;
        }
        private void Poke____(int address, byte data) { }
        private void Poke2000(int address, byte data)
        {
            scroll.temp = (scroll.temp & ~0x0C00) | (data << 10 & 0x0C00);
            scroll.step = (data & 0x04) != 0 ? 0x0020 : 0x0001;
            spr.address = (data & 0x08) != 0 ? 0x1000 : 0x0000;
            bkg.address = (data & 0x10) != 0 ? 0x1000 : 0x0000;
            spr.rasters = (data & 0x20) != 0 ? 0x0010 : 0x0008;

            nmi = (data & 0x80) != 0;

            if (nmi && ((value2000 & 0x80) == 0) && vbl)
                Nes.Cpu.requestNmi = true;
            if ((vclock == 242 & hclock < 2) && !nmi)
            {
                Nes.Cpu.requestNmi = false;
                Nes.Cpu.Interrupt(Cpu.IsrType.Ppu, false);
            }
            value2000 = data;
        }
        private void Poke2001(int address, byte data)
        {
            clipping = (data & 0x01) != 0 ? 0x30 : 0x3F;
            emphasis = (data & 0xE0) << 1;

            bkg.clipped = (data & 0x02) == 0;
            spr.clipped = (data & 0x04) == 0;
            bkg.enabled = (data & 0x08) != 0;
            spr.enabled = (data & 0x10) != 0;
        }
        private void Poke2003(int address, byte data)
        {
            oam_address = data;
        }
        private void Poke2004(int address, byte data)
        {
            oam[oam_address] = data;
            oam_address = ++oam_address & 0xFF;
        }
        private void Poke2005(int address, byte data)
        {
            if (scroll.swap = !scroll.swap)
            {
                scroll.temp = (scroll.temp & ~0x001F) | (data >> 3 & 0x001F);
                scroll.fine = (data & 0x07);
            }
            else
            {
                scroll.temp = (scroll.temp & ~0x73E0) | (data << 2 & 0x03E0) | (data << 12 & 0x7000);
            }
        }
        private void Poke2006(int address, byte data)
        {
            if (scroll.swap = !scroll.swap)
            {
                scroll.temp = (scroll.temp & ~0xFF00) | (data << 8 & 0x3F00);
            }
            else
            {
                scroll.temp = (scroll.temp & ~0x00FF) | (data << 0 & 0x00FF);
                scroll.addr = (scroll.temp);
            }
        }
        private void Poke2007(int address, byte data)
        {
            Nes.PpuMemory[scroll.addr] = data;

            scroll.addr = (scroll.addr + scroll.step) & 0x7FFF;
        }

        private void RenderPixel()
        {
            var bkgPixel = 0x3F00 | bkg.GetPixel(hclock, scroll.fine);
            var sprPixel = 0x3F10 | spr.GetPixel(hclock);

            // todo: handle priority and sprite-zero hit
            var pixel = bkgPixel;

            screen[vclock][hclock] = colors[Nes.PpuMemory[pixel]];
        }
        private void SynthesizeBkgPixels()
        {
            var pos = (hclock + 9) % 336;

            for (int i = 0; i < 8 && pos < 256; i++, pos++, fetch.bit0 <<= 1, fetch.bit1 <<= 1)
                bkg.pixels[pos] = (fetch.attr << 2 & 12) | (fetch.bit0 >> 7 & 1) | (fetch.bit1 >> 6 & 2);
        }
        private void SynthesizeSprPixels()
        {
            int pos = buffer[hclock >> 3 & 7].x;

            for (int i = 0; i < 8 && pos < 256; i++, pos++, fetch.bit0 <<= 1, fetch.bit1 <<= 1)
                spr.pixels[pos] = (fetch.attr << 2 & 12) | (fetch.bit0 >> 7 & 1) | (fetch.bit1 >> 6 & 2);
        }

        public override void Initialize()
        {
            Console.WriteLine("Initializing PPU...");

            for (int i = 0x0000; i < 0x2000; i += 8)
            {
                Nes.CpuMemory.Hook(0x2000 + i, Peek____, Poke2000);
                Nes.CpuMemory.Hook(0x2001 + i, Peek____, Poke2001);
                Nes.CpuMemory.Hook(0x2002 + i, Peek2002, Poke____);
                Nes.CpuMemory.Hook(0x2003 + i, Peek____, Poke2003);
                Nes.CpuMemory.Hook(0x2004 + i, Peek2004, Poke2004);
                Nes.CpuMemory.Hook(0x2005 + i, Peek____, Poke2005);
                Nes.CpuMemory.Hook(0x2006 + i, Peek____, Poke2006);
                Nes.CpuMemory.Hook(0x2007 + i, Peek2007, Poke2007);
            }

            Console.UpdateLine("Initializing PPU... Success!", DebugCode.Good);
        }
        public override void Shutdown() { }
        public override void Update()
        {
            if (vclock < 240 || vclock == 261)
            {
                if (bkg.enabled || spr.enabled)
                {
                    if (hclock < 256)
                    {
                        #region Bkg Fetches

                        switch (hclock & 7)
                        {
                            case 0: FetchName_0(); break;
                            case 1: FetchName_1(); break;
                            case 2: FetchAttr_0(); break;
                            case 3: FetchAttr_1(); scroll.ClockX(); break;
                            case 4: FetchBit0_0(); break;
                            case 5: FetchBit0_1(); break;
                            case 6: FetchBit1_0(); break;
                            case 7: FetchBit1_1(); SynthesizeBkgPixels(); break;
                        }

                        #endregion

                        if (vclock < 240)
                            RenderPixel();
                    }
                    else if (hclock < 320)
                    {
                        if (hclock == 256)
                        {
                            scroll.ClockY();
                            scroll.ResetX();
                        }

                        if (hclock == 304 && vclock == 261)
                            scroll.addr = scroll.temp;

                        #region Spr Fetches

                        switch (hclock & 7)
                        {
                            case 0: FetchName_0(); break;
                            case 1: FetchName_1(); break;
                            case 2: FetchAttr_0(); break;
                            case 3: FetchAttr_1(); break;
                            case 4: /*   Bit0   */ break;
                            case 5: /*   Bit0   */ break;
                            case 6: /*   Bit1   */ break;
                            case 7: /*   Bit1   */ SynthesizeSprPixels(); break;
                        }

                        #endregion
                    }
                    else if (hclock < 336)
                    {
                        #region Bkg Fetches

                        switch (hclock & 7)
                        {
                            case 0: FetchName_0(); break;
                            case 1: FetchName_1(); break;
                            case 2: FetchAttr_0(); break;
                            case 3: FetchAttr_1(); scroll.ClockX(); break;
                            case 4: FetchBit0_0(); break;
                            case 5: FetchBit0_1(); break;
                            case 6: FetchBit1_0(); break;
                            case 7: FetchBit1_1(); SynthesizeBkgPixels(); break;
                        }

                        #endregion
                    }
                    else if (hclock < 340)
                    {
                        #region Dummy Fetches

                        switch (hclock & 1)
                        {
                            case 0: FetchName_0(); break;
                            case 1: FetchName_1(); break;
                        }

                        #endregion
                    }
                    else
                    {
                        // Idle cycle
                    }
                }
                else
                {
                    // Rendering is off
                }
            }

            hclock++;
            //Nmi occur after 2 cycles of vblank
            if (hclock == 2)
            {
                if (vclock == 242)
                {
                    if (!suppressNmi)
                    {
                        if (nmi)
                            Nes.Cpu.Interrupt(Cpu.IsrType.Ppu, true);
                    }
                    else
                    {
                        suppressNmi = false;
                    }
                }
            }
            //odd frame
            if (hclock == 339)
            {
                if (vclock == 0)
                {
                    oddSwap = !oddSwap;

                    if (!oddSwap & bkg.enabled)
                    {
                        hclock++;
                    }
                }
            }

            if (hclock == 341)
            {
                hclock = 0;
                vclock++;

                if (vclock == 242)
                {
                    if (!suppressVbl)
                        vbl = true;
                    else
                        suppressVbl = false;
                }
                if (vclock == 262)
                {
                    vclock = 0;
                    vbl = false;

                    Nes.SpeedLimiter.Update();
                    Nes.VideoDevice.RenderFrame(screen);
                }
            }

        }

        public void SetupPalette(int[] colors)
        {
            this.colors = colors;
        }

        public class Fetch
        {
            public int addr;
            public int attr;
            public int bit0;
            public int bit1;
            public int name;
        }
        public class Scroll
        {
            public bool swap;
            public int addr;
            public int fine;
            public int step = 1;
            public int temp;

            public void ClockX()
            {
                if ((addr & 0x001F) == 0x001F)
                    addr ^= 0x041F;
                else
                    addr++;
            }
            public void ClockY()
            {
                if ((addr & 0x7000) != 0x7000)
                {
                    addr += 0x1000;
                }
                else
                {
                    addr ^= 0x7000;

                    switch (addr & 0x3E0)
                    {
                        case 0x3A0: addr ^= 0xBA0; break;
                        case 0x3E0: addr ^= 0x3E0; break;
                        default: addr += 0x20; break;
                    }
                }
            }
            public void ResetX()
            {
                addr = (addr & ~0x41F) | (temp & 0x41F);
            }
        }

        public struct Sprite
        {
            public byte y;
            public byte name;
            public byte attr;
            public byte x;
        }
        public class Unit
        {
            public bool clipped;
            public bool enabled;
            public int address;
            public int rasters = 8;
            public int[] pixels;

            public Unit(int capacity)
            {
                this.pixels = new int[capacity];
            }

            public int GetPixel(int hclock, int offset = 0)
            {
                //if (!enabled || (clipped && hclock < 8))
                //    return 0;

                return pixels[hclock + offset];
            }
        }
    }
}