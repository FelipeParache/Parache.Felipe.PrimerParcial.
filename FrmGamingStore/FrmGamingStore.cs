using FrmGamingStore;
using Entidades;
namespace FrmGamingStore
{
    public partial class FrmGamingStore : Form
    {
        protected string consolas;
        GamingStore gamingStore;

        public FrmGamingStore()
        {
            InitializeComponent();
            gamingStore = new GamingStore();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.consolas = "";
        }

        private void btnPlayStation_Click(object sender, EventArgs e)
        {
            FrmConsola frmPlayStation = new FrmPlayStation();

            if (frmPlayStation.ShowDialog() == DialogResult.OK)
            {
                this.lstConsolas.Text = this.consolas;
            }
        }

        private void btnNintendo_Click(object sender, EventArgs e)
        {
            FrmConsola frmNintendo = new FrmNintendo();

            if (frmNintendo.ShowDialog() == DialogResult.OK)
            {
                this.lstConsolas.Text = this.consolas;
            }
        }

        private void btnXbox_Click(object sender, EventArgs e)
        {
            FrmConsola frmXbox = new FrmXbox();

            if (frmXbox.ShowDialog() == DialogResult.OK)
            {
                this.lstConsolas.Text = this.consolas;
            }
        }
    }
}
