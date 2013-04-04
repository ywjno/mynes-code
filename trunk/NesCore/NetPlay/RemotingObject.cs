using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console = MyNes.Core.Console;
namespace MyNes.Core.NetPlay
{
    /// <summary>
    /// The remoting object which provide online play. Hold users, do the net play calculations .... etc
    /// </summary>
    public class RemotingObject : MarshalByRefObject
    {
        private List<Player> players = new List<Player>();
        private bool isPasswordProtected = false;
        private string password = "";
        private string serverName = "";
        private bool isServerRunning = false;
        private int maxPlayersNumber = 4;


        /// <summary>
        /// Join this server object as a normal user
        /// </summary>
        /// <param name="userName">The user name</param>
        public void Join(string userName)
        { Join(userName, "", false); }
        /// <summary>
        /// Join this server object as a normal user
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The server password</param>
        public void Join(string userName, string password)
        { Join(userName, password, false); }
        /// <summary>
        /// Join this server object
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The server password</param>
        /// <param name="isAdmin">Is this user an admin ?</param>
        public void Join(string userName, string password, bool isAdmin)
        {
            if (userName == "")
                throw new Exception("User name is empty !");

            if (players.Count == maxPlayersNumber)
                throw new Exception("The number of players reached the maximum number.");

            if (!isPasswordProtected)
            {
                // just ignore password and add the user ...
                if (!IsUserExist(userName))
                {
                    if (!IsUserBanned(userName))
                    {
                        Player newUser = new Player();
                        newUser.Name = userName;
                        newUser.Admin = isAdmin;
                        // set number 
                        for (int i = 1; i < 5; i++)
                        {
                            if (IsPlayerNumberAvailable(i))
                            {
                                newUser.Number = i;
                                break;
                            }
                        }
                        players.Add(newUser);
                        OnUserJoined(userName);
                    }
                    else
                    {
                        throw new Exception("This user is banned !!");
                    }
                }
                else
                {
                    throw new Exception("This user already exist !!");
                }
            }
            else// we need to do password check first !!
            {
                if (!CheckPassword(password))
                {
                    throw new Exception("Username is not exist, password is not correct or both !");
                }
                else
                {
                    // password match !
                    if (!IsUserExist(userName))
                    {
                        if (!IsUserBanned(userName))
                        {
                            Player newUser = new Player();
                            newUser.Name = userName;
                            newUser.Admin = isAdmin;
                            // set number 
                            for (int i = 1; i < 5; i++)
                            {
                                if (IsPlayerNumberAvailable(i))
                                {
                                    newUser.Number = i;
                                    break;
                                }
                            }
                            players.Add(newUser);
                            OnUserJoined(userName);
                        }
                        else
                        {
                            throw new Exception("This user is banned !!");
                        }
                    }
                    else
                    {
                        throw new Exception("This user already exist !!");
                    }
                }
            }
        }
        /// <summary>
        /// Get a user index
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetPlayerIndex(string userName)
        {
            for (int i = 0; i < players.Count;i++ )
            {
                if (players[i].Name.ToLower() == userName.ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsPlayerNumberAvailable(int number)
        {
            foreach (Player usr in players)
            {
                if (usr.Number == number)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Request a log out for a user
        /// </summary>
        /// <param name="userName">The user name</param>
        public void LogOut(string userName)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    // log out via removing this user from the list
                    players.Remove(usr);
                    OnUserLeave(userName);
                    break;
                }
            }
        }
        /// <summary>
        /// Check to see if a user exist
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <returns>True if the user name already exist otherwise false</returns>
        public bool IsUserExist(string userName)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get if an user is banned or not
        /// </summary>
        /// <param name="userName">The user name. Must be exist</param>
        /// <returns>True if the user exist and banned otherwise false</returns>
        public bool IsUserBanned(string userName)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    if (usr.Banned)
                        return true;
                }
            }
            return false;
        }

        //TODO: make a real secured password check
        private bool CheckPassword(string password)
        { return this.password == password; }

        /// <summary>
        /// Raise the UserJoined event
        /// </summary>
        /// <param name="userName">The user name</param>
        protected void OnUserJoined(string userName)
        {
            SendMessage(userName + " has joined the server.");
        }
        /// <summary>
        /// Raise the UserLeave event
        /// </summary>
        /// <param name="userName">The user name</param>
        protected void OnUserLeave(string userName)
        {
            SendMessage(userName + " has left the server.");
        }

        /// <summary>
        /// Get the users collection
        /// </summary>
        public List<Player> Players
        { get { return players; } }
        /// <summary>
        /// Get or set if this server is password protected
        /// </summary>
        public bool IsPasswordProtected
        { get { return isPasswordProtected; } set { isPasswordProtected = value; } }
        /// <summary>
        /// Get or set the password
        /// </summary>
        public string Password
        { get { return password; } set { password = value; } }
        /// <summary>
        /// Get or set the server name
        /// </summary>
        public string ServerName
        { get { return serverName; } set { serverName = value; } }
        /// <summary>
        /// Get or set the maximum players number. This can't be 0.
        /// </summary>
        public int MaxPlayersNumber
        {
            get { return maxPlayersNumber; }
            set
            {
                if (value > 0)
                    maxPlayersNumber = value;
                else
                    maxPlayersNumber = 1;
            }
        }
        /// <summary>
        /// Get or set if the server is alive
        /// </summary>
        public bool IsServerRunning
        { get { return isServerRunning; } set { isServerRunning = value; } }

        /*Messaging members (chat)*/
        public List<string> messages = new List<string>();
        public int messagesLimit = 10000;
        public int messageIndex = 0;

        public void SendMessage(string message)
        {
            messages.Add(message);
            // limit messages to messagesLimit
            if (messages.Count > messagesLimit)
            { messages.RemoveAt(0); }
            messageIndex++;
        }

        /*Emulation memebers*/
        public string RomSha1 = "";// the users must use this to ensure all of them have the same rom.
        public bool IsPlaying = false;
        public bool StartRequest = false;
        public byte[] STATE;
        // The joystick data
        public NPJoypad joypad1;
        public NPJoypad joypad2;
        public NPJoypad joypad3;
        public NPJoypad joypad4;

        public void SetPlayerReadyStatus(string userName,bool ready)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    usr.Ready = ready;
                    break;
                }
            }
        }
        public void SetPlayerFrame(string userName, long frame)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    usr.Frame = frame;
                    break;
                }
            }
        }
        public void SetPlayerPause(string userName, bool paused)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    usr.Paused = paused;
                    break;
                }
            }
        }
        public void SetPlayerBanned(string userName, bool banned)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    usr.Banned = banned;
                    break;
                }
            }
        }
        public void SetPlayerNumber(string userName, int number)
        {
            foreach (Player usr in players)
            {
                if (usr.Name.ToLower() == userName.ToLower())
                {
                    int oldNumber = usr.Number;
                    usr.Number = number;
                    // Refresh other users
                    foreach (Player plr in players)
                    {
                        if (plr.Number == number && plr.Name != userName.ToLower())
                        {
                            plr.Number = oldNumber;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        public bool IsAllUsersReady()
        {
            bool started = true;
            foreach (Player plr in players)
            {
                if (!plr.Ready)
                {
                    started = false;
                    break;
                }
            }
            return started;
        }
        public void SubmitJoypad1Data(byte data)
        {
            joypad1.SetData(data);
        }
        public void SubmitJoypad2Data(byte data)
        {
            joypad2.SetData(data);
        }
        public void SubmitJoypad3Data(byte data)
        {
            joypad3.SetData(data);
        }
        public void SubmitJoypad4Data(byte data)
        {
            joypad4.SetData(data);
        }

        public void SubmitState(byte[] state)
        {
            this.STATE = state;
        }
    }
}
