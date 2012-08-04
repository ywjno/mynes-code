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

        public static implicit operator Register(int value)
        {
            return new Register
            {
                Value = value
            };
        }
        public static implicit operator int(Register value)
        {
            return value.Value;
        }
        public static int operator +(Register a1, int value)
        {
            return a1.Value + value;
        }
        public static int operator +(int value, Register a1)
        {
            return a1.Value + value;
        }
        public static int operator -(Register a1, int value)
        {
            return a1.Value - value;
        }
        public static int operator -(int value, Register a1)
        {
            return value - a1.Value;
        }
    }
}