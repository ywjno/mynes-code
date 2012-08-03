/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyNes.Core;

namespace MyNes
{
    public partial class ConsolePanel : Control
    {
        public ConsolePanel()
        {
            InitializeComponent();

            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);

            WriteLine("MY NES CONSOLE VERSION 5");
            WriteLine("Enter 'help' for instruction list");
            WriteLine("=====================================");
            CONSOLE.DebugRised += new EventHandler<DebugEventArgs>(CONSOLE_DebugRised);
        }

        List<DebugLine> debugLines = new List<DebugLine>();
        public int ScrollOffset = 0;
        public void WriteLine(string line)
        { WriteLine(line, DebugCode.None); }
        public void WriteLine(string line, DebugCode status)
        {
            debugLines.Add(new DebugLine(line, status));
            if (DebugLinesUpdated != null)
                DebugLinesUpdated(this, null);
            this.Invalidate();
        }
        public int StringHeight
        {
            get
            {
                Size CharSize = TextRenderer.MeasureText("TEST", this.Font);

                return CharSize.Height * debugLines.Count;
            }
        }
        public event EventHandler DebugLinesUpdated;
        void CONSOLE_DebugRised(object sender, DebugEventArgs e)
        {
            WriteLine(e.Text, e.Code);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //get default size of word
            Size CharSize = TextRenderer.MeasureText("TEST", this.Font);

            int lines = (this.Height / CharSize.Height) + 2;
            int lineIndex = ScrollOffset / CharSize.Height;
            int offset = ScrollOffset % CharSize.Height;
            for (int i = 0; i < lines; i++)
            {
                if (lineIndex < debugLines.Count)
                {
                    Color clr = Color.White;
                    switch (debugLines[lineIndex].DebugStatus)
                    {
                        case DebugCode.Error: clr = Color.Red; break;
                        case DebugCode.Warning: clr = Color.Yellow; break;
                        case DebugCode.Good: clr = Color.LimeGreen; break;
                    }
                    pe.Graphics.DrawString(debugLines[lineIndex].Line, this.Font,
                               new SolidBrush(clr), new PointF(1, (i * CharSize.Height) - offset));
                }
                lineIndex++;
            }
        }
    }
}
