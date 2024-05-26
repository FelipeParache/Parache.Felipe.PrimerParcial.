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
        private string? ePerifericos;

        public Nintendo(string? eModelosNintendo, int almacenamiento) : base(eModelosNintendo, almacenamiento)
        {
            this.VerificarPortabilidad();
        }

        public Nintendo(string? eModelosNintendo, int almacenamiento, string? eVideojuegosNintendo) : base(eModelosNintendo, almacenamiento, eVideojuegosNintendo)
        {
            this.VerificarPortabilidad();
        }

        public Nintendo(string? eModelosNintendo, int almacenamiento, string? eVideojuegosNintendo, string? ePerifericos) : this(eModelosNintendo, almacenamiento, eVideojuegosNintendo)
        {
            this.ePerifericos = ePerifericos;
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

        public string Periferico
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Incluye periférico: {this.ePerifericos}");
                return sb.ToString();
            }
        }

        public void VerificarPortabilidad()
        {
            if (base.eModelo == EModelosNintendo.WiiU.ToString() || base.eModelo == EModelosNintendo.NintendoSwitch.ToString())
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
                sb.Append($"- {this.DuracionBateria}");
            }

            if (this.ePerifericos != null)
            {
                sb.Append($"- {this.Periferico}");
            }

            return sb.ToString();
        }

        protected override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("There's No Play Like It");
            return sb.ToString();
        }

        /*public override bool Equals(object? obj)
        {
            Boolean retorno = false;

            if (obj is Nintendo)
            {
                retorno = true;
            }

            return retorno;
        }*/

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
