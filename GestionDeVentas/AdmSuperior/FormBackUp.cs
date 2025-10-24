using System;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using GestionDeVentas.Datos; // Importa tu clase de conexión

namespace GestionDeVentas.AdmSuperior
{
    public partial class FormBackup : Form
    {
        private string defaultSourceFolder = Path.Combine(Application.StartupPath, "Data");

        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(defaultSourceFolder))
                txtCarpetaOrigen.Text = defaultSourceFolder;
        }

        // --- ELEGIR CARPETA A RESPALDAR ---
        private void btnElegirOrigen_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Selecciona la carpeta a respaldar (archivos, imágenes, etc.)";
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtCarpetaOrigen.Text = dlg.SelectedPath;
            }
        }

        // --- BACKUP DE ARCHIVOS DEL SISTEMA (.ZIP) ---
        private void btnCrearBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string source = txtCarpetaOrigen.Text?.Trim();
                if (string.IsNullOrWhiteSpace(source) || !Directory.Exists(source))
                {
                    MessageBox.Show("Selecciona una carpeta de origen válida.", "BackUp",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string carpetaDestino = @"C:\Backups_TYV";

                Directory.CreateDirectory(carpetaDestino);

                string rutaZip = Path.Combine(carpetaDestino, $"Backup_TYV_{DateTime.Now:yyyyMMdd_HHmm}.zip");

                if (File.Exists(rutaZip))
                    File.Delete(rutaZip);

                ZipFile.CreateFromDirectory(source, rutaZip, CompressionLevel.Optimal, includeBaseDirectory: true);

                MessageBox.Show($"✅ Backup de archivos creado correctamente:\n{rutaZip}",
                    "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creando el BackUp:\n" + ex.Message,
                    "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BACKUP DE BASE DE DATOS SQL SERVER (.BAK) ---
        private void btnBackupBD_Click(object sender, EventArgs e)
        {
            try
            {
                // 📂 Carpeta de destino del backup (SQL Server tiene permiso en C:\)
                string carpetaDestino = @"C:\Backups_TYV";
                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                // 📄 Nombre del archivo con fecha y hora
                string nombreArchivo = $"bd_BarberoBolo_{DateTime.Now:yyyyMMdd_HHmm}.bak";
                string rutaBackup = Path.Combine(carpetaDestino, nombreArchivo);

                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();

                    // Cambiamos a master antes del backup
                    using (SqlCommand cmdUse = new SqlCommand("USE master;", conn))
                    {
                        cmdUse.ExecuteNonQuery();
                    }

                    // Comando SQL que crea el backup
                    string query = $@"
                BACKUP DATABASE bd_BarberoBolo
                TO DISK = '{rutaBackup}'
                WITH INIT, FORMAT, NAME = 'Backup TYV CLOTHES';";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"✅ Backup de base de datos completado correctamente:\n{rutaBackup}",
                    "Backup BD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al crear backup de la BD:\n{ex.Message}",
                    "Backup BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --- RESTAURAR BACKUP DE BASE DE DATOS (.BAK) ---
        private void btnRestaurarBD_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Selecciona un archivo de Backup de BD (.bak)";
                    ofd.Filter = "Archivos BAK (*.bak)|*.bak";
                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;

                    string rutaBackup = ofd.FileName;

                    using (SqlConnection conn = ConexionBD.ObtenerConexion())
                    {
                        conn.Open();

                        // Desconectamos usuarios y restauramos la BD
                        string query = $@"
                            USE master;
                            ALTER DATABASE bd_BarberoBolo SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                            RESTORE DATABASE bd_BarberoBolo 
                            FROM DISK = '{rutaBackup}' 
                            WITH REPLACE;
                            ALTER DATABASE bd_BarberoBolo SET MULTI_USER;";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("♻️ Restauración de base de datos completada correctamente.",
                        "Restauración BD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al restaurar la base de datos:\n{ex.Message}",
                    "Restauración BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- RESTAURAR BACKUP DE ARCHIVOS (.ZIP) ---
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                string destino = txtCarpetaOrigen.Text?.Trim();
                if (string.IsNullOrWhiteSpace(destino))
                {
                    MessageBox.Show("Indica la carpeta destino donde restaurar.", "Restauración",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Selecciona un BackUp (.zip)";
                    ofd.Filter = "Archivo ZIP (*.zip)|*.zip";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show(
                            "Se restaurarán los archivos sobre la carpeta destino.\n¿Deseas continuar?",
                            "Confirmar restauración",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes)
                            return;

                        Directory.CreateDirectory(destino);

                        string tempDir = Path.Combine(Path.GetTempPath(), "GV_Restore_" + Guid.NewGuid().ToString("N"));
                        Directory.CreateDirectory(tempDir);

                        ZipFile.ExtractToDirectory(ofd.FileName, tempDir);

                        CopiarDirectorio(tempDir, destino, overwrite: true);
                        Directory.Delete(tempDir, recursive: true);

                        MessageBox.Show("♻️ Restauración de archivos completada correctamente.",
                            "Restauración Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error restaurando el BackUp:\n" + ex.Message,
                    "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- UTILIDAD PARA COPIAR DIRECTORIOS ---
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
