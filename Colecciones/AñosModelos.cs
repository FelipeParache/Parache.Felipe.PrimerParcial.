using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    public static class AñosModelos
    {
        private static readonly Dictionary<string, int> diccionarioAñosModelos;

        static AñosModelos()
        {
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

        public static Dictionary<string, int> DiccionarioAñosModelos
        {
            get { return diccionarioAñosModelos; }
        }

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
