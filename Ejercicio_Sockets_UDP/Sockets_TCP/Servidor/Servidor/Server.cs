using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Servidor
{
    public class Server
    {
        public void connect()
        {
            byte[] buffer = new byte[1024];
            byte[] buf = new byte[10];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 5067);
            socket.Bind(ip);
            socket.Listen();
            Socket escucha = socket.Accept();
            escucha.Send(Encoding.UTF8.GetBytes(DateTime.Now.ToString()));
            Console.ReadKey();
            escucha.Close();
        }
    }
}
