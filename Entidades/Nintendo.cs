using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nintendo : Consola
    {
        public bool Portable { get; set; }
        public int DuracionBateria { get; set; }
        public string? Periferico { get; set; }

        public Nintendo() { }

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
            this.Periferico = ePerifericos;
        }

        [JsonConstructor]
        public Nintendo(bool Portable, int DuracionBateria, string Periferico, bool ConectividadOnline, string Modelo, int Almacenamiento, string Videojuego)
        {
            this.Portable = Portable;
            this.DuracionBateria = DuracionBateria;
            this.Periferico = Periferico;
            this.ConectividadOnline = ConectividadOnline;
            this.Modelo = Modelo;
            this.Almacenamiento = Almacenamiento;
            this.Videojuego = Videojuego;
        }

        public void VerificarPortabilidad()
        {
            if (base.Modelo == EModelosNintendo.WiiU.ToString() || base.Modelo == EModelosNintendo.NintendoSwitch.ToString())
            {
                base.ConectividadOnline = true;
                this.Portable = true;
                this.DuracionBateria = 5;
            }
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.Portable)
            {
                sb.AppendLine($"Duracion de la bateria: {this.DuracionBateria}hs.");
            }

            if (this.Periferico != null)
            {
                sb.AppendLine($"Incluye periferico: {this.Periferico}");
            }

            return sb.ToString();
        }

        public override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("There's No Play Like It");
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
