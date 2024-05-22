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

        public FrmNintendo()
        {
            InitializeComponent();

            Array arrayModelos = Enum.GetValues(typeof(EModelosNintendo));
            Array arrayVideojuegos = Enum.GetValues(typeof(EVideojuegosNintendo));

            foreach (EModelosNintendo modelo in arrayModelos)
            {
                this.cmbModelos.Items.Add(modelo);
            }

            foreach (EVideojuegosNintendo videojuego in arrayVideojuegos)
            {
                this.cmbAlmacenamiento.Items.Add(videojuego);
            }
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            nintendo = new Nintendo((EModelosNintendo)this.cmbModelos.SelectedItem, 1000, (EVideojuegosNintendo)this.cmbAlmacenamiento.SelectedItem, new List<EPerifericosNintendo> { EPerifericosNintendo.GafasVR });
            MessageBox.Show(nintendo.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
