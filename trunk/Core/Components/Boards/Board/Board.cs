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
using System.Linq;
using System.Text;
using MyNes.Core.Database;
using MyNes.Core.GameGenie;
namespace MyNes.Core.Boards
{
    /// <summary>
    /// Emulates the nes board. The board is the cartridge itself.
    /// </summary>
    public abstract partial class Board : INesComponent
    {
        public Board()
        {
            //load information only
            LoadAttributes();
        }
        public Board(byte[] chr, byte[] prg, byte[] trainer, bool isVram)
        {
            this.InitializePRG(prg, trainer);
            this.CHR = chr;
            this.IsVram = isVram;
            this.CHROffset = new int[8];
            this.NMTOffset = new byte[4];
            LoadAttributes();
        }

        private string name;
        private int inesMapperNumber;

        protected void CalculateBankMasks()
        {
            this.CHRMaxSizeInBytesMask = CHR.Length - 1;
            this.CHRSizeInKB = (CHR.Length / 1024);
            this.CHR_01KBBanksCountMask = (CHRSizeInKB / 01) - 1;
            this.CHR_02KBBanksCountMask = (CHRSizeInKB / 02) - 1;
            this.CHR_04KBBanksCountMask = (CHRSizeInKB / 04) - 1;
            this.CHR_08KBBanksCountMask = (CHRSizeInKB / 08) - 1;
        }
        private void LoadAttributes()
        {
            foreach (Attribute attr in Attribute.GetCustomAttributes(this.GetType()))
            {
                if (attr.GetType() == typeof(BoardInfo))
                {
                    this.name = ((BoardInfo)attr).Name;
                    this.inesMapperNumber = ((BoardInfo)attr).InesMapperNumber;
                    this.enabled_ppuA12ToggleTimer = ((BoardInfo)attr).Enabled_ppuA12ToggleTimer;
                    this.ppuA12TogglesOnRaisingEdge = ((BoardInfo)attr).PPUA12TogglesOnRaisingEdge;
                    this.BusConflictEnabled = ((BoardInfo)attr).BusConflict;
                    break;
                }
            }
        }
        public override void Initialize()
        {
            //SwitchMirroring(Mirroring.ModeHorz);
        }

        public override void HardReset()
        {
            NesCore.CPU.BUS_CONFLICTS = this.BusConflictEnabled;
            Console.WriteLine("BUS CONFLICTS = " + this.BusConflictEnabled);
            InitializeVRAM();
            CalculateBankMasks();
            ResetPRGRAM();
            Switch08kCHR(0);
            Switch08KPRG(0, 0x6000);
            Switch32KPRGROM(0);
            SwitchMirroring(NesCore.RomInfo.Mirroring);
            NMT = new byte[4][]
            {
               new byte[0x0400],new byte[0x0400],new byte[0x0400],new byte[0x0400]
               /*Only 2 nmt banks should be used in normal state*/
            };
        }
        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            // SRAM
            for (int i = 0; i < PRG.Length; i++)
            {
                if (PRGRAM[i])
                    stream.Write(PRG[i]);
            }
            // CHR
            if (IsVram)
                stream.Write(CHR);
            for (int i = 0; i < CHROffset.Length; i++)
                stream.Write(CHROffset[i]);
            // NMT
            for (int i = 0; i < NMTOffset.Length; i++)
                stream.Write(NMTOffset[i]);
            for (int i = 0; i < 4; i++)
                stream.Write(NMT[i]);
            // PRG
            for (int i = 0; i < PRGOffsets.Length; i++)
                stream.Write(PRGOffsets[i]);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            // SRAM
            for (int i = 0; i < PRG.Length; i++)
            {
                if (PRGRAM[i])
                    stream.Read(PRG[i], 0, 0x2000);
            }
            if (IsVram)
                stream.Read(CHR, 0, CHR.Length);
            for (int i = 0; i < CHROffset.Length; i++)
                CHROffset[i] = stream.ReadInt32();
            for (int i = 0; i < NMTOffset.Length; i++)
                NMTOffset[i] = stream.ReadByte();
            for (int i = 0; i < 4; i++)
                stream.Read(NMT[i], 0, NMT[i].Length);
            for (int i = 0; i < PRGOffsets.Length; i++)
                PRGOffsets[i] = stream.ReadInt32();
        }

        // Properties
        /// <summary>
        /// Get the board name
        /// </summary>
        public string Name
        { get { return name; } }
        /// <summary>
        /// Get the ines mapper name
        /// </summary>
        public int INESMapperNumber
        { get { return inesMapperNumber; } }
        /// <summary>
        /// Get or set if the game genie is active
        /// </summary>
        public bool IsGameGenieActive
        { get { return isGameGenieActive; } set { isGameGenieActive = value; } }
        /// <summary>
        /// List of activated game genie codes.
        /// </summary>
        public GameGenieCode[] GameGenieCodes
        { get { return gameGenieCodes; } set { gameGenieCodes = value; } }
    }
}
