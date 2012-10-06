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

namespace MyNes.Core.Boards.FFE
{
    class FFE : Board
    {
        public FFE(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : 
            base(chr, prg)
        {
            this.trainer = trainer;
            this.isVram = isVram;
        }
        protected bool isVram;
        protected bool IRQEnabled = false;
        protected int irq_counter = 0;
        protected byte[] sram = new byte[0x2000];
        protected byte[] trainer;

        public override void Initialize()
        {
            base.Initialize();
            Nes.CpuMemory.Hook(0x4018, 0x5FFF, PeekPrg, PokePrg);
            Nes.CpuMemory.Hook(0x6000, 0x7FFF, PeekSram, PokeSram);
        }
        public override void HardReset()
        {
            base.HardReset();
            sram = new byte[0x2000];
            //trainer loaded into address 0x7000
            trainer.CopyTo(sram, 0x1000);
            Nes.Cpu.ClockCycle = TickIRQTimer;

            //setup chr
            if (isVram)
                chr = new byte[0x10000];//64 k
            base.Switch08kCHR(0);
        }
        protected override byte PeekPrg(int address)
        {
            return base.PeekPrg(address);
        }
        protected override void PokePrg(int address, byte data)
        {
            switch (address)
            {
                case 0x42FE:
                    if ((data & 0x10) != 0)
                        Nes.PpuMemory.SwitchMirroring(Types.Mirroring.Mode1ScB);
                    else
                        Nes.PpuMemory.SwitchMirroring(Types.Mirroring.Mode1ScA);
                    break;
                case 0x42FF:
                    if ((data & 0x10) != 0)
                        Nes.PpuMemory.SwitchMirroring(Types.Mirroring.ModeHorz);
                    else
                        Nes.PpuMemory.SwitchMirroring(Types.Mirroring.ModeVert);
                    break;
                case 0x4501: IRQEnabled = false; Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, false); break;
                case 0x4502: irq_counter = (short)((irq_counter & 0xFF00) | data); break;
                case 0x4503: irq_counter = (short)((data << 8) | (irq_counter & 0x00FF)); IRQEnabled = true;
                    Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, false); break;
            }
        }
        private void TickIRQTimer()
        {
            if (IRQEnabled)
            {
                irq_counter ++;
                if (irq_counter >= 0xFFFF)
                {
                    irq_counter = 0;
                    Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, true);
                }
            }
        }
        private void PokeSram(int address, byte data)
        {
            sram[address - 0x6000] = data;
        }
        private byte PeekSram(int address)
        {
            return sram[address - 0x6000];
        }
        public override void SetSram(byte[] buffer)
        {
            buffer.CopyTo(sram, 0);
        }
        public override byte[] GetSaveRam()
        {
            return sram;
        }
    }
}
