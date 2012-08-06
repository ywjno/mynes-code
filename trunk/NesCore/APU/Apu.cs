namespace MyNes.Core
{
    public class Apu : ProcessorBase
    {
        public Apu(TimingInfo.Cookie cookie)
            : base(cookie)
        {
            timing.period = cookie.Master;
            timing.single = cookie.Spu;
        }

        public override void Update() { }

        public void Shutdown() { }
        public void Initialize() { }
    }
}
