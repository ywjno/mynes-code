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
using System;
namespace MyNes.Core.Boards
{
    /// <summary>
    /// Attributes for boards, use it to configure the board !
    /// </summary>
    public class BoardInfo : Attribute
    {
        /// <summary>
        /// The board info attribute, determines a board basic information and behaviour
        /// </summary>
        /// <param name="name">The board name</param>
        /// <param name="inesMapperNumber">The INES mapper number that this board is assigned to</param>
        /// <param name="busConflict">Indicate if this board has bus conflict at $8000-$FFFF</param>
        public BoardInfo(string name, int inesMapperNumber, bool busConflict)
        {
            this.name = name;
            this.inesMapperNumber = inesMapperNumber;
            this.busConflict = busConflict;
            this.ppuA12TogglesOnRaisingEdge = this.enabled_ppuA12ToggleTimer = false;
        }
        /// <summary>
        /// The board info attribute, determines a board basic information and behaviour
        /// </summary>
        /// <param name="name">The board name</param>
        /// <param name="inesMapperNumber">The INES mapper number that this board is assigned to</param>
        /// <param name="busConflict">Indicate if this board has bus conflict at $8000-$FFFF</param>
        /// <param name="enabled_ppuA12ToggleTimer">Toggle the scanline timer (clocked on PPU A12 raising edge, used in MMC3)</param>
        /// <param name="ppuA12TogglesOnRaisingEdge">Indicated if the scanline timer clock on raising edge(true) of A12 or not(false)</param>
        public BoardInfo(string name, int inesMapperNumber, bool busConflict, bool enabled_ppuA12ToggleTimer, bool ppuA12TogglesOnRaisingEdge)
        {
            this.name = name;
            this.inesMapperNumber = inesMapperNumber;
            this.enabled_ppuA12ToggleTimer = enabled_ppuA12ToggleTimer;
            this.ppuA12TogglesOnRaisingEdge = ppuA12TogglesOnRaisingEdge;
        }
        private string name;
        private int inesMapperNumber;
        private bool busConflict;
        private bool enabled_ppuA12ToggleTimer;
        private bool ppuA12TogglesOnRaisingEdge;

        public string Name
        { get { return name; } }
        public int InesMapperNumber
        { get { return inesMapperNumber; } }
        public bool BusConflict
        { get { return busConflict; } }
        public bool Enabled_ppuA12ToggleTimer
        { get { return enabled_ppuA12ToggleTimer; } }
        public bool PPUA12TogglesOnRaisingEdge
        { get { return ppuA12TogglesOnRaisingEdge; } }
    }
}
