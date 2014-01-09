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
namespace MyNes.Core.PPU
{
    public partial class PPU2C02 : IProcesserBase
    {     
        private bool nmi_enabled;
        private bool vbl_flag;
        private bool vbl_flag_temp;

        // NMI status is between 1 and 3 (edge detector get nmi request at this time)
        // NMI disable via $2000 works only when written in HClock between 1 and 3
        // Special case: nmi can be set anytime if vbl flag is set and nmi enabled via reg $2000 (this register force edge detector)
        private void CheckNMI()
        {
            // At VBL time
            if (VClock == vbl_vclock_Start && HClock < 3)
            {
                NesCore.CPU.AssertInterrupt(CPU.CPU6502.InterruptType.NMI, vbl_flag_temp & nmi_enabled);
                // normally, ppu question for nmi at first 3 clocks of vblank
            }
        }
    }
}
