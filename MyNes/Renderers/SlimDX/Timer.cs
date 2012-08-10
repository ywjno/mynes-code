using System.ComponentModel;
using System.Runtime.InteropServices;
using myNES.Core.Controls;

namespace myNES
{
    public class Timer : ITimer
    {
        private long frequency;

        public Timer()
        {
            if (!QueryPerformanceFrequency(out frequency))
                throw new Win32Exception();
        }

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        public double GetCurrentTime()
        {
            long counter;
            QueryPerformanceCounter(out counter);

            return (double)counter / (double)frequency;
        }
    }
}