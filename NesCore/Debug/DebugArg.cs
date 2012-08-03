namespace MyNes.Core
{
    /// <summary>
    /// Console Debug Args
    /// </summary>
    public class DebugEventArgs : System.EventArgs
    {
        private DebugCode code;
        private string text;

        public DebugCode Code { get { return code; } }
        public string Text { get { return text; } }

        /// <summary>
        /// Console Debug Args
        /// </summary>
        /// <param name="text">The debug line</param>
        /// <param name="code">The status</param>
        public DebugEventArgs(string text, DebugCode code)
        {
            this.text = text;
            this.code = code;
        }
    }
}
