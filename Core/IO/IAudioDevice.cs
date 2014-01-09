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
namespace MyNes.Core.IO
{
    /// <summary>
    /// Represents My Nes audio output device
    /// </summary>
    public abstract class IAudioDevice
    {
        /// <summary>
        /// Emu calls this when it needs to update a frame
        /// </summary>
        public virtual void UpdateFrame() { }
        /// <summary>
        /// Emu calls this when it finishes a buffer and needs to submit
        /// </summary>
        /// <param name="samplesBuffer"></param>
        public virtual void SubmitBuffer(byte[] samplesBuffer) { }
        /// <summary>
        /// Shutdown the device then dispose, emu calls this when it shutdown
        /// </summary>
        public virtual void Shutdown() { }
        /// <summary>
        /// Play/Resume
        /// </summary>
        public virtual void Play() { }
        /// <summary>
        /// Pause
        /// </summary>
        public virtual void Stop() { }
        /// <summary>
        /// Get if the device is recording sound
        /// </summary>
        public virtual bool IsRecording { get { return false; } }
        /// <summary>
        /// Record the sound
        /// </summary>
        /// <param name="filePath">The complete wav file path</param>
        public virtual void Record(string filePath) { }
        /// <summary>
        /// Stop recording
        /// </summary>
        public virtual void RecordStop() { }
        /// <summary>
        /// Get the record time in seconds
        /// </summary>
        public virtual int RecordTime { get { return 0; } }
        /// <summary>
        /// Get if this device is still playing
        /// </summary>
        public virtual bool IsPlaying { get { return false; } }
        /// <summary>
        /// Nes calls this when it needs to reset playing buffer.
        /// </summary>
        public virtual void ResetBuffer() { }
    }
}
