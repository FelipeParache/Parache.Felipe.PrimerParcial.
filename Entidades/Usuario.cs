using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa un usuario con sus atributos principales
    /// </summary>
    public class Usuario
    {
        public string Apellido {  get; set; }
        public string Nombre { get; set; }
        public int Legajo { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Perfil { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Usuario()
        {
            Apellido = string.Empty;
            Nombre = string.Empty;
            Legajo = 0;
            Correo = string.Empty;
            Clave = string.Empty;
            Perfil = string.Empty;
        }

        /// <summary>
        /// Constructor que inicializa el correo y la clave.
        /// </summary>
        public Usuario(string correo, string clave) : this()
        {
            Correo = correo;
            Clave = clave;
        }

        /// <summary>
        /// Constructor que inicializa el apellido, nombre, legajo, correo, clave y perfil.
        /// </summary>
        public Usuario(string apellido, string nombre, int legajo, string correo, string clave, string perfil) : this(correo, clave)
        {
            Apellido = apellido;
            Nombre = nombre;
            Legajo = legajo;
            Perfil = perfil;
        }

        /// <summary>
        /// Compara dos objetos de tipo Usuario según sus atributos correo y clave.
        /// </summary>
        /// <returns>true si son iguales, false si son diferentes.</returns>
        public static bool operator ==(Usuario uA, Usuario uB)
        {
            return (uA.Correo == uB.Correo && uA.Clave == uB.Clave);
        }

        /// <summary>
        /// Compara dos objetos de tipo Usuario para determinar si son diferentes.
        /// </summary>
        /// <returns>true si son diferentes, false si son iguales.</returns>
        public static bool operator !=(Usuario uA, Usuario uB)
        {
            return !(uA == uB);
        }

        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido}";
        }

        /// <summary>
        /// Busca si el correo y la clave recibidos por parámetro coinciden con los de algún usuario en la lista recibida por parámetro.
        /// </summary>
        /// <param name="usuarios">Lista de usuarios a recorrer.</param>
        /// <param name="correo">Correo electrónico a buscar.</param>
        /// <param name="clave">Clave a buscar.</param>
        /// <returns>null si no se encontró el usuario, el usuario hallado si se encontró.</returns>
        public static Usuario? BuscarUsuario(List<Usuario> usuarios, string correo, string clave)
        { 
            Usuario usuario = new Usuario(correo, clave);

            foreach (Usuario u in usuarios)
            {
                if (u == usuario)
                {
                    return u;
                }
            }
            return null;
        }

        /// <summary>
        /// Crea un log en el archivo ubicado en la ruta recibida por parámetro, escribiendo nombre, apellido y horario de ingreso de este usuario.
        /// </summary>
        /// <param name="ruta">Ruta del archivo donde se va a escribir.</param>
        public void CrearLogUsuario(string ruta)
        {
            string fechaHora = DateTime.Now.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append($"Usuario ingresado: {this.ToString()}");
            sb.Append($" - Fecha y hora de ingreso: {fechaHora}");

            using (StreamWriter sw = new StreamWriter(ruta, true))
            {
                sw.WriteLine(sb.ToString());
            }

        }

        public override bool Equals(object? obj)
        {
            if (obj is Usuario)
            {
                return this == (Usuario)obj;
            }
            return false;
        }
    }
}
