﻿using FrmGamingStore;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrmGamingStore
{
    public partial class FrmXbox : FrmConsola
    {
        private Consola xbox;
        private string? videojuegoSeleccionado;
        private int almacenamientoNubeSeleccionado;

        public FrmXbox()
        {
            InitializeComponent();

            this.cmbAlmacenamientoNube.Items.Add("No agregar");
            this.cmbAlmacenamientoNube.Items.Add("100 GB");
            this.cmbAlmacenamientoNube.Items.Add("500 GB");
            this.cmbAlmacenamientoNube.Items.Add("1000 GB");

            Array arrayModelos = Enum.GetValues(typeof(EModelosXbox));
            Array arrayVideojuegos = Enum.GetValues(typeof(EVideojuegosXbox));

            foreach (EModelosXbox modelo in arrayModelos)
            {
                this.cmbModelos.Items.Add(modelo);
            }

            foreach (EVideojuegosXbox videojuego in arrayVideojuegos)
            {
                this.cmbVideojuegos.Items.Add(videojuego);
            }
        }

        public FrmXbox(Consola xbox) : this()
        {
            string auxAlmacenamiento = $"{xbox.Almacenamiento} GB";
            cmbModelos.Text = xbox.Modelo.ToString();
            cmbAlmacenamiento.Text = auxAlmacenamiento;
            cmbModelos.Enabled = false;
            cmbAlmacenamiento.Enabled = false;
        }

        public override Consola ConsolaDelFormulario
        {
            get { return xbox; }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar selección de modelo
                base.VerificarSeleccionModelo();
                // Verificar selección de almacenamiento
                base.VerificarSeleccionAlmacenamiento();
                // Verificar selección de videojuego si se seleccionó alguna opcion de almacenamietno nube
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

            if (this.cmbAlmacenamientoNube.SelectedIndex == -1 && this.cmbVideojuegos.SelectedIndex == -1)
            {
                this.xbox = new Xbox(modeloSeleccionado, almacenamientoSeleccionado);
            }
            else if (this.cmbAlmacenamientoNube.SelectedIndex == -1)
            {
                this.videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                this.xbox = new Xbox(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado);
            }
            else
            {
                this.videojuegoSeleccionado = this.cmbVideojuegos.SelectedItem.ToString();
                this.xbox = new Xbox(modeloSeleccionado, almacenamientoSeleccionado, videojuegoSeleccionado, almacenamientoNubeSeleccionado, VerificarSeleccionRadioButton());
            }

            // Cerrar el formulario con resultado OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbAlmacenamientoNube_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbAlmacenamientoNube.SelectedItem.ToString() != "No agregar")
            {
                this.MostrarXboxLiveGold();
            }
            else
            {
                this.OcultarXboxLiveGold();
            }
        }

        private void MostrarXboxLiveGold()
        {
            this.lblXboxLiveGold.Visible = true;
            this.rbtnXboxLiveGoldSi.Visible = true;
            this.rbtnXboxLiveGoldNo.Visible = true;
        }

        private void OcultarXboxLiveGold()
        {
            this.lblXboxLiveGold.Visible = false;
            this.rbtnXboxLiveGoldSi.Visible = false;
            this.rbtnXboxLiveGoldNo.Visible = false;
        }

        private bool VerificarSeleccionRadioButton()
        {
            return this.rbtnXboxLiveGoldSi.Checked;
        }

        protected override void VerificarSeleccionVideojuego()
        {
            if (this.cmbAlmacenamientoNube.SelectedItem != null && this.cmbAlmacenamientoNube.SelectedItem.ToString() != "No agregar")
            {
                this.almacenamientoNubeSeleccionado = int.Parse(this.cmbAlmacenamientoNube.SelectedItem.ToString().Replace(" GB", ""));
                if (this.cmbVideojuegos.SelectedIndex == -1)
                {
                    throw new VideojuegoNoSeleccionadoException();
                }
            }
        }
    }
}
