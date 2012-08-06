using System;

namespace MyNes.Core
{
    /// <summary>
    /// My Nes Console
    /// </summary>
    public class Console
    {
        /// <summary>
        /// Write line to the console and raise the "LineWritten" event
        /// </summary>
        /// 
        /// <param name="text">The debug line</param>
        /// <param name="code">The status</param>
        public static void WriteLine(string text, DebugCode code = DebugCode.None)
        {
            if (LineWritten != null)
                LineWritten(null, new DebugEventArgs(text, code));
        }
        /// <summary>
        /// Update the last written line
        /// </summary>
        /// <param name="text">The debug line</param>
        /// <param name="code">The status</param>
        public static void UpdateLine(string text, DebugCode code = DebugCode.None)
        {
            if (UpdateLastLine != null)
                UpdateLastLine(null, new DebugEventArgs(text, code));
        }

        public static event EventHandler<DebugEventArgs> LineWritten;
        public static event EventHandler<DebugEventArgs> UpdateLastLine;
    }
}