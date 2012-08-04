﻿using System.Runtime.InteropServices;

namespace MyNes.Core
{
    [StructLayout(LayoutKind.Explicit)]
    public class RegisterPair
    {
        [FieldOffset(0)]
        public byte LoByte;
        [FieldOffset(1)]
        public byte HiByte;

        [FieldOffset(0)]
        public int Value;
    }
}