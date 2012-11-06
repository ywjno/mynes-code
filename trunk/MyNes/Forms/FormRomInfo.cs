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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using MyNes.Core;
using MyNes.Core.Database;
namespace MyNes
{
    public partial class FormRomInfo : Form
    {
        public FormRomInfo()
        {
            InitializeComponent();
            if (!Nes.ON)
            {
                MessageBox.Show("EMULATION IS OFF !!");
            }
            else
            {
                Nes.TogglePause(true);
                //Get general information
                textBox_fileName.Text = Nes.RomInfo.Path;
                textBox_sha1.Text = Nes.RomInfo.SHA1.ToUpper();
                textBox_prg.Text = Nes.RomInfo.PRGcount + " [" + (Nes.RomInfo.PRGcount * 16) + " KB]";
                textBox_chr.Text = Nes.RomInfo.CHRcount + " [" + (Nes.RomInfo.CHRcount * 8) + " KB]";
                switch (Nes.RomInfo.Mirroring)
                {
                    case Core.Types.Mirroring.Mode1ScA: textBox_mirroring.Text = "One-Screen A"; break;
                    case Core.Types.Mirroring.Mode1ScB: textBox_mirroring.Text = "One-Screen B"; break;
                    case Core.Types.Mirroring.ModeFull: textBox_mirroring.Text = "4-Screen"; break;
                    case Core.Types.Mirroring.ModeHorz: textBox_mirroring.Text = "Horizontal"; break;
                    case Core.Types.Mirroring.ModeVert: textBox_mirroring.Text = "Vertical"; break;
                }
                textBox_mapper.Text = Nes.RomInfo.MapperBoard;

                //Get database info
                if (Nes.RomInfo.DatabaseGameInfo.Game_Name != null)
                {
                    //Game info
                    ListViewGroup gr = new ListViewGroup("Game info");
                    listView1.Groups.Add(gr);
                    FieldInfo[] Fields = typeof(NesDatabaseGameInfo).GetFields(BindingFlags.Public
                    | BindingFlags.Instance);
                    bool ColorOr = false;
                    for (int i = 0; i < Fields.Length; i++)
                    {
                        if (Fields[i].FieldType == typeof(System.String))
                        {
                            listView1.Items.Add(Fields[i].Name.Replace("_", " "));
                            gr.Items.Add(listView1.Items[listView1.Items.Count - 1]);
                            try
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(Fields[i].GetValue
                                    (Nes.RomInfo.DatabaseGameInfo).ToString());
                            }
                            catch
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                            }
                            if (ColorOr)
                                listView1.Items[listView1.Items.Count - 1].BackColor = Color.WhiteSmoke;
                            ColorOr = !ColorOr;
                        }
                    }

                    //chips
                    if (Nes.RomInfo.DatabaseGameInfo.chip_type != null)
                    {
                        for (int i = 0; i < Nes.RomInfo.DatabaseGameInfo.chip_type.Count; i++)
                        {
                            listView1.Items.Add("Chip " + (i + 1));
                            gr.Items.Add(listView1.Items[listView1.Items.Count - 1]);
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(Nes.RomInfo.DatabaseGameInfo.chip_type[i]);
                            if (ColorOr)
                                listView1.Items[listView1.Items.Count - 1].BackColor = Color.WhiteSmoke;
                            ColorOr = !ColorOr;
                        }
                    }

                    //Cartridge
                    gr = new ListViewGroup("Cartridge");
                    listView1.Groups.Add(gr);
                    Fields = typeof(NesDatabaseCartridgeInfo).GetFields(BindingFlags.Public
                    | BindingFlags.Instance);
                    ColorOr = false;
                    for (int i = 0; i < Fields.Length; i++)
                    {
                        if (Fields[i].FieldType == typeof(System.String))
                        {
                            listView1.Items.Add(Fields[i].Name.Replace("_", " "));
                            gr.Items.Add(listView1.Items[listView1.Items.Count - 1]);
                            try
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(Fields[i].GetValue(Nes.RomInfo.DatabaseCartInfo).ToString());
                            }
                            catch
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                            }
                            if (ColorOr)
                                listView1.Items[listView1.Items.Count - 1].BackColor = Color.WhiteSmoke;
                            ColorOr = !ColorOr;
                        }
                    }

                    //DataBase
                    gr = new ListViewGroup("DataBase");
                    listView1.Groups.Add(gr);
                    Fields = typeof(NesDatabase).GetFields(BindingFlags.Public
                  | BindingFlags.Static);
                    ColorOr = false;
                    for (int i = 0; i < Fields.Length; i++)
                    {
                        if (Fields[i].FieldType == typeof(System.String))
                        {
                            listView1.Items.Add(Fields[i].Name.Remove(0, 2));
                            gr.Items.Add(listView1.Items[listView1.Items.Count - 1]);
                            try
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(Fields[i].GetValue(Nes.RomInfo.DatabaseCartInfo).ToString());
                            }
                            catch
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                            }
                            if (ColorOr)
                                listView1.Items[listView1.Items.Count - 1].BackColor = Color.WhiteSmoke;
                            ColorOr = !ColorOr;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormRomInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Nes.ON)
                Nes.TogglePause(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = new RichTextBox();
            foreach (ListViewItem item in listView1.Items)
            {
                textBox.Text += item.Text + ": " + item.SubItems[1].Text + "\n";
            }
            textBox.SelectAll();
            textBox.Copy();
            MessageBox.Show("Done !");
        }
    }
}
