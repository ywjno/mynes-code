namespace MyNes.Core
{
    /// <summary>
    /// My Nes Console
    /// </summary>
    public class CONSOLE
    {
        /// <summary>
        /// Write line delegate
        /// </summary>
        public delegate void WriteDebugLineDelegate();
        /// <summary>
        /// Write line to the console and rise the "DebugRised" event
        /// </summary>
        /// <param name="Line">The debug line</param>
        public static void WriteLine(string Line)
        {
            WriteLine(null, Line, DebugStatus.None);
        }
        /// <summary>
        /// Write line to the console and rise the "DebugRised" event
        /// </summary>
        /// <param name="Line">The debug line</param>
        /// <param name="status">The status</param>
        public static void WriteLine(string Line, DebugStatus status)
        {
            WriteLine(null, Line, status);
        }
        /// <summary>
        /// Write line to the console and rise the "DebugRised" event
        /// </summary>
        /// <param name="Sender">The object that sent this line</param>
        /// <param name="Line">The debug line</param>
       /// <param name="status">The status</param>
        public static void WriteLine(object Sender, string Line,DebugStatus status)
        {
            System.EventHandler<DebugArg> handler = DebugRised;
            if (handler != null)
                handler(Sender, new DebugArg(Line, status));
        }
        /// <summary>
        /// Rised when the system write a debug
        /// </summary>
        public static event System.EventHandler<DebugArg> DebugRised;
    }
}
