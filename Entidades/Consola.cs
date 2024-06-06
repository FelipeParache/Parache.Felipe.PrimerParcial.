using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que representa una consola de videojuegos.
    /// </summary>
    public abstract class Consola
    {
        public bool ConectividadOnline { get; set; }
        public int Almacenamiento { get; set; }
        public string? Modelo { get; set; }
        public string? Videojuego { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Consola() { }

        /// <summary>
        /// Constructor que inicializa el modelo y el almacenamiento de la consola.
        /// </summary>
        public Consola(string? eModelo, int almacenamiento)
        {
            this.Modelo = eModelo;
            this.Almacenamiento = almacenamiento;
        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola y el videojuego.
        /// </summary>
        public Consola(string? eModelo, int almacenamiento, string? eVideojuego) : this(eModelo, almacenamiento)
        {
            this.Videojuego = eVideojuego;
        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola, el videojuego y la conectividad online.
        /// </summary>
        public Consola(string? eModelo, int almacenamiento, string? eVideojuego, bool conectividadOnline) : this(eModelo, almacenamiento, eVideojuego)
        {
            this.ConectividadOnline = conectividadOnline;
        }

        /// <summary>
        /// Muestra información resumida de la consola.
        /// </summary>
        /// <returns>Una cadena con el modelo y el almacenamiento de la consola.</returns>
        public virtual string MostrarInformacionResumida()
        {
            return $"- Consola {this.Modelo} - {this.Almacenamiento} GB";
        }

        /// <summary>
        /// Muestra información detallada de la consola.
        /// </summary>
        /// <returns>Una cadena con todos los detalles de la consola.</returns>
        public virtual string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"** {this.MostrarEslogan()} **");
            sb.AppendLine($"- Modelo: {this.Modelo}");
            sb.AppendLine($"- Almacenamiento: {this.Almacenamiento} GB");
            if (this.ConectividadOnline)
            {
                sb.AppendLine("- Tiene conectividad online");
            }
            else
            {
                sb.AppendLine("- No tiene conectividad online");
            }
            if (this.Videojuego == null)
            {
                sb.AppendLine("- No incluye videojuego");
            }
            else
            {
                sb.AppendLine($"- Videojuego: {this.Videojuego}");
            }
            return sb.ToString();
        }

        public abstract string MostrarEslogan();
        public abstract string Serializar();

        public static bool operator ==(Consola c1, Consola c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Consola c1, Consola c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Determina si el objeto especificado es igual a la consola actual, dependiendo su modelo y almacenamiento.
        /// </summary>
        /// <param name="obj">El objeto a comparar con la consola actual.</param>
        /// <returns>True si el objeto especificado es igual a la consola actual, de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Consola consola)
            {
                return this.Modelo == consola.Modelo && this.Almacenamiento == consola.Almacenamiento;
            }

            return false;
        }

        public override string ToString()
        {
            return this.MostrarInformacion();
        }
    }
}