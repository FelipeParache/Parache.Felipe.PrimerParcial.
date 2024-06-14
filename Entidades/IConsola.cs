using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz que define las propiedades y métodos de una consola
    /// </summary>
    public interface IConsola 
    {
        bool ConectividadOnline { get; set; }
        int Almacenamiento { get; set; }
        string? Modelo { get; set; }
        string? Videojuego { get; set; }

        string MostrarInformacion();
        string MostrarInformacion(bool enDetalle);
        string MostrarEslogan();
        string Serializar(string ruta);
    }
}
