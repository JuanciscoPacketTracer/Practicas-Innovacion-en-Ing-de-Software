namespace Practica_ETL
{
    partial class frmEmpleados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNoEmpleado = new System.Windows.Forms.Label();
            this.tbINoEmpleado = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbINombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.tbIApellido = new System.Windows.Forms.TextBox();
            this.pbIQR = new System.Windows.Forms.PictureBox();
            this.btnCargarFoto = new System.Windows.Forms.Button();
            this.btnGenerarQR = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pbQRPreview = new System.Windows.Forms.PictureBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblQR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbIQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🪪 Gestión de Empleados";
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(20, 80);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(120, 19);
            this.lblFoto.TabIndex = 13;
            this.lblFoto.Text = "Fotografía del empleado:";
            // 
            // pbIQR
            // 
            this.pbIQR.Location = new System.Drawing.Point(20, 105);
            this.pbIQR.Name = "pbIQR";
            this.pbIQR.Size = new System.Drawing.Size(150, 150);
            this.pbIQR.TabIndex = 1;
            this.pbIQR.TabStop = false;
            // 
            // btnCargarFoto
            // 
            this.btnCargarFoto.Location = new System.Drawing.Point(20, 265);
            this.btnCargarFoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargarFoto.Name = "btnCargarFoto";
            this.btnCargarFoto.Size = new System.Drawing.Size(150, 45);
            this.btnCargarFoto.TabIndex = 2;
            this.btnCargarFoto.Text = "Cargar Foto";
            this.btnCargarFoto.UseVisualStyleBackColor = true;
            this.btnCargarFoto.Click += new System.EventHandler(this.btnCargarFoto_Click);
            // 
            // lblNoEmpleado
            // 
            this.lblNoEmpleado.AutoSize = true;
            this.lblNoEmpleado.Location = new System.Drawing.Point(200, 80);
            this.lblNoEmpleado.Name = "lblNoEmpleado";
            this.lblNoEmpleado.Size = new System.Drawing.Size(120, 19);
            this.lblNoEmpleado.TabIndex = 3;
            this.lblNoEmpleado.Text = "No. Empleado:";
            // 
            // tbINoEmpleado
            // 
            this.tbINoEmpleado.Location = new System.Drawing.Point(200, 105);
            this.tbINoEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.tbINoEmpleado.Name = "tbINoEmpleado";
            this.tbINoEmpleado.Size = new System.Drawing.Size(240, 26);
            this.tbINoEmpleado.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(200, 155);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 19);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // tbINombre
            // 
            this.tbINombre.Location = new System.Drawing.Point(200, 178);
            this.tbINombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbINombre.Name = "tbINombre";
            this.tbINombre.Size = new System.Drawing.Size(240, 26);
            this.tbINombre.TabIndex = 6;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(200, 228);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(80, 19);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido:";
            // 
            // tbIApellido
            // 
            this.tbIApellido.Location = new System.Drawing.Point(200, 251);
            this.tbIApellido.Margin = new System.Windows.Forms.Padding(4);
            this.tbIApellido.Name = "tbIApellido";
            this.tbIApellido.Size = new System.Drawing.Size(240, 26);
            this.tbIApellido.TabIndex = 8;
            // 
            // lblQR
            // 
            this.lblQR.AutoSize = true;
            this.lblQR.Location = new System.Drawing.Point(470, 80);
            this.lblQR.Name = "lblQR";
            this.lblQR.Size = new System.Drawing.Size(100, 19);
            this.lblQR.TabIndex = 14;
            this.lblQR.Text = "Vista previa del QR:";
            // 
            // pbQRPreview
            // 
            this.pbQRPreview.Location = new System.Drawing.Point(470, 105);
            this.pbQRPreview.Name = "pbQRPreview";
            this.pbQRPreview.Size = new System.Drawing.Size(150, 150);
            this.pbQRPreview.TabIndex = 9;
            this.pbQRPreview.TabStop = false;
            // 
            // btnGenerarQR
            // 
            this.btnGenerarQR.Location = new System.Drawing.Point(470, 265);
            this.btnGenerarQR.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarQR.Name = "btnGenerarQR";
            this.btnGenerarQR.Size = new System.Drawing.Size(150, 45);
            this.btnGenerarQR.TabIndex = 10;
            this.btnGenerarQR.Text = "Generar QR";
            this.btnGenerarQR.UseVisualStyleBackColor = true;
            this.btnGenerarQR.Click += new System.EventHandler(this.btnGenerarQR_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(200, 330);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(240, 50);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir Credencial";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 420);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFoto);
            this.Controls.Add(this.pbIQR);
            this.Controls.Add(this.btnCargarFoto);
            this.Controls.Add(this.lblNoEmpleado);
            this.Controls.Add(this.tbINoEmpleado);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tbINombre);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.tbIApellido);
            this.Controls.Add(this.lblQR);
            this.Controls.Add(this.pbQRPreview);
            this.Controls.Add(this.btnGenerarQR);
            this.Controls.Add(this.btnImprimir);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmEmpleados";
            this.Text = "Empleados";
            ((System.ComponentModel.ISupportInitialize)(this.pbIQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNoEmpleado;
        private System.Windows.Forms.TextBox tbINoEmpleado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbINombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox tbIApellido;
        private System.Windows.Forms.PictureBox pbIQR;
        private System.Windows.Forms.Button btnCargarFoto;
        private System.Windows.Forms.Button btnGenerarQR;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PictureBox pbQRPreview;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Label lblQR;
    }
}
