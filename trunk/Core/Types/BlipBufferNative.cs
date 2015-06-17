/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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
using System;
using System.Runtime.InteropServices;
namespace MyNes.Core
{
    // Band-limited sound synthesis buffer
    // http://www.slack.net/~ant/

    /* Copyright (C) 2003-2007 Shay Green. This module is free software; you
    can redistribute it and/or modify it under the terms of the GNU Lesser
    General Public License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version. This
    module is distributed in the hope that it will be useful, but WITHOUT ANY
    WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
    FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
    details. You should have received a copy of the GNU Lesser General Public
    License along with this module; if not, write to the Free Software Foundation,
    Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA */
    public sealed class BlipBufferNative : IDisposable
    {
        private static class BlipBufDll
        {
            public const int blip_max_ratio = 1048576;
            public const int blip_max_frame = 4000;
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr blip_new(int sample_count);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void blip_set_rates(IntPtr context, double clock_rate, double sample_rate);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void blip_clear(IntPtr context);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void blip_add_delta(IntPtr context, uint clock_time, int delta);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void blip_add_delta_fast(IntPtr context, uint clock_time, int delta);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int blip_clocks_needed(IntPtr context, int sample_count);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void blip_end_frame(IntPtr context, uint clock_duration);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int blip_samples_avail(IntPtr context);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int blip_read_samples(IntPtr context, short[] @out, int count, int stereo);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int blip_read_samples(IntPtr context, IntPtr @out, int count, int stereo);
            [DllImport("blip_buf.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void blip_delete(IntPtr context);
        }
        public const int MaxRatio = 1048576;
        public const int MaxFrame = 4000;
        private IntPtr context;
        public BlipBufferNative(int sample_count)
        {
            this.context = BlipBufferNative.BlipBufDll.blip_new(sample_count);
            if (this.context == IntPtr.Zero)
            {
                throw new Exception("blip_new returned NULL!");
            }
        }
        public void Dispose()
        {
            BlipBufferNative.BlipBufDll.blip_delete(this.context);
            this.context = IntPtr.Zero;
        }
        public void SetRates(double clock_rate, double sample_rate)
        {
            BlipBufferNative.BlipBufDll.blip_set_rates(this.context, clock_rate, sample_rate);
        }
        public void Clear()
        {
            BlipBufferNative.BlipBufDll.blip_clear(this.context);
        }
        public void AddDelta(uint clock_time, int delta)
        {
            BlipBufferNative.BlipBufDll.blip_add_delta(this.context, clock_time, delta);
        }
        public void AddDeltaFast(uint clock_time, int delta)
        {
            BlipBufferNative.BlipBufDll.blip_add_delta_fast(this.context, clock_time, delta);
        }
        public int ClocksNeeded(int sample_count)
        {
            return BlipBufferNative.BlipBufDll.blip_clocks_needed(this.context, sample_count);
        }
        public void EndFrame(uint clock_duration)
        {
            BlipBufferNative.BlipBufDll.blip_end_frame(this.context, clock_duration);
        }
        public int SamplesAvailable()
        {
            return BlipBufferNative.BlipBufDll.blip_samples_avail(this.context);
        }
        public int ReadSamples(short[] output, int count, bool stereo)
        {
            if (output.Length < count * (stereo ? 2 : 1))
            {
                throw new ArgumentOutOfRangeException();
            }
            return BlipBufferNative.BlipBufDll.blip_read_samples(this.context, output, count, stereo ? 1 : 0);
        }
    }
}
