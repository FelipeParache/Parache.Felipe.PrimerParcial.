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
            this.listaPerifericos = new List<EPerifericosNintendo>();
            this.listaPerifericos = listaPerifericos;
        }

        public string Portable
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.portable)
                {
                    sb.AppendLine($"Es portatil.");
                    return sb.ToString();
                }
                return "";
            }
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
                    sb.AppendLine($"\n+ {periferico}");
                }
                
                return sb.ToString();
            }
        }

        protected override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.portable)
            {
                sb.AppendLine($"+ {this.Portable}");
                sb.AppendLine($"+ {this.DuracionBateria}");
            }

            if (this.listaPerifericos != null)
            {
                sb.AppendLine($"{this.ListaPerifericos}");
            }

            return sb.ToString();
        }

        protected override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("There's No Play Like It");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            Boolean retorno = false;

            if (obj is Nintendo)
            {
                retorno = true;
            }

            return retorno;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
