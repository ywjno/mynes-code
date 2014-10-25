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
    [BoardInfo("Unknown", 53)]
    [NotImplementedWell("Mapper 53:\nNot work ?")]
    class Mapper053 : Board
    {
        private byte[] regs = new byte[2];
        private bool epromFirst;
        public override void HardReset()
        {
            base.HardReset();
            regs = new byte[2];
            epromFirst = true;
            Switch08KPRG(0, 0x6000, true);
        }
        public override void WritePRG(ref int address, ref byte data)
        {
            regs[1] = data;
            UpdatePrg();
        }
        public override void WriteSRM(ref int address, ref byte data)
        {
            regs[0] = data;
            UpdatePrg();
            SwitchNMT((data & 0x20) == 0x20 ? Mirroring.Horz : Mirroring.Vert);
        }
        private void UpdatePrg()
        {
            int r = regs[0] << 3 & 0x78;

            Switch08KPRG((r << 1 | 0xF) + (epromFirst ? 0x4 : 0x0), 0x6000, true);

            Switch16KPRG((regs[0] & 0x10) == 0x10 ? (r | (regs[1] & 0x7))
                + (epromFirst ? 0x2 : 0x0) : epromFirst ? 0x00 : 0x80, 0x8000, true);
            Switch16KPRG((regs[0] & 0x10) == 0x10 ? (r | (0xFF & 0x7)) + (epromFirst ? 0x2 : 0x0) : epromFirst ? 0x01 : 0x81,
                0xC000, true);
        }

        public override void SaveState(System.IO.BinaryWriter stream)
        {
            base.SaveState(stream);
            stream.Write(regs);
            stream.Write(epromFirst);
        }
        public override void LoadState(System.IO.BinaryReader stream)
        {
            base.LoadState(stream);
            stream.Read(regs, 0, 2);
            epromFirst = stream.ReadBoolean();
        }
    }
}
