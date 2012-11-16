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
    [BoardName("Bandai", 16)]
    class Bandai : Board
    {
        public Bandai() : base() { }
        public Bandai(byte[] chr, byte[] prg, byte[] trainer, bool isVram) : base(chr, prg, trainer, isVram) { }

        private bool irqEnable = false;
        private int irqCounter = 0;
        private byte[] EPROM;

        public override void Initialize()
        {
            base.Initialize();
            Nes.CpuMemory.Hook(0x6000, 0xFFFF, PeekPrg, PokePrg);
            Nes.Cpu.ClockCycle = ClockIrqTimer;
        }
        public override void HardReset()
        {
            base.HardReset();
            base.Switch16KPRG((prg.Length - 0x4000) >> 14, 0xC000);
            irqEnable = false;
            irqCounter = 0;
            EPROM = new byte[256];
        }
        protected override void PokePrg(int address, byte data)
        {
            switch (address & 0xF)
            {
                case 0x0: base.Switch01kCHR(data, 0x0000); break;
                case 0x1: base.Switch01kCHR(data, 0x0400); break;
                case 0x2: base.Switch01kCHR(data, 0x0800); break;
                case 0x3: base.Switch01kCHR(data, 0x0C00); break;
                case 0x4: base.Switch01kCHR(data, 0x1000); break;
                case 0x5: base.Switch01kCHR(data, 0x1400); break;
                case 0x6: base.Switch01kCHR(data, 0x1800); break;
                case 0x7: base.Switch01kCHR(data, 0x1C00); break;
                case 0x8: base.Switch16KPRG(data, 0x8000); break;
                case 0x9:
                    switch (data)
                    {
                        case 0: Nes.PpuMemory.SwitchMirroring(Types.Mirroring.ModeVert); break;
                        case 1: Nes.PpuMemory.SwitchMirroring(Types.Mirroring.ModeHorz); break;
                        case 2: Nes.PpuMemory.SwitchMirroring(Types.Mirroring.Mode1ScA); break;
                        case 3: Nes.PpuMemory.SwitchMirroring(Types.Mirroring.Mode1ScB); break;
                    }
                    break;
                case 0xA: irqEnable = (data & 1) == 1; Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, false); break;
                case 0xB: irqCounter = (irqCounter & 0xFF00) | data; break;
                case 0xC: irqCounter = (irqCounter & 0x00FF) | (data << 8); break;
                case 0xD: /*EPROM I/O , later :D*/break;
            }
        }

        private void ClockIrqTimer()
        {
            if (irqEnable)
            {
                if (irqCounter > 0)
                    irqCounter--;
                if (irqCounter == 0)
                {
                    irqEnable = false;
                    irqCounter = 0xFFFF;
                    Nes.Cpu.Interrupt(CPU.Cpu.IsrType.Brd, true);
                }
            }
        }

        public override void SaveState(Types.StateStream stream)
        {
            base.SaveState(stream);
            stream.Write(irqEnable);
            stream.Write(irqCounter);
            stream.Write(EPROM);
        }
        public override void LoadState(Types.StateStream stream)
        {
            base.LoadState(stream);
            irqEnable = stream.ReadBoolean();
            irqCounter = stream.ReadInt32();
            stream.Read(EPROM);
        }
    }
}
