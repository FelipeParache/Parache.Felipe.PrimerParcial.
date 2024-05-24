using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FrmGamingStore
{
    partial class FrmConsola
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblModelo = new Label();
            cmbModelos = new ComboBox();
            lblAlmacenamiento = new Label();
            cmbVideojuegos = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            lblVideojuegos = new Label();
            cmbAlmacenamiento = new ComboBox();
            SuspendLayout();
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblModelo.Location = new Point(64, 75);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(91, 29);
            lblModelo.TabIndex = 0;
            lblModelo.Text = "Modelo:";
            // 
            // cmbModelos
            // 
            cmbModelos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelos.FormattingEnabled = true;
            cmbModelos.Location = new Point(295, 78);
            cmbModelos.Name = "cmbModelos";
            cmbModelos.Size = new Size(180, 28);
            cmbModelos.TabIndex = 1;
            // 
            // lblAlmacenamiento
            // 
            lblAlmacenamiento.AutoSize = true;
            lblAlmacenamiento.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblAlmacenamiento.Location = new Point(64, 160);
            lblAlmacenamiento.Name = "lblAlmacenamiento";
            lblAlmacenamiento.Size = new Size(187, 29);
            lblAlmacenamiento.TabIndex = 2;
            lblAlmacenamiento.Text = "Almacenamiento:";
            // 
            // cmbVideojuegos
            // 
            cmbVideojuegos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVideojuegos.FormattingEnabled = true;
            cmbVideojuegos.Location = new Point(295, 244);
            cmbVideojuegos.Name = "cmbVideojuegos";
            cmbVideojuegos.Size = new Size(180, 28);
            cmbVideojuegos.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(64, 528);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(180, 78);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(295, 528);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 78);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblVideojuegos
            // 
            lblVideojuegos.AutoSize = true;
            lblVideojuegos.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblVideojuegos.Location = new Point(64, 241);
            lblVideojuegos.Name = "lblVideojuegos";
            lblVideojuegos.Size = new Size(127, 29);
            lblVideojuegos.TabIndex = 6;
            lblVideojuegos.Text = "Videojuego:";
            // 
            // cmbAlmacenamiento
            // 
            cmbAlmacenamiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlmacenamiento.FormattingEnabled = true;
            cmbAlmacenamiento.Location = new Point(295, 163);
            cmbAlmacenamiento.Name = "cmbAlmacenamiento";
            cmbAlmacenamiento.Size = new Size(180, 28);
            cmbAlmacenamiento.TabIndex = 7;
            // 
            // FrmConsola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 630);
            Controls.Add(cmbAlmacenamiento);
            Controls.Add(lblVideojuegos);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbVideojuegos);
            Controls.Add(lblAlmacenamiento);
            Controls.Add(cmbModelos);
            Controls.Add(lblModelo);
            Name = "FrmConsola";
            Text = "FrmConsola";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblModelo;
        private Label lblAlmacenamiento;
        protected ComboBox cmbModelos;
        protected ComboBox cmbVideojuegos;
        protected Button btnAceptar;
        protected Button btnCancelar;
        private Label lblVideojuegos;
        protected ComboBox cmbAlmacenamiento;
    }
}