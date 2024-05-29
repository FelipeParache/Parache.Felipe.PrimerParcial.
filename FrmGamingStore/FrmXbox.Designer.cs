using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;
using FrmGamingStore.Properties;

namespace FrmGamingStore
{
    partial class FrmXbox
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
            lblAlmacenamientoNube = new Label();
            cmbAlmacenamientoNube = new ComboBox();
            lblXboxLiveGold = new Label();
            rbtnXboxLiveGoldSi = new RadioButton();
            rbtnXboxLiveGoldNo = new RadioButton();
            SuspendLayout();
            // 
            // lblAlmacenamientoNube
            // 
            lblAlmacenamientoNube.AutoSize = true;
            lblAlmacenamientoNube.BackColor = Color.Transparent;
            lblAlmacenamientoNube.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblAlmacenamientoNube.ForeColor = Color.White;
            lblAlmacenamientoNube.Location = new Point(64, 325);
            lblAlmacenamientoNube.Name = "lblAlmacenamientoNube";
            lblAlmacenamientoNube.Size = new Size(187, 58);
            lblAlmacenamientoNube.TabIndex = 8;
            lblAlmacenamientoNube.Text = "Almacenamiento \r\nextra en la nube:";
            // 
            // cmbAlmacenamientoNube
            // 
            cmbAlmacenamientoNube.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlmacenamientoNube.FormattingEnabled = true;
            cmbAlmacenamientoNube.Location = new Point(295, 355);
            cmbAlmacenamientoNube.Name = "cmbAlmacenamientoNube";
            cmbAlmacenamientoNube.Size = new Size(180, 28);
            cmbAlmacenamientoNube.TabIndex = 9;
            cmbAlmacenamientoNube.TextChanged += cmbAlmacenamientoNube_TextChanged;
            // 
            // lblXboxLiveGold
            // 
            lblXboxLiveGold.AutoSize = true;
            lblXboxLiveGold.BackColor = Color.Transparent;
            lblXboxLiveGold.Font = new Font("Franklin Gothic Medium", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblXboxLiveGold.ForeColor = Color.White;
            lblXboxLiveGold.Location = new Point(64, 429);
            lblXboxLiveGold.Name = "lblXboxLiveGold";
            lblXboxLiveGold.Size = new Size(181, 58);
            lblXboxLiveGold.TabIndex = 10;
            lblXboxLiveGold.Text = "¿Desea contratar\r\nXbox Live Gold?";
            lblXboxLiveGold.Visible = false;
            // 
            // rbtnXboxLiveGoldSi
            // 
            rbtnXboxLiveGoldSi.AutoSize = true;
            rbtnXboxLiveGoldSi.BackColor = Color.Transparent;
            rbtnXboxLiveGoldSi.ForeColor = Color.White;
            rbtnXboxLiveGoldSi.Location = new Point(295, 433);
            rbtnXboxLiveGoldSi.Name = "rbtnXboxLiveGoldSi";
            rbtnXboxLiveGoldSi.Size = new Size(42, 24);
            rbtnXboxLiveGoldSi.TabIndex = 11;
            rbtnXboxLiveGoldSi.TabStop = true;
            rbtnXboxLiveGoldSi.Text = "Si";
            rbtnXboxLiveGoldSi.UseVisualStyleBackColor = false;
            rbtnXboxLiveGoldSi.Visible = false;
            // 
            // rbtnXboxLiveGoldNo
            // 
            rbtnXboxLiveGoldNo.AutoSize = true;
            rbtnXboxLiveGoldNo.BackColor = Color.Transparent;
            rbtnXboxLiveGoldNo.ForeColor = Color.White;
            rbtnXboxLiveGoldNo.Location = new Point(295, 463);
            rbtnXboxLiveGoldNo.Name = "rbtnXboxLiveGoldNo";
            rbtnXboxLiveGoldNo.Size = new Size(50, 24);
            rbtnXboxLiveGoldNo.TabIndex = 12;
            rbtnXboxLiveGoldNo.TabStop = true;
            rbtnXboxLiveGoldNo.Text = "No";
            rbtnXboxLiveGoldNo.UseVisualStyleBackColor = false;
            rbtnXboxLiveGoldNo.Visible = false;
            // 
            // FrmXbox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.frmXboxBackgroundImage1;
            ClientSize = new Size(536, 630);
            Controls.Add(rbtnXboxLiveGoldNo);
            Controls.Add(rbtnXboxLiveGoldSi);
            Controls.Add(lblXboxLiveGold);
            Controls.Add(cmbAlmacenamientoNube);
            Controls.Add(lblAlmacenamientoNube);
            Name = "FrmXbox";
            Text = "FrmXbox";
            Controls.SetChildIndex(cmbModelos, 0);
            Controls.SetChildIndex(cmbVideojuegos, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(cmbAlmacenamiento, 0);
            Controls.SetChildIndex(lblAlmacenamientoNube, 0);
            Controls.SetChildIndex(cmbAlmacenamientoNube, 0);
            Controls.SetChildIndex(lblXboxLiveGold, 0);
            Controls.SetChildIndex(rbtnXboxLiveGoldSi, 0);
            Controls.SetChildIndex(rbtnXboxLiveGoldNo, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAlmacenamientoNube;
        private ComboBox cmbAlmacenamientoNube;
        private Label lblXboxLiveGold;
        private RadioButton rbtnXboxLiveGoldSi;
        private RadioButton rbtnXboxLiveGoldNo;
    }
}