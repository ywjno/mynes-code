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
using System.Collections;
using System.Collections.Generic;
namespace MyNes
{
    [System.Serializable()]
    public class BrowserDatabase
    {
        List<BFolder> folders = new List<BFolder>();
        /// <summary>
        /// Get or set the folders collection
        /// </summary>
        public List<BFolder> Folders
        { get { return folders; } set { folders = value; } }
        /// <summary>
        /// Get if a folder exists in the folders collection
        /// </summary>
        /// <param name="folderPath">The folder path</param>
        /// <returns>True if folder exists otherwise folder</returns>
        public bool IsFolderExist(string folderPath)
        {
            foreach (BFolder fldr in folders)
            {
                if (fldr.Path == folderPath)
                    return true;
            }
            return false;
        }
    }
}