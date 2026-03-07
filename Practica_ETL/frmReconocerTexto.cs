using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Practica_ETL
{
    public partial class frmReconocerTexto : Form
    {
        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarBoton(btnCarga, "🖼️ Cargar Imagen");
            Estilos.EstilizarBoton(btnProcesamiento, "⚙️ Procesar Texto");
            Estilos.EstilizarBoton(btnGuardar, "💾 Guardar Texto");
            Estilos.EstilizarComboBox(cbIdioma);
            Estilos.EstilizarTextBox(tbTexto);
            Estilos.EstilizarLabel(lblIdioma);
            Estilos.EstilizarPictureBox(pbImagen);

        }
        public frmReconocerTexto()
        {
            InitializeComponent();
            AplicarEstilo();
            cbIdioma.SelectedIndex = 0;
            btnProcesamiento.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void frmReconocerTexto_Load(object sender, EventArgs e)
        {

        }
        string rutaImagen;

        private void btnCarga_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagen = ofd.FileName;
                    pbImagen.Image = Image.FromFile(rutaImagen);
                    if (pbImagen.Image != null)
                    {
                        btnProcesamiento.Enabled = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
        }

        private void btnProcesamiento_Click(object sender, EventArgs e)
        {
            string idioma = "";
            if (cbIdioma.SelectedIndex == 0) { idioma = "spa"; }
            else if (cbIdioma.SelectedIndex == 1) { idioma = "eng"; }
            else if (cbIdioma.SelectedIndex == 2) { idioma = "fra"; }
            else if (cbIdioma.SelectedIndex == 3) { idioma = "jpn"; }
            try
            {
                using (var engine = new TesseractEngine(
                    "C:/Users/JUAN2/source/repos/Practica_ETL/Practica_ETL/bin/modelos", idioma, EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(rutaImagen))
                    {
                        using (var page = engine.Process(img))
                        {
                            string textoReconocido = page.GetText();
                            tbTexto.Text = textoReconocido;
                        }

                    }
                }
                if (tbTexto.Text != "")
                    btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la imagen: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rutaarchivo = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos de texto|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rutaarchivo = sfd.FileName;
                try
                {
                    System.IO.File.WriteAllText(rutaarchivo, tbTexto.Text);
                    MessageBox.Show("Archivo guardado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }
    }
}
