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
/*
 * Added Tuesday, October 22, 2013 at 1:20 AM
 */
namespace MyNes.Core.CPU
{
    /// <summary>
    /// Emulate the 6502 cpu
    /// </summary>
    public partial class CPU6502 : IProcesserBase
    {
        public override void HardReset()
        {
            base.HardReset();
            // memory
            WRAM = new byte[0x800];
            WRAM[0x0008] = 0xF7;
            WRAM[0x0008] = 0xF7;
            WRAM[0x0009] = 0xEF;
            WRAM[0x000A] = 0xDF;
            WRAM[0x000F] = 0xBF;
            // registers
            A = 0x00;
            X = 0x00;
            Y = 0x00;

            S.LOW = 0xFD;
            S.Hi = 0x01;

            PC.LOW = NesCore.BOARD.ReadPRG(0xFFFC);
            PC.Hi = NesCore.BOARD.ReadPRG(0xFFFD);
            P.VAL = 0;
            P.I = true;
            EA.VAL = 0;
            //interrupts
            NMI_Current = false;
            IRGFlags = 0;
            interrupt_suspend = false;
            //others
            opcode = 0;
        }
        public override void SoftReset()
        {
            P.I = true;
            S.VAL -= 3;

            PC.LOW = Read(0xFFFC);
            PC.Hi = Read(0xFFFD);
        }
        public override void Clock()
        {
            // First clock is to fetch opcode
            opcode = Read(PC.VAL);
            PC.VAL++;
            // Decode the opcode !!
            // Opcode pattern is aaab bbcc
            // cc bits determine instructions group. We have 4 groups of instructions.
            /*switch (opcode & 3)
            {
                case 0: DecodeInstructionCollection00(opcode); break;
                case 1: DecodeInstructionCollection01(opcode); break;
                case 2: DecodeInstructionCollection10(opcode); break;
                case 3: DecodeInstructionCollection11(opcode); break;
            }*/
            #region Decode Opcode
            // PLA emulating is possible, it decreases performance and the result is the same.
            // Switch logic is the fastest way for decoding.
            switch (opcode)
            {
                case 0x00:
                    {
                        BRK();
                        break;
                    }
                case 0x01:
                    {
                        IndirectX_R(); ORA();
                        break;
                    }
                case 0x02:
                    {
                        ImpliedAccumulator();// ILLEGAL ! set JAM.
                        break;
                    }
                case 0x03:
                    {
                        IndirectX_W(); SLO();
                        break;
                    }
                case 0x04:
                    {
                        ZeroPage_R(); // ILLEGAL ! set DOP
                        break;
                    }
                case 0x05:
                    {
                        ZeroPage_R(); ORA();
                        break;
                    }
                case 0x06:
                    {
                        ZeroPage_RW(); ASL_M();
                        break;
                    }
                case 0x07:
                    {
                        ZeroPage_W(); SLO();
                        break;
                    }
                case 0x08:
                    {
                        ImpliedAccumulator(); PHP();
                        break;
                    }
                case 0x09:
                    {
                        Immediate(); ORA();
                        break;
                    }
                case 0x0A:
                    {
                        ImpliedAccumulator(); ASL_A();
                        break;
                    }
                case 0x0B:
                    {
                        Immediate(); ANC();
                        break;
                    }
                case 0x0C:
                    {
                        Absolute_R(); // ILLEGAL ! set TOP 
                        break;
                    }
                case 0x0D:
                    {
                        Absolute_R(); ORA();
                        break;
                    }
                case 0x0E:
                    {
                        Absolute_RW(); ASL_M();
                        break;
                    }
                case 0x0F:
                    {
                        Absolute_W(); SLO();
                        break;
                    }
                case 0x10:
                    {
                        Branch(!P.N);
                        break;
                    }
                case 0x11:
                    {
                        IndirectY_R(); ORA();
                        break;
                    }
                case 0x12:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0x13:
                    {
                        IndirectY_W(); SLO();
                        break;
                    }
                case 0x14:
                    {
                        ZeroPageX_R();// ILLEGAL ! set DOP
                        break;
                    }
                case 0x15:
                    {
                        ZeroPageX_R(); ORA();
                        break;
                    }
                case 0x16:
                    {
                        ZeroPageX_RW(); ASL_M();
                        break;
                    }
                case 0x17:
                    {
                        ZeroPageX_W(); SLO();
                        break;
                    }
                case 0x18:
                    {
                        ImpliedAccumulator(); P.C = false;
                        break;
                    }
                case 0x19:
                    {
                        AbsoluteY_R(); ORA();
                        break;
                    }
                case 0x1A:
                    {
                        ImpliedAccumulator();// LEGAL ! set NOP. (is NOP a legal instruction ?)
                        break;
                    }
                case 0x1B:
                    {
                        AbsoluteY_W(); SLO();
                        break;
                    }
                case 0x1C:
                    {
                        AbsoluteX_R(); // ILLEGAL ! set TOP
                        break;
                    }
                case 0x1D:
                    {
                        AbsoluteX_R(); ORA();
                        break;
                    }
                case 0x1E:
                    {
                        AbsoluteX_RW(); ASL_M();
                        break;
                    }
                case 0x1F:
                    {
                        AbsoluteX_W(); SLO();
                        break;
                    }
                case 0x20:
                    {
                        JSR();
                        break;
                    }
                case 0x21:
                    {
                        IndirectX_R(); AND();
                        break;
                    }
                case 0x22:
                    {
                        ImpliedAccumulator();// ILLEGAL ! set JAM.
                        break;
                    }
                case 0x23:
                    {
                        IndirectX_W(); RLA();
                        break;
                    }
                case 0x24:
                    {
                        ZeroPage_R(); BIT();
                        break;
                    }
                case 0x25:
                    {
                        ZeroPage_R(); AND();
                        break;
                    }
                case 0x26:
                    {
                        ZeroPage_RW(); ROL_M();
                        break;
                    }
                case 0x27:
                    {
                        ZeroPage_W(); RLA();
                        break;
                    }
                case 0x28:
                    {
                        ImpliedAccumulator(); PLP();
                        break;
                    }
                case 0x29:
                    {
                        Immediate(); AND();
                        break;
                    }
                case 0x2A:
                    {
                        ImpliedAccumulator(); ROL_A();
                        break;
                    }
                case 0x2B:
                    {
                        Immediate(); ANC();
                        break;
                    }
                case 0x2C:
                    {
                        Absolute_R(); BIT();
                        break;
                    }
                case 0x2D:
                    {
                        Absolute_R(); AND();
                        break;
                    }
                case 0x2E:
                    {
                        Absolute_RW(); ROL_M();
                        break;
                    }
                case 0x2F:
                    {
                        Absolute_W(); RLA();
                        break;
                    }
                case 0x30:
                    {
                        Branch(P.N);
                        break;
                    }
                case 0x31:
                    {
                        IndirectY_R(); AND();
                        break;
                    }
                case 0x32:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0x33:
                    {
                        IndirectY_W(); RLA();
                        break;
                    }
                case 0x34:
                    {
                        ZeroPageX_R();// ILLEGAL ! set DOP
                        break;
                    }
                case 0x35:
                    {
                        ZeroPageX_R(); AND();
                        break;
                    }
                case 0x36:
                    {
                        ZeroPageX_RW(); ROL_M();
                        break;
                    }
                case 0x37:
                    {
                        ZeroPageX_W(); RLA();
                        break;
                    }
                case 0x38:
                    {
                        ImpliedAccumulator(); P.C = true;
                        break;
                    }
                case 0x39:
                    {
                        AbsoluteY_R(); AND();
                        break;
                    }
                case 0x3A:
                    {
                        ImpliedAccumulator();// LEGAL ! set NOP. (is NOP a legal instruction ?)
                        break;
                    }
                case 0x3B:
                    {
                        AbsoluteY_W(); RLA();
                        break;
                    }
                case 0x3C:
                    {
                        AbsoluteX_R(); // ILLEGAL ! set TOP
                        break;
                    }
                case 0x3D:
                    {
                        AbsoluteX_R(); AND();
                        break;
                    }
                case 0x3E:
                    {
                        AbsoluteX_RW(); ROL_M();
                        break;
                    }
                case 0x3F:
                    {
                        AbsoluteX_W(); RLA();
                        break;
                    }
                case 0x40:
                    {
                        ImpliedAccumulator(); RTI();
                        break;
                    }
                case 0x41:
                    {
                        IndirectX_R(); EOR();
                        break;
                    }
                case 0x42:
                    {
                        ImpliedAccumulator();// ILLEGAL ! set JAM.
                        break;
                    }
                case 0x43:
                    {
                        IndirectX_W(); SRE();
                        break;
                    }
                case 0x44:
                    {
                        ZeroPage_R(); // ILLEGAL ! set DOP
                        break;
                    }
                case 0x45:
                    {
                        ZeroPage_R(); EOR();
                        break;
                    }
                case 0x46:
                    {
                        ZeroPage_RW(); LSR_M();
                        break;
                    }
                case 0x47:
                    {
                        ZeroPage_W(); SRE();
                        break;
                    }
                case 0x48:
                    {
                        ImpliedAccumulator(); PHA();
                        break;
                    }
                case 0x49:
                    {
                        Immediate(); EOR();
                        break;
                    }
                case 0x4A:
                    {
                        ImpliedAccumulator(); LSR_A();
                        break;
                    }
                case 0x4B:
                    {
                        Immediate(); ALR();
                        break;
                    }
                case 0x4C:
                    {
                        Absolute_W(); PC.VAL = EA.VAL;/*JMP*/
                        break;
                    }
                case 0x4D:
                    {
                        Absolute_R(); EOR();
                        break;
                    }
                case 0x4E:
                    {
                        Absolute_RW(); LSR_M();
                        break;
                    }
                case 0x4F:
                    {
                        Absolute_W(); SRE();
                        break;
                    }
                case 0x50:
                    {
                        Branch(!P.V);
                        break;
                    }
                case 0x51:
                    {
                        IndirectY_R(); EOR();
                        break;
                    }
                case 0x52:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0x53:
                    {
                        IndirectY_W(); SRE();
                        break;
                    }
                case 0x54:
                    {
                        ZeroPageX_R();// ILLEGAL ! set DOP
                        break;
                    }
                case 0x55:
                    {
                        ZeroPageX_R(); EOR();
                        break;
                    }
                case 0x56:
                    {
                        ZeroPageX_RW(); LSR_M();
                        break;
                    }
                case 0x57:
                    {
                        ZeroPageX_W(); SRE();
                        break;
                    }
                case 0x58:
                    {
                        ImpliedAccumulator(); P.I = false;
                        break;
                    }
                case 0x59:
                    {
                        AbsoluteY_R(); EOR();
                        break;
                    }
                case 0x5A:
                    {
                        ImpliedAccumulator();// LEGAL ! set NOP. (is NOP a legal instruction ?)
                        break;
                    }
                case 0x5B:
                    {
                        AbsoluteY_W(); SRE();
                        break;
                    }
                case 0x5C:
                    {
                        AbsoluteX_R(); // ILLEGAL ! set TOP
                        break;
                    }
                case 0x5D:
                    {
                        AbsoluteX_R(); EOR();
                        break;
                    }
                case 0x5E:
                    {
                        AbsoluteX_RW(); LSR_M();
                        break;
                    }
                case 0x5F:
                    {
                        AbsoluteX_W(); SRE();
                        break;
                    }
                case 0x60:
                    {
                        ImpliedAccumulator(); RTS();
                        break;
                    }
                case 0x61:
                    {
                        IndirectX_R(); ADC();
                        break;
                    }
                case 0x62:
                    {
                        ImpliedAccumulator();// ILLEGAL ! set JAM.
                        break;
                    }
                case 0x63:
                    {
                        IndirectX_W(); RRA();
                        break;
                    }
                case 0x64:
                    {
                        ZeroPage_R(); // ILLEGAL ! set DOP
                        break;
                    }
                case 0x65:
                    {
                        ZeroPage_R(); ADC();
                        break;
                    }
                case 0x66:
                    {
                        ZeroPage_RW(); ROR_M();
                        break;
                    }
                case 0x67:
                    {
                        ZeroPage_W(); RRA();
                        break;
                    }
                case 0x68:
                    {
                        ImpliedAccumulator(); PLA();
                        break;
                    }
                case 0x69:
                    {
                        Immediate(); ADC();
                        break;
                    }
                case 0x6A:
                    {
                        ImpliedAccumulator(); ROR_A();
                        break;
                    }
                case 0x6B:
                    {
                        Immediate(); ARR();
                        break;
                    }
                case 0x6C:
                    {
                        JMP_I();
                        break;
                    }
                case 0x6D:
                    {
                        Absolute_R(); ADC();
                        break;
                    }
                case 0x6E:
                    {
                        Absolute_RW(); ROR_M();
                        break;
                    }
                case 0x6F:
                    {
                        Absolute_W(); RRA();
                        break;
                    }
                case 0x70:
                    {
                        Branch(P.V);
                        break;
                    }
                case 0x71:
                    {
                        IndirectY_R(); ADC();
                        break;
                    }
                case 0x72:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0x73:
                    {
                        IndirectY_W(); RRA();
                        break;
                    }
                case 0x74:
                    {
                        ZeroPageX_R();// ILLEGAL ! set DOP
                        break;
                    }
                case 0x75:
                    {
                        ZeroPageX_R(); ADC();
                        break;
                    }
                case 0x76:
                    {
                        ZeroPageX_RW(); ROR_M();
                        break;
                    }
                case 0x77:
                    {
                        ZeroPageX_W(); RRA();
                        break;
                    }
                case 0x78:
                    {
                        ImpliedAccumulator(); P.I = true;
                        break;
                    }
                case 0x79:
                    {
                        AbsoluteY_R(); ADC();
                        break;
                    }
                case 0x7A:
                    {
                        ImpliedAccumulator();// LEGAL ! set NOP. (is NOP a legal instruction ?)
                        break;
                    }
                case 0x7B:
                    {
                        AbsoluteY_W(); RRA();
                        break;
                    }
                case 0x7C:
                    {
                        AbsoluteX_R(); // ILLEGAL ! set TOP
                        break;
                    }
                case 0x7D:
                    {
                        AbsoluteX_R(); ADC();
                        break;
                    }
                case 0x7E:
                    {
                        AbsoluteX_RW(); ROR_M();
                        break;
                    }
                case 0x7F:
                    {
                        AbsoluteX_W(); RRA();
                        break;
                    }
                case 0x80:
                    {
                        Immediate(); // ILLEGAL ! set DOP
                        break;
                    }
                case 0x81:
                    {
                        IndirectX_W(); STA();
                        break;
                    }
                case 0x82:
                    {
                        Immediate();// ILLEGAL ! set DOP.
                        break;
                    }
                case 0x83:
                    {
                        IndirectX_W(); SAX();
                        break;
                    }
                case 0x84:
                    {
                        ZeroPage_W(); STY();
                        break;
                    }
                case 0x85:
                    {
                        ZeroPage_W(); STA();
                        break;
                    }
                case 0x86:
                    {
                        ZeroPage_W(); STX();
                        break;
                    }
                case 0x87:
                    {
                        ZeroPage_W(); SAX();
                        break;
                    }
                case 0x88:
                    {
                        ImpliedAccumulator(); DEY();
                        break;
                    }
                case 0x89:
                    {
                        Immediate();// ILLEGAL ! set DOP
                        break;
                    }
                case 0x8A:
                    {
                        ImpliedAccumulator(); TXA();
                        break;
                    }
                case 0x8B:
                    {
                        Immediate(); XAA();
                        break;
                    }
                case 0x8C:
                    {
                        Absolute_W(); STY();
                        break;
                    }
                case 0x8D:
                    {
                        Absolute_W(); STA();
                        break;
                    }
                case 0x8E:
                    {
                        Absolute_W(); STX();
                        break;
                    }
                case 0x8F:
                    {
                        Absolute_W(); SAX();
                        break;
                    }
                case 0x90:
                    {
                        Branch(!P.C);
                        break;
                    }
                case 0x91:
                    {
                        IndirectY_W(); STA();
                        break;
                    }
                case 0x92:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0x93:
                    {
                        IndirectY_W(); AHX();
                        break;
                    }
                case 0x94:
                    {
                        ZeroPageX_W(); STY();
                        break;
                    }
                case 0x95:
                    {
                        ZeroPageX_W(); STA();
                        break;
                    }
                case 0x96:
                    {
                        ZeroPageY_W(); STX();
                        break;
                    }
                case 0x97:
                    {
                        ZeroPageY_W(); SAX();
                        break;
                    }
                case 0x98:
                    {
                        ImpliedAccumulator(); TYA();
                        break;
                    }
                case 0x99:
                    {
                        AbsoluteY_W(); STA();
                        break;
                    }
                case 0x9A:
                    {
                        ImpliedAccumulator(); TXS();
                        break;
                    }
                case 0x9B:
                    {
                        AbsoluteY_W(); XAS();
                        break;
                    }
                case 0x9C:
                    {
                        Absolute_W(); SHY(); // ILLEGAL ! SHY fits here.
                        break;
                    }
                case 0x9D:
                    {
                        AbsoluteX_W(); STA();
                        break;
                    }
                case 0x9E:
                    {
                        Absolute_W(); SHX();// ILLEGAL ! SHX fits here.
                        break;
                    }
                case 0x9F:
                    {
                        AbsoluteY_W(); AHX();
                        break;
                    }
                case 0xA0:
                    {
                        Immediate(); LDY();
                        break;
                    }
                case 0xA1:
                    {
                        IndirectX_R(); LDA();
                        break;
                    }
                case 0xA2:
                    {
                        Immediate(); LDX();
                        break;
                    }
                case 0xA3:
                    {
                        IndirectX_R(); LAX();
                        break;
                    }
                case 0xA4:
                    {
                        ZeroPage_R(); LDY();
                        break;
                    }
                case 0xA5:
                    {
                        ZeroPage_R(); LDA();
                        break;
                    }
                case 0xA6:
                    {
                        ZeroPage_R(); LDX();
                        break;
                    }
                case 0xA7:
                    {
                        ZeroPage_R(); LAX();
                        break;
                    }
                case 0xA8:
                    {
                        ImpliedAccumulator(); TAY();
                        break;
                    }
                case 0xA9:
                    {
                        Immediate(); LDA();
                        break;
                    }
                case 0xAA:
                    {
                        ImpliedAccumulator(); TAX();
                        break;
                    }
                case 0xAB:
                    {
                        Immediate(); LAX();
                        break;
                    }
                case 0xAC:
                    {
                        Absolute_R(); LDY();
                        break;
                    }
                case 0xAD:
                    {
                        Absolute_R(); LDA();
                        break;
                    }
                case 0xAE:
                    {
                        Absolute_R(); LDX();
                        break;
                    }
                case 0xAF:
                    {
                        Absolute_R(); LAX();
                        break;
                    }
                case 0xB0:
                    {
                        Branch(P.C);
                        break;
                    }
                case 0xB1:
                    {
                        IndirectY_R(); LDA();
                        break;
                    }
                case 0xB2:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0xB3:
                    {
                        IndirectY_R(); LAX();
                        break;
                    }
                case 0xB4:
                    {
                        ZeroPageX_R(); LDY();
                        break;
                    }
                case 0xB5:
                    {
                        ZeroPageX_R(); LDA();
                        break;
                    }
                case 0xB6:
                    {
                        ZeroPageY_R(); LDX();
                        break;
                    }
                case 0xB7:
                    {
                        ZeroPageY_R(); LAX();
                        break;
                    }
                case 0xB8:
                    {
                        ImpliedAccumulator(); P.V = false;
                        break;
                    }
                case 0xB9:
                    {
                        AbsoluteY_R(); LDA();
                        break;
                    }
                case 0xBA:
                    {
                        ImpliedAccumulator(); TSX();
                        break;
                    }
                case 0xBB:
                    {
                        AbsoluteY_R(); LAR();
                        break;
                    }
                case 0xBC:
                    {
                        AbsoluteX_R(); LDY();
                        break;
                    }
                case 0xBD:
                    {
                        AbsoluteX_R(); LDA();
                        break;
                    }
                case 0xBE:
                    {
                        AbsoluteY_R(); LDX();
                        break;
                    }
                case 0xBF:
                    {
                        AbsoluteY_R(); LAX();
                        break;
                    }
                case 0xC0:
                    {
                        Immediate(); CPY();
                        break;
                    }
                case 0xC1:
                    {
                        IndirectX_R(); CMP();
                        break;
                    }
                case 0xC2:
                    {
                        Immediate(); // ILLEGAL ! set DOP.
                        break;
                    }
                case 0xC3:
                    {
                        IndirectX_R(); DCP();
                        break;
                    }
                case 0xC4:
                    {
                        ZeroPage_R(); CPY();
                        break;
                    }
                case 0xC5:
                    {
                        ZeroPage_R(); CMP();
                        break;
                    }
                case 0xC6:
                    {
                        ZeroPage_RW(); DEC();
                        break;
                    }
                case 0xC7:
                    {
                        ZeroPage_R(); DCP();
                        break;
                    }
                case 0xC8:
                    {
                        ImpliedAccumulator(); INY();
                        break;
                    }
                case 0xC9:
                    {
                        Immediate(); CMP();
                        break;
                    }
                case 0xCA:
                    {
                        ImpliedAccumulator(); DEX();
                        break;
                    }
                case 0xCB:
                    {
                        Immediate(); AXS();
                        break;
                    }
                case 0xCC:
                    {
                        Absolute_R(); CPY();
                        break;
                    }
                case 0xCD:
                    {
                        Absolute_R(); CMP();
                        break;
                    }
                case 0xCE:
                    {
                        Absolute_RW(); DEC();
                        break;
                    }
                case 0xCF:
                    {
                        Absolute_R(); DCP();
                        break;
                    }
                case 0xD0:
                    {
                        Branch(!P.Z);
                        break;
                    }
                case 0xD1:
                    {
                        IndirectY_R(); CMP();
                        break;
                    }
                case 0xD2:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0xD3:
                    {
                        IndirectY_RW(); DCP();
                        break;
                    }
                case 0xD4:
                    {
                        ZeroPageX_R();// ILLEGAL ! set DOP
                        break;
                    }
                case 0xD5:
                    {
                        ZeroPageX_R(); CMP();
                        break;
                    }
                case 0xD6:
                    {
                        ZeroPageX_RW(); DEC();
                        break;
                    }
                case 0xD7:
                    {
                        ZeroPageX_RW(); DCP();
                        break;
                    }
                case 0xD8:
                    {
                        ImpliedAccumulator(); P.D = false;
                        break;
                    }
                case 0xD9:
                    {
                        AbsoluteY_R(); CMP();
                        break;
                    }
                case 0xDA:
                    {
                        ImpliedAccumulator();// LEGAL ! set NOP. (is NOP a legal instruction ?)
                        break;
                    }
                case 0xDB:
                    {
                        AbsoluteY_RW(); DCP();
                        break;
                    }
                case 0xDC:
                    {
                        AbsoluteX_R(); // ILLEGAL ! set TOP
                        break;
                    }
                case 0xDD:
                    {
                        AbsoluteX_R(); CMP();
                        break;
                    }
                case 0xDE:
                    {
                        AbsoluteX_RW(); DEC();
                        break;
                    }
                case 0xDF:
                    {
                        AbsoluteX_RW(); DCP();
                        break;
                    }
                case 0xE0:
                    {
                        Immediate(); CPX();
                        break;
                    }
                case 0xE1:
                    {
                        IndirectX_R(); SBC();
                        break;
                    }
                case 0xE2:
                    {
                        Immediate(); // ILLEGAL ! set DOP.
                        break;
                    }
                case 0xE3:
                    {
                        IndirectX_W(); ISC();
                        break;
                    }
                case 0xE4:
                    {
                        ZeroPage_R(); CPX();
                        break;
                    }
                case 0xE5:
                    {
                        ZeroPage_R(); SBC();
                        break;
                    }
                case 0xE6:
                    {
                        ZeroPage_RW(); INC();
                        break;
                    }
                case 0xE7:
                    {
                        ZeroPage_W(); ISC();
                        break;
                    }
                case 0xE8:
                    {
                        ImpliedAccumulator(); INX();
                        break;
                    }
                case 0xE9:
                    {
                        Immediate(); SBC();
                        break;
                    }
                case 0xEA:
                    {
                        ImpliedAccumulator();// NOP ...
                        break;
                    }
                case 0xEB:
                    {
                        Immediate(); SBC();
                        break;
                    }
                case 0xEC:
                    {
                        Absolute_R(); CPX();
                        break;
                    }
                case 0xED:
                    {
                        Absolute_R(); SBC();
                        break;
                    }
                case 0xEE:
                    {
                        Absolute_RW(); INC();
                        break;
                    }
                case 0xEF:
                    {
                        Absolute_W(); ISC();
                        break;
                    }
                case 0xF0:
                    {
                        Branch(P.Z);
                        break;
                    }
                case 0xF1:
                    {
                        IndirectY_R(); SBC();
                        break;
                    }
                case 0xF2:
                    {
                        // ILLEGAL ! set JAM.
                        break;
                    }
                case 0xF3:
                    {
                        IndirectY_W(); ISC();
                        break;
                    }
                case 0xF4:
                    {
                        ZeroPageX_R();// ILLEGAL ! set DOP
                        break;
                    }
                case 0xF5:
                    {
                        ZeroPageX_R(); SBC();
                        break;
                    }
                case 0xF6:
                    {
                        ZeroPageX_RW(); INC();
                        break;
                    }
                case 0xF7:
                    {
                        ZeroPageX_W(); ISC();
                        break;
                    }
                case 0xF8:
                    {
                        ImpliedAccumulator(); P.D = true;
                        break;
                    }
                case 0xF9:
                    {
                        AbsoluteY_R(); SBC();
                        break;
                    }
                case 0xFA:
                    {
                        ImpliedAccumulator();// LEGAL ! set NOP. (is NOP a legal instruction ?)
                        break;
                    }
                case 0xFB:
                    {
                        AbsoluteY_W(); ISC();
                        break;
                    }
                case 0xFC:
                    {
                        AbsoluteX_R(); // ILLEGAL ! set TOP
                        break;
                    }
                case 0xFD:
                    {
                        AbsoluteX_R(); SBC();
                        break;
                    }
                case 0xFE:
                    {
                        AbsoluteX_RW(); INC();
                        break;
                    }
                case 0xFF:
                    {
                        AbsoluteX_W(); ISC();
                        break;
                    }
            }
            #endregion
            // Handle interrupts...
            if (NMI_Detected)
            {
                Interrupt();

                NMI_Detected = false;// NMI handled !
            }
            else if (IRQ_Detected)
            {
                Interrupt();
            }
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(WRAM);
            stream.Write(P.VAL);
            stream.Write(PC.VAL);
            stream.Write(S.VAL);
            stream.Write(A);
            stream.Write(X);
            stream.Write(Y);
            stream.Write(EA.VAL);
            stream.Write(M);
            stream.Write(opcode);
            stream.Write(BUS_DATA);
            stream.Write(BUS_ADDRESS);
            stream.Write(BUS_RW);
            stream.Write(NMI_Current);
            stream.Write(NMI_Old);
            stream.Write(NMI_Detected);
            stream.Write(IRGFlags);
            stream.Write(IRQ_Detected);
            stream.Write(interrupt_vector);
            stream.Write(interrupt_suspend);
            stream.Write(oam_dma_current);
            stream.Write(oam_dma_cycles);
            stream.Write(dmc_dma_current);
            stream.Write(dmc_dma_cycles);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            stream.Read(WRAM, 0, 0x800);
            P.VAL = stream.ReadByte();
            PC.VAL = stream.ReadUInt16();
            S.VAL = stream.ReadUInt16();
            A = stream.ReadByte();
            X = stream.ReadByte();
            Y = stream.ReadByte();
            EA.VAL = stream.ReadUInt16();
            M = stream.ReadByte();
            opcode = stream.ReadByte();
            BUS_DATA = stream.ReadByte();
            BUS_ADDRESS = stream.ReadInt32();
            BUS_RW = stream.ReadBoolean();
            NMI_Current = stream.ReadBoolean();
            NMI_Old = stream.ReadBoolean();
            NMI_Detected = stream.ReadBoolean();
            IRGFlags = stream.ReadInt32();
            IRQ_Detected = stream.ReadBoolean();
            interrupt_vector = stream.ReadInt32();
            interrupt_suspend = stream.ReadBoolean();
            oam_dma_current = stream.ReadBoolean();
            oam_dma_cycles = stream.ReadInt32();
            dmc_dma_current = stream.ReadBoolean(); 
            dmc_dma_cycles = stream.ReadByte();
        }
    }
}
