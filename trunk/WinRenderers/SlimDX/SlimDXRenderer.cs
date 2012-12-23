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
using MyNes.Renderers;
namespace MyNes.WinRenderers
{
    /// <summary>
    /// This class will define the slimdx renderer.
    /// </summary>
    public class SlimDXRenderer : IRenderer
    {
        public override void Start()
        {
            RendererFormSlimDX frm = new RendererFormSlimDX();
            frm.Show();
        }

        public override string Name
        {
            get { return "SlimDX Direct3D9"; }
        }

        public override string Description
        {
            get { return "Render using SlimDX (managed directx) library.\n\nThis renderer requires the SlimDX Runtime for .NET 4.0 (January 2012), for more info please visit: http://slimdx.org/ \nNote that only January 2012 version work with My Nes.\n\nWritten by Ala Ibrahim Hadid."; }
        }
    }
}
