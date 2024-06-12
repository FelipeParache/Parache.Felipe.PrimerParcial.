using FrmGamingStore;
using Entidades;
namespace FrmGamingStore
{
    /// <summary>
    /// Formulario principal para gestionar la tienda de videojuegos.
    /// </summary>
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

        /// <summary>
        /// Inicializa una nueva instancia del formulario con un usuario específico.
        /// </summary>
        /// <param name="usuario">El usuario actual.</param>
        public FrmGamingStore(Usuario? usuario) : this()
        {
            this.usuario = usuario;
        }

        private void FrmGamingStore_Load(object sender, EventArgs e)
        {
            this.lblUsuarioFecha.Text = $"{DateTime.Now.ToString().Substring(0, 9)} Usuario: {usuario}";
        }

        /// <summary>
        /// Maneja el evento de click en el botón para agregar una PlayStation.
        /// </summary>
        private void btnPlayStation_Click(object sender, EventArgs e)
        {
            FrmConsola frmPlayStation = new FrmPlayStation();

            if (frmPlayStation.ShowDialog() == DialogResult.OK)
            {
                Consola playStation = frmPlayStation.ConsolaDelFormulario;

                if (this.gamingStore != playStation)
                {
                    this.gamingStore += playStation;
                }
                else
                {
                    MessageBox.Show("La consola ya se encuentra en la lista.", "Error al agregar consola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.ActualizarVisor();
            }
        }

        /// <summary>
        /// Maneja el evento de click en el botón para agregar una Nintendo.
        /// </summary>
        private void btnNintendo_Click(object sender, EventArgs e)
        {
            FrmConsola frmNintendo = new FrmNintendo();

            if (frmNintendo.ShowDialog() == DialogResult.OK)
            {
                Consola nintendo = frmNintendo.ConsolaDelFormulario;

                if (this.gamingStore != nintendo)
                {
                    this.gamingStore += nintendo;
                }
                else
                {
                    MessageBox.Show("La consola ya se encuentra en la lista.", "Error al agregar consola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.ActualizarVisor();
            }
        }

        /// <summary>
        /// Maneja el evento de click en el botón para agregar una Xbox.
        /// </summary>
        private void btnXbox_Click(object sender, EventArgs e)
        {
            FrmConsola frmXbox = new FrmXbox();

            if (frmXbox.ShowDialog() == DialogResult.OK)
            {
                Consola xbox = frmXbox.ConsolaDelFormulario;

                if (this.gamingStore != xbox)
                {
                    this.gamingStore += xbox;
                }
                else
                {
                    MessageBox.Show("La consola ya se encuentra en la lista.", "Error al agregar consola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.ActualizarVisor();
            }
        }

        /// <summary>
        /// Maneja el evento de click en el botón para modificar una consola seleccionada.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = lstConsolas.SelectedIndex;
            if (indiceSeleccionado >= 0 && indiceSeleccionado < gamingStore.listaConsolas.Count)
            {
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
                    if (this.gamingStore != frmConsola.ConsolaDelFormulario)
                    {
                        this.gamingStore.listaConsolas[indiceSeleccionado] = frmConsola.ConsolaDelFormulario;
                        this.ActualizarVisor();
                    }
                    else
                    {
                        MessageBox.Show("La consola ya se encuentra en la lista.", "Error al agregar consola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una consola de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Maneja el evento de click en el botón para ver los detalles de una consola seleccionada.
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de click en el botón para eliminar una consola seleccionada.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = lstConsolas.SelectedIndex;
            if (indiceSeleccionado >= 0 && indiceSeleccionado < gamingStore.listaConsolas.Count)
            {
                this.gamingStore -= indiceSeleccionado;
                this.ActualizarVisor();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una consola de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de estado del radio button para ordenar por año de forma ascendente o descendente.
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de cambio de estado del radio button para ordenar por marca de forma ascendente o descendente.
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de cierre del formulario.
        /// </summary>
        private void FrmGamingStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quieres salir?", "Saliendo de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Actualiza el visor de consolas en el formulario.
        /// </summary>
        private void ActualizarVisor()
        {
            this.lstConsolas.Items.Clear();
            foreach (Consola consola in this.gamingStore.listaConsolas)
            {
                this.lstConsolas.Items.Add(consola.MostrarInformacion());
            }
        }

        /// <summary>
        /// Abre un archivo de consolas y carga los datos en la tienda de juegos.
        /// </summary>
        private void AbrirArchivoConsolas()
        {
            ofdConsolas.Title = "Elige un archivo de consolas para abrir";
            ofdConsolas.InitialDirectory = @"Parache.Felipe.PrimerParcial\Colecciones\Archivos\";
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

        /// <summary>
        /// Guarda los datos de las consolas en un archivo JSON.
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de click en el botón para abrir un archivo de consolas.
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            this.AbrirArchivoConsolas();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón para guardar los datos de las consolas en un archivo JSON.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarArchivoConsolas();
        }
    }
}
