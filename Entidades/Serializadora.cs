using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    public class Serializadora<T> : IJSON<T>
    {
        private string? ruta;

        public Serializadora()
        {

        }

        public Serializadora(string ruta)
        {
            this.ruta = ruta;
        }

        public string Serializar(T dato, string ruta)
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            return JsonSerializer.Serialize(dato, opciones);
        }

        public T Deserializar(string dato)
        {
            if (!File.Exists(ruta))
            {
                throw new FileNotFoundException("El archivo no existe.", ruta);
            }

            string obj_json = File.ReadAllText(ruta);
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.PropertyNameCaseInsensitive = true;
  
            return JsonSerializer.Deserialize<T>(obj_json, opciones); 
        }
    }
}
