using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Practica_ETL
{
    public partial class frmDatagrid : Form
    {
        private int currentPage = 0;
        private readonly int pageSize = 10;
        private int totalRows = 0;
        private int totalPages = 0;
        private readonly string connStr = "Server=127.0.0.1;Uid=root;Pwd=rootroot;Database=bdpractica;";
        public frmDatagrid()
        {
            InitializeComponent();
            AplicarEstilo();
        }
        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.Text = "Galería de Fotos";
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarDataGridView(dgFotos);
            Estilos.EstilizarPictureBox(pbFoto);
            Estilos.EstilizarLabel(lblTitulo, esTitulo: true);
            Estilos.EstilizarLabel(lblIdFoto, esTitulo: false);
            Estilos.EstilizarLabel(lblNombreFoto, esTitulo: false);
            Estilos.EstilizarBoton(btnPrev, "◀️");
            Estilos.EstilizarBoton(btnNext, "▶️");
            Estilos.EstilizarTextBox(tbPagina);
        }
        private async Task<int> GetTotalRowsAsync()
        {
            return await Task.Run(() =>
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM fotos", conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            });
        }

        private async Task LoadPageAsync(int page)
        {
            btnNext.Enabled = btnPrev.Enabled = false;
            int offset = page * pageSize;

            DataTable dt = await Task.Run(() =>
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT Id, Nombre FROM fotos ORDER BY Id LIMIT @limit OFFSET @offset";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@limit", pageSize);
                        cmd.Parameters.AddWithValue("@offset", offset);
                        using (var da = new MySqlDataAdapter(cmd))
                        {
                            var table = new DataTable();
                            da.Fill(table);
                            return table;
                        }
                    }
                }
            });

            dgFotos.DataSource = dt;

            if (dgFotos.Columns.Contains("Id"))
            {
                dgFotos.Columns["Id"].Width = 60;
                dgFotos.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            if (dgFotos.Columns.Contains("Nombre"))
            {
                dgFotos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            tbPagina.Text = $"Página {currentPage + 1} / {totalPages}";
            btnNext.Enabled = (currentPage + 1) < totalPages;
            btnPrev.Enabled = currentPage > 0;

            if (dgFotos.Rows.Count > 0)
                dgFotos.Rows[0].Selected = true;
        }

        private async void frmDatagrid_Load(object sender, EventArgs e)
        {

            totalRows = await GetTotalRowsAsync();
            totalPages = Math.Max(1, (totalRows + pageSize - 1) / pageSize);
            currentPage = 0;
            await LoadPageAsync(currentPage);
        }
       

        private async void dgFotos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgFotos.SelectedRows.Count == 0) return;

            try
            {
                int id = Convert.ToInt32(dgFotos.SelectedRows[0].Cells["Id"].Value);
                string nombre = dgFotos.SelectedRows[0].Cells["Nombre"].Value?.ToString() ?? "";
                lblNombreFoto.Text = $"📝 Nombre: {nombre}";
                lblIdFoto.Text = $"🔢 ID: {id}";

                byte[] imagenBytes = await Task.Run(() =>
                {
                    using (var conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string sql = "SELECT Bits FROM fotos WHERE Id = @id";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
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
                        pbFoto.Image?.Dispose();
                        pbFoto.Image = new Bitmap(imgOriginal);
                        imgOriginal.Dispose();
                    }
                }
                else
                {
                    pbFoto.Image?.Dispose();
                    pbFoto.Image = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando imagen: {ex.Message}");
                pbFoto.Image = null;
            }
        }

        private async void btnNext_Click_1(object sender, EventArgs e)
        {
            if (currentPage + 1 < totalPages)
            {
                currentPage++;
                await LoadPageAsync(currentPage);
            }
        }
        private async void btnPrev_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                await LoadPageAsync(currentPage);
            }
        }

        private void tbPagina_TextChanged(object sender, EventArgs e)
        {

        }
    }
}