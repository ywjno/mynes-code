namespace myNES.Core.CPU
{
    // Emulates the undocumented direct memory access controller in the 2A03/2A07
    public class Dma
    {
        private bool step;
        private byte data;
        private int addr;
        private int size;

        public void OamTransfer(int address, byte data)
        {
            if (size != 0)
                return; // transfer already occuring

            step = false;
            addr = (data << 8);
            size = 256;

            Nes.Cpu.Lock();
        }

        public void Update()
        {
            if (size == 0)
                return;

            if (step = !step)
            {
                data = Nes.CpuMemory[addr];
            }
            else
            {
                Nes.CpuMemory[0x2004] = data;

                addr = (++addr) & 0xFFFF;
                size = (--size) & 0xFFFF;

                if (size == 0)
                    Nes.Cpu.Unlock();
            }
        }
    }
}