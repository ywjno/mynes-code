using System;
using System.Windows.Forms;
using myNES.Core.IO.Output;
using myNES.Core;
using SlimDX.DirectSound;
using SlimDX.Multimedia;
using Console = myNES.Core.Console;
namespace myNES
{
    public class AudioDSD : IAudioDevice
    {
        public AudioDSD(IntPtr handle)
        {
            _Handle = handle;
        }
        IntPtr _Handle;
        public Control _Control;
        //slimdx
        public DirectSound _SoundDevice;
        public SecondarySoundBuffer buffer;

        bool IsPaused;
        public bool IsRendering = false;
        bool _FirstRender = true;
        public byte[] DATA = new byte[44100];
        int BufferSize = 44100;
        int W_Pos = 0;//Write position
        int L_Pos = 0;//Last position
        int D_Pos = 0;//Data position

        public void Initialize(IntPtr handle)
        {
            _Handle = handle;
            //Create the device
            Console.WriteLine("Initializing SlimDX DirectSound for APU....");
            _SoundDevice = new DirectSound();
            _SoundDevice.SetCooperativeLevel(_Handle, CooperativeLevel.Normal);
            //Create the wav format
            WaveFormat wav = new WaveFormat();
            wav.FormatTag = WaveFormatTag.Pcm;
            wav.SamplesPerSecond = 44100;
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
            //buffer
            DATA = new byte[BufferSize];
            buffer = new SecondarySoundBuffer(_SoundDevice, des);
            buffer.Play(0, PlayFlags.Looping);
            Console.WriteLine("SlimDX DirectSound initialized OK.");
        }
        public void UpdateBuffer()//old way
        {
            if (buffer == null | buffer.Disposed)
            { IsRendering = false; return; }
            W_Pos = buffer.CurrentWritePosition;
            if (_FirstRender)
            {
                _FirstRender = false;
                D_Pos = buffer.CurrentWritePosition + 0x1000;
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
                    short OUT = 0;
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
        public void UpdateFrame()
        {

        }

        public void Play()
        {
            if (!IsPaused)
            { return; }
            if (buffer != null && !buffer.Disposed & !IsRendering)
            {
                IsPaused = false;
                try//Sometimes this line thorws an exception for unkown reason !!
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
            IsPaused = true;
            while (IsRendering)
            { }
            if (buffer != null)
            {
                buffer.Stop();
                buffer.Dispose();
            }
            if (_SoundDevice != null)
                _SoundDevice.Dispose();
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
    }
}