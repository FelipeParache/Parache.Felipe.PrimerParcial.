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
            cmbAlmacenamiento = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblModelo.Location = new Point(34, 64);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(151, 25);
            lblModelo.TabIndex = 0;
            lblModelo.Text = "Elija un modelo:";
            // 
            // cmbModelos
            // 
            cmbModelos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelos.FormattingEnabled = true;
            cmbModelos.Location = new Point(191, 61);
            cmbModelos.Name = "cmbModelos";
            cmbModelos.Size = new Size(151, 28);
            cmbModelos.TabIndex = 1;
            // 
            // lblAlmacenamiento
            // 
            lblAlmacenamiento.AutoSize = true;
            lblAlmacenamiento.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAlmacenamiento.Location = new Point(22, 216);
            lblAlmacenamiento.Name = "lblAlmacenamiento";
            lblAlmacenamiento.Size = new Size(163, 25);
            lblAlmacenamiento.TabIndex = 2;
            lblAlmacenamiento.Text = "Almacenamiento:";
            // 
            // cmbAlmacenamiento
            // 
            cmbAlmacenamiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlmacenamiento.FormattingEnabled = true;
            cmbAlmacenamiento.Location = new Point(191, 216);
            cmbAlmacenamiento.Name = "cmbAlmacenamiento";
            cmbAlmacenamiento.Size = new Size(151, 28);
            cmbAlmacenamiento.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 377);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(158, 61);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(200, 377);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(158, 61);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmConsola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbAlmacenamiento);
            Controls.Add(lblAlmacenamiento);
            Controls.Add(cmbModelos);
            Controls.Add(lblModelo);
            Name = "FrmConsola";
            Text = "Elija su consola";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblModelo;
        private Label lblAlmacenamiento;
        private Button btnAceptar;
        private Button btnCancelar;
        protected ComboBox cmbModelos;
        protected ComboBox cmbAlmacenamiento;
    }
}