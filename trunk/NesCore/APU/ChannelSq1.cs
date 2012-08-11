using System;

namespace myNES.Core.APU
{
    public class ChannelSq1 : Apu.Channel
    {
        // $4000 / $4004 - ...C VVVV - constant volume (C), volume/envelope (V)
        // $4001 / $4005 - EPPP NSSS - Sweep unit: enabled (E), period (P), negate (N), shift (S)

        private Apu.Duty dutyForm = new Apu.Duty(8, 0x01, 0x03, 0x0F, 0xFC);
        private Apu.Duration duration = new Apu.Duration();
        private Apu.Envelope envelope = new Apu.Envelope();

        private bool sweep_enabled;
        private bool sweep_refresh;
        private int sweep_timer;
        private int sweep_delay;

        public override bool Status
        {
            get { return duration.Counter != 0; }
            set { duration.SetEnabled(value); }
        }

        public ChannelSq1(TimingInfo.System system)
            : base(system) { }

        protected override void PokeReg1(int address, byte data)
        {
            dutyForm.Form = (data >> 6);
            duration.Halt = (data & 0x20) != 0;
            envelope.PokeReg(data);
        }
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
            dutyForm.Reset();
        }

        public override byte Render(int cycles)
        {
            if (duration.Counter != 0)
            {
                int sum = timing.cycles;
                timing.cycles -= cycles;

                if (timing.cycles >= 0)
                {
                    return (byte)(dutyForm.Value() * envelope.level);
                }
                else
                {
                    sum *= dutyForm.Value();

                    do
                    {
                        dutyForm.Clock();

                        sum += Math.Min(-timing.cycles, timing.single) * dutyForm.Value();
                        timing.cycles += timing.single;
                    }
                    while (timing.cycles < 0);

                    return (byte)((sum * envelope.level) / cycles);
                }
            }

            return 0;
        }
    }
}