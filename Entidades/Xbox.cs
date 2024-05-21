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
        readonly EModelosXbox eModelosXbox;
        readonly EVideojuegosXbox eVideojuegosXbox;

        public Xbox(EModelosXbox eModelosXbox, int almacenamiento) : base(eModelosXbox, almacenamiento)
        {
            this.eModelosXbox = eModelosXbox;
        }

        public Xbox(EModelosXbox eModelosXbox, int almacenamiento, int almacenamientoNube, bool conectividadOnline = true) : base(eModelosXbox, almacenamiento, conectividadOnline)
        {
            this.almacenamientoNube = almacenamientoNube;
        }

        public Xbox(EModelosXbox eModelosXbox, int almacenamiento, int almacenamientoNube, EVideojuegosXbox eVideojuegosXbox, bool xBoxLiveGold, bool conectividadOnline = true) : base(eModelosXbox, almacenamiento, conectividadOnline, eVideojuegosXbox)
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
                    sb.AppendLine("Incluye servicio de Xbox Live Gold");
                }
                else
                {
                    sb.AppendLine("No incluye servicio de Xbox Live Gold");
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

            sb.AppendLine($"- {this.AlmacenamientoNube}");

            return sb.ToString();
        }

        protected override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Power Your Dreams");
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            Boolean retorno = false;

            if (obj is Xbox)
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
