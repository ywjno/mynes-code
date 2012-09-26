/* This file is part of My Nes
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
using MyNes.Core.Types;
namespace MyNes.Core.Boards.Nintendo
{
    [BoardName("MMC1 [SUROM]")]
    class MMC1_SUROM : Board
    {
        public MMC1_SUROM(byte[] chr, byte[] prg, bool isVram)
            : base(chr, prg)
        {
        }
        public override void Initialize()
        {            
            //setup sram
            Nes.CpuMemory.Hook(0x6000, 0x7FFF, PeekSram, PokeSram);
            base.Initialize();
        }
        public override void HardReset()
        {
            base.HardReset();
            reg = new byte[4];
            reg[0] = 0x0C;
            reg[1] = reg[2] = reg[3] = 0;

            //setup prg
            base.Switch16KPRG(0, 0x8000);
            base.Switch16KPRG(0xF, 0xC000);

            //setup chr
            if (isVram)
                chr = new byte[0x4000];//16 k
            base.Switch08kCHR(0);

            wramON = true;
            shift = 0; 
            buffer = 0;
            sram = new byte[0x2000];
        }
        private bool isVram;
        private byte[] reg = new byte[4];
        private byte[] sram = new byte[0x2000];
        private byte shift = 0;
        private byte buffer = 0;
        private bool wramON = true;//enable sram, not sure about this but some docs mansion it

        public override void SetSram(byte[] buffer)
        {
            buffer.CopyTo(sram, 0);
        }
        public override byte[] GetSaveRam()
        {
            return sram;
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

            if (address == 0)
            {
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
            }

            if ((reg[0] & 0x10) == 0x10)
            {
                base.Switch04kCHR(reg[1], 0);
                base.Switch04kCHR(reg[2], 0x1000);
            }
            else
            {
                base.Switch08kCHR(reg[1] >> 1);
            }
            int BASE = reg[1] & 0x10;
            wramON = (reg[3] & 0x10) == 0;
            if ((reg[0] & 0x08) == 0)
            {
                base.Switch32KPRG((reg[3] & (0xF + BASE)) >> 1);
            }
            else
            {
                if ((reg[0] & 0x04) == 0x04)
                {
                    base.Switch16KPRG(BASE + (reg[3] & 0x0F), 0x8000);
                    base.Switch16KPRG(BASE + 0xF, 0xC000);
                }
                else
                {

                    base.Switch16KPRG(BASE, 0x8000);
                    base.Switch16KPRG(BASE + (reg[3] & 0x0F), 0xC000);
                }
            }
        }
        public override void SaveState(StateStream stream)
        {
            base.SaveState(stream);
            stream.Write(reg);
            stream.Write(sram);
            stream.Write(shift);
            stream.Write(buffer);
            stream.Write(wramON);
        }
        public override void LoadState(StateStream stream)
        {
            base.LoadState(stream);
            stream.Read(reg);
            stream.Read(sram);
            shift = stream.ReadByte();
            buffer = stream.ReadByte();
            wramON = stream.ReadBoolean();
        }
    }
}
