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
/*DMA section*/
namespace MyNes.Core.CPU
{
    public partial class CPU6502 : IProcesserBase
    {
        private bool oam_dma_current;
        private int oam_dma_cycles;
        private bool dmc_dma_current;
        private byte dmc_dma_cycles;
        public enum RDYType
        {
            PPU, DMC
        }

        public void AssertRDY(RDYType rdy)
        {
            switch (rdy)
            {
                case RDYType.DMC: dmc_dma_current = true; dmc_dma_cycles = 3; break;
                case RDYType.PPU: oam_dma_current = true; oam_dma_cycles = 2; break;
            }
        }
        private void CheckRDY()
        {
            if (oam_dma_current)
            {
                oam_dma_current = false;
                for (int i = 0; i < oam_dma_cycles; i++)
                {
                    NesCore.ClockComponents();
                }
                NesCore.PPU.DoDMA();
                oam_dma_cycles = 0;
            }
            if (dmc_dma_current)
            {
                if (!BUS_RW)
                {
                    //Console.WriteLine(string.Format("DMA WRITE addr=${0:X4}; Cycles = ", BUS_ADDRESS) + dmc_dma_cycles);
                    if (dmc_dma_cycles > 0)
                        dmc_dma_cycles--;
                    //if (dmc_dma_cycles <= 0)
                    //{ dmc_dma_current = false; Console.WriteLine("RDY ignored", DebugCode.Error); }
                }
                else
                {
                    dmc_dma_current = false;

                   // Console.WriteLine(string.Format("DMA addr=${0:X4}; Cycles = ", BUS_ADDRESS) + dmc_dma_cycles, DebugCode.Warning);
                    if (BUS_ADDRESS == 0x4016 || BUS_ADDRESS == 0x4017)
                    {
                        Read(BUS_ADDRESS); dmc_dma_cycles--;
                        for (int i = 0; i < dmc_dma_cycles; i++)
                        {
                            NesCore.ClockComponents();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dmc_dma_cycles; i++)
                        {
                            Read(BUS_ADDRESS);
                        }
                    }
                    dmc_dma_cycles = 0;
                    // Do it !
                    NesCore.APU.DoDMA();
                }
            }
        }
    }
}
