namespace myNES.Core.APU
{
    public class Apu : ProcessorBase
    {
        private ChannelSq1 sq1;
        private ChannelSq2 sq2;
        private ChannelTri tri;
        private ChannelNoi noi;
        private ChannelDmc dmc;

        public Apu(TimingInfo.System system)
            : base(system)
        {
            timing.period = system.Master;
            timing.single = system.Spu;

            sq1 = new ChannelSq1(system);
            sq2 = new ChannelSq2(system);
            tri = new ChannelTri(system);
            noi = new ChannelNoi(system);
            dmc = new ChannelDmc(system);
        }

        public override void Initialize()
        {
            sq1.Hook(0x4000);
            sq2.Hook(0x4004);
            tri.Hook(0x4008);
            noi.Hook(0x400C);
            dmc.Hook(0x4010);
        }
        public override void Shutdown() { }
        public override void Update() { }

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
                return cycles * system.Cpu;
            }

            protected virtual void PokeReg1(int address, byte data) { }
            protected virtual void PokeReg2(int address, byte data) { }
            protected virtual void PokeReg3(int address, byte data) { }
            protected virtual void PokeReg4(int address, byte data) { }

            public virtual void Hook(int address)
            {
                Nes.CpuMemory.Hook(address++, PokeReg1);
                Nes.CpuMemory.Hook(address++, PokeReg2);
                Nes.CpuMemory.Hook(address++, PokeReg3);
                Nes.CpuMemory.Hook(address++, PokeReg4);
            }

            public virtual void ClockDuration() { }
            public virtual void ClockEnvelope() { }
            public virtual byte Render() { return 0; }
        }
    }
}