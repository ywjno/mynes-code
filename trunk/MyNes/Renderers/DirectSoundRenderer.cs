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
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MyNes.Core;
using SlimDX.DirectSound;
using SlimDX.Multimedia;

namespace MyNes
{
    public class DirectSoundRenderer : IAudioProvider
    {
        public DirectSoundRenderer(IntPtr handle)
        {
            LoadSettings();
            Initialize(handle);
        }
        // slimdx
        public DirectSound _SoundDevice;
        public SecondarySoundBuffer buffer;
        public WaveRecorder Recorder = new WaveRecorder();

        private int volume = 0;
        private bool IsPaused;
        public bool IsRendering = false;
        public int BufferSize = 44100;
        public int latency_in_bytes;
        public int latency_in_samples;
        private bool isInitialized;

        private int[] buffer_internal;
        private int buffer_internal_size;
        private int buffer_internal_r_pos;
        private int buffer_internal_w_pos;

        private byte[] buffer_playback;
        private int buffer_playback_size;
        private int buffer_playback_current_pos;
        private int buffer_playback_last_pos;
        private int buffer_playback_w_pos;
        private int buffer_playback_required_samples;
        private int buffer_playback_i;
        private int buffer_playback_currentSample;

        // Latency adjust
        private int comparer_w;
        private int comparer_wm;
        private bool comparer_condition;
        public void Initialize(IntPtr handle)
        {
            if (isInitialized)
            {
                Dispose();
            }
            isInitialized = false;
            LoadSettings();
            //Create the device
            Console.WriteLine("DirectSound: Initializing directSound ...");
            _SoundDevice = new DirectSound();
            _SoundDevice.SetCooperativeLevel(handle, CooperativeLevel.Normal);

            //Create the wav format
            WaveFormat wav = new WaveFormat();
            wav.FormatTag = WaveFormatTag.Pcm;
            wav.SamplesPerSecond = Program.Settings.Audio_Frequency;
            wav.Channels = 1;
            wav.BitsPerSample = Program.Settings.Audio_BitsPerSample;
            wav.AverageBytesPerSecond = wav.SamplesPerSecond * wav.Channels * (wav.BitsPerSample / 8);
            wav.BlockAlignment = (short)(wav.Channels * wav.BitsPerSample / 8);

            //BufferSize = (int)(wav.AverageBytesPerSecond * ((double)Program.Settings.Audio_BufferSizeInMilliseconds) / (double)1000);
            BufferSize = Program.Settings.Audio_BufferSizeInBytes;

            //latency_in_bytes = (int)((double)wav.AverageBytesPerSecond * (double)(Program.Settings.Audio_LatencyInPrecentage / (double)1000));
            latency_in_bytes = (Program.Settings.Audio_LatencyInPrecentage * BufferSize) / 100;
            latency_in_samples = latency_in_bytes / 2;

            Console.WriteLine("DirectSound: BufferSize = " + BufferSize + " Byte");
            Console.WriteLine("DirectSound: Latency in bytes = " + latency_in_bytes + " Byte");
            //Description
            SoundBufferDescription des = new SoundBufferDescription();
            des.Format = wav;
            des.SizeInBytes = BufferSize;
            des.Flags = BufferFlags.ControlVolume | BufferFlags.ControlFrequency | BufferFlags.ControlPan | BufferFlags.Software;

            buffer = new SecondarySoundBuffer(_SoundDevice, des);
            //buffer.Play(0, PlayFlags.Looping);

            // Set volume
            SetVolume(volume);
            Console.WriteLine("DirectSound: DirectSound initialized OK.");
            isInitialized = true;

            Shutdown();
        }
        public void LoadSettings()
        {
            volume = Program.Settings.Audio_Volume;
        }

        public void Update(ref short[] nesBuffer)
        {
            if (!isInitialized)
                return;

            IsRendering = true;
            // Get the playback buffer needed samples
            buffer_playback_current_pos = buffer.CurrentWritePosition;
            buffer_playback_w_pos = buffer_playback_last_pos;

            buffer_playback_required_samples = buffer_playback_current_pos - buffer_playback_last_pos;
            if (buffer_playback_required_samples < 0)
                buffer_playback_required_samples = (buffer_playback_size - buffer_playback_last_pos) + buffer_playback_current_pos;
            // fill up the internal buffer using the nes buffer
            for (int i = 0; i < nesBuffer.Length; i++)
            {
                buffer_playback_currentSample = nesBuffer[i];
                // Limit peek level
                if (buffer_playback_currentSample > 120)
                    buffer_playback_currentSample = 120;
                if (buffer_playback_currentSample < -120)
                    buffer_playback_currentSample = -120;

                if (buffer_internal_w_pos >= buffer_internal_size)
                    buffer_internal_w_pos = 0;

                buffer_internal[buffer_internal_w_pos] = buffer_playback_currentSample;

                buffer_internal_w_pos++;
                if (buffer_internal_w_pos >= buffer_internal_size)
                    buffer_internal_w_pos = 0;

                if (Recorder.IsRecording)
                    Recorder.AddSample(ref buffer_playback_currentSample);
            }
            // Fill up the playback buffer
            for (buffer_playback_i = 0; buffer_playback_i < buffer_playback_required_samples; buffer_playback_i += 2)
            {
                // Get the sample from the internal buffer
                if (buffer_internal_r_pos >= buffer_internal_size || buffer_internal_r_pos < 0)
                    buffer_internal_r_pos = 0;
                buffer_playback_currentSample = buffer_internal[buffer_internal_r_pos];
                buffer_internal_r_pos++;
                if (buffer_internal_r_pos >= buffer_internal_size)
                    buffer_internal_r_pos = 0;

                // Put it in the playback buffer
                if (buffer_playback_w_pos >= buffer_playback_size)
                    buffer_playback_w_pos = 0;

                buffer_playback[buffer_playback_w_pos] = (byte)((buffer_playback_currentSample & 0xFF00) >> 8);
                buffer_playback_w_pos++;
                if (buffer_playback_w_pos >= buffer_playback_size)
                    buffer_playback_w_pos = 0;

                buffer_playback[buffer_playback_w_pos] = (byte)(buffer_playback_currentSample & 0xFF);
                buffer_playback_w_pos++;
                if (buffer_playback_w_pos >= buffer_playback_size)
                    buffer_playback_w_pos = 0;
            }

            buffer.Write(buffer_playback, 0, LockFlags.None);

            buffer_playback_last_pos = buffer_playback_current_pos;
            IsRendering = false;

            // W: the write pointer in samples
            // R: the read pointer in samples
            // L: latency in samples
            // Lm: maximum latency, Lm= L * 2 
            //
            // To keep up the synchronization, it must be
            // 
            //         Lm
            //         v        L
            //         v        v        W
            //         v        v        v
            // ...TTTTT[////////|XXXXXXXX]
            //      ^    ^          ^    
            //      ^    ^          ^
            //      ^    ^          R MUST NOT be here in XXX area (results corrupted sound)
            //      ^    R must be here somewhere in the /// area
            //      R MUST NOT be here in TTT area (results more latency than we want !)
            //
            comparer_wm = buffer_internal_w_pos - latency_in_bytes;// latency_in_bytes = latency_in_samples * 2
            if (comparer_wm > 0)
            {
                comparer_w = buffer_internal_w_pos - latency_in_samples;

                comparer_condition = buffer_internal_r_pos > comparer_wm && buffer_internal_r_pos < comparer_w;

                if (!comparer_condition)
                {
                    // Program.FormMain.video.WriteNotification(
                    //   string.Format("FIX ! CW = {0}; CWm = {1}; R = {2};", comparer_w, comparer_wm, buffer_internal_r_pos), 320, System.Drawing.Color.Red);

                    // Do the fix !
                    buffer_internal_r_pos = comparer_w - 4;
                }
            }
        }
        public void Dispose()
        {
            isInitialized = false;
            Stop();

            buffer.Dispose(); buffer = null;
            _SoundDevice.Dispose(); _SoundDevice = null;

            GC.Collect();
        }
        public void Play()
        {
            if (!IsPaused)
                return;

            if (isInitialized)
            {
                IsPaused = false;
                // Reset buffer pointers
                buffer_internal_r_pos = buffer_internal_w_pos - latency_in_samples;

                buffer.Play(0, PlayFlags.Looping);
            }
        }
        public void Pause()
        {
            if (IsPaused)
                return;
            if (buffer == null)
                return;
            if (!buffer.Disposed & !IsRendering)
            {
                buffer.Stop();
                IsPaused = true;
            }
        }
        public void Stop()
        {
            if (IsPaused)
            { return; }
            if (buffer == null)
                return;
            if (!buffer.Disposed & !IsRendering)
            {
                buffer.Stop();
                IsPaused = true;
            }
        }
        public void Shutdown()
        {
            Stop();
            if (Recorder.IsRecording)
                Recorder.Stop();
            // Set buffers
            buffer_internal_size = (BufferSize / 2);
            buffer_internal = new int[buffer_internal_size];
            buffer_internal_r_pos = 0;
            buffer_internal_w_pos = 0;

            buffer_playback_size = BufferSize;
            buffer_playback = new byte[buffer_playback_size];
            buffer_playback_current_pos = 0;
            buffer_playback_last_pos = 0;
            buffer_playback_required_samples = 0;
            buffer_playback_i = 0;
            buffer_playback_currentSample = 0;

            // Noise on shutdown; MISC
            Random r = new Random();
            for (int i = 0; i < buffer_internal.Length; i++)
                buffer_internal[i] = (byte)r.Next(0, 20);

            for (int i = 0; i < buffer_playback.Length; i++)
                buffer_playback[i] = (byte)r.Next(0, 20);
        }
        public void SetVolume(int Vol)
        {
            if (buffer != null && !buffer.Disposed & !IsRendering)
            {
                int volLev = (Vol * 3000) / 100;
                buffer.Volume = -3000 + volLev;
            }
        }
        public void SetPan(int Pan)
        {
            if (buffer != null && !buffer.Disposed & !IsRendering)
            {
                buffer.Pan = Pan;
            }
        }
        public bool IsRecording
        {
            get { return Recorder.IsRecording; }
        }
        public void Record(string filePath)
        {
            Recorder.Record(filePath, 1, Program.Settings.Audio_BitsPerSample, Program.Settings.Audio_Frequency);
        }
        public void RecordStop()
        {
            Recorder.Stop();
        }
        public int RecordTime
        {
            get { return Recorder.Time; }
        }
        public bool IsPlaying
        {
            get { return !IsPaused; }
        }
    }
}
