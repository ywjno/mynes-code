namespace MyNes.Core
{
    public class ProcessorBase
    {
        protected TimingInfo timing;
        protected TimingInfo.Cookie cookie;

        public ProcessorBase(TimingInfo.Cookie cookie)
        {
            this.cookie = cookie;
        }

        public virtual void Update()
        {
        }
        public virtual void Update(int cycles)
        {
            while (timing.cycles < cycles)
            {
                timing.cycles += cycles;

                Update();
            }

            timing.cycles -= cycles;
        }
    }
}