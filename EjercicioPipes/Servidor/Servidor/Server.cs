using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
namespace Servidor
{
    public class Server
    {
        public void conectar()
        {
            NamedPipeServerStream nmp = new NamedPipeServerStream("Servidor");
            Console.WriteLine("Esperando conexion...");
            nmp.WaitForConnection();
            Console.WriteLine("Conectado");
            Console.ReadKey();
        }
    }
}
