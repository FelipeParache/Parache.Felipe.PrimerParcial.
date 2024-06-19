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
