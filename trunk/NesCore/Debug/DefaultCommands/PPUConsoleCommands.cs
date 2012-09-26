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
namespace MyNes.Core.Debug.DefaultCommands
{
    class PPUConsoleCommands : ConsoleCommand
    {
        public override string Method
        {
            get { return "ppu"; }
        }

        public override string Description
        {
            get { return "Call ppu, use parameters for more options"; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[]{
                       new ConsoleCommandParameter("vbl_h", "Set vblank hclock, the next parameter must be the value '3 - 328'"),
                       new ConsoleCommandParameter("vbl_s", "Set vblank start scanline, the next parameter must be the value 'x >= 241'"),
                       new ConsoleCommandParameter("vbl_e", "Set vblank end scanline, the next parameter must be the value 'x >= 241'"),
                };
            }
        }
        public override void Execute(string parameters)
        {
            if (!Nes.ON)
            {
                Console.WriteLine("Emulation is OFF, you can't access the PPU.", DebugCode.Error);
                return;
            }
            if (parameters.Length == 0)
            {
                Console.WriteLine("No parameter passed.", DebugCode.Error);
                return;
            }
            string[] codes = parameters.Split(new char[] { ' ' });
            for (int i = 0; i < codes.Length; i++)
            {
                if (codes[i].ToLower() == "vbl_h")
                {
                    i++;
                    Nes.Ppu.vbl_hclock = int.Parse(codes[i]);
                    Console.WriteLine("Vblank hclock = " + codes[i], DebugCode.Good);
                }
                else if (codes[i].ToLower() == "vbl_s")
                {
                    i++;
                    Nes.Ppu.vbl_vclock_Start = int.Parse(codes[i]);
                    Console.WriteLine("Vblank start scanline = " + codes[i], DebugCode.Good);
                }
                else if (codes[i].ToLower() == "vbl_e")
                {
                    i++;
                    Nes.Ppu.vbl_vclock_End = int.Parse(codes[i]);
                    Console.WriteLine("Vblank end scanline = " + codes[i], DebugCode.Good);
                }
            }
        }
    }
}
