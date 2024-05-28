using Entidades;
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
    public partial class FrmLogsUsuarios : Form
    {
        public FrmLogsUsuarios()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormLogsUsuarios_Load(object sender, EventArgs e)
        {
            string ruta = @"C:\Users\soyfe\source\repos\Parache.Felipe.PrimerParcial\Colecciones\Archivos\usuarios.log";
            string[] lineas = ManejadorArchivos.LeerArchivoLogs(ruta);

            lstUsuarios.Items.Clear();

            foreach (string s in lineas)
            {
                lstUsuarios.Items.Add(s);
            }
        }
    }
}
