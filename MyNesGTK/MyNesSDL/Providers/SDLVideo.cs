//  
//  SDLVideo.cs
//  
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
// 
//  Copyright (c) 2009 - 2015 Ala Ibrahim Hadid
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using SdlDotNet;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Core;
using SdlDotNet.Input;
using SdlDotNet.Graphics.Primitives;
using MyNes.Core;

namespace MyNesSDL
{
    public unsafe class SDLVideo : IVideoProvider
    {
        //make 2 surfaces for resizing and fullscreen
        private string gameTitle;
        private Surface screen;
        private Surface screen_back;
        private int screenBufferSize;
        private TextSprite fpsTextSprite;
        private TextSprite notTextSprite;
        private TextSprite statusTextSprite;
        private TextSprite soundRecordTextSprite;
        private Rectangle originalRect;
        private Rectangle destinationRect;
        public Size[] fullscreenModes;
        private bool auto_resize;
        private int Screen_w;
        private int Screen_h;
        private int windowW = 0;
        private int windowH = 0;
        private IntPtr pointer;
        private int* screen_pointer;
        private int firstToCut = 0;
        private bool ImmediateMode = false;
        private bool cutLines = true;
        private int FullScreenModeIndex = 0;
        private bool FullScreen = false;
        private int stretchMultiply = 2;
        private bool canRender = false;
        private bool openGL = false;
        private bool initialized = false;
        private bool keepAspectRatio;
        private bool showFps = true;
        private bool showNotifications = false;
        private bool isRendering = false;
        public int scanlines = 240;
        public string fontPath;
        private int textAppearanceFrames = 0;
        private int statusAppearanceFrames = 0;
        private Random r = new Random();
        private byte c;

        public SDLVideo(TVSystem system)
        {
            LoadSettings();
            initialized = false;
            canRender = false;
            Console.WriteLine("->Initializing video ...");
            fontPath = System.IO.Path.Combine(Program.ApplicationFolder, "FreeSans.ttf");
            // Initialize the video
            Video.Initialize();
            Video.WindowIcon();
            Video.WindowCaption = "My Nes SDL";
            fullscreenModes = Video.ListModes();
            Video.GLDoubleBufferEnabled = !ImmediateMode;
            windowW = 256 * stretchMultiply;
            switch (system)
            {
                case TVSystem.NTSC:
                    {
                        Events.TargetFps = 60;
                        break;
                    }
                case TVSystem.PALB:
                case TVSystem.DENDY:	
                    {
                        Events.TargetFps = 50;
                        break;
                    }
            }
            if (cutLines)
            {
                if (system == TVSystem.NTSC)
                {
                    scanlines = 224;
                    firstToCut = 8;
                }
                else
                {
                    scanlines = 238;
                    firstToCut = 1;
                }
            }
            else
            {
                scanlines = 240;
                firstToCut = 0;
            }
            screenBufferSize = 256 * scanlines;
            originalRect = new Rectangle(0, 0, 256, scanlines);
            screen_back = new Surface(256, scanlines, 32);

            windowH = scanlines * stretchMultiply;

            pointer = screen_back.Pixels;
            screen_pointer = (int*)screen_back.Pixels;
            NesEmu.SetupVideoRenderer(this, true, screen_back.Pixels, firstToCut * 256, 256 * (240 - firstToCut));
            // Create texts
            Console.WriteLine("-->Loading fonts ...");
            fpsTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(fontPath, 15));
            fpsTextSprite.Color = Color.White;
            fpsTextSprite.BackgroundColor = Color.Black;
            notTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(fontPath, 15));
            notTextSprite.BackgroundColor = Color.Black;
            soundRecordTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(fontPath, 15));
            soundRecordTextSprite.BackgroundColor = Color.Black;
            statusTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(fontPath, 15));
            statusTextSprite.BackgroundColor = Color.Black;
            // set video mode.
            Resize(FullScreen, true, windowW, windowH);
            Events.VideoResize += VideoResize;
            Events.MouseButtonDown += Events_MouseButtonDown;
            Events.MouseButtonUp += Events_MouseButtonUp;
            Events.Tick += OnTick;
            canRender = true;
            initialized = true;
            Console.WriteLine("->Video initialized successfully");
        }

        public void LoadSettings()
        {
            auto_resize = Settings.Video_AutoResizeToFitEmu;
            FullScreenModeIndex = Settings.Video_FullScreenModeIndex;
            cutLines = Settings.Video_HideLinesForNTSCAndPAL;
            keepAspectRatio = Settings.Video_KeepAspectRatio;
            Screen_h = Settings.Video_ScreenHeight;
            Screen_w = Settings.Video_ScreenWidth;
            showFps = Settings.Video_ShowFPS;
            showNotifications = Settings.Video_ShowNotification;
            FullScreen = Settings.Video_StartInFullscreen;
            stretchMultiply = Settings.Video_StretchMulti;
        }

        public void ApplySettings()
        {
            windowW = Settings.Video_ScreenWidth;
            windowH = Settings.Video_ScreenHeight;
            Resize(FullScreen, true, windowW, windowH);
        }
        // Tick !
        private void OnTick(object sender, SdlDotNet.Core.TickEventArgs e)
        {
            if (!canRender)
                return;
            if (!initialized)
                return;
            if (isRendering)
                return;

            if (!NesEmu.EmulationON)
            {
                isRendering = true;

                // Make a snow buffer !!

                for (int i = 0; i < screenBufferSize; i++)
                {
                    c = (byte)r.Next(0, 255);
                    screen_pointer[i] = c | (c << 8) | (c << 16) | (255 << 24);
                }

                screen.Lock();
                screen.Fill(Color.Black);
                screen.Blit(screen_back.CreateStretchedSurface(destinationRect.Size), destinationRect.Location);
                screen.Unlock();

                // Draw texts ...
            
                fpsTextSprite.Color = Color.Lime;
                fpsTextSprite.Text = "NO SIGNAL";
                screen.Blit(fpsTextSprite);

                if (showNotifications)
                {
                    if (textAppearanceFrames > 0)
                    {
                        textAppearanceFrames--;
                        screen.Blit(notTextSprite);
                    }
                }
                // Menu page !
                if (Program.PausedShowMenu)
                {
                    Program.Rooms[Program.RoomIndex].Draw(screen);
                }
                //screen.Update();
                Video.Update();

                isRendering = false;
            }
            else if (NesEmu.EmulationPaused)
            {
                isRendering = true;
                screen.Lock();
                screen.Fill(Color.Black);
                screen.Blit(screen_back.CreateStretchedSurface(destinationRect.Size), destinationRect.Location);
                screen.Unlock();
                //fpsTextSprite.Text = "PAUSED";
                //
                switch (NesEmu.EmuStatus)
                {
                    case NesEmu.EmulationStatus.HARDRESET:
                        {
                            fpsTextSprite.Text = "HARD RESETING ...";
                            break;
                        }
                    case NesEmu.EmulationStatus.LOADINGSTATE:
                        {
                            fpsTextSprite.Text = "LOADING STATE ...";
                            break;
                        }
                    case NesEmu.EmulationStatus.PAUSED:
                        {
                            fpsTextSprite.Text = "PAUSED";
                            break;
                        }
                    case NesEmu.EmulationStatus.SAVINGSNAP:
                        {
                            fpsTextSprite.Text = "SAVING SNAPSHOT ...";
                            break;
                        }
                    case NesEmu.EmulationStatus.SAVINGSRAM:
                        {
                            fpsTextSprite.Text = "SAVING SRAM ...";
                            break;
                        }
                    case NesEmu.EmulationStatus.SAVINGSTATE:
                        {
                            fpsTextSprite.Text = "SAVING STATE ...";
                            break;
                        }
                    case NesEmu.EmulationStatus.SOFTRESET:
                        {
                            fpsTextSprite.Text = "SOFT RESETTING ...";
                            break;
                        }
                }
                screen.Blit(fpsTextSprite);

                if (showNotifications)
                {
                    if (textAppearanceFrames > 0)
                    {
                        textAppearanceFrames--;
                        screen.Blit(notTextSprite);
                    }
                }
                // Menu page !
                if (Program.PausedShowMenu)
                {
                    Program.Rooms[Program.RoomIndex].Draw(screen);
                }
                //screen.Update();
                Video.Update();

                isRendering = false;
            }
        }

        public void SetWindowTitle()
        {
            if (NesEmu.IsGameFoundOnDB)
            {
                if (NesEmu.GameInfo.Game_AltName != null && NesEmu.GameInfo.Game_AltName != "")
                {
                    Video.WindowCaption = NesEmu.GameInfo.Game_Name + " (" + NesEmu.GameInfo.Game_AltName + ") - My Nes SDL";
                    gameTitle = NesEmu.GameInfo.Game_Name + " (" + NesEmu.GameInfo.Game_AltName + ")";
                }
                else
                {
                    Video.WindowCaption = NesEmu.GameInfo.Game_Name + " - My Nes SDL";
                    gameTitle = NesEmu.GameInfo.Game_Name;
                }
            }
            else
            {
                Video.WindowCaption = Path.GetFileName(NesEmu.GAMEFILE) + " - My Nes SDL";
                gameTitle = Path.GetFileName(NesEmu.GAMEFILE);
            }
        }

        public void SubmitBuffer(ref int[] buffer)
        {
            // Nothing to do since this video provider uses the pointer mode.
        }

        public void OnFrameFinished()
        {
            if (!canRender)
                return;
            if (!initialized)
                return;
            if (isRendering)
                return;
            isRendering = true;

            //screen.Lock();
            screen.Fill(Color.Black);
            screen.Blit(screen_back.CreateStretchedSurface(destinationRect.Size), destinationRect.Location);
            //screen.Unlock();

            if (Program.AUDIO.IsRecording)
            {
                fpsTextSprite.Text = "Recording Sound [" + TimeSpan.FromSeconds(Program.AUDIO.RecorderTime) + "]";
                screen.Blit(fpsTextSprite);
            }
            else if (showFps)
            {
                if (NesEmu.ImmediateFrameTime > 0)
                {
                    fpsTextSprite.Text = "FPS: " + (1.0 / NesEmu.ImmediateFrameTime).ToString("F2") + " / " + (1.0 / NesEmu.CurrentFrameTime).ToString("F2");
                    screen.Blit(fpsTextSprite);
                }
            }

            if (!NesEmu.SpeedLimitterON)
            {
                notTextSprite.Text = "TURBO";
                notTextSprite.Color = Color.Lime;
                screen.Blit(notTextSprite);
            }
            if (statusAppearanceFrames > 0)
            {
                statusAppearanceFrames--;

                statusTextSprite.X = destinationRect.X + 2;
                statusTextSprite.Y = 2;
                statusTextSprite.Text = "GAME: " + gameTitle;

                screen.Blit(statusTextSprite);

                statusTextSprite.Y = 32;
                statusTextSprite.Text = "TV: " + NesEmu.TVFormat.ToString();

                screen.Blit(statusTextSprite);

                statusTextSprite.Y = 62;
                statusTextSprite.Text = "FPS: " + (1.0 / NesEmu.ImmediateFrameTime).ToString("F2") + " / " + (1.0 / NesEmu.CurrentFrameTime).ToString("F2");

                screen.Blit(statusTextSprite);
            }
            if (showNotifications)
            {
                if (textAppearanceFrames > 0)
                {
                    textAppearanceFrames--;
                    screen.Blit(notTextSprite);
                }
            }
            // Menu page !
            if (Program.PausedShowMenu)
            {
                Program.Rooms[Program.RoomIndex].Draw(screen);
            }
            screen.Update();
            //Video.Update();

            isRendering = false;
        }

        private void Resize(bool fullScreen)
        {
            this.FullScreen = fullScreen;
			
            Resize(FullScreen, true, windowW, windowH);
        }

        private void Resize(bool fullScreen, bool resizable, int w, int h)
        {
            if (Settings.Video_AutoResizeToFitEmu && NesEmu.EmulationON)
            {
                w = 256 * stretchMultiply;
                h = scanlines * stretchMultiply;
            }
            switch (NesEmu.TVFormat)
            {
                case TVSystem.NTSC:
                    {
                        Events.TargetFps = 60;
                        scanlines = 224;
                        firstToCut = 8;
                        break;
                    }
                case TVSystem.PALB:
                case TVSystem.DENDY:    
                    {
                        Events.TargetFps = 50;
                        scanlines = 238;
                        firstToCut = 1;
                        break;
                    }
            }
            if (!cutLines)
            {
                scanlines = 240;
                firstToCut = 0;
            }
            screenBufferSize = 256 * scanlines;
            originalRect = new Rectangle(0, 0, 256, scanlines);
            screen_back = new Surface(256, scanlines, 32);

            windowH = scanlines * stretchMultiply;

            pointer = screen_back.Pixels;
            screen_pointer = (int*)screen_back.Pixels;
            NesEmu.SetupVideoRenderer(this, true, screen_back.Pixels, firstToCut * 256, 256 * (240 - firstToCut));
            // setup rectangles
            if (FullScreen)
            {
                if (!keepAspectRatio)
                {
                    destinationRect = new Rectangle(0, 0, fullscreenModes[FullScreenModeIndex].Width, fullscreenModes[FullScreenModeIndex].Height);
                }
                else
                {
                    destinationRect = GetRatioStretchRectangle(fullscreenModes[FullScreenModeIndex].Width, fullscreenModes[FullScreenModeIndex].Height);
                }
                if (!NesEmu.IsZapperConnected)
                    SdlDotNet.Input.Mouse.ShowCursor = false;
            }
            else
            {
                if (!keepAspectRatio)
                {
                    destinationRect = new Rectangle(0, 0, w, h);
                }
                else
                {
                    destinationRect = GetRatioStretchRectangle(w, h);
                }
                SdlDotNet.Input.Mouse.ShowCursor = true;
                Settings.Video_ScreenWidth = w;
                Settings.Video_ScreenHeight = h;
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

            statusTextSprite.X = destinationRect.X + 2;
            statusTextSprite.Y = 2;
            statusTextSprite.Color = Color.White;
            statusTextSprite.Text = "0/0";
            // set video mode.
            if (fullScreen)
            {
                screen = Video.SetVideoMode(fullscreenModes[FullScreenModeIndex].Width, fullscreenModes[FullScreenModeIndex].Height, 32, resizable, openGL, true);
            }
            else
            {
                screen = Video.SetVideoMode(w, h, 32, resizable, openGL, false);
            }
        }

        public void ShutDown()
        {
        }

        public void WriteNotification(string text, int frames, Color color)
        {
            notTextSprite.Color = color;
            notTextSprite.Text = text;
            textAppearanceFrames = frames;
        }

        public void ShowGameStatus()
        {
            statusAppearanceFrames = 500;
        }

        public void OnResizeBegin()
        {
        }

        public void OnResizeEnd()
        {
			
        }

        public void SwitchFullscreen()
        {
            NesEmu.EmulationPaused = true;
            this.FullScreen = !this.FullScreen;
            Resize(this.FullScreen);
            NesEmu.EmulationPaused = false;
        }

        public void Reset()
        {
            Resize(FullScreen);
        }

        public void TakeSnapshot(string snapsfolder, string snapFileName, string format, bool replace)
        {
            try
            {
                int j = 0;
                string path = "";
                if (!replace)
                {
                    path = Path.Combine(snapsfolder, snapFileName + "_" + j + format);
                    while (System.IO.File.Exists(path))
                    {
                        j++;
                        path = Path.Combine(snapsfolder, snapFileName + "_" + j + format);
                    }
                }
                else
                {
                    path = Path.Combine(snapsfolder, snapFileName + format);
                }
                WriteNotification("Snapshot taken. [" + Path.GetFileName(path) + "]", 120, Color.Green);
                screen_back.SaveBmp(path);
                Console.WriteLine("Snapshot taken");
            }
            catch (Exception ex)
            {
                WriteNotification(ex.Message, 120, Color.Red);
                File.WriteAllText("SDL_ERROR.txt", ex.ToString());
            }
        }

        public int ScreenWidth
        {
            get { return windowW; }
        }

        public int ScreenHeight
        {
            get { return windowH; }
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

        private void VideoResize(object sender, VideoResizeEventArgs e)
        {
            this.Resize(this.FullScreen, true, e.Width, e.Height);
        }

        private void Events_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Events_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
        }
    }
}

