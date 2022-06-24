using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Cliente
    {
        //Paso 2 crear la funcion Commit
        public string getPathVacio(string o)
        {
            //Paso 3 hacer el codigo necesario para que compile la funcion pero de eerror el test: return null Commit
            //Paso 4 hacer el codigo necesario para que pase Commit
            //Paso 5 refactor: hacemos el codigo bonito pero que el test pase Commit
            if(o.Length == 0)
            {
                return "Error";
            }
            else
            {
                return o;
            }
        }

        public string getPathEspacios(string o)
        {
            string s = "";
            if(o.Contains(" "))
            {
                s = o.Replace(" ", "");
            }
            return s;
        }

        public string getPathEnMinusculas(string o)
        {
            string s = o.ToLower();
            return s;
        }

        public Boolean getPathTXT(string o)
        {
            int i = o.Length;
            int c = i - 4;
            string oo = o.Substring(c, 4);

            if(oo.Equals(".txt"))
            {
                return true;
            }else
            {
                return false;
            }
        }


    }
}
