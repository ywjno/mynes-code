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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Core;
namespace MyNes
{
    public partial class MemoryWathcerPanel : Control
    {
        public MemoryWathcerPanel()
        {
            InitializeComponent();
            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);

            charHeight = TextRenderer.MeasureText("T", this.Font).Height;
            charWidth = TextRenderer.MeasureText("T", this.Font).Width;
            dataWidth = TextRenderer.MeasureText("FF", this.Font).Width;
            addressWidth = TextRenderer.MeasureText("FFFF:", this.Font).Width;
        }
        private int charHeight;
        private int charWidth;
        private int dataWidth;
        private int addressWidth;
        public int max = 0;
        public int memOffset = 0x0000; 
        public int scroll;
        private ASCIIEncoding encoding = new ASCIIEncoding();
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            int xd = addressWidth + (16 * dataWidth);
            pe.Graphics.DrawLine(new Pen(new SolidBrush(this.ForeColor)), new Point(0, charHeight), new Point(this.Width, charHeight));
            pe.Graphics.DrawLine(new Pen(new SolidBrush(this.ForeColor)), new Point(xd, 0), new Point(xd, this.Height));
            pe.Graphics.DrawLine(new Pen(new SolidBrush(this.ForeColor)), new Point(addressWidth, 0), new Point(addressWidth, this.Height));
            pe.Graphics.DrawString("ASCII", this.Font, new SolidBrush(this.ForeColor), xd, 0);
            // Draw column
            pe.Graphics.DrawString("Addr", this.Font, new SolidBrush(this.ForeColor), 0, 0);
            int xpc = addressWidth;
            for (int x = 0; x < 16; x++)
            {
                pe.Graphics.DrawString(string.Format("{0:X2}", x), this.Font, new SolidBrush(this.ForeColor), xpc, 0);
                xpc += dataWidth;
            }
            if (NesCore.ON)
            {
                // Get lines
                int lines = (this.Height - charHeight) / charHeight;
                // Get address
                int currentAddressOffset = scroll * 16;
                for (int i = 0; i < lines; i++)
                {
                    if (currentAddressOffset >= max) return;
                    int xp = addressWidth;
                    xd = addressWidth + (16 * dataWidth);
                    int y = (i * charHeight) + charHeight;
                    // Draw address
                    string dis = string.Format("${0:X4}", currentAddressOffset + memOffset);
                    pe.Graphics.DrawString(dis, this.Font, new SolidBrush(this.ForeColor), 0, y);
                    for (int x = 0; x < 16; x++)
                    {
                        string st = "";
                        if (currentAddressOffset < max)
                        {
                            byte val = 0;
                           // TODO : fix this
                            // val = NesCore.CPUMemory[currentAddressOffset + memOffset];
                            dis = string.Format("{0:X2}", val);
                            st = encoding.GetString(new byte[] { val });

                            pe.Graphics.DrawString(dis, this.Font, new SolidBrush(this.ForeColor), xp, y);
                            pe.Graphics.DrawString(st, this.Font, new SolidBrush(this.ForeColor), xd, y);
                        }

                        xp += dataWidth;
                        xd += charWidth;

                        currentAddressOffset++;
                        if (currentAddressOffset > max)
                            break;
                    }
                }
            }
        }
        public string GetAddressOnPoint(Point p)
        {
            if (NesCore.ON)
            {
                if (p.X > addressWidth && p.Y > charHeight)
                {
                    int currentAddressOffset = scroll * 16;
                    currentAddressOffset += ((p.Y - charHeight) / charHeight) * 16;
                    int XX = ((p.X - addressWidth) / dataWidth);
                    if (XX >= 16)
                        XX = ((p.X - addressWidth - ((16 * dataWidth))) / charWidth);
                    if (XX < 16)
                    {
                        currentAddressOffset += XX;
                        return "0x" + string.Format("{0:X4}", currentAddressOffset + memOffset);
                    }
                }
            } 
            return "";
        }
    }
}
