using System;
namespace MyNes.Core.NetPlay
{
    /// <summary>
    /// Class represnts user
    /// </summary>
    [Serializable()]
    public class Player
    {
        /// <summary>
        /// Class represnts user
        /// </summary>
        public Player()
        {
        }
        /// <summary>
        /// Class represnts user
        /// </summary>
        /// <param name="name">The user name</param>
        /// <param name="isAdmin">Is this user an admin ?</param>
        public Player(string name, bool isAdmin)
        {
            this.name = name;
            this.isAdmin = isAdmin;
        }
        private string name = "";
        private bool banned = false;
        private bool isAdmin = false;
        private int playerNumber = 1;
        private bool ready = false;
        private long frame = 0;
        private bool paused = false;

        /// <summary>
        /// Get or set the user name
        /// </summary>
        public string Name
        { get { return name; } set { name = value; } }
        /// <summary>
        /// Get or set a value indecate whether this user is banned
        /// </summary>
        public bool Banned
        { get { return banned; } set { banned = value; } }
        /// <summary>
        /// Get or set a value indecate whether this user is an admin
        /// </summary>
        public bool Admin
        { get { return isAdmin; } set { isAdmin = value; } }
        /// <summary>
        /// Get or set the player number. e.g player 1 or player 2 in nes.
        /// </summary>
        public int Number
        { get { return playerNumber; } set { playerNumber = value; } }
        /// <summary>
        /// Get or set if this player is ready to start
        /// </summary>
        public bool Ready
        { get { return ready; } set { ready = value; } }
        /// <summary>
        /// Get or set the current frame that this user in
        /// </summary>
        public long Frame
        { get { return frame; } set { frame = value; } }
        /// <summary>
        /// Get or set a value indecate whether this player is paused
        /// </summary>
        public bool Paused
        { get { return paused; } set { paused = value; } }
    }
}
