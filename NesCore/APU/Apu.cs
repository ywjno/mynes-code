namespace MyNes.Core
{
    public class Apu : ProcessorBase
    {
        public Apu(TimingInfo.System system)
            : base(system)
        {
            timing.period = system.Master;
            timing.single = system.Spu;
        }

        public override void Update() { }

        public void Shutdown() { }
        public void Initialize() { }
    }
}