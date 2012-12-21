using System;
using MyNes.Core.IO.Input;

namespace CPRenderers
{
    class SDLVSUnisystemDIP : IVSunisystemDIP
    {
        public bool CreditServiceButton = false;
        public bool DIPSwitch1 = false;
        public bool DIPSwitch2 = false;
        public bool DIPSwitch3 = false;
        public bool DIPSwitch4 = false;
        public bool DIPSwitch5 = false;
        public bool DIPSwitch6 = false;
        public bool DIPSwitch7 = false;
        public bool DIPSwitch8 = false;
        public bool CreditLeftCoinSlot = false;
        public bool CreditRightCoinSlot = false;

        public byte GetData4016()
        {
            byte data = 0;
            if (CreditServiceButton)
                data |= 0x04;
            if (DIPSwitch1)
                data |= 0x08;
            if (DIPSwitch2)
                data |= 0x10;
            if (CreditLeftCoinSlot)
                data |= 0x20;
            if (CreditRightCoinSlot)
                data |= 0x40;
            return data;
        }
        public byte GetData4017()
        {
            byte data = 0;
            if (DIPSwitch3)
                data |= 0x04;
            if (DIPSwitch4)
                data |= 0x08;
            if (DIPSwitch5)
                data |= 0x10;
            if (DIPSwitch6)
                data |= 0x20;
            if (DIPSwitch7)
                data |= 0x40;
            if (DIPSwitch8)
                data |= 0x80;
            return data;
        }
    }
}
