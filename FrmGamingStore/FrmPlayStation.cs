using FrmGamingStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmGamingStore
{
    public partial class FrmPlayStation : FrmConsola
    {
        private Consola playStation;
        private string? videojuegoSeleccionado;
        private int controlSeleccionado;

        public FrmPlayStation()
        {
            InitializeComponent();

            this.cmbControles.Items.Add(1);
            this.cmbControles.Items.Add(2);
            this.cmbControles.Items.Add(3);
            this.cmbControles.Items.Add(4);

            Array arrayModelos = Enum.GetValues(typeof(EModelosPlayStation));
            Array arrayVideojuegos = Enum.GetValues(typeof(EVideojuegosPlayStation));

            foreach (EModelosPlayStation modelo in arrayModelos)
            {
                this.cmbModelos.Items.Add(modelo);
            }

            foreach (EVideojuegosPlayStation videojuego in arrayVideojuegos)
            {
                this.cmbVideojuegos.Items.Add(videojuego);
            }
        }

        public override Consola ConsolaDelFormulario
        {
            get { return playStation; }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            // Verificar selección de modelo
            try
            {
                base.VerificarSeleccionModelo();
            }
            catch (ModeloNoSeleccionadoException)
            {
                MessageBox.Show("Por favor, seleccione un modelo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar selección de almacenamiento
            try
            {
                base.VerificarSeleccionAlmacenamiento();
            }
            catch (AlmacenamientoNoSeleccionadoException)
            {
                MessageBox.Show("Por favor, seleccione una opción de almacenamiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar selección de control
            this.VerificarSeleccionControl();

            // Verificar selección de videojuego si se seleccionó almacenamiento nube
            try
            {
                this.VerificarSeleccionVideojuegoDadoControles();
            }
            catch (VideojuegoNoSeleccionadoException)
            {
                MessageBox.Show("Por favor, seleccione un videojuego.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cmbControles.SelectedIndex == -1 && this.cmbVideojuegos.SelectedIndex == -1)
            {
                MessageBox.Show("SOY OPCION 1");
                playStation = new PlayStation(modeloSeleccionado, almacenamientoSeleccionado);
            }
            else if (!VerificarSeleccionRadioButton())
            {
                MessageBox.Show("SOY OPCION 2");
                videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                playStation = new PlayStation(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado, controlSeleccionado);
            }
            else
            {
                MessageBox.Show("SOY OPCION 3");
                videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                playStation = new PlayStation(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado, controlSeleccionado, true, VerificarSeleccionRadioButton());
            }
            
            // Cerrar el formulario con resultado OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool VerificarSeleccionRadioButton()
        {
            return this.rbtnPsPlusSi.Checked;
        }

        private void VerificarSeleccionControl()
        {
            if (this.cmbControles.SelectedItem != null)
            {
                this.controlSeleccionado = (int)this.cmbControles.SelectedItem;
            }
        }

        private void VerificarSeleccionVideojuegoDadoControles()
        {
            if (this.cmbControles.SelectedItem != null)
            {
                if (this.cmbVideojuegos.SelectedIndex == -1)
                {
                    throw new VideojuegoNoSeleccionadoException();
                }
            }
        }
    }
}
