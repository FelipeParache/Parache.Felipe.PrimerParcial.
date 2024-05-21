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
        readonly EModelosPlayStation eModelosPlayStation;
        readonly EVideojuegosPlayStation eVideojuegosPlayStation;

        public PlayStation(EModelosPlayStation eModelosPlayStation, int almacenamiento) : base(eModelosPlayStation, almacenamiento)
        {
            this.eModelosPlayStation = eModelosPlayStation;
        }

        public PlayStation(EModelosPlayStation eModelosPlayStation, int almacenamiento, bool conectividadOnline, int controles) : base(eModelosPlayStation, almacenamiento, conectividadOnline)
        {
            this.controles = controles;
        }

        public PlayStation(EModelosPlayStation eModelosPlayStation, int almacenamiento, bool conectividadOnline, int controles, EVideojuegosPlayStation eVideoJuegosPlayStation, bool psPlus) : base(eModelosPlayStation, almacenamiento, conectividadOnline, eVideoJuegosPlayStation)
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
                    sb.AppendLine("Incluye servicio de PlayStation Plus");
                }
                else
                {
                    sb.AppendLine("No incluye servicio de PlayStation Plus");
                }
                return sb.ToString();
            }
        }

        public string Controles
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.controles == 1)
                {
                    sb.AppendLine($"Incluye {this.controles} control Dualshock");
                }
                else
                {
                    sb.AppendLine($"Incluye {this.controles} controles Dualshock");
                }
                return sb.ToString();
            }
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarInformacion());

            if (this.psPlus)
            {
                sb.Append($"- {this.PsPlus}");
            }

            sb.Append($"- {this.Controles}");

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
