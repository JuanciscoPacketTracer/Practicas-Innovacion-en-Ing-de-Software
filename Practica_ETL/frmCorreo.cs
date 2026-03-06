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
        public frmCorreo()
        {
            InitializeComponent();
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
