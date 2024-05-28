using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlayStation : Consola
    {
        public bool PsPlus { get; set; }
        public int Controles { get; set; }

        public PlayStation() { }

        public PlayStation(string? eModelosPlayStation, int almacenamiento) : base(eModelosPlayStation, almacenamiento)
        {

        }

        public PlayStation(string? eModelosPlayStation, int almacenamiento, string? eVideojuegosPlayStation, int controles) : base(eModelosPlayStation, almacenamiento, eVideojuegosPlayStation)
        {
            this.Controles = controles;
        }

        public PlayStation(string? eModelosPlayStation, int almacenamiento, string? eVideoJuegosPlayStation, int controles, bool conectividadOnline, bool psPlus) : base(eModelosPlayStation, almacenamiento, eVideoJuegosPlayStation, conectividadOnline)
        {
            this.Controles = controles;
            this.PsPlus = psPlus;
        }

        [JsonConstructor]
        public PlayStation(bool PsPlus, int Controles, bool ConectividadOnline, string Modelo, int Almacenamiento, string Videojuego)
        {
            this.PsPlus = PsPlus;
            this.Controles = Controles;
            this.ConectividadOnline = ConectividadOnline;
            this.Modelo = Modelo;
            this.Almacenamiento = Almacenamiento;
            this.Videojuego = Videojuego;
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarInformacion());

            if (this.PsPlus)
            {
                sb.Append("Incluye servicio de PlayStation Plus");
            }
            else
            {
                sb.Append("No incluye servicio de PlayStation Plus");
            }

            if (this.Controles < 1)
            {
                sb.AppendLine("No incluye control Dualshock");
            }
            else if (this.Controles == 1)
            {
                sb.AppendLine($"Incluye {this.Controles} control Dualshock");
            }
            else if (this.Controles > 1)
            {
                sb.AppendLine($"Incluye {this.Controles} controles Dualshock");
            }

            return sb.ToString();
        }

        public override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Play Has No Limits");
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
