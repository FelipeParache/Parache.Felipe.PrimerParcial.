using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FrmGamingStore
{
    partial class FrmPlayStation
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
            lblControles = new Label();
            cmbControles = new ComboBox();
            lblPsPlus = new Label();
            rbtnPsPlusSi = new RadioButton();
            rbtnPsPlusNo = new RadioButton();
            SuspendLayout();
            // 
            // lblControles
            // 
            lblControles.AutoSize = true;
            lblControles.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblControles.Location = new Point(64, 327);
            lblControles.Name = "lblControles";
            lblControles.Size = new Size(111, 29);
            lblControles.TabIndex = 8;
            lblControles.Text = "Controles:";
            // 
            // cmbControles
            // 
            cmbControles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbControles.FormattingEnabled = true;
            cmbControles.Location = new Point(295, 328);
            cmbControles.Name = "cmbControles";
            cmbControles.Size = new Size(180, 28);
            cmbControles.TabIndex = 9;
            // 
            // lblPsPlus
            // 
            lblPsPlus.AutoSize = true;
            lblPsPlus.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblPsPlus.Location = new Point(64, 406);
            lblPsPlus.Name = "lblPsPlus";
            lblPsPlus.Size = new Size(184, 58);
            lblPsPlus.TabIndex = 10;
            lblPsPlus.Text = "¿Desea contratar\r\nPlayStation Plus?";
            // 
            // rbtnPsPlusSi
            // 
            rbtnPsPlusSi.AutoSize = true;
            rbtnPsPlusSi.Location = new Point(295, 410);
            rbtnPsPlusSi.Name = "rbtnPsPlusSi";
            rbtnPsPlusSi.Size = new Size(42, 24);
            rbtnPsPlusSi.TabIndex = 11;
            rbtnPsPlusSi.TabStop = true;
            rbtnPsPlusSi.Text = "Si";
            rbtnPsPlusSi.UseVisualStyleBackColor = true;
            // 
            // rbtnPsPlusNo
            // 
            rbtnPsPlusNo.AutoSize = true;
            rbtnPsPlusNo.Location = new Point(295, 440);
            rbtnPsPlusNo.Name = "rbtnPsPlusNo";
            rbtnPsPlusNo.Size = new Size(50, 24);
            rbtnPsPlusNo.TabIndex = 12;
            rbtnPsPlusNo.TabStop = true;
            rbtnPsPlusNo.Text = "No";
            rbtnPsPlusNo.UseVisualStyleBackColor = true;
            // 
            // FrmPlayStation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 630);
            Controls.Add(rbtnPsPlusNo);
            Controls.Add(rbtnPsPlusSi);
            Controls.Add(lblPsPlus);
            Controls.Add(cmbControles);
            Controls.Add(lblControles);
            Name = "FrmPlayStation";
            Text = "FrmPlayStation";
            Controls.SetChildIndex(cmbModelos, 0);
            Controls.SetChildIndex(cmbVideojuegos, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(cmbAlmacenamiento, 0);
            Controls.SetChildIndex(lblControles, 0);
            Controls.SetChildIndex(cmbControles, 0);
            Controls.SetChildIndex(lblPsPlus, 0);
            Controls.SetChildIndex(rbtnPsPlusSi, 0);
            Controls.SetChildIndex(rbtnPsPlusNo, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblControles;
        private ComboBox cmbControles;
        private Label lblPsPlus;
        private RadioButton rbtnPsPlusSi;
        private RadioButton rbtnPsPlusNo;
    }
}