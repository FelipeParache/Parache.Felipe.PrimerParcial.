using FrmGamingStore.Properties;

namespace FrmGamingStore
{
    partial class FrmLogsUsuarios
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
            lstUsuarios = new ListBox();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // lstUsuarios
            // 
            lstUsuarios.FormattingEnabled = true;
            lstUsuarios.ItemHeight = 20;
            lstUsuarios.Location = new Point(12, 65);
            lstUsuarios.Margin = new Padding(3, 4, 3, 4);
            lstUsuarios.Name = "lstUsuarios";
            lstUsuarios.Size = new Size(697, 464);
            lstUsuarios.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(89, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(532, 29);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Nombre - Apellido - Fecha y hora de ingreso";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // FrmLogsUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.frmGamingStoreBackgroundImage;
            ClientSize = new Size(726, 543);
            Controls.Add(lblTitulo);
            Controls.Add(lstUsuarios);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmLogsUsuarios";
            Text = "Registro de usuarios";
            Load += FormLogsUsuarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstUsuarios;
        private Label lblTitulo;
    }
}