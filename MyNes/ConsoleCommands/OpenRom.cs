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
using System.Windows.Forms;
using System.Threading;
using MyNes.Core;
namespace MyNes.Debug.ConsoleCommands
{
    class OpenRom : ConsoleCommand
    {
        public override string Description
        {
            get { return "Open a rom (for test)"; }
        }
        public override string Method
        {
            get { return "open"; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[] {
                    new ConsoleCommandParameter("step", "Enable the CPU step mode instead of normal thread run.")
                };
            }
        }
        public override void Execute(string parameters)
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "INES (*.Nes)|*.Nes";

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (NesCore.ON) NesCore.ShutDown();

                        NesCore.CreateNew(form.FileName, Program.Settings.TVFormat);
                        string[] codes = parameters.Split(new char[] { ' ' });

                        bool step = false;
                        foreach (string para in codes)
                        {
                            if (para == "step")
                            { step = true; }
                        }
                        NesCore.TurnOn(!step);
                    }
                    catch { }
                }
            }
        }
    }
}
