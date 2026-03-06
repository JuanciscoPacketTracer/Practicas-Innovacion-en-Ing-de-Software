using AForge.Video;
using AForge.Video.DirectShow;
using K4os.Compression.LZ4.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica_ETL
{
    public partial class frmFrame : Form
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
            EstilizarBoton(btnActivar, "🎥 Activar Camara");
            EstilizarBoton(btnCaptura, "📷 Capturar Frame");
            EstilizarBoton(btnConsulta, "💽 Consultar BD");
            EstilizarBoton(btnGuardar, "💾 Guardar Frame");
            label1.Font = fuenteTitulo;
            label1.ForeColor = colorTexto;
            label1.AutoSize = true;

        }
        public frmFrame()
        {
            InitializeComponent();
            AplicarEstilo();
            btnCaptura.Enabled = false;
            if (btnActivar.Enabled)
            {
                btnGuardar.Enabled = false;
                tbNombre.Enabled = false;
            }
        }
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice camara;
        private void Camara_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbVideo.Image = (Bitmap)eventArgs.Frame.Clone();
            pbVideo.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        public void ActivarCamara()
        {
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            camara = new VideoCaptureDevice(dispositivos[0].MonikerString);
            camara.NewFrame += Camara_NewFrame;
            camara.Start();
            btnCaptura.Enabled = true;
            btnActivar.Enabled = false;
            btnGuardar.Enabled = false;
            tbNombre.Enabled = false;
        }
        public void DetenerCamara()
        {
            if (camara != null && camara.IsRunning)
            {
                camara.SignalToStop();
                camara.NewFrame -= Camara_NewFrame;
                camara = null;
            }
            btnGuardar.Enabled = true;
            tbNombre.Enabled = true;
        }
        public byte[] GuardarImagenEnBytes(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
                return null;
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void frmFrame_Load(object sender, EventArgs e)
        {
           
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (pbVideo.Image == null)
            {
                MessageBox.Show("No hay imagen para guardar");
                return;
            }

            string connectionString = "server=localhost;database=bdpractica;uid=root;pwd=rootroot;";

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    string query = "INSERT INTO fotos (Nombre, Bits) VALUES (@nombre, @foto)";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", tbNombre.Text);

                        byte[] imagenBytes = GuardarImagenEnBytes(pbVideo);
                        cmd.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = imagenBytes;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Imagen guardada con éxito");
                pbVideo.Image = null;
                tbNombre.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message);
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmDatagrid datagrid = new frmDatagrid();
            datagrid.Show();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            ActivarCamara();
        }

        private void btnCaptura_Click(object sender, EventArgs e)
        {
            if (pbVideo.Image != null)
            {
                DetenerCamara();
                btnActivar.Enabled = true;
                btnCaptura.Enabled = false;
            }
        }
    }
}
