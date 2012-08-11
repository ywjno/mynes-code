using System;
using myNES.Core.IO.Output;
using SlimDX.DirectSound;
using SlimDX.Multimedia;
using myNES.Core;

namespace myNES
{
    public class AudioDSD : IAudioDevice
    {
        private DirectSound device;
        private SecondarySoundBuffer buffer;
        private IntPtr handle;
        private bool firstRender;
        private bool isPaused;
        private int currWritePos;
        private int lastWritePos;
        private int renderPos;
        private int sampleGetPos;
        private int sampleSetPos;
        private short[] renderBuffer;
        private short[] sampleBuffer;

        public AudioDSD(IntPtr handle)
        {
            this.firstRender = true;
            this.handle = handle;
            this.device = new DirectSound();
            this.device.SetCooperativeLevel(this.handle, CooperativeLevel.Normal);

            var wave = new WaveFormat();
            wave.FormatTag = WaveFormatTag.Pcm;
            wave.SamplesPerSecond = 44100;
            wave.Channels = 1;
            wave.BitsPerSample = sizeof(short) * 8;
            wave.AverageBytesPerSecond = (wave.Channels * (wave.BitsPerSample / 8) * wave.SamplesPerSecond);
            wave.BlockAlignment = (short)(wave.Channels * (wave.BitsPerSample / 8));

            renderBuffer = new short[wave.SamplesPerSecond];
            sampleBuffer = new short[wave.SamplesPerSecond];

            buffer = new SecondarySoundBuffer(device, new SoundBufferDescription
            {
                Format = wave,
                SizeInBytes = wave.AverageBytesPerSecond,
                Flags = BufferFlags.ControlVolume | BufferFlags.ControlPan
            });
            buffer.Play(0, PlayFlags.Looping);
        }

        public void Dispose()
        {
            this.isPaused = true;

            if (buffer != null)
            {
                buffer.Dispose();
                buffer = null;
            }

            if (device != null)
            {
                device.Dispose();
                device = null;
            }
        }
        public void Play()
        {
            if (isPaused && buffer != null && !buffer.Disposed)
            {
                isPaused = false;
                buffer.Play(0, PlayFlags.Looping);
            }
        }
        public void Stop()
        {
            if (!isPaused)
            {
                if (buffer != null && !buffer.Disposed)
                {
                    buffer.Stop();
                    isPaused = true;
                }

                sampleGetPos = 0;
                sampleSetPos = 0;
            }
        }
        public void Render()
        {
            currWritePos = buffer.CurrentWritePosition;

            if (firstRender)
            {
                firstRender = false;
                renderPos = (currWritePos / sizeof(short)) + ((44100 * 3) / 60);
                lastWritePos = currWritePos;
            }

            int size = currWritePos - lastWritePos;

            if (size < 0)
                size += buffer.Format.AverageBytesPerSecond;

            if (size != 0)
            {
                for (int i = 0; i < size; i += sizeof(short))
                {
                    while (sampleGetPos >= sampleSetPos)
                        Nes.Apu.Render();
                        
                    renderBuffer[renderPos++ % renderBuffer.Length] = sampleBuffer[sampleGetPos++ % sampleBuffer.Length];
                }

                buffer.Write(renderBuffer, 0, LockFlags.None);
                lastWritePos = currWritePos;
            }
        }
        public void Sample(short sample)
        {
            sampleBuffer[sampleSetPos++ % sampleBuffer.Length] = sample;
        }
    }
}