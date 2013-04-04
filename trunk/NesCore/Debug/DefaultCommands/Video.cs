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
using MyNes.Core.Database;
namespace MyNes.Core.Debug.DefaultCommands
{
    class Video : ConsoleCommand
    {
        public override string Method
        {
            get { return "video"; }
        }

        public override string Description
        {
            get { return "Call video device, use parameters for options."; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[]{
                   new ConsoleCommandParameter("show_fps","Show fps on renderer screen"),
                   new ConsoleCommandParameter("hide_fps","Hide fps from renderer screen"),
                   new ConsoleCommandParameter("show_notifications","Show notifications on renderer screen"),
                   new ConsoleCommandParameter("hide_notifications","Hide notifications from renderer screen"),
                };
            }
        }
        public override void Execute(string parameters)
        {
            if (!Nes.ON)
            {
                Console.WriteLine("Emulation is OFF, you can't access the video device.", DebugCode.Error);
                return;
            }
            if (parameters.Length == 0)
            {
                Console.WriteLine("No parameter passed.", DebugCode.Error);
                return;
            }
            if (Nes.VideoDevice == null)
            {
                Console.WriteLine("The video device is not ready ! not initialized maybe.", DebugCode.Error);
                return;
            }
            Nes.TogglePause(true);
            string[] codes = parameters.Split(new char[] { ' ' });
            for (int i = 0; i < codes.Length; i++)
            {
                if (codes[i].ToLower() == "show_fps")
                {
                    Nes.VideoDevice.ShowFPS = true;
                    Console.WriteLine("FPS on", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "hide_fps")
                {
                    Nes.VideoDevice.ShowFPS = false;
                    Console.WriteLine("FPS off", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "show_notifications")
                {
                    Nes.VideoDevice.ShowNotifications = true;
                    Console.WriteLine("Notifications on", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "hide_notifications")
                {
                    Nes.VideoDevice.ShowNotifications = false;
                    Console.WriteLine("Notifications off", DebugCode.Good);
                }
            }
            Nes.TogglePause(false);
        }
    }
}
