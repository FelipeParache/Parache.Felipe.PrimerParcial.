using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IJSON<T>
    {
        string Serializar(T dato, string ruta);
        T Deserializar(string ruta);
    }
}
