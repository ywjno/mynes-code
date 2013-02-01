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
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
namespace MyNes.Renderers
{
    /// <summary>
    /// The renderers manager, use it to find renderers
    /// </summary>
    public class RenderersCore
    {
        private static IRenderer[] availableRenderers;
        private static SettingsManager settingsManager = new SettingsManager();
        /// <summary>
        /// Search My Nes dir for renderers.
        /// </summary>
        public static void FindRenderers(string directory)
        {
            string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            List<IRenderer> rendrs = new List<IRenderer>();
            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToLower() == ".dll" || Path.GetExtension(file).ToLower() == ".exe")
                {
                    try
                    {
                        Assembly assm = Assembly.LoadFile(file);
                        Type[] types = assm.GetTypes();
                        foreach (Type tp in types)
                        {
                            if (tp.IsSubclassOf(typeof(IRenderer)))
                            {
                                IRenderer renderer = Activator.CreateInstance(tp) as IRenderer;
                                renderer.AssemblyPath = file;
                                rendrs.Add(renderer);
                            }
                        }
                    }
                    catch//this assembly can't be loaded, ignore ..
                    { }
                }
            }
            availableRenderers = rendrs.ToArray();
        }
        /// <summary>
        /// Get the available renderers. The FindRenderers() must be called first so that the renderers list get filled.
        /// </summary>
        public static IRenderer[] AvailableRenderers
        {
            get { return availableRenderers; }
        }
        /// <summary>
        /// Get the settings manager which holds shared settings data and save/load method
        /// </summary>
        public static SettingsManager SettingsManager { get { return settingsManager; } }
    }
}
