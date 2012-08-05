using System;

namespace MyNes.Core
{
    /// <summary>
    /// My Nes Console
    /// </summary>
    public class Console
    {
        /// <summary>
        /// Write line to the console and rise the "DebugRised" event
        /// </summary>
        /// <param name="text">The debug line</param>
        public static void WriteLine(string text)
        {
            WriteLine(text, DebugCode.None);
        }

        /// <summary>
        /// Write line to the console and rise the "DebugRised" event
        /// </summary>
        /// 
        /// <param name="text">The debug line</param>
        /// <param name="code">The status</param>
        public static void WriteLine(string text, DebugCode code)
        {
            if (LineWritten != null)
            {
                LineWritten(null, new DebugEventArgs(text, code));
            }
        }
        /// <summary>
        /// Rised when the system write a debug
        /// </summary>
        public static event EventHandler<DebugEventArgs> LineWritten;
    }
}