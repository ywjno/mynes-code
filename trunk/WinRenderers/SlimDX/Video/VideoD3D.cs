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
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MyNes.Core;
using MyNes.Core.IO.Output;
using MyNes.Renderers;
using SlimDX;
using SlimDX.Direct3D9;
using Console = MyNes.Core.Console;
using MyNes.WinRenderers.Debug;

namespace MyNes.WinRenderers
{
    public unsafe class VideoD3D : IVideoDevice, IDisposable
    {
        private const int BUFFER_SIZE_NTSC = (256 * 224) * sizeof(int);
        private const int BUFFER_SIZE_PALB = (256 * 240) * sizeof(int);

        private TimingInfo.System system;
        private Direct3D Direct3D = new Direct3D();
        private DisplayMode currentMode;
        private DisplayMode mode;
        private Control control;
        private Device displayDevice;
        private Format displayFormat;
        private PresentParameters presentParams;
        private Surface bufferedSurface;
        private Surface frontSurface;
        private Rectangle originalRect;
        private Rectangle destinationRect;
        private Sprite displaySprite;
        private Color4 dcolor = new Color4(Color.White);
        private TextureFilter filter = TextureFilter.None;


        public SlimDX.Direct3D9.Font font;
        private bool canRender = true;
        public bool cutLines = true;
        private bool deviceLost;
        private bool disposed;
        private bool fullScreen;
        private bool initialized;
        public bool ImmediateMode = true;
        private bool isRendering;
        private int bufferSize;
        private int linesToSkip;
        public int FullScreenModeIndex = 0;
        public int AdapterIndex = 0;
        private int scanlines = 240;
        private bool drawFPS = false;
        private string textToDraw = "";
        private int textAppearanceFrames = 0;
        private bool drawText = true;
        private Color textColor = Color.White;
        private int notTextY = 200;
        private int textX = 2;
        private bool isHardwareVertexProcessing = false;

        private bool keepAspectRatio = true;

        public VideoD3D(TimingInfo.System system, Control control)
        {
            this.control = control;
            this.system = system;
            ConsoleCommands.AddCommand(new videoCommands(this));
            ApplySettings();
        }

        private DisplayMode FindSupportedMode()
        {
            return Direct3D.Adapters[AdapterIndex].GetDisplayModes(Format.X8R8G8B8)[FullScreenModeIndex];
        }
        public void ApplySettings()
        {
            Console.WriteLine("SlimDX: loading video settings ...");
            filter = SlimDXRenderer.Settings.Video_TextureFilter;
            Console.WriteLine("SlimDX: texture filter = " + filter.ToString());
            isHardwareVertexProcessing = SlimDXRenderer.Settings.Video_IsHardwareVertexProcessing;
            Console.WriteLine("SlimDX: vertex processing = " + (isHardwareVertexProcessing ? "Hardware" : "Software"));
            Console.WriteLine("SlimDX: video settings loaded successfully.");
        }
        public void Initialize()
        {
            if (cutLines)
            {
                if (system.Master == TimingInfo.NTSC.Master)
                {
                    linesToSkip = 8;
                    scanlines = 224;
                }
                else
                {
                    linesToSkip = 1;
                    scanlines = 238;
                }
            }
            else
            {
                linesToSkip = 0;
                scanlines = 240;
            }
            originalRect = new Rectangle(0, 0, 256, scanlines);
            currentMode = Direct3D.Adapters[0].CurrentDisplayMode;
            Console.WriteLine("SlimDX: Initializing Direct 3d video device ...");

            try
            {
                if (!fullScreen)
                {
                    presentParams = new PresentParameters();
                    presentParams.BackBufferWidth = 256;
                    presentParams.BackBufferHeight = scanlines;
                    presentParams.BackBufferFormat = Format.A8R8G8B8;
                    presentParams.Windowed = true;
                    presentParams.SwapEffect = SwapEffect.Discard;
                    presentParams.Multisample = MultisampleType.None;
                    if (ImmediateMode)
                        presentParams.PresentationInterval = PresentInterval.Immediate;
                    else
                        presentParams.PresentationInterval = PresentInterval.Default;
                    displayFormat = currentMode.Format;
                    displayDevice = new Device(Direct3D, 0, DeviceType.Hardware, control.Handle,
                      isHardwareVertexProcessing ? CreateFlags.HardwareVertexProcessing : CreateFlags.SoftwareVertexProcessing,
                      presentParams);
                    bufferSize = (256 * scanlines * 4);
                    font = new SlimDX.Direct3D9.Font(displayDevice, new System.Drawing.Font("Tahoma", 8, FontStyle.Bold));
                    CreateDisplayObjects(displayDevice);
                    initialized = true;
                    disposed = false;
                    destinationRect = new Rectangle(0, 0, 256, scanlines);
                    notTextY = 200;
                    textX = 2;
                }
                else
                {
                    mode = this.FindSupportedMode();
                    presentParams = new PresentParameters();
                    presentParams.BackBufferFormat = mode.Format;
                    presentParams.BackBufferCount = 1;
                    presentParams.BackBufferWidth = mode.Width;
                    presentParams.BackBufferHeight = mode.Height;
                    presentParams.FullScreenRefreshRateInHertz = mode.RefreshRate;
                    presentParams.Windowed = false;
                    presentParams.SwapEffect = SwapEffect.Discard;
                    presentParams.Multisample = MultisampleType.None;
                    if (ImmediateMode)
                        presentParams.PresentationInterval = PresentInterval.Immediate;
                    else
                        presentParams.PresentationInterval = PresentInterval.Default;
                    displayFormat = mode.Format;
                    displayDevice = new Device(Direct3D, 0, DeviceType.Hardware, control.Handle,
                        isHardwareVertexProcessing ? CreateFlags.HardwareVertexProcessing : CreateFlags.SoftwareVertexProcessing,
                        presentParams);
                    displayDevice.ShowCursor = false;
                    bufferSize = (256 * scanlines) * 4;
                    notTextY = mode.Height - ((mode.Height * 40) / 240);
                    font = new SlimDX.Direct3D9.Font(displayDevice, new System.Drawing.Font("Tahoma", (8 * mode.Height) / 240,
                        FontStyle.Bold));
                    CreateDisplayObjects(displayDevice);
                    initialized = true;
                    disposed = false;
                    destinationRect = GetRatioStretchRectangle(mode.Width, mode.Height);
                    textX = destinationRect.X + 2;
                }

                Console.WriteLine("SlimDX: Direct 3d video device initialized.", DebugCode.Good);
            }
            catch (Exception e)
            {
                initialized = false;
                Console.WriteLine("SlimDX: Failed to initialize the Direct 3d video device:", DebugCode.Error);
                Console.WriteLine(e.Message, DebugCode.Error);
            }
        }
        private void CreateDisplayObjects(Device device)
        {
            displaySprite = new Sprite(device);
            bufferedSurface = Surface.CreateRenderTarget(device, 256, scanlines, Format.A8R8G8B8,
                MultisampleType.None, 0, true);

            frontSurface = device.GetBackBuffer(0, 0);
        }
        private void DisposeDisplayObjects()
        {
            Console.WriteLine("SlimDX: shutdown video ...");
            if (displaySprite != null)
                displaySprite.Dispose();

            if (bufferedSurface != null)
                bufferedSurface.Dispose();

            if (frontSurface != null)
                frontSurface.Dispose();

            if (font != null)
                font.Dispose();
            Console.WriteLine("SlimDX: video shutdown done.", DebugCode.Good);
        }
        private void ResetDirect3D()
        {
            if (!initialized)
                return;

            DisposeDisplayObjects();

            try
            {
                displayDevice.Reset(presentParams);
                CreateDisplayObjects(displayDevice);
            }
            catch
            {
                displayDevice.Dispose();
                Initialize();
            }
        }

        public void Begin()
        {
            if (canRender)
                isRendering = true;
        }
        public void Dispose()
        {
            if (displayDevice != null)
            {
                displayDevice.Dispose();
            }

            this.DisposeDisplayObjects();

            disposed = true;
        }

        public void RenderFrame(int[][] screen)
        {
            if (control != null && canRender && !disposed && initialized)
            {
                isRendering = true;
                var result = displayDevice.TestCooperativeLevel();

                switch (result.Code)
                {
                    case -2005530510:
                    case -2005530520: deviceLost = true; break;
                    case -2005530519: deviceLost = false; ResetDirect3D(); break;
                }

                if (!deviceLost)
                {
                    var rect = bufferedSurface.LockRectangle(LockFlags.Discard);

                    for (int i = linesToSkip; i < 240 - linesToSkip; i++)
                        rect.Data.WriteRange(screen[i], 0, screen[i].Length);

                    rect.Data.Close();
                    bufferedSurface.UnlockRectangle();
                    // copy the surface data to the device one with stretch. 
                    if (canRender && !disposed)
                    {
                        if (fullScreen)
                        {
                            if (keepAspectRatio)
                                displayDevice.StretchRectangle(bufferedSurface, originalRect, frontSurface, destinationRect, filter);
                            else
                                displayDevice.StretchRectangle(bufferedSurface, frontSurface, filter);
                        }
                        else
                            displayDevice.StretchRectangle(bufferedSurface, frontSurface, filter);
                    }


                    displayDevice.BeginScene();

                    displaySprite.Begin(SpriteFlags.AlphaBlend);
                    // draw debug things here... comment this when done.
                    //font.DrawString(displaySprite, resss.Description, 2, 200, Color.White);
                    // fps
                    if (drawFPS)
                    {
                        double fps = (1.0 / Nes.SpeedLimiter.ImmediateFrameTime);
                        double pfps = (1.0 / Nes.SpeedLimiter.CurrentFrameTime);
                        font.DrawString(displaySprite, fps.ToString("F2") + "/" + pfps.ToString("F2"), textX, 2, Color.White);
                    }
                    // draw notification text
                    if (drawText)
                    {
                        if (textAppearanceFrames > 0)
                        {
                            textAppearanceFrames--;
                            font.DrawString(displaySprite, textToDraw, textX, notTextY, textColor);
                        }
                    }
                    displaySprite.End();

                    displayDevice.EndScene();
                    displayDevice.Present();
                }
                isRendering = false;
            }
        }
        public void TakeSnapshot(string folder, string filename, string format, bool replace)
        {
            Nes.TogglePause(true);
            while (isRendering) { }//wait until the frame is finished
            // make sure the file is not replaced
            string path = "";
            if (!replace)
            {
                int j = 0;
                path = folder + "\\" + filename + "_" + j +
                    RenderersCore.SettingsManager.Settings.Video_SnapshotFormat;
                while (System.IO.File.Exists(path))
                {
                    j++;
                    path = folder + "\\" + filename + "_" + j +
                    RenderersCore.SettingsManager.Settings.Video_SnapshotFormat;
                }
            }
            else
            {
                path = folder + "\\" + filename +
                     RenderersCore.SettingsManager.Settings.Video_SnapshotFormat;
            }
            // get image data as bitmap
            Bitmap bitmap = new Bitmap(256, scanlines);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, 256, scanlines), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            int* pointer = (int*)bitmapData.Scan0;

            var rect = bufferedSurface.LockRectangle(LockFlags.Discard);
            byte[] data = new byte[bufferSize];
            rect.Data.Read(data, 0, bufferSize);
            rect.Data.Close();
            bufferedSurface.UnlockRectangle();

            for (int i = 0; i < data.Length; i += 4)
            {
                *pointer++ =
                    (data[i + 3] << 0x18) | // A
                    (data[i + 2] << 0x10) | // R
                    (data[i + 1] << 0x08) | // G
                    (data[i + 0] << 0x00);  // B
            }

            bitmap.UnlockBits(bitmapData);

            switch (format)
            {
                case ".bmp": bitmap.Save(path, ImageFormat.Bmp); break;
                case ".gif": bitmap.Save(path, ImageFormat.Gif); break;
                case ".jpg": bitmap.Save(path, ImageFormat.Jpeg); break;
                case ".png": bitmap.Save(path, ImageFormat.Png); break;
                case ".tiff": bitmap.Save(path, ImageFormat.Tiff); break;
                case ".emf": bitmap.Save(path, ImageFormat.Emf); break;
                case ".wmf": bitmap.Save(path, ImageFormat.Wmf); break;
                case ".exif": bitmap.Save(path, ImageFormat.Exif); break;
            }

            canRender = true;
            DrawText("Snapshot taken. [" + System.IO.Path.GetFileName(path) + "]", 120, Color.Green);
            Console.WriteLine("Snapshot taken");
            Nes.TogglePause(false);
        }
        public void Shutdown()
        {
            this.Dispose();
        }
        public bool Disposed { get { return disposed; } }
        public bool FullScreen
        {
            get { return fullScreen; }
            set { fullScreen = value; }
        }
        public bool Initialized
        { get { return initialized; } }
        public bool ShowFPS
        {
            get
            {
                return drawFPS;
            }
            set
            {
                drawFPS = value;
            }
        }
        public void DrawText(string text, int frames, Color color)
        {
            textColor = color;
            textToDraw = text;
            textAppearanceFrames = frames;
        }
        public bool ShowNotifications
        {
            get
            {
                return drawText;
            }
            set
            {
                drawText = value;
            }
        }
        public bool IsRendering
        {
            get { return isRendering; }
        }
        public bool KeepAspectRatio
        { get { return keepAspectRatio; } set { keepAspectRatio = value; } }
        public void SwitchFilter(TextureFilter newFilter)
        {
            this.filter = newFilter;
        }
        private Rectangle GetRatioStretchRectangle(int windowWidth, int windowHeight)
        {
            float pRatio = (float)windowWidth / windowHeight;
            float imRatio = (float)256 / scanlines;

            int w = 0;
            int h = 0;

            if (windowWidth >= 256 && windowHeight >= scanlines)
            {
                if (windowWidth >= windowHeight)
                {
                    //width image
                    if (256 >= scanlines && imRatio >= pRatio)
                    {
                        w = windowWidth;
                        h = (int)(windowWidth / imRatio);
                    }
                    else
                    {
                        h = windowHeight;
                        w = (int)(windowHeight * imRatio);
                    }
                }
                else
                {
                    if (256 < scanlines && imRatio < pRatio)
                    {
                        h = windowHeight;
                        w = (int)(windowHeight * imRatio);
                    }
                    else
                    {
                        w = windowWidth;
                        h = (int)(windowWidth / imRatio);
                    }
                }
            }
            else if (windowWidth > 256 && windowHeight < scanlines)
            {
                h = windowHeight;
                w = (int)(windowHeight * imRatio);
            }
            else if (windowWidth < 256 && windowHeight > scanlines)
            {
                w = windowWidth;
                h = (int)(windowWidth / imRatio);
            }
            else if (windowWidth < 256 && windowHeight < scanlines)
            {
                if (windowWidth >= windowHeight)
                {
                    //width image
                    if (256 >= scanlines && imRatio >= pRatio)
                    {
                        w = windowWidth;
                        h = (int)(windowWidth / imRatio);
                    }
                    else
                    {
                        h = windowHeight;
                        w = (int)(windowHeight * imRatio);
                    }
                }
                else
                {
                    if (256 < scanlines && imRatio < pRatio)
                    {
                        h = windowHeight;
                        w = (int)(windowHeight * imRatio);
                    }
                    else
                    {
                        w = windowWidth;
                        h = (int)(windowWidth / imRatio);
                    }
                }
            }
            return new Rectangle((windowWidth - w) / 2, 0, w, h);
        }
    }
}