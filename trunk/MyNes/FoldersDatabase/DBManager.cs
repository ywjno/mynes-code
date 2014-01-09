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
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace MyNes
{
    public class DBManager
    {
        public DBManager(string dbPath)
        {
            this.dbPath = dbPath;
            this.db = new FoldersDatabase();
        }
        private string dbPath;
        private FoldersDatabase db;

        public void SaveDatabase(string dbPath)
        { this.dbPath = dbPath; SaveDatabase(); }
        public void SaveDatabase()
        {
            try
            {
                Trace.WriteLine("Saving folders database ..", "DBManager");
                FileStream fs = new FileStream(dbPath, FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                formatter.Serialize(fs, db);
                fs.Close();
                Trace.WriteLine("folders database saved successfully", "DBManager");
            }
            catch (Exception ex)
            {
                Trace.TraceError("Unable to save folders database: " + ex.Message);
            }
        }
        public void LoadDatabase(string dbPath)
        { this.dbPath = dbPath; LoadDatabase(); }
        public void LoadDatabase()
        {
            FileStream fs = null;
            try
            {
                if (File.Exists(dbPath))
                {
                    Trace.WriteLine("Loading folders database ..", "DBManager");
                    fs = new FileStream(dbPath, FileMode.Open, FileAccess.Read);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    db = (FoldersDatabase)formatter.Deserialize(fs);
                    fs.Close();
                    Trace.WriteLine("Folders database loaded successfully", "DBManager");
                }
                else
                {
                    Trace.TraceError("Unable to load folders database: folders database file is not exist.");
                }
            }
            catch (Exception ex)
            {
                if (fs != null)
                    fs.Close();
                Trace.TraceError("Unable to load folders database: " + ex.Message);
            }
        }

        /// <summary>
        /// Get or set the database file path
        /// </summary>
        public string DBPath
        { get { return dbPath; } set { dbPath = value; } }
        /// <summary>
        /// Get or set the folders database object
        /// </summary>
        public FoldersDatabase DB
        { get { return db; } set { db = value; } }
    }
}
