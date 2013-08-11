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
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using SdlDotNet;
using SdlDotNet.Graphics;
using Console = System.Console;
using SdlDotNet.Core;

namespace CPRenderers
{
    public class SDLRenderer : IRenderer
    {
        public override void Start()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                    thread.Abort();
            }
            Console.WriteLine("Launching SDL .NET window ...");
            //Listing video modes 
            if (!File.Exists(Path.Combine(RenderersCore.StartupFolder, "modes.txt")))
            {
                Console.WriteLine("Listing video modes ...");
                Size[] modes = Video.ListModes();
                List<string> lines = new List<string>();
                foreach (Size mode in modes)
                {
                    lines.Add(mode.Width + " x " + mode.Height);
                }
                File.WriteAllLines(Path.Combine(RenderersCore.StartupFolder, "modes.txt"), lines.ToArray());
            }
            window = new SDLWindow();
            thread = new Thread(new ThreadStart(window.Run));
            thread.Start();
        }
        private Thread thread;
        private SDLWindow window;
        public override string Name
        {
            get { return "SDL .NET"; }
        }
        public override string Description
        {
            get
            {
                return "Render using SDL .NET library.\n\n"
                +
                "Uses sdl dotnet library for renderering. For more info please visit: http://cs-sdl.sourceforge.net/" + "\n\n"
                + "This renderer requires the sdl .net runtime to run.\nhttp://cs-sdl.sourceforge.net/downloads";
            }
        }
        public override string CopyrightMessage
        {
            get
            {
                return "Written by Ala Ibrahim Hadid.";
            }
        }
        public override void Kill()
        {
            Console.WriteLine("SDL .NET: killing renderer ...");
            window.KillWindow();
        }
        public override bool IsAlive
        {
            get
            {
                if (thread != null)
                    return thread.IsAlive;
                return false;
            }
        }
        public override void ApplySettings(SettingType stype)
        {
            if (window != null)
            {
                window.ApplySettings(stype);
            }
        }
        public override void Dispose()
        {
            Events.Close();
            if (thread != null)
            {
                if (thread.IsAlive)
                    thread.Abort();
            }
        }
    }
}
