/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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
using MyNes.Core;
using MyNes.Core.IO;
using SlimDX;
using SlimDX.Direct3D9;
using Console = MyNes.Core.Console;
namespace MyNes.Renderers
{
    unsafe class SlimDXVideo : IVideoDevice, IDisposable
    {
        private System.Windows.Forms.Control surface_control;
        private Direct3D direct3D = new Direct3D();

        private int linesToSkip = 8;
        private int scanlines;
        private Rectangle originalRect;
        private Rectangle destinationRect;
        private DisplayMode currentMode;
        private PresentParameters presentParams;
        private Device displayDevice;
        private Format displayFormat;
        private Surface bufferedSurface;
        private Surface frontSurface;
        private Sprite displaySprite;
        private bool canRender;
        private int bufferSize;
        private bool initialized;
        private bool disposed;
        private bool isRendering;
        private bool deviceLost;
        // FPS and Notification
        private SlimDX.Direct3D9.Font font;
        private int notification_y = 0;
        private int notification_x = 0;
        private int notification_appearance;
        private string notification_text;
        private Color notification_color = Color.White;
        private int fullscreen_mode_index = 0;
        // Settings
        private TextureFilter filter = TextureFilter.None;
        private bool cut_lines = true;
        private bool fullScreen = false;
        private bool immediate_mode = true;
        private bool hardware_vertex_processing = false;
        private bool keep_aspect_ratio;
        private bool show_fps;
        private bool show_notification;

        public SlimDXVideo(System.Windows.Forms.Control surface_control)
        {
            this.surface_control = surface_control;
            LoadSettings();
        }

        private DisplayMode FindSupportedMode()
        {
            return direct3D.Adapters[0].GetDisplayModes(Format.X8R8G8B8)[fullscreen_mode_index];
        }
        public override void Initialize()
        {
            if (cut_lines)
            {
                if (NesCore.TV == TVSystem.NTSC)
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
            currentMode = direct3D.Adapters[0].CurrentDisplayMode;
            Console.WriteLine("SlimDX: Initializing Direct 3d video device ...");

            try
            {
                if (!fullScreen)
                {
                    presentParams = new PresentParameters();
                    presentParams.BackBufferWidth = surface_control.Width;
                    presentParams.BackBufferCount = 1;
                    presentParams.BackBufferHeight = surface_control.Height;

                    presentParams.BackBufferFormat = Format.A8R8G8B8;
                    presentParams.Windowed = true;
                    presentParams.SwapEffect = SwapEffect.Discard;
                    presentParams.Multisample = MultisampleType.None;
                    if (immediate_mode)
                        presentParams.PresentationInterval = PresentInterval.Immediate;
                    else
                        presentParams.PresentationInterval = PresentInterval.Default;
                    displayFormat = currentMode.Format;
                    displayDevice = new Device(direct3D, 0, DeviceType.Hardware, surface_control.Handle,
                    hardware_vertex_processing ? CreateFlags.HardwareVertexProcessing : CreateFlags.SoftwareVertexProcessing,
                    presentParams);
                    bufferSize = (256 * scanlines * 4);
                    font = new SlimDX.Direct3D9.Font(displayDevice,
                        new System.Drawing.Font("Tahoma", (8 * surface_control.Height) / scanlines, FontStyle.Bold));
                    CreateDisplayObjects(displayDevice);
                    initialized = true;
                    disposed = false;
                    if (keep_aspect_ratio)
                        destinationRect = GetRatioStretchRectangle(surface_control.Width, surface_control.Height);
                    else
                        destinationRect = new Rectangle(0, 0, surface_control.Width, surface_control.Height);
                    notification_x = destinationRect.X + 2;
                    notification_y = surface_control.Height - ((surface_control.Height * 25) / scanlines);
                    canRender = true;
                }
                else
                {
                    DisplayMode mode = this.FindSupportedMode();
                    presentParams = new PresentParameters();
                    presentParams.BackBufferFormat = mode.Format;
                    presentParams.BackBufferCount = 1;
                    presentParams.BackBufferWidth = mode.Width;
                    presentParams.BackBufferHeight = mode.Height;
                    presentParams.FullScreenRefreshRateInHertz = mode.RefreshRate;
                    presentParams.Windowed = false;
                    presentParams.SwapEffect = SwapEffect.Discard;
                    presentParams.Multisample = MultisampleType.None;
                    if (immediate_mode)
                        presentParams.PresentationInterval = PresentInterval.Immediate;
                    else
                        presentParams.PresentationInterval = PresentInterval.Default;
                    displayFormat = mode.Format;
                    displayDevice = new Device(direct3D, 0, DeviceType.Hardware, surface_control.Parent.Handle,
                        hardware_vertex_processing ? CreateFlags.HardwareVertexProcessing : CreateFlags.SoftwareVertexProcessing,
                        presentParams);
                    displayDevice.ShowCursor = false;
                    bufferSize = (256 * scanlines) * 4;

                    font = new SlimDX.Direct3D9.Font(displayDevice, new System.Drawing.Font("Tahoma", (8 * mode.Height) / scanlines,
                        FontStyle.Bold));
                    CreateDisplayObjects(displayDevice);
                    initialized = true;
                    disposed = false;
                    if (keep_aspect_ratio)
                        destinationRect = GetRatioStretchRectangle(mode.Width, mode.Height);
                    else
                        destinationRect = new Rectangle(0, 0, mode.Width, mode.Height);
                    notification_x = destinationRect.X + 2;
                    notification_y = mode.Height - ((mode.Height * 25) / scanlines);
                    canRender = true;
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
        public override void RenderFrame(int[] screen)
        {
            if (canRender && !disposed && initialized)
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

                    rect.Data.WriteRange(screen, linesToSkip * 256, 256 * scanlines);

                    rect.Data.Close();
                    bufferedSurface.UnlockRectangle();
                    // copy the surface data to the device one with stretch. 
                    if (canRender && !disposed)
                    {
                        if (keep_aspect_ratio)
                            displayDevice.StretchRectangle(bufferedSurface, originalRect, frontSurface, destinationRect, filter);
                        else
                            displayDevice.StretchRectangle(bufferedSurface, frontSurface, filter);
                    }


                    displayDevice.BeginScene();

                    displaySprite.Begin(SpriteFlags.AlphaBlend);
                    // draw debug things here... comment this when done.
                    //font.DrawString(displaySprite, resss.Description, 2, 200, Color.White);
                    // fps
                    if (show_fps)
                    {
                        double fps = (1.0 / NesCore.SpeedLimiter.ImmediateFrameTime);
                        double pfps = (1.0 / NesCore.SpeedLimiter.CurrentFrameTime);
                        font.DrawString(displaySprite, fps.ToString("F2") + "/" + pfps.ToString("F2"),
                            notification_x, 2, Color.White);
                    }
                    // draw notification text
                    if (show_notification)
                    {
                        if (notification_appearance > 0)
                        {
                            notification_appearance--;

                            // Draw the string
                            font.DrawString(displaySprite, notification_text, notification_x, notification_y, notification_color);

                        }
                        // draw recording
                        if (NesCore.AudioOutput != null)
                        {
                            if (NesCore.AudioOutput.IsRecording)
                            {
                                font.DrawString(displaySprite, "Recording [" + TimeSpan.FromSeconds(NesCore.AudioOutput.RecordTime) + "]",
                                    notification_x, 13, Color.White);
                            }
                        }
                    }

                    displaySprite.End();

                    displayDevice.EndScene();
                    displayDevice.Present();
                }
                isRendering = false;
            }
        }
        public override void TakeSnapshot(string folder, string filename, string format, bool replace)
        {
            NesCore.PAUSED = true;
            while (isRendering) { }//wait until the frame is finished
            // make sure the file is not replaced
            string path = "";

            if (!replace)
            {
                int j = 0;
                path = folder + "\\" + filename + "_" + j + format;
                while (System.IO.File.Exists(path))
                {
                    j++;
                    path = folder + "\\" + filename + "_" + j + format;
                }
            }
            else
            {
                path = folder + "\\" + filename + format;
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
            DrawNotification("Snapshot taken. [" + System.IO.Path.GetFileName(path) + "]", 120, Color.Green.ToArgb());
            Console.WriteLine("Snapshot taken");
            NesCore.PAUSED = false;
        }
        public override void ShutDown()
        {
            this.Dispose();
        }
        public override void DrawNotification(string text, int frames, int color)
        {
            notification_color = Color.FromArgb(color);
            notification_text = text;
            notification_appearance = frames;
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

        public void Dispose()
        {
            if (displayDevice != null)
            {
                displayDevice.Dispose();
            }

            this.DisposeDisplayObjects();

            disposed = true;
        }
        public bool Disposed
        { get { return disposed; } }
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

        public void LoadSettings()
        {
            fullscreen_mode_index = Program.Settings.VideoFullscreenResIndex;
            cut_lines = Program.Settings.VideoCutLines;
            fullScreen = Program.Settings.VideoLaunchFullscreen;
            immediate_mode = Program.Settings.VideoImmediateMode;
            hardware_vertex_processing = Program.Settings.VideoDirect9IsHardwareVertexProcessing;
            filter = (TextureFilter)Program.Settings.VideoDirect9Filter;
            keep_aspect_ratio = Program.Settings.VideoKeepAspectRatio;
            show_fps = Program.Settings.VideoShowFPS;
            show_notification = Program.Settings.VideoShowNotifications;
        }

        public override void ResizeBegin()
        {
            NesCore.PAUSED = true;
            while (isRendering) { }// Wait to finish frame if it is rendering !
        }
        public override void ResizeEnd()
        {
            //shutdown renderer
            ShutDown();
            //re-Initialize
            Initialize();

            NesCore.VideoOutput = this;
            NesCore.PAUSED = false;
        }
        public override void SwitchFullscreen()
        {
            NesCore.PAUSED = true;
            while (isRendering) { }// Wait to finish frame if it is rendering !
            fullScreen = !fullScreen;
            //shutdown renderer
            ShutDown();
            //re-Initialize
            Initialize();

            NesCore.VideoOutput = this;
            NesCore.PAUSED = false;
        }
    }
}
