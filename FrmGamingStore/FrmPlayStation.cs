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
using Excepciones;

namespace FrmGamingStore
{
    /// <summary>
    /// Formulario para agregar una consola PlayStation.
    /// </summary>
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

        /// <summary>
        /// Constructor sobrecargado.
        /// </summary>
        /// <param name="playStation">Consola PlayStation a modificar.</param>
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

        /// <summary>
        /// Maneja el evento click del botón Aceptar para agregar una consola PlayStation.
        /// Verifica la selección del modelo, almacenamiento y la presencia de un videojuego, controles y ps plus opcionales.
        /// </summary>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                base.VerificarSeleccionModelo();
                base.VerificarSeleccionAlmacenamiento();
                this.VerificarSeleccionVideojuego();
                this.VerificarSeleccionControl();
                this.VerificarSeleccionPsPlus();
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
            catch (ControlNoSeleccionadoException)
            {
                MessageBox.Show("Por favor, seleccione cuántos controles quiere.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crea una nueva instancia de PlayStation con las selecciones realizadas
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

        private void VerificarSeleccionPsPlus()
        {
            if (this.VerificarSeleccionRadioButton() && this.cmbControles.SelectedItem == null)
            {
                throw new ControlNoSeleccionadoException();
            }
        }

        /// <summary>
        /// Verifica si se ha seleccionado un videojuego cuando se elige un control.
        /// </summary>
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
