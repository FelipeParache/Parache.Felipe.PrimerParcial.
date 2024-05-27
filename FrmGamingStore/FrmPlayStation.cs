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

            for (int i = 1; i < 5; i++)
            {
                this.cmbControles.Items.Add(i);
            }
        }

        public FrmPlayStation(Consola playStation) : this()
        {
            string auxAlmacenamiento = $"{playStation.Almacenamiento} GB";
            cmbModelos.Text = playStation.Modelo.ToString();
            cmbAlmacenamiento.Text = auxAlmacenamiento;
            cmbModelos.Enabled = false;
            cmbAlmacenamiento.Enabled = false;
        }

        public override Consola ConsolaDelFormulario
        {
            get { return playStation; }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar selección de modelo
                base.VerificarSeleccionModelo();
                // Verificar selección de almacenamiento
                base.VerificarSeleccionAlmacenamiento();
                // Verificar selección de videojuego si se seleccionó alguna opcion de controles
                this.VerificarSeleccionVideojuego();
                // Verificar selección de control
                this.VerificarSeleccionControl();
            }
            catch (ModeloNoSeleccionadoException)
            {
                MessageBox.Show("Por favor, seleccione un modelo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (AlmacenamientoNoSeleccionadoException)
            {
                MessageBox.Show("Por favor, seleccione una opción de almacenamiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (VideojuegoNoSeleccionadoException)
            {
                MessageBox.Show("Por favor, seleccione un videojuego.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cmbControles.SelectedIndex == -1 && this.cmbVideojuegos.SelectedIndex == -1)
            {
                playStation = new PlayStation(modeloSeleccionado, almacenamientoSeleccionado);
            }
            else if (!VerificarSeleccionRadioButton())
            {
                videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                playStation = new PlayStation(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado, controlSeleccionado);
            }
            else
            {
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

        protected override void VerificarSeleccionVideojuego()
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
