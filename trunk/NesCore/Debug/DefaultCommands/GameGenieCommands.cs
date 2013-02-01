/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
using System.Collections.Generic;
using MyNes.Core.GameGenie;
namespace MyNes.Core.Debug.DefaultCommands
{
    class GameGenieCommands : ConsoleCommand
    {
        public override string Method
        {
            get { return "gg"; }
        }

        public override string Description
        {
            get { return "Call game genie, use parameters to active and configure"; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[]{
                    new ConsoleCommandParameter("on","Active the Game Genie (you MUST enter at least one code first)"),
                    new ConsoleCommandParameter("off","Deactive the Game Genie"),
                    new ConsoleCommandParameter("code xxxx c","Enter a Game Genie code, xxxx is the code and c is code enable '0 or 1'. e.g: SIXOPO 1"),
                    new ConsoleCommandParameter("codes","Show the entered codes as list"),
                };
            }
        }
        public override void Execute(string parameters)
        {
            if (!Nes.ON)
            {
                Console.WriteLine("Emulation is OFF, you can't access the Game Genie.", DebugCode.Error);
                return;
            }
            if (parameters.Length == 0)
            {
                Console.WriteLine("No parameter passed.", DebugCode.Error);
                return;
            }
            Nes.TogglePause(true);
            string[] codes = parameters.Split(new char[] { ' ' });
            for (int i = 0; i < codes.Length; i++)
            {
                if (codes[i].ToLower() == "on")
                {
                    Nes.Board.IsGameGenieActive = true;
                    Console.WriteLine("Game Genie Activated", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "off")
                {
                    Nes.Board.IsGameGenieActive = false;
                    Console.WriteLine("Game Genie Diactivated", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "codes")
                {
                    if (Nes.Board.GameGenieCodes == null)
                    { Console.WriteLine("No code entered", DebugCode.Error); }
                    else
                    {
                        Console.WriteLine("Game Genie Codes");
                        foreach (GameGenie.GameGenieCode cod in Nes.Board.GameGenieCodes)
                        {
                            Console.WriteLine(cod.Name + ": " + (cod.Enabled ? "ON" : "OFF"));
                        }
                    }
                }
                else if (codes[i].ToLower() == "code")
                {
                    //the next parameter is the code
                    i++;
                    string ggcode = codes[i];
                    //the next parameter is the enable flag
                    i++;
                    bool enabled = codes[i] == "1";
                    //see if the codes list is not null
                    if (Nes.Board.GameGenieCodes == null)
                        Nes.Board.GameGenieCodes = new GameGenieCode[0];
                    List<GameGenieCode> list = new List<GameGenieCode>(Nes.Board.GameGenieCodes);
                    //see if the code already exists
                    bool found = false;
                    for (int j = 0; j < Nes.Board.GameGenieCodes.Length; j++)
                    {
                        if (Nes.Board.GameGenieCodes[j].Name == ggcode)
                        {
                            Nes.Board.GameGenieCodes[j].Enabled = enabled;
                            Console.WriteLine("Code " + ggcode + (enabled ? " enabled." : " disabled"), DebugCode.Good);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        //now add the code
                        GameGenieCode ggd = new GameGenieCode();
                        GameGenie.GameGenie gg = new GameGenie.GameGenie();
                        ggd.Enabled = enabled;
                        ggd.Name = ggcode;

                        if (ggcode.Length == 6)
                        {
                            ggd.Address = gg.GetGGAddress(gg.GetCodeAsHEX(ggcode), 6) | 0x8000;
                            ggd.Value = gg.GetGGValue(gg.GetCodeAsHEX(ggcode), 6);
                            ggd.IsCompare = false;
                        }
                        else
                        {
                            ggd.Address = gg.GetGGAddress(gg.GetCodeAsHEX(ggcode), 8) | 0x8000;
                            ggd.Value = gg.GetGGValue(gg.GetCodeAsHEX(ggcode), 8);
                            ggd.Compare = gg.GetGGCompareValue(gg.GetCodeAsHEX(ggcode));
                            ggd.IsCompare = true;
                        }
                        list.Add(ggd);
                        Console.WriteLine("Code " + ggcode +" added", DebugCode.Good);
                        Nes.Board.GameGenieCodes = list.ToArray();
                    }

                }
            }
            Nes.TogglePause(false);
        }
    }
}
