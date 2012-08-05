namespace MyNes.Core
{
    public struct Flags
    {
        public bool FlagN;
        public bool FlagV;
        public bool FlagD;
        public bool FlagI;
        public bool FlagZ;
        public bool FlagC;

        public static implicit operator Flags(byte value)
        {
            return new Flags
            {
                FlagN = (value & 0x80) != 0,
                FlagV = (value & 0x40) != 0,
                FlagD = (value & 0x08) != 0,
                FlagI = (value & 0x04) != 0,
                FlagZ = (value & 0x02) != 0,
                FlagC = (value & 0x01) != 0
            };
        }
        public static implicit operator byte(Flags value)
        {
            return (byte)(
                (value.FlagN ? 0x80 : 0) |
                (value.FlagV ? 0x40 : 0) |
                (value.FlagD ? 0x08 : 0) |
                (value.FlagI ? 0x04 : 0) |
                (value.FlagZ ? 0x02 : 0) |
                (value.FlagC ? 0x01 : 0) | 0x20);
        }
    }
}