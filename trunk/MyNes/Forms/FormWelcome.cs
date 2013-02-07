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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyNes.Renderers;
using MLV;
using MyNes.Core;
namespace MyNes
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
            checkBox1.Checked = Program.Settings.ShowWelcomeAtStartup;
            tabControl1.SelectedIndex = Program.Settings.WelcomePageIndex;
            // Load things
            // recent roms
            ManagedListViewColumn column = new ManagedListViewColumn();
            column.HeaderText = "Name";
            column.ID = "name";
            column.Width = 120;
            managedListView1.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Path";
            column.ID = "path";
            column.Width = 220;
            managedListView1.Columns.Add(column);
            if (Program.Settings.RecentFiles == null) 
                Program.Settings.RecentFiles = new System.Collections.Specialized.StringCollection();
            foreach (string file in Program.Settings.RecentFiles)
            {
                ManagedListViewItem item = new ManagedListViewItem();
                item.Tag = file;

                ManagedListViewSubItem subitem = new ManagedListViewSubItem();
                subitem.ColumnID = "name";
                subitem.DrawMode = ManagedListViewItemDrawMode.Text;
                subitem.Text = Path.GetFileName(file);
                item.SubItems.Add(subitem);

                subitem = new ManagedListViewSubItem();
                subitem.ColumnID = "path";
                subitem.DrawMode = ManagedListViewItemDrawMode.Text;
                subitem.Text = file;
                item.SubItems.Add(subitem);

                managedListView1.Items.Add(item);
            }
            // save states
            if (Directory.Exists(RenderersCore.SettingsManager.Settings.Folders_StateFolder))
            {
                string[] stateFiles = Directory.GetFiles(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
                foreach (string file in stateFiles)
                {
                    if (Path.GetExtension(file).ToLower() == ".msn")
                    {
                        ManagedListViewItem item = new ManagedListViewItem();
                        item.Text = Path.GetFileName(file);
                        item.Tag = file;
                        item.DrawMode = ManagedListViewItemDrawMode.UserDraw;
                        managedListView_states.Items.Add(item);
                    }
                }
            }
        }
        string stateFile = "";
        private void managedListView_states_DrawItem(object sender, MLV.ManagedListViewItemDrawArgs e)
        {
            string path = managedListView_states.Items[e.ItemIndex].Tag.ToString();
            e.TextToDraw = managedListView_states.Items[e.ItemIndex].Text;
           // e.ImageToDraw = Image.FromFile(managedListView_states.Items[e.ItemIndex].Tag.ToString());
            string imagePath = Path.GetDirectoryName(path) +
                "\\" + Path.GetFileNameWithoutExtension(path) + ".png";
            e.ImageToDraw = Image.FromFile(imagePath);
        }

        private void FormWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Settings.ShowWelcomeAtStartup = checkBox1.Checked;
            Program.Settings.WelcomePageIndex = tabControl1.SelectedIndex;
            Program.Settings.Save();
        }

        private void managedListView_states_ItemDoubleClick(object sender, ManagedListViewItemDoubleClickArgs e)
        {
            // get rom path
            stateFile = managedListView_states.Items[e.ClickedItemIndex].Tag.ToString();
            string path = File.ReadAllText(Path.GetDirectoryName(stateFile) +
                "\\" + Path.GetFileNameWithoutExtension(stateFile) + ".txt");
            Program.FormMain.OpenRom(path);
            // load state
            while (!Nes.VideoDevice.Initialized) { }
            if (Nes.ON && File.Exists(stateFile))
            { Nes.LoadStateAs(stateFile); } 
            this.Close();
        }

        private void managedListView1_ItemDoubleClick(object sender, ManagedListViewItemDoubleClickArgs e)
        {
            Program.FormMain.OpenRom(managedListView1.Items[e.ClickedItemIndex].Tag.ToString());
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
