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
        private static Dictionary<DebugCode, Brush> CodeColors = new Dictionary<DebugCode, Brush>()
        {
            { DebugCode.Error,   Brushes.Red       },
            { DebugCode.Good,    Brushes.LimeGreen },
            { DebugCode.None,    Brushes.White     },
            { DebugCode.Warning, Brushes.Yellow    },
        };

        private List<DebugLine> debugLines = new List<DebugLine>();

        public int ScrollOffset = 0;

        public event EventHandler DebugLinesUpdated;

        public int StringHeight
        {
            get
            {
                Size CharSize = TextRenderer.MeasureText("TEST", this.Font);

                return CharSize.Height * debugLines.Count;
            }
        }

        public ConsolePanel()
        {
            InitializeComponent();

            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);

            WriteLine("MY NES CONSOLE VERSION 5");
            WriteLine("Enter 'help' for instruction list");
            WriteLine("=====================================");

            CONSOLE.LineWritten += (sender, e) => WriteLine(e.Text, e.Code);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int stringHeight = StringHeight;

            int lines = (base.Height / stringHeight) + 2;
            int lineIndex = ScrollOffset / stringHeight;
            int offset = ScrollOffset % stringHeight;

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
                        (i * stringHeight) - offset);
                }
            }
        }

        public void WriteLine(string line, DebugCode status = DebugCode.None)
        {
            debugLines.Add(new DebugLine(line, status));

            if (DebugLinesUpdated != null)
                DebugLinesUpdated(this, EventArgs.Empty);

            base.Invalidate();
        }
    }
}