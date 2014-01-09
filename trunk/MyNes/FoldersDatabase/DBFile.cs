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
    public class DBFile
    {
        private string path;
        private string sizeLabel;
        private long size;
        private int rating;
        private int playedTimes;
        private double playTime;
        private DBFileFormat format;
        private List<string> snapshots = new List<string>();
        private List<string> covers = new List<string>();
        private List<string> infoTexts = new List<string>();
        // Board info
        private string boardName;
        private int mapperNumber;
        private string prgSize;
        private string chrSize;
        private int prg;
        private int chr;
        private bool hasTrainer;
        private string mirroring;
        private bool hasSaveRam;
        private bool isVSSystem;
        private bool isPlaychoice10;
        private string tvSystem;

        public string Path
        { get { return path; } set { path = value; } }
        public DBFileFormat Format
        { get { return format; } set { format = value; } }
        public string SizeLabel
        { get { return sizeLabel; } set { sizeLabel = value; } }
        public long Size
        { get { return size; } set { size = value; } }
        public int Rating
        { get { return rating; } set { rating = value; } }
        public int PlayedTimes
        { get { return playedTimes; } set { playedTimes = value; } }
        public double PlayTimeInSeconds
        { get { return playTime; } set { playTime = value; } }
        public List<string> Snapshots
        { get { return snapshots; } set { snapshots = value; } }
        public List<string> Covers
        { get { return covers; } set { covers = value; } }
        public List<string> InfoTexts
        { get { return infoTexts; } set { infoTexts = value; } }
        // Board info
        public string BoardName
        { get { return boardName; } set { boardName = value; } }
        public int MapperNumber
        { get { return mapperNumber; } set { mapperNumber = value; } }
        public string PRGSize
        { get { return prgSize; } set { prgSize = value; } }
        public string CHRSize
        { get { return chrSize; } set { chrSize = value; } }
        /// <summary>
        /// The prg size in bytes
        /// </summary>
        public int PRG
        { get { return prg; } set { prg = value; } }
        /// <summary>
        /// The chr size in bytes
        /// </summary>
        public int CHR
        { get { return chr; } set { chr = value; } }
        public bool HasTrainer
        { get { return hasTrainer; } set { hasTrainer = value; } }
        public bool HasSaveRam
        { get { return hasSaveRam; } set { hasSaveRam = value; } }
        public string Mirroring
        { get { return mirroring; } set { mirroring = value; } }
        public bool IsVSSystem
        { get { return isVSSystem; } set { isVSSystem = value; } }
        public bool IsPlaychoice10
        { get { return isPlaychoice10; } set { isPlaychoice10 = value; } }
        public string TvSystem
        { get { return tvSystem; } set { tvSystem = value; } }
    }
}
