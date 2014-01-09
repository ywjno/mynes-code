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
using System;
using System.Collections.Generic;

namespace MyNes
{
    [Serializable]
    public class DBColumn
    {
        private string id;
        private string name;
        private int width;
        private bool visible;

        public static string[,] DEFAULTCOLUMNS
        {
            get
            {
                return new string[,]  {
          {  Program.ResourceManager.GetString("Column_Name"),            "name" } ,
          {  Program.ResourceManager.GetString("Column_Size"),            "size" } ,
          {  Program.ResourceManager.GetString("Column_FileType"),        "file type" } ,
          {  Program.ResourceManager.GetString("Column_PlayedTimes"),     "played times" } ,
          {  Program.ResourceManager.GetString("Column_Rating"),          "rating" } ,
          {  Program.ResourceManager.GetString("Column_Path"),            "path" } ,
          {  Program.ResourceManager.GetString("Column_BoardName"),       "board" } ,            
          {  Program.ResourceManager.GetString("Column_Mapper"),          "mapper" } ,           
          {  Program.ResourceManager.GetString("Column_PRGSize"),         "prg" } ,  
          {  Program.ResourceManager.GetString("Column_CHRSize"),         "chr" } , 
          {  Program.ResourceManager.GetString("Column_HasTrainer"),      "trainer" } , 
          {  Program.ResourceManager.GetString("Column_HasSaveRam"),      "save ram" } , 
          {  Program.ResourceManager.GetString("Column_Mirroring"),       "mirroring" } , 
          {  Program.ResourceManager.GetString("Column_IsVSSystem"),      "vs system" } , 
          {  Program.ResourceManager.GetString("Column_IsPlaychoice10"),  "pc10" } , 
          {  Program.ResourceManager.GetString("Column_TVSystem"),        "tv" } ,
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
        public static DBColumn[] BuildDefaultCollection()
        {
            List<DBColumn> columns = new List<DBColumn>();
            for (int i = 0; i < DEFAULTCOLUMNS.Length / 2; i++)
            {
                DBColumn c = new DBColumn();
                c.name = DEFAULTCOLUMNS[i, 0];
                c.visible = true;
                c.width = 70;
                c.id = DEFAULTCOLUMNS[i, 1];
                columns.Add(c);
            }
            return columns.ToArray();
        }

        public string ColumnID
        { get { return id; } set { id = value; } }
        public string Name
        { get { return name; } set { name = value; } }
        public int Width
        { get { return width; } set { width = value; } }
        public bool Visible
        { get { return visible; } set { visible = value; } }
    }
    [Serializable]// For save
    public class DBColumnCollection : List<DBColumn>
    {
        public DBColumnCollection() : base() { } 
        public DBColumnCollection(DBColumn[] columns) : base(columns) { } 
    }
}
