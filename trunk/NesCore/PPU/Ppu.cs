namespace MyNes.Core
{
    // Emulates the RP2C02/RP2C07 graphics synthesizer
    public class Ppu
    {
        private Scroll scroll = new Scroll();
        private Unit bkg = new Unit(272);
        private Unit spr = new Unit(256);
        private bool vbl;
        private int hclock;
        private int vclock;

        public Ppu()
        {
        }

        private byte Peek2002(int address)
        {
            byte data = 0;

            if (vbl) data |= 0x80;

            vbl = false;
            scroll.swap = false;

            return data;
        }
        private byte Peek2004(int address) { return 0; }
        private byte Peek2007(int address) { return 0; }

        public void Update()
        {
            hclock++;

            if (hclock == 341)
            {
                hclock = 0;
                vclock++;

                if (vclock == 241)
                    vbl = true;

                if (vclock == 262)
                {
                    vclock = 0;
                    vbl = false;
                }
            }
        }

        public class Scroll
        {
            public bool swap;
            public int addr;
            public int step;
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
                    addr += 0x1000;
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
        public class Unit
        {
            public bool clipped;
            public bool enabled;
            public int address;
            public int[] pixels;

            public Unit(int capacity)
            {
                this.pixels = new int[capacity];
            }

            public int GetPixel(int hclock, int offset = 0)
            {
                if (!enabled || (clipped && hclock < 8))
                    return 0;

                return pixels[hclock + offset];
            }
        }
    }
}