using System;
using System.Runtime.InteropServices;
using MyNes.Core;
using MyNes.Core.IO.Output;
using SdlDotNet.Core;
using SdlDotNet.Audio;
using Console = MyNes.Core.Console;
namespace CPRenderers
{
    class SDLsound : IAudioDevice
    {
        AudioStream stream;
        AudioCallback callback;
        public SDLsound(bool On, int playbackFreq)
        {
            if (On)
            {
                try
                {
                    Mixer.Initialize();
                    callback = new AudioCallback(Unsigned16BigCallback);
                    stream = new AudioStream(playbackFreq, AudioFormat.Unsigned16Big,
                        SoundChannel.Mono, 0, callback, "My Nes Sound");
                    stream.Paused = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        void Unsigned16BigCallback(IntPtr userData, IntPtr stream, int len)
        {
            len /= 2;
            int bufPos = 0;
            short[] buff = new short[len];
            while (bufPos < len)
            {
                if (!Nes.Pause)
                {
                    buff[bufPos] = Nes.Apu.PullSample();
                    bufPos++;
                }
            }

            Marshal.Copy(buff, 0, stream, len);

            len = 0;
        }
        public void UpdateFrame()
        {

        }

        public void SubmitBuffer(byte[] samplesBuffer)
        {

        }

        public void Shutdown()
        {
            if (stream != null)
            {
                stream.Paused = true;
            }
            Events.CloseAudio();
        }

        public void Play()
        {
            if (stream != null)
            {
                if (stream.Paused)
                    stream.Paused = false;
            }
        }

        public void Stop()
        {
            if (stream != null)
            {
                if (!stream.Paused)
                    stream.Paused = true;
            }
            Events.Poll();
        }

        public bool IsRecording
        {
            get { return false; }
        }

        public void Record(string filePath)
        {

        }

        public void RecordStop()
        {

        }

        public int RecordTime
        {
            get { return 0; }
        }
    }
}
