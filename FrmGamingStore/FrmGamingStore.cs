using FrmGamingStore;
using Entidades;
using ADO;
namespace FrmGamingStore
{
    /// <summary>
    /// Formulario principal para gestionar la tienda de videojuegos.
    /// </summary>
    public partial class FrmGamingStore : Form
    {
        private AccesoDatos ado;
        private GamingStore gamingStore;
        private Usuario? usuario;
        private string rutaDataConsolas;
        private Action actualizarVisorDelegate;
        private Task establecerConexionBdd;
        public event Action consolaYaAgregadaHandler;

        public FrmGamingStore()
        {
            InitializeComponent();
            this.ado = new AccesoDatos();
            this.establecerConexionBdd = new Task(this.ado.EstablecerConexion);
            this.gamingStore = new GamingStore();
            this.StartPosition = FormStartPosition.CenterScreen;

            string archivoData = @"\Archivos";
            this.rutaDataConsolas = ManejadorArchivos.ObtenerRuta(Environment.CurrentDirectory, archivoData);

            this.actualizarVisorDelegate = () =>
            {
                this.lstConsolas.Items.Clear();
                foreach (Consola consola in this.gamingStore.listaConsolas)
                {
                    this.lstConsolas.Items.Add(consola.MostrarInformacion());
                }
            };
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
            this.consolaYaAgregadaHandler += this.OnConsolaYaAgregada;

            if (usuario.Perfil == "vendedor")
            {
                lblMarca.Text = "ELIJA UN ARCHIVO";
                btnPlayStation.Visible = false;
                btnNintendo.Visible = false;
                btnXbox.Visible = false;
                btnGuardar.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
            }
            else if (usuario.Perfil == "supervisor")
            {
                btnEliminar.Visible = false;
            }
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
                    int filasAfectadas = this.ado.AgregarConsola(playStation, playStation.ObtenerTipo());
                    this.MostrarMensajeFilasAfectadas(filasAfectadas);
                }
                else
                {
                    this.consolaYaAgregadaHandler.Invoke();
                }
                this.actualizarVisorDelegate.Invoke();
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
                    int filasAfectadas = this.ado.AgregarConsola(nintendo, nintendo.ObtenerTipo());
                    this.MostrarMensajeFilasAfectadas(filasAfectadas);
                }
                else
                {
                    this.consolaYaAgregadaHandler.Invoke();
                }
                this.actualizarVisorDelegate.Invoke();
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
                    int filasAfectadas = this.ado.AgregarConsola(xbox, xbox.ObtenerTipo());
                    this.MostrarMensajeFilasAfectadas(filasAfectadas);
                }
                else
                {
                    this.consolaYaAgregadaHandler.Invoke();
                }
                this.actualizarVisorDelegate.Invoke();
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
                    Consola consolaModificada = frmConsola.ConsolaDelFormulario;
                    consolaModificada.Id = consolaSeleccionada.Id;

                    if (this.gamingStore != consolaModificada)
                    {
                        int filasAfectadas = ado.ModificarConsola(consolaModificada, consolaModificada.ObtenerTipo());

                        if (filasAfectadas > 0)
                        {
                            this.gamingStore.listaConsolas[indiceSeleccionado] = consolaModificada;
                            this.actualizarVisorDelegate.Invoke();

                            MessageBox.Show("Consola modificada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (filasAfectadas != 0)
                        {
                            MessageBox.Show("Error al modificar la consola en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (filasAfectadas == 0)
                        {
                            this.gamingStore.listaConsolas[indiceSeleccionado] = consolaModificada;
                            this.actualizarVisorDelegate.Invoke();
                        }
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
                Consola consolaSeleccionada = this.gamingStore.listaConsolas[indiceSeleccionado];
                int idConsola = consolaSeleccionada.Id;
                string tipoConsola = consolaSeleccionada.ObtenerTipo();

                int filasAfectadas = this.ado.EliminarConsola(idConsola, tipoConsola);

                if (filasAfectadas > 0)
                {
                    this.gamingStore -= indiceSeleccionado;
                    this.actualizarVisorDelegate.Invoke();

                    MessageBox.Show("Consola eliminada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (filasAfectadas != 0)
                {
                    MessageBox.Show("Error al eliminar la consola", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (filasAfectadas == 0)
                {
                    this.gamingStore -= indiceSeleccionado;
                    this.actualizarVisorDelegate.Invoke();
                }
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

            this.actualizarVisorDelegate.Invoke();
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

            this.actualizarVisorDelegate.Invoke();
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
        /// Abre un archivo JSON de consolas y carga los datos en la tienda de juegos.
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            ofdConsolas.Title = "Elige un archivo de consolas para abrir";
            ofdConsolas.InitialDirectory = rutaDataConsolas;
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
                            this.actualizarVisorDelegate.Invoke();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                sfdConsolas.Filter = "Archivo JSON (*.json) | *.json";
                if (sfdConsolas.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = sfdConsolas.FileName;
                    ManejadorArchivos.SerializarConsolasJSON(rutaArchivo, this.gamingStore.listaConsolas);
                    MessageBox.Show("Archivo guardado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre la base de datos y carga las consolas en la tienda de juegos.
        /// </summary>
        private async void btnAbrirSql_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.establecerConexionBdd.Status == TaskStatus.Created)
                {
                    MessageBox.Show("Conectando con la base de datos, espere unos segundos...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.establecerConexionBdd.Start();
                    Thread.Sleep(1000);
                    MessageBox.Show("¡Conexión establecida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡Conexión establecida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectarse con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                List<Consola> consolas = new List<Consola>();

                List<PlayStation> consolasPS;
                List<Nintendo> consolasNN;
                List<Xbox> consolasXB;

                try
                {
                    consolasPS = this.ado.ObtenerPlayStation();
                    consolasNN = this.ado.ObtenerNintendo();
                    consolasXB = this.ado.ObtenerXbox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener consolas desde la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                consolas.AddRange(consolasPS);
                consolas.AddRange(consolasNN);
                consolas.AddRange(consolasXB);

                if (consolas == null || consolas.Count == 0)
                {
                    MessageBox.Show("No se encontraron consolas para cargar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.gamingStore != null)
                {
                    this.gamingStore.listaConsolas = consolas;
                    this.actualizarVisorDelegate.Invoke();
                }
                else
                {
                    MessageBox.Show("Error: gamingStore no está inicializado.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al abrir el archivo de consolas: {ex.Message}");
            }
        }
        
        private void MostrarMensajeFilasAfectadas(int filasAfectadas)
        {
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Consola agregada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar la consola", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnConsolaYaAgregada()
        {
            MessageBox.Show("La consola ya se encuentra en la lista", "Error al agregar consola", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
