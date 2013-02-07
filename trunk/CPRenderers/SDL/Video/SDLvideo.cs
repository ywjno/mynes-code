using System;
using System.Drawing;
using MyNes.Core;
using MyNes.Core.IO.Output;
using SdlDotNet;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Core;
using SdlDotNet.Input;
using SdlDotNet.Graphics.Primitives;
using Console = MyNes.Core.Console;
namespace CPRenderers
{
    unsafe class SDLvideo : IVideoDevice
    {
        //make 2 surfaces for resizing and fullscreen
        private Surface screen;
        private Surface screen_back;
        private int windowW = 0;
        private int windowH = 0;
        private string romName = "";
        private int* pointer;
        private int firstToCut = 0;
        private TimingInfo.System system;
        private bool ImmediateMode = false;
        private bool cutLines = true;
        private int AdapterIndex = 0;
        private int FullScreenModeIndex = 0;
        public bool FullScreen = false;
        private int stretchMultiply = 2;
        private bool canRender = false;
        private bool openGL = false;
        private bool initialized = false;

        public SDLvideo(TimingInfo.System system, int stretchMultiply, string romName, bool ImmediateMode, bool cutLines,
            int AdapterIndex, int FullScreenModeIndex, bool openGL, bool FullScreen)
        {
            initialized = false;
            canRender = false;
            this.system = system;
            this.romName = romName;
            this.ImmediateMode = ImmediateMode;
            this.cutLines = cutLines;
            this.AdapterIndex = AdapterIndex;
            this.FullScreenModeIndex = FullScreenModeIndex;
            this.FullScreen = FullScreen;
            this.stretchMultiply = stretchMultiply;
            this.openGL = openGL;
        }
        public void Launch()
        {
            Video.Initialize();
            Video.WindowIcon();
            Video.WindowCaption = romName + " - My Nes [SDL .NET]";
            windowW = 256 * stretchMultiply;
            if (cutLines)
            {
                if (system.Master == TimingInfo.NTSC.Master)
                {
                    screen_back = new Surface(256, 224, 32);
                    firstToCut = 8;
                    windowH = 224 * stretchMultiply;
                }
                else
                {
                    screen_back = new Surface(256, 238, 32);
                    firstToCut = 1;
                    windowH = 238 * stretchMultiply;
                }
            }
            else
            {
                screen_back = new Surface(256, 240, 32);
                firstToCut = 0;
                windowH = 240 * stretchMultiply;
            }
            Resize(FullScreen, true, windowW, windowH);
            //screen.AlphaBlending = false;
            // screen_back.AlphaBlending = false;
            pointer = (int*)screen_back.Pixels;
            canRender = true;
            Nes.Pause = false;
        }
        public void Resize(bool fullScreen)
        {
            this.FullScreen = fullScreen;
            Resize(FullScreen, true, windowW, windowH);
        }
        public void Resize(bool fullScreen, bool resizable, int w, int h)
        {
            if (fullScreen)
            {
                Size[] modes = Video.ListModes();
                screen = Video.SetVideoMode(modes[FullScreenModeIndex].Width,
                   modes[FullScreenModeIndex].Width, 32, resizable, openGL, true);
            }
            else
            {
                screen = Video.SetVideoMode(w, h, 32, resizable, openGL, false);
            }
            initialized = true;
        }
        public void RenderFrame(int[][] ScreenBuffer)
        {
            if (Nes.Pause) return;
            if (!canRender) return;
            for (int y = firstToCut; y < 240 - firstToCut; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    pointer[x + ((y - firstToCut) * 256)] = ScreenBuffer[y][x];
                }
            }
            screen.Blit(screen_back.CreateStretchedSurface(screen.Size));

            screen.Update();
        }

        public void Begin()
        {

        }

        public void Shutdown()
        {
            Events.CloseVideo();
        }

        public void TakeSnapshot(string path, string format)
        {
            screen_back.SaveBmp(path);
            Console.WriteLine("Snapshot taken");
        }
        public bool Initialized
        { get { return initialized; } }
    }
}
