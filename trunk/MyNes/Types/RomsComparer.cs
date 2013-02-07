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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
namespace MyNes
{
    class RomsComparer : Comparer<BRom>
    {
        public RomsComparer(bool AtoZ, string sortId)
        {
            this.AtoZ = AtoZ;
            this.sortId = sortId;
        }

        private bool AtoZ = false;
        private string sortId = "";

        public override int Compare(BRom x, BRom y)
        {
            switch (sortId)
            {
                case "name":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Name, y.Name);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Name, y.Name));
                case "size":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Size, y.Size);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Size, y.Size));
                case "file type":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(Path.GetExtension(x.Path).ToLower(), Path.GetExtension(y.Size).ToLower());
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(Path.GetExtension(x.Size).ToLower(), Path.GetExtension(y.Size).ToLower()));
                case "played times":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.PlayedTimes, y.PlayedTimes);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.PlayedTimes, y.PlayedTimes));
                case "rating":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Rating, y.Rating);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Rating, y.Rating));
                case "path":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Path, y.Path);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Path, y.Path));
                case "mapper":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Mapper, y.Mapper);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Mapper, y.Mapper));
                case "board":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Board, y.Board);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Board, y.Board));
                case "trainer":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.HasTrainer, y.HasTrainer);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.HasTrainer, y.HasTrainer));
                case "battery":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.IsBattery, y.IsBattery);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.IsBattery, y.IsBattery));
                case "pc10":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.IsPc10, y.IsPc10);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.IsPc10, y.IsPc10));
                case "vs":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.IsVsUnisystem, y.IsVsUnisystem);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.IsVsUnisystem, y.IsVsUnisystem));
                case "mirroring":
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Mirroring, y.Mirroring);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(x.Mirroring, y.Mirroring));
                case "snapshot":
                    string xx = File.Exists(x.SnapshotPath) ? "Yes" : "No";
                    string yy = File.Exists(y.SnapshotPath) ? "Yes" : "No";
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(xx, yy);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(xx, yy));
                case "cover":
                    string xx1 = File.Exists(x.CoverPath) ? "Yes" : "No";
                    string yy1 = File.Exists(y.CoverPath) ? "Yes" : "No";
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(xx1, yy1);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(xx1, yy1));
                case "info":
                    string xx2 = (x.InfoText.Length > 0) ? "Yes" : "No";
                    string yy2 = (y.InfoText.Length > 0) ? "Yes" : "No";
                    if (AtoZ)
                        return (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(xx2, yy2);
                    else
                        return (-1 * (StringComparer.Create(Thread.CurrentThread.CurrentCulture, false)).Compare(xx2, yy2));
            }
            return -1;
        }
    }
}
