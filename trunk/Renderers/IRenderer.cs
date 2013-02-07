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
namespace MyNes.Renderers
{
    /// <summary>
    /// The interface of renderer, the renderer should handle nes emulation outputs of video, sound and keys input.
    /// </summary>
    public abstract class IRenderer
    {
        private string rendererAssemblyPath = ""; 
        /// <summary>
        /// Start this renderer
        /// </summary>
        public abstract void Start();
        /// <summary>
        /// Get the name of this renderer
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Get the description of this renderer
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Get the copyright message provided by the author of this renderer.
        /// </summary>
        public virtual string CopyrightMessage { get { return ""; } }
        /// <summary>
        /// Get or set the parent asssembly path of this renderer. This should set by the manager and used for reset or reload
        ///  assembly that required by some renderers.
        /// </summary>
        public virtual string AssemblyPath
        { get { return rendererAssemblyPath; } set { rendererAssemblyPath = value; } }
    }
}
