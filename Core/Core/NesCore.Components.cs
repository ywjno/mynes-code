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
using System.IO;
using System.Threading;
using MyNes.Core.Database;
using MyNes.Core.CPU;
using MyNes.Core.PPU;
using MyNes.Core.APU;
using MyNes.Core.Boards;
using MyNes.Core.ROM;

using MyNes.Core.Controls;
using MyNes.Core.IO;
using MyNes.Core.State;
namespace MyNes.Core
{
    public partial class NesCore
    {
        /// <summary>
        /// The 6502 cpu component.
        /// </summary>
        public static CPU6502 CPU;
        /// <summary>
        /// The ppu component
        /// </summary>
        public static PPU2C02 PPU;
        /// <summary>
        /// The apu component
        /// </summary>
        public static APU2A03 APU;
        /// <summary>
        /// The cartridge (board)
        /// </summary>
        public static Board BOARD;
        /// <summary>
        /// The current rom info.
        /// </summary>
        public static RomInfo RomInfo;
        /// <summary>
        /// The controls unit. Handles nes input + input devices
        /// </summary>
        public static ControlsUnit ControlsUnit;

        // IO
        /// <summary>
        /// The emulation thread
        /// </summary>
        public static Thread MainThread;
        /// <summary>
        /// The speed control. Not a nes component.
        /// </summary>
        public static SpeedLimiter SpeedLimiter;
        /// <summary>
        /// The video output device
        /// </summary>
        public static IVideoDevice VideoOutput;
        /// <summary>
        /// The audio output device
        /// </summary>
        public static IAudioDevice AudioOutput;

        // Flags
        /// <summary>
        /// Determine the tv system. This take effect after hard reset.
        /// </summary>
        public static TVSystem TV;

        private static void InitializeComponents()
        {
            Console.WriteLine("Initializing components ...");
            SpeedLimiter = new SpeedLimiter();

            ControlsUnit = new Controls.ControlsUnit();
            ControlsUnit.Initialize();

            CPU = new CPU6502();
            PPU = new PPU2C02();
            APU = new APU2A03();

            PPU.Initialize();
            APU.Initialize();
            BOARD.Initialize();
            CPU.Initialize();
            Console.WriteLine("Initializing components ... OK");
        }
    }
}
