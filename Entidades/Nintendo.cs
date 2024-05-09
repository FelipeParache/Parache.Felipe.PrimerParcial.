using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nintendo : Consola
    {
        private bool portable;
        private int duracionBateria;
        private List<EPerifericosNintendo> listaPerifericos;

        private Nintendo() : base()
        {
            base.LlenarListaVideojuegos(typeof(EVideojuegosNintendo));
        }

        public Nintendo(string modelo, int almacenamiento, bool portable) : base(modelo, almacenamiento)
        {
            this.portable = portable;

            if (this.portable)
            {
                this.duracionBateria = 5;
            }
        }

        public Nintendo(string modelo, int almacenamiento, bool portable, List<EPerifericosNintendo> listaPerifericos) : this(modelo, almacenamiento, portable)
        {
            this.portable = portable;
            this.listaPerifericos = new List<EPerifericosNintendo>();
            this.listaPerifericos = listaPerifericos;

            if (this.portable)
            {
                this.duracionBateria = 5;
            }
        }

        public bool Portable
        {
            get { return this.portable; }
            set { this.portable = value; }
        }

        public string DuracionBateria
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Duración de bateria: {this.duracionBateria}hs.");
                return sb.ToString();
            }
        }

        public string ListaPerifericos
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Los perifericos son:");

                foreach (EPerifericosNintendo periferico in this.listaPerifericos)
                {
                    sb.AppendLine($"\n{periferico}");
                }
                
                return sb.ToString();
            }
        }
    }
}
