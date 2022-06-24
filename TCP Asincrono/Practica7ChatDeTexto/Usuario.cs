using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica7ChatDeTexto
{
    public class Usuario
    {

        private string nick;
        private List<string> mensajes;

        public Usuario()
        {

        }

        public void setMensaje(string mensaje)
        {
            this.mensajes.Add(mensaje);
        }

        public void setNick(string nick)
        {
            this.nick = nick;
        }

        public string getNick()
        {
            return this.nick;
        }
        public List<string> getMensajes()
        {
            return this.mensajes;
        }
    }
}
