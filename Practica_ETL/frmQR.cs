using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Common;
using BarcodeWriter = ZXing.Windows.Compatibility.BarcodeWriter;
namespace Practica_ETL
{
    public partial class frmQR : Form
    {

        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            Estilos.EstilizarTabControl(tcEmpleado);
            tpGuardar.Text = "📁 Guardar";
            tpImprimir.Text = "🖨️ Imprimir";
            tpQR.Text = "🖼️ QR";
            Estilos.EstilizarTextBoxConPlaceholder(tbGNoEmpleado, "Introduzca No. de Empleado");
            Estilos.EstilizarTextBoxConPlaceholder(tbGNombre, "Introduzca Nombre del Empleado");
            Estilos.EstilizarTextBoxConPlaceholder(tbGApellido, "Introduzca Apellido del Empleado");
            Estilos.EstilizarTextBox(tbINoEmpleado);
            Estilos.EstilizarTextBox(tbINombre);
            Estilos.EstilizarTextBox(tbIApellido);
            Estilos.EstilizarBoton(btnCargar, "📂 Cargar Imagen");
            Estilos.EstilizarBoton(btnConsultar, "🔍 Consultar Empleado");
            Estilos.EstilizarBoton(btnImprimir, "🖨️ Imprimir Credencial");
            Estilos.EstilizarBoton(btnGuardar, "📁 Guardar Empleado");
            Estilos.EstilizarLabel(label1, false);
            Estilos.EstilizarLabel(label2, false);
            Estilos.EstilizarLabel(label3, false);
            Estilos.EstilizarLabel(label4, false);
            Estilos.EstilizarLabel(label5, false);
            Estilos.EstilizarLabel(label6, false);
            Estilos.EstilizarLabel(label7, false);
            Estilos.EstilizarLabel(label8, false);
            Estilos.EstilizarLabel(label9, false);
            Estilos.EstilizarPictureBox(pbIQR);
            Estilos.EstilizarPictureBox(pbLQR);
            Estilos.EstilizarTextBox(tbLApellido);
            Estilos.EstilizarTextBox(tbLNombre);
            Estilos.EstilizarTextBox(tbLNoEmpleado);
            Estilos.EstilizarBoton(btnLeer, "📷 Leer QR");
        }
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int x = 50, y = 50, width = 380, height = 220;
            int padding = 12;

            Rectangle card = new Rectangle(x, y, width, height);
            using (Brush bg = new SolidBrush(Color.White))
            using (Pen border = new Pen(Color.FromArgb(60, 60, 60), 2))
            {
                g.FillRectangle(bg, card);
                g.DrawRectangle(border, card);
            }
            using (Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold))
            using (Brush headerBrush = new SolidBrush(Color.Black))
            {
                g.DrawString("CREDENCIAL", headerFont, headerBrush, x + padding, y + padding);
            }
            g.DrawLine(Pens.LightGray, x + padding, y + 35, x + width - padding, y + 35);

            int contentY = y + 45;
            int imgSize = 90;
            if (pbIQR.Image != null)
            {
                g.DrawRectangle(Pens.LightGray, x + padding, contentY, imgSize, imgSize);
                g.DrawImage(pbIQR.Image, x + padding, contentY, imgSize, imgSize);
            }

            int textX = x + padding + imgSize + 15;

            using (Font labelFont = new Font("Segoe UI", 8, FontStyle.Bold))
            using (Font valueFont = new Font("Segoe UI", 9, FontStyle.Regular))
            using (Brush labelBrush = new SolidBrush(Color.Gray))
            using (Brush valueBrush = new SolidBrush(Color.Black))
            {
                int lineSpacing = 22;

                g.DrawString("No. Empleado", labelFont, labelBrush, textX, contentY);
                g.DrawString(tbINoEmpleado.Text ?? "-", valueFont, valueBrush, textX, contentY + 12);

                g.DrawString("Nombre", labelFont, labelBrush, textX, contentY + lineSpacing);
                g.DrawString(tbINombre.Text ?? "-", valueFont, valueBrush, textX, contentY + lineSpacing + 12);

                g.DrawString("Apellido", labelFont, labelBrush, textX, contentY + lineSpacing * 2);
                g.DrawString(tbIApellido.Text ?? "-", valueFont, valueBrush, textX, contentY + lineSpacing * 2 + 12);
            }
            int qrSize = 85;
            Rectangle qrRect = new Rectangle(x + width - qrSize - padding, y + height - qrSize - padding, qrSize, qrSize);

            using (Pen qrBorder = new Pen(Color.Gray, 1))
            {
                g.DrawRectangle(qrBorder, qrRect);
            }

            if (qrImage != null)
            {
                g.DrawImage(qrImage, qrRect);
            }
        }

        public frmQR()
        {
            InitializeComponent();
            AplicarEstilo();
        }
        string connectionString = "server=localhost;database=bdpractica;uid=root;pwd=rootroot;";
        PrintDocument printDoc = new PrintDocument();
        Bitmap qrImage;
        private Bitmap GenerarQR(string texto)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = new EncodingOptions
            {
                Width = 150,
                Height = 150,
                Margin = 1
            };
            return writer.Write(texto);
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGNoEmpleado.Text) || string.IsNullOrWhiteSpace(tbGNombre.Text) || string.IsNullOrWhiteSpace(tbGApellido.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }
            
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "INSERT INTO `empleados`(`NoEmpleado`, `NombreEmpleado`, `ApellidoEmpleado`) VALUES (@no, @nombre, @apellido)";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@no", Convert.ToInt32(tbGNoEmpleado.Text));
                        cmd.Parameters.AddWithValue("@nombre", tbGNombre.Text);
                        cmd.Parameters.AddWithValue("@apellido", tbGApellido.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Empleado guardado con éxito");
                tbGNoEmpleado.Text = "";
                tbGNombre.Text = "";
                tbGApellido.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el empleado: " + ex.Message);
            }
        }

        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private readonly BarcodeReader _lector = new BarcodeReader();
        private volatile bool _decoding;

        private void IniciarCamara()
        {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (_videoDevices == null || _videoDevices.Count == 0)
            {
                MessageBox.Show("No camera device found.");
                return;
            }
            _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _videoSource.NewFrame += Video_NewFrame;
            _videoSource.Start();
        }

        private void DetenerCamara()
        {
            if (_videoSource == null) return;

            _videoSource.NewFrame -= Video_NewFrame;

            if (_videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
                _videoSource.WaitForStop();
            }

            _videoSource = null;
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap previewFrame = null;
            Bitmap decodeFrame = null;

            try
            {
                previewFrame = (Bitmap)eventArgs.Frame.Clone();
                if (pbLQR.IsHandleCreated)
                {
                    pbLQR.BeginInvoke((Action)(() =>
                    {
                        var old = pbLQR.Image;
                        pbLQR.Image = (Bitmap)previewFrame.Clone();
                        if (old != null) old.Dispose();
                    }));
                }
                if (_decoding) return;
                _decoding = true;

                decodeFrame = (Bitmap)previewFrame.Clone();
                var result = _lector.Decode(decodeFrame);

                if (result != null && !string.IsNullOrWhiteSpace(result.Text))
                {
                    var qrResultado = result.Text;

                    if (IsHandleCreated)
                    {
                        BeginInvoke((Action)(() =>
                        {
                            DetenerCamara();
                            ConsultarEmpleadoPorQr(qrResultado);
                        }));
                    }
                }
            }
            catch
            {
                // log
            }
            finally
            {
                if (decodeFrame != null) decodeFrame.Dispose();
                if (previewFrame != null) previewFrame.Dispose();
                _decoding = false;
            }
        }

        private void ConsultarEmpleadoPorQr(string qrResultado)
        {
            tbLNoEmpleado.Text = "";
            tbLNombre.Text = "";
            tbLApellido.Text = "";

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "SELECT `NoEmpleado`, `NombreEmpleado`, `ApellidoEmpleado` FROM `empleados` WHERE `NoEmpleado` = @NoEmpleado";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@NoEmpleado", qrResultado);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                tbLNoEmpleado.Text = dt.Rows[0]["NoEmpleado"].ToString();
                                tbLNombre.Text = dt.Rows[0]["NombreEmpleado"].ToString();
                                tbLApellido.Text = dt.Rows[0]["ApellidoEmpleado"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Empleado no encontrado");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message);
            }
        }
        private void frmQR_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DetenerCamara();
            base.OnFormClosing(e);
        }

        private void tbGNoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tpGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Imagen| *. jpg; *. png; *. jpeg";
            if (abrir.ShowDialog() == DialogResult.OK)
            {

                pbIQR.Image = Image.FromFile(abrir.FileName);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            qrImage = GenerarQR(tbINoEmpleado.Text);

            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();
        }

        private void tbINoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                try
                {
                    using (MySqlConnection cn = new MySqlConnection(connectionString))
                    {
                        string query = "SELECT `NoEmpleado`, `NombreEmpleado`, `ApellidoEmpleado` FROM `empleados` WHERE NoEmpleado = @NoEmpleado";
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@NoEmpleado", tbINoEmpleado.Text);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            tbINombre.Text = dt.Rows[0]["NombreEmpleado"].ToString();
                            tbIApellido.Text = dt.Rows[0]["ApellidoEmpleado"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Empleado no encontrado");
                            tbINombre.Text = "";
                            tbIApellido.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el empleado: " + ex.Message);
                }
            }
        }
        private void btnLeer_Click(object sender, EventArgs e)
        {
            IniciarCamara();
        }
    }
}
