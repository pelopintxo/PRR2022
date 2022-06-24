using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace ChatDeTextoCliente
{
    public class Cliente
    {
        private Socket cliente;
        private byte[] buffer;
        private string nick;


        public Cliente()
        {
            Console.Title = "Cliente";
            this.cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.buffer = new byte[2048];
            this.nick = "";
        }
        public void iniciarCliente()
        {
            while(!this.cliente.Connected)
            {
                try
                {
                    this.cliente.Connect(IPAddress.Loopback,1234);
                    Console.Clear();
                    Console.WriteLine("Conexión realizada.");
                    this.cliente.Receive(buffer);
                    
                    string mensajeDeBienvenida = this.truncarArray(this.buffer);
                    Console.WriteLine(mensajeDeBienvenida);

                    this.cliente.Send(Encoding.UTF8.GetBytes("Este es el primer mensaje"));

                    while(true)
                    {
                        if(this.nick.Equals(""))
                        {
                            Console.WriteLine("Introduzca su nick");
                            this.nick = Console.ReadLine();
                            this.buffer = Encoding.UTF8.GetBytes(this.nick);
                            this.cliente.Send(buffer);
                        }
                        else
                        {
                            while(true)
                            {
                                Console.WriteLine("Introduzca el mensaje que desea enviar");
                                string mensaje = Console.ReadLine();
                                byte[] buffer2 = Encoding.UTF8.GetBytes(mensaje);

                                this.cliente.Send(buffer2) ;

                                if(this.buffer.Length != 0)
                                {
                                    string msg = this.truncarArray(buffer);
                                    Console.WriteLine(msg);
                                }
                            }
                        }

                    }
                }
                catch(Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Conexión fallida");
                }
            }
        }

        private string truncarArray(byte[] array)
        {
            int i = 0;
            string mensaje = "";
            for (; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    mensaje = Encoding.UTF8.GetString(array, 0, i);
                    break;
                }
            }

            return mensaje;
        }
    }
}
