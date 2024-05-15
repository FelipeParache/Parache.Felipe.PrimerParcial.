using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Xbox : Consola
    {
        private bool xboxLiveGold;
        private int almacenamientoNube;

        private Xbox() : base()
        {
            base.LlenarListaVideojuegos(typeof(EVideojuegosXbox));
        }

        public Xbox(string modelo, int almacenamiento, int almacenamientoNube) : base(modelo, almacenamiento)
        {
            this.almacenamientoNube = almacenamientoNube;
        }

        public Xbox(string modelo, int almacenamiento, int almacenamientoNube, bool xboxLive) : this(modelo, almacenamiento, almacenamientoNube)
        {
            this.xboxLiveGold = xboxLive;
        }

        public string XboxLiveGold
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (this.xboxLiveGold)
                {
                    sb.AppendLine($"Incluye servicio de Xbox Live Gold.");
                    return sb.ToString();
                }
                return "";
            }
        }

        public string AlmacenamientoNube
        {
            get
            {
                return $"Almacenamiento en la nube: {this.almacenamientoNube}GB.";
            }
        }

        protected override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.xboxLiveGold)
            {
                sb.AppendLine($"+ {this.xboxLiveGold}");
            }

            sb.AppendLine($"{this.AlmacenamientoNube}");

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
