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
    /// Clase estática con métodos que se utilizarán para leer archivos, serializar y deserializar datos.
    /// </summary>
    public static class ManejadorArchivos 
    {
        /// <summary>
        /// Deserializa la lista de usuarios hallada en el archivo tipo JSON recibido por parámetro.
        /// </summary>
        /// <param name="ruta">Ruta del archivo JSON.</param>
        /// <returns>Lista de usuarios en el archivo, o null si ocurre un error.</returns>
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
        /// Serializa en el archivo que se encuentra en la ruta recibida por parámetro,
        /// la lista de consolas recibida por parámetro en formato JSON.
        /// </summary>
        /// <param name="ruta">Ruta del archivo JSON.</param>
        /// <param name="consolas">Lista de consolas a serializar.</param>
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
        /// Deserializa la lista de consolas hallada en el archivo tipo JSON recibido por parámetro.
        /// </summary>
        /// <param name="ruta">Ruta del archivo JSON.</param>
        /// <returns>Lista de consolas en el archivo, o null si ocurre un error.</returns>
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
        /// Lee los logs con el registro de los usuarios hallados en el archivo de tipo TXT recibido por parámetro.
        /// </summary>
        /// <param name="ruta">Ruta del archivo TXT.</param>
        /// <returns>Array de strings con las líneas de texto halladas.</returns>
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
