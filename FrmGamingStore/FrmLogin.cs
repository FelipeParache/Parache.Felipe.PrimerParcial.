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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool LoguearUsuario(List<Usuario> usuarios, Usuario? usuario)
        {
            if (usuario is not null)
            {
                string rutaUsuario = @"C:\Users\soyfe\source\repos\Parache.Felipe.PrimerParcial\Colecciones\Archivos\usuarios.log";

                usuario.CrearLogUsuario(rutaUsuario);
                return true;
            }
            else
            {
                MessageBox.Show($"Correo o clave incorrecta\nIntenta nuevamente", $"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string clave = txtClave.Text;

            string ruta = @"C:\Users\soyfe\source\repos\Parache.Felipe.PrimerParcial\Colecciones\Archivos\MOCK_DATA.json";

            List<Usuario> usuarios = ManejadorArchivos.DeserializarUsuarios(ruta);
           
            if (usuarios is not null)
            {
                Usuario? usuario = Usuario.BuscarUsuario(usuarios, correo, clave);
                if(this.LoguearUsuario(usuarios, usuario))
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

        private void btnLogs_Click(object sender, EventArgs e)
        {
            FrmLogsUsuarios frmLogsUsuarios = new FrmLogsUsuarios();
            frmLogsUsuarios.ShowDialog();
        }
    }
}
