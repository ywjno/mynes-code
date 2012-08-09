using System.Threading;
namespace myNES.Core.Controls
{
    /// <summary>
    /// The speed limiter which should control speed depending on emulation system
    /// </summary>
    public class SpeedLimiter
    {
        public SpeedLimiter(ITimer timer, TimingInfo.System emuSystem)
        {
            this.timer = timer;
            this.emuSystem = emuSystem;
            this.ON = true;
        }
        private ITimer timer;
        private TimingInfo.System emuSystem;
        public bool ON;

        public double CurrentFrameTime;
        public double DeadTime;
        public double LastFrameTime;
        public double FramePeriod = (1.0 / 60.0);

        /// <summary>
        /// Call this when a frame completed
        /// </summary>
        public void Update()
        {
            CurrentFrameTime = timer.GetCurrentTime() - LastFrameTime;
            DeadTime = FramePeriod - CurrentFrameTime;
            if (ON)
            {
                if (DeadTime > 0)
                    Thread.Sleep((int)(DeadTime * 1000));

                while (CurrentFrameTime < FramePeriod)
                {
                    if ((timer.GetCurrentTime() - LastFrameTime) > FramePeriod)
                    {
                        break;
                    }
                }
            }
            LastFrameTime = timer.GetCurrentTime();
        }
        public void SleepOnPause()
        {
            Thread.Sleep(100);
        }
    }
    public interface ITimer
    {
        /// <summary>
        /// Get current time
        /// </summary>
        /// <returns></returns>
        double GetCurrentTime();
    }
}
