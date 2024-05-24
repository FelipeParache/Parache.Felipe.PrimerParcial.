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
    public partial class FrmConsola : Form
    {
        protected Consola consola;

        public FrmConsola()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.cmbAlmacenamiento.Items.Add("500 GB");
            this.cmbAlmacenamiento.Items.Add("1000 GB");
            this.cmbAlmacenamiento.Items.Add("2000 GB");
        }

        public virtual Consola ConsolaDelFormulario
        {
            get { return consola; }
        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
