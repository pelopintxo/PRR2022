using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Servidor;

public class Server
{
    public void connect()
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(new IPEndPoint(IPAddress.Any, 0));      
        Console.WriteLine("Esperando conexión....");

        byte[] buffer = new byte[20];
        buffer = 0b101101;
        socket.Send(buffer);
        //socket.Receive(buffer);
        //Console.WriteLine("Conectado!");//No llega a este print porqeu en UDP se queda escuchando siempre.

        Console.ReadKey();



    }
}

