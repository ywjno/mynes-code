using myNES.Core.Types;
namespace myNES.Core.Boards.Nintendo
{
    class MMC1 : Board
    {
        public MMC1(byte[] chr, byte[] prg, bool isVram)
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
        public override void Initialize()
        {
            base.Initialize();

            reg[0] = 0x0C;
            reg[1] = reg[2] = reg[3] = 0;

            //setup prg
            if (prg.Length < 0x80000)
            {
                prgPage[0] = 0x8000;
                prgPage[1] = prg.Length - 0x4000;//last bank
            }
            else//larger than 512K
            {
                prgPage[0] = 0x8000;
                prgPage[1] = 15 << 14;
                MODE = true;
            }
            //setup chr
            if (isVram)
                chr = new byte[0x4000];//16 k
            chrPage[0] = 0x0000;
            chrPage[1] = 0x1000;

            //setup sram
            Nes.CpuMemory.Hook(0x6000, 0x7FFF, PeekSram, PokeSram);
        }

        bool isVram;
        byte[] reg = new byte[4];
        byte[] sram = new byte[0x2000];
        byte shift = 0;
        byte buffer = 0;
        bool MODE = false;
        bool wramON = true;//enable sram, not sure about this but some docs mansion it
        int cc = 0;

        protected override int DecodeChrAddress(int address)
        {
            /*
             * There are 2 CHR regs and 2 CHR modes.

            $0000   $0400   $0800   $0C00   $1000   $1400   $1800   $1C00 
          +---------------------------------------------------------------+
C=0:      |                            <$A000>                            |
          +---------------------------------------------------------------+
C=1:      |             $A000             |             $C000             |
          +-------------------------------+-------------------------------+
             */
            switch (address & 0x1000)
            {
                case 0x0000: return (address & 0x0FFF) | chrPage[0];
                case 0x1000: return (address & 0x0FFF) | chrPage[1];
            }

            return base.DecodeChrAddress(address);
        }
        protected override int DecodePrgAddress(int address)
        {
            /*
             There is 1 PRG reg and 3 PRG modes.

               $8000   $A000   $C000   $E000
             +-------------------------------+
P=0:         |            <$E000>            |
             +-------------------------------+
P=1, S=0:    |     { 0 }     |     $E000     |
             +---------------+---------------+
P=1, S=1:    |     $E000     |     {$0F}     |
             +---------------+---------------+
             */
            switch (address & 0xC000)
            {
                case 0x8000: return (address & 0x3FFF) | prgPage[0];
                case 0xC000: return (address & 0x3FFF) | prgPage[1];
            }
            return base.DecodePrgAddress(address);
        }
        protected override void PokePrg(int address, byte data)
        {
            //Temporary reg port ($8000-FFFF):
            //[r... ...d]
            //r = reset flag
            //d = data bit

            //r is set
            if ((data & 0x80) == 0x80)
            {
                reg[0] |= 0x0C;//bits 2,3 of reg $8000 are set (16k PRG mode, $8000 swappable)
                shift = buffer = 0;//hidden temporary reg is reset
                return;
            }
            //d is set
            if ((data & 0x01) == 0x01)
                buffer |= (byte)(1 << shift);//'d' proceeds as the next bit written in the 5-bit sequence
            if (++shift < 5)
                return;
            // If this completes the 5-bit sequence:
            // - temporary reg is copied to actual internal reg (which reg depends on the last address written to)
            address = (ushort)((address & 0x7FFF) >> 13);
            reg[address] = buffer;

            // - temporary reg is reset (so that next write is the "first" write)
            shift = buffer = 0;

            //  $8000-9FFF:  [...C PSMM]
            if (!MODE)
            {
                switch (address)
                {
                    case 0:
                        /*
                       M = Mirroring control:
                       %00 = 1ScA
                       %01 = 1ScB
                       %10 = Vert
                       %11 = Horz
                         */
                        if ((reg[0] & 0x02) == 0x02)
                        {
                            if ((reg[0] & 0x01) != 0)
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
                        break;

                    case 1://C = CHR Mode (0=8k mode, 1=4k mode)

                        if (!isVram)
                        {
                            if ((reg[0] & 0x10) != 0)
                            {
                                chrPage[0] = reg[1] << 12;
                                chrPage[1] = reg[2] << 12;
                            }
                            else
                            {
                                chrPage[0] = reg[1] << 11;
                                chrPage[1] = chrPage[0] + 0x1000;
                            }
                        }
                        else
                        {
                            if ((reg[0] & 0x10) != 0)
                            {
                                chrPage[0] = reg[1] << 12;
                            }
                        }
                        break;

                    case 2:

                        if (!isVram)
                        {
                            if ((reg[0] & 0x10) != 0)
                            {
                                chrPage[0] = reg[1] << 12;
                                chrPage[1] = reg[2] << 12;
                            }
                            else
                            {
                                chrPage[0] = reg[1] << 11;
                                chrPage[1] = chrPage[0] + 0x1000;
                            }
                        }
                        else
                        {
                            if ((reg[0] & 0x10) != 0)
                            {
                                chrPage[1] = reg[2] << 12;
                            }
                        }
                        break;

                    case 3:
                        /*
                            S = Slot select:
                            0 = $C000 swappable, $8000 fixed to page $00 (mode A)
                            1 = $8000 swappable, $C000 fixed to page $0F (mode B)
                            This bit is ignored when 'P' is clear (32k mode)
                        */
                        /*
                         *  $E000-FFFF:  [...W PPPP]
                            W = WRAM Disable (0=enabled, 1=disabled)
                            P = PRG Reg
                         */
                        wramON = (reg[3] & 0x10) == 0;

                        if ((reg[0] & 0x08) == 0)
                        {
                            prgPage[0] = reg[3] << 13;
                            prgPage[1] = prgPage[0] + 0x4000;
                        }
                        else
                        {
                            if ((reg[0] & 0x04) != 0)
                            {
                                prgPage[0] = reg[3] << 14;
                                prgPage[1] = prg.Length - 0x4000;//last bank
                            }
                            else
                            {
                                prgPage[0] = 0x8000;
                                prgPage[1] = reg[3] << 14;
                            }
                        }
                        break;
                }
            }
            else//roms with 512K and larger
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
                wramON = (reg[3] & 0x10) == 0;
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

        private void PokeSram(int address, byte data)
        {
            if (wramON)
                sram[address - 0x6000] = data;
        }
        private byte PeekSram(int address)
        {
            if (wramON)
                return sram[address - 0x6000];
            return 0;
        }
    }
}
