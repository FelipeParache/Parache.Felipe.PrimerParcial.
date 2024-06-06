using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepción que se lanza cuando no se ha seleccionado una opción de controles de PlayStation.
    /// </summary>
    public class ControlNoSeleccionadoException : Exception
    {
        public ControlNoSeleccionadoException() : base("Por favor, seleccione cuántos controles quiere.") 
        {

        }
    }
}
