using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace Servidor
{
    public class Server
    {
        public void conect()
        {
            NamedPipeServerStream Server = new NamedPipeServerStream("pipe");
            Console.WriteLine("Esperando al servidor...");
            Server.WaitForConnection();
            Console.WriteLine("Conectado con éxito");
            Console.ReadKey();

        }
    }

}
