using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
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
    public partial class frmCorreo : Form
    {
        private Color colorFondo = Color.FromArgb(30, 30, 46);
        private Color colorBoton = Color.FromArgb(137, 180, 250);
        private Color colorBotonHover = Color.FromArgb(116, 199, 236);
        private Color colorTexto = Color.White;
        private Color colorTextoBoton = Color.FromArgb(30, 30, 46);
        private Font fuenteTitulo = new Font("Times New Roman", 18, FontStyle.Bold);
        private Font fuenteBoton = new Font("Times New Roman", 18, FontStyle.Bold);

        private void EstilizarBoton(System.Windows.Forms.Button btn, string texto)
        {
            btn.FlatStyle = FlatStyle.Flat;                    // Quita el estilo 3D de Windows
            btn.FlatAppearance.BorderSize = 0;                 // Sin borde
            btn.BackColor = colorBoton;                        // Color de fondo
            btn.ForeColor = colorTextoBoton;                   // Color del texto
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
            EstilizarBoton(btnArchivo, "📁 Adjuntar Archivo");
            EstilizarBoton(btnEnviar, "📧 Enviar Correo");
            label1.Font = fuenteTitulo;
            label1.ForeColor = colorTexto;
            label1.AutoSize = true;
            label2.Font = fuenteTitulo;
            label2.ForeColor = colorTexto;
            label2.AutoSize = true;
            label3.Font = fuenteTitulo;
            label3.ForeColor = colorTexto;
            label3.AutoSize = true;
            label4.Font = fuenteTitulo;
            label4.ForeColor = colorTexto;
            label4.AutoSize = true;
            label5.Font = fuenteTitulo;
            label5.ForeColor = colorTexto;
            label5.AutoSize = true;
            label6.Font = fuenteTitulo;
            label6.ForeColor = colorTexto;
            label6.AutoSize = true;

        }
        public frmCorreo()
        {
            InitializeComponent();
            AplicarEstilo();
        }
        private void EnviarCorreo()
        {
            var mensaje = new MimeMessage();
            mensaje.From.Add(MailboxAddress.Parse(tbCorreo.Text));
            mensaje.To.Add(MailboxAddress.Parse(tbDestinatario.Text));
            mensaje.Subject = tbAsunto.Text;
            var builder = new BodyBuilder();
            builder.TextBody = tbMensaje.Text;
            if (!string.IsNullOrEmpty(ruta))
            {
                builder.Attachments.Add(ruta);
            }
            mensaje.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(tbCorreo.Text, tbPassword.Text);
                smtp.Send(mensaje);
                smtp.Disconnect(true);
            }
            MessageBox.Show("Correo enviado exitosamente.");
        }
        private void frmCorreo_Load(object sender, EventArgs e)
        {

        }
        string ruta = "";
        private void adjuntar_archivo()
        {             OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                tbArchivo.Text = rutaArchivo;
                ruta = rutaArchivo;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarCorreo();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            adjuntar_archivo();
        }
    }
}
