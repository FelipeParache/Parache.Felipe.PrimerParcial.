﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa una consola PlayStation.
    /// </summary>
    public class PlayStation : Consola
    {
        public bool PsPlus { get; set; }
        public int Controles { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public PlayStation() { }

        /// <summary>
        /// Constructor que inicializa el modelo y el almacenamiento de la consola.
        /// </summary>
        public PlayStation(string? eModelosPlayStation, int almacenamiento) : base(eModelosPlayStation, almacenamiento)
        {

        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola, el videojuego y los controles.
        /// </summary>
        public PlayStation(string? eModelosPlayStation, int almacenamiento, string? eVideojuegosPlayStation, int controles) : base(eModelosPlayStation, almacenamiento, eVideojuegosPlayStation)
        {
            this.Controles = controles;
        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola, el videojuego, los controles, la conectividad online y ps plus.
        /// </summary>
        public PlayStation(string? eModelosPlayStation, int almacenamiento, string? eVideoJuegosPlayStation, int controles, bool conectividadOnline, bool psPlus) : base(eModelosPlayStation, almacenamiento, eVideoJuegosPlayStation, conectividadOnline)
        {
            this.Controles = controles;
            this.PsPlus = psPlus;
        }

        /// <summary>
        /// Constructor que inicializa todos los parametros para la deserializacion JSON.
        /// </summary>
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
            sb.Append(base.MostrarInformacion());

            if (this.PsPlus)
            {
                sb.AppendLine("- Incluye servicio de PlayStation Plus");
            }
            else
            {
                sb.AppendLine("- No incluye servicio de PlayStation Plus");
            }

            if (this.Controles < 1)
            {
                sb.AppendLine("- No incluye control Dualshock");
            }
            else if (this.Controles == 1)
            {
                sb.AppendLine($"- Incluye {this.Controles} control Dualshock");
            }
            else if (this.Controles > 1)
            {
                sb.AppendLine($"- Incluye {this.Controles} controles Dualshock");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra el eslogan de la consola PlayStation.
        /// </summary>
        /// <returns>El eslogan de la consola PlayStation.</returns>
        public override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Play Has No Limits");
            return sb.ToString();
        }

        /// <summary>
        /// Serializa la instancia actual de la consola PlayStation a formato JSON.
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
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
