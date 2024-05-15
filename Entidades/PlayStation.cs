using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlayStation : Consola
    {
        private bool psPlus;
        private int controles;

        private PlayStation() : base()
        {
            base.LlenarListaVideojuegos(typeof(EVideojuegosPlayStation));
        }

        public PlayStation(string modelo, int almacenamiento, int controles) : base(modelo, almacenamiento)
        {
            this.controles = controles;
        }

        public PlayStation(string modelo, int almacenamiento, int controles, bool psPlus) : this(modelo, almacenamiento, controles)
        {
            this.psPlus = psPlus;
        }

        public string PsPlus
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.psPlus)
                {
                    sb.AppendLine($"Incluye servicio de PlayStation Plus.");
                    return sb.ToString();
                }
                return "";
            }
        }

        public string Controles
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Incluye {this.controles} controles Dualshock.");
                return sb.ToString();
            }
        }

        protected override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.psPlus)
            {
                sb.AppendLine($"+ {this.PsPlus}");
            }

            sb.AppendLine($"{this.Controles}");

            return sb.ToString();
        }

        protected override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Play Has No Limits");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            Boolean retorno = false;

            if (obj is PlayStation)
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
