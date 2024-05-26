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

        public void OrdenarPorModelo(bool ascendente)
        {
            for (int i = 0; i < this.listaConsolas.Count - 1; i++)
            {
                for (int j = 0; j < this.listaConsolas.Count - i - 1; j++)
                {
                    if (ascendente)
                    {
                        // CompareTo() es un metodo que compara dos objetos del mismo tipo (string modelo)
                        // El metodo devuelve un entero que indica la relacion de orden entre las dos cadenas
                        // Si se verifica que el resultado es mayor que 0
                        // El modelo de consola en la posicion "j" es ALFABETICAMENTE POSTERIOR al modelo de la consola en la posicion "j + 1"
                        if (listaConsolas[j].Modelo.CompareTo(listaConsolas[j + 1].Modelo) > 0)
                        {
                            Consola auxConsola = listaConsolas[j];
                            listaConsolas[j] = listaConsolas[j + 1];
                            listaConsolas[j + 1] = auxConsola;
                        }
                    }
                    else
                    {
                        if (listaConsolas[j].Modelo.CompareTo(listaConsolas[j + 1].Modelo) < 0)
                        {
                            Consola auxConsola = listaConsolas[j];
                            listaConsolas[j] = listaConsolas[j + 1];
                            listaConsolas[j + 1] = auxConsola;
                        }
                    }
                }
            }
        }

        public void OrdenarPorAlmaceamiento(bool ascendente)
        {
            for (int i = 0; i < this.listaConsolas.Count - 1; i++)
            {
                for (int j = 0; j < this.listaConsolas.Count - i - 1; j++)
                {
                    if (ascendente)
                    {
                        // CompareTo() es un metodo que compara dos objetos del mismo tipo (int almacenamiento)
                        // El metodo devuelve un entero que indica la relacion de orden entre las dos cadenas
                        // Si se verifica que el resultado es mayor que 0
                        // El modelo de consola en la posicion "j" es ALFABETICAMENTE POSTERIOR al modelo de la consola en la posicion "j + 1"
                        if (listaConsolas[j].Almacenamiento > listaConsolas[j + 1].Almacenamiento)
                        {
                            Consola auxConsola = listaConsolas[j];
                            listaConsolas[j] = listaConsolas[j + 1];
                            listaConsolas[j + 1] = auxConsola;
                        }
                    }
                    else
                    {
                        if (listaConsolas[j].Almacenamiento < listaConsolas[j + 1].Almacenamiento)
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
