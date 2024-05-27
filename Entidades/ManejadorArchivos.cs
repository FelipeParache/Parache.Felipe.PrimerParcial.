using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase estatica con metodos que se utilizarán para leer archivos, serializar y deserializar datos
    /// </summary>
    public static class ManejadorArchivos
    {
        /// <summary>
        /// Deserealiza la lista de usuarios hallada en el archivo tipo json recibido por parametro
        /// </summary>
        /// <param name="ruta">string con la ruta del archivo</param>
        /// <returns>Lista de usuarios en el archivo (si se encuentran) - 
        /// null en caso contrario</returns>
        
        public static List<Usuario> DeserializarUsuarios(string ruta)
        {
            List<Usuario>? usuarios = new();

            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string json = sr.ReadToEnd();
                    usuarios = (List<Usuario>?)JsonSerializer.Deserialize(json, typeof(List<Usuario>), opciones);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return usuarios;
        }

        /// <summary>
        /// Seraliza, en el archivo que se encuentra en la ruta recibida por parametro,
        /// la lista de consolas recibida por parametro en formato XML
        /// </summary>
        /// <param name="ruta">string con la ruta del archivo</param>
        /// <param name="consolas">Lista de consolas, a serealizar</param>
        
        public static void SerializarConsolas(string ruta, List<Consola> consolas)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(ruta, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Consola>));
                    ser.Serialize(writer, consolas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Deserealiza la lista de consolas hallada en el archivo tipo xml recibido por parametro
        /// </summary>
        /// <returns>Lista de consolas en el archivo (si se encuentran), null en caso contrario</returns>
        
        public static List<Consola>? DeserializarConsolas(string ruta)
        {
            List<Consola> consolas = new();

            try
            {
                using (XmlTextReader reader = new XmlTextReader(ruta))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Consola>));
                    consolas = (List<Consola>?)ser.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }

            return consolas;
        }

        /// <summary>
        /// Lee los logs con el registro de los usuarios hallados en el archivo de tipo txt recibido por parametro 
        /// </summary>
        /// <param name="ruta">string con la ruta del archivo</param>
        /// <returns>string[] con las lineas de texto halladas</returns>
        
        public static string[] LeerArchivoLogs(string ruta)
        {
            string[] lineas = {};

            try
            {
                lineas = File.ReadAllLines(ruta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lineas;
        }
    }
}
