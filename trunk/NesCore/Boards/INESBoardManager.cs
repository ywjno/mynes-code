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
using MyNes.Core.Boards.Discreet;
using MyNes.Core.Boards.Nintendo;
using MyNes.Core.Boards.FFE;
using MyNes.Core.ROM;

namespace MyNes.Core.Boards
{
    public static class INESBoardManager
    {
        public static Board GetBoard(INESHeader header, byte[] chr, byte[] prg, byte[] trainer)
        {
            // todo: add more cases, until a proprietary format is devised to store all of this information

            switch (header.Mapper)
            {
                case 0:
                    switch (header.PrgPages * 0x4000)
                    {
                        case 0x4000: return new NROM128(chr, prg); // 128 kb PRG, 8kB CHR-RAM
                        case 0x8000: return new NROM256(chr, prg); // 256 kb PRG, 8kB CHR-RAM
                    }
                    break;

                case 1:
                    if (prg.Length < 0x80000)
                        return new MMC1(chr, prg, header.IsVram);
                    else
                        return new MMC1_SUROM(chr, prg, header.IsVram);

                case 2:
                    switch (header.PrgPages * 16384)
                    {
                        case 0x20000: return new UNROM(chr, prg); // 128 kB PRG, 8kB CHR-RAM
                        case 0x40000: return new UOROM(chr, prg); // 256 kB PRG, 8kB CHR-RAM
                    }
                    break;

                case 3: return new CNROM(chr, prg);

                case 4: return new MMC3(chr, prg, header.IsVram);

                case 5: return new MMC5(chr, prg, header.IsVram);

                case 6: return new FFE_F4xxx(chr, prg, trainer, header.IsVram);

                case 7: return new AxROM(chr, prg);

                case 71: return new Camerica(chr, prg);
            }

            return null;
        }
    }
}