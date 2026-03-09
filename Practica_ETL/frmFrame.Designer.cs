namespace Practica_ETL
{
    partial class frmFrame
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnCaptura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(17, 123);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(126, 60);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del Frame";
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(17, 60);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(304, 26);
            this.tbNombre.TabIndex = 3;
            // 
            // pbVideo
            // 
            this.pbVideo.Location = new System.Drawing.Point(343, 24);
            this.pbVideo.Margin = new System.Windows.Forms.Padding(4);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(555, 392);
            this.pbVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVideo.TabIndex = 4;
            this.pbVideo.TabStop = false;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(196, 123);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(126, 60);
            this.btnConsulta.TabIndex = 5;
            this.btnConsulta.Text = "Consulta base de datos";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.Location = new System.Drawing.Point(18, 281);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(126, 60);
            this.btnActivar.TabIndex = 6;
            this.btnActivar.Text = "Activar Camara";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnCaptura
            // 
            this.btnCaptura.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaptura.Location = new System.Drawing.Point(196, 281);
            this.btnCaptura.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaptura.Name = "btnCaptura";
            this.btnCaptura.Size = new System.Drawing.Size(126, 60);
            this.btnCaptura.TabIndex = 7;
            this.btnCaptura.Text = "Captura";
            this.btnCaptura.UseVisualStyleBackColor = true;
            this.btnCaptura.Click += new System.EventHandler(this.btnCaptura_Click);
            // 
            // frmFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 429);
            this.Controls.Add(this.btnCaptura);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFrame";
            this.Text = "Captura de Frames";
            this.Load += new System.EventHandler(this.frmFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnCaptura;
    }
}