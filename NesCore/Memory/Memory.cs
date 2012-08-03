namespace MyNes.Core
{
   public abstract class Memory
    {
       public Memory(int capacity)
       {
           peek = new PeekRegister[capacity + 1];
           poke = new PokeRegister[capacity + 1];
           this.mask = capacity;
           this.Map(0, capacity, PeekStub, PokeStub);
       }
       private PeekRegister[] peek;
       private PokeRegister[] poke;
       int mask;

       public byte this[int addr]
       {
           get
           {
               return peek[addr &= mask](addr);
           }
           set
           {
               poke[addr &= mask](addr, value);
           }
       }
       
       private byte PeekStub(int addr)
       {
           return 0;
       }
       private void PokeStub(int addr, byte data)
       {
       }

       public void Map(int addr, PeekRegister peek)
       {
           this.peek[addr] = peek;
       }
       public void Map(int addr, PokeRegister poke)
       {
           this.poke[addr] = poke;
       }
       public void Map(int addr, PeekRegister peek, PokeRegister poke)
       {
           this.peek[addr] = peek;
           this.poke[addr] = poke;
       }
       public void Map(int addr, int last, PeekRegister peek)
       {
           do
           {
               this.peek[addr] = peek;
           }
           while (addr++ != last);
       }
       public void Map(int addr, int last, PokeRegister poke)
       {
           do
           {
               this.poke[addr] = poke;
           }
           while (addr++ != last);
       }
       public void Map(int addr, int last, PeekRegister peek, PokeRegister poke)
       {
           do
           {
               this.peek[addr] = peek;
               this.poke[addr] = poke;
           }
           while (addr++ != last);
       }
    }
}
