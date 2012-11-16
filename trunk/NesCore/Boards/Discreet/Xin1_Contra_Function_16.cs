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
    [BoardName("100-in-1 Contra Function 16", 15)]
    class Xin1_Contra_Function_16 : Board
    {
        public Xin1_Contra_Function_16()
            : base()
        { }
        public Xin1_Contra_Function_16(byte[] chr, byte[] prg, byte[] trainer, bool isVram)
            : base(chr, prg, trainer, isVram)
        { }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void PokePrg(int address, byte data)
        {
            byte lb = (byte)((data >> 7) & 1);
            data <<= 1;
            data &= 0xFE;

            switch (address & 0xFFF)
            {
                case 0:
                    base.Switch08KPRG((data + 0) ^ lb, 0x8000);
                    base.Switch08KPRG((data + 1) ^ lb, 0xA000);
                    base.Switch08KPRG((data + 2) ^ lb, 0xC000);
                    base.Switch08KPRG((data + 3) ^ lb, 0xE000);
                    break;

                case 2:
                    data |= lb;
                    base.Switch08KPRG(data, 0x8000);
                    base.Switch08KPRG(data, 0xA000);
                    base.Switch08KPRG(data, 0xC000);
                    base.Switch08KPRG(data, 0xE000);
                    break;

                case 1:
                case 3:
                    data |= lb;
                    base.Switch08KPRG(data, 0x8000);
                    base.Switch08KPRG(data + 1, 0xA000);
                    base.Switch08KPRG(data + ((~address >> 1) & 1), 0xC000);
                    base.Switch08KPRG(data + 1, 0xE000);
                    break;

            }
            Nes.PpuMemory.SwitchMirroring((data & 0x40) == 0x40 ? Types.Mirroring.ModeHorz : Types.Mirroring.ModeVert);
        }
    }
}
