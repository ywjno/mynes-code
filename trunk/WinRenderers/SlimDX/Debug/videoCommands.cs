using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNes.Core;
using Console = MyNes.Core.Console;

namespace MyNes.WinRenderers.Debug
{
    class videoCommands : ConsoleCommand
    {
        public videoCommands(VideoD3D d3d)
        {
            this.d3d = d3d;
        }
        private VideoD3D d3d;
        public override string Method
        {
            get { return "slimdx"; }
        }

        public override string Description
        {
            get { return "Call SlimDX renderer and use parameters for more options."; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[] {
                new ConsoleCommandParameter("filter_none", "Switch to None filter"),
                new ConsoleCommandParameter("filter_linear", "Switch to Linear filter"),
                new ConsoleCommandParameter("filter_point", "Switch to Point filter"),
                };
            }
        }
        public override void Execute(string parameters)
        {
            if (!Nes.ON)
            {
                Console.WriteLine("Emulation is OFF, you can't access the SlimDX.", DebugCode.Error);
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
                if (codes[i].ToLower() == "filter_none")
                {
                    d3d.SwitchFilter(SlimDX.Direct3D9.TextureFilter.None);
                    Console.WriteLine("Image filter = None", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "filter_linear")
                {
                    d3d.SwitchFilter(SlimDX.Direct3D9.TextureFilter.Linear);
                    Console.WriteLine("Image filter = Linear", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "filter_point")
                {
                    d3d.SwitchFilter(SlimDX.Direct3D9.TextureFilter.Point);
                    Console.WriteLine("Image filter = Point", DebugCode.Good);
                }
            }
        }
    }
}
