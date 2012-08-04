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

        private PeekAccessor peek;
        private PokeAccessor poke;
        /*Add a cycle to the counter*/
        void Clock(int cycles)
        {

        }

        byte PeekMem()
        {
            byte data = NesCore.CpuMemory[aa.Value];
            return data;
        }
        void PokeMem(byte data)
        {
            NesCore.CpuMemory[aa.Value] = data;
        }

        void AmAbs()
        {
            peek = PeekMem;
            poke = PokeMem;

            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];
        }
        void AmAbX()
        {
            peek = PeekMem;
            poke = PokeMem;

            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += x;

            if (aa.LoByte < x)
            {
                byte dummy = NesCore.CpuMemory[aa.Value];
                aa.HiByte++;
            }
        }
        void AmAbX_C()//add cycle when crossed page
        {
            peek = PeekMem;
            poke = PokeMem;

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
        void AmAbX_D()//always does dummy read
        {
            /*Special case for ROL 0x3E, always does dummy reads !!*/
            peek = PeekMem;
            poke = PokeMem;

            aa.LoByte = NesCore.CpuMemory[pc.Value++];
            aa.HiByte = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += x;

            byte dummy = NesCore.CpuMemory[aa.Value];
            aa.HiByte++;
            Clock(1);
        }
        void AmAbY()
        {
            peek = PeekMem;
            poke = PokeMem;

            aa.LoByte = NesCore.CpuMemory[pc++];
            aa.HiByte = NesCore.CpuMemory[pc++];

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa];
                aa.HiByte++;
            }
        }
        void AmAbY_C()//add cycle when crossed page
        {
            peek = PeekMem;
            poke = PokeMem;

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
        void AmAcc()
        {
            peek = () => a;
            poke = (data) => a = data;
        }
        void AmImm()
        {
            aa = pc++;
            peek = PeekMem;
            poke = PokeMem;
        }
        void AmImp()
        {
        }
        void AmInd()
        {
            aa.LoByte = NesCore.CpuMemory[pc++];
            aa.HiByte = NesCore.CpuMemory[pc++];

            aa.LoByte = NesCore.CpuMemory[aa];
            aa.HiByte = NesCore.CpuMemory[NesCore.CpuMemory[((aa + 1) & 0xFF) | aa.HiByte]];
        }
        void AmInX()
        {
            byte arg = NesCore.CpuMemory[pc++];
            aa.LoByte = NesCore.CpuMemory[(arg + x + 0) & 0xFF];
            aa.HiByte = NesCore.CpuMemory[(arg + x + 1) & 0xFF];

            peek = PeekMem;
            poke = PokeMem;
        }
        void AmInY()
        {
            peek = PeekMem;
            poke = PokeMem;

            byte arg = NesCore.CpuMemory[pc++];
            aa.LoByte = NesCore.CpuMemory[(arg  + 0) & 0xFF];
            aa.HiByte = NesCore.CpuMemory[(arg  + 1) & 0xFF];

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa];
                aa.HiByte++;
            }
        }
        void AmInY_C()
        {
            peek = PeekMem;
            poke = PokeMem;

            byte arg = NesCore.CpuMemory[pc++];
            aa.LoByte = NesCore.CpuMemory[(arg + 0) & 0xFF];
            aa.HiByte = NesCore.CpuMemory[(arg + 1) & 0xFF];

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa];
                aa.HiByte++;
                Clock(1);
            }
        }
        void AmZpg()
        {
            aa = (NesCore.CpuMemory[pc++]);
            peek = PeekMem;
            poke = PokeMem;
        }
        void AmZpX()
        {
            aa = (NesCore.CpuMemory[pc++] + x) & 0xFF;
            peek = PeekMem;
            poke = PokeMem;
        }
        void AmZpY()
        {
            aa = (NesCore.CpuMemory[pc++] + y) & 0xFF;
            peek = PeekMem;
            poke = PokeMem;
        }
    }
}