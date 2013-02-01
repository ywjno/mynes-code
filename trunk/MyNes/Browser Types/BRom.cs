/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2013
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
namespace MyNes
{
    [System.Serializable()]
    public class BRom
    {
        private string name = "";
        private string path = "";
        private string size = "0 Byte";
        private string mapper = "N/A";
        private string board = "N/A";
        private string isPc10 = "No";
        private string isVsUnisystem = "No";
        private string isBattery = "No";
        private string hasTrainer = "No";
        private string mirroring = "N/A";
        private BRomType type = BRomType.INES;
        private string snapshotPath = "";
        private string coverPath = "";
        private int playedTimes = 0;
        private int rating = 0;
        private string description = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Mapper
        {
            get { return mapper; }
            set { mapper = value; }
        }
        public string Board
        {
            get { return board; }
            set { board = value; }
        }
        public string IsPc10
        {
            get { return isPc10; }
            set { isPc10 = value; }
        }
        public string IsVsUnisystem
        {
            get { return isVsUnisystem; }
            set { isVsUnisystem = value; }
        }
        public string IsBattery
        {
            get { return isBattery; }
            set { isBattery = value; }
        }
        public string HasTrainer
        {
            get { return hasTrainer; }
            set { hasTrainer = value; }
        }
        public string Mirroring
        {
            get { return mirroring; }
            set { mirroring = value; }
        }
        public BRomType BRomType
        {
            get { return type; }
            set { type = value; }
        }
        public string SnapshotPath
        {
            get { return snapshotPath; }
            set { snapshotPath = value; }
        }
        public string CoverPath
        {
            get { return coverPath; }
            set { coverPath = value; }
        }
        public int PlayedTimes
        {
            get { return playedTimes; }
            set { playedTimes = value; }
        }
        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public string InfoText
        { get { return description; } set { description = value; } }
    }

    public enum BRomType
    { INES, Archive }
}
