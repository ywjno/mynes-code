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
using System;
using System.Windows.Forms;
using MyNes.Core.IO;
using MyNes.Core;
using SlimDX.DirectSound;
using SlimDX.Multimedia;
using Console = MyNes.Core.Console;

namespace MyNes.Renderers
{
    class SlimDXDirectSound : IAudioDevice
    {
        public SlimDXDirectSound(IntPtr handle)
        {
            LoadSettings();
            Initialize(handle);
        }
        //slimdx
        public DirectSound _SoundDevice;
        public SecondarySoundBuffer buffer;
        private WaveRecorder Recorder = new WaveRecorder();

        private bool IsPaused;
        public bool IsRendering = false;
        private bool _FirstRender = true;
        public byte[] DATA = new byte[44100];
        private int BufferSize = 44100;
        private int latency = 0x1000;
        private int W_Pos = 0;//Write position
        private int L_Pos = 0;//Last position
        private int D_Pos = 0;//Data position
        // Settings
        private int latency_in_milliseconds;
        private int playback_frequency;
        private short bits_per_sample = 16;
        private short channels_count = 1;
        private int volume = 0;

        public void Initialize(IntPtr handle)
        {
            //Create the device
            Console.WriteLine("Initializing directSound ...");
            _SoundDevice = new DirectSound();
            _SoundDevice.SetCooperativeLevel(handle, CooperativeLevel.Normal);
            //Create the wav format
            WaveFormat wav = new WaveFormat();
            wav.FormatTag = WaveFormatTag.Pcm;
            wav.SamplesPerSecond = playback_frequency;
            wav.Channels = channels_count;
            wav.BitsPerSample = bits_per_sample;
            wav.AverageBytesPerSecond = wav.SamplesPerSecond * wav.Channels * (wav.BitsPerSample / 8);
            wav.BlockAlignment = (short)(wav.Channels * wav.BitsPerSample / 8);
            BufferSize = wav.AverageBytesPerSecond;
            //Description
            SoundBufferDescription des = new SoundBufferDescription();
            des.Format = wav;
            des.SizeInBytes = BufferSize;
            des.Flags = BufferFlags.ControlVolume | BufferFlags.ControlFrequency | BufferFlags.ControlPan |
                BufferFlags.Software;
            //buffer (1 second length)
            DATA = new byte[BufferSize];

            latency = (latency_in_milliseconds * BufferSize) / 1000;

            buffer = new SecondarySoundBuffer(_SoundDevice, des);
            buffer.Play(0, PlayFlags.Looping);

            // Set volume
            SetVolume(volume);
            Console.WriteLine("DirectSound initialized OK.", DebugCode.Good);
        }

        public void LoadSettings()
        {
            volume = Program.Settings.AudioVolume;
            latency_in_milliseconds = Program.Settings.AudioLatency;
            playback_frequency = Program.Settings.AudioFrequency;
            bits_per_sample = Program.Settings.AudioBitsPerSample;
            channels_count = Program.Settings.AudioChannelsCount;
        }

        public override void UpdateFrame()
        {
            if (buffer == null | buffer.Disposed)
            { IsRendering = false; return; }
            switch (channels_count)
            {
                case 1:// Mono
                    {
                        switch (bits_per_sample)
                        {
                            case 8: PullSample_Mono_8Bit(); break;
                            case 16: PullSample_Mono_16Bit(); break;
                            case 32: PullSample_Mono_32Bit(); break;
                        }
                        break;
                    }
                case 2:// Stereo
                    {
                        switch (bits_per_sample)
                        {
                            case 8: PullSample_Stereo_8Bit(); break;
                            case 16: PullSample_Stereo_16Bit(); break;
                            case 32: PullSample_Stereo_32Bit(); break;
                        }
                        break;
                    }
            }
        }
        private void PullSample_Mono_8Bit()
        {
            W_Pos = buffer.CurrentWritePosition;
            if (_FirstRender)
            {
                _FirstRender = false;
                D_Pos = buffer.CurrentWritePosition + latency;
                L_Pos = buffer.CurrentWritePosition;
            }
            int po = W_Pos - L_Pos;
            int ps = D_Pos;
            if (po < 0)
            {
                po = (BufferSize - L_Pos) + W_Pos;
            }
            if (po != 0)
            {
                for (int i = 0; i < po; i++)
                {
                    //Get the sample from the apu
                    int OUT = NesCore.APU.PullSample();
                    //RECORD
                    if (Recorder.IsRecording)
                        Recorder.AddSample((short)OUT);
                    if (D_Pos < DATA.Length)
                    {
                        DATA[D_Pos] = (byte)(OUT & 0xFF);
                    }
                    D_Pos++;
                    D_Pos = D_Pos % BufferSize;
                }
                buffer.Write(DATA, 0, LockFlags.None);
                L_Pos = W_Pos;
            }
        }
        private void PullSample_Mono_16Bit()
        {
            W_Pos = buffer.CurrentWritePosition;
            if (_FirstRender)
            {
                _FirstRender = false;
                D_Pos = buffer.CurrentWritePosition + latency;
                L_Pos = buffer.CurrentWritePosition;
            }
            int po = W_Pos - L_Pos;
            int ps = D_Pos;
            if (po < 0)
            {
                po = (BufferSize - L_Pos) + W_Pos;
            }
            if (po != 0)
            {
                for (int i = 0; i < po; i += 2)
                {
                    //Get the sample from the apu
                    int OUT = NesCore.APU.PullSample();
                    //RECORD
                    if (Recorder.IsRecording)
                        Recorder.AddSample((short)OUT);
                    if (D_Pos < DATA.Length)
                    {
                        DATA[D_Pos] = (byte)((OUT & 0xFF00) >> 8);
                        DATA[D_Pos + 1] = (byte)(OUT & 0xFF);
                    }
                    D_Pos += 2;
                    D_Pos = D_Pos % BufferSize;
                }
                buffer.Write(DATA, 0, LockFlags.None);
                L_Pos = W_Pos;
            }
        }
        private void PullSample_Mono_32Bit()
        {
            W_Pos = buffer.CurrentWritePosition;
            if (_FirstRender)
            {
                _FirstRender = false;
                D_Pos = buffer.CurrentWritePosition + latency;
                L_Pos = buffer.CurrentWritePosition;
            }
            int po = W_Pos - L_Pos;
            int ps = D_Pos;
            if (po < 0)
            {
                po = (BufferSize - L_Pos) + W_Pos;
            }
            if (po != 0)
            {
                for (int i = 0; i < po; i += 4)
                {
                    //Get the sample from the apu
                    int OUT = NesCore.APU.PullSample();
                    //RECORD
                    if (Recorder.IsRecording)
                        Recorder.AddSample((short)OUT);
                    if (D_Pos < DATA.Length)
                    {
                        DATA[D_Pos + 0] = (byte)((OUT & 0xFF000000) >> 24);
                        DATA[D_Pos + 1] = (byte)((OUT & 0x00FF0000) >> 16);
                        DATA[D_Pos + 2] = (byte)((OUT & 0x0000FF00) >> 08);
                        DATA[D_Pos + 3] = (byte)((OUT & 0x000000FF) >> 00);
                    }
                    D_Pos += 4;
                    D_Pos = D_Pos % BufferSize;
                }
                buffer.Write(DATA, 0, LockFlags.None);
                L_Pos = W_Pos;
            }
        }
        private void PullSample_Stereo_8Bit()
        {
            W_Pos = buffer.CurrentWritePosition;
            if (_FirstRender)
            {
                _FirstRender = false;
                D_Pos = buffer.CurrentWritePosition + latency;
                L_Pos = buffer.CurrentWritePosition;
            }
            int po = W_Pos - L_Pos;
            int ps = D_Pos;
            if (po < 0)
            {
                po = (BufferSize - L_Pos) + W_Pos;
            }
            if (po != 0)
            {
                for (int i = 0; i < po; i += 2)
                {
                    //Get the sample from the apu
                    int OUT = NesCore.APU.PullSample();
                    //RECORD
                    if (Recorder.IsRecording)
                        Recorder.AddSample((short)OUT);
                    if (D_Pos < DATA.Length)
                    {
                        DATA[D_Pos] = (byte)(OUT & 0xFF);
                        // Add same sample twice
                        DATA[D_Pos + 1] = (byte)(OUT & 0xFF);
                    }
                    D_Pos += 2;
                    D_Pos = D_Pos % BufferSize;
                }
                buffer.Write(DATA, 0, LockFlags.None);
                L_Pos = W_Pos;
            }
        }
        private void PullSample_Stereo_16Bit()
        {
            W_Pos = buffer.CurrentWritePosition;
            if (_FirstRender)
            {
                _FirstRender = false;
                D_Pos = buffer.CurrentWritePosition + latency;
                L_Pos = buffer.CurrentWritePosition;
            }
            int po = W_Pos - L_Pos;
            int ps = D_Pos;
            if (po < 0)
            {
                po = (BufferSize - L_Pos) + W_Pos;
            }
            if (po != 0)
            {
                for (int i = 0; i < po; i += 4)
                {
                    //Get the sample from the apu
                    int OUT = NesCore.APU.PullSample();
                    //RECORD
                    if (Recorder.IsRecording)
                        Recorder.AddSample((short)OUT);
                    if (D_Pos < DATA.Length)
                    {
                        DATA[D_Pos + 0] = (byte)((OUT & 0xFF00) >> 8);
                        DATA[D_Pos + 1] = (byte)(OUT & 0xFF);
                        // Add same sample twice
                        DATA[D_Pos + 2] = (byte)((OUT & 0xFF00) >> 8);
                        DATA[D_Pos + 3] = (byte)(OUT & 0xFF);
                    }
                    D_Pos += 4;
                    D_Pos = D_Pos % BufferSize;
                }
                buffer.Write(DATA, 0, LockFlags.None);
                L_Pos = W_Pos;
            }
        }
        private void PullSample_Stereo_32Bit()
        {
            W_Pos = buffer.CurrentWritePosition;
            if (_FirstRender)
            {
                _FirstRender = false;
                D_Pos = buffer.CurrentWritePosition + latency;
                L_Pos = buffer.CurrentWritePosition;
            }
            int po = W_Pos - L_Pos;
            int ps = D_Pos;
            if (po < 0)
            {
                po = (BufferSize - L_Pos) + W_Pos;
            }
            if (po != 0)
            {
                for (int i = 0; i < po; i += 8)
                {
                    //Get the sample from the apu
                    int OUT = NesCore.APU.PullSample();
                    //RECORD
                    if (Recorder.IsRecording)
                        Recorder.AddSample((short)OUT);
                    if (D_Pos < DATA.Length)
                    {
                        DATA[D_Pos + 0] = (byte)((OUT & 0xFF000000) >> 24);
                        DATA[D_Pos + 1] = (byte)((OUT & 0x00FF0000) >> 16);
                        DATA[D_Pos + 2] = (byte)((OUT & 0x0000FF00) >> 08);
                        DATA[D_Pos + 3] = (byte)((OUT & 0x000000FF) >> 00);
                        // Add same sample twice
                        DATA[D_Pos + 4] = (byte)((OUT & 0xFF000000) >> 24);
                        DATA[D_Pos + 5] = (byte)((OUT & 0x00FF0000) >> 16);
                        DATA[D_Pos + 6] = (byte)((OUT & 0x0000FF00) >> 08);
                        DATA[D_Pos + 7] = (byte)((OUT & 0x000000FF) >> 00);
                    }
                    D_Pos += 8;
                    D_Pos = D_Pos % BufferSize;
                }
                buffer.Write(DATA, 0, LockFlags.None);
                L_Pos = W_Pos;
            }
        }

        public override void Play()
        {
            if (!IsPaused)
            { return; }
            if (buffer != null && !buffer.Disposed & !IsRendering)
            {
                IsPaused = false;
                try//Sometimes this line throw an exception for unknown reason !!
                {
                    buffer.Play(0, PlayFlags.Looping);
                }
                catch { }
            }
        }
        public override void Stop()
        {
            if (IsPaused)
            { return; }
            if (buffer != null && !buffer.Disposed & !IsRendering)
            {
                buffer.Stop();
                IsPaused = true;
            }
        }
        public override void Shutdown()
        {
            Console.WriteLine("SlimDX: shutdown audio ..");
            IsPaused = true;
            if (buffer != null)
            {
                buffer.Stop();
                buffer.Dispose();
            }
            if (_SoundDevice != null)
                _SoundDevice.Dispose();
            if (Recorder.IsRecording)
                Recorder.Stop();

            Console.WriteLine("SlimDX: audio shutdown done.", DebugCode.Good);
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
        public override bool IsRecording
        {
            get { return Recorder.IsRecording; }
        }
        public override void Record(string filePath)
        {
            Recorder.Record(filePath, channels_count, bits_per_sample, playback_frequency);
        }
        public override void RecordStop()
        {
            Recorder.Stop();
            NesCore.VideoOutput.DrawNotification("Record stopped.", 120, System.Drawing.Color.Green.ToArgb());
        }
        public override int RecordTime
        {
            get { return Recorder.Time; }
        }
        public override bool IsPlaying
        {
            get { return !IsPaused; }
        }
        public override void ResetBuffer()
        {
            _FirstRender = true;
            D_Pos = 0;
            L_Pos = 0;
            NesCore.APU.ResetBuffer();
        }
    }
}