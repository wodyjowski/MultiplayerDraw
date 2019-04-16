using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerDraw.Connection
{
    class ConnectionProvider
    {
        private IPAddress currentIPAddress;

        public ConnectionProvider()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    currentIPAddress = ip;
                }
            }
        }

        public IPAddress GetIPv4Address()
        {
            return currentIPAddress;
        }
    }
}
