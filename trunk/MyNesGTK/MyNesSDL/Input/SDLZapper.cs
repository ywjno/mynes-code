//  
//  SDLZapper.cs
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
using MyNes.Core;
using SdlDotNet.Input;

namespace MyNesSDL
{
    public class SDLZapper : IZapperConnecter
    {
        private bool oldTrigger;
        private int timer = 3;
        private int pixelX;
        private int pixelY;
        public int winPosX;
        public int winPosY;
        private int c;
        private byte r;
        private byte g;
        private byte b;

        public override void Update()
        {
            oldTrigger = Trigger;
            Trigger = Mouse.IsButtonPressed(MouseButton.PrimaryButton);
            if (timer > 0)
            {
                timer--;
                pixelX = ((Mouse.MousePosition.X - winPosX) * 256) / Program.VIDEO.ScreenWidth;
                if (pixelX < 0 || pixelX >= 256)
                {
                    State = false;
                    return;
                }
                pixelY = ((Mouse.MousePosition.Y - winPosY) * Program.VIDEO.scanlines) / Program.VIDEO.ScreenHeight;
                if (pixelY < 0 || pixelY >= Program.VIDEO.scanlines)
                {
                    State = false;
                    return;
                }
                //System.Console.WriteLine(pixelX + ", " + pixelY);
                for (int x = -15; x < 15; x++)
                {
                    for (int y = -15; y < 15; y++)
                    {
                        if (pixelX + x < 256 && pixelX + x >= 0 && pixelY + y < Program.VIDEO.scanlines && pixelY + y >= 0)
                        {
                            c = NesEmu.GetPixel(pixelX + x, pixelY + y);
                            r = (byte)(c >> 0x10);
                            // R
                            g = (byte)(c >> 0x08);
                            // G
                            b = (byte)(c >> 0x00);
                            // B
                            State = (r > 85 && g > 85 && b > 85);
                            //bright color ?
                        }
                        if (State)
                            break;
                    }
                    if (State)
                        break;
                }
            }
            else
                State = false;
            if (!Trigger && oldTrigger)
                timer = 6;
        }
    }
}

