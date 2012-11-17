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
/*Written by Ala Ibrahim Hadid*/
namespace MyNes.Core.Boards.Discreet
{
    [BoardName("Taito TC190V", 48)]
    class TaitoTC190V : Board
    {
        public TaitoTC190V() : base() { }
        public TaitoTC190V(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        private byte irqReload = 0xFF;
        private byte irqCounter = 0;
        private bool IrqEnable = false;
        private bool mmc3_alt_behavior = false;//true=rev A, false= rev B
        private bool clear = false;
        private int oldA12;
        private int newA12;
        private int timer;
        public override void Initialize()
        {
            base.Initialize();
            Nes.Ppu.AddressLineUpdating = this.PPU_AddressLineUpdating;
            Nes.Ppu.CycleTimer = this.TickPPU;
        }
        public override void HardReset()
        {
            // Switch 32KB prg bank at 0x8000
            // Switch 08KB chr bank at 0x0000
            base.HardReset();

            Switch16KPRG((prg.Length - 0x4000) >> 14, 0xC000);
        }
        protected override void PokePrg(int address, byte data)
        {
            switch (address & 0xE003)
            {
                case 0x8000:
                    Switch08KPRG(data , 0x8000);
                    //
                    break;
                case 0x8001: Switch08KPRG(data , 0xA000); break;
                case 0x8002: Switch02kCHR(data, 0x0000); break;
                case 0x8003: Switch02kCHR(data, 0x0800); break;
                case 0xA000: Switch01kCHR(data, 0x1000); break;
                case 0xA001: Switch01kCHR(data, 0x1400); break;
                case 0xA002: Switch01kCHR(data, 0x1800); break;
                case 0xA003: Switch01kCHR(data, 0x1C00); break;

                case 0xE000: Nes.PpuMemory.SwitchMirroring((data & 0x40) == 0x40 ? Types.Mirroring.ModeHorz : Types.Mirroring.ModeVert); break;

                case 0xC000: irqReload = (byte)(data^ 0xFF); break;
                case 0xC001: if (mmc3_alt_behavior) clear = true; irqCounter = 0; break;
                case 0xC002: IrqEnable = true; break;
                case 0xC003: IrqEnable = false; Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, false); break;
            }
        }
        private void TickPPU()
        {
            timer++;
        }
        private void PPU_AddressLineUpdating(int addr)
        {
            oldA12 = newA12;
            newA12 = addr & 0x1000;

            if (oldA12 < newA12)
            {
                if (timer > 12)
                {
                    int old = irqCounter;

                    if (irqCounter == 0 || clear)
                        irqCounter = irqReload;
                    else
                        irqCounter = (byte)(irqCounter - 1);

                    if ((!mmc3_alt_behavior || old != 0 || clear) && irqCounter == 0 && IrqEnable)
                        Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, true);

                    clear = false;
                }

                timer = 0;
            }
        }
    }
}
