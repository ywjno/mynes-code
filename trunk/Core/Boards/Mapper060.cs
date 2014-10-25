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
    [BoardInfo("Unknown", 60)]
    [NotImplementedWell("Mapper 60:\nNot work ?")]
    class Mapper060 : Board
    {
        private int latch = 0;
        private byte menu = 0;
        public override void HardReset()
        {
            base.HardReset();
            latch = 0;
            menu = 0;
        }
        public override void SoftReset()
        {
            base.SoftReset();
            latch = 0;
            menu = (byte)((menu + 1) & 0x3);
            Switch08KCHR(menu, chr_01K_rom_count > 0);
            Switch16KPRG(menu, 0x8000, true);
            Switch16KPRG(menu, 0xC000, true);
        }
        public override void WritePRG(ref int address, ref byte data)
        {
            latch = address & 0x100;
            SwitchNMT((address & 0x8) == 0x8 ? Mirroring.Horz : Mirroring.Vert);
            Switch16KPRG((address >> 4) & ~(~address >> 7 & 0x1), 0x8000, true);
            Switch16KPRG((address >> 4) | (~address >> 7 & 0x1), 0xC000, true);
            Switch08KCHR(address, chr_01K_rom_count > 0);
        }
        public override byte ReadPRG(ref int address)
        {
            if (latch == 0)
                return base.ReadPRG(ref address);
            else
                return menu;
        }
        public override void SaveState(System.IO.BinaryWriter stream)
        {
            base.SaveState(stream);
            stream.Write(latch);
            stream.Write(menu);
        }
        public override void LoadState(System.IO.BinaryReader stream)
        {
            base.LoadState(stream);
            latch = stream.ReadInt32();
            menu = stream.ReadByte();
        }
    }
}
