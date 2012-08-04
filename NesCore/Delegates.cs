namespace MyNes.Core
{
    public delegate byte PeekAccessor();
    public delegate void PokeAccessor(byte data);
    public delegate void PokeRegister(int address, byte value);
    public delegate byte PeekRegister(int address);
}
