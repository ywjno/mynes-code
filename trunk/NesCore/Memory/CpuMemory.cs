﻿namespace MyNes.Core
{
    public class CpuMemory : Memory
    {
        private byte[] ram = new byte[2048];
        private byte[] prg;

        public CpuMemory()
            : base(0xFFFF)
        {
            Hook(0x0000, 0x2000, PeekRam, PokeRam);
        }

        private byte PeekRam(int address)
        {
            return ram[address & 0x7FF];
        }
        private void PokeRam(int address, byte data)
        {
            ram[address & 0x7FF] = data;
        }
    }
}