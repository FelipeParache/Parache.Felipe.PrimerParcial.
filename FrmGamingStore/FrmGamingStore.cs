using FrmGamingStore;
using Entidades;
namespace FrmGamingStore
{
    public partial class FrmGamingStore : Form
    {
        private GamingStore gamingStore;
        private Usuario? usuario;

        public FrmGamingStore()
        {
            InitializeComponent();
            this.gamingStore = new GamingStore();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public FrmGamingStore(Usuario usuario) : this()
        {
            this.usuario = usuario;
        }

        private void FrmGamingStore_Load(object sender, EventArgs e)
        {
            MessageBox.Show("¡Bienvenido a GamingStore!");
            this.lblUsuarioFecha.Text = $"{DateTime.Now.ToString().Substring(0, 9)} Usuario: {usuario}";

        }

        private void btnPlayStation_Click(object sender, EventArgs e)
        {
            FrmConsola frmPlayStation = new FrmPlayStation();

            if (frmPlayStation.ShowDialog() == DialogResult.OK)
            {
                Consola playStation = frmPlayStation.ConsolaDelFormulario;

                if (this.gamingStore != playStation)
                {
                    MessageBox.Show("La consola no está en la lista, agregando...");
                    this.gamingStore += playStation;
                }
                else
                {
                    MessageBox.Show("La consola ya se encuentra en la lista, no será agregada.");
                }
                this.ActualizarVisor();
            }
        }

        private void btnNintendo_Click(object sender, EventArgs e)
        {
            FrmConsola frmNintendo = new FrmNintendo();

            if (frmNintendo.ShowDialog() == DialogResult.OK)
            {
                Consola nintendo = frmNintendo.ConsolaDelFormulario;

                if (this.gamingStore != nintendo)
                {
                    MessageBox.Show("La consola no está en la lista, agregando...");
                    this.gamingStore += nintendo;
                }
                else
                {
                    MessageBox.Show("La consola ya se encuentra en la lista, no será agregada.");
                }
                this.ActualizarVisor();
            }
        }

        private void btnXbox_Click(object sender, EventArgs e)
        {
            FrmConsola frmXbox = new FrmXbox();

            if (frmXbox.ShowDialog() == DialogResult.OK)
            {
                Consola xbox = frmXbox.ConsolaDelFormulario;

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Obtengo el indice del producto seleccionado en lstConsolas
            int indiceSeleccionado = lstConsolas.SelectedIndex;
            if (indiceSeleccionado >= 0 && indiceSeleccionado < gamingStore.listaConsolas.Count)
            {
                // Obtengo el producto seleccionado y creo una instancia del heredero de FrmConsola correspondiente 
                Consola consolaSeleccionada = gamingStore.listaConsolas[indiceSeleccionado];

                FrmConsola? frmConsola = null;

                if (Enum.IsDefined(typeof(EModelosPlayStation), consolaSeleccionada.Modelo))
                {
                    frmConsola = new FrmPlayStation(consolaSeleccionada);
                }
                else if (Enum.IsDefined(typeof(EModelosNintendo), consolaSeleccionada.Modelo))
                {
                    frmConsola = new FrmNintendo(consolaSeleccionada);
                }
                else if (Enum.IsDefined(typeof(EModelosXbox), consolaSeleccionada.Modelo))
                {
                    frmConsola = new FrmXbox(consolaSeleccionada);
                }

                DialogResult resultado = frmConsola.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    this.gamingStore.listaConsolas[indiceSeleccionado] = frmConsola.ConsolaDelFormulario;
                    this.ActualizarVisor();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una consola de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerEnDetalle_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = lstConsolas.SelectedIndex;
            if (indiceSeleccionado >= 0 && indiceSeleccionado < gamingStore.listaConsolas.Count)
            {
                Consola consolaSeleccionada = gamingStore.listaConsolas[indiceSeleccionado];
                MessageBox.Show($"{consolaSeleccionada.ToString()}");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una consola de la lista para ver en detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = lstConsolas.SelectedIndex;
            if (indiceSeleccionado >= 0 && indiceSeleccionado < gamingStore.listaConsolas.Count)
            {
                this.gamingStore.listaConsolas.RemoveAt(indiceSeleccionado);
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una consola de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rbtnAscendenteAño_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnAscendenteAño.Checked)
            {
                this.gamingStore.OrdenarPorAñoModelo(true);
            }
            else
            {
                this.gamingStore.OrdenarPorAñoModelo(false);
            }

            this.ActualizarVisor();
        }

        private void rbtnAscendenteMarca_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnAscendenteMarca.Checked)
            {
                this.gamingStore.OrdenarPorClase(true);
            }
            else
            {
                this.gamingStore.OrdenarPorClase(false);
            }

            this.ActualizarVisor();
        }

        private void FrmGamingStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quieres salir?", "Saliendo de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ActualizarVisor()
        {
            this.lstConsolas.Items.Clear();
            foreach (Consola consola in this.gamingStore.listaConsolas)
            {
                this.lstConsolas.Items.Add(consola.MostrarInformacionResumida());
            }
        }

        private void AbrirArchivoConsolas()
        {
            ofdConsolas.Title = "Elige un archivo de consolas para abrir";
            ofdConsolas.InitialDirectory = @"C:\Users\soyfe\source\repos\Parache.Felipe.PrimerParcial\Colecciones\Archivos\";
            ofdConsolas.FileName = "CONSOLAS_DATA.json";
            ofdConsolas.Filter = "JSON-File | *.json";

            if (ofdConsolas.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofdConsolas.FileName))
                {
                    List<Consola>? consolas = ManejadorArchivos.DeserializarConsolasJSON(ofdConsolas.FileName);
                    if (consolas is not null)
                    {
                        if (this.gamingStore != null)
                        {
                            this.gamingStore.listaConsolas = consolas;
                            this.ActualizarVisor();
                        }
                        else
                        {
                            MessageBox.Show("Error: gamingStore no está inicializado.");
                        }
                    }
                }
            }
        }

        private void GuardarArchivoConsolas()
        {
            try
            {
                sfdConsolas.Filter = "Archivo JSON (*.json) | *.json";
                if (sfdConsolas.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = sfdConsolas.FileName;
                    ManejadorArchivos.SerializarConsolasJSON(rutaArchivo, this.gamingStore.listaConsolas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}");
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            foreach (Consola consola in this.gamingStore.listaConsolas)
            {
                MessageBox.Show($"{consola}");
            }
            this.AbrirArchivoConsolas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarArchivoConsolas();
        }
    }
}
