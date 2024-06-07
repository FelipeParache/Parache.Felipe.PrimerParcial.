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
    /// Representa una consola Nintendo.
    /// </summary>
    public class Nintendo : Consola
    {
        public bool Portable { get; set; }
        public int DuracionBateria { get; set; }
        public string? Periferico { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Nintendo() { }

        /// <summary>
        /// Constructor que inicializa el modelo y el almacenamiento de la consola.
        /// </summary>
        public Nintendo(string? eModelosNintendo, int almacenamiento) : base(eModelosNintendo, almacenamiento)
        {
            this.VerificarPortabilidad();
        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola y el videojuego.
        /// </summary>
        public Nintendo(string? eModelosNintendo, int almacenamiento, string? eVideojuegosNintendo) : base(eModelosNintendo, almacenamiento, eVideojuegosNintendo)
        {
            this.VerificarPortabilidad();
        }

        /// <summary>
        /// Constructor que inicializa el modelo, el almacenamiento de la consola, el videojuego y el periferico.
        /// </summary>
        public Nintendo(string? eModelosNintendo, int almacenamiento, string? eVideojuegosNintendo, string? ePerifericos) : this(eModelosNintendo, almacenamiento, eVideojuegosNintendo)
        {
            this.Periferico = ePerifericos;
        }

        /// <summary>
        /// Constructor que inicializa todos los parametros para la deserializacion JSON.
        /// </summary>
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

        /// <summary>
        /// Verifica y establece si la consola es portátil.
        /// </summary>
        public void VerificarPortabilidad()
        {
            if (base.Modelo == EModelosNintendo.WiiU.ToString() || base.Modelo == EModelosNintendo.NintendoSwitch.ToString())
            {
                base.ConectividadOnline = true;
                this.Portable = true;
                this.DuracionBateria = 5;
            }
        }

        public override string MostrarInformacionResumida()
        {
            string portable = "";
            string periferico = "";

            if (this.Portable)
            {
                portable = " - Es portable";
            }
            if (this.Periferico != null)
            {
                periferico = $" - Incluye {this.Periferico}";
            }

            return $"{base.MostrarInformacionResumida()}{periferico}{portable}";
        }

        public override string MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarInformacion());

            if (this.Portable)
            {
                sb.AppendLine($"- Duracion de la bateria: {this.DuracionBateria}hs.");
            }

            if (this.Periferico != null)
            {
                sb.AppendLine($"- Incluye periferico: {this.Periferico}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Muestra el eslogan de la consola Nintendo.
        /// </summary>
        /// <returns>El eslogan de la consola Nintendo.</returns>
        public override string MostrarEslogan()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("There's No Play Like It");
            return sb.ToString();
        }

        /// <summary>
        /// Serializa la instancia actual de la consola Nintendo a formato JSON.
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
            if (obj is Nintendo nintendo)
            {
                return base.Equals(obj) && this.Portable == nintendo.Portable && this.Periferico == nintendo.Periferico;
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
