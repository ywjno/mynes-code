using System;
using System.Drawing;
using System.Windows.Forms;
using myNES.Core;

namespace myNES
{
    public partial class RendererFormSlimDX : Form
    {
        private AudioDSD audioDevice;
        private VideoD3D videoDevice;

        public RendererFormSlimDX()
        {
            InitializeComponent();
            InitializeRenderers();

            base.ClientSize = new Size(256, 224);

            Nes.EmuShutdown += new EventHandler(Nes_EmuShutdown);
        }

        void Nes_EmuShutdown(object sender, EventArgs e)
        {
            this.Close();
        }
        void InitializeRenderers()
        {
            videoDevice = new VideoD3D(TimingInfo.NTSC, this);
            videoDevice.Initialize();

            audioDevice = new AudioDSD(this.Handle);

            // TODO: settings for input
            InputManager inputManager = new InputManager(this.Handle);

            Joypad joy1 = new Joypad(inputManager);
            Joypad joy2 = new Joypad(inputManager);

            joy1.A.Input = "Keyboard.X";
            joy1.B.Input = "Keyboard.Z";
            joy1.Down.Input = "Keyboard.DownArrow";
            joy1.Left.Input = "Keyboard.LeftArrow";
            joy1.Right.Input = "Keyboard.RightArrow";
            joy1.Up.Input = "Keyboard.UpArrow";
            joy1.Select.Input = "Keyboard.C";
            joy1.Start.Input = "Keyboard.V";

            Nes.SetupOutput(TimingInfo.NTSC, videoDevice, audioDevice);
            Nes.SetupLimiter(new Timer());
            Nes.SetupInput(inputManager, joy1, joy2);
        }

        private void RendererFormSlimDX_FormClosing(object sender, FormClosingEventArgs e)
        {
            Nes.Shutdown();
        }
    }
}