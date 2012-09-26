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
    public partial class FormPathSettings : Form
    {
        public FormPathSettings()
        {
            InitializeComponent();

            textBox_snapshots.Text = Program.Settings.SnapshotsFolder;
            textBox_statesFolder.Text = Program.Settings.StateFolder;
            textBox_browserDatabase.Text = Program.Settings.FoldersDatabasePath;
        }
        private bool refreshBrowser = false;

        public bool RefreshBrowser
        { get { return refreshBrowser; } }
        //save and close
        private void button3_Click(object sender, EventArgs e)
        {
            Program.Settings.SnapshotsFolder = textBox_snapshots.Text;
            Program.Settings.StateFolder = textBox_statesFolder.Text;
            Program.Settings.FoldersDatabasePath = textBox_browserDatabase.Text;
            Program.Settings.Save();
            Close();
        }
        //cancel
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        //defaults
        private void button5_Click(object sender, EventArgs e)
        {
            textBox_snapshots.Text = System.IO.Path.GetFullPath(@".\Snapshots");
            textBox_statesFolder.Text = System.IO.Path.GetFullPath(@".\StateSaves");
            textBox_browserDatabase.Text = System.IO.Path.GetFullPath(@".\fdb.fl");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = "Browse for state saves folder";
            fol.SelectedPath = textBox_statesFolder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                textBox_statesFolder.Text = fol.SelectedPath;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.Description = "Browse for snapshots folder";
            fol.SelectedPath = textBox_snapshots.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                textBox_snapshots.Text = fol.SelectedPath;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open MyNes folders database";
            op.Filter = "MyNes folders database (*.fl)|*.fl";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                refreshBrowser = true;
                textBox_browserDatabase.Text = op.FileName;
            }
        }
    }
}
