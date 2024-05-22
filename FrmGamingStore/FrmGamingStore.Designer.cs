using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

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
            SuspendLayout();
            // 
            // btnPlayStation
            // 
            btnPlayStation.Location = new Point(12, 87);
            btnPlayStation.Name = "btnPlayStation";
            btnPlayStation.Size = new Size(135, 54);
            btnPlayStation.TabIndex = 0;
            btnPlayStation.Text = "PlayStation";
            btnPlayStation.UseVisualStyleBackColor = true;
            btnPlayStation.Click += btnPlayStation_Click;
            // 
            // btnNintendo
            // 
            btnNintendo.Location = new Point(153, 87);
            btnNintendo.Name = "btnNintendo";
            btnNintendo.Size = new Size(135, 54);
            btnNintendo.TabIndex = 1;
            btnNintendo.Text = "Nintendo";
            btnNintendo.UseVisualStyleBackColor = true;
            btnNintendo.Click += btnNintendo_Click;
            // 
            // btnXbox
            // 
            btnXbox.Location = new Point(294, 87);
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
            lblMarca.Location = new Point(116, 43);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(195, 20);
            lblMarca.TabIndex = 3;
            lblMarca.Text = "Elija la marca de su consola:";
            // 
            // lstConsolas
            // 
            lstConsolas.FormattingEnabled = true;
            lstConsolas.ItemHeight = 20;
            lstConsolas.Location = new Point(12, 175);
            lstConsolas.Name = "lstConsolas";
            lstConsolas.Size = new Size(417, 304);
            lstConsolas.TabIndex = 4;
            // 
            // FrmTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 487);
            Controls.Add(lstConsolas);
            Controls.Add(lblMarca);
            Controls.Add(btnXbox);
            Controls.Add(btnNintendo);
            Controls.Add(btnPlayStation);
            Name = "FrmTest";
            Text = "Gaming Store";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlayStation;
        private Button btnNintendo;
        private Button btnXbox;
        private Label lblMarca;
        private ListBox lstConsolas;
    }
}