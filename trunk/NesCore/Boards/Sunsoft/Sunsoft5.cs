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
using MyNes.Core.Types;
namespace MyNes.Core.Boards.Sunsoft
{
    [BoardName("Sunsoft B5 / FME-7", 69)]
    class Sunsoft5 : Board
    {
        public Sunsoft5() : base() { }
        public Sunsoft5(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        private int addressOf8000;
        private bool RamEnabled = false;
        private int sramAddress = 0;
        private bool ramRomSelect = false;

        private int irqCounter = 0;
        private bool irqEnableCountdown = false;
        private bool irqEnableTriggiring = false;

        public override void Initialize()
        {
            base.Initialize();

            Nes.Cpu.ClockCycle = TickCPU;
        }
        public override void HardReset()
        {
            base.HardReset();
            Switch08KPRG(prg.Length - 02000 >> 13, 0xE000);
            addressOf8000 = 0;
            RamEnabled = false;
            sramAddress = 0;
            ramRomSelect = false;

            irqCounter = 0;
            irqEnableCountdown = false;
            irqEnableTriggiring = false;
        }
        protected override void PokePrg(int address, byte data)
        {
            switch (address & 0xE000)
            {
                case 0x8000: addressOf8000 = data & 0xF; break;
                case 0xA000:
                    switch (addressOf8000)
                    {
                        case 0x0: Switch01kCHR(data, 0x0000); break;
                        case 0x1: Switch01kCHR(data, 0x0400); break;
                        case 0x2: Switch01kCHR(data, 0x0800); break;
                        case 0x3: Switch01kCHR(data, 0x0C00); break;
                        case 0x4: Switch01kCHR(data, 0x1000); break;
                        case 0x5: Switch01kCHR(data, 0x1400); break;
                        case 0x6: Switch01kCHR(data, 0x1800); break;
                        case 0x7: Switch01kCHR(data, 0x1C00); break;
                        case 0x8:
                            RamEnabled = (data & 0x80) == 0x80;
                            ramRomSelect = (data & 0x40) == 0x40;
                            sramAddress = data & 0x3F;
                            break;
                        case 0x9: Switch08KPRG(data, 0x8000); break;
                        case 0xA: Switch08KPRG(data, 0xA000); break;
                        case 0xB: Switch08KPRG(data, 0xC000); break;
                        case 0xC:
                            switch (data & 0x3)
                            {
                                case 0: Nes.PpuMemory.SwitchMirroring(Mirroring.ModeVert); break;
                                case 1: Nes.PpuMemory.SwitchMirroring(Mirroring.ModeHorz); break;
                                case 2: Nes.PpuMemory.SwitchMirroring(Mirroring.Mode1ScA); break;
                                case 3: Nes.PpuMemory.SwitchMirroring(Mirroring.Mode1ScB); break;
                            }
                            break;
                        case 0xD:
                            irqEnableCountdown = (data & 0x80) == 0x80;
                            irqEnableTriggiring = (data & 0x1) == 0x1;
                            if (!irqEnableTriggiring)
                                Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, false);
                            break;
                        case 0xE: irqCounter = (irqCounter & 0xFF00) | data; break;
                        case 0xF: irqCounter = (irqCounter & 0x00FF) | data << 8; break;
                    }
                    break;
            }
        }
        protected override byte PeekSram(int address)
        {
            if (RamEnabled)
            {
                if (ramRomSelect)
                    return base.PeekSram(address);
                else
                    return prg[(sramAddress << 13) | (address & 0x1FFF)];
            }
            return 0;
        }
        protected override void PokeSram(int address, byte data)
        {
            if (RamEnabled)
                base.PokeSram(address, data);
        }
        void TickCPU()
        {
            if (irqEnableCountdown)
            {
                irqCounter--;
                if (irqCounter == 0)
                {
                    irqCounter = 0xFFFF;
                    if (irqEnableTriggiring)
                        Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, true);
                }
            }
        }
        public override void SaveState(StateStream stream)
        {
            base.SaveState(stream);
            stream.Write(addressOf8000);
            stream.Write(RamEnabled);
            stream.Write(sramAddress);
            stream.Write(ramRomSelect);

            stream.Write(irqCounter);
            stream.Write(irqEnableCountdown);
            stream.Write(irqEnableTriggiring);
        }
        public override void LoadState(StateStream stream)
        {
            addressOf8000 = stream.ReadInt32();
            RamEnabled = stream.ReadBoolean();
            sramAddress = stream.ReadInt32();
            ramRomSelect = stream.ReadBoolean();

            irqCounter = stream.ReadInt32();
            irqEnableCountdown = stream.ReadBoolean();
            irqEnableTriggiring = stream.ReadBoolean();
        }
    }
}
