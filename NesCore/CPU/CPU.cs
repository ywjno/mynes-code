namespace MyNes.Core
{
    public class CPU
    {
        private byte a;//Accumulator
        private byte x;//Index Register X
        private byte y;//Index Register Y
        private Register pc;//Program Counter
        private Register sp;//Stack Pointer
        private Flags sr;//Processor Status

        private Register aa;

        /*Add a cycle to the counter*/
        private void Clock(int cycles) { }

        private void AmAbs()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];
        }
        private void AmAbX()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += x;

            if (aa.LoByte < x)
            {
                byte dummy = NesCore.CpuMemory[aa.Value];
                aa.HiByte++;
            }
        }
        private void AmAbX_C()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += x;

            if (aa.LoByte < x)
            {
                byte dummy = NesCore.CpuMemory[aa.Value];
                aa.HiByte++;
                Clock(1);
            }
        }
        private void AmAbX_D()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += x;

            byte dummy = NesCore.CpuMemory[aa.Value];
            aa.HiByte++;
            Clock(1);
        }
        private void AmAbY()
        {
            aa.LoByte = NesCore.CpuMemory[pc++];
            aa.HiByte = NesCore.CpuMemory[pc++];

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa];
                aa.HiByte++;
            }
        }
        private void AmAbY_C()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa.Value];
                aa.HiByte++;
                Clock(1);
            }
        }
        private void AmImm()
        {
            aa.Value = pc.Value++;
        }
        private void AmImp() { }
        private void AmInd()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];

            byte addr = NesCore.CpuMemory[aa.Value++];

            aa.LoByte++; // only increment the low byte, causing the "JMP ($nnnn)" bug

            aa.HiByte = NesCore.CpuMemory[aa.Value++];
            aa.LoByte = value;
        }
        private void AmInX()
        {
            byte addr = NesCore.CpuMemory[pc.Value++];

            addr += x;

            aa.LoByte = NesCore.CpuMemory[addr++];
            aa.HiByte = NesCore.CpuMemory[addr++];
        }
        private void AmInY()
        {
            byte addr = NesCore.CpuMemory[pc.Value++];
            aa.LoByte = NesCore.CpuMemory[addr++];
            aa.HiByte = NesCore.CpuMemory[addr++];

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa];
                aa.HiByte++;
            }
        }
        private void AmInY_C()
        {
            byte addr = NesCore.CpuMemory[pc.Value++];
            aa.LoByte = NesCore.CpuMemory[addr++];
            aa.HiByte = NesCore.CpuMemory[addr++];

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa];
                aa.HiByte++;
                Clock(1);
            }
        }
        private void AmZpg()
        {
            aa.Value = NesCore.CpuMemory[pc.Value++];
        }
        private void AmZpX()
        {
            aa.Value = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += x;
        }
        private void AmZpY()
        {
            aa.Value = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += y;
        }
    }
}