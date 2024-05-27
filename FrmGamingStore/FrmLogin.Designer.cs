using System.Runtime.Versioning;

namespace FrmGamingStore
{
    partial class FrmLogin
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
            lblCorreo = new Label();
            lblClave = new Label();
            txtCorreo = new TextBox();
            txtClave = new TextBox();
            lblTitulo = new Label();
            btnIngresar = new Button();
            btnLogs = new Button();
            SuspendLayout();
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCorreo.Location = new Point(67, 119);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(52, 20);
            lblCorreo.TabIndex = 0;
            lblCorreo.Text = "Correo";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblClave.Location = new Point(67, 248);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(45, 20);
            lblClave.TabIndex = 1;
            lblClave.Text = "Clave";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(67, 143);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(308, 27);
            txtCorreo.TabIndex = 2;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(67, 272);
            txtClave.Margin = new Padding(3, 4, 3, 4);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(298, 27);
            txtClave.TabIndex = 3;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(67, 29);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(312, 24);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "BIENVENIDO A GAMINGSTORE";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.Location = new Point(67, 361);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(126, 72);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLogs
            // 
            btnLogs.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogs.Location = new Point(241, 361);
            btnLogs.Margin = new Padding(3, 4, 3, 4);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(125, 72);
            btnLogs.TabIndex = 6;
            btnLogs.Text = "VER LOGS USUARIOS";
            btnLogs.Click += btnLogs_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 507);
            Controls.Add(btnLogs);
            Controls.Add(btnIngresar);
            Controls.Add(lblTitulo);
            Controls.Add(txtClave);
            Controls.Add(txtCorreo);
            Controls.Add(lblClave);
            Controls.Add(lblCorreo);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmLogin";
            Text = "Inicio sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCorreo;
        private Label lblClave;
        private TextBox txtCorreo;
        private TextBox txtClave;
        private Label lblTitulo;
        private Button btnIngresar;
        private Button btnLogs;
    }
}