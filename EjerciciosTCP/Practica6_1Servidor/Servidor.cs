using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;



namespace Practica6_1Servidor
{
    public class Servidor
    {
        public void iniciarServidor()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint end = new IPEndPoint(IPAddress.Any, 1234);

            socket.Bind(end);
            socket.Listen();

            Thread t;

            while(true)
            {
                Console.Out.Flush();                                                                                                                                                                                                                                                                                                                                           
                Console.WriteLine("Esperando conexiones...");
                Socket escuchar = socket.Accept();
                t = new Thread(conexionCliente);
                t.Start(escuchar);
                Console.WriteLine("Cliente conectado");
            }
        }
        
        private void conexionCliente(object s)
        {
            Socket escuchar = (Socket) s;
            while (true)
            {
                byte[] vs = new byte[1024];
                escuchar.Receive(vs);
                string path = this.truncarByteArray(vs);
                byte[] buffer = Encoding.UTF8.GetBytes(this.lectorArchivo(path));
                escuchar.Send(buffer);
                Console.WriteLine("Mensaje enviado al cliente con exito");
            }
        }
        private string lectorArchivo(string path)
        {
            string info = "";
            try
            {
                info = File.ReadAllText(path);

            }catch(Exception ex)
            {
                Console.WriteLine("La ruta del archivo no es correcta");
            }

            return info;
        }

        private string truncarByteArray(byte[] b)
        {
            int i;
            string data = "";
            for (i = 0; i < b.Length; i++)
            {
                if (b[i] == 0)
                {
                    data = Encoding.UTF8.GetString(b, 0, i);
                    break;
                }
            }

            return data;
        }
    }


}
