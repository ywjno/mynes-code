using myNES.Core.Types;

namespace myNES.Core.Boards.Nintendo
{
    public class SxROM : Board
    {
        bool isVram;
        byte[] reg = new byte[4];
        byte[] sram = new byte[0x2000];
        byte shift = 0;
        byte value = 0;
        bool MODE = false;
        bool wramEnable = true;//enable sram, not sure about this but some docs mansion it
        int cc = 0;

        public SxROM(byte[] chr, byte[] prg, bool isVram)
            : base(chr, prg)
        {
            this.isVram = isVram;
            chrPage = new int[2];
            chrPage[0] = 0x0000;
            chrPage[1] = 0x1000;

            prgPage = new int[2];
            prgPage[0] = 0x8000;
            prgPage[1] = 0xC000;
        }

        private void Poke8000()
        {
            /* M = Mirroring control:
             * %00 = 1ScA
             * %01 = 1ScB
             * %10 = Vert
             * %11 = Horz
             */

            switch (reg[0] & 0x03)
            {
            case 0: Nes.PpuMemory.SwitchMirroring(Mirroring.Mode1ScA); break;
            case 1: Nes.PpuMemory.SwitchMirroring(Mirroring.Mode1ScB); break;
            case 2: Nes.PpuMemory.SwitchMirroring(Mirroring.ModeVert); break;
            case 3: Nes.PpuMemory.SwitchMirroring(Mirroring.ModeHorz); break;
            }
        }
        private void PokeA000()
        {
            chrPage[0] = (reg[1] & 0x1F) << 12;
        }
        private void PokeC000()
        {
            chrPage[1] = (reg[2] & 0x1F) << 12;
        }
        private void PokeE000()
        {
            /* $E000-FFFF:  [...W PPPP]
             * W = WRAM Disable (0=enabled, 1=disabled)
             * P = PRG Reg
             */

            wramEnable = (reg[3] & 0x10) == 0;
            prgPage[0] = (reg[3] & 0x0F) << 14;
        }

        private void PokeSram(int address, byte data)
        {
            if (wramEnable)
                sram[address - 0x6000] = data;
        }
        private byte PeekSram(int address)
        {
            if (wramEnable)
                return sram[address - 0x6000];
            return 0;
        }

        protected override int DecodeChrAddress(int address)
        {
            switch (reg[0] >> 4 & 0x01)
            {
            case 0: return (address & 0x1FFF) | (chrPage[0] & ~0x1FFF);
            case 1:
                switch (address & 0x1000)
                {
                case 0x0000: return (address & 0x0FFF) | chrPage[0];
                case 0x1000: return (address & 0x0FFF) | chrPage[1];
                }
                break;
            }

            return base.DecodeChrAddress(address);
        }
        protected override int DecodePrgAddress(int address)
        {
            switch (reg[0] >> 2 & 0x03)
            {
            case 0:
            case 1: return (address & 0x7FFF) | (prgPage[0] & ~0x7FFF);
            case 2:
                switch (address & 0xC000)
                {
                case 0x8000: return (address & 0x3FFF) | (0x00 << 14 & ~0x3FFF);
                case 0xC000: return (address & 0x3FFF) | (prgPage[0] & ~0x3FFF);
                }
                break;
            case 3:
                switch (address & 0xC000)
                {
                case 0x8000: return (address & 0x3FFF) | (prgPage[0] & ~0x3FFF);
                case 0xC000: return (address & 0x3FFF) | (0x0F << 14 & ~0x3FFF);
                }
                break;
            }

            return base.DecodePrgAddress(address);
        }
        protected override void PokePrg(int address, byte data)
        {
            if ((data & 0x80) != 0)
            {
                reg[0] |= 0x0C;
                shift = 0;
                value = 0;
                return;
            }

            value |= (byte)((data & 0x01) << shift++);

            if (shift < 5)
                return;

            address = (address >> 13 & 0x03);
            reg[address] = value;

            shift = 0;
            value = 0;

            if (!MODE)//Normal mode + [SOROM]
            {
                switch (address)
                {
                case 0: Poke8000(); break;
                case 1: PokeA000(); break;
                case 2: PokeC000(); break;
                case 3: PokeE000(); break;
                }
            }
            else//roms with 512K and larger [SUROM]+[SXROM]
            {
                int BASE = reg[1] & 0x10;

                if (address == 0)
                {
                    if ((reg[0] & 0x02) == 0x02)
                    {
                        if ((reg[0] & 0x01) == 0x01)
                            Nes.PpuMemory.SwitchMirroring(Mirroring.ModeHorz);
                        else
                            Nes.PpuMemory.SwitchMirroring(Mirroring.ModeVert);
                    }
                    else
                    {
                        if ((reg[0] & 0x01) != 0)
                            Nes.PpuMemory.SwitchMirroring(Mirroring.Mode1ScB);
                        else
                            Nes.PpuMemory.SwitchMirroring(Mirroring.Mode1ScA);
                    }
                }

                if (!isVram)
                {
                    if ((reg[0] & 0x10) == 0x10)
                    {
                        chrPage[0] = reg[1] << 12;
                    }
                    else
                    {
                        chrPage[0] = reg[1] << 11;
                        chrPage[1] = chrPage[0] + 0x1000;
                    }
                }
                else
                {
                    if ((reg[0] & 0x10) == 0x10)
                    {
                        chrPage[0] = reg[1] << 12;
                    }
                }

                if (!isVram)
                {
                    if ((reg[0] & 0x10) == 0x10)
                    {
                        chrPage[1] = reg[2] << 12;
                    }
                }
                else
                {
                    if ((reg[0] & 0x10) == 0x10)
                    {
                        chrPage[1] = reg[2] << 12;
                    }
                }

                wramEnable = (reg[3] & 0x10) == 0;

                if ((reg[0] & 0x08) == 0)
                {
                    prgPage[0] = (reg[3] & (0xF + BASE)) << 13;
                    prgPage[1] = prgPage[0] + 0x4000;
                }
                else
                {
                    if ((reg[0] & 0x04) == 0x04)
                    {
                        prgPage[0] = (BASE + (reg[3] & 0x0F)) << 14;
                        prgPage[1] = (BASE + 15) << 14;
                    }
                    else
                    {
                        prgPage[0] = BASE << 14;
                        prgPage[1] = (BASE + (reg[3] & 0x0F)) << 14;
                    }
                }
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            reg[0] = 0x0C;
            reg[1] = 0x00;
            reg[2] = 0x00;
            reg[3] = 0x00;

            if (isVram)
                chr = new byte[0x4000];

            Nes.CpuMemory.Hook(0x6000, 0x7FFF, PeekSram, PokeSram);
        }
    }
}