﻿using System;
using System.Text;

namespace Entidades
{
    public abstract class Consola
    {
        private string? modelo;
        private bool conectividadOnline;
        private int almacenamiento;
        private List<string> listaVideojuegos;

        public Consola()
        {
            listaVideojuegos = new List<string>();
        }

        public Consola(string modelo, int almacenamiento) : this()
        {
            this.modelo = modelo;
            this.almacenamiento = almacenamiento;
            this.DeterminarConectividadOnline();
        }

        public Consola(string modelo, int almacenamiento, List<string> listaVideojuegos) : this(modelo, almacenamiento)
        {
            this.listaVideojuegos = listaVideojuegos;
        }

        public string? Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        public int Almacenamiento
        {
            get { return this.almacenamiento; }
            set { this.almacenamiento = value; }
        }

        public string ConectividadOnline
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.conectividadOnline)
                {
                    sb.AppendLine("tiene conectividad online.");
                    return sb.ToString();
                }
                sb.AppendLine("no tiene conectividad online.");
                return sb.ToString();
            }
        }

        public string? ListaVideojuegos
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Videojuegos:");
                foreach (string videojuego in this.listaVideojuegos)
                {
                    sb.AppendLine($"{videojuego}");
                }
                return sb.ToString();
            }
        }

        private void DeterminarConectividadOnline()
        {
            this.conectividadOnline = InfoConsolas.ObtenerConectividadOnline(this.Modelo);
        }

        protected void LlenarListaVideojuegos(Type enumerado)
        {
            foreach (Enum videojuego in Enum.GetValues(enumerado))
            {
                this.listaVideojuegos.Add(videojuego.ToString());
            }
        }

        protected virtual string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-- {this.MostrarEslogan()}--");
            sb.AppendLine($"* {this.Modelo}");
            sb.AppendLine($"- {this.ConectividadOnline}");
            sb.AppendLine($"- {this.Almacenamiento} GB de almacenamiento");
            sb.AppendLine($"- {this.ListaVideojuegos}");
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
            return consola.modelo;
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
