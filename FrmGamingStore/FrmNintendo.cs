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
    public partial class FrmNintendo : FrmConsola
    {
        private Nintendo nintendo;
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

        public override Consola ConsolaDelFormulario
        {
            get { return nintendo; }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar selección de modelo
                base.VerificarSeleccionModelo();
                // Verificar selección de almacenamiento
                base.VerificarSeleccionAlmacenamiento();
                // Verificar selección de videojuego si se seleccionó alguna opcion de perifericos
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

            if (this.cmbPerifericos.SelectedIndex == -1 && this.cmbVideojuegos.SelectedIndex == -1)
            {
                MessageBox.Show("SOY OPCION 1");
                nintendo = new Nintendo(modeloSeleccionado, almacenamientoSeleccionado);
            }
            else if (this.cmbPerifericos.SelectedIndex == -1 && this.cmbVideojuegos.SelectedIndex != -1)
            {
                MessageBox.Show("SOY OPCION 2");
                videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                nintendo = new Nintendo(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado);
            }
            else
            {
                MessageBox.Show("SOY OPCION 3");
                videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                perifericoSeleccionado = this.cmbPerifericos.SelectedItem.ToString();
                nintendo = new Nintendo(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado, perifericoSeleccionado);
            }

            // Cerrar el formulario con resultado OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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
