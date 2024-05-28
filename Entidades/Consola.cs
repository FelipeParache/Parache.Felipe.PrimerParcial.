using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Entidades
{
    public abstract class Consola
    {
        public bool ConectividadOnline { get; set; }
        public int Almacenamiento { get; set; }
        public string? Modelo { get; set; }
        public string? Videojuego { get; set; }

        public Consola() { }

        public Consola(string? eModelo, int almacenamiento)
        {
            this.Modelo = eModelo;
            this.Almacenamiento = almacenamiento;
        }

        public Consola(string? eModelo, int almacenamiento, string? eVideojuego) : this(eModelo, almacenamiento)
        {
            this.Videojuego = eVideojuego;
        }

        public Consola(string? eModelo, int almacenamiento, string? eVideojuego, bool conectividadOnline) : this(eModelo, almacenamiento, eVideojuego)
        {
            this.ConectividadOnline = conectividadOnline;
        }

        public string MostrarInformacionResumida()
        {
            return $"- Consola {this.Modelo}, {this.Almacenamiento} GB de almacenamiento.";
        }

        public virtual string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"** {this.MostrarEslogan()} **");
            sb.AppendLine($"- Modelo: {this.Modelo}");
            sb.AppendLine($"- Almacenamiento: {this.Almacenamiento} GB");
            if (this.ConectividadOnline)
            {
                sb.Append("Tiene conectividad online");
            }
            else
            {
                sb.Append("No tiene conectividad online");
            }
            if (this.Videojuego == null)
            {
                sb.Append("No incluye videojuego");
            }
            else
            {
                sb.Append($"Videojuego: {this.Videojuego}");
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

        /*public static explicit operator string?(Consola consola)
        {
            return consola.Modelo;
        }

        public static implicit operator int(Consola consola)
        {
            return consola.almacenamiento;
        }*/
    }
}