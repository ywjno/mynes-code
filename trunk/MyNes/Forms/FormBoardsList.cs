/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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
using System.Reflection;
using System.IO;
using System.Diagnostics;
using MyNes.Core;
namespace MyNes
{
    public partial class FormBoardsList : Form
    {
        public FormBoardsList()
        {
            InitializeComponent();
            // Refresh
            List<Type> types = new List<System.Type>(Assembly.GetAssembly(typeof(NesEmu)).GetTypes());
            supported = 0;
            for (int i = 0; i < 256; i++)
            {
                string mapperName = "MyNes.Core.Mapper" + i.ToString("D3");

                for (int j = 0; j < types.Count; j++)
                {
                    if (types[j].FullName == mapperName)
                    {
                        Board board = Activator.CreateInstance(types[j]) as Board;

                        ListViewItem item = new ListViewItem();
                        item.Text = i.ToString("D3");
                        item.SubItems.Add(board.Name);
                        item.SubItems.Add(board.Supported ? "YES" : "NO");
                        item.SubItems.Add(board.NotImplementedWell ? "YES" : "NO");
                        item.SubItems.Add(board.Issues != null ? board.Issues.Replace("\n", "|") : "");
                        item.ImageIndex = board.NotImplementedWell ? 2 : (board.Supported ? 0 : 1);
                        item.Tag = board;
                        listView1.Items.Add(item);

                        if (board.Supported)
                            supported++;
                        types.RemoveAt(j);
                        j--;
                    }
                }
            }
            label_inf.Text = Program.ResourceManager.GetString("Status_TotalOf") + " " +
                supported + " " + Program.ResourceManager.GetString("Status_Supported");
        }
        private int supported;
        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Board board = (Board)listView1.SelectedItems[0].Tag;
                richTextBox1.Text = "Name: " + board.Name + "\n" +
                      "Mapper #: " + board.MapperNumber.ToString("D3") + "\n" +
                      "Supported: " + (board.Supported ? "YES" : "NO") + "\n" +
                      (board.NotImplementedWell ? ("**Issues**\n" + board.Issues) : "");
            }
            else
            {
                richTextBox1.Text = "";
            }
        }
    }
}
