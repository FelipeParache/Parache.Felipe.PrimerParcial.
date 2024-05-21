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
        readonly private List<EPerifericosNintendo>? listaPerifericos;
        readonly EModelosNintendo eModelosNintendo;
        readonly EVideojuegosNintendo eVideojuegosNintendo;

        private Nintendo(EModelosNintendo eModelosNintendo, int almacenamiento) : base(eModelosNintendo, almacenamiento)
        {
            this.eModelosNintendo = eModelosNintendo;
            this.VerificarPortabilidad();
        }

        public Nintendo(EModelosNintendo eModelosNintendo, int almacenamiento, EVideojuegosNintendo eVideojuegosNintendo) : this(eModelosNintendo, almacenamiento)
        {
            this.eVideojuegosNintendo = eVideojuegosNintendo;
        }

        public Nintendo(EModelosNintendo eModelosNintendo, int almacenamiento, EVideojuegosNintendo eVideojuegosNintendo, List<EPerifericosNintendo> listaPerifericos) : this(eModelosNintendo, almacenamiento, eVideojuegosNintendo)
        {
            this.listaPerifericos = new List<EPerifericosNintendo>();
            this.listaPerifericos = listaPerifericos;
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
                sb.AppendLine($"Duración de la bateria: {this.duracionBateria}hs.");
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

        public void VerificarPortabilidad()
        {
            if (this.eModelosNintendo == EModelosNintendo.WiiU || this.eModelosNintendo == EModelosNintendo.NintendoSwitch)
            {
                base.conectividadOnline = true;
                this.Portable = true;
                this.duracionBateria = 5;
            }
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.portable)
            {
                sb.AppendLine($"- {this.DuracionBateria}");
            }

            if (this.listaPerifericos != null)
            {
                sb.AppendLine($"- {this.ListaPerifericos}");
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
