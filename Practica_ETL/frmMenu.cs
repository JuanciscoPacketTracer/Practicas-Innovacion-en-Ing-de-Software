using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_ETL
{
    public partial class frmMenu : Form
    {
        private Color colorFondo = Color.FromArgb(30, 30, 46);     
        private Color colorBoton = Color.FromArgb(137, 180, 250); 
        private Color colorBotonHover = Color.FromArgb(116, 199, 236);
        private Color colorTexto = Color.White;
        private Color colorTextoBoton = Color.FromArgb(30, 30, 46);
        private Font fuenteTitulo = new Font("Times New Roman", 18, FontStyle.Bold);
        private Font fuenteBoton = new Font("Times New Roman", 18, FontStyle.Bold);

        public frmMenu()
        {
            InitializeComponent();
            AplicarEstilo();
        }

        private void EstilizarBoton(Button btn, string texto)
        {
            btn.FlatStyle = FlatStyle.Flat;                    // Quita el estilo 3D de Windows
            btn.FlatAppearance.BorderSize = 0;                 // Sin borde
            btn.BackColor = colorBoton;                        // Color de fondo
            btn.ForeColor = colorTextoBoton;                   // Color del texto
            btn.Font = fuenteBoton;                            // Fuente moderna
            btn.Text = texto;
            btn.Cursor = Cursors.Hand;                         // Manita al pasar el mouse
            btn.MouseEnter += (s, e) => btn.BackColor = colorBotonHover;
            btn.MouseLeave += (s, e) => btn.BackColor = colorBoton;
        }
        private void AplicarEstilo()
        {
            this.BackColor = colorFondo;
            this.Text = "Menú Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            EstilizarBoton(btnETL, "📊  Proceso ETL");
            EstilizarBoton(tbEnviarCorreos, "📧  Enviar Correos");
            EstilizarBoton(btnFrame, "📷  Captura de Frame");
            lblTitulo.Font = fuenteTitulo;
            lblTitulo.ForeColor = colorTexto;
            lblTitulo.AutoSize = true; 
        }

        private void btnFrame_Click(object sender, EventArgs e)
        {
            frmFrame frame = new frmFrame();
            frame.Show();
        }

        private void tbEnviarCorreos_Click(object sender, EventArgs e)
        {
            frmCorreo correo = new frmCorreo();
            correo.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnETL_Click(object sender, EventArgs e)
        {
            frmETL ETL = new frmETL();
            ETL.Show();
        }
    }
}
