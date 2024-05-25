using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlmacenamientoNoSeleccionadoException : Exception
    {
        public AlmacenamientoNoSeleccionadoException() : base("Por favor, seleccione una opción de almacenamiento.")
        {

        }
    }
}
