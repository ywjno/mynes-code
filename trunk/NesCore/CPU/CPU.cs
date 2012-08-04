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
            aa = (NesCore.CpuMemory[pc + 0] | (NesCore.CpuMemory[pc + 1] << 8));
            peek = PeekMem;
            poke = PokeMem;

            pc.Value += 2;
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
    }
}