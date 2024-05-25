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
        readonly string? eModelosPlayStation;
        readonly string? eVideojuegosPlayStation;

        public PlayStation(string? eModelosPlayStation, int almacenamiento) : base(eModelosPlayStation, almacenamiento)
        {
            this.eModelosPlayStation = eModelosPlayStation;
        }

        public PlayStation(string? eModelosPlayStation, int almacenamiento, string? eVideojuegosPlayStation, int controles) : base(eModelosPlayStation, almacenamiento, eVideojuegosPlayStation)
        {
            this.controles = controles;
        }

        public PlayStation(string? eModelosPlayStation, int almacenamiento, string? eVideoJuegosPlayStation, int controles, bool conectividadOnline, bool psPlus) : base(eModelosPlayStation, almacenamiento, eVideoJuegosPlayStation, conectividadOnline)
        {
            this.controles = controles;
            this.psPlus = psPlus;
        }

        public string PsPlus
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.psPlus)
                {
                    sb.Append("Incluye servicio de PlayStation Plus");
                }
                else
                {
                    sb.Append("No incluye servicio de PlayStation Plus");
                }
                return sb.ToString();
            }
        }

        public string Controles
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.controles < 1)
                {
                    sb.AppendLine("No incluye control Dualshock");
                }
                else if (this.controles == 1)
                {
                    sb.AppendLine($"Incluye {this.controles} control Dualshock");
                }
                else if (this.controles > 1)
                {
                    sb.AppendLine($"Incluye {this.controles} controles Dualshock");
                }
                return sb.ToString();
            }
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.psPlus)
            {
                sb.AppendLine($"- {this.PsPlus}");
            }

            sb.AppendLine($"- {this.Controles}");

            return sb.ToString();
        }

        protected override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Play Has No Limits");
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
