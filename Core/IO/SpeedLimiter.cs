/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System.Diagnostics;
using System.Threading;

namespace MyNes.Core.IO
{
    /// <summary>
    /// The speed limiter which should control speed depending on emulation system
    /// </summary>
    public class SpeedLimiter : INesComponent
    {
        public SpeedLimiter()
        {
            this.st = Stopwatch.StartNew();
            this.ON = true;

            HardReset();
        }
        private Stopwatch st;
        public bool ON;

        public double CurrentFrameTime;
        public double ImmediateFrameTime;
        public double DeadTime;
        public double LastFrameTime;
        public double FramePeriod = (1.0 / 60.0988);
        public double FPS = 0;

        /// <summary>
        /// Call this when a frame completed
        /// </summary>
        public void Update()
        {
            ImmediateFrameTime = CurrentFrameTime = GetTime() - LastFrameTime;
            DeadTime = FramePeriod - CurrentFrameTime;
            if (ON)
            {
                //This should relieve the pc's cpu for the dead time
                //but after monitoring performance this has no effect.
                // if (DeadTime > 0)
                //    Thread.Sleep((int)(DeadTime * 1000));

                while (ImmediateFrameTime < FramePeriod)
                {
                    ImmediateFrameTime = GetTime() - LastFrameTime;
                    //if ((timer.GetCurrentTime() - LastFrameTime) > FramePeriod)
                    //{
                    //    break;
                    //}
                }
            }
            LastFrameTime = GetTime();
        }
        public void SleepOnPause()
        {
            Thread.Sleep(100);
        }
        public override void HardReset()
        {
            if (NesCore.TV == TVSystem.NTSC)
                FramePeriod = (1.0 / (FPS = 60.0988));
            else//PALB, DENDY
                FramePeriod = (1.0 / (FPS = 50.0070));
        }
        private double GetTime()
        {
            return (double)Stopwatch.GetTimestamp() / (double)Stopwatch.Frequency;
        }
    }
}
