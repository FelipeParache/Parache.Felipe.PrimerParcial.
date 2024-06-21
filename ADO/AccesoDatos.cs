using Entidades;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace ADO
{
    public class AccesoDatos
    {
        private static string? cadenaConexion;
        private SqlConnection? conexion;
        private SqlCommand? comando;
        private SqlDataReader? lector;

        static AccesoDatos()
        {
            AccesoDatos.cadenaConexion = Properties.Resources.miConexion;
        }

        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadenaConexion);
        }

        public bool ProbarConexion()
        {
            bool respuesta = true;
            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                respuesta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return respuesta;
        }

        public List<PlayStation> ObtenerPlayStation()
        {
            List<PlayStation> listaPlayStation = new List<PlayStation>();
            string sqlQuery = "SELECT modelo, almacenamiento, videojuego, conectividad_online, ps_plus, controles FROM playstation";
            
            try
            {
                this.lector = EjecutarQuery(sqlQuery);
                
                while (lector.Read())
                {
                    PlayStation playStation = new PlayStation();

                    playStation.Modelo = lector.GetString(0);   
                    playStation.Almacenamiento = lector.GetInt32(1);
                    playStation.Videojuego = lector.GetString(2);
                    playStation.ConectividadOnline = lector.GetBoolean(3);
                    playStation.PsPlus = lector.GetBoolean(4);
                    playStation.Controles = lector.GetInt32(5);

                    listaPlayStation.Add(playStation);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return listaPlayStation;
        }

        public List<Nintendo> ObtenerNintendo()
        {
            List<Nintendo> listaNintendo = new List<Nintendo>();
            string sqlQuery = "SELECT modelo, almacenamiento, videojuego, conectividad_online, portable, duracion_bateria, periferico FROM nintendo";

            try
            {
                this.lector = EjecutarQuery(sqlQuery);

                while (lector.Read())
                {
                    Nintendo nintendo = new Nintendo();

                    nintendo.Modelo = lector.GetString(0);
                    nintendo.Almacenamiento = lector.GetInt32(1);
                    nintendo.Videojuego = lector.GetString(2);
                    nintendo.ConectividadOnline = lector.GetBoolean(3);
                    nintendo.Portable = lector.GetBoolean(4);
                    nintendo.DuracionBateria = lector.GetInt32(5);
                    nintendo.Periferico = lector.GetString(6);

                    listaNintendo.Add(nintendo);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return listaNintendo;
        }

        public List<Xbox> ObtenerXbox()
        {
            List<Xbox> listaXbox = new List<Xbox>();
            string sqlQuery = "SELECT modelo, almacenamiento, videojuego, conectividad_online, almacenamiento_nube, xbox_live_gold FROM xbox";

            try
            {
                this.lector = EjecutarQuery(sqlQuery);

                while (lector.Read())
                {
                    Xbox xbox = new Xbox();

                    xbox.Modelo = lector.GetString(0);
                    xbox.Almacenamiento = lector.GetInt32(1);
                    xbox.Videojuego = lector.GetString(2);
                    xbox.ConectividadOnline = lector.GetBoolean(3);
                    xbox.AlmacenamientoNube = lector.GetInt32(4);
                    xbox.XboxLiveGold = lector.GetBoolean(5);

                    listaXbox.Add(xbox);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return listaXbox;
        }

        public int AgregarConsola(PlayStation playStation)
        {
            try
            {
                string sqlQuery = $"INSERT INTO playstation (modelo, almacenamiento, videojuego, conectividad_online, ps_plus, controles) " +
                                  $"VALUES ('{playStation.Modelo}', {playStation.Almacenamiento}, '{playStation.Videojuego}', " +
                                  $"{playStation.ConectividadOnline.GetHashCode()}, {playStation.PsPlus.GetHashCode()}, {playStation.Controles})";

                this.comando = new SqlCommand(sqlQuery, this.conexion);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public int AgregarConsola(Nintendo nintendo)
        {
            try
            {
                string sqlQuery = $"INSERT INTO nintendo (modelo, almacenamiento, videojuego, conectividad_online, portable, duracion_bateria, periferico) " +
                                  $"VALUES ('{nintendo.Modelo}', {nintendo.Almacenamiento}, '{nintendo.Videojuego}', " +
                                  $"{nintendo.ConectividadOnline.GetHashCode()}, {nintendo.Portable.GetHashCode()}, {nintendo.DuracionBateria}, '{nintendo.Periferico}')";

                this.comando = new SqlCommand(sqlQuery, this.conexion);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public int AgregarConsola(Xbox xbox)
        {
            try
            {
                string sqlQuery = $"INSERT INTO xbox (modelo, almacenamiento, videojuego, conectividad_online, almacenamiento_nube, xbox_live_gold) " +
                                  $"VALUES ('{xbox.Modelo}', {xbox.Almacenamiento}, '{xbox.Videojuego}', " +
                                  $"{xbox.ConectividadOnline.GetHashCode()}, {xbox.AlmacenamientoNube}, {xbox.XboxLiveGold.GetHashCode()})";

                this.comando = new SqlCommand(sqlQuery, this.conexion);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        private SqlDataReader EjecutarQuery(string sqlQuery)
        {
            SqlDataReader? lector = null;

            try
            {
                this.comando = new SqlCommand(sqlQuery, this.conexion);
                this.conexion.Open();
                lector = this.comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return lector;
        }
    }
}
