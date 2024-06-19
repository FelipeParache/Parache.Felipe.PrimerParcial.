using Entidades;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;

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
    }
}
