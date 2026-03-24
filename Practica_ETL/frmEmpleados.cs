using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

namespace Practica_ETL
{
    public partial class frmEmpleados : Form
    {
        private PrintDocument printDoc = new PrintDocument();
        private Bitmap qrImage = null;

        public frmEmpleados()
        {
            InitializeComponent();
            AplicarEstilo();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.Text = "Empleados";
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarLabel(lblTitulo, esTitulo: true);
            Estilos.EstilizarLabel(lblNoEmpleado, esTitulo: false);
            Estilos.EstilizarLabel(lblNombre, esTitulo: false);
            Estilos.EstilizarLabel(lblApellido, esTitulo: false);
            Estilos.EstilizarLabel(lblFoto, esTitulo: false);
            Estilos.EstilizarLabel(lblQR, esTitulo: false);
            Estilos.EstilizarTextBox(tbINoEmpleado);
            Estilos.EstilizarTextBox(tbINombre);
            Estilos.EstilizarTextBox(tbIApellido);
            Estilos.EstilizarPictureBox(pbIQR);
            Estilos.EstilizarPictureBox(pbQRPreview);
            Estilos.EstilizarBoton(btnCargarFoto, "📷 Cargar Foto");
            Estilos.EstilizarBoton(btnGenerarQR, "🔲 Generar QR");
            Estilos.EstilizarBoton(btnImprimir, "🖨️ Imprimir Credencial");
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Seleccionar fotografía del empleado";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbIQR.Image = Image.FromFile(ofd.FileName);
                    pbIQR.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            string noEmpleado = tbINoEmpleado.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(noEmpleado))
            {
                MessageBox.Show("Ingrese el número de empleado antes de generar el QR.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string datosQR = $"EMP:{noEmpleado}|{tbINombre.Text?.Trim()}|{tbIApellido.Text?.Trim()}";

            var writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    Width = 200,
                    Height = 200,
                    Margin = 1
                },
                Renderer = new BitmapRenderer()
            };

            qrImage?.Dispose();
            qrImage = writer.Write(datosQR);

            pbQRPreview.Image = qrImage;
            pbQRPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbINoEmpleado.Text) ||
                string.IsNullOrWhiteSpace(tbINombre.Text) ||
                string.IsNullOrWhiteSpace(tbIApellido.Text))
            {
                MessageBox.Show("Complete todos los campos antes de imprimir.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (PrintPreviewDialog vista = new PrintPreviewDialog())
            {
                vista.Document = printDoc;
                vista.ShowDialog();
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Card dimensions and position (centered on page)
            const int cardW = 500;
            const int cardH = 290;
            int cardX = (e.PageBounds.Width - cardW) / 2;
            int cardY = (e.PageBounds.Height - cardH) / 2;
            if (cardY < 50) cardY = 50;

            // Colors
            Color headerTop = Color.FromArgb(15, 52, 96);
            Color headerBot = Color.FromArgb(22, 82, 147);
            Color accentColor = Color.FromArgb(52, 152, 219);
            Color labelColor = Color.FromArgb(44, 62, 80);
            Color valueColor = Color.FromArgb(41, 128, 185);
            Color footerColor = Color.FromArgb(236, 240, 241);
            Color cardBorder = Color.FromArgb(15, 52, 96);

            // --- Card shadow ---
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
            {
                g.FillRectangle(shadowBrush, cardX + 4, cardY + 4, cardW, cardH);
            }

            // --- Card background (rounded rectangle) ---
            const int headerH = 65;
            using (GraphicsPath cardPath = RoundedRect(cardX, cardY, cardW, cardH, 12))
            {
                g.FillPath(Brushes.White, cardPath);
                using (Pen borderPen = new Pen(cardBorder, 2))
                    g.DrawPath(borderPen, cardPath);
            }

            // --- Header section (gradient) ---
            Rectangle headerRect = new Rectangle(cardX, cardY, cardW, headerH);
            GraphicsPath headerPath = RoundedRectTop(cardX, cardY, cardW, headerH, 12);
            using (LinearGradientBrush headerBrush = new LinearGradientBrush(
                headerRect, headerTop, headerBot, LinearGradientMode.Vertical))
            {
                g.FillPath(headerBrush, headerPath);
            }
            headerPath.Dispose();

            using (Font fontTitleBig = new Font("Segoe UI", 14, FontStyle.Bold))
            using (Font fontTitleSmall = new Font("Segoe UI", 8, FontStyle.Regular))
            using (SolidBrush subtitleBrush = new SolidBrush(Color.FromArgb(180, 220, 255)))
            {
                string titleLine1 = "CREDENCIAL DE EMPLEADO";
                string titleLine2 = "Sistema de Identificación Institucional";

                SizeF sz1 = g.MeasureString(titleLine1, fontTitleBig);
                SizeF sz2 = g.MeasureString(titleLine2, fontTitleSmall);

                float textCenterX = cardX + (cardW / 2f) + 20;
                g.DrawString(titleLine1, fontTitleBig, Brushes.White,
                    textCenterX - sz1.Width / 2, cardY + 10);
                g.DrawString(titleLine2, fontTitleSmall, subtitleBrush,
                    textCenterX - sz2.Width / 2, cardY + 38);
            }

            // Accent icon in header left
            using (Pen iconPen = new Pen(Color.FromArgb(180, 255, 255, 255), 2))
            {
                g.DrawEllipse(iconPen, cardX + 15, cardY + 12, 40, 40);
                using (Font iconFont = new Font("Segoe UI", 18, FontStyle.Regular))
                    g.DrawString("👤", iconFont, Brushes.White, cardX + 18, cardY + 14);
            }

            // --- Accent stripe below header ---
            using (LinearGradientBrush stripeBrush = new LinearGradientBrush(
                new Rectangle(cardX, cardY + headerH, cardW, 4),
                accentColor, Color.FromArgb(52, 200, 219), LinearGradientMode.Horizontal))
            {
                g.FillRectangle(stripeBrush, cardX, cardY + headerH, cardW, 4);
            }

            // --- Photo section ---
            int photoX = cardX + 18;
            int photoY = cardY + headerH + 14;
            int photoSize = 110;

            using (GraphicsPath photoClip = RoundedRect(photoX, photoY, photoSize, photoSize, 8))
            {
                g.SetClip(photoClip);

                if (pbIQR.Image != null)
                {
                    g.DrawImage(pbIQR.Image, photoX, photoY, photoSize, photoSize);
                }
                else
                {
                    using (SolidBrush placeholderBgBrush = new SolidBrush(Color.FromArgb(220, 230, 240)))
                        g.FillRectangle(placeholderBgBrush, photoX, photoY, photoSize, photoSize);
                    using (Font placeholderFont = new Font("Segoe UI", 9, FontStyle.Regular))
                    using (Brush placeholderBrush = new SolidBrush(Color.Gray))
                    {
                        SizeF ps = g.MeasureString("Sin foto", placeholderFont);
                        g.DrawString("Sin foto", placeholderFont, placeholderBrush,
                            photoX + (photoSize - ps.Width) / 2,
                            photoY + (photoSize - ps.Height) / 2);
                    }
                }

                g.ResetClip();

                // Photo border
                using (Pen photoBorderPen = new Pen(accentColor, 2.5f))
                    g.DrawPath(photoBorderPen, photoClip);
            }

            // --- Data section ---
            int dataX = cardX + photoSize + 30;
            int dataY = cardY + headerH + 18;

            using (Font fontLabel = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Font fontValue = new Font("Segoe UI", 10, FontStyle.Regular))
            using (SolidBrush labelBrush = new SolidBrush(labelColor))
            using (SolidBrush valueBrush = new SolidBrush(valueColor))
            {
                int lineH = 32;

                // No. Empleado
                DrawDataRow(g, fontLabel, fontValue, labelBrush, valueBrush,
                    "No. Empleado:", tbINoEmpleado.Text ?? "",
                    dataX, dataY, accentColor);

                // Nombre
                DrawDataRow(g, fontLabel, fontValue, labelBrush, valueBrush,
                    "Nombre:", tbINombre.Text ?? "",
                    dataX, dataY + lineH, accentColor);

                // Apellido
                DrawDataRow(g, fontLabel, fontValue, labelBrush, valueBrush,
                    "Apellido:", tbIApellido.Text ?? "",
                    dataX, dataY + lineH * 2, accentColor);
            }

            // --- QR Code ---
            const int qrSize = 90;
            int qrX = cardX + cardW - qrSize - 18;
            int qrY = cardY + headerH + 14;

            if (qrImage != null)
            {
                using (GraphicsPath qrBgPath = RoundedRect(qrX - 4, qrY - 4, qrSize + 8, qrSize + 8, 6))
                {
                    using (SolidBrush qrBgBrush = new SolidBrush(Color.FromArgb(245, 247, 250)))
                        g.FillPath(qrBgBrush, qrBgPath);
                    using (Pen qrBorderPen = new Pen(Color.FromArgb(200, 210, 220), 1))
                        g.DrawPath(qrBorderPen, qrBgPath);
                }
                g.DrawImage(qrImage, qrX, qrY, qrSize, qrSize);
            }
            else
            {
                using (GraphicsPath qrBgPath = RoundedRect(qrX - 4, qrY - 4, qrSize + 8, qrSize + 8, 6))
                {
                    using (SolidBrush qrBgBrush = new SolidBrush(Color.FromArgb(245, 247, 250)))
                        g.FillPath(qrBgBrush, qrBgPath);
                    using (Pen qrBorderPen = new Pen(Color.FromArgb(180, 190, 210), 1.5f))
                        g.DrawPath(qrBorderPen, qrBgPath);
                }
                using (Font qrPlaceholderFont = new Font("Segoe UI", 7))
                using (Brush qrPlaceholderBrush = new SolidBrush(Color.Gray))
                {
                    g.DrawString("QR", qrPlaceholderFont, qrPlaceholderBrush,
                        qrX + 30, qrY + 36);
                }
            }

            // QR label
            using (Font fontQrLabel = new Font("Segoe UI", 6, FontStyle.Regular))
            using (Brush qrLabelBrush = new SolidBrush(Color.Gray))
            {
                SizeF qrLblSz = g.MeasureString("Escanear QR", fontQrLabel);
                g.DrawString("Escanear QR", fontQrLabel, qrLabelBrush,
                    qrX + (qrSize - qrLblSz.Width) / 2, qrY + qrSize + 4);
            }

            // --- Footer ---
            const int footerH = 30;
            int footerY = cardY + cardH - footerH;
            using (GraphicsPath footerPath = RoundedRectBottom(cardX, footerY, cardW, footerH, 12))
            using (SolidBrush footerBgBrush = new SolidBrush(footerColor))
                g.FillPath(footerBgBrush, footerPath);

            using (Pen footerLine = new Pen(Color.FromArgb(200, 210, 220), 1))
                g.DrawLine(footerLine, cardX + 1, footerY, cardX + cardW - 1, footerY);

            using (Font fontFooter = new Font("Segoe UI", 7, FontStyle.Regular))
            using (Brush footerBrush = new SolidBrush(Color.FromArgb(100, 120, 140)))
            {
                string footerLeft = "DOCUMENTO OFICIAL — NO TRANSFERIBLE";
                string footerRight = DateTime.Now.ToString("yyyy");
                SizeF szRight = g.MeasureString(footerRight, fontFooter);
                g.DrawString(footerLeft, fontFooter, footerBrush, cardX + 10, footerY + 8);
                g.DrawString(footerRight, fontFooter, footerBrush,
                    cardX + cardW - szRight.Width - 10, footerY + 8);
            }

            e.HasMorePages = false;
        }

        private void DrawDataRow(Graphics g, Font fontLabel, Font fontValue,
            Brush labelBrush, Brush valueBrush,
            string label, string value, int x, int y, Color accentColor)
        {
            // Small accent dot
            using (SolidBrush dotBrush = new SolidBrush(accentColor))
                g.FillEllipse(dotBrush, x, y + 5, 6, 6);

            g.DrawString(label, fontLabel, labelBrush, x + 12, y);
            SizeF labelSz = g.MeasureString(label, fontLabel);
            g.DrawString(value, fontValue, valueBrush, x + 12 + labelSz.Width + 4, y);
        }
        private static GraphicsPath RoundedRect(int x, int y, int w, int h, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, r * 2, r * 2, 180, 90);
            path.AddArc(x + w - r * 2, y, r * 2, r * 2, 270, 90);
            path.AddArc(x + w - r * 2, y + h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(x, y + h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static GraphicsPath RoundedRectTop(int x, int y, int w, int h, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, r * 2, r * 2, 180, 90);
            path.AddArc(x + w - r * 2, y, r * 2, r * 2, 270, 90);
            path.AddLine(x + w, y + h, x, y + h);
            path.CloseFigure();
            return path;
        }

        private static GraphicsPath RoundedRectBottom(int x, int y, int w, int h, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(x, y, x + w, y);
            path.AddArc(x + w - r * 2, y + h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(x, y + h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
