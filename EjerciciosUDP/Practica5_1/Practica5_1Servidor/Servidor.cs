using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Practica5_1Servidor
{
    public class Servidor
    {
        public void iniciarServidor()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint end = new IPEndPoint(IPAddress.Any, 1234);
            socket.Bind(end);
            Console.WriteLine("Esperando información");
            byte[] buffer = new byte[1024];

            socket.ReceiveFrom(buffer, ref end);

            string cadena = this.truncarByteArray(buffer);
            string contenido = this.buscarContenido(cadena);
            Console.WriteLine("Dirección del archivo recibida: " + cadena);
            Console.WriteLine("Contenido: " + contenido);

            buffer = Encoding.UTF8.GetBytes(contenido);
            try
            {
                socket.SendTo(buffer, end);
            }catch(Exception ex)
            {
                Console.WriteLine("Fallo aqui");

            }            

            Console.ReadKey();
            socket.Close();
        }

        private string truncarByteArray(byte[] a)
        {
            string cadena = "";
            int i;
            for(i = 0; i< a.Length; i++)
            {
                if(a[i] == 0)
                {
                    cadena = Encoding.UTF8.GetString(a,0,i);
                    break;
                }
            }
            return cadena;
        }

        private string buscarContenido(string a)
        {
            string contenido = "";
            try
            {
                contenido = File.ReadAllText(a);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("No se encontro el archivo");
            }

            return contenido;   
        }
    }
}
