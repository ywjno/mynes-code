using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Core.NetPlay;

namespace MyNes
{
    public partial class Frm_SetPlayerNumber : Form
    {
        public Frm_SetPlayerNumber(RemotingObject remotingObject)
        {
            InitializeComponent();

            if (remotingObject.IsPlayerNumberAvailable(1))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton1.Checked = false;
            }

            if (remotingObject.IsPlayerNumberAvailable(2))
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton2.Enabled = false;
                radioButton2.Checked = false;
            }

            if (remotingObject.IsPlayerNumberAvailable(3))
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton3.Enabled = false;
                radioButton3.Checked = false;
            }

            if (remotingObject.IsPlayerNumberAvailable(4))
            {
                radioButton4.Checked = true;
            }
            else
            {
                radioButton4.Enabled = false;
                radioButton4.Checked = false;
            }
        }
        public int PlayerNumber
        {
            get
            {
                if (radioButton1.Checked)
                    return 1;
                if (radioButton2.Checked)
                    return 2;
                if (radioButton3.Checked)
                    return 3;
                if (radioButton4.Checked)
                    return 4;
                return -1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
