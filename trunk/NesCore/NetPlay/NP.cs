using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Console = MyNes.Core.Console;
namespace MyNes.Core.NetPlay
{
    /// <summary>
    /// Net Play class
    /// </summary>
    public class NP
    {
        private static TcpChannel channel;
        private static string objectName = "";
        private static ServerStatus status = ServerStatus.Off;
        private static int portNumber;

        /// <summary>
        /// Register a channel (create server)
        /// </summary>
        /// <param name="name">The server object name</param>
        /// <param name="theObject">The server object to set in the host</param>
        /// <param name="port">The port number</param>
        public static void CreateServer(string name, RemotingObject theObject, int port)
        {
            try
            {
                objectName = name;
                portNumber = port;
                Console.WriteLine("Creating Tcp channel at port " + port);
                channel = new TcpChannel(port);

                Console.WriteLine("Registering the channel ...");
                ChannelServices.RegisterChannel(channel, false);
                Console.WriteLine("Channel registered !", DebugCode.Good);

                Console.WriteLine("Registering the remoting object at the channel ...");
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingObject), name, WellKnownObjectMode.Singleton);
                Console.WriteLine("Remoting object registered !", DebugCode.Good);

                status = ServerStatus.Running;
                Console.WriteLine("Server is running", DebugCode.Good);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't create server !", DebugCode.Error);
                Console.WriteLine(ex.Message, DebugCode.Error);
                status = ServerStatus.Off;
            }
        }
        /// <summary>
        /// Kill registerd server
        /// </summary>
        public static void KillServer()
        {
            if (channel != null)
            {
                try
                {
                    Console.WriteLine("Killing server ....");
                    ChannelServices.UnregisterChannel(channel);
                    Console.WriteLine("Done.");
                }
                catch { }
                channel = null;
            }
            else
            {
                Console.WriteLine("There is no server to kill !", DebugCode.Warning);
            }
            status = ServerStatus.Off;
        }

        /// <summary>
        /// Get the remoting object at address (join server)
        /// </summary>
        /// <param name="address">The complete server address</param>
        /// <returns></returns>
        public static RemotingObject GetServerObject(string address)
        {
            if (channel == null)
            {
                Console.WriteLine("Registering tcp channel as client...");
                // Create the channel.
                channel = new TcpChannel();

                // Register the channel.
                ChannelServices.RegisterChannel(channel, false);
                Console.WriteLine("Channel registered.", DebugCode.Good);
            }
            try
            {
                Console.WriteLine("Returning the remoting object at address " + address);
                return (RemotingObject)Activator.GetObject(typeof(RemotingObject), address);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when trying to get the remoting object at given address", DebugCode.Error);
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Get current running server address
        /// </summary>
        /// <returns>The complete server address</returns>
        public static string GetServerAddress()
        {
            if (channel != null)
            {
                string[] urls = channel.GetUrlsForUri(objectName);
                if (urls.Length > 0)
                {
                    return urls[0];
                }
            }
            return "";
        }
        /// <summary>
        /// Get the server ip address. The server must be running first.
        /// </summary>
        /// <returns></returns>
        public static string GetServerIPAddress()
        {
            if (status == ServerStatus.Off)
            {
                throw new Exception("Server is off !");
            }
            // get the complete address first !
            string address = GetServerAddress().Replace("tcp://", "").Replace("/" + objectName, "");
            // remove port nubmer
            string[] code = address.Split(new char[] { ':' });

            return code[0];// this should be the ip.
        }

        /// <summary>
        /// Build address that client can use to join a server
        /// </summary>
        /// <param name="ip">The server ip address</param>
        /// <param name="port">The port number</param>
        /// <returns>The server address</returns>
        public static string BuildAddress(string ip, int port)
        {
            return "tcp://" + ip + ":" + port + "/" + objectName;
        }

        /// <summary>
        /// Get the server (or the registered channel). If the server is not created yet, this returns null.
        /// </summary>
        public static TcpChannel Channel
        { get { return channel; } }
        /// <summary>
        /// Get current status of running server
        /// </summary>
        public static ServerStatus Status
        { get { return status; } }
        /// <summary>
        /// Get or set the current remoting object name
        /// </summary>
        public static string ObjectName
        { get { return objectName; } set { objectName = value; } }
        /// <summary>
        /// Get the server port number if this server is running.
        /// </summary>
        public static int PortNumber
        { get { return portNumber; } }
    }
    /// <summary>
    /// The server status
    /// </summary>
    public enum ServerStatus
    {
        /// <summary>
        /// The server is running
        /// </summary>
        Running,
        /// <summary>
        /// The server is off
        /// </summary>
        Off
    }
}
