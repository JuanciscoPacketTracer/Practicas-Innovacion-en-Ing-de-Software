namespace Practica_ETL
{
    partial class frmQR
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
            this.tcEmpleado = new System.Windows.Forms.TabControl();
            this.tpGuardar = new System.Windows.Forms.TabPage();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbGApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGNoEmpleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpImprimir = new System.Windows.Forms.TabPage();
            this.pbIQR = new System.Windows.Forms.PictureBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tbIApellido = new System.Windows.Forms.TextBox();
            this.tbINombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbINoEmpleado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tpQR = new System.Windows.Forms.TabPage();
            this.tbLApellido = new System.Windows.Forms.TextBox();
            this.tbLNombre = new System.Windows.Forms.TextBox();
            this.pbLQR = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLeer = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLNoEmpleado = new System.Windows.Forms.TextBox();
            this.tcEmpleado.SuspendLayout();
            this.tpGuardar.SuspendLayout();
            this.tpImprimir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIQR)).BeginInit();
            this.tpQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLQR)).BeginInit();
            this.SuspendLayout();
            // 
            // tcEmpleado
            // 
            this.tcEmpleado.Controls.Add(this.tpGuardar);
            this.tcEmpleado.Controls.Add(this.tpImprimir);
            this.tcEmpleado.Controls.Add(this.tpQR);
            this.tcEmpleado.Location = new System.Drawing.Point(2, 5);
            this.tcEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.tcEmpleado.Name = "tcEmpleado";
            this.tcEmpleado.SelectedIndex = 0;
            this.tcEmpleado.Size = new System.Drawing.Size(776, 454);
            this.tcEmpleado.TabIndex = 0;
            // 
            // tpGuardar
            // 
            this.tpGuardar.Controls.Add(this.btnGuardar);
            this.tpGuardar.Controls.Add(this.tbGApellido);
            this.tpGuardar.Controls.Add(this.label3);
            this.tpGuardar.Controls.Add(this.tbGNombre);
            this.tpGuardar.Controls.Add(this.label2);
            this.tpGuardar.Controls.Add(this.tbGNoEmpleado);
            this.tpGuardar.Controls.Add(this.label1);
            this.tpGuardar.Location = new System.Drawing.Point(4, 28);
            this.tpGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.tpGuardar.Name = "tpGuardar";
            this.tpGuardar.Padding = new System.Windows.Forms.Padding(4);
            this.tpGuardar.Size = new System.Drawing.Size(768, 422);
            this.tpGuardar.TabIndex = 0;
            this.tpGuardar.Text = "Guardar";
            this.tpGuardar.UseVisualStyleBackColor = true;
            this.tpGuardar.Click += new System.EventHandler(this.tpGuardar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(455, 40);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(234, 67);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "button1";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbGApellido
            // 
            this.tbGApellido.Location = new System.Drawing.Point(15, 212);
            this.tbGApellido.Margin = new System.Windows.Forms.Padding(4);
            this.tbGApellido.Name = "tbGApellido";
            this.tbGApellido.Size = new System.Drawing.Size(300, 26);
            this.tbGApellido.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido";
            // 
            // tbGNombre
            // 
            this.tbGNombre.Location = new System.Drawing.Point(15, 132);
            this.tbGNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbGNombre.Name = "tbGNombre";
            this.tbGNombre.Size = new System.Drawing.Size(300, 26);
            this.tbGNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // tbGNoEmpleado
            // 
            this.tbGNoEmpleado.Location = new System.Drawing.Point(15, 61);
            this.tbGNoEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.tbGNoEmpleado.Name = "tbGNoEmpleado";
            this.tbGNoEmpleado.Size = new System.Drawing.Size(300, 26);
            this.tbGNoEmpleado.TabIndex = 1;
            this.tbGNoEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGNoEmpleado_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. de Empleado";
            // 
            // tpImprimir
            // 
            this.tpImprimir.Controls.Add(this.pbIQR);
            this.tpImprimir.Controls.Add(this.btnCargar);
            this.tpImprimir.Controls.Add(this.btnConsultar);
            this.tpImprimir.Controls.Add(this.btnImprimir);
            this.tpImprimir.Controls.Add(this.tbIApellido);
            this.tpImprimir.Controls.Add(this.tbINombre);
            this.tpImprimir.Controls.Add(this.label4);
            this.tpImprimir.Controls.Add(this.label6);
            this.tpImprimir.Controls.Add(this.tbINoEmpleado);
            this.tpImprimir.Controls.Add(this.label5);
            this.tpImprimir.Location = new System.Drawing.Point(4, 28);
            this.tpImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.tpImprimir.Name = "tpImprimir";
            this.tpImprimir.Padding = new System.Windows.Forms.Padding(4);
            this.tpImprimir.Size = new System.Drawing.Size(768, 422);
            this.tpImprimir.TabIndex = 1;
            this.tpImprimir.Text = "Imprimir";
            this.tpImprimir.UseVisualStyleBackColor = true;
            // 
            // pbIQR
            // 
            this.pbIQR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIQR.Location = new System.Drawing.Point(490, 9);
            this.pbIQR.Name = "pbIQR";
            this.pbIQR.Size = new System.Drawing.Size(254, 220);
            this.pbIQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIQR.TabIndex = 15;
            this.pbIQR.TabStop = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(513, 297);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(187, 67);
            this.btnCargar.TabIndex = 14;
            this.btnCargar.Text = "button1";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(248, 297);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnConsultar.Size = new System.Drawing.Size(187, 67);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(4, 297);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(187, 67);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "btnImprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // tbIApellido
            // 
            this.tbIApellido.Location = new System.Drawing.Point(8, 189);
            this.tbIApellido.Margin = new System.Windows.Forms.Padding(4);
            this.tbIApellido.Name = "tbIApellido";
            this.tbIApellido.Size = new System.Drawing.Size(300, 26);
            this.tbIApellido.TabIndex = 11;
            // 
            // tbINombre
            // 
            this.tbINombre.Location = new System.Drawing.Point(8, 109);
            this.tbINombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbINombre.Name = "tbINombre";
            this.tbINombre.Size = new System.Drawing.Size(300, 26);
            this.tbINombre.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Apellido";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "No. de Empleado";
            // 
            // tbINoEmpleado
            // 
            this.tbINoEmpleado.Location = new System.Drawing.Point(8, 38);
            this.tbINoEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.tbINoEmpleado.Name = "tbINoEmpleado";
            this.tbINoEmpleado.Size = new System.Drawing.Size(300, 26);
            this.tbINoEmpleado.TabIndex = 7;
            this.tbINoEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbINoEmpleado_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nombre";
            // 
            // tpQR
            // 
            this.tpQR.Controls.Add(this.tbLApellido);
            this.tpQR.Controls.Add(this.tbLNombre);
            this.tpQR.Controls.Add(this.pbLQR);
            this.tpQR.Controls.Add(this.label7);
            this.tpQR.Controls.Add(this.btnLeer);
            this.tpQR.Controls.Add(this.label8);
            this.tpQR.Controls.Add(this.label9);
            this.tpQR.Controls.Add(this.tbLNoEmpleado);
            this.tpQR.Location = new System.Drawing.Point(4, 28);
            this.tpQR.Margin = new System.Windows.Forms.Padding(4);
            this.tpQR.Name = "tpQR";
            this.tpQR.Padding = new System.Windows.Forms.Padding(4);
            this.tpQR.Size = new System.Drawing.Size(768, 422);
            this.tpQR.TabIndex = 2;
            this.tpQR.Text = "Leer QR";
            this.tpQR.UseVisualStyleBackColor = true;
            // 
            // tbLApellido
            // 
            this.tbLApellido.Location = new System.Drawing.Point(284, 197);
            this.tbLApellido.Margin = new System.Windows.Forms.Padding(4);
            this.tbLApellido.Name = "tbLApellido";
            this.tbLApellido.Size = new System.Drawing.Size(300, 26);
            this.tbLApellido.TabIndex = 17;
            // 
            // tbLNombre
            // 
            this.tbLNombre.Location = new System.Drawing.Point(284, 117);
            this.tbLNombre.Margin = new System.Windows.Forms.Padding(4);
            this.tbLNombre.Name = "tbLNombre";
            this.tbLNombre.Size = new System.Drawing.Size(300, 26);
            this.tbLNombre.TabIndex = 15;
            // 
            // pbLQR
            // 
            this.pbLQR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbLQR.Location = new System.Drawing.Point(7, 15);
            this.pbLQR.Name = "pbLQR";
            this.pbLQR.Size = new System.Drawing.Size(254, 220);
            this.pbLQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLQR.TabIndex = 17;
            this.pbLQR.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 160);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Apellido";
            // 
            // btnLeer
            // 
            this.btnLeer.Location = new System.Drawing.Point(51, 264);
            this.btnLeer.Margin = new System.Windows.Forms.Padding(4);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(187, 67);
            this.btnLeer.TabIndex = 16;
            this.btnLeer.Text = "button1";
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 19);
            this.label8.TabIndex = 12;
            this.label8.Text = "No. de Empleado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Nombre";
            // 
            // tbLNoEmpleado
            // 
            this.tbLNoEmpleado.Location = new System.Drawing.Point(284, 46);
            this.tbLNoEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.tbLNoEmpleado.Name = "tbLNoEmpleado";
            this.tbLNoEmpleado.Size = new System.Drawing.Size(300, 26);
            this.tbLNoEmpleado.TabIndex = 13;
            // 
            // frmQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 472);
            this.Controls.Add(this.tcEmpleado);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQR";
            this.Text = "frmQR";
            this.Load += new System.EventHandler(this.frmQR_Load);
            this.tcEmpleado.ResumeLayout(false);
            this.tpGuardar.ResumeLayout(false);
            this.tpGuardar.PerformLayout();
            this.tpImprimir.ResumeLayout(false);
            this.tpImprimir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIQR)).EndInit();
            this.tpQR.ResumeLayout(false);
            this.tpQR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcEmpleado;
        private System.Windows.Forms.TabPage tpGuardar;
        private System.Windows.Forms.TabPage tpImprimir;
        private System.Windows.Forms.TabPage tpQR;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox tbGApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGNoEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox tbIApellido;
        private System.Windows.Forms.TextBox tbINombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbINoEmpleado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbIQR;
        private System.Windows.Forms.TextBox tbLApellido;
        private System.Windows.Forms.TextBox tbLNombre;
        private System.Windows.Forms.PictureBox pbLQR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLeer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLNoEmpleado;
    }
}