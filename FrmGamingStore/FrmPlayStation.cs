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
        private PlayStation playStation;

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
                this.cmbAlmacenamiento.Items.Add(videojuego);
            }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            playStation = new PlayStation((EModelosPlayStation)this.cmbModelos.SelectedItem, 1000, true, 4, (EVideojuegosPlayStation)this.cmbAlmacenamiento.SelectedItem, true);
            MessageBox.Show(playStation.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
