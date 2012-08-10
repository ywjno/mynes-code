using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using myNES.Core;

namespace myNES
{
    public partial class FormSpeed : Form
    {
        public FormSpeed()
        {
            InitializeComponent();
            if (Nes.SpeedLimiter.ON)
            {
                button2.Text = "ON";
                button2.FlatStyle = FlatStyle.Popup;
            }
            else
            {
                button2.Text = "OFF";
                button2.FlatStyle = FlatStyle.Standard;
            }
        }
        double min = 1000;
        double max = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Nes.ON)
            {
                textBox_dead.Text = Nes.SpeedLimiter.DeadTime.ToString();
                textBox_FrameTime.Text = Nes.SpeedLimiter.CurrentFrameTime.ToString();
                double fps = (1.0 / Nes.SpeedLimiter.CurrentFrameTime);
                if (fps < min)
                    min = fps;
                if (fps > max)
                    max = fps;
                textBox_fpsCanMake.Text = fps.ToString();
                label_min_max.Text = "Min= " + min.ToString() + "\nMax= " + max.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nes.SpeedLimiter.ON = !Nes.SpeedLimiter.ON;
            if (Nes.SpeedLimiter.ON)
            {
                button2.Text = "ON";
                button2.FlatStyle = FlatStyle.Popup;
            }
            else
            {
                button2.Text = "OFF";
                button2.FlatStyle = FlatStyle.Standard;
            }
        }
    }
}
