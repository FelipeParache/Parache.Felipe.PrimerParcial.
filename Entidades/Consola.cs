using System;
using System.Text;

namespace Entidades
{
    public class Consola
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
                    sb.AppendLine("tiene conectividad online");
                    return sb.ToString();
                }
                sb.AppendLine("no tiene conectividad online");
                return sb.ToString();
            }
        }

        public string? ListaVideojuegos
        {
            get
            {
                StringBuilder sb = new StringBuilder();
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

        public string MostrarVideojuegos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Videojuegos {this.Modelo}: {this.ListaVideojuegos}");
            return sb.ToString();
        }
    }
}
