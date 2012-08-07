namespace myNES.Core.CPU.Types
{
    public struct Flags
    {
        public bool n;
        public bool v;
        public bool d;
        public bool i;
        public bool z;
        public bool c;

        public static implicit operator Flags(byte value)
        {
            return new Flags
            {
                n = (value & 0x80) != 0,
                v = (value & 0x40) != 0,
                d = (value & 0x08) != 0,
                i = (value & 0x04) != 0,
                z = (value & 0x02) != 0,
                c = (value & 0x01) != 0
            };
        }
        public static implicit operator byte(Flags value)
        {
            return (byte)(
                (value.n ? 0x80 : 0) |
                (value.v ? 0x40 : 0) |
                (value.d ? 0x08 : 0) |
                (value.i ? 0x04 : 0) |
                (value.z ? 0x02 : 0) |
                (value.c ? 0x01 : 0) | 0x20);
        }
    }
}