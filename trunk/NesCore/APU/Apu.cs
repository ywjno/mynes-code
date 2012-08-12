using System;

namespace myNES.Core.APU
{
    public partial class Apu : ProcessorBase
    {
        private const int DELAY = 3125;
        private const int PHASE = 77;

        private int timer;

        public ChannelSq1 Sq1;
        public ChannelSq2 Sq2;
        public ChannelTri Tri;
        public ChannelNoi Noi;
        public ChannelDmc Dmc;

        public Apu(TimingInfo.System system)
            : base(system)
        {
            timing.period = system.Master;
            timing.single = system.Apu;

            Sq1 = new ChannelSq1(system);
            Sq2 = new ChannelSq2(system);
            Tri = new ChannelTri(system);
            Noi = new ChannelNoi(system);
            Dmc = new ChannelDmc(system);
        }

        private byte Peek4015(int address)
        {
            return (byte)(
                (Sq1.Status ? 0x01 : 0) |
                (Sq2.Status ? 0x02 : 0) |
                (Tri.Status ? 0x04 : 0) |
                (Noi.Status ? 0x08 : 0) |
                (Dmc.Status ? 0x10 : 0));
        }
        private void Poke4015(int address, byte data)
        {
            Sq1.Status = (data & 0x01) != 0;
            Sq2.Status = (data & 0x02) != 0;
            Tri.Status = (data & 0x04) != 0;
            Noi.Status = (data & 0x08) != 0;
            Dmc.Status = (data & 0x10) != 0;
        }

        public override void Initialize()
        {
            Sq1.Hook(0x4000);
            Sq2.Hook(0x4004);
            Tri.Hook(0x4008);
            Noi.Hook(0x400C);
            Dmc.Hook(0x4010);

            Nes.CpuMemory.Hook(0x4015, Poke4015);
        }
        public override void Update()
        {
            // todo: frame horse shit, length counter clocks, envelope clocks.. yuck
        }
        public override void Update(int cycles)
        {
            base.Update(cycles);

            timer += PHASE;

            if (timer >= DELAY)
            {
                timer -= DELAY;
                Render();
            }
        }

        public void Render()
        {
            var sq1Sample = Sq1.Render(DELAY / 2);
            var sq2Sample = Sq2.Render(DELAY / 2);

            var triSample = Tri.Render(DELAY);

            Nes.AudioDevice.Sample(
                Mixer.MixSamples(sq1Sample, sq2Sample, triSample, 0, 0));
        }

        public class Channel : ProcessorBase
        {
            protected int frequency;

            public virtual bool Status { get; set; }

            public Channel(TimingInfo.System system)
                : base(system)
            {
                timing.period = system.Master;
                timing.single = GetCycles(frequency + 1);
            }

            protected int GetCycles(int cycles)
            {
                return cycles * PHASE;
            }

            protected virtual void PokeReg1(int address, byte data) { }
            protected virtual void PokeReg2(int address, byte data) { }
            protected virtual void PokeReg3(int address, byte data) { }
            protected virtual void PokeReg4(int address, byte data) { }

            public virtual void Hook(int address)
            {
                Nes.CpuMemory.Hook(address + 0, PokeReg1);
                Nes.CpuMemory.Hook(address + 1, PokeReg2);
                Nes.CpuMemory.Hook(address + 2, PokeReg3);
                Nes.CpuMemory.Hook(address + 3, PokeReg4);
            }

            public virtual void ClockDuration() { }
            public virtual void ClockEnvelope() { }
            public virtual byte Render(int cycles) { return 0; }
        }

        public class Duty
        {
            private byte[][] table;
            private int form;
            private int step;
            private int mask;

            public int Form
            {
                get { return form; }
                set { form = value; }
            }

            public Duty(int steps, params int[] forms)
            {
                if ((steps & (steps - 1)) != 0 || steps == 0)
                    throw new Exception("'steps' must be a non-zero power of two.");

                mask = (steps - 1);

                table = new byte[forms.Length][];

                for (int i = 0; i < forms.Length; i++)
                {
                    int form = forms[i];

                    table[i] = new byte[steps];

                    for (int j = 0; j < steps; j++)
                    {
                        table[i][j] = (byte)(form & 0x01);
                        form >>= 1;
                    }
                }
            }

            public void Clock() { step = ++step & mask; }
            public void Reset() { step = 0; }
            public byte Value() { return table[form][step]; }
        }
        public class Duration
        {
            public static readonly int[] LookupTable = new int[]
            { 
                0x0A, 0xFE, 0x14, 0x02, 0x28, 0x04, 0x50, 0x06, 0xA0, 0x08, 0x3C, 0x0A, 0x0E, 0x0C, 0x1A, 0x0E,
                0x0C, 0x10, 0x18, 0x12, 0x30, 0x14, 0x60, 0x16, 0xC0, 0x18, 0x48, 0x1A, 0x10, 0x1C, 0x20, 0x1E
            };

            public bool Halt;
            public int Enabled;
            public int Counter;

            public void Clock()
            {
                if (Counter != 0 && !Halt)
                    Counter--;
            }
            public void SetEnabled(bool value)
            {
                Enabled = (value) ? 0xFF : 0x00;
                Counter &= Enabled;
            }
            public void SetCounter(byte value)
            {
                Counter = LookupTable[value >> 3] & Enabled;
            }
        }
        public class Envelope
        {
            private bool reset;
            private int[] regs = new int[2];
            private int count;

            public int level;

            private void UpdateLevel()
            {
                level = (regs[regs[1] >> 4 & 1] & 0xF);
            }

            public void Clock()
            {
                if (!reset)
                {
                    if (count != 0)
                    {
                        count--;
                        return;
                    }

                    if (regs[0] != 0 || (regs[1] & 0x20) != 0)
                        regs[0] = --regs[0] & 0xF;
                }
                else
                {
                    reset = false;
                    regs[0] = 0xF;
                }

                count = regs[1] & 0x0F;
                UpdateLevel();
            }
            public void PokeReg(byte data)
            {
                regs[1] = data;
                UpdateLevel();
            }
        }
    }
}