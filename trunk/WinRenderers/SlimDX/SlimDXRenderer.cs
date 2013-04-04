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
            settings = new SlimDXSettings();
            // try to load the settings
            object settingsObject = SettingsManager.LoadSettingsObject("slimdxconfig", typeof(SlimDXSettings));
            if (settingsObject != null)
                settings = (SlimDXSettings)settingsObject;
            frm = new RendererFormSlimDX();
            frm.Show();
        }

        private RendererFormSlimDX frm;
        private static SlimDXSettings settings;

        public override string Name
        {
            get { return "SlimDX Direct3D9"; }
        }
        public override string Description
        {
            get { return "Render using SlimDX (managed directx) library.\n\nThis renderer requires the SlimDX Runtime for .NET 4.0 (January 2012), for more info please visit: http://slimdx.org/ \nNote that only January 2012 version work with My Nes."; }
        }
        public override string CopyrightMessage
        {
            get
            {
                return "Written by Ala Ibrahim Hadid.";
            }
        }
        public override void Kill()
        {
            if (frm != null) frm.Close();
        }
        public override bool IsAlive
        {
            get
            {
                if (frm != null)
                    return frm.Visible;
                 return false;
            }
        }
        public override void ApplySettings(SettingType stype)
        {
            if (frm != null)
            {
                frm.ApplySettings(stype);
            }
        }
        public override void ChangeSettings()
        {
            Frm_SlimDXSettings frm = new Frm_SlimDXSettings();
            frm.ShowDialog();
        }
        public static SlimDXSettings Settings
        { get { return settings; } set { settings = value; } }
    }
}
