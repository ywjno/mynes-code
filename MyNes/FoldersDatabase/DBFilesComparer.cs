/* This file is part of Emulators Organizer
   A program that can organize roms and emulators

   Copyright © Ali Ibrahim Hadid and Ala Ibrahim Hadid 2009 - 2013

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace MyNes
{
    class DBFilesComparer : IComparer<DBFile>
    {
        public DBFilesComparer(bool az, string id)
        {
            this.az = az;
            this.id = id;
            this.comp = StringComparer.Create(Thread.CurrentThread.CurrentCulture, false);
        }
        private bool az;
        private string id;
        private StringComparer comp;

        public int Compare(DBFile x, DBFile y)
        {
            switch (id)
            {
                case "name":
                    {
                        string x_name = Path.GetFileName(x.Path);
                        string y_name = Path.GetFileName(y.Path);
                        if (az)
                            return comp.Compare(x_name, y_name);
                        else
                            return (-1 * comp.Compare(x_name, y_name));
                    }
                case "size":
                    {
                        if (az)
                            return (int)(x.Size - y.Size);
                        else
                            return (int)(y.Size - x.Size);
                    }
                case "file type":
                    {
                        string x_name = Path.GetExtension(x.Path);
                        string y_name = Path.GetExtension(y.Path);
                        if (az)
                            return comp.Compare(x_name, y_name);
                        else
                            return (-1 * comp.Compare(x_name, y_name));
                    }
                case "played times":
                    {
                        if (az)
                            return (int)(x.PlayedTimes - y.PlayedTimes);
                        else
                            return (int)(y.PlayedTimes - x.PlayedTimes);
                    }
                case "rating":
                    {
                        if (az)
                            return (int)(x.Rating - y.Rating);
                        else
                            return (int)(y.Rating - x.Rating);
                    }
                case "path":
                    {
                        if (az)
                            return comp.Compare(x.Path, y.Path);
                        else
                            return (-1 * comp.Compare(x.Path, y.Path));
                    }
                case "board":
                    {
                        if (az)
                            return comp.Compare(x.BoardName, y.BoardName);
                        else
                            return (-1 * comp.Compare(x.BoardName, y.BoardName));
                    }
                case "mapper":
                    {
                        if (az)
                            return (int)(x.MapperNumber - y.MapperNumber);
                        else
                            return (int)(y.MapperNumber - x.MapperNumber);
                    }
                case "prg":
                    {
                        if (az)
                            return (int)(x.PRG - y.PRG);
                        else
                            return (int)(y.PRG - x.PRG);
                    }
                case "chr":
                    {
                        if (az)
                            return (int)(x.CHR - y.CHR);
                        else
                            return (int)(y.CHR - x.CHR);
                    }
                case "trainer":
                    {
                        int x_h = x.HasTrainer ? 1 : 0;
                        int y_h = y.HasTrainer ? 1 : 0;
                        if (az)
                            return (int)(x_h - y_h);
                        else
                            return (int)(y_h - x_h);
                    }
                case "save ram":
                    {
                        int x_h = x.HasSaveRam ? 1 : 0;
                        int y_h = y.HasSaveRam ? 1 : 0;
                        if (az)
                            return (int)(x_h - y_h);
                        else
                            return (int)(y_h - x_h);
                    }
                case "mirroring":
                    {
                        if (az)
                            return comp.Compare(x.Mirroring, y.Mirroring);
                        else
                            return (-1 * comp.Compare(x.Mirroring, y.Mirroring));
                    }
                case "vs system":
                    {
                        int x_h = x.IsVSSystem ? 1 : 0;
                        int y_h = y.IsVSSystem ? 1 : 0;
                        if (az)
                            return (int)(x_h - y_h);
                        else
                            return (int)(y_h - x_h);
                    }
                case "pc10":
                    {
                        int x_h = x.IsPlaychoice10 ? 1 : 0;
                        int y_h = y.IsPlaychoice10 ? 1 : 0;
                        if (az)
                            return (int)(x_h - y_h);
                        else
                            return (int)(y_h - x_h);
                    }
                case "tv":
                    {
                        if (az)
                            return comp.Compare(x.TvSystem, y.TvSystem);
                        else
                            return (-1 * comp.Compare(x.TvSystem, y.TvSystem));
                    }
                default: return -1;
            }
        }
    }
}
