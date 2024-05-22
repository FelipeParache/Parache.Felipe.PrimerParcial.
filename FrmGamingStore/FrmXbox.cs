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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrmGamingStore
{
    public partial class FrmXbox : FrmConsola
    {
        private Xbox xbox;

        public FrmXbox()
        {
            InitializeComponent();
            Array arrayModelos = Enum.GetValues(typeof(EModelosXbox));
            Array arrayVideojuegos = Enum.GetValues(typeof(EVideojuegosXbox));

            foreach (EModelosXbox modelo in arrayModelos)
            {
                this.cmbModelos.Items.Add(modelo);
            }

            foreach (EVideojuegosXbox videojuego in arrayVideojuegos)
            {
                this.cmbAlmacenamiento.Items.Add(videojuego);
            }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            xbox = new Xbox((EModelosXbox)this.cmbModelos.SelectedItem, 1000, 2000, (EVideojuegosXbox)this.cmbAlmacenamiento.SelectedItem, true);
            MessageBox.Show(xbox.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
