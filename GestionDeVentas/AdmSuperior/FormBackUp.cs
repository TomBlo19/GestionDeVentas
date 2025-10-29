using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using GestionDeVentas.Datos;

namespace GestionDeVentas.AdmSuperior
{
    public partial class FormBackup : Form
    {
        private string ultimaRutaBackup = string.Empty;

        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            ValidarConexion();
            CargarUltimoBackup();
        }

        // --- Verifica si la conexión a la BD funciona ---
        private void ValidarConexion()
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    
                }
            }
            catch
            {
                
            }
        }

        // --- Muestra la información del último backup ---
        private void CargarUltimoBackup()
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    string query = "IF OBJECT_ID('backup_logs') IS NOT NULL SELECT TOP 1 ruta, fecha_backup FROM backup_logs ORDER BY fecha_backup DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ultimaRutaBackup = dr.GetString(0);
                            DateTime fecha = dr.GetDateTime(1);

                            string infoArchivo = File.Exists(ultimaRutaBackup)
                                ? $"{new FileInfo(ultimaRutaBackup).Length / 1024 / 1024.0:F2} MB"
                                : "archivo no encontrado";

                            lblUltimoBackup.Text =
                                $"🕒 Último backup: {fecha:dd/MM/yyyy HH:mm}\n📁 Archivo: {Path.GetFileName(ultimaRutaBackup)} ({infoArchivo})";
                            btnAbrirCarpeta.Enabled = true;
                        }
                        else
                        {
                            lblUltimoBackup.Text = "🕒 Último backup: sin registros";
                            btnAbrirCarpeta.Enabled = false;
                        }
                    }
                }
            }
            catch
            {
                lblUltimoBackup.Text = "🕒 Último backup: sin registros";
                btnAbrirCarpeta.Enabled = false;
            }
        }

        // --- Permite seleccionar la carpeta de destino ---
        private void btnElegirDestino_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Selecciona la carpeta donde se guardará el backup (.bak/.zip)";
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtDestino.Text = dlg.SelectedPath;
            }
        }

        // --- Ejecuta el backup de la BD ---
        private void btnBackupBD_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                // Carpeta de destino
                string carpetaDestino = string.IsNullOrWhiteSpace(txtDestino.Text)
                    ? @"C:\Backups_TYV"
                    : txtDestino.Text;

                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                // Prueba de escritura
                string test = Path.Combine(carpetaDestino, "test.txt");
                File.WriteAllText(test, "test");
                File.Delete(test);

                // Nombre del archivo
                string nombreArchivo = $"bd_BarberoBolo_{DateTime.Now:yyyyMMdd_HHmm}.bak";
                string rutaBackup = Path.Combine(carpetaDestino, nombreArchivo);

                conn = ConexionBD.ObtenerConexion();
                conn.Open();

                // Crear tabla de logs si no existe
                string createTable = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='backup_logs' AND xtype='U')
                CREATE TABLE backup_logs (
                    id_log INT IDENTITY(1,1) PRIMARY KEY,
                    fecha_backup DATETIME NOT NULL,
                    usuario NVARCHAR(100),
                    ruta NVARCHAR(400),
                    estado NVARCHAR(50),
                    mensaje NVARCHAR(MAX)
                );";
                new SqlCommand(createTable, conn).ExecuteNonQuery();

                // Cambiar al contexto master antes del backup
                new SqlCommand("USE master;", conn).ExecuteNonQuery();

                // --- Comando compatible con SQL Server Express (sin COMPRESSION) ---
                string query = $@"
                BACKUP DATABASE bd_BarberoBolo
                TO DISK = '{rutaBackup}'
                WITH INIT, FORMAT, NAME = 'Backup TYV CLOTHES';";
                new SqlCommand(query, conn).ExecuteNonQuery();

                // Crear ZIP adicional
                string rutaZip = Path.Combine(
                    carpetaDestino,
                    Path.GetFileNameWithoutExtension(nombreArchivo) + ".zip");

                using (FileStream zipToOpen = new FileStream(rutaZip, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(rutaBackup, Path.GetFileName(rutaBackup));
                }

                // Volver al contexto original para registrar el log
                new SqlCommand("USE bd_BarberoBolo;", conn).ExecuteNonQuery();

                string insert = @"INSERT INTO backup_logs (fecha_backup, usuario, ruta, estado, mensaje)
                  VALUES (@fecha, SYSTEM_USER, @ruta, 'Éxito', 'Backup completado correctamente')";
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ruta", rutaZip);
                    cmd.ExecuteNonQuery();
                }


                ultimaRutaBackup = rutaZip;
                MessageBox.Show($"✅ Backup completado correctamente:\n{rutaZip}",
                    "Backup BD", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUltimoBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al crear backup:\n{ex.Message}",
                    "Backup BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        // --- Abre la carpeta del último backup ---
        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ultimaRutaBackup) && File.Exists(ultimaRutaBackup))
                {
                    Process.Start("explorer.exe", Path.GetDirectoryName(ultimaRutaBackup));
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo del último backup.",
                        "Abrir carpeta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir la carpeta: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();

        // --- Efectos hover TYV ---
        private void BtnHoverEnter(object sender, EventArgs e)
        {
            var boton = sender as Button;
            boton.BackColor = System.Drawing.Color.FromArgb(230, 190, 140);
        }

        private void BtnHoverLeave(object sender, EventArgs e)
        {
            var boton = sender as Button;
            if (boton == btnBackupBD)
                boton.BackColor = System.Drawing.Color.FromArgb(80, 50, 40);
            else
                boton.BackColor = System.Drawing.Color.FromArgb(200, 170, 120);
        }
    }
}
