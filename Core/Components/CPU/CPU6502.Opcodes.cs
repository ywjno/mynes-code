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

namespace MyNes.Core.CPU
{
    public partial class CPU6502 : IProcesserBase
    {
        private byte M;// Used by read addressing modes
        private byte opcode;

        /*PLA decoding !*/
        private void DecodeInstructionCollection00(byte opcode)
        {
            /*
             * This group is the hardest one. Each instruction should treated differently.
             * Opcode pattern is aaab bb00
             * aaa bits determine the instruction (or flag to use).
             * bbb bits determine the addressing mode.
             * 
             * bbb=5 and aaa < 4 or aaa > 5 is DOP instruction with zpg addressing mode.
             * bbb=7 and aaa < 4 or aaa > 5 is TOP instruction with abs addressing mode.
             * SHY is the only illegal instruction that works here.
             * 
             */
            int aaa = ((opcode >> 5) & 7);
            int bbb = (opcode >> 2) & 7;
            switch (bbb)
            {
                case 0:// Special instructions ...
                    {
                        switch (aaa)
                        {
                            case 0: BRK(); break;
                            case 1: JSR(); break;// addressing mode is done in instruction itself
                            case 2: ImpliedAccumulator(); RTI(); break;
                            case 3: ImpliedAccumulator(); RTS(); break;
                            case 4: Immediate(); break;// ILLEGAL ! set DOP
                            case 5: Immediate(); LDY(); break;
                            case 6: Immediate(); CPY(); break;
                            case 7: Immediate(); CPX(); break;
                        }
                        break;
                    }
                case 1:// Zero page instructions
                    {
                        switch (aaa)
                        {
                            case 0: ZeroPage_R(); break;// ILLEGAL ! set DOP
                            case 1: ZeroPage_R(); BIT(); break;
                            case 2: ZeroPage_R(); break;// ILLEGAL ! set DOP
                            case 3: ZeroPage_R(); break;// ILLEGAL ! set DOP
                            case 4: ZeroPage_W(); STY(); break;
                            case 5: ZeroPage_R(); LDY(); break;
                            case 6: ZeroPage_R(); CPY(); break;
                            case 7: ZeroPage_R(); CPX(); break;
                        }
                        break;
                    }
                case 2: // PHP, PLA ...etc
                    {
                        ImpliedAccumulator();// All implied addressing
                        switch (aaa)
                        {
                            case 0: PHP(); break;
                            case 1: PLP(); break;
                            case 2: PHA(); break;
                            case 3: PLA(); break;
                            case 4: DEY(); break;
                            case 5: TAY(); break;
                            case 6: INY(); break;
                            case 7: INX(); break;
                        }
                        break;
                    }
                case 3:
                    {
                        switch (aaa)
                        {
                            case 0: Absolute_R(); break;// ILLEGAL ! set TOP
                            case 1: Absolute_R(); BIT(); break;
                            case 2: Absolute_W(); PC.VAL = EA.VAL;/*JMP*/ break;
                            case 3: JMP_I(); break;
                            case 4: Absolute_W(); STY(); break;
                            case 5: Absolute_R(); LDY(); break;
                            case 6: Absolute_R(); CPY(); break;
                            case 7: Absolute_R(); CPX(); break;
                        }
                        break;
                    }
                case 4:// Branches (Relative addressing mode, here, addressing mode is done in instruction itself)
                    {
                        switch (aaa)
                        {
                            case 0: Branch(!P.N); break;
                            case 1: Branch(P.N); break;
                            case 2: Branch(!P.V); break;
                            case 3: Branch(P.V); break;
                            case 4: Branch(!P.C); break;
                            case 5: Branch(P.C); break;
                            case 6: Branch(!P.Z); break;
                            case 7: Branch(P.Z); break;
                        }
                        break;
                    }
                case 5:
                    {
                        switch (aaa)
                        {
                            case 4: ZeroPageX_W(); STY(); break;
                            case 5: ZeroPageX_R(); LDY(); break;
                            default: ZeroPageX_R(); break;// ILLEGAL ! set DOP
                        }
                        break;
                    }
                case 6: // CLC, SEC ...etc
                    {
                        ImpliedAccumulator();// All implied addressing
                        switch (aaa)
                        {
                            case 0: P.C = false; break;
                            case 1: P.C = true; break;
                            case 2: P.I = false; break;
                            case 3: P.I = true; break;
                            case 4: TYA(); break;
                            case 5: P.V = false; break;
                            case 6: P.D = false; break;
                            case 7: P.D = true; break;
                        }
                        break;
                    }
                case 7:
                    {
                        switch (aaa)
                        {
                            case 4: Absolute_W(); SHY(); break;// ILLEGAL ! SHY fits here.
                            case 5: AbsoluteX_R(); LDY(); break;
                            default: AbsoluteX_R(); break;// ILLEGAL ! set TOP
                        }
                        break;
                    }
            }
        }
        private void DecodeInstructionCollection01(byte opcode)
        {
            /*
             * Opcode pattern is aaab bb01
             * aaa bits determine the instruction.
             * bbb bits determine the addressing mode.
             * 
             * We have 9 instructions involved here (1 illegal)
             * 
             */
            int aaa = ((opcode >> 5) & 7);
            int bbb = (opcode >> 2) & 7;
            // Addressing mode:
            if (aaa != 4)// not STA instruction. All addressing modes then are read
            {
                switch (bbb)
                {
                    case 0: IndirectX_R(); break;
                    case 1: ZeroPage_R(); break;
                    case 2: Immediate(); break;
                    case 3: Absolute_R(); break;
                    case 4: IndirectY_R(); break;
                    case 5: ZeroPageX_R(); break;
                    case 6: AbsoluteY_R(); break;
                    case 7: AbsoluteX_R(); break;
                }
                // Do instruction
                switch (aaa)
                {
                    case 0: ORA(); break;
                    case 1: AND(); break;
                    case 2: EOR(); break;
                    case 3: ADC(); break;
                    case 5: LDA(); break;
                    case 6: CMP(); break;
                    case 7: SBC(); break;
                }
            }
            else// STA ! This instruction is an exception for this group.
            {

                switch (bbb)
                {
                    case 0: IndirectX_W(); STA(); break;
                    case 1: ZeroPage_W(); STA(); break;
                    // STA impossible with immediate addressing mode, so set DOP. (or nop, do nothing !)
                    // This is the only illegal instruction in 01 group.
                    // To me, cpu should jam here !
                    case 2: Immediate(); break;
                    case 3: Absolute_W(); STA(); break;
                    case 4: IndirectY_W(); STA(); break;
                    case 5: ZeroPageX_W(); STA(); break;
                    case 6: AbsoluteY_W(); STA(); break;
                    case 7: AbsoluteX_W(); STA(); break;
                }
            }
        }
        private void DecodeInstructionCollection10(byte opcode)
        {
            /*
             * Opcode pattern is aaab bb10
             * aaa bits determine the instruction.
             * bbb bits determine the addressing mode.
             * 
             * SHX is the only illegal instruction that work here without problems.
             * bbb= 000 (0) and aaa < 4 causes cpu to JAM; aaa= 4 or aaa > 5 set DOP (aaa= 5 is LDX).
             * (Looks like instruction ASL, ROL, LSR and ROR are forbidden with this addressing mode.)
             * bbb= 100 (4) is illegal addressing mode. Calling it causes cpu to JAM.
             * bbb= 110 (6) and aaa < 4 or aaa > 5 turn instructions ASL, ROL, LSR, ROR, DEC and INC into NOP.
             * 
             */
            int aaa = ((opcode >> 5) & 7);
            int bbb = (opcode >> 2) & 7;
            // Addressing mode (CHECK FORBIDDEN OPCODES FIRST)
            if (bbb == 4)// This addressing mode is forbidden in this group !
            {
                Console.WriteLine("JAM !", DebugCode.Error); // ILLEGAL ! set JAM.
                return;
            }
            else if (bbb == 0)
            {
                if (aaa < 4)
                {
                    // Instruction ASL, ROL, LSR, ROR are forbidden with this addressing mode.
                    ImpliedAccumulator();
                    Console.WriteLine("JAM !", DebugCode.Error);
                    return;// ILLEGAL ! set JAM.
                }
                else if (aaa > 5)
                {
                    // Instruction DEC and INC turned into DOP.
                    Immediate();
                    return;// ILLEGAL ! set DOP.
                }
            }
            else if (bbb == 6)
            {
                if ((aaa < 4) || (aaa > 5))
                {
                    // Instruction ASL, ROL, LSR, ROR, DEC and INC turned into NOP.
                    ImpliedAccumulator();
                    return;// LEGAL ! set NOP. (is NOP a legal instruction ?)
                }
            }
            // Decode
            switch (aaa)
            {
                case 4:// STX, TXA, TXS
                    {
                        switch (bbb)
                        {
                            case 0: Immediate(); break;// ILLEGAL ! set DOP.
                            case 1: ZeroPage_W(); STX(); break;
                            case 2: ImpliedAccumulator(); TXA(); break;
                            case 3: Absolute_W(); STX(); break;
                            case 5: ZeroPageY_W(); STX(); break;
                            case 6: ImpliedAccumulator(); TXS(); break;
                            case 7: Absolute_W(); SHX(); break;// ILLEGAL ! SHX fits here.
                        }
                        break;
                    }
                case 5:// LDX, TAX, TSX
                    {
                        switch (bbb)
                        {
                            case 0: Immediate(); LDX(); break;
                            case 1: ZeroPage_R(); LDX(); break;
                            case 2: ImpliedAccumulator(); TAX(); break;
                            case 3: Absolute_R(); LDX(); break;
                            case 5: ZeroPageY_R(); LDX(); break;
                            case 6: ImpliedAccumulator(); TSX(); break;
                            case 7: AbsoluteY_R(); LDX(); break;
                        }
                        break;
                    }
                default:
                    {
                        switch (bbb)
                        {
                            case 0: Immediate(); break;
                            case 1: ZeroPage_RW(); break;
                            case 2: ImpliedAccumulator(); break;
                            case 3: Absolute_RW(); break;
                            case 5: ZeroPageX_RW(); break;
                            case 7: AbsoluteX_RW(); break;
                        }
                        // Do instruction
                        switch (aaa)
                        {
                            case 0:
                                {
                                    if (bbb == 2)// Implied or Accumulator
                                        ASL_A();
                                    else
                                        ASL_M();
                                    break;
                                }
                            case 1:
                                {
                                    if (bbb == 2)
                                        ROL_A();
                                    else
                                        ROL_M();
                                    break;
                                }
                            case 2:
                                {
                                    if (bbb == 2)
                                        LSR_A();
                                    else
                                        LSR_M();
                                    break;
                                }
                            case 3:
                                {
                                    if (bbb == 2)
                                        ROR_A();
                                    else
                                        ROR_M();
                                    break;
                                }
                            case 6:
                                {
                                    if (bbb == 2)
                                        DEX();
                                    else
                                        DEC();
                                    break;
                                }
                            case 7:
                                {
                                    if (bbb != 2)
                                        INC();
                                    /* else NOP();*/
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        private void DecodeInstructionCollection11(byte opcode)
        {
            /* 
             * Illegal opcodes group !
             * Combined of group cc=01 and group cc=10 (11)
             * 
             * Opcode pattern is aaab bb11
             * aaa bits determine the instruction (or flag to use).
             * bbb bits determine the addressing mode.
             * 
             */
            int aaa = ((opcode >> 5) & 7);
            int bbb = (opcode >> 2) & 7;


            switch (bbb)
            {
                case 0: if (aaa == 5 || aaa == 6) IndirectX_R(); else IndirectX_W(); IllegalInstrucitonGroup1(aaa); break;
                case 1: if (aaa == 5 || aaa == 6) ZeroPage_R(); else ZeroPage_W(); IllegalInstrucitonGroup1(aaa); break;
                case 3: if (aaa == 5 || aaa == 6) Absolute_R(); else Absolute_W(); IllegalInstrucitonGroup1(aaa); break;
                case 5:
                    {
                        if (aaa == 4)
                            ZeroPageY_W();
                        else if (aaa == 5)
                            ZeroPageY_R();
                        else if (aaa == 6)
                            ZeroPageX_RW();
                        else
                            ZeroPageX_W();
                        IllegalInstrucitonGroup1(aaa);
                        break;
                    }
                case 2: Immediate(); IllegalInstrucitonGroup2(aaa); break;

                case 4:
                    {
                        if (aaa == 5)
                            IndirectY_R();
                        else if (aaa == 6)
                            IndirectY_RW();
                        else
                            IndirectY_W();
                        IllegalInstrucitonGroup3(aaa); break;
                    }
                case 7:
                    {
                        if (aaa == 4)
                            AbsoluteY_W();
                        else if (aaa == 5)
                            AbsoluteY_R();
                        else if (aaa == 6)
                            AbsoluteX_RW();
                        else
                            AbsoluteX_W();
                        IllegalInstrucitonGroup3(aaa);
                        break;
                    }

                case 6: IllegalInstrucitonGroup4(aaa); break;
            }
        }
        private void IllegalInstrucitonGroup1(int aaa)
        {
            switch (aaa)
            {
                case 0: SLO(); break;
                case 1: RLA(); break;
                case 2: SRE(); break;
                case 3: RRA(); break;
                case 4: SAX(); break;
                case 5: LAX(); break;
                case 6: DCP(); break;
                case 7: ISC(); break;
            }
        }
        private void IllegalInstrucitonGroup2(int aaa)
        {
            switch (aaa)
            {
                case 0: ANC(); break;
                case 1: ANC(); break;
                case 2: ALR(); break;
                case 3: ARR(); break;
                case 4: XAA(); break;
                case 5: LAX(); break;
                case 6: AXS(); break;
                case 7: SBC(); break;
            }
        }
        private void IllegalInstrucitonGroup3(int aaa)
        {
            switch (aaa)
            {
                case 0: SLO(); break;
                case 1: RLA(); break;
                case 2: SRE(); break;
                case 3: RRA(); break;
                case 4: AHX(); break;
                case 5: LAX(); break;
                case 6: DCP(); break;
                case 7: ISC(); break;
            }
        }
        private void IllegalInstrucitonGroup4(int aaa)
        {
            switch (aaa)
            {
                case 0: AbsoluteY_W(); SLO(); break;
                case 1: AbsoluteY_W(); RLA(); break;
                case 2: AbsoluteY_W(); SRE(); break;
                case 3: AbsoluteY_W(); RRA(); break;
                case 4: AbsoluteY_W(); XAS(); break;
                case 5: AbsoluteY_R(); LAR(); break;
                case 6: AbsoluteY_RW(); DCP(); break;
                case 7: AbsoluteY_W(); ISC(); break;
            }
        }

        #region Addressing modes
        /*
         * _R: read access instructions, set the M value. Some addressing modes will execute 1 extra cycle when page crossed.
         * _W: write access instructions, doesn't set the M value. The instruction should handle write at effective address (EF).
         * _RW: Read-Modify-Write instructions, set the M value and the instruction should handle write at effective address (EF).
         */
        private void IndirectX_R()
        {
            byte temp = Read(PC.VAL); PC.VAL++;// CLock 1
            Read(temp);// Clock 2
            temp += X;

            EA.LOW = Read(temp);// Clock 3
            temp++;

            EA.Hi = Read(temp);// Clock 4

            M = Read(EA.VAL);
        }
        private void IndirectX_W()
        {
            byte temp = Read(PC.VAL); PC.VAL++;// CLock 1
            Read(temp);// Clock 2
            temp += X;

            EA.LOW = Read(temp);// Clock 3
            temp++;

            EA.Hi = Read(temp);// Clock 4
        }
        private void IndirectX_RW()
        {
            byte temp = Read(PC.VAL); PC.VAL++;// CLock 1
            Read(temp);// Clock 2
            temp += X;

            EA.LOW = Read(temp);// Clock 3
            temp++;

            EA.Hi = Read(temp);// Clock 4

            M = Read(EA.VAL);
        }

        private void IndirectY_R()
        {
            byte temp = Read(PC.VAL); PC.VAL++;// CLock 1
            EA.LOW = Read(temp); temp++;// Clock 2
            EA.Hi = Read(temp);// Clock 2

            EA.LOW += Y;

            M = Read(EA.VAL);// Clock 3
            if (EA.LOW < Y)
            {
                EA.Hi++;
                M = Read(EA.VAL);// Clock 4
            }
        }
        private void IndirectY_W()
        {
            byte temp = Read(PC.VAL); PC.VAL++;// CLock 1
            EA.LOW = Read(temp); temp++;// Clock 2
            EA.Hi = Read(temp);// Clock 2

            EA.LOW += Y;

            M = Read(EA.VAL);// Clock 3
            if (EA.LOW < Y)
                EA.Hi++;
        }
        private void IndirectY_RW()
        {
            byte temp = Read(PC.VAL); PC.VAL++;// CLock 1
            EA.LOW = Read(temp); temp++;// Clock 2
            EA.Hi = Read(temp);// Clock 2

            EA.LOW += Y;

            Read(EA.VAL);// Clock 3
            if (EA.LOW < Y)
                EA.Hi++;

            M = Read(EA.VAL);// Clock 4
        }

        private void ZeroPage_R()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            M = Read(EA.VAL);// Clock 2
        }
        private void ZeroPage_W()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
        }
        private void ZeroPage_RW()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            M = Read(EA.VAL);// Clock 2
        }

        private void ZeroPageX_R()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            Read(EA.VAL);// Clock 2
            EA.LOW += X;
            M = Read(EA.VAL);// Clock 3
        }
        private void ZeroPageX_W()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            Read(EA.VAL);// Clock 2
            EA.LOW += X;
        }
        private void ZeroPageX_RW()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            Read(EA.VAL);// Clock 2
            EA.LOW += X;
            M = Read(EA.VAL);// Clock 3
        }

        private void ZeroPageY_R()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            Read(EA.VAL);// Clock 2
            EA.LOW += Y;
            M = Read(EA.VAL);// Clock 3
        }
        private void ZeroPageY_W()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            Read(EA.VAL);// Clock 2
            EA.LOW += Y;
        }
        private void ZeroPageY_RW()
        {
            EA.VAL = Read(PC.VAL); PC.VAL++;// Clock 1
            Read(EA.VAL);// Clock 2
            EA.LOW += Y;
            M = Read(EA.VAL);// Clock 3
        }

        private void Immediate()
        {
            M = Read(PC.VAL); PC.VAL++;// Clock 1
        }

        private void ImpliedAccumulator()
        {
            byte dummy = Read(PC.VAL);
        }

        private void Absolute_R()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2
            M = Read(EA.VAL);// Clock 3
        }
        private void Absolute_W()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2
        }
        private void Absolute_RW()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2
            M = Read(EA.VAL);// Clock 3
        }

        private void AbsoluteX_R()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2

            EA.LOW += X;

            M = Read(EA.VAL);// Clock 3
            if (EA.LOW < X)
            {
                EA.Hi++;
                M = Read(EA.VAL);// Clock 4
            }
        }
        private void AbsoluteX_W()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2

            EA.LOW += X;

            M = Read(EA.VAL);// Clock 3
            if (EA.LOW < X)
                EA.Hi++;
        }
        private void AbsoluteX_RW()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2

            EA.LOW += X;

            Read(EA.VAL);// Clock 3
            if (EA.LOW < X)
                EA.Hi++;

            M = Read(EA.VAL);// Clock 4
        }

        private void AbsoluteY_R()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2

            EA.LOW += Y;

            M = Read(EA.VAL);// Clock 3
            if (EA.LOW < Y)
            {
                EA.Hi++;
                M = Read(EA.VAL);// Clock 4
            }
        }
        private void AbsoluteY_W()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2

            EA.LOW += Y;

            M = Read(EA.VAL);// Clock 3
            if (EA.LOW < Y)
                EA.Hi++;
        }
        private void AbsoluteY_RW()
        {
            EA.LOW = Read(PC.VAL); PC.VAL++;// Clock 1
            EA.Hi = Read(PC.VAL); PC.VAL++;// Clock 2

            EA.LOW += Y;

            M = Read(EA.VAL);// Clock 3
            if (EA.LOW < Y)
                EA.Hi++;

            M = Read(EA.VAL);// Clock 4
        }
        #endregion
        #region Instructions
        private void Branch(bool condition)
        {
            byte data = Read(PC.VAL); PC.VAL++;

            if (condition)
            {
                interrupt_suspend = true;
                Read(PC.VAL);
                PC.LOW += data;
                interrupt_suspend = false;
                if (data >= 0x80)
                {
                    if (PC.LOW >= data)
                    {
                        Read(PC.VAL);
                        PC.Hi--;
                    }
                }
                else
                {
                    if (PC.LOW < data)
                    {
                        Read(PC.VAL);
                        PC.Hi++;
                    }
                }
            }

        }
        private void Push(byte val)
        {
            Write(S.VAL, val);
            S.LOW--;
        }
        private byte Pull()
        {
            S.LOW++;
            return Read(S.VAL);
        }

        private void ADC()
        {
            int t = (A + M + (P.C ? 1 : 0));

            P.V = ((t ^ A) & (t ^ M) & 0x80) != 0;
            P.N = (t & 0x80) != 0;
            P.Z = (t & 0xFF) == 0;
            P.C = (t >> 0x8) != 0;

            A = (byte)(t & 0xFF);
        }
        private void AHX()
        {
            byte data = (byte)((A & X) & 7);
            Write(EA.VAL, data);
        }
        private void ALR()
        {
            A &= M;

            P.C = (A & 0x01) != 0;

            A >>= 1;

            P.N = (A & 0x80) != 0;
            P.Z = A == 0;
        }
        private void ANC()
        {
            A &= M;
            P.N = (A & 0x80) != 0;
            P.Z = A == 0;
            P.C = (A & 0x80) != 0;
        }
        private void AND()
        {
            A &= M;
            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void ARR()
        {
            A = (byte)(((M & A) >> 1) | (P.C ? 0x80 : 0x00));

            P.Z = (A & 0xFF) == 0;
            P.N = (A & 0x80) != 0;
            P.C = (A & 0x40) != 0;
            P.V = ((A << 1 ^ A) & 0x40) != 0;
        }
        private void AXS()
        {
            int temp = (A & X) - M;

            P.N = (temp & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (~temp >> 8) != 0;

            X = (byte)(temp);
        }
        private void ASL_M()
        {
            P.C = (M & 0x80) == 0x80;
            Write(EA.VAL, M);

            M = (byte)((M << 1) & 0xFE);

            Write(EA.VAL, M);

            P.N = (M & 0x80) == 0x80;
            P.Z = (M == 0);
        }
        private void ASL_A()
        {
            P.C = (A & 0x80) == 0x80;

            A = (byte)((A << 1) & 0xFE);

            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void BIT()
        {
            P.N = (M & 0x80) != 0;
            P.V = (M & 0x40) != 0;
            P.Z = (M & A) == 0;
        }
        private void BRK()
        {
            Read(PC.VAL);
            PC.VAL++;

            Push(PC.Hi);
            Push(PC.LOW);

            Push(P.VALB());
            // the vector is detected during φ2 of previous cycle (before push about 2 ppu cycles)
            int v = interrupt_vector;

            interrupt_suspend = true;
            PC.LOW = Read(v++); P.I = true;
            PC.Hi = Read(v);
            interrupt_suspend = false;
        }
        private void CMP()
        {
            int t = A - M;
            P.N = (t & 0x80) == 0x80;
            P.C = (A >= M);
            P.Z = (t == 0);
        }
        private void CPX()
        {
            int t = X - M;
            P.N = (t & 0x80) == 0x80;
            P.C = (X >= M);
            P.Z = (t == 0);
        }
        private void CPY()
        {
            int t = Y - M;
            P.N = (t & 0x80) == 0x80;
            P.C = (Y >= M);
            P.Z = (t == 0);
        }
        private void DCP()
        {
            Write(EA.VAL, M);

            M--;
            Write(EA.VAL, M);

            int data1 = A - M;

            P.N = (data1 & 0x80) != 0;
            P.Z = data1 == 0;
            P.C = (~data1 >> 8) != 0;
        }
        private void DEC()
        {
            Write(EA.VAL, M);
            M--;
            Write(EA.VAL, M);
            P.N = (M & 0x80) == 0x80;
            P.Z = (M == 0);
        }
        private void DEY()
        {
            Y--;
            P.Z = (Y == 0);
            P.N = (Y & 0x80) == 0x80;
        }
        private void DEX()
        {
            X--;
            P.Z = (X == 0);
            P.N = (X & 0x80) == 0x80;
        }
        private void EOR()
        {
            A ^= M;
            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void INC()
        {
            Write(EA.VAL, M);
            M++;
            Write(EA.VAL, M);
            P.N = (M & 0x80) == 0x80;
            P.Z = (M == 0);
        }
        private void INX()
        {
            X++;
            P.Z = (X == 0);
            P.N = (X & 0x80) == 0x80;
        }
        private void INY()
        {
            Y++;
            P.N = (Y & 0x80) == 0x80;
            P.Z = (Y == 0);
        }
        private void ISC()
        {
            byte data = Read(EA.VAL);

            Write(EA.VAL, data);

            data++;

            Write(EA.VAL, data);

            int data1 = data ^ 0xFF;
            int temp = (A + data1 + (P.C ? 1 : 0));

            P.N = (temp & 0x80) != 0;
            P.V = ((temp ^ A) & (temp ^ data1) & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (temp >> 0x8) != 0;
            A = (byte)(temp);
        }
        private void JMP_I()
        {
            EA.LOW = Read(PC.VAL++);
            EA.Hi = Read(PC.VAL++);

            byte latch = Read(EA.VAL);
            EA.LOW++; // only increment the low byte, causing the "JMP ($nnnn)" bug
            PC.Hi = Read(EA.VAL);

            PC.LOW = latch;
        }
        private void JSR()
        {
            /*EF.LOW = Peek(PC.VAL); PC.VAL++;// Clock 1
            EF.Hi = Peek(PC.VAL); //PC.VAL++;

            Push(PC.Hi);
            Push(PC.LOW);

            PC.VAL = EF.VAL;
            Peek(PC.VAL);*/
            EA.LOW = Read(PC.VAL); PC.VAL++;
            EA.Hi = Read(PC.VAL);

            Push(PC.Hi);
            Push(PC.LOW);

            EA.Hi = Read(PC.VAL);
            PC.VAL = EA.VAL;
        }
        private void LAR()
        {
            S.LOW &= M;
            A = S.LOW;
            X = S.LOW;

            P.N = (S.LOW & 0x80) != 0;
            P.Z = (S.LOW & 0xFF) == 0;
        }
        private void LAX()
        {
            X = A = M;

            P.N = (X & 0x80) != 0;
            P.Z = (X & 0xFF) == 0;
        }
        private void LDA()
        {
            A = M;
            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void LDX()
        {
            X = M;
            P.N = (X & 0x80) == 0x80;
            P.Z = (X == 0);
        }
        private void LDY()
        {
            Y = M;
            P.N = (Y & 0x80) == 0x80;
            P.Z = (Y == 0);
        }
        private void LSR_A()
        {
            P.C = (A & 1) == 1;
            A >>= 1;
            P.Z = (A == 0);
            P.N = (A & 0x80) != 0;
        }
        private void LSR_M()
        {
            P.C = (M & 1) == 1;
            Write(EA.VAL, M);
            M >>= 1;

            Write(EA.VAL, M);
            P.Z = (M == 0);
            P.N = (M & 0x80) != 0;
        }
        private void ORA()
        {
            A |= M;
            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void PHA()
        {
            Push(A);
        }
        private void PHP()
        {
            Push(P.VALB());
        }
        private void PLA()
        {
            Read(S.VAL);
            A = Pull();
            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void PLP()
        {
            Read(S.VAL);
            P.VAL = Pull();
        }
        private void RLA()
        {
            byte data = Read(EA.VAL);

            Write(EA.VAL, data);

            byte temp = (byte)((data << 1) | (P.C ? 0x01 : 0x00));

            Write(EA.VAL, temp);

            P.N = (temp & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (data & 0x80) != 0;

            A &= temp;
            P.N = (A & 0x80) != 0;
            P.Z = (A & 0xFF) == 0;
        }
        private void ROL_A()
        {
            byte temp = (byte)((A << 1) | (P.C ? 0x01 : 0x00));

            P.N = (temp & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (A & 0x80) != 0;

            A = temp;
        }
        private void ROL_M()
        {
            Write(EA.VAL, M);
            byte temp = (byte)((M << 1) | (P.C ? 0x01 : 0x00));

            Write(EA.VAL, temp);
            P.N = (temp & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (M & 0x80) != 0;
        }
        private void ROR_A()
        {
            byte temp = (byte)((A >> 1) | (P.C ? 0x80 : 0x00));

            P.N = (temp & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (A & 0x01) != 0;

            A = temp;
        }
        private void ROR_M()
        {
            Write(EA.VAL, M);

            byte temp = (byte)((M >> 1) | (P.C ? 0x80 : 0x00));
            Write(EA.VAL, temp);

            P.N = (temp & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (M & 0x01) != 0;
        }
        private void RRA()
        {
            byte data = Read(EA.VAL);

            Write(EA.VAL, data);

            byte temp = (byte)((data >> 1) | (P.C ? 0x80 : 0x00));

            Write(EA.VAL, temp);

            P.N = (temp & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (data & 0x01) != 0;

            data = temp;
            int temp1 = (A + data + (P.C ? 1 : 0));

            P.N = (temp1 & 0x80) != 0;
            P.V = ((temp1 ^ A) & (temp1 ^ data) & 0x80) != 0;
            P.Z = (temp1 & 0xFF) == 0;
            P.C = (temp1 >> 0x8) != 0;
            A = (byte)(temp1);
        }
        private void RTI()
        {
            Read(S.VAL);
            P.VAL = Pull();

            PC.LOW = Pull();
            PC.Hi = Pull();
        }
        private void RTS()
        {
            Read(S.VAL);
            PC.LOW = Pull();
            PC.Hi = Pull();

            PC.VAL++;

            Read(PC.VAL);
        }
        private void SAX()
        { Write(EA.VAL, (byte)(X & A)); }
        private void SBC()
        {
            M ^= 0xFF;
            int temp = (A + M + (P.C ? 1 : 0));

            P.N = (temp & 0x80) != 0;
            P.V = ((temp ^ A) & (temp ^ M) & 0x80) != 0;
            P.Z = (temp & 0xFF) == 0;
            P.C = (temp >> 0x8) != 0;
            A = (byte)(temp);
        }
        private void SHX()
        {
            byte t = (byte)(X & (EA.Hi + 1));

            Read(EA.VAL);
            EA.LOW += Y;

            if (EA.LOW < Y)
                EA.Hi = t;

            Write(EA.VAL, t);
        }
        private void SHY()
        {
            var t = (byte)(Y & (EA.Hi + 1));

            Read(EA.VAL);
            EA.LOW += X;

            if (EA.LOW < X)
                EA.Hi = t;
            Write(EA.VAL, t);
        }
        private void SLO()
        {
            byte data = Read(EA.VAL);

            P.C = (data & 0x80) != 0;

            Write(EA.VAL, data);

            data <<= 1;

            Write(EA.VAL, data);

            P.N = (data & 0x80) != 0;
            P.Z = (data & 0xFF) == 0;

            A |= data;
            P.N = (A & 0x80) != 0;
            P.Z = (A & 0xFF) == 0;
        }
        private void SRE()
        {
            byte data = Read(EA.VAL);

            P.C = (data & 0x01) != 0;

            Write(EA.VAL, data);

            data >>= 1;

            Write(EA.VAL, data);

            P.N = (data & 0x80) != 0;
            P.Z = (data & 0xFF) == 0;

            A ^= data;
            P.N = (A & 0x80) != 0;
            P.Z = (A & 0xFF) == 0;
        }
        private void STA()
        {
            Write(EA.VAL, A);
        }
        private void STX()
        {
            Write(EA.VAL, X);
        }
        private void STY()
        {
            Write(EA.VAL, Y);
        }
        private void TAX()
        {
            X = A;
            P.N = (X & 0x80) == 0x80;
            P.Z = (X == 0);
        }
        private void TAY()
        {
            Y = A;
            P.N = (Y & 0x80) == 0x80;
            P.Z = (Y == 0);
        }
        private void TSX()
        {
            X = S.LOW;
            P.N = (X & 0x80) != 0;
            P.Z = X == 0;
        }
        private void TXA()
        {
            A = X;
            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void TXS()
        { S.LOW = X; }
        private void TYA()
        {
            A = Y;
            P.N = (A & 0x80) == 0x80;
            P.Z = (A == 0);
        }
        private void XAA()
        {
            A = (byte)(X & M);
            P.N = (A & 0x80) != 0;
            P.Z = (A & 0xFF) == 0;
        }
        private void XAS()
        {
            S.LOW = (byte)(A & X /*& ((dummyVal >> 8) + 1)*/);
            Write(EA.VAL, S.LOW);
        }
        #endregion
    }
}
