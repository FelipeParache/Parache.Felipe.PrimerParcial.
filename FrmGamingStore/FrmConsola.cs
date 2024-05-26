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
    public abstract partial class FrmConsola : Form
    {
        public Consola consola;
        public string? modeloSeleccionado;
        public int almacenamientoSeleccionado;

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

        protected abstract void VerificarSeleccionVideojuego();

        public void VerificarSeleccionModelo()
        {
            try
            {
                this.modeloSeleccionado = this.cmbModelos.SelectedItem.ToString();
            }
            catch
            {
                throw new ModeloNoSeleccionadoException();
            }
        }

        public void VerificarSeleccionAlmacenamiento()
        {
            try
            {
                this.almacenamientoSeleccionado = int.Parse(this.cmbAlmacenamiento.SelectedItem.ToString().Replace(" GB", ""));
            }
            catch
            {
                throw new AlmacenamientoNoSeleccionadoException();
            }
        }
    }
}
