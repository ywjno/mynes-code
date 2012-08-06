using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Core;

namespace MyNes
{
    public partial class MemoryPanel : Control
    {
        public MemoryPanel()
        {
            InitializeComponent();
            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true); 
        }

        public int currentAddress = 0;
        public int SpecialAddress = 0;
        public bool EnableSpecialAddress = true;
        public Color SpecialAddressHighlight = Color.Blue;

        SizeF charSize;

        public Memory memorySpace;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (memorySpace==null)
                return;
            charSize = pe.Graphics.MeasureString("0000: ", this.Font);

            float lines = this.Height / charSize.Height;

            int address = currentAddress;

            for (int i = 0; i < lines; i++)
            {
                if (address < memorySpace.Length)
                {
                    pe.Graphics.DrawString(string.Format("{0:X4}", address) + ": ", this.Font,
                        new SolidBrush(this.ForeColor), new PointF(1, i * charSize.Height));
                    for (int j = 0; j < 16; j++)
                    {
                        byte val = 0;
                        if (memorySpace != null)
                            val = memorySpace.DebugPeek(address);

                       // if (address >= 0x2000 && address <= 0x4017)
                       //     pe.Graphics.FillRectangle(new SolidBrush(Color.Navy), new Rectangle((int)(charSize.Width + 2 + j * 16), (int)(i * charSize.Height), 16, 16));
                        if (address == SpecialAddress && EnableSpecialAddress)
                            pe.Graphics.FillRectangle(new SolidBrush(SpecialAddressHighlight), new Rectangle((int)(charSize.Width + 2 + j * 16), (int)(i * charSize.Height), 16, 16));

                        pe.Graphics.DrawString(string.Format("{0:X2}", val), this.Font,
                        new SolidBrush(this.ForeColor), new PointF(charSize.Width + 2 + j * 16, i * charSize.Height));

                        address++;
                    }
                }
            }
        }
    }
}
