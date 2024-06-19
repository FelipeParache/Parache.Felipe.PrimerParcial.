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

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandText = "SELECT modelo, almacenamiento, videojuego, conectividad_online, ps_plus, controles FROM playstation";
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read()) // Este metodo lee cada fila de la tabla y luego la elimina
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
                Console.WriteLine(ex.ToString());
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

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandText = "SELECT modelo, almacenamiento, videojuego, conectividad_online, portable, duracion_bateria, periferico FROM nintendo";
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read()) // Este metodo lee cada fila de la tabla y luego la elimina
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
                Console.WriteLine(ex.ToString());
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

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandText = "SELECT modelo, almacenamiento, videojuego, conectividad_online, almacenamiento_nube, xbox_live_gold FROM xbox";
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read()) // Este metodo lee cada fila de la tabla y luego la elimina
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
                string sqlQuery = "INSERT INTO playstation (modelo, almacenamiento, videojuego, conectividad_online, ps_plus, controles) VALUES(";
                sqlQuery = sqlQuery + "'" + playStation.Modelo + "'," + playStation.Almacenamiento.ToString() + ",'" + playStation.Videojuego + "'," + playStation.ConectividadOnline.GetHashCode() + "," + playStation.PsPlus.GetHashCode() + "," + playStation.Controles.ToString() + ")";
                
                this.comando = new SqlCommand();
                
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sqlQuery;
                this.comando.Connection = this.conexion;

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
                string sqlQuery = "INSERT INTO nintendo (modelo, almacenamiento, videojuego, conectividad_online, portable, duracion_bateria, periferico) VALUES(";
                sqlQuery = sqlQuery + "'" + nintendo.Modelo + "'," + nintendo.Almacenamiento.ToString() + ",'" + nintendo.Videojuego + "'," + nintendo.ConectividadOnline.GetHashCode() + "," + nintendo.Portable.GetHashCode() + "," + nintendo.DuracionBateria.ToString() + ",'" + nintendo.Periferico + "'" + ")";

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sqlQuery;
                this.comando.Connection = this.conexion;

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
                string sqlQuery = "INSERT INTO xbox (modelo, almacenamiento, videojuego, conectividad_online, almacenamiento_nube, xbox_live_gold) VALUES(";
                sqlQuery = sqlQuery + "'" + xbox.Modelo + "'," + xbox.Almacenamiento.ToString() + ",'" + xbox.Videojuego + "'," + xbox.ConectividadOnline.GetHashCode() + "," + xbox.AlmacenamientoNube.ToString() + "," + xbox.XboxLiveGold.GetHashCode() + ")";

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sqlQuery;
                this.comando.Connection = this.conexion;

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
    }
}
