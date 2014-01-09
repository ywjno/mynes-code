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

namespace MyNes.Core.Boards
{
    // Clocks
    public abstract partial class Board : INesComponent
    {
        protected bool enabled_ppuA12ToggleTimer;
        protected bool ppuA12TogglesOnRaisingEdge;
        private int old_vram_address;
        private int new_vram_address;
        private int ppu_cycles_timer;
        /// <summary>
        /// Call this on VRAM address update
        /// </summary>
        /// <param name="newAddress"></param>
        public virtual void OnPPUAddressUpdate(int address)
        {
            if (enabled_ppuA12ToggleTimer)
            {
                old_vram_address = new_vram_address;
                new_vram_address = address & 0x1000;
                if (ppuA12TogglesOnRaisingEdge)
                {
                    if (old_vram_address < new_vram_address)
                    {
                        if (ppu_cycles_timer > 8)
                        {
                            OnPPUA12RaisingEdge();
                        }
                        ppu_cycles_timer = 0;
                    }
                }
                else
                {
                    if (old_vram_address > new_vram_address)
                    {
                        if (ppu_cycles_timer > 8)
                        {
                            OnPPUA12RaisingEdge();
                        }
                        ppu_cycles_timer = 0;
                    }
                }
            }
        }
        /// <summary>
        /// Clocked on CPU cycle clock
        /// </summary>
        public virtual void OnCPUClock()
        {
        }
        /// <summary>
        /// Clocked on ppu clock
        /// </summary>
        public virtual void OnPPUClock()
        {
            if (enabled_ppuA12ToggleTimer)
                ppu_cycles_timer++;
        }
        /// <summary>
        /// Clocked when the PPU A12 rasing edge occur (scanline timer, used in MMC3)
        /// </summary>
        public virtual void OnPPUA12RaisingEdge()
        {
        }
    }
}
