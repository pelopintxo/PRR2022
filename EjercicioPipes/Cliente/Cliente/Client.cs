using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace Cliente
{
    public class Client
    {
        public void conectar()
        {
            NamedPipeClientStream nmp = new NamedPipeClientStream("Servidor");
            nmp.Connect();
            Console.WriteLine("Conectado con el servidor");


            Console.ReadKey();
        }
    }
}
