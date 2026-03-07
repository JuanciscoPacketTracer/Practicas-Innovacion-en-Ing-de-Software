namespace Practica_ETL
{
    partial class frmReconocerTexto
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
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.tbTexto = new System.Windows.Forms.TextBox();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.btnCarga = new System.Windows.Forms.Button();
            this.btnProcesamiento = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagen.Location = new System.Drawing.Point(4, 2);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(371, 428);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // tbTexto
            // 
            this.tbTexto.Location = new System.Drawing.Point(390, 2);
            this.tbTexto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTexto.Multiline = true;
            this.tbTexto.Name = "tbTexto";
            this.tbTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTexto.Size = new System.Drawing.Size(642, 426);
            this.tbTexto.TabIndex = 1;
            // 
            // cbIdioma
            // 
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Items.AddRange(new object[] {
            "Español",
            "Inglés",
            "Francés",
            "Japonés"});
            this.cbIdioma.Location = new System.Drawing.Point(4, 463);
            this.cbIdioma.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(264, 28);
            this.cbIdioma.TabIndex = 2;
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(0, 438);
            this.lblIdioma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(166, 20);
            this.lblIdioma.TabIndex = 3;
            this.lblIdioma.Text = "Idioma del documento";
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(390, 438);
            this.btnCarga.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(186, 65);
            this.btnCarga.TabIndex = 4;
            this.btnCarga.Text = "Cargar Imagen";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnProcesamiento
            // 
            this.btnProcesamiento.Location = new System.Drawing.Point(626, 438);
            this.btnProcesamiento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProcesamiento.Name = "btnProcesamiento";
            this.btnProcesamiento.Size = new System.Drawing.Size(186, 65);
            this.btnProcesamiento.TabIndex = 5;
            this.btnProcesamiento.Text = "Procesar Texto";
            this.btnProcesamiento.UseVisualStyleBackColor = true;
            this.btnProcesamiento.Click += new System.EventHandler(this.btnProcesamiento_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(846, 438);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(186, 65);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Texto";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmReconocerTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 523);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnProcesamiento);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.tbTexto);
            this.Controls.Add(this.pbImagen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReconocerTexto";
            this.Text = "Reconocer texto";
            this.Load += new System.EventHandler(this.frmReconocerTexto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.TextBox tbTexto;
        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Button btnProcesamiento;
        private System.Windows.Forms.Button btnGuardar;
    }
}