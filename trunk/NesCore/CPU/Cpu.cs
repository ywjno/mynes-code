using System;
using myNES.Core.CPU.Types;

namespace myNES.Core.CPU
{
    public class Cpu : ProcessorBase
    {
        private Action[] codes;
        private Action[] modes;
        private Dma dma = new Dma();
        private Flags sr; // Processor Status
        private Register aa;
        private Register pc; // Program Counter
        private Register sp; // Stack Pointer
        private bool irq;
        private bool nmi;
        private bool requestIrq;
        public bool requestNmi;
        private byte a; // Accumulator
        private byte x; // Index Register X
        private byte y; // Index Register Y
        private byte code;
        private int irqRequestFlags;
        private bool locked;

        public Cpu(TimingInfo.System system)
            : base(system)
        {
            timing.period = system.Master;
            timing.single = system.Cpu;
        }

        private void Branch(bool flag)
        {
            var data = Peek(aa.Value);

            if (flag)
            {
                Dispatch();
                aa.Value = (ushort)(pc.Value + (sbyte)data);

                if (aa.HiByte != pc.HiByte)
                    Dispatch();

                pc.Value = aa.Value;
            }
        }
        private void Dispatch()
        {
            if (Nes.ON)
            {
                Nes.Apu.Update();
                Nes.Ppu.Update(timing.single);
            }
        }
        private byte Pull()
        {
            sp.LoByte++;
            return Peek(sp.Value);
        }
        private void Push(int data)
        {
            Poke(sp.Value, (byte)data);
            sp.LoByte--;
        }
        private byte Peek(int address)
        {
            Dispatch();

            return Nes.CpuMemory[address];
        }
        private void Poke(int address, byte data)
        {
            Dispatch();

            Nes.CpuMemory[address] = data;
        }

        #region Codes

        // _m = memory
        // _a = accumulator
        // _r = register
        // _i = implied

        private void OpAdc_m()
        {
            byte data = Peek(aa.Value);
            int temp = (a + data + (sr.c ? 1 : 0));

            sr.n = (temp & 0x80) != 0;
            sr.v = ((temp ^ a) & (temp ^ data) & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (temp >> 0x8) != 0;
            a = (byte)(temp);
        }
        private void OpAnd_m()
        {
            a &= Peek(aa.Value);
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpAsl_m()
        {
            byte data = Peek(aa.Value);

            sr.c = (data & 0x80) != 0;

            Poke(aa.Value, data);

            data <<= 1;

            Poke(aa.Value, data);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        }
        private void OpAsl_a()
        {
            sr.c = (a & 0x80) != 0;

            a <<= 1;
            Dispatch();

            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpBcc_m() { Branch(!sr.c); }
        private void OpBcs_m() { Branch(sr.c); }
        private void OpBeq_m() { Branch(sr.z); }
        private void OpBit_m()
        {
            var data = Peek(aa.Value);

            sr.n = (data & 0x80) != 0;
            sr.v = (data & 0x40) != 0;
            sr.z = (data & a) == 0;
        }
        private void OpBmi_m() { Branch(sr.n); }
        private void OpBne_m() { Branch(!sr.z); }
        private void OpBpl_m() { Branch(!sr.n); }
        private void OpBrk_m()
        {
            Dispatch();
            pc.Value++;

            Push(pc.HiByte);
            Push(pc.LoByte);
            Push(sr | 0x10);

            sr.i = true;

            if (nmi)
            {
                nmi = false;
                requestNmi = false;
                pc.LoByte = Peek(0xFFFA);
                pc.HiByte = Peek(0xFFFB);
            }
            else
            {
                pc.LoByte = Peek(0xFFFE);
                pc.HiByte = Peek(0xFFFF);
            }
        }
        private void OpBvc_m() { Branch(!sr.v); }
        private void OpBvs_m() { Branch(sr.v); }
        private void OpClc_i() { sr.c = false; }
        private void OpCld_i() { sr.d = false; }
        private void OpCli_i() { sr.i = false; }
        private void OpClv_i() { sr.v = false; }
        private void OpCmp_m()
        {
            int data = a - Peek(aa.Value);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
            sr.c = (~data >> 8) != 0;
        }
        private void OpCpx_m()
        {
            int data = x - Peek(aa.Value);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
            sr.c = (~data >> 8) != 0;
        }
        private void OpCpy_m()
        {
            int data = y - Peek(aa.Value);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
            sr.c = (~data >> 8) != 0;
        }
        private void OpDec_m()
        {
            byte data = Peek(aa.Value);

            Poke(aa.Value, data);

            data--;

            Poke(aa.Value, data);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        }
        private void OpDex_i()
        {
            x--;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpDey_i()
        {
            y--;
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpEor_m()
        {
            a ^= Peek(aa.Value);
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpInc_m()
        {
            byte data = Peek(aa.Value);

            Poke(aa.Value, data);

            data++;

            Poke(aa.Value, data);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        }
        private void OpInx_i()
        {
            x++;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpIny_i()
        {
            y++;
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpJmp_m()
        {
            Dispatch();
            pc.Value = aa.Value;
        }
        private void OpJsr_m()
        {
            Dispatch();
            pc.Value--;

            Push(pc.HiByte);
            Push(pc.LoByte);

            Dispatch();
            pc.Value = aa.Value;
        }
        private void OpLda_m()
        {
            a = Peek(aa.Value);
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpLdx_m()
        {
            x = Peek(aa.Value);
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpLdy_m()
        {
            y = Peek(aa.Value);
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpLsr_m()
        {
            byte data = Peek(aa.Value);

            sr.c = (data & 0x01) != 0;

            Poke(aa.Value, data);

            data >>= 1;

            Poke(aa.Value, data);

            sr.n = (data & 0x80) != 0;
            sr.z = (data & 0xFF) == 0;
        }
        private void OpLsr_a()
        {
            sr.c = (a & 0x01) != 0;

            Peek(pc.Value);
            a >>= 1;

            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpNop_i() { }
        private void OpOra_m()
        {
            a |= Peek(aa.Value);
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpPha_i()
        {
            Push(a);
        }
        private void OpPhp_i()
        {
            Push(sr | 0x10);
        }
        private void OpPla_i()
        {
            a = Pull();
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpPlp_i()
        {
            sr = Pull();
        }
        private void OpRol_a()
        {
            byte temp = (byte)((a << 1) | (sr.c ? 0x01 : 0x00));

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (a & 0x80) != 0;

            Peek(pc.Value);
            a = temp;
        }
        private void OpRol_m()
        {
            byte data = Peek(aa.Value);

            Poke(aa.Value, data);

            byte temp = (byte)((data << 1) | (sr.c ? 0x01 : 0x00));

            Poke(aa.Value, temp);

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (data & 0x80) != 0;
        }
        private void OpRor_a()
        {
            byte temp = (byte)((a >> 1) | (sr.c ? 0x80 : 0x00));

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (a & 0x01) != 0;

            Peek(pc.Value);
            a = temp;
        }
        private void OpRor_m()
        {
            byte data = Peek(aa.Value);

            Poke(aa.Value, data);

            byte temp = (byte)((data >> 1) | (sr.c ? 0x80 : 0x00));

            Poke(aa.Value, temp);

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (data & 0x01) != 0;
        }
        private void OpRti_i()
        {
            sr = Pull();
            pc.LoByte = Pull();
            pc.HiByte = Pull();

            irq = (!sr.i && (irqRequestFlags != 0));
        }
        private void OpRts_i()
        {
            pc.LoByte = Pull();
            pc.HiByte = Pull();

            pc.Value++; Dispatch();
        }
        private void OpSbc_m()
        {
            int data = Peek(aa.Value) ^ 0xFF;
            int temp = (a + data + (sr.c ? 1 : 0));

            sr.n = (temp & 0x80) != 0;
            sr.v = ((temp ^ a) & (temp ^ data) & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (temp >> 0x8) != 0;
            a = (byte)(temp);
        }
        private void OpSec_i() { sr.c = true; }
        private void OpSed_i() { sr.d = true; }
        private void OpSei_i() { sr.i = true; }
        private void OpSta_m() { Poke(aa.Value, a); }
        private void OpStx_m() { Poke(aa.Value, x); }
        private void OpSty_m() { Poke(aa.Value, y); }
        private void OpTax_i()
        {
            x = a;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpTay_i()
        {
            y = a;
            sr.n = (y & 0x80) != 0;
            sr.z = (y & 0xFF) == 0;
        }
        private void OpTsx_i()
        {
            x = sp.LoByte;
            sr.n = (x & 0x80) != 0;
            sr.z = (x & 0xFF) == 0;
        }
        private void OpTxa_i()
        {
            a = x;
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpTxs_i()
        {
            sp.LoByte = x;
        }
        private void OpTya_i()
        {
            a = y;
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }

        /* Unofficial Codes */
        private void OpAnc_m()
        {
            a &= Peek(aa.Value);
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
            sr.c = (a & 0x80) != 0;
        }
        private void OpArr_m()
        {
            a = (byte)(((Peek(aa.Value) & a) >> 1) | (sr.c ? 0x80 : 0x00));

            sr.z = (a & 0xFF) == 0;
            sr.n = (a & 0x80) != 0;
            sr.c = (a & 0x40) != 0;
            sr.v = ((a << 1 ^ a) & 0x40) != 0;
        }
        private void OpAlr_m()
        {
            a &= Peek(aa.Value);

            sr.c = (a & 0x01) != 0;

            a >>= 1;

            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpAhx_m()
        {
            byte data = (byte)((a & x) & 7);

            Poke(aa.Value, data);
        }
        private void OpAxs_m()
        {
            var temp = (a & x) - Peek(aa.Value);

            sr.n = (temp & 0x80) != 0;
            sr.z = (temp & 0xFF) == 0;
            sr.c = (~temp >> 8) != 0;

            x = (byte)(temp);
        }
        private void OpDcp_m()
        {
            OpDec_m();
            OpCmp_m();
        }
        private void OpDop_i() { }
        private void OpIsc_m()
        {
            OpInc_m();
            OpSbc_m();
        }
        private void OpJam_m()
        {
            Dispatch();
            pc.Value--;
        }
        private void OpLar_m()
        {
            sp.LoByte &= Peek(aa.Value);
            a = sp.LoByte;
            x = sp.LoByte;

            sr.n = (sp.LoByte & 0x80) != 0;
            sr.z = (sp.LoByte & 0xFF) == 0;
        }
        private void OpLax_m()
        {
            OpLda_m();
            OpLdx_m();
        }
        private void OpRla_m()
        {
            OpRol_m();
            OpAnd_m();
        }
        private void OpRra_m()
        {
            OpRor_m();
            OpAdc_m();
        }
        private void OpSax_m()
        {
            Poke(aa.Value, (byte)(x & a));
        }
        private void OpShx_m() { }
        private void OpShy_m() { }
        private void OpSlo_m()
        {
            OpAsl_m();
            OpOra_m();
        }
        private void OpSre_m()
        {
            OpLsr_m();
            OpEor_m();
        }
        private void OpTop_i() { }
        private void OpXaa_m()
        {
            a = (byte)(x & Peek(aa.Value));
            sr.n = (a & 0x80) != 0;
            sr.z = (a & 0xFF) == 0;
        }
        private void OpXas_m()
        {
            sp.LoByte = (byte)(a & x & ((Peek(aa.Value) >> 8) + 1));

            Poke(aa.Value, sp.LoByte);
        }

        #endregion
        #region Modes

        // _a = access (read and write)
        // _r = read
        // _w = write

        private void AmAbs_a()
        {
            aa.LoByte = Peek(pc.Value++);
            aa.HiByte = Peek(pc.Value++);
        }
        private void AmAbx_r()
        {
            aa.LoByte = Peek(pc.Value++);
            aa.HiByte = Peek(pc.Value++);

            aa.LoByte += x;

            if (aa.LoByte < x)
            {
                Peek(aa.Value);
                aa.HiByte++;
            }
        }
        private void AmAbx_w()
        {
            aa.LoByte = Peek(pc.Value++);
            aa.HiByte = Peek(pc.Value++);

            aa.LoByte += x;

            Peek(aa.Value);

            if (aa.LoByte < x)
                aa.HiByte++;
        }
        private void AmAby_r()
        {
            aa.LoByte = Peek(pc.Value++);
            aa.HiByte = Peek(pc.Value++);

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                Peek(aa.Value);
                aa.HiByte++;
            }
        }
        private void AmAby_w()
        {
            aa.LoByte = Peek(pc.Value++);
            aa.HiByte = Peek(pc.Value++);

            aa.LoByte += y;

            Peek(aa.Value);

            if (aa.LoByte < y)
                aa.HiByte++;
        }
        private void AmImm_a()
        {
            aa.Value = pc.Value++;
        }
        private void AmImp_a() { }
        private void AmInd_a()
        {
            aa.LoByte = Peek(pc.Value++);
            aa.HiByte = Peek(pc.Value++);

            byte addr = Peek(aa.Value);

            aa.LoByte++; // only increment the low byte, causing the "JMP ($nnnn)" bug

            aa.HiByte = Peek(aa.Value);
            aa.LoByte = addr;
        }
        private void AmInx_a()
        {
            byte addr = Peek(pc.Value++);

            addr += x; 

            aa.LoByte = Peek(addr++);
            aa.HiByte = Peek(addr++);
        }
        private void AmIny_r()
        {
            byte addr = Peek(pc.Value++);
            aa.LoByte = Peek(addr++);
            aa.HiByte = Peek(addr++);

            aa.LoByte += y;

            if (aa.LoByte < y)
            {
                Peek(aa.Value);
                aa.HiByte++;
            }
        }
        private void AmIny_w()
        {
            byte addr = Peek(pc.Value++);
            aa.LoByte = Peek(addr++);
            aa.HiByte = Peek(addr++);

            aa.LoByte += y;

            Peek(aa.Value);

            if (aa.LoByte < y)
                aa.HiByte++;
        }
        private void AmZpg_a()
        {
            aa.Value = Peek(pc.Value++);
        }
        private void AmZpx_a()
        {
            aa.Value = Peek(pc.Value++);

            Peek(aa.Value);
            aa.LoByte += x;
        }
        private void AmZpy_a()
        {
            aa.Value = Peek(pc.Value++);

            Peek(aa.Value);
            aa.LoByte += y;
        }

        #endregion

        public void Interrupt(IsrType type, bool asserted)
        {
            switch (type)
            {
                case IsrType.Ppu: nmi = asserted; break;
                case IsrType.Apu:
                case IsrType.Dmc:
                case IsrType.Mmc:
                    if (asserted)
                        irqRequestFlags |= (int)type;
                    else
                        irqRequestFlags &= ~(int)type;
                    break;
            }
        }
        public void Lock() { locked = true; }
        public void Unlock() { locked = false; }

        public override void Initialize()
        {
            Console.WriteLine("Initializing CPU...");

            modes = new Action[256]
            {
                // 0     1        2        3        4        5        6        7        8        9        A        B        C        D        E        F
                AmImp_a, AmInx_a, AmImp_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmAbs_a, AmAbs_a, AmAbs_a, AmAbs_a, // 0
                AmImm_a, AmIny_r, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpx_a, AmZpx_a, AmImp_a, AmAby_r, AmImp_a, AmAby_w, AmAbx_r, AmAbx_r, AmAbx_w, AmAbx_w, // 1
                AmAbs_a, AmInx_a, AmImp_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmAbs_a, AmAbs_a, AmAbs_a, AmAbs_a, // 2
                AmImm_a, AmIny_r, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpx_a, AmZpx_a, AmImp_a, AmAby_r, AmImp_a, AmAby_w, AmAbx_r, AmAbx_r, AmAbx_w, AmAbx_w, // 3
                AmImp_a, AmInx_a, AmImp_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmAbs_a, AmAbs_a, AmAbs_a, AmAbs_a, // 4
                AmImm_a, AmIny_r, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpx_a, AmZpx_a, AmImp_a, AmAby_r, AmImp_a, AmAby_w, AmAbx_r, AmAbx_r, AmAbx_w, AmAbx_w, // 5
                AmImp_a, AmInx_a, AmImp_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmInd_a, AmAbs_a, AmAbs_a, AmAbs_a, // 6
                AmImm_a, AmIny_r, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpx_a, AmZpx_a, AmImp_a, AmAby_r, AmImp_a, AmAby_w, AmAbx_r, AmAbx_r, AmAbx_w, AmAbx_w, // 7
                AmImm_a, AmInx_a, AmImm_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmAbs_a, AmAbs_a, AmAbs_a, AmAbs_a, // 8
                AmImm_a, AmIny_w, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpy_a, AmZpy_a, AmImp_a, AmAby_w, AmImp_a, AmAby_w, AmAbx_w, AmAbx_w, AmAby_w, AmAby_w, // 9
                AmImm_a, AmInx_a, AmImm_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmAbs_a, AmAbs_a, AmAbs_a, AmAbs_a, // A
                AmImm_a, AmIny_r, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpy_a, AmZpy_a, AmImp_a, AmAby_r, AmImp_a, AmAby_w, AmAbx_r, AmAbx_r, AmAby_r, AmAby_w, // B
                AmImm_a, AmInx_a, AmImm_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmAbs_a, AmAbs_a, AmAbs_a, AmAbs_a, // C
                AmImm_a, AmIny_r, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpx_a, AmZpx_a, AmImp_a, AmAby_r, AmImp_a, AmAby_w, AmAbx_r, AmAbx_r, AmAbx_w, AmAbx_w, // D
                AmImm_a, AmInx_a, AmImm_a, AmInx_a, AmZpg_a, AmZpg_a, AmZpg_a, AmZpg_a, AmImp_a, AmImm_a, AmImp_a, AmImm_a, AmAbs_a, AmAbs_a, AmAbs_a, AmAbs_a, // E
                AmImm_a, AmIny_r, AmImp_a, AmIny_w, AmZpx_a, AmZpx_a, AmZpx_a, AmZpx_a, AmImp_a, AmAby_r, AmImp_a, AmAby_w, AmAbx_r, AmAbx_r, AmAbx_w, AmAbx_w, // F
            };
            codes = new Action[256]
            {
                // 0     1        2        3        4        5        6        7        8        9        A        B        C        D        E        F
                OpBrk_m, OpOra_m, OpJam_m, OpSlo_m, OpDop_i, OpOra_m, OpAsl_m, OpSlo_m, OpPhp_i, OpOra_m, OpAsl_a, OpAnc_m, OpTop_i, OpOra_m, OpAsl_m, OpSlo_m, // 0
                OpBpl_m, OpOra_m, OpJam_m, OpSlo_m, OpDop_i, OpOra_m, OpAsl_m, OpSlo_m, OpClc_i, OpOra_m, OpNop_i, OpSlo_m, OpTop_i, OpOra_m, OpAsl_m, OpSlo_m, // 1
                OpJsr_m, OpAnd_m, OpJam_m, OpRla_m, OpBit_m, OpAnd_m, OpRol_m, OpRla_m, OpPlp_i, OpAnd_m, OpRol_a, OpAnc_m, OpBit_m, OpAnd_m, OpRol_m, OpRla_m, // 2
                OpBmi_m, OpAnd_m, OpJam_m, OpRla_m, OpDop_i, OpAnd_m, OpRol_m, OpRla_m, OpSec_i, OpAnd_m, OpNop_i, OpRla_m, OpTop_i, OpAnd_m, OpRol_m, OpRla_m, // 3
                OpRti_i, OpEor_m, OpJam_m, OpSre_m, OpDop_i, OpEor_m, OpLsr_m, OpSre_m, OpPha_i, OpEor_m, OpLsr_a, OpAlr_m, OpJmp_m, OpEor_m, OpLsr_m, OpSre_m, // 4
                OpBvc_m, OpEor_m, OpJam_m, OpSre_m, OpDop_i, OpEor_m, OpLsr_m, OpSre_m, OpCli_i, OpEor_m, OpNop_i, OpSre_m, OpTop_i, OpEor_m, OpLsr_m, OpSre_m, // 5
                OpRts_i, OpAdc_m, OpJam_m, OpRra_m, OpDop_i, OpAdc_m, OpRor_m, OpRra_m, OpPla_i, OpAdc_m, OpRor_a, OpArr_m, OpJmp_m, OpAdc_m, OpRor_m, OpRra_m, // 6
                OpBvs_m, OpAdc_m, OpJam_m, OpRra_m, OpDop_i, OpAdc_m, OpRor_m, OpRra_m, OpSei_i, OpAdc_m, OpNop_i, OpRra_m, OpTop_i, OpAdc_m, OpRor_m, OpRra_m, // 7
                OpDop_i, OpSta_m, OpDop_i, OpSax_m, OpSty_m, OpSta_m, OpStx_m, OpSax_m, OpDey_i, OpDop_i, OpTxa_i, OpXaa_m, OpSty_m, OpSta_m, OpStx_m, OpSax_m, // 8
                OpBcc_m, OpSta_m, OpJam_m, OpAhx_m, OpSty_m, OpSta_m, OpStx_m, OpSax_m, OpTya_i, OpSta_m, OpTxs_i, OpXas_m, OpShy_m, OpSta_m, OpShx_m, OpAhx_m, // 9
                OpLdy_m, OpLda_m, OpLdx_m, OpLax_m, OpLdy_m, OpLda_m, OpLdx_m, OpLax_m, OpTay_i, OpLda_m, OpTax_i, OpLax_m, OpLdy_m, OpLda_m, OpLdx_m, OpLax_m, // A
                OpBcs_m, OpLda_m, OpJam_m, OpLax_m, OpLdy_m, OpLda_m, OpLdx_m, OpLax_m, OpClv_i, OpLda_m, OpTsx_i, OpLar_m, OpLdy_m, OpLda_m, OpLdx_m, OpLax_m, // B
                OpCpy_m, OpCmp_m, OpDop_i, OpDcp_m, OpCpy_m, OpCmp_m, OpDec_m, OpDcp_m, OpIny_i, OpCmp_m, OpDex_i, OpAxs_m, OpCpy_m, OpCmp_m, OpDec_m, OpDcp_m, // C
                OpBne_m, OpCmp_m, OpJam_m, OpDcp_m, OpDop_i, OpCmp_m, OpDec_m, OpDcp_m, OpCld_i, OpCmp_m, OpNop_i, OpDcp_m, OpTop_i, OpCmp_m, OpDec_m, OpDcp_m, // D
                OpCpx_m, OpSbc_m, OpDop_i, OpIsc_m, OpCpx_m, OpSbc_m, OpInc_m, OpIsc_m, OpInx_i, OpSbc_m, OpNop_i, OpSbc_m, OpCpx_m, OpSbc_m, OpInc_m, OpIsc_m, // E
                OpBeq_m, OpSbc_m, OpJam_m, OpIsc_m, OpDop_i, OpSbc_m, OpInc_m, OpIsc_m, OpSed_i, OpSbc_m, OpNop_i, OpIsc_m, OpTop_i, OpSbc_m, OpInc_m, OpIsc_m, // F
            };

            Poke(0x0008, 0xF7);
            Poke(0x0008, 0xF7);
            Poke(0x0009, 0xEF);
            Poke(0x000A, 0xDF);
            Poke(0x000F, 0xBF);

            a = 0x00;
            x = 0x00;
            y = 0x00;

            sp.LoByte = 0xFD;
            sp.HiByte = 0x01;

            pc.LoByte = Peek(0xFFFC);
            pc.HiByte = Peek(0xFFFD);

            sr.i = true;

            Nes.CpuMemory.Hook(0x4014, dma.OamTransfer);

            Console.WriteLine("CPU initialized!", DebugCode.Good);
        }
        public override void Shutdown() { }
        public override void Update()
        {
            if (locked)
            {
                dma.Update();
                return;
            }

            irq = (!sr.i && (irqRequestFlags != 0));

            code = Peek(pc.Value++);

            modes[code]();
            codes[code]();

            if (nmi)
            {
                nmi = false;
                requestNmi = false;

                Push(pc.HiByte);
                Push(pc.LoByte);
                Push(sr);

                pc.LoByte = Peek(0xFFFA);
                pc.HiByte = Peek(0xFFFB);
            }
            else if (irq)
            {
                Push(pc.HiByte);
                Push(pc.LoByte);
                Push(sr);

                sr.i = true;

                pc.LoByte = Peek(0xFFFE);
                pc.HiByte = Peek(0xFFFF);
            }

            if (requestNmi)
            {
                requestNmi = false;
                nmi = true;
            }

            if (requestIrq)
            {
                requestIrq = false;
                Interrupt(IsrType.Mmc, true);
            }
        }

        public enum IsrType
        {
            Ppu = 0,
            Apu = 1,
            Dmc = 2,
            Mmc = 4,
        }
    }
}