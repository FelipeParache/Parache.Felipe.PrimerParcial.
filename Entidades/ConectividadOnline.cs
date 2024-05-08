﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static class ConectividadOnline
    {
        private static Dictionary<string, bool> conectividadPorModelo;

        static ConectividadOnline()
        {
            ConectividadOnline.conectividadPorModelo = new Dictionary<string, bool>
            {
                // Modelos PlayStation
                { "PS1", false },
                { "PS2", false },
                { "PS3", true },
                { "PS4", true },
                { "PS5", true },

                // Modelos Xbox
                { "Xbox", false },
                { "Xbox 360", true },
                { "Xbox One", true },
                { "Xbox Series X", true },

                // Modelos Nintendo
                { "Nintendo NES", false },
                { "Super Nintendo", false },
                { "Wii", true },
                { "Nintendo Switch", true }
            };
        }

        public static bool ObtenerConectividadOnline(string? modelo)
        {
            bool conectividadOnline;
      
            if (ConectividadOnline.conectividadPorModelo.TryGetValue(modelo, out conectividadOnline))
            {
                return conectividadOnline;
            }

            return conectividadOnline;
        }
    }
}
