/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
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
using SlimDX;
using SlimDX.Direct3D9;
using Console = MyNes.Core.Console;

namespace MyNes
{
    public unsafe class VideoD3D : IVideoDevice, IDisposable
    {
        private const int BUFFER_SIZE_NTSC = (256 * 224) * sizeof(int);
        private const int BUFFER_SIZE_PALB = (256 * 240) * sizeof(int);

        private DisplayMode currentMode;
        private DisplayMode mode;
        private Control control;
        private Device displayDevice;
        private Format displayFormat;
        private PresentParameters presentParams;
        private Rectangle displayRect;
        private Texture backBuffer;
        private Texture nesDisplay;
        private TimingInfo.System system;
        private Sprite displaySprite;
        private Vector3 position;
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
        private Direct3D Direct3D = new Direct3D();

        public VideoD3D(TimingInfo.System system, Control control)
        {
            this.control = control;
            this.system = system;
        }

        private DisplayMode FindSupportedMode()
        {
            return Direct3D.Adapters[AdapterIndex].GetDisplayModes(Format.X8R8G8B8)[FullScreenModeIndex];
        }
        private void CreateDisplayObjects(Device device)
        {
            displaySprite = new Sprite(device);
            backBuffer = new Texture(device, 256, scanlines, 1, Usage.Dynamic, Format.A8R8G8B8, Pool.SystemMemory);
            nesDisplay = new Texture(device, 256, scanlines, 1, Usage.Dynamic, Format.A8R8G8B8, Pool.Default);
        }
        private void DisposeDisplayObjects()
        {
            if (displaySprite != null)
                displaySprite.Dispose();

            if (nesDisplay != null)
                nesDisplay.Dispose();

            if (backBuffer != null)
                backBuffer.Dispose();
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
            disposed = true;

            if (displayDevice != null)
                displayDevice.Dispose();

            this.DisposeDisplayObjects();
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
            currentMode = Direct3D.Adapters[0].CurrentDisplayMode;
            Console.WriteLine("Initializing Direct 3d (SlimDX) video device ...");

            try
            {
                if (!fullScreen)
                {
                    presentParams = new PresentParameters();
                    presentParams.BackBufferWidth = 256;
                    presentParams.BackBufferHeight = scanlines;
                    presentParams.Windowed = true;
                    presentParams.SwapEffect = SwapEffect.Discard;
                    presentParams.Multisample = MultisampleType.None;
                    if (ImmediateMode)
                        presentParams.PresentationInterval = PresentInterval.Immediate;
                    else
                        presentParams.PresentationInterval = PresentInterval.Default;
                    displayFormat = currentMode.Format;
                    displayDevice = new Device(Direct3D, 0, DeviceType.Hardware, control.Handle, CreateFlags.SoftwareVertexProcessing, presentParams);
                    displayRect = new Rectangle(0, 0, 256, scanlines);
                    bufferSize = (256 * scanlines * 4);
                    CreateDisplayObjects(displayDevice);
                    initialized = true;
                    disposed = false;
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
                    displayDevice = new Device(Direct3D, 0, DeviceType.Hardware, control.Handle, CreateFlags.SoftwareVertexProcessing, presentParams);
                    displayDevice.ShowCursor = false;
                    displayRect = new Rectangle(0, 0, 256, scanlines);
                    position = new Vector3((mode.Width - 256) / 2, (mode.Height - scanlines) / 2, 0);
                    bufferSize = (256 * scanlines) * 4;
                    CreateDisplayObjects(displayDevice);
                    initialized = true;
                    disposed = false;
                }

                Console.WriteLine("Direct 3d (SlimDX) video device initialized.");
            }
            catch (Exception e)
            {
                initialized = false;
                Console.WriteLine("Faild to initialize the Direct 3d (SlimDX) video device:");
                Console.WriteLine(e.Message);
            }
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
                    var rect = backBuffer.LockRectangle(0, LockFlags.DoNotWait);

                    for (int i = linesToSkip; i < screen.Length - linesToSkip; i++)
                        rect.Data.WriteRange(screen[i], 0, screen[i].Length);

                    rect.Data.Close();
                    backBuffer.UnlockRectangle(0);

                    if (canRender && !disposed)
                        displayDevice.UpdateTexture(backBuffer, nesDisplay);

                    displayDevice.BeginScene();
                    displayDevice.Clear(ClearFlags.Target, Color.Black, 0, 0);

                    displaySprite.Begin(SpriteFlags.None);
                    displaySprite.Draw(nesDisplay, displayRect, Color.White);
                    displaySprite.End();

                    displayDevice.EndScene();
                    displayDevice.Present();
                }
                isRendering = false;
            }
        }
        public void TakeSnapshot(string path, string format)
        {
            Nes.TogglePause(true);
            while (isRendering) { }//wait until the frame is finished
            Bitmap bitmap = new Bitmap(256, scanlines);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, 256, scanlines), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            int* pointer = (int*)bitmapData.Scan0;

            var rect = backBuffer.LockRectangle(0, LockFlags.DoNotWait);
            byte[] data = new byte[bufferSize];
            rect.Data.Read(data, 0, bufferSize);
            rect.Data.Close();
            backBuffer.UnlockRectangle(0);

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
            Nes.TogglePause(false);
        }
        public void Shutdown()
        {
            this.Dispose();
        }
        public bool FullScreen
        {
            get { return fullScreen; }
            set { fullScreen = value; }
        }
    }
}