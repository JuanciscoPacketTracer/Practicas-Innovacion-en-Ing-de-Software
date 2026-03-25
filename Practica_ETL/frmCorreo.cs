using System;
using System.Drawing;
using System.Windows.Forms;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Tesseract;

namespace Practica_ETL
{
    public partial class frmCorreo : Form
    {
        public frmCorreo()
        {
            InitializeComponent();
            AplicarEstilo();
        }
        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Estilos.TextoClaro;
                    lbl.Font = Estilos.FuenteBold;
                }
            }

            Estilos.EstilizarTextBoxConPlaceholder(tbCorreo, "tucorreo@gmail.com");
            Estilos.EstilizarTextBoxConPlaceholder(tbDestinatario, "destinatario@email.com");
            Estilos.EstilizarTextBoxConPlaceholder(tbAsunto, "Escribe el asunto...");
            Estilos.EstilizarTextBoxConPlaceholder(tbArchivo, "Ruta del archivo...");
            Estilos.EstilizarTextBox(tbPassword);
            Estilos.EstilizarTextBoxConPlaceholder(tbMensaje, "Escribe tu mensaje aquí...");
            Estilos.EstilizarBoton(btnEnviar, "📧 Enviar Correo");
            Estilos.EstilizarBoton(btnArchivo, "📎 Adjuntar Archivo");
        }
        private void EnviarCorreo()
        {
            var mensaje = new MimeMessage();
            mensaje.From.Add(MailboxAddress.Parse(tbCorreo.Text));
            mensaje.To.Add(MailboxAddress.Parse(tbDestinatario.Text));
            mensaje.Subject = tbAsunto.Text;
            var builder = new BodyBuilder
            {
                TextBody = tbMensaje.Text
            };
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
        private void Adjuntar_archivo()
        {             OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
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

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            EnviarCorreo();
        }

        private void BtnArchivo_Click(object sender, EventArgs e)
        {
            Adjuntar_archivo();
        }

        private void BtnLeerImagen_Click(object sender, EventArgs e)
        {
            var idiomasDisponibles = "spa|eng|fra|deu|rus";
            var dlg = new OpenFileDialog();
            dlg.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var rutaImagen = dlg.FileName;
                var idioma = "spa";
                if (idiomasDisponibles.Contains(idioma))
                {
                    var tessdataPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "modelos");
                    using (var engine = new TesseractEngine(tessdataPath, idioma, EngineMode.Default))
                    {
                        using (var img = Pix.LoadFromFile(rutaImagen))
                        {
                            using (var page = engine.Process(img))
                            {
                                tbMensaje.Text = page.GetText();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Idioma no soportado para OCR.");
                }
            }
        }
    }
}
