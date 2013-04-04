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
using System.Drawing;
namespace MyNes.Core.IO.Output
{
    public interface IVideoDevice
    {
        /// <summary>
        /// Render a frame into the screen, the ppu calls this when the buffer is ready to be presented
        /// </summary>
        /// <param name="ScreenBuffer">The screen buffer, size = 256 * 240, each value is int32-ARBG color</param>
        void RenderFrame(int[][] ScreenBuffer);
        /// <summary>
        /// Begin the rendering operation, Ppu calls this at the beginning of the frame
        /// </summary>
        void Begin();
        /// <summary>
        /// Shutdown the device then dispose, emu calls this when it shutdown
        /// </summary>
        void Shutdown();
        /// <summary>
        /// Take a snapshot
        /// </summary>
        /// <param name="snapshotsFolder">The snapshots folder. Snap name will be generated atomaticly</param>
        /// <param name="filename">The snapshot file name without extension.</param>
        /// <param name="format">The image format</param>
        /// <param name="replace">Replace original snap if exist instead of creating new one</param>
        void TakeSnapshot(string snapshotsFolder, string filename, string format, bool replace);
        /// <summary>
        /// Get a value indecate if this video device is initialized and ready to use
        /// </summary>
        bool Initialized { get; }
        /// <summary>
        /// Draw a notification text
        /// </summary>
        /// <param name="text">The text to draw</param>
        /// <param name="frames">How many frames the text should appear</param>
        /// <param name="color">The text color</param>
        void DrawText(string text, int frames, Color color);
        /// <summary>
        /// Get or set if the device should draw fps.
        /// </summary>
        bool ShowFPS { get; set; }
        /// <summary>
        /// Get or set if the device should draw notifications (drown text using DrawText method).
        /// </summary>
        bool ShowNotifications { get; set; }
        /// <summary>
        /// Get if this device is rendering.
        /// </summary>
        bool IsRendering { get; }
    }
}
