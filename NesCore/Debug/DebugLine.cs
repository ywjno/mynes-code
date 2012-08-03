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

        public string Line
        { get { return debugLine; } set { debugLine = value; } }
        public DebugCode DebugStatus
        { get { return status; } set { status = value; } }
    }
}
