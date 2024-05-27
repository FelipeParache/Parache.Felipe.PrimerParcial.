using Colecciones;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GamingStore
    {
        public List<Consola> listaConsolas;

        public GamingStore()
        {
            this.listaConsolas = new List<Consola>();
        }

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

        public static bool operator !=(GamingStore gamingStore, Consola consola)
        {
            return !(gamingStore == consola);
        }

        public static GamingStore operator +(GamingStore gamingStore, Consola consola)
        {
            if (gamingStore != consola)
            {
                gamingStore.listaConsolas.Add(consola);
            }
            return gamingStore;
        }

        public static GamingStore operator -(GamingStore gamingStore, Consola consola)
        {
            if (gamingStore == consola)
            {
                gamingStore.listaConsolas.Remove(consola);
            }
            return gamingStore;
        }

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
                        // Utilizo el metodo Compare para determinar el orden alfabetico entre las dos cadenas
                        // Si el resultado es menor a 0 significa que A es anterior que B alfabeticamente
                        // Si el resultado es igual a 0 significa que A es igual a B
                        // Si el resultado es mayor a 0 significa que A es posterior a B
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
