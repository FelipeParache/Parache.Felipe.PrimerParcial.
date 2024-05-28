using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Xbox : Consola
    {
        public int AlmacenamientoNube { get; set; }
        public bool XboxLiveGold { get; set; }

        public Xbox() { }

        public Xbox(string? eModelosXbox, int almacenamiento) : base(eModelosXbox, almacenamiento)
        {

        }

        public Xbox(string? eModelosXbox, int almacenamiento, string? eVideojuegosXbox) : base(eModelosXbox, almacenamiento, eVideojuegosXbox)
        {

        }

        public Xbox(string? eModelosXbox, int almacenamiento, string? eVideojuegosXbox, int almacenamientoNube, bool xBoxLiveGold, bool conectividadOnline = true) : base(eModelosXbox, almacenamiento, eVideojuegosXbox, conectividadOnline)
        {
            this.AlmacenamientoNube = almacenamientoNube;
            this.XboxLiveGold = xBoxLiveGold;
        }

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

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());
            
            if (this.XboxLiveGold)
            {
                sb.Append("Incluye servicio de Xbox Live Gold");
            }
            else
            {
                sb.Append("No incluye servicio de Xbox Live Gold");
            }

            if (this.AlmacenamientoNube > 0)
            {
                sb.AppendLine($"Almacenamiento en la nube: {this.AlmacenamientoNube} GB");
            }

            return sb.ToString();
        }

        public override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Power Your Dreams");
            return sb.ToString();
        }

        public override string Serializar()
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            return JsonSerializer.Serialize(this, opciones);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
