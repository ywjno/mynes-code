﻿/* This file is part of My Nes
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
/*DMC sound channel*/
namespace MyNes.Core
{
    public partial class NesEmu
    {
        private static bool DeltaIrqOccur;
        private static bool DMCIrqEnabled;
        private static bool dmc_dmaLooping;
        private static bool dmc_dmaEnabled;
        private static bool dmc_bufferFull = false;
        private static int dmc_dmaAddrRefresh;
        private static int dmc_dmaSizeRefresh;
        private static int dmc_dmaSize;
        private static int dmc_dmaBits = 0;
        private static byte dmc_dmaByte = 0;
        private static int dmc_dmaAddr = 0;
        private static byte dmc_dmaBuffer = 0;
        private static byte dmc_output;
        private static int dmc_cycles;
        private static int dmc_freqTimer;
        // Playback
        private static int dmc_pl_clocks;
        private static int dmc_pl_output_av;
        private static int dmc_pl_output;

        private static void DMCShutdown()
        {

        }
        private static void DMCHardReset()
        {
            DeltaIrqOccur = false;
            DMCIrqEnabled = false;
            dmc_dmaLooping = false;
            dmc_dmaEnabled = false;
            dmc_bufferFull = false;
            dmc_output = 0;
            dmc_dmaAddr = dmc_dmaAddrRefresh = 0xC000;
            dmc_dmaSizeRefresh = 0;
            dmc_dmaSize = 0;
            dmc_dmaBits = 1;
            dmc_dmaByte = 1;
            dmc_dmaAddr = 0;
            dmc_dmaBuffer = 0;
            dmc_freqTimer = 0;
            dmc_cycles = DMCFrequencyTable[systemIndex][dmc_freqTimer];
            dmc_pl_clocks = 0;
        }
        private static void DMCSoftReset()
        {
            DeltaIrqOccur = false;
        }
        private static void DMCClockSingle()
        {
            if (--dmc_cycles <= 0)
            {
                dmc_cycles = DMCFrequencyTable[systemIndex][dmc_freqTimer];
                if (dmc_dmaEnabled)
                {
                    if ((dmc_dmaByte & 0x01) != 0)
                    {
                        if (dmc_output <= 0x7D)
                            dmc_output += 2;
                    }
                    else
                    {
                        if (dmc_output >= 0x02)
                            dmc_output -= 2;
                    }
                    dmc_dmaByte >>= 1;
                }
                dmc_dmaBits--;
                if (dmc_dmaBits == 0)
                {
                    dmc_dmaBits = 8;
                    if (dmc_bufferFull)
                    {
                        dmc_bufferFull = false;
                        dmc_dmaEnabled = true;
                        dmc_dmaByte = dmc_dmaBuffer;
                        // RDY ?
                        if (dmc_dmaSize > 0)
                        {
                            AssertDMCDMA();
                        }
                    }
                    else
                    {
                        dmc_dmaEnabled = false;
                    }
                }
                if (audio_playback_dmc_enabled)
                    dmc_pl_output_av += dmc_output;
                dmc_pl_clocks++;
            }
        }
    }
}
