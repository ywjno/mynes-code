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
using System.Collections.Generic;
using System.IO;
namespace MyNes
{
    [System.Serializable]
    public class DBFolder
    {
        private string path;
        private bool cacheBuilt;
        private List<DBFolder> folders = new List<DBFolder>();
        private List<DBFile> files = new List<DBFile>();
        
        public void RefreshFolders()
        {
            folders = new List<DBFolder>();
            string[] fldrs = Directory.GetDirectories(path);
            foreach (string fol in fldrs)
            {
                DBFolder bfolder = new DBFolder();
                bfolder.Path = fol;
                bfolder.RefreshFolders();
                folders.Add(bfolder);
            }
        }

        /// <summary>
        /// Get or set the folder path
        /// </summary>
        public string Path
        { get { return path; } set { path = value; } }
        /// <summary>
        /// Get or set if the cache has been built for this folder
        /// </summary>
        public bool CacheBuilt
        { get { return cacheBuilt; } set { cacheBuilt = value; } }
        /// <summary>
        /// Get or set the folders collection
        /// </summary>
        public List<DBFolder> Folders
        { get { return folders; } set { folders = value; } }
        /// <summary>
        /// Get or set the files collection
        /// </summary>
        public List<DBFile> Files
        { get { return files; } set { files = value; } }
    }
}
