/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
    public partial class FormSpeed : Form
    {
        public FormSpeed()
        {
            InitializeComponent();
            try
            {
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
            catch
            {
                MessageBox.Show("EMULATION IS OFF !!");
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
                textBox_fps.Text = Nes.SpeedLimiter.FramePeriod.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
