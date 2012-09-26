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
