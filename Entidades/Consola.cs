using System;
using System.Text;

namespace Entidades
{
    public abstract class Consola
    {
        protected bool conectividadOnline;
        protected int almacenamiento;
        public Enum? eModelo;
        public Enum? eVideojuego;

        public Consola(Enum? eModelo, int almacenamiento)
        {
            this.eModelo = eModelo;
            this.almacenamiento = almacenamiento;
            this.conectividadOnline = false;
        }

        public Consola(Enum? eModelo, int almacenamiento, bool conectividadOnline) : this(eModelo, almacenamiento)
        {
            this.conectividadOnline = conectividadOnline;
        }

        public Consola(Enum? eModelo, int almacenamiento, bool conectividadOnline, Enum? eVideojuego) : this(eModelo, almacenamiento, conectividadOnline)
        {
            this.eVideojuego = eVideojuego;
        }

        public string? ConectividadOnline
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.conectividadOnline)
                {
                    sb.AppendLine("Tiene conectividad online");
                }
                else
                {
                    sb.AppendLine("No tiene conectividad online");
                }
                return sb.ToString();
            }
        }

        public string Modelo
        {
            get { return this.eModelo.ToString(); }
        }

        public int Almacenamiento
        {
            get { return this.almacenamiento; }
            set { this.almacenamiento = value; }
        }

        public virtual string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-- {this.MostrarEslogan()} --");
            sb.AppendLine($"* Modelo: {this.eModelo}");
            sb.AppendLine($"- {this.Almacenamiento} GB de almacenamiento");
            sb.AppendLine($"- {this.ConectividadOnline}");
            if (this.eVideojuego != null)
            {
                sb.AppendLine($"- Videojuego elegido: {this.eVideojuego}");
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

        public static explicit operator string?(Consola consola)
        {
            return consola.Modelo;
        }

        public static implicit operator int(Consola consola)
        {
            return consola.almacenamiento;
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
    }
}