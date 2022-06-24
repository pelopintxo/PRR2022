using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
namespace Cliente
{
    public class Client
    {
        public void connect()
        {
            NamedPipeClientStream pipe = new NamedPipeClientStream("pipe");
            pipe.Connect();
            Console.WriteLine("Conectado con éxito");
            Console.ReadKey();
            pipe.Flush();
            pipe.Close();
        }
    }
}
