using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FrmGamingStore
{
    /// <summary>
    /// Formulario para mostrar los logs de usuarios.
    /// </summary>
    public partial class FrmLogsUsuarios : Form
    {
        public FrmLogsUsuarios()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormLogsUsuarios_Load(object sender, EventArgs e)
        {
            string archivo = @"\Colecciones\Archivos\usuarios.log";
            string rutaArchivo = ManejadorArchivos.ObtenerRuta(Environment.CurrentDirectory, archivo);
            
            string[] lineas = ManejadorArchivos.LeerArchivoLogs(rutaArchivo);

            lstUsuarios.Items.Clear();

            foreach (string s in lineas)
            {
                lstUsuarios.Items.Add(s);
            }
        }
    }
}
