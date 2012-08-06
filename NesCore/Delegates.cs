namespace MyNes.Core
{
    public delegate byte PeekRegister(int address);
    public delegate void PokeRegister(int address, byte value);
}