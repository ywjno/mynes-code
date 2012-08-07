using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using myNES;
using myNES.Core;
using myNES.Core.IO.Output;

namespace myNES
{
    public partial class RendererFormSlimDX : Form
    {
        VideoD3D videoDevice;
        IAudioDevice audioDevice;
        public RendererFormSlimDX()
        {
            InitializeComponent();
            InitializeRendrers();
            Nes.EmuShutdown += new EventHandler(Nes_EmuShutdown);     
        }

        void Nes_EmuShutdown(object sender, EventArgs e)
        {
            this.Close();
        }
        void InitializeRendrers()
        {
            videoDevice = new VideoD3D(TimingInfo.NTSC, this);
            videoDevice.FullScreen = false;
            audioDevice = new AudioDSD(this.Handle);

            Nes.SetupOutput(TimingInfo.NTSC, videoDevice, audioDevice);
        }

        private void RendererFormSlimDX_FormClosing(object sender, FormClosingEventArgs e)
        {
            Nes.Shutdown();
        }
    }
}
