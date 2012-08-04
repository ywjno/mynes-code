using System.Runtime.InteropServices;

namespace MyNes.Core
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Register
    {
        [FieldOffset(0)]
        public byte LoByte;
        [FieldOffset(1)]
        public byte HiByte;

        [FieldOffset(0)]
        public int Value;
    }
}