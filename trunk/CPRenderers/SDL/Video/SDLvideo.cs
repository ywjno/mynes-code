using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using MyNes.Core;
using MyNes.Core.IO.Output;
using MyNes.Renderers;
using SdlDotNet;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Core;
using SdlDotNet.Input;
using SdlDotNet.Graphics.Primitives;
using Console = MyNes.Core.Console;
namespace CPRenderers
{
    class SDLvideo : IVideoDevice
    {
        //make 2 surfaces for resizing and fullscreen
        private Surface screen;
        private Surface screen_back;
        private TextSprite fpsTextSprite;
        private TextSprite notTextSprite;
        private TextSprite soundRecordTextSprite;
        private Rectangle originalRect;
        private Rectangle destinationRect;
        private Size[] modes;
        private int windowW = 0;
        private int windowH = 0;
        private string romName = "";
        private IntPtr pointer;
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
        private bool keepAspectRatio;
        private bool showFps = false;
        private bool showNotifications = false;
        private bool isRendering = false;
        private int scanlines = 240;
        private string fontPath;
        private int textAppearanceFrames = 0;

        public SDLvideo(TimingInfo.System system, int stretchMultiply, string romName, bool ImmediateMode, bool cutLines,
            int AdapterIndex, int FullScreenModeIndex, bool openGL, bool FullScreen, bool showFps, bool showNotifications, bool keepAspectRatio)
        {
            initialized = false;
            canRender = false;
            // Get video modes
            string[] mds = System.IO.File.ReadAllLines(Path.Combine(RenderersCore.StartupFolder, "modes.txt"));
            System.Collections.Generic.List<Size> modesT = new System.Collections.Generic.List<Size>();
            foreach (string mo in mds)
            {
                string[] code = mo.Split(new string[] { " x " }, StringSplitOptions.None);
                modesT.Add(new Size(int.Parse(code[0]), int.Parse(code[1])));
            }
            modes = modesT.ToArray();

            fontPath = Path.Combine(RenderersCore.StartupFolder, "consola.ttf");

            this.system = system;
            this.romName = romName;
            this.ImmediateMode = ImmediateMode;
            this.cutLines = cutLines;
            this.AdapterIndex = AdapterIndex;
            this.FullScreenModeIndex = FullScreenModeIndex;
            this.FullScreen = FullScreen;
            this.stretchMultiply = stretchMultiply;
            this.openGL = openGL;
            this.showFps = showFps;
            this.showNotifications = showNotifications;
            this.keepAspectRatio = keepAspectRatio;
        }
        public void Launch()
        {
            Video.Initialize();
            Video.WindowIcon();
            Video.WindowCaption = romName + " - My Nes [SDL .NET]";
            Video.GLDoubleBufferEnabled = !ImmediateMode;
            windowW = 256 * stretchMultiply;
            if (cutLines)
            {
                if (system.Master == TimingInfo.NTSC.Master)
                {
                    scanlines = 224;
                    screen_back = new Surface(256, scanlines, 32);
                    originalRect = new Rectangle(0, 0, 256, scanlines);
                    firstToCut = 8;
                    windowH = scanlines * stretchMultiply;
                }
                else
                {
                    scanlines = 238;
                    screen_back = new Surface(256, scanlines, 32);
                    originalRect = new Rectangle(0, 0, 256, scanlines);
                    firstToCut = 1;
                    windowH = scanlines * stretchMultiply;
                }
            }
            else
            {
                scanlines = 240;
                screen_back = new Surface(256, scanlines, 32);
                originalRect = new Rectangle(0, 0, 256, scanlines);
                firstToCut = 0;
                windowH = scanlines * stretchMultiply;
            }
            pointer = screen_back.Pixels;
            // Create texts
            fpsTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(fontPath, 25));
            notTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(fontPath, 25));
            soundRecordTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(fontPath, 25));
            // set video mode.
            Resize(FullScreen, true, windowW, windowH);

            canRender = true;
            Nes.Pause = false;
            initialized = true;
        }
        public void Resize(bool fullScreen)
        {
            this.FullScreen = fullScreen;

            Resize(FullScreen, true, windowW, windowH);
        }
        public void Resize(bool fullScreen, bool resizable, int w, int h)
        {
            // setup rectangles
            if (FullScreen)
            {
                if (!keepAspectRatio)
                    destinationRect = new Rectangle(0, 0, modes[FullScreenModeIndex].Width, modes[FullScreenModeIndex].Height);
                else
                    destinationRect = GetRatioStretchRectangle(modes[FullScreenModeIndex].Width, modes[FullScreenModeIndex].Height);
            }
            else
            {
                // destinationRect = new Rectangle(0, 0, w, h);
                if (!keepAspectRatio)
                    destinationRect = new Rectangle(0, 0, w, h);
                else
                    destinationRect = GetRatioStretchRectangle(w, h);
            }
            fpsTextSprite.X = destinationRect.X + 2;
            fpsTextSprite.Y = 2;
            fpsTextSprite.Color = Color.White;
            fpsTextSprite.Text = "0/0";

            notTextSprite.X = destinationRect.X + 2;
            notTextSprite.Y = destinationRect.Height - 40;
            notTextSprite.Color = Color.White;
            notTextSprite.Text = " ";

            soundRecordTextSprite.X = destinationRect.X + 2;
            soundRecordTextSprite.Y = 22;
            soundRecordTextSprite.Color = Color.White;
            soundRecordTextSprite.Text = " ";
            // set video mode.
            if (fullScreen)
            {
                screen = Video.SetVideoMode(modes[FullScreenModeIndex].Width,
                   modes[FullScreenModeIndex].Height, 32, resizable, openGL, true);
            }
            else
            {
                screen = Video.SetVideoMode(w, h, 32, resizable, openGL, false);
            }
        }
        public void RenderFrame(int[][] ScreenBuffer)
        {
            if (Nes.Pause) return;
            if (!canRender) return;

            isRendering = true;
            int[] offScreen = new int[240 * 256];
            for (int y = 0; y < 240; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    offScreen[x + (y * 256)] = ScreenBuffer[y][x];
                }
            }
            Marshal.Copy(offScreen, 256 * firstToCut, pointer, 256 * scanlines);
            screen.Blit(screen_back.CreateStretchedSurface(destinationRect.Size), destinationRect.Location);
            if (showFps)
            {
                double fps = (1.0 / Nes.SpeedLimiter.ImmediateFrameTime);
                double pfps = (1.0 / Nes.SpeedLimiter.CurrentFrameTime);
                fpsTextSprite.Text = fps.ToString("F2") + "/" + pfps.ToString("F2");
                screen.Blit(fpsTextSprite);
            }
            if (showNotifications)
            {
                if (textAppearanceFrames > 0)
                {
                    textAppearanceFrames--;
                    screen.Blit(notTextSprite);
                }
            }
            if (Nes.AudioDevice.IsRecording)
            {
                soundRecordTextSprite.Text = "Recording [" + TimeSpan.FromSeconds(Nes.AudioDevice.RecordTime) + "]";
                screen.Blit(soundRecordTextSprite);
            }
            screen.Update();
            Video.Update();
            isRendering = false;
        }

        public void Begin()
        {

        }

        public void Shutdown()
        {
            canRender = false;
            screen.Dispose();
            screen_back.Dispose();
            fpsTextSprite.Dispose();
            notTextSprite.Dispose();
            Events.CloseVideo();
        }

        public void TakeSnapshot(string folder, string filename, string format, bool replace)
        {
            try
            {
                int j = 0;
                string path = "";
                if (!replace)
                {
                    path = Path.Combine(folder, filename + "_" + j +
                        RenderersCore.SettingsManager.Settings.Video_SnapshotFormat);
                    while (System.IO.File.Exists(path))
                    {
                        j++;
                        path = Path.Combine(folder, filename + "_" + j +
                        RenderersCore.SettingsManager.Settings.Video_SnapshotFormat);
                    }
                }
                else
                {
                    path = Path.Combine(folder, filename +
                           RenderersCore.SettingsManager.Settings.Video_SnapshotFormat);
                }
                DrawText("Snapshot taken. [" + Path.GetFileName(path) + "]", 120, Color.Green);
                screen_back.SaveBmp(path);
                Console.WriteLine("Snapshot taken");
            }
            catch(Exception ex)
            {
                DrawText(ex.Message, 120, Color.Red);
                File.WriteAllText(Path.Combine(RenderersCore.StartupFolder, "ERROR.txt"), ex.ToString());
            }
        }
        public bool Initialized
        { get { return initialized; } }
        public bool ShowFPS
        {
            get
            {
                return showFps;
            }
            set
            {
                showFps = value;
            }
        }
        public void DrawText(string text, int frames, Color color)
        {
            notTextSprite.Color = color;
            notTextSprite.Text = text;
            textAppearanceFrames = frames;
        }
        public bool ShowNotifications
        {
            get
            {
                return showNotifications;
            }
            set
            {
                showNotifications = value;
            }
        }
        public bool IsRendering
        {
            get { return isRendering; }
        }
        private Rectangle GetRatioStretchRectangle(int wWidth, int wHeight)
        {
            float pRatio = (float)wWidth / wHeight;
            float imRatio = (float)256 / scanlines;

            int w = 0;
            int h = 0;

            if (wWidth >= 256 && wHeight >= scanlines)
            {
                if (wWidth >= wHeight)
                {
                    //width image
                    if (256 >= scanlines && imRatio >= pRatio)
                    {
                        w = wWidth;
                        h = (int)(wWidth / imRatio);
                    }
                    else
                    {
                        h = wHeight;
                        w = (int)(wHeight * imRatio);
                    }
                }
                else
                {
                    if (256 < scanlines && imRatio < pRatio)
                    {
                        h = wHeight;
                        w = (int)(wHeight * imRatio);
                    }
                    else
                    {
                        w = wWidth;
                        h = (int)(wWidth / imRatio);
                    }
                }
            }
            else if (wWidth > 256 && wHeight < scanlines)
            {
                h = wHeight;
                w = (int)(wHeight * imRatio);
            }
            else if (wWidth < 256 && wHeight > scanlines)
            {
                w = wWidth;
                h = (int)(wWidth / imRatio);
            }
            else if (wWidth < 256 && wHeight < scanlines)
            {
                if (wWidth >= wHeight)
                {
                    //width image
                    if (256 >= scanlines && imRatio >= pRatio)
                    {
                        w = wWidth;
                        h = (int)(wWidth / imRatio);
                    }
                    else
                    {
                        h = wHeight;
                        w = (int)(wHeight * imRatio);
                    }
                }
                else
                {
                    if (256 < scanlines && imRatio < pRatio)
                    {
                        h = wHeight;
                        w = (int)(wHeight * imRatio);
                    }
                    else
                    {
                        w = wWidth;
                        h = (int)(wWidth / imRatio);
                    }
                }
            }
            return new Rectangle((wWidth - w) / 2, 0, w, h);
        }
    }
}
