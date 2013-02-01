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
using MyNes.Renderers;
using System;
using System.Threading;
using Console = System.Console;

namespace CPRenderers
{
    public class SDLRenderer : IRenderer
    {
        [STAThread]
        public override void Start()
        {
            Console.WriteLine("Launching SDL .NET window ...");
            SDLWindow window = new SDLWindow();
            Thread thread = new Thread(new ThreadStart(window.Run));
            thread.Start();
        }

        public override string Name
        {
            get { return "SDL .NET"; }
        }

        public override string Description
        {
            get {
                return "Render using SDL .NET library.\n\n"
                +
                "Uses sdl dotnet library for renderering. For more info please visit: http://cs-sdl.sourceforge.net/" + "\n\n"
                + "This renderer requires the sdl .net runtime to run.\nhttp://cs-sdl.sourceforge.net/downloads";
            }
        }
    }
}
