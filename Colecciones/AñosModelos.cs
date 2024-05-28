using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    /// <summary>
    /// Clase estática que proporciona información sobre los años de fabricación de los modelos de consolas.
    /// </summary>
    public static class AñosModelos
    {
        /// <summary>
        /// Diccionario que asocia el modelo de consola con su año de fabricación.
        /// </summary>
        private static readonly Dictionary<string, int> diccionarioAñosModelos;

        static AñosModelos()
        {
            /// <summary>
            /// Constructor estático que inicializa el diccionario con los modelos y sus respectivos años de fabricación.
            /// </summary>
            diccionarioAñosModelos = new Dictionary<string, int>
            {
                {EModelosNintendo.NintendoNes.ToString(), 1985 },
                {EModelosNintendo.SuperNintendo.ToString(), 1990 },
                {EModelosNintendo.WiiU.ToString(), 2012 },
                {EModelosNintendo.NintendoSwitch.ToString(), 2017 },
                {EModelosPlayStation.PS1.ToString(), 1994 },
                {EModelosPlayStation.PS2.ToString(), 2000 },
                {EModelosPlayStation.PS3.ToString(), 2006 },
                {EModelosPlayStation.PS4.ToString(), 2013 },
                {EModelosPlayStation.PS5.ToString(), 2020 },
                {EModelosXbox.Xbox.ToString(), 2001 },
                {EModelosXbox.Xbox360.ToString(), 2005 },
                {EModelosXbox.XboxOne.ToString(), 2013 },
                {EModelosXbox.XboxSeriesX.ToString() , 2020 }
            };
        }

        /// <summary>
        /// Obtiene el diccionario que contiene los modelos de consolas y sus años de fabricación.
        /// </summary>
        public static Dictionary<string, int> DiccionarioAñosModelos
        {
            get { return diccionarioAñosModelos; }
        }

        /// <summary>
        /// Obtiene el año de fabricación de un modelo de consola dado su nombre.
        /// </summary>
        /// <param name="modelo">El nombre del modelo de la consola.</param>
        /// <returns>El año de fabricación del modelo, o 0 si el modelo no se encuentra en el diccionario.</returns>
        public static int ObtenerAñoDeFabricacion(string modelo)
        {
            if (diccionarioAñosModelos.ContainsKey(modelo))
            {
                return diccionarioAñosModelos[modelo];
            }
            return 0;
        }
    }
}
