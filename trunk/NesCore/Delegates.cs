﻿namespace MyNes.Core
{
    public delegate void PokeRegister(int address, byte value);
    public delegate byte PeekRegister(int address);
}
