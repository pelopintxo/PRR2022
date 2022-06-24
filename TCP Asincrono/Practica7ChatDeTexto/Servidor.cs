using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Practica7ChatDeTexto
{
    public class Servidor
    {
        private Socket servidor;
        private IPEndPoint iEnd;
        private List<Socket> clientes;
        private byte[] buffer;
        private string mensaje;
        private int numUsuarios;
        private Dictionary<string, Socket> sockets;
        private List<Usuario> usuarios;

        public Servidor()
        {
            Console.Title = "Servidor";
            this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            this.iEnd = new IPEndPoint(IPAddress.Any,1234);
            this.clientes = new List<Socket>();
            this.buffer = new byte[2048];
            this.mensaje = "";
            this.numUsuarios = 0;
            this.sockets = new Dictionary<string, Socket>();
            this.usuarios = new List<Usuario>();
        }

        public void inicarServidor()
        {
            Console.WriteLine("Inicializando servidor...");
            this.servidor.Bind(iEnd);
            servidor.Listen();
            servidor.BeginAccept(new AsyncCallback(aceptarCallback), null);
        }

        private void aceptarCallback(IAsyncResult ar)
        {
            Socket cliente = this.servidor.EndAccept(ar);
            this.clientes.Add(cliente);
            this.numUsuarios++;

            byte[] vs = Encoding.UTF8.GetBytes("Bienvenido al chat de texto de la asignatura" +
                " de Programación en Red. " +
                "A continuación debe autenticarse con un nick.");

            cliente.Send(vs);
            Console.WriteLine("Cliente Conectado");
            cliente.BeginReceive(this.buffer,0, this.buffer.Length, SocketFlags.None, new AsyncCallback(recibirCallback), cliente);
            servidor.BeginAccept(new AsyncCallback(aceptarCallback), null);
        }

        private void recibirCallback(IAsyncResult ar)
        {
            Socket cliente = (Socket) ar.AsyncState;
            int i = cliente.EndReceive(ar);
            byte[] vs = new byte[i];
            string msg = this.truncarArray(this.buffer);
            
            Console.WriteLine("El mensaje recibido es: " + msg);
            if(msg.Equals("Este es el primer mensaje"))
            {
                cliente.Receive(vs);
                string nick = this.truncarArray(vs);
                Usuario usuario = new Usuario();
                usuario.setNick(nick);
                this.usuarios.Add(usuario);
                this.sockets.Add(nick, cliente);
                Console.WriteLine("Se ha registrado el usuario:" + nick);
            }      
            else
            {
                Console.WriteLine(msg);
                foreach(Usuario u in this.usuarios)
                {
                    string n = u.getNick();
                    this.sockets.TryGetValue(n, out Socket s);

                    if(s == cliente)
                    {
                        vs = Encoding.UTF8.GetBytes(n + ": " + msg);
                        foreach (Socket si in this.clientes)
                        {
                            si.BeginSend(vs, 0, vs.Length, SocketFlags.None, new AsyncCallback(enviarCallback), vs);
                            Console.WriteLine("Llego aqui");
                        }
                    }

                }
            }
        }

        private void enviarCallback(IAsyncResult ar) 
        {
            Socket cliente = (Socket)(ar.AsyncState);
            cliente.EndSend(ar);
        }

        private string truncarArray(byte[] array)
        {
            int i = 0;
            string mensaje = "";
            for(;i<array.Length;i++)
            {
                if(array[i] == 0)
                {
                    mensaje = Encoding.UTF8.GetString(array,0,i);
                    break;
                }
            }

            return mensaje;
        }
    }


}
