using Colecciones;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Entidades
{
    /// <summary>
    /// Clase que representa una tienda de videojuegos.
    /// </summary>
    public class GamingStore
    {
        public List<Consola> listaConsolas;

        /// <summary>
        /// Constructor por defecto que inicializa la lista de consolas.
        /// </summary>
        public GamingStore()
        {
            this.listaConsolas = new List<Consola>();
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar si una consola está en la tienda.
        /// </summary>
        /// <param name="gamingStore">La tienda de videojuegos.</param>
        /// <param name="consola">La consola a comparar.</param>
        /// <returns>True si la consola está en la tienda, de lo contrario, false.</returns>
        public static bool operator ==(GamingStore gamingStore, Consola consola)
        {
            foreach (Consola auxConsola in gamingStore.listaConsolas)
            {
                if (auxConsola == consola)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar si una consola no está en la tienda.
        /// </summary>
        /// <param name="gamingStore">La tienda de videojuegos.</param>
        /// <param name="consola">La consola a comparar.</param>
        /// <returns>True si la consola no está en la tienda, de lo contrario, false.</returns>
        public static bool operator !=(GamingStore gamingStore, Consola consola)
        {
            return !(gamingStore == consola);
        }

        /// <summary>
        /// Sobrecarga del operador de adición para agregar una consola a la tienda.
        /// </summary>
        /// <param name="gamingStore">La tienda de videojuegos.</param>
        /// <param name="consola">La consola a agregar.</param>
        /// <returns>La tienda de videojuegos con la consola agregada.</returns>
        public static GamingStore operator +(GamingStore gamingStore, Consola consola)
        {
            if (gamingStore != consola)
            {
                gamingStore.listaConsolas.Add(consola);
            }
            return gamingStore;
        }

        /// <summary>
        /// Sobrecarga del operador de sustracción para eliminar una consola de la tienda.
        /// </summary>
        /// <param name="gamingStore">La tienda de videojuegos.</param>
        /// <param name="consola">La consola a eliminar.</param>
        /// <returns>La tienda de videojuegos con la consola eliminada.</returns>
        public static GamingStore operator -(GamingStore gamingStore, int indiceConsola)
        {
            if (indiceConsola >= 0 && indiceConsola < gamingStore.listaConsolas.Count)
            {
                gamingStore.listaConsolas.RemoveAt(indiceConsola);
            }
            return gamingStore;
        }

        /// <summary>
        /// Ordena la lista de consolas por año de modelo.
        /// </summary>
        /// <param name="ascendente">Indica si el orden debe ser ascendente.</param>
        public void OrdenarPorAñoModelo(bool ascendente)
        {
            for (int i = 0; i < this.listaConsolas.Count - 1; i++)
            {
                for (int j = 0; j < this.listaConsolas.Count - i - 1; j++)
                {

                    int añoConsolaA = AñosModelos.ObtenerAñoDeFabricacion(listaConsolas[j].Modelo);
                    int añoConsolaB = AñosModelos.ObtenerAñoDeFabricacion(listaConsolas[j + 1].Modelo);

                    if (ascendente)
                    {
                        if (añoConsolaA > añoConsolaB)
                        {
                            Consola auxConsola = listaConsolas[j];
                            listaConsolas[j] = listaConsolas[j + 1];
                            listaConsolas[j + 1] = auxConsola;
                        }
                    }
                    else
                    {
                        if (añoConsolaA < añoConsolaB)
                        {
                            Consola auxConsola = listaConsolas[j];
                            listaConsolas[j] = listaConsolas[j + 1];
                            listaConsolas[j + 1] = auxConsola;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ordena la lista de consolas por su clase.
        /// </summary>
        /// <param name="ascendente">Indica si el orden debe ser ascendente.</param>
        public void OrdenarPorClase(bool ascendente)
        {
            for (int i = 0; i < this.listaConsolas.Count - 1; i++)
            {
                for (int j = 0; j < this.listaConsolas.Count - i - 1; j++)
                {
                    string claseConsolaA = listaConsolas[j].GetType().ToString();
                    string claseConsolaB = listaConsolas[j + 1].GetType().ToString();

                    if (ascendente)
                    {
                        if (string.Compare(claseConsolaA, claseConsolaB) > 0)
                        {
                            Consola auxConsola = listaConsolas[j];
                            listaConsolas[j] = listaConsolas[j + 1];
                            listaConsolas[j + 1] = auxConsola;
                        }
                    }
                    else
                    {
                        if (string.Compare(claseConsolaA, claseConsolaB) < 0)
                        {
                            Consola auxConsola = listaConsolas[j];
                            listaConsolas[j] = listaConsolas[j + 1];
                            listaConsolas[j + 1] = auxConsola;
                        }
                    }
                }
            }
        }

    }
}
