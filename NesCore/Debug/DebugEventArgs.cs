namespace MyNes.Core
{
    /// <summary>
    /// Console Debug Args
    /// </summary>
    public class DebugEventArgs : System.EventArgs
    {
        public DebugCode Code { get; private set; }
        public string Text { get; private set; }

        /// <summary>
        /// Console Debug Args
        /// </summary>
        /// <param name="text">The debug line</param>
        /// <param name="code">The status</param>
        public DebugEventArgs(string text, DebugCode code)
        {
            this.Text = text;
            this.Code = code;
        }
    }
}