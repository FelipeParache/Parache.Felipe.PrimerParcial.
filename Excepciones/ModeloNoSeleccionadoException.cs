using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepción que se lanza cuando no se ha seleccionado una opción de modelo.
    /// </summary>
    public class ModeloNoSeleccionadoException : Exception
    {
        public ModeloNoSeleccionadoException() : base("Por favor, seleccione un modelo.")
        {

        }
    }
}