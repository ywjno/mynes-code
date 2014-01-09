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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyNes.Core;
using Console = MyNes.Core.Console;

namespace MyNes
{
    public partial class ConsolePanel : Control
    {
        private static Dictionary<DebugCode, Brush> CodeColors = new Dictionary<DebugCode, Brush>()
        {
            { DebugCode.Error,   Brushes.Red       },
            { DebugCode.Good,    Brushes.LimeGreen },
            { DebugCode.None,    Brushes.White     },
            { DebugCode.Warning, Brushes.Yellow    },
        };

        public List<DebugLine> debugLines = new List<DebugLine>();

        public int ScrollOffset = 0;
        private int charHeight = 0;
        public event EventHandler DebugLinesUpdated;

        public int StringHeight
        {
            get
            {
                Size CharSize = TextRenderer.MeasureText("TEST", this.Font);

                return (CharSize.Height - 1) * debugLines.Count;
            }
        }
        public int CharHeight
        {
            get { return TextRenderer.MeasureText("TEST", this.Font).Height; }
        }

        public ConsolePanel()
        {
            InitializeComponent();

            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);

            WriteLine("MY Nes CONSOLE VERSION 6");
            WriteLine("Enter 'help' for instruction list");
            WriteLine("=====================================");

            Console.LineWritten += (sender, e) => WriteLine(e.Text, e.Code);
            Console.UpdateLastLine += (sender, e) => UpdateLastLine(e.Text, e.Code);

            charHeight = CharHeight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int lines = (base.Height / charHeight) + 2;
            int lineIndex = ScrollOffset / charHeight;
            int offset = ScrollOffset % charHeight;

            for (int i = 0; i < lines; i++, lineIndex++)
            {
                if (lineIndex < debugLines.Count)
                {
                    var line = debugLines[lineIndex];

                    e.Graphics.DrawString(
                        line.Text,
                        this.Font,
                        CodeColors[line.Code],
                        1,
                        (i * charHeight) - offset);
                }
            }
        }

        public void WriteLine(string line, DebugCode status = DebugCode.None)
        {
            debugLines.Add(new DebugLine(line, status));
            //limit lines to 1000000 lines
            if (debugLines.Count == 1000000)
                debugLines.RemoveAt(0);

            if (DebugLinesUpdated != null)
                DebugLinesUpdated(this, EventArgs.Empty);

            base.Invalidate();
        }
        public void UpdateLastLine(string line, DebugCode status = DebugCode.None)
        {
            debugLines[debugLines.Count - 1] = new DebugLine(line, status);

            if (DebugLinesUpdated != null)
                DebugLinesUpdated(this, EventArgs.Empty);

            base.Invalidate();
        }
    }
}