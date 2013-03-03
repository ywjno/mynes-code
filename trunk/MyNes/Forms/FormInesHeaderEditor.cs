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
using MyNes.Core;
using MyNes.Core.Database;
using MyNes.Core.ROM;
using MyNes.Core.Boards;
namespace MyNes
{
    public partial class FormInesHeaderEditor : Form
    {
        public FormInesHeaderEditor()
        {
            InitializeComponent();
            button1_Click(this, null);
        }
        public FormInesHeaderEditor(string FilePath)
        {
            InitializeComponent();
            this.filePath = FilePath;
            button3_Click(this, null);
        }
        private INESHeader header;
        private RomInfo info;
        private string filePath;

        private void OpenFile(string filePath)
        {
            this.filePath = filePath;
            if (Path.GetExtension(filePath).ToLower() != ".nes")
            {
                MessageBox.Show("Can't open this file. It's not an INES format file.");
                button_save.Enabled = false;
                return;
            }
            header = new INESHeader(filePath);

            if (header.IsValid)
            {
                info = new RomInfo(filePath);
                info.Format = "INES";
                info.CHRcount = header.ChrPages;
                info.PRGcount = header.PrgPages;
                info.Mirroring = header.Mirroring;
                info.MapperBoard = "Mapper " + header.Mapper;
                info.HasSaveRam = header.HasSaveRam;
                // This is not a fix, 
                // all mapper 99 roms are vsunisystem and doesn't have the flag set !
                info.VSUnisystem = header.IsVSUnisystem || (header.Mapper == 99);
                info.PC10 = header.IsPlaychoice10;

                //Get general information
                textBox_romPath.Text = info.Path;
                textBox_sha1.Text = info.SHA1.ToUpper();
                textBox_size.Text = Helper.GetFileSize(filePath);
                numericUpDown_prgCount.Value = info.PRGcount;
                numericUpDown_chrCount.Value = info.CHRcount;
                switch (info.Mirroring)
                {
                    case Core.Types.Mirroring.ModeFull: comboBox1.SelectedIndex = 2; break;
                    case Core.Types.Mirroring.ModeHorz: comboBox1.SelectedIndex = 0; break;
                    case Core.Types.Mirroring.ModeVert: comboBox1.SelectedIndex = 1; break;
                }
                numericUpDown_mapper.Value = header.Mapper;

                checkBox_isBattery.Checked = header.HasSaveRam;
                checkBox_pc10.Checked = header.IsPlaychoice10;
                checkBox_trainer.Checked = header.HasTrainer;
                checkBox_VSUnisystem.Checked = header.IsVSUnisystem;

                comboBox_version.SelectedIndex = header.IsVersion2 ? 1 : 0;
                switch (header.TVSystem)
                {
                    case INESRVSystem.NTSC: comboBox_tvSystem.SelectedIndex = 0; break;
                    case INESRVSystem.PAL: comboBox_tvSystem.SelectedIndex = 1; break;
                    case INESRVSystem.DualCompatible: comboBox_tvSystem.SelectedIndex = 2; break;
                }
                button_save.Enabled = true;
            }
            else
            {
                MessageBox.Show("Can't open this file. It's not in INES format or the file is currepted.");
                button_save.Enabled = false;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Change
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "INES rom (*.nes)|*.nes";
            op.Title = "Open rom to edit INES rom header";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OpenFile(op.FileName);
            }
        }
        // Reload file
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                OpenFile(filePath);
            }
            else
            {
                button1_Click(this, null);
            }
        }
        // Fix using database
        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_romPath.Text))
            {
                MessageBox.Show("No INES file !");
                return;
            }
            if (!File.Exists(".\\database.xml"))
            {
                MessageBox.Show("The database file is missing. Please make sure the database.xml file is presented in My Nes folder. This file should be presented by default.");
                return;
            }
            if (info.DatabaseGameInfo.Game_Name != null)
            {
                // mapper
                numericUpDown_mapper.Value = byte.Parse(info.DatabaseGameInfo.Board_Mapper);
                // prg
                if (info.DatabaseGameInfo.PRG_size != "")
                {
                    string size = info.DatabaseGameInfo.PRG_size.Replace("k", "");
                    int siz = int.Parse(size);
                    numericUpDown_prgCount.Value = siz / 16;
                }
                else
                {
                    numericUpDown_prgCount.Value = 0;
                }
                // chr
                if (info.DatabaseGameInfo.CHR_size != null && info.DatabaseGameInfo.CHR_size != "")
                {
                    string size = info.DatabaseGameInfo.CHR_size.Replace("k", "");
                    int siz = int.Parse(size);
                    numericUpDown_chrCount.Value = siz / 8;
                }
                else
                {
                    numericUpDown_chrCount.Value = 0;
                }
                // system  
                if (info.DatabaseCartInfo.System != null)
                {
                    if (info.DatabaseCartInfo.System.ToUpper().Contains("PAL"))
                        comboBox_tvSystem.SelectedIndex = 1;
                    else
                        comboBox_tvSystem.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("This rom can't be found in the database.");
            }
        }
        // Save changes
        private void button_save_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Please open file first.");
                return;
            }
            if (Path.GetExtension(filePath).ToLower() != ".nes")
            {
                MessageBox.Show("Can't save this file. It's not an INES format file.");
                button_save.Enabled = false;
                return;
            }
            if (comboBox_version.SelectedIndex == 1)
            {
                MessageBox.Show("INES version 2.0 is not supported. Sorry :/");
                return;
            }
            INESHeader sheader = new INESHeader();
            // save valus
            sheader.ChrPages = (byte)numericUpDown_chrCount.Value;
            sheader.HasSaveRam = checkBox_isBattery.Checked;
            sheader.HasTrainer = checkBox_trainer.Checked;
            sheader.IsPlaychoice10 = checkBox_pc10.Checked;
            sheader.IsVersion2 = comboBox_version.SelectedIndex == 1;
            sheader.IsVSUnisystem = checkBox_VSUnisystem.Checked;
            sheader.Mapper = (byte)numericUpDown_mapper.Value;
            switch (comboBox1.SelectedIndex)
            {
                case 0: sheader.Mirroring = Core.Types.Mirroring.ModeHorz; break;
                case 1: sheader.Mirroring = Core.Types.Mirroring.ModeVert; break;
                case 2: sheader.Mirroring = Core.Types.Mirroring.ModeFull; break;
            }
            sheader.PrgPages = (byte)numericUpDown_prgCount.Value;
            switch (comboBox_tvSystem.SelectedIndex)
            {
                case 0: sheader.TVSystem = INESRVSystem.NTSC; break;
                case 1: sheader.TVSystem = INESRVSystem.PAL; break;
                case 2: sheader.TVSystem = INESRVSystem.DualCompatible; break;
            }
            sheader.SaveFile(filePath);
            // the sha1 and the size maybe changed, reload them.
            RomInfo info1 = new RomInfo(filePath);
            textBox_sha1.Text = info1.SHA1.ToUpper();
            textBox_size.Text = Helper.GetFileSize(filePath);

            MessageBox.Show("Done");
        }
    }
}
