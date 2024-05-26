using System;
using System.Text;

namespace Entidades
{
    public abstract class Consola
    {
        protected bool conectividadOnline;
        protected int almacenamiento;
        public string? eModelo;
        public string? eVideojuego;

        public Consola(string? eModelo, int almacenamiento)
        {
            this.eModelo = eModelo;
            this.almacenamiento = almacenamiento;
        }

        public Consola(string? eModelo, int almacenamiento, string? eVideojuego) : this(eModelo, almacenamiento)
        {
            this.eVideojuego = eVideojuego;
        }

        public Consola(string? eModelo, int almacenamiento, string? eVideojuego, bool conectividadOnline) : this(eModelo, almacenamiento, eVideojuego)
        {
            this.conectividadOnline = conectividadOnline;
        }

        public string? ConectividadOnline
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.conectividadOnline)
                {
                    sb.Append("Tiene conectividad online");
                }
                else
                {
                    sb.Append("No tiene conectividad online");
                }
                return sb.ToString();
            }
        }

        public string Modelo
        {
            get { return this.eModelo; }
        }

        public int Almacenamiento
        {
            get { return this.almacenamiento; }
            set { this.almacenamiento = value; }
        }

        public virtual string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"** {this.MostrarEslogan()} **");
            sb.AppendLine($"- Modelo: {this.Modelo}");
            sb.AppendLine($"- Almacenamiento: {this.Almacenamiento} GB");
            sb.AppendLine($"- {this.ConectividadOnline}");
            if (this.eVideojuego != null)
            {
                sb.Append($"- Videojuego: {this.eVideojuego}");
            }
            return sb.ToString();
        }

        protected abstract string MostrarEslogan();

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

        public static explicit operator string?(Consola consola)
        {
            return consola.Modelo;
        }

        public static implicit operator int(Consola consola)
        {
            return consola.almacenamiento;
        }
    }
}