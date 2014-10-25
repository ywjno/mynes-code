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
namespace MyNes.Core
{
    [BoardInfo("Mario Baby", 42)]
    class Mapper042 : Board
    {
        private int SRAM_PRG_Page = 0;
        private bool irqEnable = false;
        private int irqCounter = 0;

        public override void HardReset()
        {
            base.HardReset();
            Switch32KPRG(prg_32K_rom_mask, true);
        }
        public override void WritePRG(ref int address, ref byte data)
        {
            if (address == 0x8000)
            {
                Switch08KCHR(data, chr_01K_rom_count > 0);
            }
            else if (address == 0xF000)
            {
                SRAM_PRG_Page = data << 13;
            }
            else
                switch (address & 0xE003)
                {
                    case 0xE000:
                        base.Switch08KPRG(data, 0x6000, true);
                        break;

                    case 0xE001:
                        if ((data & 0x8) == 0x8)
                            SwitchNMT(Mirroring.Horz);
                        else
                            SwitchNMT(Mirroring.Vert);
                        break;

                    case 0xE002:
                        irqEnable = (data & 2) == 2;
                        if (!irqEnable)
                            irqCounter = 0;
                        NesEmu.IRQFlags &= ~NesEmu.IRQ_BOARD;
                        break;
                }
        }
        public override void OnCPUClock()
        {
            if (irqEnable)
            {
                int prev = irqCounter++;

                if ((irqCounter & 0x6000) != (prev & 0x6000))
                {
                    if ((irqCounter & 0x6000) == 0x6000)
                        NesEmu.IRQFlags |= NesEmu.IRQ_BOARD;
                    else
                        NesEmu.IRQFlags &= ~NesEmu.IRQ_BOARD;
                }
            }
        }
        public override void SaveState(System.IO.BinaryWriter stream)
        {
            base.SaveState(stream);
            stream.Write(SRAM_PRG_Page);
            stream.Write(irqEnable);
            stream.Write(irqCounter);
        }
        public override void LoadState(System.IO.BinaryReader stream)
        {
            base.LoadState(stream);
            SRAM_PRG_Page = stream.ReadInt32();
            irqEnable = stream.ReadBoolean();
            irqCounter = stream.ReadInt32();
        }
    }
}
