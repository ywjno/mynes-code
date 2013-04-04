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
    public partial class FormJoinServer : Form
    {
        public FormJoinServer()
        {
            InitializeComponent();
            if (Program.Settings.NetJoinIPS == null)
                Program.Settings.NetJoinIPS = new System.Collections.Specialized.StringCollection();
            foreach (string ip in Program.Settings.NetJoinIPS)
                comboBox_ip.Items.Add(ip);
        }
        public string UserName
        { get { return textBox_username.Text; } }
        public string Password
        { get { return textBox_password.Text; } }
        public string ServerIP
        { get { return comboBox_ip.Text; } }
        public int ServerPort
        { get { return (int)numericUpDown1.Value; } }

        public event EventHandler<ServerJoinArgs> CheckLogin;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_ip.Text == "")
            {
                MessageBox.Show("Please enter the server ip first !");
                return;
            }
            if (textBox_username.Text == "")
            {
                MessageBox.Show("Please enter the player name first !");
                return;
            }
            if (!comboBox_ip.Items.Contains(comboBox_ip.Text))
                comboBox_ip.Items.Add(comboBox_ip.Text);
            NP.ObjectName = "mns";
            ServerJoinArgs args = new ServerJoinArgs(textBox_username.Text, textBox_password.Text,
                NP.BuildAddress(comboBox_ip.Text, (int)numericUpDown1.Value));

            if (CheckLogin != null)
                CheckLogin(this, args);

            if (args.CanJoin)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void FormJoinServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Settings.NetJoinIPS = new System.Collections.Specialized.StringCollection();
            foreach (string ip in comboBox_ip.Items)
                Program.Settings.NetJoinIPS.Add(ip);
        }
    }
}
