namespace MyNes.Core
{
    public struct DebugLine
    {
        public DebugLine(string debugLine, DebugCode status)
        {
            this.debugLine = debugLine;
            this.status = status;
        }
        string debugLine;
        DebugCode status;

        public string Text
        { get { return debugLine; } set { debugLine = value; } }
        public DebugCode Code
        { get { return status; } set { status = value; } }
    }
}
