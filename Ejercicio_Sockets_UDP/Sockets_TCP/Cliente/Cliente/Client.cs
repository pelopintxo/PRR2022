using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    public class Client { 
    
        public void connect()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, 5067);
            socket.Connect(ipe);
           
            byte[] buffer = new byte[1024];
            socket.Receive(buffer);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));
            socket.Close();
        }

    }
}
