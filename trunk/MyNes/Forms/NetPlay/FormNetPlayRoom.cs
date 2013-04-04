using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MyNes.Core;
using MyNes.Core.NetPlay;
using MyNes.Core.IO.Input;
using MLV;

namespace MyNes
{
    public partial class FormNetPlayRoom : Form
    {
        public FormNetPlayRoom(string userName, string password, string serverAddress, bool isCreatingServer)
        {
            InitializeComponent();
            SetupPlayersListView();
            LogIn(userName, password, serverAddress, isCreatingServer);
        }

        public void LogIn(string userName, string password, string serverAddress, bool isCreatingServer)
        {
            this.userName = userName;
            this.password = password;
            this.isServer = isCreatingServer;
            this.Text = "NetPlay Room (logged in as " + userName + ")";
            // get the server object
            try
            {
                remotingObject = NP.GetServerObject(serverAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't join this server:\n" + ex.Message);
                Close();
                return;
            }
            if (remotingObject != null)
            {
                if (isCreatingServer)
                {
                    // in this case the user is the admin and creating this server ...
                    try
                    {
                        remotingObject.Join(userName, password, true);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can't join this server:\n" + ex.Message);
                        Close();
                        return;
                    }
                    remotingObject.IsPasswordProtected = true;
                    remotingObject.Password = password;
                    remotingObject.IsServerRunning = true;
                    remotingObject.MaxPlayersNumber = 4;
                    remotingObject.RomSha1 = Nes.RomInfo.SHA1;
                    remotingObject.IsPlaying = false;
                    remotingObject.joypad1 = new NPJoypad();
                    remotingObject.joypad2 = new NPJoypad();
                    remotingObject.joypad3 = new NPJoypad();
                    remotingObject.joypad4 = new NPJoypad();

                    textBox_ip.Text = NP.GetServerIPAddress();
                    textBox_port.Text = NP.PortNumber.ToString();
                }
                else
                {
                    // the user is client. Disable controls ...
                    groupBox_gameObtions.Enabled = false;
                    button_ready.Enabled = false;
                    button_ban.Enabled = false;
                    button_kick.Enabled = false;
                    button_setPlayer.Enabled = false;
                    groupBox_serverStatus.Visible = false;
                    if (remotingObject.RomSha1 != Nes.RomInfo.SHA1)
                    {
                        MessageBox.Show("Can't join this server:\n" + "The game that currently loaded in the emulation core is not match the server game !");
                        Close();
                        return;
                    }
                    try
                    {
                        remotingObject.Join(userName, password);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can't join this server:\n" + ex.Message);
                        Close();
                        return;
                    }
                    // join immediatly !
                    if (remotingObject.IsPlaying)
                        remotingObject.StartRequest = true;
                }
                // update chat
                messageIndex = remotingObject.messageIndex - 1;
                joypad = Nes.ControlsUnit.Joypad1;// we'll need this
                playerIndex = remotingObject.GetPlayerIndex(this.userName);
                timer1.Start();
                //game options
                textBox_romSha1.Text = Nes.RomInfo.SHA1;
            }
            else
            {
                MessageBox.Show("Can't join this server, the remoting object is currepted.");
                Close();
                return;
            }
        }
        public RemotingObject remotingObject;
        // chat items
        private string userName;
        private string password;
        private int messageIndex = 0;
        private bool isServer = false;
        // playing items
        private IJoypad joypad;
        private int playerIndex;

        private delegate void AddText(string text);

        private void SetupPlayersListView()
        {
            ManagedListViewColumn column = new ManagedListViewColumn();
            column.HeaderText = "Player name";
            column.ID = "player name";
            column.Width = 120;
            managedListView1.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Is admin";
            column.ID = "admin";
            column.Width = 60;
            managedListView1.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Player #";
            column.ID = "player number";
            column.Width = 60;
            managedListView1.Columns.Add(column);
        }
        private void AddPlayerToList(Player user)
        {
            ManagedListViewItem item = new ManagedListViewItem();

            // player name sub item
            ManagedListViewSubItem subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "player name";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = user.Name;
            item.SubItems.Add(subitem);

            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "admin";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = user.Admin ? "Yes" : "No";
            item.SubItems.Add(subitem);

            subitem = new ManagedListViewSubItem();
            subitem.ColumnID = "player number";
            subitem.DrawMode = ManagedListViewItemDrawMode.Text;
            subitem.Text = "Player " + user.Number;
            item.SubItems.Add(subitem);

            managedListView1.Items.Add(item);
        }

        private void SendMessage()
        {
            if (textBox_message.Text != "")
            {
                remotingObject.SendMessage(userName + ": " + textBox_message.Text);
            }
        }

        void UpdateVscroll()
        {
            if (!this.InvokeRequired)
            {
                this.UpdateVscroll1();
            }
            else
            {
                this.Invoke(new Action(UpdateVscroll1));
            }
        }
        void UpdateVscroll1()
        {
            if (chatPanel1.StringHeight < chatPanel1.Height)
            {
                vScrollBar1.Maximum = 1;
                vScrollBar1.Value = 0;
                vScrollBar1.Enabled = false;
                chatPanel1.ScrollOffset = 0;
            }
            else
            {
                vScrollBar1.Enabled = true;
                vScrollBar1.Maximum = chatPanel1.StringHeight - chatPanel1.Height + 10;
                vScrollBar1.Value = vScrollBar1.Maximum - 1;
                chatPanel1.ScrollOffset = vScrollBar1.Value;
            }
            chatPanel1.Invalidate();
        }

        private void chatPanel1_LinesUpdated(object sender, EventArgs e)
        {
            UpdateVscroll();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            chatPanel1.ScrollOffset = vScrollBar1.Value;
            chatPanel1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void textBox_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                SendMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNetPlayRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            // log out the user
            remotingObject.LogOut(this.userName);
            if (isServer)
            {
                remotingObject.IsServerRunning = false;
                NP.KillServer();
            }
            // shutdown nes
            Nes.Shutdown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "INES rom (*.nes)|*.nes;*.NES";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_romSha1.Text = op.FileName;
            }
        }
        // start server ...
        private void button_ready_Click(object sender, EventArgs e)
        {
            if (remotingObject == null)
            {
                MessageBox.Show("Remoting object is currepted.");
                return;
            }
            if (isServer)
            {
                // check the players count
                //if (remotingObject.Players.Count < 2)
                {
                //    MessageBox.Show("You can't start server without at least 2 players.");
               //     return;
                }
                // everything is ok. let's start the game !
                // set start request
                playerIndex = remotingObject.GetPlayerIndex(this.userName);
                remotingObject.StartRequest = true;
                Nes.TogglePause(false);
                Nes.SaveMemoryState();
                // submit the buffer
                Nes.TogglePause(true);
                remotingObject.SubmitState(Nes.GetMemoryState());
            }
        }
        //The Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remotingObject != null)
            {
                // check server status ...
                if (isServer)
                {
                    // server stoped for unexpected reason ...
                    if (NP.Status == ServerStatus.Off)
                    {
                        timer1.Stop();
                        // log out the user
                        remotingObject.LogOut(this.userName);
                        Nes.Shutdown();
                        MessageBox.Show("Server stopped for unexpected reason !!");
                        Close();
                        return;
                    }
                    // server status
                    switch (NP.Status)
                    {
                        case ServerStatus.Running: textBox_status.Text = "Running"; textBox_status.ForeColor = Color.Green; break;
                        case ServerStatus.Off: textBox_status.Text = "Off"; textBox_status.ForeColor = Color.Red; break;
                    }
                }
                else
                {
                    if (!remotingObject.IsServerRunning)
                    {
                        timer1.Stop();
                        Nes.Shutdown();
                        // the server is not running !
                        MessageBox.Show("Server is not running. Logging out.");
                        Close();
                        return;
                    }
                }
                // Check if this player still in server
                if (!remotingObject.IsUserExist(this.userName))
                {
                    timer1.Stop();
                    Nes.Shutdown();
                    MessageBox.Show("Logged out from the server !");
                    Close();
                    return;
                }
                // update data (submit joystick data using joystick we have)
                if (remotingObject.IsPlaying)
                {
                    if (!Nes.ON)// nes shutdown !!
                    {
                        timer1.Stop();
                        remotingObject.LogOut(this.userName);
                        MessageBox.Show("Nes shutdown !! logged out.");
                        Close();
                        return;
                    }
                    Nes.ControlsUnit.InputDevice.Update();
                    switch (remotingObject.Players[playerIndex].Number)
                    {
                        case 1: remotingObject.SubmitJoypad1Data(joypad.GetData()); break;
                        case 2: remotingObject.SubmitJoypad2Data(joypad.GetData()); break;
                        case 3: remotingObject.SubmitJoypad3Data(joypad.GetData()); break;
                        case 4: remotingObject.SubmitJoypad4Data(joypad.GetData()); break;
                    }
                    // if server, save state and submit to the remoting object
                    if (isServer)
                    {
                        Nes.SaveMemoryState();
                        while (Nes.saveMemoryStateRequest) { }
                        // submit the buffer
                        remotingObject.SubmitState(Nes.GetMemoryState());
                    }
                    else
                    {
                        // load state from buffer
                        Nes.SetMemoryState(remotingObject.STATE);
                        Nes.LoadMemoryState();
                    }
                }
                // refresh chat
                if (this.messageIndex != remotingObject.messageIndex)
                {
                    if (this.messageIndex >= 0 & this.messageIndex < remotingObject.messages.Count)
                    {
                        chatPanel1.AddLine(remotingObject.messages[messageIndex]);
                        messageIndex++;
                        UpdateVscroll();
                    }
                }

                // refresh players
                if (managedListView1.Items.Count != remotingObject.Players.Count)
                {
                    managedListView1.Items.Clear();
                    foreach (Player plyr in remotingObject.Players)
                        AddPlayerToList(plyr);
                    managedListView1.Invalidate();
                }

                // start new game ?
                if (remotingObject.StartRequest && !remotingObject.Players[playerIndex].Ready)
                {
                    // setup
                    Nes.ControlsUnit.IsNetPlay = true;
                    Nes.ControlsUnit.RemotingObject = this.remotingObject;
                    // set restart 
                    Nes.HardReset();
                    Nes.TogglePause(false);
                    if (isServer)
                        Nes.SaveMemoryState();
                    // set ready
                    remotingObject.SetPlayerReadyStatus(userName, true);
                }

                if (isServer)
                {
                    // starting ??
                    if (remotingObject.StartRequest)
                    {
                        if (remotingObject.IsAllUsersReady())
                        {
                            remotingObject.StartRequest = false;
                            remotingObject.IsPlaying = true;
                        }
                    }
                }
            }
        }

        private void button_kick_Click(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one player first.");
                return;
            }
            string user = managedListView1.SelectedItems[0].GetSubItemByID("player name").Text;
            remotingObject.LogOut(user);
        }

        private void button_ban_Click(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one player first.");
                return;
            }
            string user = managedListView1.SelectedItems[0].GetSubItemByID("player name").Text;
            remotingObject.SetPlayerBanned(user, true);
            remotingObject.LogOut(user);
        }

        private void button_setPlayer_Click(object sender, EventArgs e)
        {
            if (managedListView1.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one player first.");
                return;
            }
            string user = managedListView1.SelectedItems[0].GetSubItemByID("player name").Text;
            Frm_SetPlayerNumber frm = new Frm_SetPlayerNumber(remotingObject);
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                remotingObject.SetPlayerNumber(user, frm.PlayerNumber);
                managedListView1.SelectedItems[0].GetSubItemByID("player number").Text = "Player " + frm.PlayerNumber;
            }
        }
    }
}
