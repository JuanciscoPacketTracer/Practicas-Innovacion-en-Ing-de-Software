namespace Practica_ETL
{
    partial class frmDatagrid
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
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.dgFotos = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.tbPagina = new System.Windows.Forms.TextBox();
            this.lblIdFoto = new System.Windows.Forms.Label();
            this.lblNombreFoto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFotos)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFoto
            // 
            this.pbFoto.Location = new System.Drawing.Point(504, 58);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(383, 280);
            this.pbFoto.TabIndex = 1;
            this.pbFoto.TabStop = false;
            this.pbFoto.Click += new System.EventHandler(this.pbFoto_Click);
            // 
            // dgFotos
            // 
            this.dgFotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFotos.Location = new System.Drawing.Point(11, 58);
            this.dgFotos.Name = "dgFotos";
            this.dgFotos.Size = new System.Drawing.Size(487, 391);
            this.dgFotos.TabIndex = 0;
            this.dgFotos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFotos_CellContentClick);
            this.dgFotos.SelectionChanged += new System.EventHandler(this.dgFotos_SelectionChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(10, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(119, 13);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Imagenes almacenadas";
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNext.Location = new System.Drawing.Point(447, 477);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(48, 34);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "->";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnPrev
            // 
            this.btnPrev.AutoSize = true;
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrev.Location = new System.Drawing.Point(10, 477);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(48, 34);
            this.btnPrev.TabIndex = 10;
            this.btnPrev.Text = "<-";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click_1);
            // 
            // tbPagina
            // 
            this.tbPagina.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPagina.Location = new System.Drawing.Point(151, 482);
            this.tbPagina.Margin = new System.Windows.Forms.Padding(4);
            this.tbPagina.Name = "tbPagina";
            this.tbPagina.ReadOnly = true;
            this.tbPagina.Size = new System.Drawing.Size(180, 26);
            this.tbPagina.TabIndex = 9;
            this.tbPagina.TextChanged += new System.EventHandler(this.tbPagina_TextChanged);
            // 
            // lblIdFoto
            // 
            this.lblIdFoto.AutoSize = true;
            this.lblIdFoto.Location = new System.Drawing.Point(504, 368);
            this.lblIdFoto.Name = "lblIdFoto";
            this.lblIdFoto.Size = new System.Drawing.Size(35, 13);
            this.lblIdFoto.TabIndex = 12;
            this.lblIdFoto.Text = "label2";
            this.lblIdFoto.Click += new System.EventHandler(this.lblIdFoto_Click);
            // 
            // lblNombreFoto
            // 
            this.lblNombreFoto.AutoSize = true;
            this.lblNombreFoto.Location = new System.Drawing.Point(504, 410);
            this.lblNombreFoto.Name = "lblNombreFoto";
            this.lblNombreFoto.Size = new System.Drawing.Size(12, 13);
            this.lblNombreFoto.TabIndex = 13;
            this.lblNombreFoto.Text = "x";
            this.lblNombreFoto.Click += new System.EventHandler(this.lblNombreFoto_Click);
            // 
            // frmDatagrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 545);
            this.Controls.Add(this.lblNombreFoto);
            this.Controls.Add(this.lblIdFoto);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.tbPagina);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.dgFotos);
            this.Name = "frmDatagrid";
            this.Text = "frmDatagrid";
            this.Load += new System.EventHandler(this.frmDatagrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFotos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.DataGridView dgFotos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox tbPagina;
        private System.Windows.Forms.Label lblIdFoto;
        private System.Windows.Forms.Label lblNombreFoto;
    }
}