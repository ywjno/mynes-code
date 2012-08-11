using System;

namespace myNES.Core.APU
{
    public class ChannelTri : Apu.Channel
    {
        private static readonly byte[] pyramid =
        {
            0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF,
            0xF, 0xE, 0xD, 0xC, 0xB, 0xA, 0x9, 0x8, 0x7, 0x6, 0x5, 0x4, 0x3, 0x2, 0x1, 0x0
        };

        private Apu.Duration duration = new Apu.Duration();
        private int step;

        public ChannelTri(TimingInfo.System system)
            : base(system) { }

        protected override void PokeReg1(int address, byte data)
        {
            // $4008 - CRRR RRRR - linear counter control (C), linear counter load (R)

            duration.Halt = (data & 0x80) != 0;
        }
        protected override void PokeReg2(int address, byte data) { }
        protected override void PokeReg3(int address, byte data)
        {
            frequency = (frequency & ~0x0FF) | (data << 0 & 0x0FF);
            timing.single = GetCycles(frequency + 1);
        }
        protected override void PokeReg4(int address, byte data)
        {
            frequency = (frequency & ~0x700) | (data << 8 & 0x700);
            timing.single = GetCycles(frequency + 1);

            duration.SetCounter(data);
        }

        public override byte Render(int cycles)
        {
            if (duration.Counter != 0 && frequency >= 3)
            {
                int sum = timing.cycles;
                timing.cycles -= cycles;

                if (timing.cycles >= 0)
                {
                    return pyramid[step];
                }
                else
                {
                    sum *= pyramid[step];

                    do
                    {
                        sum += Math.Min(-timing.cycles, timing.single) * pyramid[step = ++step & 0x1F];
                        timing.cycles += timing.single;
                    }
                    while (timing.cycles < 0);

                    return (byte)(sum / cycles);
                }
            }

            return pyramid[step];
        }
    }
}