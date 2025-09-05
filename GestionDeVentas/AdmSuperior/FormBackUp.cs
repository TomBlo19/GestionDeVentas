using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;



namespace GestionDeVentas.AdmSuperior
{
    public partial class FormBackup : Form
    {
        // Carpeta por defecto a respaldar (ajústala si tu DB/archivos están en otra carpeta)
        private string defaultSourceFolder =
            Path.Combine(Application.StartupPath, "Data"); // ej: ...\bin\Debug\Data

        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            // Pre-cargamos la carpeta de origen si existe
            if (Directory.Exists(defaultSourceFolder))
                txtCarpetaOrigen.Text = defaultSourceFolder;
        }

        private void btnElegirOrigen_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Selecciona la carpeta a respaldar (BD, imágenes, etc.)";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtCarpetaOrigen.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnCrearBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string source = txtCarpetaOrigen.Text?.Trim();
                if (string.IsNullOrWhiteSpace(source) || !Directory.Exists(source))
                {
                    MessageBox.Show("Selecciona una carpeta de origen válida.", "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Title = "Guardar BackUp";
                    sfd.Filter = "Archivo ZIP (*.zip)|*.zip";
                    sfd.FileName = $"Backup_GestionDeVentas_{DateTime.Now:yyyyMMdd_HHmm}.zip";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string tempZip = sfd.FileName;

                        // Si existe, lo reemplazamos
                        if (File.Exists(tempZip))
                            File.Delete(tempZip);

                        ZipFile.CreateFromDirectory(source, tempZip, CompressionLevel.Optimal, includeBaseDirectory: true);

                        MessageBox.Show("BackUp creado correctamente.", "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando el BackUp:\n" + ex.Message, "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                string destino = txtCarpetaOrigen.Text?.Trim();
                if (string.IsNullOrWhiteSpace(destino))
                {
                    MessageBox.Show("Indica la carpeta destino donde restaurar.", "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Selecciona un BackUp (.zip)";
                    ofd.Filter = "Archivo ZIP (*.zip)|*.zip";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // Confirmación
                        if (MessageBox.Show(
                            "Se restaurarán los archivos sobre la carpeta destino.\n¿Deseas continuar?",
                            "Confirmar restauración",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes)
                            return;

                        // Creamos carpeta si no existe
                        Directory.CreateDirectory(destino);

                        // Extraer a carpeta temporal y luego copiar (para evitar bloquear archivos en uso)
                        string tempDir = Path.Combine(Path.GetTempPath(), "GV_Restore_" + Guid.NewGuid().ToString("N"));
                        Directory.CreateDirectory(tempDir);

                        ZipFile.ExtractToDirectory(ofd.FileName, tempDir);

                        CopiarDirectorio(tempDir, destino, overwrite: true);

                        // Limpieza
                        Directory.Delete(tempDir, recursive: true);

                        MessageBox.Show("Restauración completada.", "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restaurando el BackUp:\n" + ex.Message, "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CopiarDirectorio(string sourceDir, string destDir, bool overwrite)
        {
            foreach (var dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                string target = dir.Replace(sourceDir, destDir);
                Directory.CreateDirectory(target);
            }

            foreach (var file in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
            {
                string target = file.Replace(sourceDir, destDir);
                Directory.CreateDirectory(Path.GetDirectoryName(target));
                File.Copy(file, target, overwrite);
            }
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario BackUp
        }

    }
}
