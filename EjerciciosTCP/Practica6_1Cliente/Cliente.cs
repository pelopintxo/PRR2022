using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Practica6_1Cliente
{
    public class Cliente
    {
        public void inciarCliente()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint end = new IPEndPoint(this.obtenerDireccion(), 1234);
            socket.Connect(end);
            Console.WriteLine("Conectado al servidor");
            while(true)
            {
                this.escritor(socket);
                string contenido = this.lector(socket);
                Console.WriteLine("La informacion que busca es: " + contenido);
            }
            
            Console.ReadKey();
        }

        private void escritor(Socket s)
        {
            Console.WriteLine("Introduzca la ruta del archivo que desea leer:");
            string path = Console.ReadLine();
            s.Send(Encoding.UTF8.GetBytes(path), 0, Encoding.UTF8.GetBytes(path).Length, 0);
        }

        private string lector(Socket s)
        {
            byte[] buffer = new byte[1024];
            s.Receive(buffer, 0, buffer.Length, 0);
            string data = this.truncarByteArray(buffer);

            return data;
        }

        private IPAddress obtenerDireccion()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress address = null;
            foreach (IPAddress i in host.AddressList)
            {
                if (i.AddressFamily.ToString() == "InterNetwork")
                {
                    address = i;
                    break;
                }
            }

            return address;
        }

        private string truncarByteArray(byte[] b)
        {
            int i;
            string data = "";
            for(i = 0; i < b.Length; i++)
            {
                if(b[i] == 0)
                {
                    data = Encoding.UTF8.GetString(b,0,i);
                    break;
                }
            }

            return data;
        }
    }
}
