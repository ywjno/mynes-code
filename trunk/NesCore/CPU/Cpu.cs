using System;

namespace MyNes.Core
{
    public class Cpu : ProcessorBase
    {
        private Action[] codes;
        private Action[] modes;
        private Flags sr; // Processor Status
        private Register aa;
        private Register pc; // Program Counter
        private Register sp; // Stack Pointer
        private byte a; // Accumulator
        private byte x; // Index Register X
        private byte y; // Index Register Y
        private byte code;

        //interrupts
        private bool NmiRequest;
        private bool SetNmiRequest;
        private bool ExeIRQ;
        private int irqRequestFlags;
        private bool SetMapperIrqRequest;

        public Cpu(TimingInfo.Cookie cookie)
            : base(cookie)
        {
            timing.period = cookie.Master;
            timing.single = cookie.Cpu;
        }

        #region Helpers

        private void Branch(bool flag)
        {
            if (flag)
            {
                ushort addr = (ushort)(pc.Value + (sbyte)NesCore.CpuMemory[aa.Value++]);

                if ((addr & 0xFF00) != (pc.Value & 0xFF00))
                    Clock(2);
                else
                    Clock();

                pc.Value = addr;
            }
        }
        public void Clock(int cycles = 1)
        {
            if (NesCore.ON)
            {
                NesCore.Apu.Update();
                NesCore.Ppu.Update();
            }
        }
        private byte Pull()
        {
            sp.LoByte++; Clock();
            return NesCore.CpuMemory[sp.Value | 0x0100];
        }
        private void Push(int data)
        {
            NesCore.CpuMemory[sp.Value | 0x0100] = (byte)data;
            sp.LoByte--;
        }

        #endregion

        #region Codes

        private void OpAdc()
        {
            byte data = NesCore.CpuMemory[aa.Value];
            int temp = (a + data + (sr.c ? 1 : 0));

            sr.n = (temp & 0x80) != 0;
            sr.v = ((temp ^ a) & (temp ^ data) & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (temp >> 0x8) != 0;
            a = (byte)(temp);
        }
        private void OpAnd()
        {
            a &= NesCore.CpuMemory[aa.Value];
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpAsl()
        {
            byte data = NesCore.CpuMemory[aa.Value];

            sr.c = (data & 0x80) != 0;

            NesCore.CpuMemory[aa.Value] = data;

            data <<= 1;

            NesCore.CpuMemory[aa.Value] = data;

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        }
        private void OpAsl_A()
        {
            //byte data = NesCore.CpuMemory[aa.Value];

            sr.c = (a & 0x80) != 0;

            //NesCore.CpuMemory[aa.Value] = data;

            a <<= 1;
            Clock();

            //NesCore.CpuMemory[aa.Value] = data;

            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpBcc() { Branch(!sr.c); }
        private void OpBcs() { Branch(sr.c); }
        private void OpBeq() { Branch(sr.z); }
        private void OpBit()
        {
            var data = NesCore.CpuMemory[aa.Value];

            sr.n = (data & 0x80) != 0;
            sr.v = (data & 0x40) != 0;
            sr.z = (data & a) == 0;
        }
        private void OpBmi() { Branch(sr.n); }
        private void OpBne() { Branch(!sr.z); }
        private void OpBpl() { Branch(!sr.n); }
        private void OpBrk()
        {
            pc.Value++; Clock();

            Push(pc.HiByte);
            Push(pc.LoByte);
            Push(sr | 0x10);

            sr.i = true;

            if (NmiRequest)
            {
                NmiRequest = false;
                SetNmiRequest = false;
                pc.LoByte = NesCore.CpuMemory[0xFFFA];
                pc.HiByte = NesCore.CpuMemory[0xFFFB];
            }
            else
            {
                pc.LoByte = NesCore.CpuMemory[0xFFFE];
                pc.HiByte = NesCore.CpuMemory[0xFFFF];
            }
        }
        private void OpBvc() { Branch(!sr.v); }
        private void OpBvs() { Branch(sr.v); }
        private void OpClc() { sr.c = false; }
        private void OpCld() { sr.d = false; }
        private void OpCli() { sr.i = false; }
        private void OpClv() { sr.v = false; }
        private void OpCmp()
        {
            int data = (a - NesCore.CpuMemory[aa.Value]);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
            sr.c = (~data >> 8) != 0;
        }
        private void OpCpx()
        {
            int data = (x - NesCore.CpuMemory[aa.Value]);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
            sr.c = (~data >> 8) != 0;
        }
        private void OpCpy()
        {
            int data = (y - NesCore.CpuMemory[aa.Value]);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
            sr.c = (~data >> 8) != 0;
        }
        private void OpDec()
        {
            byte data = NesCore.CpuMemory[aa.Value];

            NesCore.CpuMemory[aa.Value] = data;

            data--;

            NesCore.CpuMemory[aa.Value] = data;

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        }
        private void OpDex()
        {
            x--;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpDey()
        {
            y--;
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpEor()
        {
            a ^= NesCore.CpuMemory[aa.Value];
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpInc()
        {
            byte data = NesCore.CpuMemory[aa.Value];

            NesCore.CpuMemory[aa.Value] = data;

            data++;

            NesCore.CpuMemory[aa.Value] = data;

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        }
        private void OpInx()
        {
            x++;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpIny()
        {
            y++;
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpJmp()
        {
            pc.Value = aa.Value; Clock();
        }
        private void OpJsr()
        {
            pc.Value--; Clock();

            Push(pc.HiByte);
            Push(pc.LoByte);

            pc.Value = aa.Value; Clock();
        }
        private void OpLda()
        {
            a = NesCore.CpuMemory[aa.Value];
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpLdx()
        {
            x = NesCore.CpuMemory[aa.Value];
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpLdy()
        {
            y = NesCore.CpuMemory[aa.Value];
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpLsr()
        {
            byte data = NesCore.CpuMemory[aa.Value];

            sr.c = (data & 0x01) != 0;

            NesCore.CpuMemory[aa.Value] = data;

            data >>= 1;

            NesCore.CpuMemory[aa.Value] = data;

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        } 
        private void OpLsr_A()
        {
           // byte data = NesCore.CpuMemory[aa.Value];

            sr.c = (a & 0x01) != 0;

            // NesCore.CpuMemory[aa.Value] = data;

            a >>= 1; 
            Clock();

           // NesCore.CpuMemory[aa.Value] = data;

            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpNop()
        {
        }
        private void OpOra()
        {
            a |= NesCore.CpuMemory[aa.Value];
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpPha()
        {
            Push(a);
        }
        private void OpPhp()
        {
            Push(sr | 0x10);
        }
        private void OpPla()
        {
            a = Pull();
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpPlp()
        {
            sr = Pull();
        }
        private void OpRol()
        {
            byte data = NesCore.CpuMemory[aa.Value];

            NesCore.CpuMemory[aa.Value] = data;

            byte temp = (byte)((data << 1) | (sr.c ? 0x01 : 0x00));

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (data & 0x80) != 0;

            NesCore.CpuMemory[aa.Value] = temp;
        }
        private void OpRol_A() 
        {
           // byte data = NesCore.CpuMemory[aa.Value];

           // NesCore.CpuMemory[aa.Value] = data;

            byte temp = (byte)((a << 1) | (sr.c ? 0x01 : 0x00));

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (a & 0x80) != 0;

            NesCore.CpuMemory[aa.Value] = temp;
        }
        private void OpRor()
        {
            byte data = NesCore.CpuMemory[aa.Value];

            NesCore.CpuMemory[aa.Value] = data;

            byte temp = (byte)((data >> 1) | (sr.c ? 0x80 : 0x00));

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (data & 0x01) != 0;

            NesCore.CpuMemory[aa.Value] = temp;
        }  
        private void OpRor_A() 
        {
            // byte data = NesCore.CpuMemory[aa.Value];

           //  NesCore.CpuMemory[aa.Value] = data;

            byte temp = (byte)((a >> 1) | (sr.c ? 0x80 : 0x00));

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (a & 0x01) != 0;

            NesCore.CpuMemory[aa.Value] = temp;
        }
        private void OpRti()
        {
            sr = Pull();
            pc.LoByte = Pull();
            pc.HiByte = Pull();

            ExeIRQ = (!sr.i && (irqRequestFlags != 0));
        }
        private void OpRts()
        {
            pc.LoByte = Pull();
            pc.HiByte = Pull();

            pc.Value++; Clock();
        }
        private void OpSbc()
        {
            int data = NesCore.CpuMemory[aa.Value] ^ 0xFF;
            int temp = (a + data + (sr.c ? 1 : 0));

            sr.n = (temp & 0x80) != 0;
            sr.v = ((temp ^ a) & (temp ^ data) & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (temp >> 0x8) != 0;
            a = (byte)(temp);
        }
        private void OpSec() { sr.c = true; }
        private void OpSed() { sr.d = true; }
        private void OpSei() { sr.i = true; }
        private void OpSta() { NesCore.CpuMemory[aa.Value] = a; }
        private void OpStx() { NesCore.CpuMemory[aa.Value] = x; }
        private void OpSty() { NesCore.CpuMemory[aa.Value] = y; }
        private void OpTax()
        {
            x = a;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpTay()
        {
            y = a;
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpTsx()
        {
            x = sp.LoByte;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpTxa()
        {
            a = x;
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpTxs()
        {
            sp.LoByte = x;
        }
        private void OpTya()
        {
            a = y;
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }

        /* Unofficial Codes */
        private void OpAnc()
        {
            a &= NesCore.CpuMemory[aa.Value];
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
            sr.c = (a & 0x80) != 0;
        }
        private void OpArr()
        {
            a = (byte)(((NesCore.CpuMemory[aa.Value] & a) >> 1) | (sr.c ? 0x80 : 0x00));

            sr.z = (a & 0xFF) == 0;
            sr.n = (a & 0x80) != 0;
            sr.c = (a & 0x40) != 0;
            sr.v = ((a << 1 ^ a) & 0x40) != 0;
        }
        private void OpAlr()
        {
            a &= NesCore.CpuMemory[aa.Value];

            sr.c = (a & 0x01) != 0;

            a >>= 1;

            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpAhx()
        {
            byte data = (byte)((a & x) & 7);

            NesCore.CpuMemory[aa.Value] = data;
        }
        private void OpAxs()
        {
            var temp = ((a & x) - NesCore.CpuMemory[aa.Value]);

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (~temp >> 8) != 0;

            x = (byte)(temp);
        }
        private void OpDcp()
        {
            OpDec();
            OpCmp();
        }
        private void OpDop() { }
        private void OpIsc()
        {
            OpInc();
            OpSbc();
        }
        private void OpJam()
        {
            pc.Value++; Clock();
        }
        private void OpLar()
        {
            sp.LoByte &= NesCore.CpuMemory[aa.Value];
            a = sp.LoByte;
            x = sp.LoByte;

            sr.n = (sp.LoByte & 0x80) != 0;
            sr.z = (sp.LoByte & 0xFF) == 0;
        }
        private void OpLax()
        {
            OpLda();
            OpLdx();
        }
        private void OpRla()
        {
            OpRol();
            OpAnd();
        }
        private void OpRra()
        {
            OpRor();
            OpAdc();
        }
        private void OpSax()
        {
            NesCore.CpuMemory[aa.Value] = (byte)(x & a);
        }
        private void OpShx() { }
        private void OpShy() { }
        private void OpSlo()
        {
            OpAsl();
            OpOra();
        }
        private void OpSre()
        {
            OpLsr();
            OpEor();
        }
        private void OpTop() { }
        private void OpXaa()
        {
            a = (byte)(x & NesCore.CpuMemory[aa.Value]);
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpXas()
        {
            sp.LoByte = (byte)(a & x & ((NesCore.CpuMemory[aa.Value] >> 8) + 1));

            NesCore.CpuMemory[aa.Value] = sp.LoByte;
        }

        #endregion
        #region Modes

        private void AmAbs()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++]; 
            aa.HiByte = NesCore.CpuMemory[pc.Value++]; 
        }
        private void AmAbX()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++]; 
            aa.HiByte = NesCore.CpuMemory[pc.Value++]; 

            aa.LoByte += x;

            if (aa.LoByte < x)
            {
                byte dummy = NesCore.CpuMemory[aa.Value]; 
                aa.HiByte++;
            }
        }
        private void AmAbX_C()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++]; 
            aa.HiByte = NesCore.CpuMemory[pc.Value++]; 

            aa.LoByte += x;

            if (aa.LoByte < x)
            {
                byte dummy = NesCore.CpuMemory[aa.Value]; 
                aa.HiByte++;
                Clock();
            }
        }
        private void AmAbX_D()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++]; 
            aa.HiByte = NesCore.CpuMemory[pc.Value++]; 

            aa.LoByte += x;

            byte dummy = NesCore.CpuMemory[aa.Value]; 
            aa.HiByte++;
            Clock();
        }
        private void AmAbY()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++]; 
            aa.HiByte = NesCore.CpuMemory[pc.Value++]; 

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa.Value];
                aa.HiByte++;
            }
        }
        private void AmAbY_C()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++]; 
            aa.HiByte = NesCore.CpuMemory[pc.Value++]; 

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa.Value]; 
                aa.HiByte++;
                Clock();
            }
        }
        private void AmAcc() { }
        private void AmImm()
        {
            aa.Value = pc.Value++; Clock();
        }
        private void AmImp() { }
        private void AmInd()
        {
            aa.LoByte = NesCore.CpuMemory[pc.Value++]; 
            aa.HiByte = NesCore.CpuMemory[pc.Value++]; 

            byte addr = NesCore.CpuMemory[aa.Value++]; 

            aa.LoByte++; // only increment the low byte, causing the "JMP ($nnnn)" bug

            aa.HiByte = NesCore.CpuMemory[aa.Value++]; 
            aa.LoByte = addr;
        }
        private void AmInX()
        {
            byte addr = NesCore.CpuMemory[pc.Value++]; 

            addr += x;

            aa.LoByte = NesCore.CpuMemory[addr++]; 
            aa.HiByte = NesCore.CpuMemory[addr++]; 
        }
        private void AmInY()
        {
            byte addr = NesCore.CpuMemory[pc.Value++]; 
            aa.LoByte = NesCore.CpuMemory[addr++]; 
            aa.HiByte = NesCore.CpuMemory[addr++]; 

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa.Value]; 
                aa.HiByte++;
            }
        }
        private void AmInY_C()
        {
            byte addr = NesCore.CpuMemory[pc.Value++];
            aa.LoByte = NesCore.CpuMemory[addr++]; 
            aa.HiByte = NesCore.CpuMemory[addr++]; 

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                byte dummy = NesCore.CpuMemory[aa.Value]; 
                aa.HiByte++;
                Clock();
            }
        }
        private void AmZpg()
        {
            aa.Value = NesCore.CpuMemory[pc.Value++];
        }
        private void AmZpX()
        {
            aa.Value = NesCore.CpuMemory[pc.Value++]; 

            aa.LoByte += x;
        }
        private void AmZpY()
        {
            aa.Value = NesCore.CpuMemory[pc.Value++];

            aa.LoByte += y;
        }

        #endregion

        public void Initialize()
        {
            Console.WriteLine("Initializing CPU...");

            modes = new Action[256]
            {
                // 0   1        2      3      4      5      6      7      8      9        A      B      C        D         E       F
                AmImp, AmInX,   AmImp, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmAcc, AmImm, AmAbs,   AmAbs,   AmAbs,   AmAbs, // 0
                AmImm, AmInY_C, AmImp, AmInY, AmZpX, AmZpX, AmZpX, AmZpX, AmImp, AmAbY_C, AmImp, AmAbY, AmAbX_C, AmAbX_C, AmAbX,   AmAbX, // 1
                AmAbs, AmInX,   AmImp, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmAcc, AmImm, AmAbs,   AmAbs,   AmAbs,   AmAbs, // 2
                AmImm, AmInY_C, AmImp, AmInY, AmZpX, AmZpX, AmZpX, AmZpX, AmImp, AmAbY_C, AmImp, AmAbY, AmAbX_C, AmAbX_C, AmAbX_D, AmAbX, // 3
                AmImp, AmInX,   AmImp, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmAcc, AmImm, AmAbs,   AmAbs,   AmAbs,   AmAbs, // 4
                AmImm, AmInY_C, AmImp, AmInY, AmZpX, AmZpX, AmZpX, AmZpX, AmImp, AmAbY_C, AmImp, AmAbY, AmAbX_C, AmAbX_C, AmAbX,   AmAbX, // 5
                AmImp, AmInX,   AmImp, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmAcc, AmImm, AmInd,   AmAbs,   AmAbs,   AmAbs, // 6
                AmImm, AmInY_C, AmImp, AmInY, AmZpX, AmZpX, AmZpX, AmZpX, AmImp, AmAbY_C, AmImp, AmAbY, AmAbX_C, AmAbX_C, AmAbX,   AmAbX, // 7
                AmImm, AmInX,   AmImm, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmImp, AmImm, AmAbs,   AmAbs,   AmAbs,   AmAbs, // 8
                AmImm, AmInY,   AmImp, AmInY, AmZpX, AmZpX, AmZpY, AmZpY, AmImp, AmAbY,   AmImp, AmAbY, AmAbX,   AmAbX,   AmAbY,   AmAbY, // 9
                AmImm, AmInX,   AmImm, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmImp, AmImm, AmAbs,   AmAbs,   AmAbs,   AmAbs, // A
                AmImm, AmInY_C, AmImp, AmInY, AmZpX, AmZpX, AmZpY, AmZpY, AmImp, AmAbY_C, AmImp, AmAbY, AmAbX_C, AmAbX_C, AmAbY_C, AmAbY, // B
                AmImm, AmInX,   AmImm, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmImp, AmImm, AmAbs,   AmAbs,   AmAbs,   AmAbs, // C
                AmImm, AmInY_C, AmImp, AmInY, AmZpX, AmZpX, AmZpX, AmZpX, AmImp, AmAbY_C, AmImp, AmAbY, AmAbX_C, AmAbX_C, AmAbX,   AmAbX, // D
                AmImm, AmInX,   AmImm, AmInX, AmZpg, AmZpg, AmZpg, AmZpg, AmImp, AmImm,   AmImp, AmImm, AmAbs,   AmAbs,   AmAbs,   AmAbs, // E
                AmImm, AmInY_C, AmImp, AmInY, AmZpX, AmZpX, AmZpX, AmZpX, AmImp, AmAbY_C, AmImp, AmAbY, AmAbX_C, AmAbX_C, AmAbX,   AmAbX, // F
            };
            codes = new Action[256]
            {
                // 0   1      2      3      4      5      6      7      8      9      A          B      C      D      E      F
                OpBrk, OpOra, OpJam, OpSlo, OpDop, OpOra, OpAsl, OpSlo, OpPhp, OpOra, OpAsl_A, OpAnc, OpTop, OpOra, OpAsl, OpSlo, // 0
                OpBpl, OpOra, OpJam, OpSlo, OpDop, OpOra, OpAsl, OpSlo, OpClc, OpOra, OpNop,     OpSlo, OpTop, OpOra, OpAsl, OpSlo, // 1
                OpJsr, OpAnd, OpJam, OpRla, OpBit, OpAnd, OpRol, OpRla, OpPlp, OpAnd, OpRol_A, OpAnc, OpBit, OpAnd, OpRol, OpRla, // 2
                OpBmi, OpAnd, OpJam, OpRla, OpDop, OpAnd, OpRol, OpRla, OpSec, OpAnd, OpNop,     OpRla, OpTop, OpAnd, OpRol, OpRla, // 3
                OpRti, OpEor, OpJam, OpSre, OpDop, OpEor, OpLsr, OpSre, OpPha, OpEor, OpLsr_A, OpAlr, OpJmp, OpEor, OpLsr, OpSre, // 4
                OpBvc, OpEor, OpJam, OpSre, OpDop, OpEor, OpLsr, OpSre, OpCli, OpEor, OpNop,     OpSre, OpTop, OpEor, OpLsr, OpSre, // 5
                OpRts, OpAdc, OpJam, OpRra, OpDop, OpAdc, OpRor, OpRra, OpPla, OpAdc, OpRor_A, OpArr, OpJmp, OpAdc, OpRor, OpRra, // 6
                OpBvs, OpAdc, OpJam, OpRra, OpDop, OpAdc, OpRor, OpRra, OpSei, OpAdc, OpNop,     OpRra, OpTop, OpAdc, OpRor, OpRra, // 7
                OpDop, OpSta, OpDop, OpSax, OpSty, OpSta, OpStx, OpSax, OpDey, OpDop, OpTxa,     OpXaa, OpSty, OpSta, OpStx, OpSax, // 8
                OpBcc, OpSta, OpJam, OpAhx, OpSty, OpSta, OpStx, OpSax, OpTya, OpSta, OpTxs,     OpXas, OpShy, OpSta, OpShx, OpAhx, // 9
                OpLdy, OpLda, OpLdx, OpLax, OpLdy, OpLda, OpLdx, OpLax, OpTay, OpLda, OpTax,     OpLax, OpLdy, OpLda, OpLdx, OpLax, // A
                OpBcs, OpLda, OpJam, OpLax, OpLdy, OpLda, OpLdx, OpLax, OpClv, OpLda, OpTsx,     OpLar, OpLdy, OpLda, OpLdx, OpLax, // B
                OpCpy, OpCmp, OpDop, OpDcp, OpCpy, OpCmp, OpDec, OpDcp, OpIny, OpCmp, OpDex,     OpAxs, OpCpy, OpCmp, OpDec, OpDcp, // C
                OpBne, OpCmp, OpJam, OpDcp, OpDop, OpCmp, OpDec, OpDcp, OpCld, OpCmp, OpNop,     OpDcp, OpTop, OpCmp, OpDec, OpDcp, // D
                OpCpx, OpSbc, OpDop, OpIsc, OpCpx, OpSbc, OpInc, OpIsc, OpInx, OpSbc, OpNop,     OpSbc, OpCpx, OpSbc, OpInc, OpIsc, // E
                OpBeq, OpSbc, OpJam, OpIsc, OpDop, OpSbc, OpInc, OpIsc, OpSed, OpSbc, OpNop,     OpIsc, OpTop, OpSbc, OpInc, OpIsc, // F
            };

            NesCore.CpuMemory[0x08] = 0xF7;
            NesCore.CpuMemory[0x09] = 0xEF;
            NesCore.CpuMemory[0x0A] = 0xDF;
            NesCore.CpuMemory[0x0F] = 0xBF;

            a = 0x00;
            x = 0x00;
            y = 0x00;

            sp.Value = 0x1FD;

            pc.LoByte = NesCore.CpuMemory[0xFFFC];
            pc.HiByte = NesCore.CpuMemory[0xFFFD];

            sr = 0x34;

            Console.WriteLine("CPU Initialized!", DebugCode.Good);
        }
        public void Shutdown() { }

        /// <summary>
        /// Request IRQ
        /// </summary>
        /// <param name="type"></param>
        /// <param name="asserted"></param>
        public void IRQ(IsrType type, bool asserted)
        {
            if (asserted)
                irqRequestFlags |= (int)type;
            else
                irqRequestFlags &= ~(int)type;
        }
        /// <summary>
        /// Request NMI
        /// </summary>
        public void NMI(bool asserted)
        {
            NmiRequest = asserted;
        }

        public void Execute()
        {
            ExeIRQ = (!sr.i && (irqRequestFlags != 0));

            code = NesCore.CpuMemory[pc.Value++];

            modes[code]();
            codes[code]();

            if (NmiRequest)
            {
                SetNmiRequest = NmiRequest = false;
                Push(pc.HiByte);
                Push(pc.LoByte);
                Push(sr & 0xEF);
                sr.i = true;
                pc.LoByte = NesCore.CpuMemory[0xFFFA];
                pc.HiByte = NesCore.CpuMemory[0xFFFB];
            }
            else if (ExeIRQ)
            {
                Push(pc.HiByte);
                Push(pc.LoByte);
                Push(sr & 0xEF);
                sr.i = true;
                pc.LoByte = NesCore.CpuMemory[0xFFFE];
                pc.HiByte = NesCore.CpuMemory[0xFFFF];
            }

            if (SetNmiRequest)
            {
                NmiRequest = true;
                SetNmiRequest = false;
            }
            if (SetMapperIrqRequest)
            {
                SetMapperIrqRequest = false;
                IRQ(IsrType.External, true);
            }
        }

        public enum IsrType
        {
            Frame = 1,
            Delta = 2,
            External = 4,
        }
    }
}