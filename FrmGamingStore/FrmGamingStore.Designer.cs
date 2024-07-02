using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;
using FrmGamingStore.Properties;

namespace FrmGamingStore
{
    partial class FrmGamingStore
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPlayStation = new Button();
            btnNintendo = new Button();
            btnXbox = new Button();
            lblMarca = new Label();
            lstConsolas = new ListBox();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnVerEnDetalle = new Button();
            grpOrdenarPorAño = new GroupBox();
            rbtnDescendenteAño = new RadioButton();
            rbtnAscendenteAño = new RadioButton();
            grpOrdenarPorMarca = new GroupBox();
            rbtnDescendenteMarca = new RadioButton();
            rbtnAscendenteMarca = new RadioButton();
            lblUsuarioFecha = new Label();
            ofdConsolas = new OpenFileDialog();
            sfdConsolas = new SaveFileDialog();
            btnGuardar = new Button();
            btnAbrirJson = new Button();
            btnAbrirSql = new Button();
            grpOrdenarPorAño.SuspendLayout();
            grpOrdenarPorMarca.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlayStation
            // 
            btnPlayStation.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPlayStation.Location = new Point(12, 158);
            btnPlayStation.Name = "btnPlayStation";
            btnPlayStation.Size = new Size(135, 54);
            btnPlayStation.TabIndex = 0;
            btnPlayStation.Text = "PlayStation";
            btnPlayStation.UseVisualStyleBackColor = true;
            btnPlayStation.Click += btnPlayStation_Click;
            // 
            // btnNintendo
            // 
            btnNintendo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnNintendo.Location = new Point(188, 158);
            btnNintendo.Name = "btnNintendo";
            btnNintendo.Size = new Size(135, 54);
            btnNintendo.TabIndex = 1;
            btnNintendo.Text = "Nintendo";
            btnNintendo.UseVisualStyleBackColor = true;
            btnNintendo.Click += btnNintendo_Click;
            // 
            // btnXbox
            // 
            btnXbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnXbox.Location = new Point(363, 158);
            btnXbox.Name = "btnXbox";
            btnXbox.Size = new Size(135, 54);
            btnXbox.TabIndex = 2;
            btnXbox.Text = "Xbox";
            btnXbox.UseVisualStyleBackColor = true;
            btnXbox.Click += btnXbox_Click;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.BackColor = Color.Transparent;
            lblMarca.Font = new Font("Franklin Gothic Medium", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(86, 101);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(348, 36);
            lblMarca.TabIndex = 3;
            lblMarca.Text = "SELECCIONE UNA CONSOLA";
            // 
            // lstConsolas
            // 
            lstConsolas.FormattingEnabled = true;
            lstConsolas.ItemHeight = 20;
            lstConsolas.Location = new Point(12, 218);
            lstConsolas.Name = "lstConsolas";
            lstConsolas.Size = new Size(486, 324);
            lstConsolas.TabIndex = 4;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.Location = new Point(12, 548);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(135, 54);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.Location = new Point(363, 548);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(135, 54);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVerEnDetalle
            // 
            btnVerEnDetalle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnVerEnDetalle.Location = new Point(188, 548);
            btnVerEnDetalle.Name = "btnVerEnDetalle";
            btnVerEnDetalle.Size = new Size(135, 54);
            btnVerEnDetalle.TabIndex = 7;
            btnVerEnDetalle.Text = "Ver en detalle";
            btnVerEnDetalle.UseVisualStyleBackColor = true;
            btnVerEnDetalle.Click += btnVerEnDetalle_Click;
            // 
            // grpOrdenarPorAño
            // 
            grpOrdenarPorAño.BackColor = Color.Transparent;
            grpOrdenarPorAño.Controls.Add(rbtnDescendenteAño);
            grpOrdenarPorAño.Controls.Add(rbtnAscendenteAño);
            grpOrdenarPorAño.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpOrdenarPorAño.Location = new Point(12, 608);
            grpOrdenarPorAño.Name = "grpOrdenarPorAño";
            grpOrdenarPorAño.Size = new Size(240, 91);
            grpOrdenarPorAño.TabIndex = 10;
            grpOrdenarPorAño.TabStop = false;
            grpOrdenarPorAño.Text = "Ordenar por año de fabricación";
            // 
            // rbtnDescendenteAño
            // 
            rbtnDescendenteAño.AutoSize = true;
            rbtnDescendenteAño.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbtnDescendenteAño.Location = new Point(6, 58);
            rbtnDescendenteAño.Name = "rbtnDescendenteAño";
            rbtnDescendenteAño.Size = new Size(130, 27);
            rbtnDescendenteAño.TabIndex = 1;
            rbtnDescendenteAño.TabStop = true;
            rbtnDescendenteAño.Text = "Descendente";
            rbtnDescendenteAño.UseVisualStyleBackColor = true;
            // 
            // rbtnAscendenteAño
            // 
            rbtnAscendenteAño.AutoSize = true;
            rbtnAscendenteAño.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbtnAscendenteAño.Location = new Point(6, 26);
            rbtnAscendenteAño.Name = "rbtnAscendenteAño";
            rbtnAscendenteAño.Size = new Size(120, 27);
            rbtnAscendenteAño.TabIndex = 0;
            rbtnAscendenteAño.TabStop = true;
            rbtnAscendenteAño.Text = "Ascendente";
            rbtnAscendenteAño.UseVisualStyleBackColor = true;
            rbtnAscendenteAño.CheckedChanged += rbtnAscendenteAño_CheckedChanged;
            // 
            // grpOrdenarPorMarca
            // 
            grpOrdenarPorMarca.BackColor = Color.Transparent;
            grpOrdenarPorMarca.BackgroundImageLayout = ImageLayout.None;
            grpOrdenarPorMarca.Controls.Add(rbtnDescendenteMarca);
            grpOrdenarPorMarca.Controls.Add(rbtnAscendenteMarca);
            grpOrdenarPorMarca.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpOrdenarPorMarca.ForeColor = Color.Black;
            grpOrdenarPorMarca.Location = new Point(258, 608);
            grpOrdenarPorMarca.Name = "grpOrdenarPorMarca";
            grpOrdenarPorMarca.Size = new Size(240, 91);
            grpOrdenarPorMarca.TabIndex = 11;
            grpOrdenarPorMarca.TabStop = false;
            grpOrdenarPorMarca.Text = "Ordenar por marca";
            // 
            // rbtnDescendenteMarca
            // 
            rbtnDescendenteMarca.AutoSize = true;
            rbtnDescendenteMarca.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbtnDescendenteMarca.Location = new Point(6, 58);
            rbtnDescendenteMarca.Name = "rbtnDescendenteMarca";
            rbtnDescendenteMarca.Size = new Size(130, 27);
            rbtnDescendenteMarca.TabIndex = 2;
            rbtnDescendenteMarca.TabStop = true;
            rbtnDescendenteMarca.Text = "Descendente";
            rbtnDescendenteMarca.UseVisualStyleBackColor = true;
            // 
            // rbtnAscendenteMarca
            // 
            rbtnAscendenteMarca.AutoSize = true;
            rbtnAscendenteMarca.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbtnAscendenteMarca.Location = new Point(6, 26);
            rbtnAscendenteMarca.Name = "rbtnAscendenteMarca";
            rbtnAscendenteMarca.Size = new Size(120, 27);
            rbtnAscendenteMarca.TabIndex = 1;
            rbtnAscendenteMarca.TabStop = true;
            rbtnAscendenteMarca.Text = "Ascendente";
            rbtnAscendenteMarca.UseVisualStyleBackColor = true;
            rbtnAscendenteMarca.CheckedChanged += rbtnAscendenteMarca_CheckedChanged;
            // 
            // lblUsuarioFecha
            // 
            lblUsuarioFecha.AutoSize = true;
            lblUsuarioFecha.BackColor = Color.Transparent;
            lblUsuarioFecha.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuarioFecha.ForeColor = Color.White;
            lblUsuarioFecha.Location = new Point(12, 9);
            lblUsuarioFecha.Name = "lblUsuarioFecha";
            lblUsuarioFecha.Size = new Size(113, 20);
            lblUsuarioFecha.TabIndex = 12;
            lblUsuarioFecha.Text = "lblUsuarioFecha";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(328, 53);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(170, 29);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar archivo JSON";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnAbrirJson
            // 
            btnAbrirJson.Location = new Point(152, 53);
            btnAbrirJson.Name = "btnAbrirJson";
            btnAbrirJson.Size = new Size(170, 29);
            btnAbrirJson.TabIndex = 14;
            btnAbrirJson.Text = "Abrir archivo JSON";
            btnAbrirJson.UseVisualStyleBackColor = true;
            btnAbrirJson.Click += btnAbrir_Click;
            // 
            // btnAbrirSql
            // 
            btnAbrirSql.Location = new Point(12, 53);
            btnAbrirSql.Name = "btnAbrirSql";
            btnAbrirSql.Size = new Size(94, 29);
            btnAbrirSql.TabIndex = 15;
            btnAbrirSql.Text = " Abrir SQL";
            btnAbrirSql.UseVisualStyleBackColor = true;
            btnAbrirSql.Click += btnAbrirSql_Click;
            // 
            // FrmGamingStore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.frmGamingStoreBackgroundImage;
            ClientSize = new Size(510, 711);
            Controls.Add(btnAbrirSql);
            Controls.Add(btnAbrirJson);
            Controls.Add(btnGuardar);
            Controls.Add(lblUsuarioFecha);
            Controls.Add(grpOrdenarPorMarca);
            Controls.Add(grpOrdenarPorAño);
            Controls.Add(btnVerEnDetalle);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(lstConsolas);
            Controls.Add(lblMarca);
            Controls.Add(btnXbox);
            Controls.Add(btnNintendo);
            Controls.Add(btnPlayStation);
            Name = "FrmGamingStore";
            Text = "Gaming Store";
            FormClosing += FrmGamingStore_FormClosing;
            Load += FrmGamingStore_Load;
            grpOrdenarPorAño.ResumeLayout(false);
            grpOrdenarPorAño.PerformLayout();
            grpOrdenarPorMarca.ResumeLayout(false);
            grpOrdenarPorMarca.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlayStation;
        private Button btnNintendo;
        private Button btnXbox;
        private Label lblMarca;
        private ListBox lstConsolas;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnVerEnDetalle;
        private GroupBox grpOrdenarPorAño;
        private RadioButton rbtnAscendenteAño;
        private GroupBox grpOrdenarPorMarca;
        private RadioButton rbtnDescendenteAño;
        private RadioButton rbtnDescendenteMarca;
        private RadioButton rbtnAscendenteMarca;
        private Label lblUsuarioFecha;
        private OpenFileDialog ofdConsolas;
        private SaveFileDialog sfdConsolas;
        private Button btnGuardar;
        private Button btnAbrirJson;
        private Button btnAbrirSql;
    }
}