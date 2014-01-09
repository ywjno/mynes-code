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

namespace MyNes
{
    public partial class FormEditFilesList : Form
    {
        public FormEditFilesList(string[] files)
        {
            InitializeComponent();
            // Load
            foreach (string f in files)
                listBox1.Items.Add(f);

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        public string[] ListItems
        {
            get
            {
                List<string> l = new List<string>();

                foreach (string s in listBox1.Items)
                    l.Add(s);

                return l.ToArray();
            }
        }
        // Cancel
        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
        // OK
        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        // Remove
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }
        // Move up
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) { return; }

            object selected = listBox1.SelectedItem;
            int index = listBox1.SelectedIndex;

            listBox1.Items.RemoveAt(index);

            if (index > 0)
                index--;

            listBox1.Items.Insert(index, selected);

            listBox1.SelectedIndex = index;
        }
        // Move down
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) { return; }

            object selected = listBox1.SelectedItem;
            int index = listBox1.SelectedIndex;

            listBox1.Items.RemoveAt(index);

            if (index < listBox1.Items.Count - 1)
                index++;

            listBox1.Items.Insert(index, selected);

            listBox1.SelectedIndex = index;
        }
    }
}
