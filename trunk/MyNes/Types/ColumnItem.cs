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
namespace MyNes
{
    [Serializable()]
    public class ColumnItem
    {
        public string ColumnID = "";
        public string ColumnName = "";
        public bool Visible = true;
        public int Width = 60;

        public static string[,] DEFAULTCOLUMNS
        {
            get
            {
                return new string[,]  {
          { "Name",              "name" } ,
          { "Size",              "size" } ,
          { "File Type",         "file type" } ,
          { "Played Times",      "played times" } ,
          { "Rating",            "rating" } ,
          { "Mapper #",          "mapper" } ,
          { "Board",             "board" } ,
          { "Mirroring",         "mirroring" } ,
          { "Has Trainer",       "trainer" } ,
          { "Is Battery Packed", "battery" } ,
          { "Is PC10",           "pc10" } ,
          { "Is VsUnisystem",    "vs" } ,
          { "Path",              "path" } , 
                                      };
            }
        }

        public static bool IsDefaultColumn(string id)
        {
            for (int i = 0; i < DEFAULTCOLUMNS.Length / 2; i++)
            {
                if (DEFAULTCOLUMNS[i, 1] == id)
                    return true;
            }
            return false;
        }
    }
}
