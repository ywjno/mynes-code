namespace myNES.Core
{
    public class ProcessorBase
    {
        protected TimingInfo timing;
        protected TimingInfo.System system;

        public ProcessorBase(TimingInfo.System system)
        {
            this.system = system;
        }

        public virtual void Initialize() { }
        public virtual void Shutdown() { }

        public virtual void Update() { }
        public virtual void Update(int cycles)
        {
            while (timing.cycles < cycles)
            {
                timing.cycles += timing.single;

                Update();
            }

            timing.cycles -= cycles;
        }
    }
}