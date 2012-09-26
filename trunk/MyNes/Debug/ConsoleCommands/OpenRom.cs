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
using System.Windows.Forms;
using MyNes.Core;

namespace MyNes.Debug.ConsoleCommands
{
    public class OpenRom : ConsoleCommand
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
                return new ConsoleCommandParameter[] { new ConsoleCommandParameter("output_on", "Enable the output (handle writes at 0x6000 > 0x7FFF and decode as ASCII then write to the console)") };
            }
        }
        public override void Execute(string parameters)
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "INES (*.nes)|*.nes";

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Nes.CreateNew(form.FileName, Program.Settings.EmuSystem);
                        //launch the renderer form (slimdx for now)
                        //the renderer (or host) form should setup input and output
                        RendererFormSlimDX frm = new RendererFormSlimDX();
                        frm.Show();
                        //for tests, make result outputs on the console
                        if (parameters.Contains("output_on"))
                        {
                            Nes.CpuMemory.Hook(0x6000, 0x7FFF, poke6004);
                        }
                        //turn on
                        Nes.TurnOn();
                        //run the thread
                        System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ThreadStart(Nes.Run));
                        thr.Start();
                    }
                    catch { }

                }
            }
        }

        void poke6004(int address, byte data)
        {
            //output result
            if (data != 0)// 0= nothing
                Console.WriteLine((new System.Text.ASCIIEncoding()).GetString(new byte[] { data }), DebugCode.Warning);
        }
    }
}