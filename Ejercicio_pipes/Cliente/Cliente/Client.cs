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
            Console.WriteLine("Escriba la dirección de un archivo: ");  
            StreamWriter sw = new StreamWriter(pipe);
    
            String path = Console.ReadLine();
            sw.WriteLine(path);
            sw.Flush();
            Console.WriteLine("Archivo enviado con éxito");

            

            StreamReader sr = new StreamReader(pipe);
            String data = sr.ReadLine();

            while(data != null)
            {
                Console.WriteLine(data);
                data = sr.ReadLine();
            }
            Console.WriteLine(data);

            Console.ReadKey();
            pipe.Flush();
            pipe.Close();
        }
    }
}
