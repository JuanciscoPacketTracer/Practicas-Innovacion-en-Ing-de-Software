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
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

namespace Practica_ETL
{
    public partial class frmProductos : Form
    {
        PrintDocument printDoc = new PrintDocument();
        List<ProductoEtiqueta> listaProductos = new List<ProductoEtiqueta>();
        int indiceImpresion = 0;
        class ProductoEtiqueta
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Precio { get; set; }
            public Image Imagen { get; set; }
        }

        private Image ObtenerImagenProducto(string codigoProducto)
        {
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                string query = "SELECT ImagenProducto FROM productos WHERE CodigoProducto = @codigo";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@codigo", codigoProducto);
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        byte[] bytes = (byte[])resultado;
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                }
            }

            return null;
        }
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle area = e.MarginBounds;
            int y = area.Top;
            int separacion = 15;
            int altoEtiqueta = 130;

            using (Font fontTitulo = new Font("Times New Roman", 12, FontStyle.Bold))
            using (Font fontTexto = new Font("Times New Roman", 10))
            {
                while (indiceImpresion < listaProductos.Count)
                {
                    if (y + altoEtiqueta > area.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    var prod = listaProductos[indiceImpresion];
                    Rectangle etiquetaRect = new Rectangle(area.Left, y, area.Width, altoEtiqueta);
                    e.Graphics.DrawRectangle(Pens.Black, etiquetaRect);

                    e.Graphics.DrawString(prod.Nombre, fontTitulo, Brushes.Black, etiquetaRect.Left + 10, etiquetaRect.Top + 8);
                    e.Graphics.DrawString("$ " + prod.Precio, fontTexto, Brushes.Black, etiquetaRect.Left + 10, etiquetaRect.Top + 32);

                    if (prod.Imagen != null)
                    {
                        Rectangle rectImagen = new Rectangle(etiquetaRect.Right - 95, etiquetaRect.Top + 8, 80, 50);
                        var modoAnterior = e.Graphics.InterpolationMode;
                        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        e.Graphics.DrawImage(prod.Imagen, rectImagen);
                        e.Graphics.InterpolationMode = modoAnterior;
                    }

                    var writer = new BarcodeWriter<Bitmap>()
                    {
                        Format = BarcodeFormat.CODE_128,
                        Options = new EncodingOptions
                        {
                            Width = 260,
                            Height = 55,
                            Margin = 2,
                            PureBarcode = true
                        },
                        Renderer = new BitmapRenderer()
                    };

                    using (Bitmap codigo = writer.Write(prod.Codigo))
                    {
                        int xCodigo = etiquetaRect.Left + (etiquetaRect.Width - codigo.Width) / 2;
                        int yCodigo = etiquetaRect.Top + 50;
                        e.Graphics.DrawImage(codigo, xCodigo, yCodigo, codigo.Width, codigo.Height);
                    }

                    e.Graphics.DrawString(prod.Codigo, fontTexto, Brushes.Black, etiquetaRect.Left + 10, etiquetaRect.Bottom - 18);

                    y += altoEtiqueta + separacion;
                    indiceImpresion++;
                }
            }

            indiceImpresion = 0;
            e.HasMorePages = false;
        }
        string connectionString = "Server=127.0.0.1;Database=bdpractica;Uid=root;Pwd=rootroot;";
        public frmProductos()
        {
            InitializeComponent();
            AplicarEstilo();
        }

        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.Text = "Productos";
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarTabControl(tcInicio);
            tabPage1.Text = "📋 Inventario";
            tabPage2.Text = "➕ Registro";
            tabPage3.Text = "🖨️ Imprimir";
            tabPage4.Text = "🔁 Actualizar";
            Estilos.EstilizarLabel(label1, esTitulo: false);
            Estilos.EstilizarLabel(label2, esTitulo: false);
            Estilos.EstilizarLabel(label3, esTitulo: false);
            Estilos.EstilizarLabel(label4, esTitulo: false);
            Estilos.EstilizarLabel(label5, esTitulo: false);
            Estilos.EstilizarLabel(label6, esTitulo: false);
            Estilos.EstilizarLabel(label7, esTitulo: false);
            Estilos.EstilizarLabel(label8, esTitulo: false);
            Estilos.EstilizarLabel(label9, esTitulo: false);
            Estilos.EstilizarLabel(label10, esTitulo: false);
            Estilos.EstilizarLabel(label11, esTitulo: false);
            Estilos.EstilizarTextBox(tbCodigo);
            Estilos.EstilizarTextBoxConPlaceholder(tbDescripcion, "Ingrese la descricion del producto");
            Estilos.EstilizarTextBox(tbPrecio);
            Estilos.EstilizarTextBox(tbICodigo);
            Estilos.EstilizarTextBox(tbIDescripcion);
            Estilos.EstilizarTextBox(tbIPrecio);
            Estilos.EstilizarBoton(btnGuardar, "💾 Guardar Producto");
            Estilos.EstilizarBoton(btnImagen, "🖼️ Cargar Imagen");
            Estilos.EstilizarPictureBox(pbImagen);
            Estilos.EstilizarBoton(btnLimpiar, "🗑️ Limpiar DataGrid");
            Estilos.EstilizarBoton(btnImprimir, "🖨️ Imprimir lista");
            Estilos.EstilizarDataGridView(dgProductos);
            Estilos.EstilizarCheckBox(cbImprimir);
            Estilos.EstilizarTextBox(tbACodigo);
            Estilos.EstilizarTextBox(tbADescripcion);
            Estilos.EstilizarTextBox(tbAPrecio);
            Estilos.EstilizarPictureBox(pbAImagen);
            Estilos.EstilizarBoton(btnABuscarProducto, "🔍 Buscar Producto");
            Estilos.EstilizarBoton(btnAActualizar, "🔄 Actualizar");
            Estilos.EstilizarBoton(btnALimpiar, "🧹 Limpiar");
            Estilos.EstilizarBoton(btnABuscarImagen, "🖼️ Cargar Imagen");
        }



        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Seleccionar imagen del producto";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(ofd.FileName);
            }

        }
        public byte[] Imagenbinario(Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var formato = imagen.RawFormat;

                if (formato.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                    imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if (formato.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                    imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                else if (formato.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                    imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                else
                    imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (pbImagen.Image == null)
            {
                MessageBox.Show("No hay imagen para guardar");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbCodigo.Text) || string.IsNullOrWhiteSpace(tbDescripcion.Text) || string.IsNullOrWhiteSpace(tbPrecio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos");
                return;
            }
            connectionString = "server=localhost;database=bdpractica;uid=root;pwd=rootroot;";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "INSERT INTO productos(CodigoProducto, DescripcionProducto, PrecioProducto, ImagenProducto) VALUES (@codigo, @descripcion, @precio, @foto)";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", Convert.ToDecimal(tbCodigo.Text));
                        cmd.Parameters.AddWithValue("@descripcion", tbDescripcion.Text);
                        cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(tbPrecio.Text));
                        cmd.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = Imagenbinario(pbImagen.Image);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }

                MessageBox.Show("Imagen guardada con éxito");
                tbCodigo.Text = "";
                tbDescripcion.Text = "";
                tbPrecio.Text = "";
                pbImagen.Image = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbICodigo.Text = "";
            tbIDescripcion.Text = "";
            tbIPrecio.Text = "";
            dgProductos.Rows.Clear();
            dgProductos.Enabled = true;
            tbICodigo.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            listaProductos.Clear();
            foreach (DataGridViewRow row in dgProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    listaProductos.Add(new ProductoEtiqueta
                    {

                        Codigo = row.Cells[0].Value.ToString(),
                        Nombre = row.Cells[1].Value.ToString(),
                        Precio = row.Cells[2].Value.ToString(),
                        Imagen = ObtenerImagenProducto(row.Cells[0].Value.ToString())
                    });
                }
            }

            if (listaProductos.Count == 0)
            {
                MessageBox.Show("No hay productos para imprimir.");
                return;
            }

            indiceImpresion = 0;
            printDoc.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            printDoc.PrintPage -= PrintDoc_PrintPage;
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog vista = new PrintPreviewDialog();
            vista.Document = printDoc;
            vista.ShowDialog();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }

        private void tbBuscarCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                        string query = "SELECT DescripcionProducto, CodigoProducto, PrecioProducto from productos WHERE CodigoProducto = @codigo";
                        MySqlCommand cmd = new MySqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@codigo", tbICodigo.Text);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            tbIDescripcion.Text = dt.Rows[0]["DescripcionProducto"].ToString();
                            tbIPrecio.Text = dt.Rows[0]["PrecioProducto"].ToString();

                            if (dgProductos.Columns.Count == 0)
                            {
                                dgProductos.Columns.Add("CodigoProducto", "Código");
                                dgProductos.Columns.Add("DescripcionProducto", "Descripción");
                                dgProductos.Columns.Add("PrecioProducto", "Precio");
                            }

                            if (cbImprimir.Checked && tbICodigo.Text != "")
                                dgProductos.Rows.Add(tbICodigo.Text, tbIDescripcion.Text, tbIPrecio.Text);
                            else
                            {
                                dgProductos.Rows.Clear();
                                dgProductos.Rows.Add(tbICodigo.Text, tbIDescripcion.Text, tbIPrecio.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Producto no encontrado");
                            tbIDescripcion.Text = "";
                            tbIPrecio.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el producto: " + ex.Message);
                }
            }
        }

        private void cbImprimir_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImprimir.Checked == false)
            {
                dgProductos.Rows.Clear();
            }
        }

        private void btnABuscarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbACodigo.Text))
            {
                MessageBox.Show("Ingrese el código del producto.");
                tbACodigo.Focus();
                return;
            }

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "SELECT DescripcionProducto, PrecioProducto, ImagenProducto FROM productos WHERE CodigoProducto = @codigo";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", tbACodigo.Text.Trim());
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                tbADescripcion.Text = dr["DescripcionProducto"].ToString();
                                tbAPrecio.Text = dr["PrecioProducto"].ToString();

                                if (dr["ImagenProducto"] != DBNull.Value)
                                {
                                    byte[] imagenBytes = (byte[])dr["ImagenProducto"];
                                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                                    {
                                        pbAImagen.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pbAImagen.Image = null;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Producto no encontrado.");
                                tbADescripcion.Text = "";
                                tbAPrecio.Text = "";
                                pbAImagen.Image = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message);
            }
        }

        private void btnALimpiar_Click(object sender, EventArgs e)
        {
            tbACodigo.Text = "";
            tbADescripcion.Text = "";
            tbAPrecio.Text = "";
            pbAImagen.Image = null;
            tbACodigo.Focus();
        }

        private void btnAActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbACodigo.Text) || string.IsNullOrWhiteSpace(tbADescripcion.Text) || string.IsNullOrWhiteSpace(tbAPrecio.Text))
            {
                MessageBox.Show("Complete código, descripción y precio para actualizar.");
                return;
            }

            decimal precio;
            if (!decimal.TryParse(tbAPrecio.Text, out precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                tbAPrecio.Focus();
                return;
            }

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "UPDATE productos SET DescripcionProducto = @descripcion, PrecioProducto = @precio, ImagenProducto = @imagen WHERE CodigoProducto = @codigo";
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", tbACodigo.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", tbADescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@precio", precio);

                        if (pbAImagen.Image != null)
                            cmd.Parameters.Add("@imagen", MySqlDbType.LongBlob).Value = Imagenbinario(pbAImagen.Image);
                        else
                            cmd.Parameters.Add("@imagen", MySqlDbType.LongBlob).Value = DBNull.Value;

                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                            MessageBox.Show("Producto actualizado correctamente.");
                        else
                            MessageBox.Show("No se encontró un producto con ese código.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
            }
        }

        private void btnABuscarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Seleccionar nueva imagen del producto";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbAImagen.Image = Image.FromFile(ofd.FileName);
            }
        }

        private async void dgMProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgMProductos.SelectedRows.Count == 0) return;

            try
            {
                int cod = Convert.ToInt32(dgMProductos.SelectedRows[0].Cells["CodigoProducto"].Value);
                string desc = dgMProductos.SelectedRows[0].Cells["DescripcionProducto"].Value?.ToString() ?? "";
                decimal precio = Convert.ToDecimal(dgMProductos.SelectedRows[0].Cells["PrecioProducto"].Value);
                lblMDescripcion.Text = $"📝 Descripcion: {desc}";
                lblMCodigo.Text = $"🔢 Codigo: {cod}";
                lblMPrecio.Text = $"💰 Precio:  {precio}";

                byte[] imagenBytes = await Task.Run(() =>
                {
                    using (var conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string sql = "SELECT ImagenProducto FROM productos WHERE CodigoProducto = @codigo";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@codigo", cod);
                            var result = cmd.ExecuteScalar();
                            return result != DBNull.Value ? (byte[])result : null;
                        }
                    }
                });

                if (imagenBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        Image imgOriginal = Image.FromStream(ms);
                        pbMFoto.Image?.Dispose();
                        pbMFoto.Image = new Bitmap(imgOriginal);
                        imgOriginal.Dispose();
                    }
                }
                else
                {
                    pbMFoto.Image?.Dispose();
                    pbMFoto.Image = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando imagen: {ex.Message}");
                pbMFoto.Image = null;
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                await LoadPageAsync(currentPage);
            }
            
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage + 1 < totalPages)
            {
                currentPage++;
                await LoadPageAsync(currentPage);
            }
        }
    }
}
