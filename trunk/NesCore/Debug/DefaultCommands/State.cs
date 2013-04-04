using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNes.Core.Debug.DefaultCommands
{
    public class State : ConsoleCommand
    {
        public override string Method
        {
            get { return "state"; }
        }

        public override string Description
        {
            get { return "Call state commands"; }
        }
        public override ConsoleCommandParameter[] Parameters
        {
            get
            {
                return new ConsoleCommandParameter[]{
                    new ConsoleCommandParameter("save","Save the state at memory !"),
                    new ConsoleCommandParameter("load","Load the state from memory !"),
                    new ConsoleCommandParameter("savefile","Save the state to file."),
                    new ConsoleCommandParameter("loadfile","Load the state from file."),
                };
            }
        }
        public override void Execute(string parameters)
        {
            if (!Nes.ON)
            {
                Console.WriteLine("Emulation is OFF, you can't access the state.", DebugCode.Error);
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
                if (codes[i].ToLower() == "save")
                {
                    Nes.SaveMemoryState();
                    while (Nes.saveMemoryStateRequest) { }
                    Console.WriteLine("State saved at memory. Size = " + Nes.memoryState.Length + " byte", DebugCode.Good);
                }
                else if (codes[i].ToLower() == "load")
                {
                    Nes.LoadMemoryState();
                    Console.WriteLine("State loaded from memory. Size = " + Nes.memoryState.Length + " byte", DebugCode.Good);
                }
            }
        }
    }
}
