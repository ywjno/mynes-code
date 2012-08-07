using System.Drawing;
using System.Windows.Forms;
using myNES.Core;

namespace myNES
{
    public partial class MemoryPanel : Control
    {
        private SizeF charSize;

        public Color SpecialAddressHighlight = Color.Blue;
        public Memory MemorySpace;
        public bool SpecialAddressEnabled = true;
        public int CurrentAddress = 0;
        public int SpecialAddress = 0;

        public MemoryPanel()
        {
            InitializeComponent();

            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (MemorySpace == null)
                return;

            charSize = e.Graphics.MeasureString("0000: ", this.Font);

            int lines = (int)(this.Height / charSize.Height);
            int address = CurrentAddress;

            for (int i = 0; i < lines; i++)
            {
                if (address < MemorySpace.Length)
                {
                    var yPos = (charSize.Height * i);

                    using (var brush = new SolidBrush(base.ForeColor))
                        e.Graphics.DrawString(string.Format("{0:X4}: ", address), this.Font, brush, 1F, yPos);

                    for (int j = 0; j < 16; j++, address++)
                    {
                        var data = MemorySpace.DebugPeek(address);
                        var xPos = (charSize.Width + 2 + j * 16);

                        if (SpecialAddressEnabled && address == SpecialAddress)
                        {
                            using (var brush = new SolidBrush(this.SpecialAddressHighlight))
                                e.Graphics.FillRectangle(brush, xPos, yPos, 16, 16);
                        }

                        using (var brush = new SolidBrush(base.ForeColor))
                            e.Graphics.DrawString(data.ToString("X2"), this.Font, brush, xPos, yPos);
                    }
                }
            }
        }
    }
}