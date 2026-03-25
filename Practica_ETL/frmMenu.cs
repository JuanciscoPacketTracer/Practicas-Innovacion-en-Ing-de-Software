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
        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarLabel(lblTitulo, esTitulo: true);
            Estilos.EstilizarBoton(btnFrame, "📸 Capturar Frame");
            Estilos.EstilizarBoton(btnEnviarCorreo, "📧 Enviar Correos");
            Estilos.EstilizarBoton(btnETL, "⚙️ Proceso ETL");
            Estilos.EstilizarBoton(btnReconocerTexto, "🔍 Reconocer Texto");
            Estilos.EstilizarBoton(btnProductos, "🛒 Productos");
            Estilos.EstilizarBoton(btnQR, "🤵 QR de Empleados");
        }
        public frmMenu()
        {
            InitializeComponent();
            AplicarEstilo();
        }

        private void BtnFrame_Click(object sender, EventArgs e)
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

        private void BtnETL_Click(object sender, EventArgs e)
        {
            frmETL ETL = new frmETL();
            ETL.Show();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnReconocerTexto_Click(object sender, EventArgs e)
        {
            frmReconocerTexto reconocerTexto = new frmReconocerTexto();
            reconocerTexto.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos productos = new frmProductos();
            productos.Show();
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            frmQR frmQR = new frmQR();
            frmQR.Show();
        }
    }
}
