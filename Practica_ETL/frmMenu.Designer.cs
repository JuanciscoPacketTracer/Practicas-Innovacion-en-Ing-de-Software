namespace Practica_ETL
{
    partial class frmMenu
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
            this.btnETL = new System.Windows.Forms.Button();
            this.btnFrame = new System.Windows.Forms.Button();
            this.btnEnviarCorreo = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnReconocerTexto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnETL
            // 
            this.btnETL.Location = new System.Drawing.Point(80, 107);
            this.btnETL.Margin = new System.Windows.Forms.Padding(4);
            this.btnETL.Name = "btnETL";
            this.btnETL.Size = new System.Drawing.Size(308, 64);
            this.btnETL.TabIndex = 0;
            this.btnETL.Text = "Proceso ETL";
            this.btnETL.UseVisualStyleBackColor = true;
            this.btnETL.Click += new System.EventHandler(this.btnETL_Click);
            // 
            // btnFrame
            // 
            this.btnFrame.Location = new System.Drawing.Point(501, 107);
            this.btnFrame.Margin = new System.Windows.Forms.Padding(4);
            this.btnFrame.Name = "btnFrame";
            this.btnFrame.Size = new System.Drawing.Size(308, 64);
            this.btnFrame.TabIndex = 1;
            this.btnFrame.Text = "Captura de frame";
            this.btnFrame.UseVisualStyleBackColor = true;
            this.btnFrame.Click += new System.EventHandler(this.btnFrame_Click);
            // 
            // btnEnviarCorreo
            // 
            this.btnEnviarCorreo.Location = new System.Drawing.Point(80, 240);
            this.btnEnviarCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviarCorreo.Name = "btnEnviarCorreo";
            this.btnEnviarCorreo.Size = new System.Drawing.Size(308, 64);
            this.btnEnviarCorreo.TabIndex = 2;
            this.btnEnviarCorreo.Text = "Enviar Correos";
            this.btnEnviarCorreo.UseVisualStyleBackColor = true;
            this.btnEnviarCorreo.Click += new System.EventHandler(this.tbEnviarCorreos_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(91, 39);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(258, 19);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Prácticas Innovación de Ing. de Software";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // btnReconocerTexto
            // 
            this.btnReconocerTexto.Location = new System.Drawing.Point(501, 240);
            this.btnReconocerTexto.Margin = new System.Windows.Forms.Padding(4);
            this.btnReconocerTexto.Name = "btnReconocerTexto";
            this.btnReconocerTexto.Size = new System.Drawing.Size(308, 64);
            this.btnReconocerTexto.TabIndex = 4;
            this.btnReconocerTexto.Text = "Reconocer Texto";
            this.btnReconocerTexto.UseVisualStyleBackColor = true;
            this.btnReconocerTexto.Click += new System.EventHandler(this.btnReconocerTexto_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 375);
            this.Controls.Add(this.btnReconocerTexto);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnEnviarCorreo);
            this.Controls.Add(this.btnFrame);
            this.Controls.Add(this.btnETL);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnETL;
        private System.Windows.Forms.Button btnFrame;
        private System.Windows.Forms.Button btnEnviarCorreo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnReconocerTexto;
    }
}