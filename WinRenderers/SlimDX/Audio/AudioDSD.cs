/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
using MyNes.Core.IO.Output;
using MyNes.Core;
using MyNes.Renderers;
using SlimDX.DirectSound;
using SlimDX.Multimedia;
using Console = MyNes.Core.Console;
namespace MyNes.WinRenderers
{
    public class AudioDSD : IAudioDevice
    {
        public AudioDSD(IntPtr handle, int playbackFreq, int latency)
        {
            Initialize(handle, playbackFreq, latency);
        }
        public Control _Control;
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
        private int playbackFreq;

        public void Initialize(IntPtr handle, int playbackFreq, int latencyInMilliseconds)
        {
            this.playbackFreq = playbackFreq;
            //Create the device
            Console.WriteLine("SlimDX: initializing directSound ...");
            _SoundDevice = new DirectSound();
            _SoundDevice.SetCooperativeLevel(handle, CooperativeLevel.Normal);
            //Create the wav format
            WaveFormat wav = new WaveFormat();
            wav.FormatTag = WaveFormatTag.Pcm;
            wav.SamplesPerSecond = playbackFreq;
            wav.Channels = 1;
            wav.BitsPerSample = 16;
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

            latency = (latencyInMilliseconds * BufferSize) / 1000;

            buffer = new SecondarySoundBuffer(_SoundDevice, des);
            buffer.Play(0, PlayFlags.Looping);
            Console.WriteLine("SlimDX: directSound initialized OK.", DebugCode.Good);
        }

        public void UpdateFrame()
        {
            if (buffer == null | buffer.Disposed)
            { IsRendering = false; return; }
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
                    short OUT = Nes.Apu.PullSample();
                    //RECORD
                    if (Recorder.IsRecording)
                        Recorder.AddSample(OUT);
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
        /*Perfect method for sound rendering but I can't figure out how to fix the delay :(*/
        public void SubmitBuffer(byte[] samplesBuffer)
        {
            if (buffer == null | buffer.Disposed)
            { IsRendering = false; return; }

            if (buffer.Status == BufferStatus.BufferLost)
                buffer.Restore();

            buffer.Write(samplesBuffer, W_Pos, LockFlags.None);

            W_Pos += samplesBuffer.Length;

            if (W_Pos > BufferSize)
                W_Pos -= BufferSize;
        }

        public void Play()
        {
            if (!IsPaused)
            { return; }
            if (buffer != null && !buffer.Disposed & !IsRendering)
            {
                IsPaused = false;
                try//Sometimes this line throw an exception for unkown reason !!
                {
                    buffer.Play(0, PlayFlags.Looping);
                }
                catch { }
            }
        }
        public void Stop()
        {
            if (IsPaused)
            { return; }
            if (buffer != null && !buffer.Disposed & !IsRendering)
            {
                buffer.Stop();
                IsPaused = true;
            }
        }
        public void Shutdown()
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
                buffer.Volume = Vol;
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
            Recorder.Record(filePath, playbackFreq);
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
        public void ResetBuffer()
        {
            _FirstRender = true;
            D_Pos = 0;
            L_Pos = 0;
            Nes.Apu.ResetBuffer();
        }
    }
}