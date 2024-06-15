using Entidades;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmGamingStore
{
    /// <summary>
    /// Formulario para el inicio de sesión de usuarios.
    /// </summary>
    public partial class FrmLogin : Form
    {
        private string rutaLogsUsuarios;
        private string rutaDataUsuarios;

        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            string archivoLogs = @"\Colecciones\Archivos\usuarios.log";
            this.rutaLogsUsuarios = ManejadorArchivos.ObtenerRuta(Environment.CurrentDirectory, archivoLogs);

            string archivoData = @"\Colecciones\Archivos\MOCK_DATA.json";
            this.rutaDataUsuarios = ManejadorArchivos.ObtenerRuta(Environment.CurrentDirectory, archivoData);

        }

        /// <summary>
        /// Método para realizar el inicio de sesión del usuario.
        /// </summary>
        /// <param name="usuario">Usuario que intenta iniciar sesión.</param>
        /// <returns>true si el inicio de sesión es exitoso, false si no lo es.</returns>
        private bool LoguearUsuario(Usuario? usuario)
        {
            if (usuario is not null)
            {
                usuario.CrearLogUsuario(rutaLogsUsuarios);
                return true;
            }
            else
            {
                MessageBox.Show($"Correo o clave incorrecta\nIntenta nuevamente", $"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Maneja el evento de click en el botón "Ingresar".
        /// </summary>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string clave = txtClave.Text;

            List<Usuario> usuarios = ManejadorArchivos.DeserializarUsuarios(this.rutaDataUsuarios);

            if (usuarios is not null)
            {
                Usuario? usuario = Usuario.BuscarUsuario(usuarios, correo, clave);
                if(this.LoguearUsuario(usuario))
                {
                    FrmGamingStore frmGamingStore = new FrmGamingStore(usuario);
                    frmGamingStore.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show($"No se ha podido verificar la existencia de usuarios.\nIntenta nuevamente en unos momentos.");
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Ver Logs Usuarios".
        /// </summary>
        private void btnLogs_Click(object sender, EventArgs e)
        {
            FrmLogsUsuarios frmLogsUsuarios = new FrmLogsUsuarios();
            frmLogsUsuarios.ShowDialog();
        }
    }
}
