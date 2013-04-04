using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNes
{
    /// <summary>
    /// Args can used for checking login information
    /// </summary>
    public class ServerJoinArgs : EventArgs
    {
        /// <summary>
        /// Args can used for checking login information
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password of the server</param>
        /// <param name="serverAddress">The complete server address</param>
        public ServerJoinArgs(string userName, string password, string serverAddress)
        {
            this.userName = userName;
            this.password = password;
            this.serverAddress = serverAddress;
        }
        private string userName;
        private string password;
        private string serverAddress;
        private bool canJoin = false;

        /// <summary>
        /// Get or set if the user can join the server
        /// </summary>
        public bool CanJoin
        { get { return canJoin; } set { canJoin = value; } }
        /// <summary>
        /// Get the user name
        /// </summary>
        public string UserName
        { get { return userName; } }
        /// <summary>
        /// Get the password
        /// </summary>
        public string Password
        { get { return password; } }
        /// <summary>
        /// Get the server address
        /// </summary>
        public string ServerAddress
        { get { return serverAddress; } }
    }
}
