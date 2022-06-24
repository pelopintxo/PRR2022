// See https://aka.ms/new-console-template for more information
using TDD;
Cliente cliente = new Cliente();
string leido = "";
string info = "";
cliente.getPathTXT("archivo.txt");
while(leido.Equals(""))
{
    Console.WriteLine("Introduzca una cadena");
    leido = Console.ReadLine();
    info = cliente.getPathVacio(leido);
    if(info.Equals("Error"))
    {
        leido = "";
    }
}
