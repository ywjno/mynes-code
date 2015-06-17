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
namespace MyNes
{
    partial class FormDetectAndDownloadFromTheGamesDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetectAndDownloadFromTheGamesDB));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_platforms = new System.Windows.Forms.ComboBox();
            this.checkBox_rename_rom = new System.Windows.Forms.CheckBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_overview_folder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_add_overview = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.radioButton_boxart_back_to_snaps = new System.Windows.Forms.RadioButton();
            this.radioButton_boxart_back_to_covers = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_boxart_back_folder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_add_boxart_back = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.radioButton_boxart_front_to_snaps = new System.Windows.Forms.RadioButton();
            this.radioButton_boxart_front_to_covers = new System.Windows.Forms.RadioButton();
            this.checkBox_include_boxart_front = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox_boxart_front_folder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.radioButton_fanart_to_snaps = new System.Windows.Forms.RadioButton();
            this.radioButton_fanart_to_covers = new System.Windows.Forms.RadioButton();
            this.checkBox_include_fanart = new System.Windows.Forms.CheckBox();
            this.checkBox_limit_download_fanart = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox_Fanart_folder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.radioButton_banners_to_snaps = new System.Windows.Forms.RadioButton();
            this.radioButton_banners_to_covers = new System.Windows.Forms.RadioButton();
            this.checkBox_include_banners = new System.Windows.Forms.CheckBox();
            this.checkBox_limit_download_banners = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox_Banners_folder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.radioButton1_screenshots_to_snaps = new System.Windows.Forms.RadioButton();
            this.radioButton_screenshots_to_covers = new System.Windows.Forms.RadioButton();
            this.checkBox_include_screenshots = new System.Windows.Forms.CheckBox();
            this.checkBox_limit_download_screenshots = new System.Windows.Forms.CheckBox();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox_Screenshots_folder = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox_clear_snapshots_table = new System.Windows.Forms.CheckBox();
            this.checkBox_clear_covers_table = new System.Windows.Forms.CheckBox();
            this.button_set_all = new System.Windows.Forms.Button();
            this.button_set_master_folder = new System.Windows.Forms.Button();
            this.checkBox_turboe = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_status = new System.Windows.Forms.GroupBox();
            this.progressBar_slave = new System.Windows.Forms.ProgressBar();
            this.label_status_sub = new System.Windows.Forms.Label();
            this.progressBar_master = new System.Windows.Forms.ProgressBar();
            this.label_status_master = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox_general = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_matchCase = new System.Windows.Forms.CheckBox();
            this.checkBox_matchWord = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_startWith = new System.Windows.Forms.RadioButton();
            this.radioButton_endwith = new System.Windows.Forms.RadioButton();
            this.radioButton_contains = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_searchmode_rominfile = new System.Windows.Forms.RadioButton();
            this.radioButton_searchmode_both = new System.Windows.Forms.RadioButton();
            this.radioButton_searchmode_fileinrom = new System.Windows.Forms.RadioButton();
            this.checkBox_clear_info_table = new System.Windows.Forms.CheckBox();
            this.checkBox_useNameWhenPathNotValid = new System.Windows.Forms.CheckBox();
            this.checkBox_useRomNameInstead = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_status.SuspendLayout();
            this.groupBox_general.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBox_platforms
            // 
            this.comboBox_platforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_platforms.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_platforms, "comboBox_platforms");
            this.comboBox_platforms.Name = "comboBox_platforms";
            // 
            // checkBox_rename_rom
            // 
            resources.ApplyResources(this.checkBox_rename_rom, "checkBox_rename_rom");
            this.checkBox_rename_rom.Checked = true;
            this.checkBox_rename_rom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rename_rom.Name = "checkBox_rename_rom";
            this.checkBox_rename_rom.UseVisualStyleBackColor = true;
            // 
            // button_start
            // 
            resources.ApplyResources(this.button_start, "button_start");
            this.button_start.Name = "button_start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox_overview_folder);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.checkBox_add_overview);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox_overview_folder
            // 
            resources.ApplyResources(this.textBox_overview_folder, "textBox_overview_folder");
            this.textBox_overview_folder.Name = "textBox_overview_folder";
            this.textBox_overview_folder.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // checkBox_add_overview
            // 
            resources.ApplyResources(this.checkBox_add_overview, "checkBox_add_overview");
            this.checkBox_add_overview.Checked = true;
            this.checkBox_add_overview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_add_overview.Name = "checkBox_add_overview";
            this.checkBox_add_overview.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.radioButton_boxart_back_to_snaps);
            this.tabPage2.Controls.Add(this.radioButton_boxart_back_to_covers);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.textBox_boxart_back_folder);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.checkBox_add_boxart_back);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // radioButton_boxart_back_to_snaps
            // 
            resources.ApplyResources(this.radioButton_boxart_back_to_snaps, "radioButton_boxart_back_to_snaps");
            this.radioButton_boxart_back_to_snaps.Name = "radioButton_boxart_back_to_snaps";
            this.radioButton_boxart_back_to_snaps.UseVisualStyleBackColor = true;
            // 
            // radioButton_boxart_back_to_covers
            // 
            resources.ApplyResources(this.radioButton_boxart_back_to_covers, "radioButton_boxart_back_to_covers");
            this.radioButton_boxart_back_to_covers.Checked = true;
            this.radioButton_boxart_back_to_covers.Name = "radioButton_boxart_back_to_covers";
            this.radioButton_boxart_back_to_covers.TabStop = true;
            this.radioButton_boxart_back_to_covers.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox_boxart_back_folder
            // 
            resources.ApplyResources(this.textBox_boxart_back_folder, "textBox_boxart_back_folder");
            this.textBox_boxart_back_folder.Name = "textBox_boxart_back_folder";
            this.textBox_boxart_back_folder.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // checkBox_add_boxart_back
            // 
            resources.ApplyResources(this.checkBox_add_boxart_back, "checkBox_add_boxart_back");
            this.checkBox_add_boxart_back.Checked = true;
            this.checkBox_add_boxart_back.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_add_boxart_back.Name = "checkBox_add_boxart_back";
            this.checkBox_add_boxart_back.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.radioButton_boxart_front_to_snaps);
            this.tabPage3.Controls.Add(this.radioButton_boxart_front_to_covers);
            this.tabPage3.Controls.Add(this.checkBox_include_boxart_front);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.textBox_boxart_front_folder);
            this.tabPage3.Controls.Add(this.label6);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // radioButton_boxart_front_to_snaps
            // 
            resources.ApplyResources(this.radioButton_boxart_front_to_snaps, "radioButton_boxart_front_to_snaps");
            this.radioButton_boxart_front_to_snaps.Name = "radioButton_boxart_front_to_snaps";
            this.radioButton_boxart_front_to_snaps.UseVisualStyleBackColor = true;
            // 
            // radioButton_boxart_front_to_covers
            // 
            resources.ApplyResources(this.radioButton_boxart_front_to_covers, "radioButton_boxart_front_to_covers");
            this.radioButton_boxart_front_to_covers.Checked = true;
            this.radioButton_boxart_front_to_covers.Name = "radioButton_boxart_front_to_covers";
            this.radioButton_boxart_front_to_covers.TabStop = true;
            this.radioButton_boxart_front_to_covers.UseVisualStyleBackColor = true;
            // 
            // checkBox_include_boxart_front
            // 
            resources.ApplyResources(this.checkBox_include_boxart_front, "checkBox_include_boxart_front");
            this.checkBox_include_boxart_front.Checked = true;
            this.checkBox_include_boxart_front.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_include_boxart_front.Name = "checkBox_include_boxart_front";
            this.checkBox_include_boxart_front.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox_boxart_front_folder
            // 
            resources.ApplyResources(this.textBox_boxart_front_folder, "textBox_boxart_front_folder");
            this.textBox_boxart_front_folder.Name = "textBox_boxart_front_folder";
            this.textBox_boxart_front_folder.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.radioButton_fanart_to_snaps);
            this.tabPage4.Controls.Add(this.radioButton_fanart_to_covers);
            this.tabPage4.Controls.Add(this.checkBox_include_fanart);
            this.tabPage4.Controls.Add(this.checkBox_limit_download_fanart);
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Controls.Add(this.textBox_Fanart_folder);
            this.tabPage4.Controls.Add(this.label8);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // radioButton_fanart_to_snaps
            // 
            resources.ApplyResources(this.radioButton_fanart_to_snaps, "radioButton_fanart_to_snaps");
            this.radioButton_fanart_to_snaps.Checked = true;
            this.radioButton_fanart_to_snaps.Name = "radioButton_fanart_to_snaps";
            this.radioButton_fanart_to_snaps.TabStop = true;
            this.radioButton_fanart_to_snaps.UseVisualStyleBackColor = true;
            // 
            // radioButton_fanart_to_covers
            // 
            resources.ApplyResources(this.radioButton_fanart_to_covers, "radioButton_fanart_to_covers");
            this.radioButton_fanart_to_covers.Name = "radioButton_fanart_to_covers";
            this.radioButton_fanart_to_covers.UseVisualStyleBackColor = true;
            // 
            // checkBox_include_fanart
            // 
            resources.ApplyResources(this.checkBox_include_fanart, "checkBox_include_fanart");
            this.checkBox_include_fanart.Checked = true;
            this.checkBox_include_fanart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_include_fanart.Name = "checkBox_include_fanart";
            this.checkBox_include_fanart.UseVisualStyleBackColor = true;
            // 
            // checkBox_limit_download_fanart
            // 
            resources.ApplyResources(this.checkBox_limit_download_fanart, "checkBox_limit_download_fanart");
            this.checkBox_limit_download_fanart.Name = "checkBox_limit_download_fanart";
            this.checkBox_limit_download_fanart.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox_Fanart_folder
            // 
            resources.ApplyResources(this.textBox_Fanart_folder, "textBox_Fanart_folder");
            this.textBox_Fanart_folder.Name = "textBox_Fanart_folder";
            this.textBox_Fanart_folder.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.radioButton_banners_to_snaps);
            this.tabPage5.Controls.Add(this.radioButton_banners_to_covers);
            this.tabPage5.Controls.Add(this.checkBox_include_banners);
            this.tabPage5.Controls.Add(this.checkBox_limit_download_banners);
            this.tabPage5.Controls.Add(this.button7);
            this.tabPage5.Controls.Add(this.textBox_Banners_folder);
            this.tabPage5.Controls.Add(this.label10);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // radioButton_banners_to_snaps
            // 
            resources.ApplyResources(this.radioButton_banners_to_snaps, "radioButton_banners_to_snaps");
            this.radioButton_banners_to_snaps.Checked = true;
            this.radioButton_banners_to_snaps.Name = "radioButton_banners_to_snaps";
            this.radioButton_banners_to_snaps.TabStop = true;
            this.radioButton_banners_to_snaps.UseVisualStyleBackColor = true;
            // 
            // radioButton_banners_to_covers
            // 
            resources.ApplyResources(this.radioButton_banners_to_covers, "radioButton_banners_to_covers");
            this.radioButton_banners_to_covers.Name = "radioButton_banners_to_covers";
            this.radioButton_banners_to_covers.UseVisualStyleBackColor = true;
            // 
            // checkBox_include_banners
            // 
            resources.ApplyResources(this.checkBox_include_banners, "checkBox_include_banners");
            this.checkBox_include_banners.Checked = true;
            this.checkBox_include_banners.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_include_banners.Name = "checkBox_include_banners";
            this.checkBox_include_banners.UseVisualStyleBackColor = true;
            // 
            // checkBox_limit_download_banners
            // 
            resources.ApplyResources(this.checkBox_limit_download_banners, "checkBox_limit_download_banners");
            this.checkBox_limit_download_banners.Name = "checkBox_limit_download_banners";
            this.checkBox_limit_download_banners.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_banners_Click);
            // 
            // textBox_Banners_folder
            // 
            resources.ApplyResources(this.textBox_Banners_folder, "textBox_Banners_folder");
            this.textBox_Banners_folder.Name = "textBox_Banners_folder";
            this.textBox_Banners_folder.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.radioButton1_screenshots_to_snaps);
            this.tabPage6.Controls.Add(this.radioButton_screenshots_to_covers);
            this.tabPage6.Controls.Add(this.checkBox_include_screenshots);
            this.tabPage6.Controls.Add(this.checkBox_limit_download_screenshots);
            this.tabPage6.Controls.Add(this.button8);
            this.tabPage6.Controls.Add(this.textBox_Screenshots_folder);
            this.tabPage6.Controls.Add(this.label12);
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // radioButton1_screenshots_to_snaps
            // 
            resources.ApplyResources(this.radioButton1_screenshots_to_snaps, "radioButton1_screenshots_to_snaps");
            this.radioButton1_screenshots_to_snaps.Checked = true;
            this.radioButton1_screenshots_to_snaps.Name = "radioButton1_screenshots_to_snaps";
            this.radioButton1_screenshots_to_snaps.TabStop = true;
            this.radioButton1_screenshots_to_snaps.UseVisualStyleBackColor = true;
            // 
            // radioButton_screenshots_to_covers
            // 
            resources.ApplyResources(this.radioButton_screenshots_to_covers, "radioButton_screenshots_to_covers");
            this.radioButton_screenshots_to_covers.Name = "radioButton_screenshots_to_covers";
            this.radioButton_screenshots_to_covers.UseVisualStyleBackColor = true;
            // 
            // checkBox_include_screenshots
            // 
            resources.ApplyResources(this.checkBox_include_screenshots, "checkBox_include_screenshots");
            this.checkBox_include_screenshots.Checked = true;
            this.checkBox_include_screenshots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_include_screenshots.Name = "checkBox_include_screenshots";
            this.checkBox_include_screenshots.UseVisualStyleBackColor = true;
            // 
            // checkBox_limit_download_screenshots
            // 
            resources.ApplyResources(this.checkBox_limit_download_screenshots, "checkBox_limit_download_screenshots");
            this.checkBox_limit_download_screenshots.Name = "checkBox_limit_download_screenshots";
            this.checkBox_limit_download_screenshots.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox_Screenshots_folder
            // 
            resources.ApplyResources(this.textBox_Screenshots_folder, "textBox_Screenshots_folder");
            this.textBox_Screenshots_folder.Name = "textBox_Screenshots_folder";
            this.textBox_Screenshots_folder.ReadOnly = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // checkBox_clear_snapshots_table
            // 
            resources.ApplyResources(this.checkBox_clear_snapshots_table, "checkBox_clear_snapshots_table");
            this.checkBox_clear_snapshots_table.Name = "checkBox_clear_snapshots_table";
            this.checkBox_clear_snapshots_table.UseVisualStyleBackColor = true;
            // 
            // checkBox_clear_covers_table
            // 
            resources.ApplyResources(this.checkBox_clear_covers_table, "checkBox_clear_covers_table");
            this.checkBox_clear_covers_table.Name = "checkBox_clear_covers_table";
            this.checkBox_clear_covers_table.UseVisualStyleBackColor = true;
            // 
            // button_set_all
            // 
            resources.ApplyResources(this.button_set_all, "button_set_all");
            this.button_set_all.Name = "button_set_all";
            this.button_set_all.UseVisualStyleBackColor = true;
            this.button_set_all.Click += new System.EventHandler(this.button9_Click);
            // 
            // button_set_master_folder
            // 
            resources.ApplyResources(this.button_set_master_folder, "button_set_master_folder");
            this.button_set_master_folder.Name = "button_set_master_folder";
            this.button_set_master_folder.UseVisualStyleBackColor = true;
            this.button_set_master_folder.Click += new System.EventHandler(this.button10_Click);
            // 
            // checkBox_turboe
            // 
            resources.ApplyResources(this.checkBox_turboe, "checkBox_turboe");
            this.checkBox_turboe.Name = "checkBox_turboe";
            this.checkBox_turboe.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MyNes.Properties.Resources.the_game_db;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox_status
            // 
            this.groupBox_status.Controls.Add(this.progressBar_slave);
            this.groupBox_status.Controls.Add(this.label_status_sub);
            this.groupBox_status.Controls.Add(this.progressBar_master);
            this.groupBox_status.Controls.Add(this.label_status_master);
            resources.ApplyResources(this.groupBox_status, "groupBox_status");
            this.groupBox_status.Name = "groupBox_status";
            this.groupBox_status.TabStop = false;
            // 
            // progressBar_slave
            // 
            resources.ApplyResources(this.progressBar_slave, "progressBar_slave");
            this.progressBar_slave.Name = "progressBar_slave";
            // 
            // label_status_sub
            // 
            resources.ApplyResources(this.label_status_sub, "label_status_sub");
            this.label_status_sub.Name = "label_status_sub";
            // 
            // progressBar_master
            // 
            resources.ApplyResources(this.progressBar_master, "progressBar_master");
            this.progressBar_master.Name = "progressBar_master";
            // 
            // label_status_master
            // 
            resources.ApplyResources(this.label_status_master, "label_status_master");
            this.label_status_master.Name = "label_status_master";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox_general
            // 
            this.groupBox_general.Controls.Add(this.groupBox3);
            this.groupBox_general.Controls.Add(this.groupBox2);
            this.groupBox_general.Controls.Add(this.groupBox1);
            this.groupBox_general.Controls.Add(this.checkBox_clear_info_table);
            this.groupBox_general.Controls.Add(this.checkBox_useNameWhenPathNotValid);
            this.groupBox_general.Controls.Add(this.checkBox_clear_covers_table);
            this.groupBox_general.Controls.Add(this.checkBox_clear_snapshots_table);
            this.groupBox_general.Controls.Add(this.checkBox_useRomNameInstead);
            this.groupBox_general.Controls.Add(this.checkBox_rename_rom);
            this.groupBox_general.Controls.Add(this.checkBox_turboe);
            this.groupBox_general.Controls.Add(this.tabControl1);
            this.groupBox_general.Controls.Add(this.button_set_all);
            this.groupBox_general.Controls.Add(this.button_set_master_folder);
            this.groupBox_general.Controls.Add(this.comboBox_platforms);
            this.groupBox_general.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox_general, "groupBox_general");
            this.groupBox_general.Name = "groupBox_general";
            this.groupBox_general.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_matchCase);
            this.groupBox3.Controls.Add(this.checkBox_matchWord);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // checkBox_matchCase
            // 
            resources.ApplyResources(this.checkBox_matchCase, "checkBox_matchCase");
            this.checkBox_matchCase.Name = "checkBox_matchCase";
            this.checkBox_matchCase.UseVisualStyleBackColor = true;
            // 
            // checkBox_matchWord
            // 
            resources.ApplyResources(this.checkBox_matchWord, "checkBox_matchWord");
            this.checkBox_matchWord.Name = "checkBox_matchWord";
            this.checkBox_matchWord.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_startWith);
            this.groupBox2.Controls.Add(this.radioButton_endwith);
            this.groupBox2.Controls.Add(this.radioButton_contains);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // radioButton_startWith
            // 
            resources.ApplyResources(this.radioButton_startWith, "radioButton_startWith");
            this.radioButton_startWith.Checked = true;
            this.radioButton_startWith.Name = "radioButton_startWith";
            this.radioButton_startWith.TabStop = true;
            this.radioButton_startWith.UseVisualStyleBackColor = true;
            // 
            // radioButton_endwith
            // 
            resources.ApplyResources(this.radioButton_endwith, "radioButton_endwith");
            this.radioButton_endwith.Name = "radioButton_endwith";
            this.radioButton_endwith.UseVisualStyleBackColor = true;
            // 
            // radioButton_contains
            // 
            resources.ApplyResources(this.radioButton_contains, "radioButton_contains");
            this.radioButton_contains.Name = "radioButton_contains";
            this.radioButton_contains.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_searchmode_rominfile);
            this.groupBox1.Controls.Add(this.radioButton_searchmode_both);
            this.groupBox1.Controls.Add(this.radioButton_searchmode_fileinrom);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioButton_searchmode_rominfile
            // 
            resources.ApplyResources(this.radioButton_searchmode_rominfile, "radioButton_searchmode_rominfile");
            this.radioButton_searchmode_rominfile.Name = "radioButton_searchmode_rominfile";
            this.radioButton_searchmode_rominfile.UseVisualStyleBackColor = true;
            // 
            // radioButton_searchmode_both
            // 
            resources.ApplyResources(this.radioButton_searchmode_both, "radioButton_searchmode_both");
            this.radioButton_searchmode_both.Name = "radioButton_searchmode_both";
            this.radioButton_searchmode_both.UseVisualStyleBackColor = true;
            // 
            // radioButton_searchmode_fileinrom
            // 
            resources.ApplyResources(this.radioButton_searchmode_fileinrom, "radioButton_searchmode_fileinrom");
            this.radioButton_searchmode_fileinrom.Checked = true;
            this.radioButton_searchmode_fileinrom.Name = "radioButton_searchmode_fileinrom";
            this.radioButton_searchmode_fileinrom.TabStop = true;
            this.radioButton_searchmode_fileinrom.UseVisualStyleBackColor = true;
            // 
            // checkBox_clear_info_table
            // 
            resources.ApplyResources(this.checkBox_clear_info_table, "checkBox_clear_info_table");
            this.checkBox_clear_info_table.Name = "checkBox_clear_info_table";
            this.checkBox_clear_info_table.UseVisualStyleBackColor = true;
            // 
            // checkBox_useNameWhenPathNotValid
            // 
            resources.ApplyResources(this.checkBox_useNameWhenPathNotValid, "checkBox_useNameWhenPathNotValid");
            this.checkBox_useNameWhenPathNotValid.Checked = true;
            this.checkBox_useNameWhenPathNotValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_useNameWhenPathNotValid.Name = "checkBox_useNameWhenPathNotValid";
            this.checkBox_useNameWhenPathNotValid.UseVisualStyleBackColor = true;
            // 
            // checkBox_useRomNameInstead
            // 
            resources.ApplyResources(this.checkBox_useRomNameInstead, "checkBox_useRomNameInstead");
            this.checkBox_useRomNameInstead.Name = "checkBox_useRomNameInstead";
            this.checkBox_useRomNameInstead.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // FormDetectAndDownloadFromTheGamesDB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_general);
            this.Controls.Add(this.groupBox_status);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetectAndDownloadFromTheGamesDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_DetectAndDownloadFromTheGamesDB_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_status.ResumeLayout(false);
            this.groupBox_general.ResumeLayout(false);
            this.groupBox_general.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_platforms;
        private System.Windows.Forms.CheckBox checkBox_rename_rom;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_overview_folder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_add_overview;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox_boxart_back_folder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_add_boxart_back;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox_boxart_front_folder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox_Fanart_folder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox_Banners_folder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox_Screenshots_folder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_set_all;
        private System.Windows.Forms.Button button_set_master_folder;
        private System.Windows.Forms.CheckBox checkBox_turboe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox_status;
        private System.Windows.Forms.ProgressBar progressBar_slave;
        private System.Windows.Forms.Label label_status_sub;
        private System.Windows.Forms.ProgressBar progressBar_master;
        private System.Windows.Forms.Label label_status_master;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_clear_snapshots_table;
        private System.Windows.Forms.CheckBox checkBox_limit_download_fanart;
        private System.Windows.Forms.CheckBox checkBox_limit_download_banners;
        private System.Windows.Forms.CheckBox checkBox_limit_download_screenshots;
        private System.Windows.Forms.GroupBox groupBox_general;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton_boxart_back_to_snaps;
        private System.Windows.Forms.RadioButton radioButton_boxart_back_to_covers;
        private System.Windows.Forms.RadioButton radioButton_boxart_front_to_snaps;
        private System.Windows.Forms.RadioButton radioButton_boxart_front_to_covers;
        private System.Windows.Forms.CheckBox checkBox_clear_covers_table;
        private System.Windows.Forms.CheckBox checkBox_include_boxart_front;
        private System.Windows.Forms.RadioButton radioButton_fanart_to_snaps;
        private System.Windows.Forms.RadioButton radioButton_fanart_to_covers;
        private System.Windows.Forms.CheckBox checkBox_include_fanart;
        private System.Windows.Forms.RadioButton radioButton_banners_to_snaps;
        private System.Windows.Forms.RadioButton radioButton_banners_to_covers;
        private System.Windows.Forms.CheckBox checkBox_include_banners;
        private System.Windows.Forms.RadioButton radioButton1_screenshots_to_snaps;
        private System.Windows.Forms.RadioButton radioButton_screenshots_to_covers;
        private System.Windows.Forms.CheckBox checkBox_include_screenshots;
        private System.Windows.Forms.CheckBox checkBox_useNameWhenPathNotValid;
        private System.Windows.Forms.CheckBox checkBox_useRomNameInstead;
        private System.Windows.Forms.CheckBox checkBox_clear_info_table;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_startWith;
        private System.Windows.Forms.RadioButton radioButton_endwith;
        private System.Windows.Forms.RadioButton radioButton_contains;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_searchmode_rominfile;
        private System.Windows.Forms.RadioButton radioButton_searchmode_both;
        private System.Windows.Forms.RadioButton radioButton_searchmode_fileinrom;
        private System.Windows.Forms.CheckBox checkBox_matchWord;
        private System.Windows.Forms.CheckBox checkBox_matchCase;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}