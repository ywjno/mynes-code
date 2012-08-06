/*********************************************************************\
*This file is part of My Nes                                          *
*A Nintendo Entertainment System Emulator.                            *
*                                                                     *
*Copyright © Ala I.Hadid 2009 - 2012                                  *
*E-mail: mailto:ahdsoftwares@hotmail.com                              *
*                                                                     *
*My Nes is free software: you can redistribute it and/or modify       *
*it under the terms of the GNU General Public License as published by *
*the Free Software Foundation, either version 3 of the License, or    *
*(at your option) any later version.                                  *
*                                                                     *
*My Nes is distributed in the hope that it will be useful,            *
*but WITHOUT ANY WARRANTY; without even the implied warranty of       *
*MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the        *
*GNU General Public License for more details.                         *
*                                                                     *
*You should have received a copy of the GNU General Public License    *
*along with this program.  If not, see <http://www.gnu.org/licenses/>.*
\*********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Core;

namespace MyNes
{
    public partial class con_Memory : UserControl
    {
        public con_Memory()
        {
            InitializeComponent();
        }
        [Browsable(false)]
        public Memory Memory
        {
            get { return memoryPanel1.memorySpace; }
            set
            {
                if (value != null)
                {
                    vScrollBar1.Maximum = value.Length / 16;
                    vScrollBar1.Value = 0;
                }
                memoryPanel1.memorySpace = value;
                memoryPanel1.Invalidate();
            }
        }
        public bool EnableSpecialAddress
        { get { return memoryPanel1.EnableSpecialAddress; } set { memoryPanel1.EnableSpecialAddress = value; memoryPanel1.Invalidate(); } }
        public int SpecailAddress
        { get { return memoryPanel1.SpecialAddress; } set { memoryPanel1.SpecialAddress = value; memoryPanel1.Invalidate(); } }
        public Color SpecialAddressHighlight
        { get { return memoryPanel1.SpecialAddressHighlight; } set { memoryPanel1.SpecialAddressHighlight = value; memoryPanel1.Invalidate(); } }
        public void SeekToAddress(int address)
        {
            try { vScrollBar1.Value = address / 16; }
            catch { }
            memoryPanel1.currentAddress = (address / 16) * 16;
            memoryPanel1.Invalidate();
        }
        private void con_Memory_Paint(object sender, PaintEventArgs e)
        {
            if (memoryPanel1.memorySpace != null)
                vScrollBar1.Maximum = memoryPanel1.memorySpace.Length / 16;
            else
            {
                vScrollBar1.Maximum = 1;
            }
            memoryPanel1.Invalidate();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            memoryPanel1.currentAddress = vScrollBar1.Value * 16;
            memoryPanel1.Invalidate();
        }
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                memoryPanel1.BackColor = base.BackColor = value;
            }
        }
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                memoryPanel1.ForeColor = base.ForeColor = value;
            }
        }
    }
}
