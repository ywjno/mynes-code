using System;
using System.Runtime.InteropServices;
using MyNes.Core;
using MyNes.Core.IO.Output;
using MyNes.Renderers;
using SdlDotNet.Core;
using SdlDotNet.Audio;
using Console = MyNes.Core.Console;
namespace CPRenderers
{
    class SDLsound : IAudioDevice
    {
        private AudioStream stream;
        private AudioCallback callback;
        private WaveRecorder Recorder = new WaveRecorder();
        private double volume = 100;// 0 - 100
        private double multi = 0;
        private bool on;
        public SDLsound(bool On, int playbackFreq)
        {
            this.on = On;
            if (On)
            {
                try
                {
                    Mixer.Initialize();
                    //TODO: find another way to adjust volume.
                    volume = ((((100 * (3000 - RenderersCore.SettingsManager.Settings.Sound_Volume)) / 3000) - 200) * -1);
                    multi = volume / 100.00;

                    callback = new AudioCallback(Unsigned16BigCallback);
                    stream = new AudioStream(playbackFreq, AudioFormat.Unsigned16Big,
                        SoundChannel.Mono, 0, callback, "My Nes Sound");
                    stream.Paused = false;
                    Mixer.OpenAudio(stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        void Unsigned16BigCallback(IntPtr userData, IntPtr stream, int len)
        {
            if (on)
            {
                len /= 2;
                int bufPos = 0;
                short[] buff = new short[len];
                while (bufPos < len)
                {
                    if (!Nes.Pause)
                    {
                        double sample = Nes.Apu.PullSample();
                        buff[bufPos] = (short)(multi * sample);
                        //RECORD
                        if (Recorder.IsRecording)
                            Recorder.AddSample(buff[bufPos]);
                        bufPos++;
                    }
                }

                Marshal.Copy(buff, 0, stream, len);

                len = 0;
            }
        }
        public void UpdateFrame()
        {

        }

        public void SubmitBuffer(byte[] samplesBuffer)
        {

        }

        public void Shutdown()
        {
            if (on)
            {
                if (stream != null)
                {
                    stream.Paused = true;
                    stream.Flush();
                    stream.Dispose();
                }
                Events.CloseAudio();
                if (Recorder.IsRecording)
                    Recorder.Stop();
            }
        }

        public void Play()
        {
            if (on)
            {
                if (stream != null)
                {
                    if (stream.Paused)
                    { stream.Paused = false; }
                }
            }
        }

        public void Stop()
        {
            if (on)
            {
                if (stream != null)
                {
                    if (!stream.Paused)
                        stream.Paused = true;
                }
                Events.Poll();
            }
        }

        public bool IsRecording
        {
            get { if (on) return Recorder.IsRecording; return false; }
        }
        public void Record(string filePath)
        {
            if (on)
                Recorder.Record(filePath, RenderersCore.SettingsManager.Settings.Sound_PlaybackFreq);
        }
        public void RecordStop()
        {
            if (on)
            {
                Recorder.Stop();
                Nes.VideoDevice.DrawText("Record stopped.", 120, System.Drawing.Color.Green);
            }
        }
        public int RecordTime
        {
            get
            {
                if (on) return Recorder.Time;

                return 0;
            }
        }

        public bool IsPlaying
        {
            get
            {
                if (on)
                { return !stream.Paused; }
                return false;
            }
        }
        public void ResetBuffer()
        {
            Nes.Apu.ResetBuffer();
        }
    }
}
