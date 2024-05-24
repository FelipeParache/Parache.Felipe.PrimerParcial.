using FrmGamingStore;
using Entidades;
namespace FrmGamingStore
{
    public partial class FrmGamingStore : Form
    {
        GamingStore gamingStore;

        public FrmGamingStore()
        {
            InitializeComponent();
            gamingStore = new GamingStore();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnPlayStation_Click(object sender, EventArgs e)
        {
            FrmConsola frmPlayStation = new FrmPlayStation();

            if (frmPlayStation.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void btnNintendo_Click(object sender, EventArgs e)
        {
            FrmConsola frmNintendo = new FrmNintendo();

            if (frmNintendo.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void btnXbox_Click(object sender, EventArgs e)
        {
            FrmConsola frmXbox = new FrmXbox();

            if (frmXbox.ShowDialog() == DialogResult.OK)
            {
                Consola xbox = frmXbox.ConsolaDelFormulario;
                MessageBox.Show(xbox.ToString());

                if (this.gamingStore != xbox)
                {
                    MessageBox.Show("La consola no está en la lista, agregando...");
                    this.gamingStore += xbox;
                }
                else
                {
                    MessageBox.Show("La consola ya se encuentra en la lista, no será agregada.");
                }
                this.ActualizarVisor();
            }
        }

        private void ActualizarVisor()
        {
            this.lstConsolas.Items.Clear();

            foreach (Consola consola in this.gamingStore.listaConsolas)
            {
                lstConsolas.Items.Add(consola.ToString());
            }
        }
    }
}
