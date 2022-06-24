using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Practica5_1Cliente
{
    public class Cliente
    {
        public void iniciarCliente()
        {
            IPAddress localIp = this.getIp();
            
            if(localIp == null)
            {
                Console.WriteLine("No se ha podido encontrar la IP");
                return;
            }

            Console.WriteLine("La ip de su ordenador es: " + localIp.ToString()); 

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            EndPoint dir = new IPEndPoint(localIp, 1234);

            Console.WriteLine("Introduzca la dirección del archivo");
            string path = Console.ReadLine();

            byte[] buffer = new byte[1024];
            buffer = Encoding.Default.GetBytes(path);

            try
            {
                byte[] vs = new byte[1024];
                socket.SendTo(buffer, dir);
                socket.Receive(vs);
                string ionfo = Encoding.UTF8.GetString(vs);
                Console.WriteLine("La información que busca es la siguiente: " + ionfo);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString);
            }
            Console.ReadKey();
            socket.Close();

        }

        private IPAddress getIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily.ToString() == "InterNetwork")
                {
                    return ip;
                }
            }
            return null;
        }
    }
}
