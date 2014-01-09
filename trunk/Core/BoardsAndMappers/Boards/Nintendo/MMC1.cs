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
using MyNes.Core;

namespace MyNes.Core.Boards
{
    abstract class MMC1 : Board
    {
        public MMC1() : base() { }
        public MMC1(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        protected byte[] reg = new byte[4];
        protected byte shift = 0;
        protected byte buffer = 0;
        protected bool flag_p;
        protected bool flag_c;
        protected bool flag_s;
        // These masks determines which MMC1 board we're dealing with ....
        // examples:
        //
        // NES-SAROM: Max. 128K PRG (16kb mask = 0x0F), 64K CHR (4kb mask = 0xF), 8K WRAM, Battery-backable.
        // * We don't need to use prg hijacked bit because of PRG mask=0x0F and bit4 is not needed !
        // * We can't switch WRAM because of chr_mask = 0xF then bits2-3 are locked for CHR switch !
        //
        // NES-SGROM: Max. 256K PRG (16kb mask = 0x1F), 8K CHR RAM (4kb mask = 0x01)
        // * We need to use prg hijacked bit because of PRG mask=0x1F and bit4 is needed !
        // * We can switch WRAM because of chr_mask = 0x1 then bits2-3 are usable ....
        // * Since bit4 of chr register is usable, we can add it to the sram offset so bit2:4 can be used for SRAM offset 
        //   then 32KB prg ram can be used.

        protected int prg_hijackedbit;

        public override void HardReset()
        {
            base.HardReset();
            // PRG
            base.Switch16KPRGROM(0, 0x8000);
            base.Switch16KPRGROM(PRGROM16KBBanksCountMask, 0xC000);

            // Registers
            reg = new byte[4];
            reg[0] = 0x0C;
            flag_s = flag_p = true;
            prg_hijackedbit = 0;
            reg[1] = reg[2] = reg[3] = 0;
            // Buffers
            buffer = 0;
            shift = 0;
        }
        public override void WritePRG(int address, byte value)
        {
            // Too close writes ignored !
            if (NesCore.CPU.BUS_RW == NesCore.CPU.BUS_RW_P)
                return;
            //Temporary reg port ($8000-FFFF):
            //[r... ...d]
            //r = reset flag
            //d = data bit

            //r is set
            if ((value & 0x80) == 0x80)
            {
                reg[0] |= 0x0C;//bits 2,3 of reg $8000 are set (16k PRG mode, $8000 swappable)
                flag_s = flag_p = true;
                shift = buffer = 0;//hidden temporary reg is reset
                return;
            }
            //d is set
            if ((value & 0x01) == 0x01)
                buffer |= (byte)(1 << shift);//'d' proceeds as the next bit written in the 5-bit sequence
            if (++shift < 5)
                return;
            // If this completes the 5-bit sequence:
            // - temporary reg is copied to actual internal reg (which reg depends on the last address written to)
            address = (ushort)((address & 0x7FFF) >> 13);
            reg[address] = buffer;

            // - temporary reg is reset (so that next write is the "first" write)
            shift = buffer = 0;

            // Update internal registers ...
            switch (address)
            {
                case 0:// $8000-9FFF [Flags and mirroring]
                    {
                        // Flags
                        flag_c = (reg[0] & 0x10) != 0;
                        flag_p = (reg[0] & 0x08) != 0;
                        flag_s = (reg[0] & 0x04) != 0;
                        // Mirroring
                        switch (reg[0] & 3)
                        {
                            case 0: base.SwitchMirroring(Mirroring.Mode1ScA); break;
                            case 1: base.SwitchMirroring(Mirroring.Mode1ScB); break;
                            case 2: base.SwitchMirroring(Mirroring.ModeVert); break;
                            case 3: base.SwitchMirroring(Mirroring.ModeHorz); break;
                        }
                        break;
                    }
                case 1:// $A000-BFFF [CHR REG 0]
                case 2:// $C000-DFFF [CHR REG 1]
                    {
                        // PRG hijacked bit (the bit4 can't be used as chr bank switch !)
                        if ((CHR_04KBBanksCountMask & 0x10) == 0x00)
                        {
                            int sramV = 0;
                            // We can use prg hijack !!
                            // Check if hijack can be used ...
                            if ((PRGROM16KBBanksCountMask & 0x10) == 0x10)
                            {
                                prg_hijackedbit = reg[1] & 0x10;
                                UpdatePRG();
                                // SRAM page select
                                if ((CHR_04KBBanksCountMask & 0xC) == 0x00)
                                    sramV = ((reg[1] & 0x8) >> 3);
                            }
                            else
                            {
                                // hijack can't be used .... we can use the 4th bit for sram instead
                                if ((CHR_04KBBanksCountMask & 0xC) == 0x00)
                                    sramV = ((reg[1] & 0x18) >> 3);
                            }
                            //Console.WriteLine(string.Format("SRAM switch: {0:X2}", sramV), DebugCode.Warning);
                            base.Switch08KPRG(sramV, 0x6000);
                        }

                        UpdateCHR();
                        break;
                    }
                case 3:// $E000-FFFF [PRG REG]
                    {
                        base.TogglePRGRAMEnable((reg[3] & 0x10) == 0);
                        UpdatePRG();
                        break;
                    }
            }
        }

        protected virtual void UpdatePRG()
        {
            if (!flag_p)
            {
                base.Switch32KPRGROM(((reg[3] & 0xF) | prg_hijackedbit) >> 1);
            }
            else
            {
                if (flag_s)
                {
                    base.Switch16KPRGROM((reg[3] & 0xF) | prg_hijackedbit, 0x8000);
                    base.Switch16KPRGROM(0xF | prg_hijackedbit, 0xC000);
                }
                else
                {
                    base.Switch16KPRGROM(0, 0x8000);
                    base.Switch16KPRGROM((reg[3] & 0xF) | prg_hijackedbit, 0xC000);
                }
            }
        }
        protected virtual void UpdateCHR()
        {
            if (!flag_c)
            {
                base.Switch08kCHR((reg[1] & CHR_04KBBanksCountMask) >> 1);
            }
            else
            {
                base.Switch04kCHR(reg[1] & CHR_04KBBanksCountMask, 0x0000);
                base.Switch04kCHR(reg[2] & CHR_04KBBanksCountMask, 0x1000);
            }
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(reg);
            stream.Write(shift);
            stream.Write(buffer);
            stream.Write(flag_p);
            stream.Write(flag_c);
            stream.Write(flag_s);
            stream.Write(prg_hijackedbit);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            stream.Read(reg, 0, 4);
            shift = stream.ReadByte();
            buffer = stream.ReadByte();
            flag_p = stream.ReadBoolean();
            flag_c = stream.ReadBoolean();
            flag_s = stream.ReadBoolean();
            prg_hijackedbit = stream.ReadInt32();
        }
    }
}
