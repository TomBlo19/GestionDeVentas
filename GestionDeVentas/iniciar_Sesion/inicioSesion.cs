using GestionDeVentas.Admin;
using GestionDeVentas.Gerent;
using GestionDeVentas.AdmSuperior;
using GestionDeVentas.vendedor;
using GestionDeVentas.Datos; 
using Modelos;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace gestionDeVentas
{
    public partial class inicioSesion : Form
    {
        private const int MAX_INTENTOS = 5;
        private int intentos = 0;

        public inicioSesion()
        {
            InitializeComponent();
            this.AcceptButton = btnIngresar;

            try
            {
                this.logoTYV.Image = global::GestionDeVentas.Properties.Resources.logo_empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo: " + ex.Message,
                    "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkVer_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVer.Checked ? '\0' : '•';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Tienes activado CAPS LOCK. Verifica la contraseña.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string correoIngresado = txtUsuario.Text.Trim();
            string contrasenaIngresada = txtPassword.Text.Trim();

            // ✅ Ahora usamos la conexión centralizada
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT u.id_usuario, u.nombre_usuario, u.apellido_usuario,
                           u.contrasena_usuario, u.estado_usuario,
                           t.nombre_tipo AS Rol
                    FROM usuario u
                    INNER JOIN tipo_usuario t ON u.id_tipo_usuario = t.id_tipo_usuario
                    WHERE u.correo_usuario = @Correo;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Correo", correoIngresado);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idUsuario = Convert.ToInt32(reader["id_usuario"]);
                            string contrasenaDB = reader["contrasena_usuario"].ToString();
                            string estado = reader["estado_usuario"].ToString();
                            string rol = reader["Rol"].ToString();
                            string nombre = reader["nombre_usuario"].ToString();
                            string apellido = reader["apellido_usuario"].ToString();

                            if (!string.Equals(estado, "activo", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("El usuario está inactivo. No puede iniciar sesión.",
                                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (!string.Equals(contrasenaDB, contrasenaIngresada))
                            {
                                MessageBox.Show("La contraseña no coincide. Verifica los datos e intenta nuevamente.",
                                    "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                IntentoFallido();
                                return;
                            }

                            // ✅ Guardamos datos de sesión
                            SesionActual.IdUsuario = idUsuario;
                            SesionActual.NombreCompleto = $"{nombre} {apellido}";
                            SesionActual.Rol = rol;

                            if (!AbrirFormularioPorRol(rol, nombre, apellido))
                                return;
                        }
                        else
                        {
                            MessageBox.Show("El correo ingresado no existe o es incorrecto.",
                                "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            IntentoFallido();
                            return;
                        }
                    }
                }
            }
        }

        private bool AbrirFormularioPorRol(string rolOriginal, string nombre, string apellido)
        {
            string key = Regex.Replace((rolOriginal ?? "").Trim(), @"[\s._-]+", "")
                               .ToLowerInvariant();

            Form frm = null;
            switch (key)
            {
                case "vendedor":
                    frm = new GestionDeVentas.vendedor.FormVendedor();
                    break;

                case "gerente":
                    frm = new FormGerentePanel();
                    break;

                case "admin":
                case "administrador":
                    frm = new Form1();
                    break;

                case "adminsuperior":
                case "administradorsuperior":
                    frm = new GestionDeVentas.AdmSuperior.FormAdminSuperior();
                    break;

                default:
                    MessageBox.Show(
                        $"Rol desconocido o no asignado: \"{rolOriginal}\".\n" +
                        "Contacte al administrador.",
                        "Error de Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }

            MessageBox.Show($"Bienvenido {nombre} {apellido}\nRol: {rolOriginal}",
                "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frm.Show();
            this.Hide();

            frm.FormClosed += (s, args) =>
            {
                this.LimpiarCampos();
                this.Show();
            };

            return true;
        }

        private void IntentoFallido()
        {
            intentos++;
            int restantes = MAX_INTENTOS - intentos;

            if (restantes <= 0)
            {
                BloquearLogin();
                return;
            }

            MessageBox.Show($"Usuario o contraseña inválidos. Intentos restantes: {restantes}",
                "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void BloquearLogin()
        {
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            btnIngresar.Enabled = false;

            MessageBox.Show(
                "Has superado el máximo de intentos. El inicio de sesión queda bloqueado.\n" +
                "Cierra y vuelve a abrir la aplicación para reintentar.",
                "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private bool ValidarFormulario()
        {
            errorProvider1.Clear();
            bool ok = true;

            string u = txtUsuario.Text.Trim();
            if (string.IsNullOrWhiteSpace(u))
            {
                errorProvider1.SetError(txtUsuario, "El correo es obligatorio.");
                ok = false;
            }

            string p = txtPassword.Text;
            if (string.IsNullOrEmpty(p))
            {
                errorProvider1.SetError(txtPassword, "La contraseña es obligatoria.");
                ok = false;
            }
            else if (p.Length < 4)
            {
                errorProvider1.SetError(txtPassword, "Mínimo 4 caracteres.");
                ok = false;
            }

            return ok;
        }

        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(205, 151, 92);
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(94, 64, 44);
        }

        private void inicioSesion_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            chkVer.Checked = false;
            txtPassword.PasswordChar = '•';
            errorProvider1.Clear();
            txtUsuario.Focus();
        }

        private void table_Paint(object sender, PaintEventArgs e) { }
        private void lblUsuario_Click(object sender, EventArgs e) { }
    }
}
