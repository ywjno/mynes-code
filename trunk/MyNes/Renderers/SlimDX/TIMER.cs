using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using myNES.Core.Controls;

namespace myNES
{
    public class TIMER : ITimer
    {
        private long _frequency;
        public TIMER()
        {
            if (!QueryPerformanceFrequency(out this._frequency))
            {
                throw new Win32Exception();
            }
        }
        public double GetCurrentTime()
        {
            long num;
            QueryPerformanceCounter(out num);
            return (((double)num) / ((double)this._frequency));
        }
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);
    }
}