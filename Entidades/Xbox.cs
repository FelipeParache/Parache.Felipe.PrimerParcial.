using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Xbox : Consola
    {
        private int almacenamientoNube;
        private bool xboxLiveGold;

        public Xbox(string? eModelosXbox, int almacenamiento) : base(eModelosXbox, almacenamiento)
        {

        }

        public Xbox(string? eModelosXbox, int almacenamiento, string? eVideojuegosXbox) : base(eModelosXbox, almacenamiento, eVideojuegosXbox)
        {

        }

        public Xbox(string? eModelosXbox, int almacenamiento, string? eVideojuegosXbox, int almacenamientoNube, bool xBoxLiveGold, bool conectividadOnline = true) : base(eModelosXbox, almacenamiento, eVideojuegosXbox, conectividadOnline)
        {
            this.almacenamientoNube = almacenamientoNube;
            this.xboxLiveGold = xBoxLiveGold;
        }

        public string XboxLiveGold
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.xboxLiveGold)
                {
                    sb.Append("Incluye servicio de Xbox Live Gold");
                }
                else
                {
                    sb.Append("No incluye servicio de Xbox Live Gold");
                }
                return sb.ToString();
            }
        }

        public string AlmacenamientoNube
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Almacenamiento en la nube: {this.almacenamientoNube} GB");
                return sb.ToString();
            }
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.xboxLiveGold)
            {
                sb.AppendLine($"- {this.XboxLiveGold}");
            }

            if (this.almacenamientoNube > 0)
            {
                sb.Append($"- {this.AlmacenamientoNube}");
            }

            return sb.ToString();
        }

        protected override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Power Your Dreams");
            return sb.ToString();
        }

        /*public override bool Equals(object? obj)
        {
            Boolean retorno = false;

            if (obj is Xbox)
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
