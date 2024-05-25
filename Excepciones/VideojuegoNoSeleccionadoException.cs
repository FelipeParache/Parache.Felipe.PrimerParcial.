using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VideojuegoNoSeleccionadoException : Exception
    {
        public VideojuegoNoSeleccionadoException() : base("Por favor, seleccione un videojuego.")
        {

        }
    }
}
