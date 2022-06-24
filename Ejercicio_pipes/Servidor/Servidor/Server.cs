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
            Console.WriteLine("Esperando al cliente...");
            Server.WaitForConnection();
            Console.WriteLine("Conectado con éxito");
            //Leemos el path
            StreamReader sr = new StreamReader(Server);
            string path = sr.ReadLine();
            Console.WriteLine("El path es:" + path);
            Console.WriteLine(path); //Imprimimos para comprobar
            
            StreamWriter texto = new StreamWriter(Server);
            texto.WriteLine(this.leertxt(path)); //Eviamos el archivo de vuelta!
            Console.WriteLine(this.leertxt(path));
            texto.Flush();
            Console.ReadKey();

        }
        public string leertxt(string path)
        {
            string data = "";
            try{
                data = File.ReadAllText(path);
            }
            catch
            {
                Console.WriteLine("No se encontró el archivo");

            }
            return data;
        }
    }
}
