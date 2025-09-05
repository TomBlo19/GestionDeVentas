using GestionDeVentas.Admin;
using GestionDeVentas.Gerent;
using GestionDeVentas.AdmSuperior; 
using GestionDeVentas.vendedor; 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace gestionDeVentas
{
    public partial class inicioSesion : Form
    {
        private const int MAX_INTENTOS = 5;
        private int intentos = 0;

        private class Usuario
        {
            public string User { get; set; }
            public string Pass { get; set; }
            public string Rol { get; set; }
        }

        private readonly List<Usuario> usuariosDemo =
            new List<Usuario>
            {
                new Usuario { User = "vendedor", Pass = "123456789", Rol = "Vendedor" },
                new Usuario { User = "gerente", Pass = "123456789", Rol = "Gerente" },
                new Usuario { User = "administrador", Pass = "123456789", Rol = "Admin" },
                new Usuario { User = "administradorSuper", Pass = "123456789", Rol = "AdminSuperior" },
            };

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
                MessageBox.Show("Error al cargar el logo: " + ex.Message, "Error de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Tienes activado CAPS LOCK. Verifica la contraseña.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            string usuario = txtUsuario.Text.Trim();
            string pass = txtPassword.Text;

            var usuarioEncontrado = usuariosDemo.FirstOrDefault(x =>
                x.User.Equals(usuario, StringComparison.OrdinalIgnoreCase) && x.Pass == pass);

            if (usuarioEncontrado != null)
            {
                MessageBox.Show($"Bienvenido {usuarioEncontrado.User} (Rol: {usuarioEncontrado.Rol})", "Login exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form frm = null;
                switch (usuarioEncontrado.Rol)
                {
                    case "Vendedor":
                        frm = new GestionDeVentas.vendedor.FormVendedor();
                        break;
                    case "Gerente":
                        frm = new FormGerentePanel();
                        break;
                    case "Admin":
                        frm = new Form1();
                        break;
                    case "AdminSuperior":
                        frm = new GestionDeVentas.AdmSuperior.FormAdminSuperior();
                        break;
                }

                if (frm != null)
                {
                    frm.Show();
                    this.Hide();
                    frm.FormClosed += (s, args) => this.Close();
                }
                return;
            }

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

        // Métodos de validación y estilo restantes...
        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(205, 151, 92);
        }
        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(94, 64, 44);
        }
        private bool ValidarFormulario()
        {
            errorProvider1.Clear();
            bool ok = true;
            string u = txtUsuario.Text.Trim();
            if (string.IsNullOrWhiteSpace(u))
            {
                errorProvider1.SetError(txtUsuario, "El usuario es obligatorio.");
                ok = false;
            }
            else if (u.Length < 4 || u.Length > 30 || !Regex.IsMatch(u, @"^[A-Za-z0-9._-]+$"))
            {
                errorProvider1.SetError(txtUsuario, "4-30 caracteres. Solo letras, números y ._-");
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

        private void table_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}