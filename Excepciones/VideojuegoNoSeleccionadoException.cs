using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepción que se lanza cuando no se ha seleccionado una opción de videojuego.
    /// </summary>
    public class VideojuegoNoSeleccionadoException : Exception
    {
        public VideojuegoNoSeleccionadoException() : base("Por favor, seleccione un videojuego.")
        {

        }
    }
}
