using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNes
{
    public partial class ChatPanel : Control
    {
        public ChatPanel()
        {
            InitializeComponent();

            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);
            charHeight = CharHeight;
        }

        public int ScrollOffset = 0;
        private int charHeight = 0;
        // we'll use the debug line object since it supports colors ...
        public List<string> chatLines = new List<string>();
        public event EventHandler LinesUpdated;

        public int StringHeight
        {
            get
            {
                Size CharSize = TextRenderer.MeasureText("TEST", this.Font);

                return CharSize.Height * chatLines.Count;
            }
        }
        public int CharHeight
        {
            get { return TextRenderer.MeasureText("TEST", this.Font).Height; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            int lines = (base.Height / charHeight) + 2;
            int lineIndex = ScrollOffset / charHeight;
            int offset = ScrollOffset % charHeight;

            for (int i = 0; i < lines; i++, lineIndex++)
            {
                if (lineIndex < chatLines.Count)
                {
                    pe.Graphics.DrawString(chatLines[lineIndex], this.Font, new SolidBrush(base.ForeColor),
                        1, (i * charHeight) - offset);
                }
            }
        }
        public void AddLine(string line)
        {
            chatLines.Add(line);
            //limit lines to 1000000 lines
            if (chatLines.Count == 1000000)
                chatLines.RemoveAt(0);

            if (LinesUpdated != null)
                LinesUpdated(this, EventArgs.Empty);

            base.Invalidate();
        }
    }
}
