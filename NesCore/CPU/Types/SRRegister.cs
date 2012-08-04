namespace MyNes.Core
{
    class SRRegister : Register
    {
        public bool FlagN;
        public bool FlagV;
        public bool FlagD;
        public bool FlagI;
        public bool FlagZ;
        public bool FlagC;

        public override int Value
        {
            get
            {
                byte data = 0x20;

                if (FlagN) data |= 0x80;
                if (FlagV) data |= 0x40;
                if (FlagD) data |= 0x08;
                if (FlagI) data |= 0x04;
                if (FlagZ) data |= 0x02;
                if (FlagC) data |= 0x01;

                return data;
            }
            set
            {
                FlagN = (value & 0x80) != 0;
                FlagV = (value & 0x40) != 0;
                FlagD = (value & 0x08) != 0;
                FlagI = (value & 0x04) != 0;
                FlagZ = (value & 0x02) != 0;
                FlagC = (value & 0x01) != 0;
            }
        }
    }
}
