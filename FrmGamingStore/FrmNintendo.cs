using FrmGamingStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmGamingStore
{
    /// <summary>
    /// Formulario para agregar una consola Nintendo.
    /// </summary>
    public partial class FrmNintendo : FrmConsola
    {
        private Nintendo? nintendo;
        private string? videojuegoSeleccionado;
        private string? perifericoSeleccionado;

        public FrmNintendo()
        {
            InitializeComponent();

            Array arrayModelos = Enum.GetValues(typeof(EModelosNintendo));
            Array arrayVideojuegos = Enum.GetValues(typeof(EVideojuegosNintendo));
            Array arrayPerifericos = Enum.GetValues(typeof(EPerifericosNintendo));

            foreach (EModelosNintendo modelo in arrayModelos)
            {
                this.cmbModelos.Items.Add(modelo);
            }

            foreach (EVideojuegosNintendo videojuego in arrayVideojuegos)
            {
                this.cmbVideojuegos.Items.Add(videojuego);
            }

            foreach (EPerifericosNintendo periferico in arrayPerifericos)
            {
                this.cmbPerifericos.Items.Add(periferico);
            }
        }

        /// <summary>
        /// Constructor sobrecargado.
        /// </summary>
        /// <param name="nintendo">Consola Nintendo a modificar.</param>
        public FrmNintendo(Consola nintendo) : this()
        {
            string auxAlmacenamiento = $"{nintendo.Almacenamiento} GB";
            cmbModelos.Text = nintendo.Modelo.ToString();
            cmbAlmacenamiento.Text = auxAlmacenamiento;
            cmbModelos.Enabled = false;
            cmbAlmacenamiento.Enabled = false;
        }

        public override Consola ConsolaDelFormulario
        {
            get { return nintendo; }
        }

        /// <summary>
        /// Maneja el evento click del botón Aceptar para agregar una consola Nintendo.
        /// Verifica la selección del modelo, almacenamiento y la presencia de periféricos y videojuegos opcionales.
        /// </summary>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                base.VerificarSeleccionModelo();
                base.VerificarSeleccionAlmacenamiento();
                this.VerificarSeleccionVideojuego();
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

            // Crea una nueva instancia de Nintendo con las selecciones realizadas
            if (this.cmbPerifericos.SelectedIndex == -1 && this.cmbVideojuegos.SelectedIndex == -1)
            {
                nintendo = new Nintendo(modeloSeleccionado, almacenamientoSeleccionado);
            }
            else if (this.cmbPerifericos.SelectedIndex == -1 && this.cmbVideojuegos.SelectedIndex != -1)
            {
                videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                nintendo = new Nintendo(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado);
            }
            else
            {
                videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                perifericoSeleccionado = this.cmbPerifericos.SelectedItem.ToString();
                nintendo = new Nintendo(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado, perifericoSeleccionado);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Verifica si se ha seleccionado un videojuego cuando se elige un periférico.
        /// </summary>
        protected override void VerificarSeleccionVideojuego()
        {
            if (this.cmbPerifericos.SelectedItem != null)
            {
                if (this.cmbVideojuegos.SelectedIndex == -1)
                {
                    throw new VideojuegoNoSeleccionadoException();
                }
            }
        }
    }
}
