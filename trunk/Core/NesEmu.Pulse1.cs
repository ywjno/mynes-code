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
/*Pulse 1 sound channel*/
namespace MyNes.Core
{
    public partial class NesEmu
    {
        private static int sq1_envelope;
        private static bool sq1_env_startflag;
        private static int sq1_env_counter;
        private static int sq1_env_devider;
        private static bool sq1_length_counter_halt_flag;
        private static bool sq1_constant_volume_flag;
        private static int sq1_volume_decay_time;
        private static bool sq1_duration_haltRequset = false;
        private static byte sq1_duration_counter;
        private static bool sq1_duration_reloadEnabled;
        private static byte sq1_duration_reload = 0;
        private static bool sq1_duration_reloadRequst = false;

        private static int sq1_dutyForm;
        private static int sq1_dutyStep;
        private static int sq1_sweepDeviderPeriod = 0;
        private static int sq1_sweepShiftCount = 0;
        private static int sq1_sweepCounter = 0;
        private static bool sq1_sweepEnable = false;
        private static bool sq1_sweepReload = false;
        private static bool sq1_sweepNegateFlag = false;
        private static int sq1_frequency;
        private static byte sq1_output;
        private static int sq1_sweep;
        private static int sq1_cycles;

        private static void Sq1Shutdown()
        {

        }
        private static void Sq1HardReset()
        {
            sq1_envelope = 0;
            sq1_env_startflag = false;
            sq1_env_counter = 0;
            sq1_env_devider = 0;
            sq1_length_counter_halt_flag = false;
            sq1_constant_volume_flag = false;
            sq1_volume_decay_time = 0;
            sq1_duration_haltRequset = false;
            sq1_duration_counter = 0;
            sq1_duration_reloadEnabled = false;
            sq1_duration_reload = 0;
            sq1_duration_reloadRequst = false;
            sq1_dutyForm = 0;
            sq1_dutyStep = 0;
            sq1_sweepDeviderPeriod = 0;
            sq1_sweepShiftCount = 0;
            sq1_sweepCounter = 0;
            sq1_sweepEnable = false;
            sq1_sweepReload = false;
            sq1_sweepNegateFlag = false;
            sq1_frequency = 0;
            sq1_output = 0;
            sq1_sweep = 0;
            sq1_cycles = 0;
        }
        private static bool Sq1IsValidFrequency()
        {
            return (sq1_frequency >= 0x8) && ((sq1_sweepNegateFlag) || (((sq1_frequency + (sq1_frequency >> sq1_sweepShiftCount))
                & 0x800) == 0));
        }
        private static void Sq1ClockEnvelope()
        {
            if (sq1_env_startflag)
            {
                sq1_env_startflag = false;
                sq1_env_counter = 0xF;
                sq1_env_devider = sq1_volume_decay_time + 1;
            }
            else
            {
                if (sq1_env_devider > 0)
                    sq1_env_devider--;
                else
                {
                    sq1_env_devider = sq1_volume_decay_time + 1;
                    if (sq1_env_counter > 0)
                        sq1_env_counter--;
                    else if (sq1_length_counter_halt_flag)
                        sq1_env_counter = 0xF;
                }
            }
            sq1_envelope = sq1_constant_volume_flag ? sq1_volume_decay_time : sq1_env_counter;
        }
        private static void Sq1ClockLengthCounter()
        {
            if (!sq1_length_counter_halt_flag)
            {
                if (sq1_duration_counter > 0)
                {
                    sq1_duration_counter--;
                }
            }

            sq1_sweepCounter--;
            if (sq1_sweepCounter == 0)
            {
                sq1_sweepCounter = sq1_sweepDeviderPeriod + 1;
                if (sq1_sweepEnable && (sq1_sweepShiftCount > 0) && Sq1IsValidFrequency())
                {
                    sq1_sweep = sq1_frequency >> sq1_sweepShiftCount;
                    sq1_frequency += sq1_sweepNegateFlag ? ~sq1_sweep : sq1_sweep;
                }
            }
            if (sq1_sweepReload)
            {
                sq1_sweepReload = false;
                sq1_sweepCounter = sq1_sweepDeviderPeriod + 1;
            }
        }
        private static void Sq1ClockSingle()
        {
            sq1_length_counter_halt_flag = sq1_duration_haltRequset;
            if (isClockingDuration && sq1_duration_counter > 0)
                sq1_duration_reloadRequst = false;
            if (sq1_duration_reloadRequst)
            {
                if (sq1_duration_reloadEnabled)
                    sq1_duration_counter = sq1_duration_reload;
                sq1_duration_reloadRequst = false;
            }

            if (sq1_frequency == 0)
            {
                sq1_output = 0;
                return;
            }
            if (sq1_cycles > 0)
                sq1_cycles--;
            else
            {
                sq1_cycles = (sq1_frequency << 1) + 2;
                sq1_dutyStep--;
                if (sq1_dutyStep < 0)
                    sq1_dutyStep = 0x7;
                if (sq1_duration_counter > 0 && Sq1IsValidFrequency())
                    sq1_output = (byte)(PulseDutyForms[sq1_dutyForm][sq1_dutyStep] * sq1_envelope);
                else
                    sq1_output = 0;
            }
        }
    }
}
