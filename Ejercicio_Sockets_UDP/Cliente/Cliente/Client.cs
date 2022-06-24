using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Cliente
{
    public class Client
    {
        public void connect()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 1222);
            socket.Connect(endPoint);
            Console.WriteLine("Conectado!");
            

        }
    }
}
