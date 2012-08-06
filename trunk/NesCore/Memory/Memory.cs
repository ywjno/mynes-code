namespace MyNes.Core
{
    public class Memory
    {
        private PeekRegister[] peek;
        private PokeRegister[] poke;
        private int size;

        public int Length { get { return size; } }

        public byte this[int address]
        {
            get { return peek[address](address); }
            set { poke[address](address, value); }
        }

        public Memory(int size)
        {
            this.peek = new PeekRegister[size];
            this.poke = new PokeRegister[size];
            this.size = size;

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

        public virtual byte DebugPeek(int address)
        {
            return this[address];
        }
        public virtual void DebugPoke(int address, byte data)
        {
            this[address] = data;
        }

        public virtual void Initialize() { }
        public virtual void Shutdown() { }
    }
}