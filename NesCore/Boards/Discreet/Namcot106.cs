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
namespace MyNes.Core.Boards.Discreet
{
    [BoardName("Namcot 106", 19)]
    class Namcot106 : Board
    {
        public Namcot106() : base() { }
        public Namcot106(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        private int irqCounter = 0;
        private bool irqEnabled = false;
        private bool chrH = false;
        private bool chrL = false;
        public override void Initialize()
        {
            // Maps prg writes to 0x8000 - 0xFFFF. Maps sram reads and writes to 0x6000 - 0x8000.
            // Then do a hard reset.
            base.Initialize();
            Nes.CpuMemory.Hook(0x4018, 0x5FFF, PeekPrg, PokePrg);
            Nes.Cpu.ClockCycle = TickIRQTimer;
            //this board has CRAM, so add 32 KB of cram at the end of chr space we have here
            System.Array.Resize(ref chr, chr.Length + 0x8000);
        }
        public override void HardReset()
        {
            // Switch 32KB prg bank at 0x8000
            // Switch 08KB chr bank at 0x0000
            base.HardReset();
            Switch08KPRG((prg.Length - 0x2000) >> 13, 0xE000);
        }
        protected override void PokePrg(int address, byte data)
        {
            switch (address & 0xF800)
            {
                case 0x5000: irqCounter = (irqCounter & 0x7F00) | (data<<0); break;
                case 0x5800: irqCounter = (irqCounter & 0x00FF) | (data << 8); irqEnabled = (data & 0x80) == 0x80; break;
                    /*prg*/
                case 0xE000: Switch08KPRG(data & 0x3F, 0x8000); break;
                case 0xE800: 
                    Switch08KPRG(data & 0x3F, 0xA000);
                    chrL = (data & 0x40) == 0x40;     
                    chrH = (data & 0x80) == 0x80;
                    break;
                case 0xF000: Switch08KPRG(data & 0x3F, 0xC000); break;
                    /*chr*/
                case 0x8000: Switch01kCHR(data | (chrL ? 0xDF : 0x00), 0x0000); break;
                case 0x8800: Switch01kCHR(data | (chrL ? 0xDF : 0x00), 0x0400); break;
                case 0x9000: Switch01kCHR(data | (chrL ? 0xDF : 0x00), 0x0800); break;
                case 0x9800: Switch01kCHR(data | (chrL ? 0xDF : 0x00), 0x0C00); break;
                case 0xA000: Switch01kCHR(data | (chrH ? 0xDF : 0x00), 0x1000); break;
                case 0xA800: Switch01kCHR(data | (chrH ? 0xDF : 0x00), 0x1400); break;
                case 0xB000: Switch01kCHR(data | (chrH ? 0xDF : 0x00), 0x1800); break;
                case 0xB800: Switch01kCHR(data | (chrH ? 0xDF : 0x00), 0x1C00); break;
            }
        }
        protected override byte PeekPrg(int address)
        {
            switch (address & 0xF800)
            {
                case 0x5000: return (byte)(irqCounter & 0x00FF);
                case 0x5800: return (byte)((irqCounter & 0x7F00) | (irqEnabled ? 0x8000 : 0x000));
            }
            return base.PeekPrg(address);
        }
        private void TickIRQTimer()
        {
        }
    }
}
