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

        #region Select

        public List<PlayStation> ObtenerPlayStation()
        {
            List<PlayStation> listaPlayStation = new List<PlayStation>();
            string sqlQuery = "SELECT id, modelo, almacenamiento, videojuego, conectividad_online, ps_plus, controles FROM playstation";
            
            try
            {
                this.lector = EjecutarQuery(sqlQuery);
                
                while (lector.Read())
                {
                    PlayStation playStation = new PlayStation();

                    playStation.Id = lector.GetInt32(0);
                    playStation.Modelo = lector.GetString(1);   
                    playStation.Almacenamiento = lector.GetInt32(2);
                    playStation.Videojuego = lector.GetString(3);
                    playStation.ConectividadOnline = lector.GetBoolean(4);
                    playStation.PsPlus = lector.GetBoolean(5);
                    playStation.Controles = lector.GetInt32(6);

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
            string sqlQuery = "SELECT id, modelo, almacenamiento, videojuego, conectividad_online, portable, duracion_bateria, periferico FROM nintendo";

            try
            {
                this.lector = EjecutarQuery(sqlQuery);

                while (lector.Read())
                {
                    Nintendo nintendo = new Nintendo();

                    nintendo.Id = lector.GetInt32(0);
                    nintendo.Modelo = lector.GetString(1);
                    nintendo.Almacenamiento = lector.GetInt32(2);
                    nintendo.Videojuego = lector.GetString(3);
                    nintendo.ConectividadOnline = lector.GetBoolean(4);
                    nintendo.Portable = lector.GetBoolean(5);
                    nintendo.DuracionBateria = lector.GetInt32(6);
                    nintendo.Periferico = lector.GetString(7);

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
            string sqlQuery = "SELECT id, modelo, almacenamiento, videojuego, conectividad_online, almacenamiento_nube, xbox_live_gold FROM xbox";

            try
            {
                this.lector = EjecutarQuery(sqlQuery);

                while (lector.Read())
                {
                    Xbox xbox = new Xbox();

                    xbox.Id = lector.GetInt32(0);
                    xbox.Modelo = lector.GetString(1);
                    xbox.Almacenamiento = lector.GetInt32(2);
                    xbox.Videojuego = lector.GetString(3);
                    xbox.ConectividadOnline = lector.GetBoolean(4);
                    xbox.AlmacenamientoNube = lector.GetInt32(5);
                    xbox.XboxLiveGold = lector.GetBoolean(6);

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

        #endregion

        #region Insert

        public int AgregarConsola(Consola consola, string tipoConsola)
        {
            string sqlQuery;

            if (tipoConsola == "PlayStation" && consola is PlayStation playStation)
            {
                sqlQuery = $"INSERT INTO playstation (modelo, almacenamiento, videojuego, conectividad_online, ps_plus, controles) " +
                           $"VALUES ('{playStation.Modelo}', {playStation.Almacenamiento}, '{playStation.Videojuego}', " +
                           $"{playStation.ConectividadOnline.GetHashCode()}, {playStation.PsPlus.GetHashCode()}, {playStation.Controles})";
            }
            else if (tipoConsola == "Xbox" && consola is Xbox xbox)
            {
                sqlQuery = $"INSERT INTO xbox (modelo, almacenamiento, videojuego, conectividad_online, almacenamiento_nube, xbox_live_gold) " +
                           $"VALUES ('{xbox.Modelo}', {xbox.Almacenamiento}, '{xbox.Videojuego}', " +
                           $"{xbox.ConectividadOnline.GetHashCode()}, {xbox.AlmacenamientoNube}, {xbox.XboxLiveGold.GetHashCode()})";
            }
            else if (tipoConsola == "Nintendo" && consola is Nintendo nintendo)
            {
                sqlQuery = $"INSERT INTO nintendo (modelo, almacenamiento, videojuego, conectividad_online, portable, duracion_bateria, periferico) " +
                           $"VALUES ('{nintendo.Modelo}', {nintendo.Almacenamiento}, '{nintendo.Videojuego}', " +
                           $"{nintendo.ConectividadOnline.GetHashCode()}, {nintendo.Portable.GetHashCode()}, {nintendo.DuracionBateria}, '{nintendo.Periferico}')";
            }
            else
            {
                throw new ArgumentException("Tipo de consola desconocido o consola no compatible.");
            }

            try
            {
                this.comando = new SqlCommand(sqlQuery, this.conexion);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar la consola: " + ex.Message);
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

        #endregion

        #region Delete

        public int EliminarConsola(int id, string tipoConsola)
        {
            string sqlQuery;

            switch (tipoConsola)
            {
                case "PlayStation":
                    sqlQuery = "DELETE FROM playstation WHERE id = @id";
                    break;
                case "Xbox":
                    sqlQuery = "DELETE FROM xbox WHERE id = @id";
                    break;
                case "Nintendo":
                    sqlQuery = "DELETE FROM nintendo WHERE id = @id";
                    break;
                default:
                    throw new ArgumentException("Tipo de consola desconocido");
            }

            try
            {
                this.comando = new SqlCommand(sqlQuery, this.conexion);
                this.comando.Parameters.AddWithValue("@id", id);

                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la consola: " + ex.Message);
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

        #endregion

        #region Update

        public int ModificarConsola(Consola consola, string tipoConsola)
        {
            string sqlQuery;

            switch (tipoConsola)
            {
                case "PlayStation":
                    PlayStation? ps = consola as PlayStation;
                    sqlQuery = $"UPDATE playstation SET " +
                               $"modelo = '{ps.Modelo}', " +
                               $"almacenamiento = {ps.Almacenamiento.ToString()}, " +
                               $"videojuego = '{ps.Videojuego}', " +
                               $"conectividad_online = {ps.ConectividadOnline.GetHashCode()}, " +
                               $"ps_plus = {ps.PsPlus.GetHashCode()}, " +
                               $"controles = {ps.Controles.ToString()} " +
                               $"WHERE id = {ps.Id.ToString()}";
                    break;

                case "Xbox":
                    Xbox? xb = consola as Xbox;
                    sqlQuery = $"UPDATE xbox SET " +
                               $"modelo = '{xb.Modelo}', " +
                               $"almacenamiento = {xb.Almacenamiento.ToString()}, " +
                               $"videojuego = '{xb.Videojuego}', " +
                               $"conectividad_online = {xb.ConectividadOnline.GetHashCode()}, " +
                               $"almacenamiento_nube = {xb.AlmacenamientoNube.ToString()}, " +
                               $"xbox_live_gold = {xb.XboxLiveGold.GetHashCode()} " +
                               $"WHERE id = {xb.Id.ToString()}";
                    break;

                case "Nintendo":
                    Nintendo? nn = consola as Nintendo;
                    sqlQuery = $"UPDATE nintendo SET " +
                               $"modelo = '{nn.Modelo}', " +
                               $"almacenamiento = {nn.Almacenamiento.ToString()}, " +
                               $"videojuego = '{nn.Videojuego}', " +
                               $"conectividad_online = {nn.ConectividadOnline.GetHashCode()}, " +
                               $"portable = {nn.Portable.GetHashCode()}, " +
                               $"duracion_bateria = {nn.DuracionBateria.ToString()}, " +
                               $"periferico = '{nn.Periferico}' " +
                               $"WHERE id = {nn.Id.ToString()}";
                    break;

                default:
                    throw new ArgumentException("Tipo de consola desconocido");
            }

            try
            {
                this.comando = new SqlCommand(sqlQuery, this.conexion);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la consola: " + ex.Message);
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

        #endregion

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
