using myNES.Core.IO.Input;
namespace myNES.Core.Controls
{
    /// <summary>
    /// Emulates the nes controls unit manager
    /// </summary>
    public class ControlsUnit
    {
        private uint inputData1;
        private uint inputData2;
        private byte inputData3;
        private byte inputData4;
        private byte inputStrobe;
        public IInputDevice InputDevice;
        public IJoypad Joypad1;
        public IJoypad Joypad2;
        public IJoypad Joypad3;
        public IJoypad Joypad4;

        public bool IsFourPlayers = true;

        private byte PeekPad4016(int addr)
        {
            byte data = (byte)(inputData1 & 1);
            inputData1 >>= 1;
            data |= (byte)((inputData3 & 1) << 1);
            inputData3 >>= 1;
            return data;
        }
        private byte PeekPad4017(int addr)
        {
            byte data = (byte)(inputData2 & 1);
            inputData2 >>= 1;
            data |= (byte)((inputData4 & 1) << 1);
            inputData4 >>= 1;
            return data;
        }
        private void PokePad4016(int addr, byte data)
        {
            if (inputStrobe > (data & 0x01))
            {
                InputDevice.Update();
                if (IsFourPlayers)
                {
                    inputData1 = (uint)(Joypad1.GetData() | (Joypad3.GetData() << 8) | 0x00080000);
                    inputData2 = (uint)(Joypad2.GetData() | (Joypad4.GetData() << 8) | 0x00040000);
                }
                else
                {
                    inputData1 = (uint)Joypad1.GetData();
                    inputData2 = (uint)Joypad2.GetData();
                }
            }

            inputStrobe = (byte)(data & 0x01);
        }

        public void Initianlize()
        {
            Nes.CpuMemory.Hook(0x4016, PeekPad4016, PokePad4016);
            Nes.CpuMemory.Hook(0x4017, PeekPad4017);
        }
        public void Shutdown()
        { 
        
        }
    }
}
