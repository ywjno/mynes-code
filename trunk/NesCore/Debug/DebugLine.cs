namespace MyNes.Core
{
    public struct DebugLine
    {
        public DebugLine(string debugLine, DebugStatus status)
        {
            this.debugLine = debugLine;
            this.status = status;
        }
        string debugLine;
        DebugStatus status;

        public string Line
        { get { return debugLine; } set { debugLine = value; } }
        public DebugStatus DebugStatus
        { get { return status; } set { status = value; } }
    }
}
