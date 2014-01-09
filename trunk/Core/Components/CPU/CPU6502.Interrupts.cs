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
/*Interrupts section*/
namespace MyNes.Core.CPU
{
    public partial class CPU6502 : IProcesserBase
    {
        private bool NMI_Current;// Represents the current NMI pin (connected to ppu)
        private bool NMI_Old;// Represents the old status if NMI pin, used to generate NMI in raising edge
        private bool NMI_Detected;// Determines that NMI is pending (active when NMI pin become true and was false)
        private int IRGFlags = 0;// Determines that IRQ flags (pins)
        private bool IRQ_Detected;// Determines that IRQ is pending
        private int interrupt_vector;// This is the interrupt vector to jump in the last 2 cycles of BRK/IRQ/NMI
        private bool interrupt_suspend;// This flag suspend interrupt polling
        public enum InterruptType
        {
            NMI = 0,
            APU = 1,
            DMC = 2,
            BOARD = 3
        }

        public void AssertInterrupt(InterruptType type, bool assert)
        {
            switch (type)
            {
                case InterruptType.NMI: NMI_Current = assert; break;
                case InterruptType.APU: 
                case InterruptType.DMC:
                case InterruptType.BOARD:
                    {
                        if (assert)
                            IRGFlags |= (int)type;
                        else
                            IRGFlags &= ~(int)type;
                        break;
                    }
            }
        }
        private void Interrupt()
        {
            Read(PC.VAL);
            Read(PC.VAL);

            Push(PC.Hi);
            Push(PC.LOW);

            Push(P.VAL);
            // the vector is detected during φ2 of previous cycle (before push about 2 ppu cycles)
            int v = interrupt_vector;

            interrupt_suspend = true;
            PC.LOW = Read(v++); P.I = true;
            PC.Hi = Read(v);
            interrupt_suspend = false;
        }
        public void PollInterruptStatus()
        {
            if (!interrupt_suspend)
            {
                // The edge detector, see if nmi occurred. 
                if (NMI_Current & !NMI_Old) // Raising edge, set nmi request
                    NMI_Detected = true;
                NMI_Old = NMI_Current = false;// NMI detected or not, low both lines for this form ___|-|__
                // irq level detector
                IRQ_Detected = (!P.I && IRGFlags != 0);
                // Update interrupt vector !
                interrupt_vector = NMI_Detected ? 0xFFFA : 0xFFFE;
            }
            CheckRDY();
        }
    }
}
