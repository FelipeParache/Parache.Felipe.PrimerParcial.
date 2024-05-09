using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Xbox : Consola
    {
        private Xbox() : base()
        {
            base.LlenarListaVideojuegos(typeof(EVideojuegosXbox));
        }

        public Xbox(string modelo, int almacenamiento) : base(modelo, almacenamiento)
        {

        }
    }
}
