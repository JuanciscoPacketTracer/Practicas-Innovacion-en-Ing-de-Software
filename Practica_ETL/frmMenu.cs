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
    }
}
