﻿using MyNes.Core.Boards.Nintendo;
namespace MyNes.Core.Boards.FFE
{
    [BoardName("FFE F6xxx", 12)]
    class FFE_F6xxx : MMC3
    {
        public FFE_F6xxx()
            : base()
        { }
        public FFE_F6xxx(byte[] chr, byte[] prg, byte[] trainer, bool isVram)
            : base(chr, prg, trainer, isVram)
        { }
        int vb0;
        int vb1;
        public override void Initialize()
        {
            base.Initialize();
            Nes.CpuMemory.Hook(0x4020, 0x5FFF, PokePrg);
            Console.WriteLine("Mapper 23 not implement well due to uncomplete information", DebugCode.Warning);
        }
        public override void HardReset()
        {
            base.HardReset();
            vb0 = 0;
            vb1 = 0;
            mmc3_alt_behavior = true;
        }
        protected override void PokePrg(int address, byte data)
        {
            if (address < 0x6000)
            {
                int vb0 = ((data & 0x01) << 8);
                int vb1 = ((data & 0x10) << 4);
                SetupCHR();
            }
            else
                base.PokePrg(address, data);
        }
        protected override void SetupCHR()
        {
            if (!chrmode)
            {
                base.Switch01kCHR(chrRegs[0] + vb0, 0x0000);
                base.Switch01kCHR(chrRegs[0] + vb0 + 1, 0x0400);
                base.Switch01kCHR(chrRegs[1] + vb0, 0x0800);
                base.Switch01kCHR(chrRegs[1] + vb0 + 1, 0x0C00);
                base.Switch01kCHR(chrRegs[2] + vb1, 0x1000);
                base.Switch01kCHR(chrRegs[3] + vb1, 0x1400);
                base.Switch01kCHR(chrRegs[4] + vb1, 0x1800);
                base.Switch01kCHR(chrRegs[5] + vb1, 0x1C00);
            }
            else
            {
                base.Switch01kCHR(chrRegs[0] + vb1, 0x1000);
                base.Switch01kCHR(chrRegs[0] + vb1 + 1, 0x1400);
                base.Switch01kCHR(chrRegs[1] + vb1, 0x1800);
                base.Switch01kCHR(chrRegs[1] + vb1 + 1, 0x1C00);
                base.Switch01kCHR(chrRegs[2] + vb0, 0x0000);
                base.Switch01kCHR(chrRegs[3] + vb0, 0x0400);
                base.Switch01kCHR(chrRegs[4] + vb0, 0x0800);
                base.Switch01kCHR(chrRegs[5] + vb0, 0x0C00);
            }
        }
    }
}
