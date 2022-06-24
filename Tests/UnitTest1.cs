using NUnit.Framework;
using TDD;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void comprobacionCadenaVacia()
        {
            string leidoPorConsola = "";
            Cliente cliente = new Cliente();
            //Paso 1 primero llamar a la funcion sin que exista Commit
            
            string path = cliente.getPathVacio(leidoPorConsola);
            if(path.Length != 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void comprobarEspacios()
        {
            Cliente cliente = new Cliente();
            string esperado = "archivo.txt";
            string leidoPorConsola = "ar chi vo .txt";

            string path = cliente.getPathEspacios(leidoPorConsola);
            Assert.AreEqual(esperado,path);
        }

        [Test]
        public void comprobarMinusculas()
        {
            Cliente cliente = new Cliente();
            string esperado = "archivo.txt";
            string leidoPorConsola = "ARCHIVO.TXT";
            string path = cliente.getPathEnMinusculas(leidoPorConsola);
            Assert.AreEqual(esperado, path);
        }

        [Test]
        public void comprobarArchivoNoseaTXT()
        {
            Cliente cliente = new Cliente();

            string leidoPorConsola = "archivo";
            Boolean valor = cliente.getPathTXT(leidoPorConsola);
            if(valor == false)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}