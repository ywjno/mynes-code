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
    public partial class Frm_Disassembler : Form
    {
        public Frm_Disassembler()
        {
            InitializeComponent();

            RefreshCpu();
            RefreshMemory();
        }
        void RefreshCpu()
        {}
        void RefreshMemory()
        {
            con_Memory1.Memory = NesCore.CpuMemory;
        }
    }
}
