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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNes.Core.IO
{
    /// <summary>
    /// Represents My Nes video output device.
    /// </summary>
    public abstract class IVideoDevice
    {
        /// <summary>
        /// Initialize the video device
        /// </summary>
        public abstract void Initialize();
        /// <summary>
        /// Shutdown the device then dispose, emu calls this when it shutdown
        /// </summary>
        public abstract void ShutDown();
        /// <summary>
        /// Render a frame into the screen, the ppu calls this when the buffer is ready to be presented
        /// </summary>
        /// <param name="ScreenBuffer">The screen buffer, size = 256 * 240, each value is int32-ARBG color</param>
        public abstract void RenderFrame(int[] ScreenBuffer);
        /// <summary>
        /// Draw a notification text
        /// </summary>
        /// <param name="text">The text to draw</param>
        /// <param name="frames">How many frames the text should appear</param>
        /// <param name="color">The int32-ARBG color text color</param>
        public virtual void DrawNotification(string text, int frames, int color) { }   
        /// <summary>
        /// Take a snapshot
        /// </summary>
        /// <param name="snapshotsFolder">The snapshots folder. Snap name will be generated automatically</param>
        /// <param name="filename">The snapshot file name without extension.</param>
        /// <param name="format">The image format</param>
        /// <param name="replace">Replace original snap if exist instead of creating new one</param>
        public virtual void TakeSnapshot(string snapshotsFolder, string filename, string format, bool replace) { }
        /// <summary>
        /// Switch to fullscreen/window mode
        /// </summary>
        public virtual void SwitchFullscreen() { }

        public virtual void ResizeBegin() { }
        public virtual void ResizeEnd() { }
    }
}
