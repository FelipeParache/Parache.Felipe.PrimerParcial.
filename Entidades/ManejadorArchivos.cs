using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            List<Usuario>? usuarios = new List<Usuario>();

            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.PropertyNameCaseInsensitive = true;

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

        public static void SerializarConsolasJSON(string ruta, List<Consola> consolas)
        {
            try
            {
                List<string> consolasSerializadas = new List<string>();
                foreach (Consola consola in consolas)
                {
                    string consolaSerializada = consola.Serializar();
                    consolasSerializadas.Add(consolaSerializada);
                }

                string jsonResultante = "[" + string.Join(",", consolasSerializadas) + "]";

                File.WriteAllText(ruta, jsonResultante);
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

        public static List<Consola>? DeserializarConsolasJSON(string ruta)
        {
            try
            {
                if (File.Exists(ruta))
                {
                    string obj_json = File.ReadAllText(ruta);
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.PropertyNameCaseInsensitive = true;

                    List<Consola> consolas = new List<Consola>();
                    List<JsonElement>? jsonConsolas = JsonSerializer.Deserialize<List<JsonElement>>(obj_json, opciones);

                    foreach (JsonElement jsonConsola in jsonConsolas)
                    {
                        if (jsonConsola.TryGetProperty("Modelo", out JsonElement jsonModelo))
                        {
                            string modelo = jsonModelo.ToString();
                            Consola? consola;
                            switch (modelo)
                            {
                                case "PS1":
                                case "PS2":
                                case "PS3":
                                case "PS4":
                                case "PS5":
                                    consola = JsonSerializer.Deserialize<PlayStation>(jsonConsola.GetRawText(), opciones);
                                    break;
                                case "NintendoNes":
                                case "SuperNintendo":
                                case "WiiU":
                                case "NintendoSwitch":
                                    consola = JsonSerializer.Deserialize<Nintendo>(jsonConsola.GetRawText(), opciones);
                                    break;
                                case "Xbox":
                                case "Xbox360":
                                case "XboxOne":
                                case "XboxSeriesX":
                                    consola = JsonSerializer.Deserialize<Xbox>(jsonConsola.GetRawText(), opciones);
                                    break;
                                default:
                                    consola = null;
                                    break;
                            }
                            if (consola != null)
                            {
                                consolas.Add(consola);
                            }
                        }
                    }
                    return consolas;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
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
