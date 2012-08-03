namespace MyNes.Core
{
    /// <summary>
    /// Console Debug Args
    /// </summary>
    public class DebugArg : System.EventArgs
    {
        /// <summary>
        /// Console Debug Args
        /// </summary>
        /// <param name="Line">The debug line</param>
        /// <param name="status">The status</param>
        public DebugArg(string Line, DebugStatus status)
        {
            _DebugLine = Line;
            this.status = status;
        }
        string _DebugLine;
        DebugStatus status;
        /// <summary>
        /// The debug line
        /// </summary>
        public string DebugLine
        { get { return _DebugLine; } }

        public DebugStatus DebugStatus
        { get { return status; } }
    }
}
