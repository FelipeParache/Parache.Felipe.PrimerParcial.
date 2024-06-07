using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa una consola Xbox.
    /// </summary>
    public class Xbox : Consola
    {
        public int AlmacenamientoNube { get; set; }
        public bool XboxLiveGold { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Xbox() { }

        /// <summary>
        /// Constructor que inicializa el modelo y el almacenamiento de la consola.
        /// </summary>
        public Xbox(string? eModelosXbox, int almacenamiento) : base(eModelosXbox, almacenamiento)
        {

        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola y el videojuego.
        /// </summary>
        public Xbox(string? eModelosXbox, int almacenamiento, string? eVideojuegosXbox) : base(eModelosXbox, almacenamiento, eVideojuegosXbox)
        {

        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola, el videojuego, el almacenamiento nube, xbox live gold y la conectividad online por defecto true.
        /// </summary>
        public Xbox(string? eModelosXbox, int almacenamiento, string? eVideojuegosXbox, int almacenamientoNube, bool xBoxLiveGold, bool conectividadOnline = true) : base(eModelosXbox, almacenamiento, eVideojuegosXbox, conectividadOnline)
        {
            this.AlmacenamientoNube = almacenamientoNube;
            this.XboxLiveGold = xBoxLiveGold;
        }

        /// <summary>
        /// Constructor que inicializa todos los parametros para la deserializacion JSON.
        /// </summary>
        [JsonConstructor]
        public Xbox(bool XboxLiveGold, int AlmacenamientoNube, bool ConectividadOnline, string Modelo, int Almacenamiento, string Videojuego)
        {
            this.XboxLiveGold = XboxLiveGold;
            this.AlmacenamientoNube = AlmacenamientoNube;
            this.ConectividadOnline = ConectividadOnline;
            this.Modelo = Modelo;
            this.Almacenamiento = Almacenamiento;
            this.Videojuego = Videojuego;
        }

        public override string MostrarInformacionResumida()
        {
            string almacenamientoNube = "";
            string xboxLiveGold = "";

            if (this.XboxLiveGold)
            {
                xboxLiveGold = " - Incluye XboxLiveGold";
            }
            if (this.AlmacenamientoNube != 0)
            {
                almacenamientoNube = $" - {this.AlmacenamientoNube} GB Nube";
            }

            return $"{base.MostrarInformacionResumida()}{xboxLiveGold}{almacenamientoNube}";
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarInformacion());
            
            if (this.XboxLiveGold)
            {
                sb.AppendLine("- Incluye servicio de Xbox Live Gold");
            }
            else
            {
                sb.AppendLine("- No incluye servicio de Xbox Live Gold");
            }

            if (this.AlmacenamientoNube > 0)
            {
                sb.AppendLine($"- Almacenamiento en la nube: {this.AlmacenamientoNube} GB");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra el eslogan de la consola Xbox.
        /// </summary>
        /// <returns>El eslogan de la consola Xbox.</returns>
        public override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Power Your Dreams");
            return sb.ToString();
        }

        /// <summary>
        /// Serializa la instancia actual de la consola Xbox a formato JSON.
        /// </summary>
        /// <returns>Una cadena en formato JSON que representa la instancia actual.</returns>
        public override string Serializar()
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            return JsonSerializer.Serialize(this, opciones);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Xbox xbox)
            {
                return base.Equals(obj) && this.AlmacenamientoNube == xbox.AlmacenamientoNube && this.XboxLiveGold == xbox.XboxLiveGold;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
