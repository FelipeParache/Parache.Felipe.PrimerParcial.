using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool PsPlus
        {
            get { return psPlus; }
            set { psPlus = value; }
        }

        public int Controles
        {
            get { return controles; }
            set { controles = value; }
        }
    }
}
