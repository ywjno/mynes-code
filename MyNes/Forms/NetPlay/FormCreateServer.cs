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
    public partial class FormCreateServer : Form
    {
        public FormCreateServer()
        {
            InitializeComponent();
        }
        public string UserName
        { get { return textBox_username.Text; } }
        public string Password
        { get { return textBox_serverPassword.Text; } }
        //create server
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text.Length == 0)
            {
                MessageBox.Show("Please enter user name first.");
                return;
            }
            // create the server
            RemotingObject theObject = new RemotingObject();

            theObject.IsPasswordProtected = textBox_serverPassword.Text.Length > 0;
            theObject.Password = textBox_serverPassword.Text;

            theObject.ServerName = "mns";//(My Nes Server)
            // register the server
            NP.CreateServer("mns", theObject, (int)numericUpDown1.Value);
            // close this window
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
