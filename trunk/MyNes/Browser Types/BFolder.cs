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
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MyNes
{
    [Serializable()]
    public class BFolder
    {
        private List<BFolder> folders = new List<BFolder>();
        private List<BRom> roms = new List<BRom>();
        private string path = "";
        private string snapshotsFolder = "";
        private string coversFolder = "";
        private string infosFolder = "";
        private bool cacheBuilt = false;
       
        //methods
        public void RefreshFolders()
        {
            folders = new List<BFolder>();
            string[] fldrs = Directory.GetDirectories(path);
            foreach (string fol in fldrs)
            {
                BFolder bfolder = new BFolder();
                bfolder.Path = fol;
                bfolder.RefreshFolders();
                folders.Add(bfolder);
            }
        }
        //Properties
        /// <summary>
        /// Get or set the path of this folder
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        /// <summary>
        /// Get or set the snapshots folder for this folder
        /// </summary>
        public string SnapshotsFolder
        {
            get { return snapshotsFolder; }
            set { snapshotsFolder = value; }
        }
        /// <summary>
        /// Get or set the info texts folder for this folder
        /// </summary>
        public string InfosFolder
        {
            get { return infosFolder; }
            set { infosFolder = value; }
        }
        /// <summary>
        /// Get or set the folders collection
        /// </summary>
        public List<BFolder> BFolders
        { get { return folders; } set { folders = value; } }
        /// <summary>
        /// Get or set the roms collection
        /// </summary>
        public List<BRom> BRoms
        { get { return roms; } set { roms = value; } }
        /// <summary>
        /// Get or set a vale indicate the cache has been built for this rom, true means cache built success
        /// </summary>
        public bool CacheBuilt
        { get { return cacheBuilt; } set { cacheBuilt = value; } }
    }
}
