using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica_ETL
{
    public partial class frmETL : Form
    {
        private int currentPage = 0;
        private int pageSize = 100;
        private int totalRows = 0;
        private int totalPages = 0;
        private readonly string connStr = "Server=127.0.0.1;Uid=root;Pwd=rootroot;Database=bdpractica;";
        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            Estilos.EstilizarBoton(btnProceso, "⚙️ Procesar");
            Estilos.EstilizarBoton(btnBuscar, "📂 Buscar");
            Estilos.EstilizarBoton(btnPrev, "◀️");
            Estilos.EstilizarBoton(btnNext, "▶️");
            Estilos.EstilizarBoton(btnLimpiar, "🗑️ Limpiar base de datos", esPeligro: true);
            Estilos.EstilizarDataGridView(dataGridView1);
            Estilos.EstilizarTextBoxConPlaceholder(tbRuta, "Ruta del archivo CSV...");
            Estilos.EstilizarTextBox(tbPagina);
        }
        public frmETL()
        {
            InitializeComponent();
            AplicarEstilo();
        }

        private async Task<int> GetTotalRowsAsync()
        {
            return await Task.Run(() =>
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Clientes", conn))
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
                    string sql = "SELECT id, Nombre, Correo, Edad FROM Clientes ORDER BY Id LIMIT @limit OFFSET @offset";
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

            dataGridView1.DataSource = dt;
            tbPagina.Text = $"Pagina {currentPage + 1} / {totalPages}";
            btnNext.Enabled = (currentPage + 1) < totalPages;
            btnPrev.Enabled = currentPage > 0;
        }

        private async void btnProceso_Click(object sender, EventArgs e)
        {
            try
            {
                btnProceso.Enabled = btnBuscar.Enabled = btnNext.Enabled = btnPrev.Enabled = false;
                var datosExtraidos = Extract.LeerCSV(tbRuta.Text);
                var datosTransformados = Transform.LimpiarDatos(datosExtraidos);
                await Task.Run(() => Cargar.InsertarClientes(datosTransformados));
                totalRows = await GetTotalRowsAsync();
                totalPages = Math.Max(1, (totalRows + pageSize - 1) / pageSize);
                currentPage = 0;
                await LoadPageAsync(currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnProceso.Enabled = btnBuscar.Enabled = true;
                btnNext.Enabled = (currentPage + 1) < totalPages;
                btnPrev.Enabled = currentPage > 0;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = "c:\\";
            of.Filter = "Archivos de csv| *. csv; ";
            try
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    tbRuta.Text = of.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    private async void Form1_Load(object sender, EventArgs e)
        {
            pageSize = 100; 
            totalRows = await GetTotalRowsAsync();
            totalPages = Math.Max(1, (totalRows + pageSize - 1) / pageSize);
            currentPage = 0;
            await LoadPageAsync(currentPage);
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                await LoadPageAsync(currentPage);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("¿Eliminar todos los registros de la tabla Clientes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes)
            {
                return;
            }
            _ = ClearAllAsync();
        }

        private async Task ClearAllAsync()
        {
            try
            {
                btnLimpiar.Enabled = btnProceso.Enabled = btnBuscar.Enabled = btnNext.Enabled = btnPrev.Enabled = false;

                await Task.Run(() =>
                {
                    using (var conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        using (var cmd = new MySqlCommand("DELETE FROM Clientes", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                });

                totalRows = await GetTotalRowsAsync();
                totalPages = Math.Max(1, (totalRows + pageSize - 1) / pageSize);
                currentPage = 0;
                await LoadPageAsync(currentPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnLimpiar.Enabled = true;
                btnProceso.Enabled = btnBuscar.Enabled = true;
                btnNext.Enabled = (currentPage + 1) < totalPages;
                btnPrev.Enabled = currentPage > 0;
            }
        }
    }
}
