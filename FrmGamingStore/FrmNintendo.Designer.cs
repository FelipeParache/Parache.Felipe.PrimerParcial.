using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FrmGamingStore
{
    partial class FrmNintendo
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
            lblPerifericos = new Label();
            cmbPerifericos = new ComboBox();
            SuspendLayout();
            // 
            // lblPerifericos
            // 
            lblPerifericos.AutoSize = true;
            lblPerifericos.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblPerifericos.Location = new Point(64, 325);
            lblPerifericos.Name = "lblPerifericos";
            lblPerifericos.Size = new Size(139, 58);
            lblPerifericos.TabIndex = 8;
            lblPerifericos.Text = "Accesorios\r\ny periféricos:";
            // 
            // cmbPerifericos
            // 
            cmbPerifericos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerifericos.FormattingEnabled = true;
            cmbPerifericos.Location = new Point(295, 355);
            cmbPerifericos.Name = "cmbPerifericos";
            cmbPerifericos.Size = new Size(180, 28);
            cmbPerifericos.TabIndex = 9;
            // 
            // FrmNintendo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 630);
            Controls.Add(cmbPerifericos);
            Controls.Add(lblPerifericos);
            Name = "FrmNintendo";
            Text = "FrmNintendo";
            Controls.SetChildIndex(cmbModelos, 0);
            Controls.SetChildIndex(cmbVideojuegos, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(cmbAlmacenamiento, 0);
            Controls.SetChildIndex(lblPerifericos, 0);
            Controls.SetChildIndex(cmbPerifericos, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPerifericos;
        private ComboBox cmbPerifericos;
    }
}