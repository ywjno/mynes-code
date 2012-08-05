namespace MyNes.Core
{
    public abstract class Memory
    {
        private PeekRegister[] peek;
        private PokeRegister[] poke;
        private int mask;

        public byte this[int addr]
        {
            get { NesCore.CPU.Clock(); return peek[addr & mask](addr); }
            set { NesCore.CPU.Clock(); poke[addr & mask](addr, value); }
        }
        public Memory(int capacity)
        {
            this.peek = new PeekRegister[capacity + 1];
            this.poke = new PokeRegister[capacity + 1];
            this.mask = capacity;

            this.Hook(0, capacity, PeekStub, PokeStub);
        }

        private byte PeekStub(int addr) { return 0; }
        private void PokeStub(int addr, byte data) { }

        public void Hook(int addr, PeekRegister peek)
        {
            this.peek[addr] = peek;
        }
        public void Hook(int addr, PokeRegister poke)
        {
            this.poke[addr] = poke;
        }
        public void Hook(int addr, PeekRegister peek, PokeRegister poke)
        {
            this.peek[addr] = peek;
            this.poke[addr] = poke;
        }
        public void Hook(int addr, int last, PeekRegister peek)
        {
            for (int i = addr; i <= last; i++)
                this.peek[i] = peek;
        }
        public void Hook(int addr, int last, PokeRegister poke)
        {
            for (int i = addr; i <= last; i++)
                this.poke[i] = poke;
        }
        public void Hook(int addr, int last, PeekRegister peek, PokeRegister poke)
        {
            for (int i = addr; i <= last; i++)
            {
                this.peek[i] = peek;
                this.poke[i] = poke;
            }
        }

        public virtual byte DebugPeek(int address)
        { return this[address]; }
        public virtual void DebugPoke(int address, byte value)
        { this[address] = value; ; }

        public int Length
        { get { return mask; } }
    }
}