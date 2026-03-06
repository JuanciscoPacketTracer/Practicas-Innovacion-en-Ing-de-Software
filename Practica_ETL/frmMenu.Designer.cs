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
            this.tbEnviarCorreos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnETL
            // 
            this.btnETL.Location = new System.Drawing.Point(88, 43);
            this.btnETL.Margin = new System.Windows.Forms.Padding(4);
            this.btnETL.Name = "btnETL";
            this.btnETL.Size = new System.Drawing.Size(308, 101);
            this.btnETL.TabIndex = 0;
            this.btnETL.Text = "Proceso ETL";
            this.btnETL.UseVisualStyleBackColor = true;
            // 
            // btnFrame
            // 
            this.btnFrame.Location = new System.Drawing.Point(88, 261);
            this.btnFrame.Margin = new System.Windows.Forms.Padding(4);
            this.btnFrame.Name = "btnFrame";
            this.btnFrame.Size = new System.Drawing.Size(308, 101);
            this.btnFrame.TabIndex = 1;
            this.btnFrame.Text = "Captura de frame";
            this.btnFrame.UseVisualStyleBackColor = true;
            this.btnFrame.Click += new System.EventHandler(this.btnFrame_Click);
            // 
            // tbEnviarCorreos
            // 
            this.tbEnviarCorreos.Location = new System.Drawing.Point(88, 152);
            this.tbEnviarCorreos.Margin = new System.Windows.Forms.Padding(4);
            this.tbEnviarCorreos.Name = "tbEnviarCorreos";
            this.tbEnviarCorreos.Size = new System.Drawing.Size(308, 101);
            this.tbEnviarCorreos.TabIndex = 2;
            this.tbEnviarCorreos.Text = "Enviar Correos";
            this.tbEnviarCorreos.UseVisualStyleBackColor = true;
            this.tbEnviarCorreos.Click += new System.EventHandler(this.tbEnviarCorreos_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 404);
            this.Controls.Add(this.tbEnviarCorreos);
            this.Controls.Add(this.btnFrame);
            this.Controls.Add(this.btnETL);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnETL;
        private System.Windows.Forms.Button btnFrame;
        private System.Windows.Forms.Button tbEnviarCorreos;
    }
}