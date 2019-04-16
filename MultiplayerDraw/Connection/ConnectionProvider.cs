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
            var ipAddressv4 = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            currentIPAddress = ipAddressv4;
        }

        public IPAddress GetIPv4Address()
        {
            return currentIPAddress;
        }
    }
}
