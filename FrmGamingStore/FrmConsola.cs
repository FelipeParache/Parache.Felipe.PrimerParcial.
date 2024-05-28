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
    /// <summary>
    /// Formulario para gestionar la información de una consola.
    /// </summary>
    public partial class FrmConsola : Form
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

        /// <summary>
        /// Maneja el evento de click en el botón Aceptar.
        /// </summary>
        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Maneja el evento de click en el botón Cancelar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual void VerificarSeleccionVideojuego() { }

        /// <summary>
        /// Verifica si se ha seleccionado un modelo de consola.
        /// </summary>
        /// <exception cref="ModeloNoSeleccionadoException">Se lanza si no se ha seleccionado un modelo.</exception>
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

        /// <summary>
        /// Verifica si se ha seleccionado una capacidad de almacenamiento.
        /// </summary>
        /// <exception cref="AlmacenamientoNoSeleccionadoException">Se lanza si no se ha seleccionado una capacidad de almacenamiento.</exception>
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
