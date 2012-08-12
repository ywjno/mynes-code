namespace myNES.Core
{
    public class Memory : Component
    {
        private PeekRegister[] peek;
        private PokeRegister[] poke;
        private int size;
        private int mask;

        public int Length { get { return size; } }

        public Memory(int size)
        {
            this.peek = new PeekRegister[size];
            this.poke = new PokeRegister[size];
            this.size = size;
            this.mask = size - 1;
            this.Hook(0, size - 1,
                delegate { return 0; },
                delegate { });
        }

        public void Hook(int address, PeekRegister peek) { this.peek[address] = peek; }
        public void Hook(int address, PokeRegister poke) { this.poke[address] = poke; }
        public void Hook(int address, PeekRegister peek, PokeRegister poke)
        {
            Hook(address, peek);
            Hook(address, poke);
        }
        public void Hook(int address, int last, PeekRegister peek)
        {
            for (; address <= last; address++)
                Hook(address, peek);
        }
        public void Hook(int address, int last, PokeRegister poke)
        {
            for (; address <= last; address++)
                Hook(address, poke);
        }
        public void Hook(int address, int last, PeekRegister peek, PokeRegister poke)
        {
            for (; address <= last; address++)
                Hook(address, peek, poke);
        }

        public virtual byte Peek(int address)
        {
            return peek[address &= mask](address);
        }
        public virtual void Poke(int address, byte data)
        {
            poke[address &= mask](address, data);
        }

        public virtual byte DebugPeek(int address) { return 0; }
        public virtual void DebugPoke(int address, byte data) { }
    }
}