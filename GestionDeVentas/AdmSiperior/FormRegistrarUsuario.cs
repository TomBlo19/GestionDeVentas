using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarUsuario : Form
    {
        private List<Usuario> listaUsuarios = new List<Usuario>();

        public FormRegistrarUsuario()
        {
            InitializeComponent();
            CargarRoles();
           // ConfigurarDataGridView();
            this.txtNombreUsuario.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtApellido.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtPais.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCiudad.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtDNI.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
        }

        private void FormRegistrarUsuario_Load(object sender, EventArgs e)
        {
            // Código que se ejecuta al cargar el formulario
        }

        private void CargarRoles()
        {
            string[] roles = { "Administrador", "Administrador Superior", "Gerente" };
            cmbRol.Items.AddRange(roles);
        }

       // private void ConfigurarDataGridView()
        //{
          //  dgvUsuarios.AutoGenerateColumns = false;
           // dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvUsuarios.AllowUserToResizeRows = false;
          //  dgvUsuarios.AllowUserToResizeColumns = true;
         //   dgvUsuarios.ReadOnly = true;

        //    dgvUsuarios.Columns.Clear();
        //    dgvUsuarios.Columns.Add("Nombre", "Nombre");
        //    dgvUsuarios.Columns.Add("Apellido", "Apellido");
        //    dgvUsuarios.Columns.Add("DNI", "DNI");
       //     dgvUsuarios.Columns.Add("Email", "Email");
       //     dgvUsuarios.Columns.Add("Rol", "Rol");
     //   }

      //  private void ActualizarDataGridView()
       // {
       //     dgvUsuarios.Rows.Clear();
      //      foreach (var user in listaUsuarios)
      //      {
       //         dgvUsuarios.Rows.Add(user.Nombre, user.Apellido, user.DNI, user.Email, user.Rol);
        //    }
       // }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = txtNombreUsuario.Text,
                    Apellido = txtApellido.Text,
                    DNI = txtDNI.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Pais = txtPais.Text,
                    Ciudad = txtCiudad.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Email = txtEmail.Text,
                    Contrasena = txtContrasena.Text,
                    Rol = cmbRol.SelectedItem.ToString()
                };

                listaUsuarios.Add(nuevoUsuario);
                MessageBox.Show("Usuario registrado correctamente!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
               // ActualizarDataGridView();
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            lblErrorNombre.Text = " ";
            lblErrorApellido.Text = " ";
            lblErrorDNI.Text = " ";
            lblErrorTelefono.Text = " ";
            lblErrorDireccion.Text = " ";
            lblErrorPais.Text = " ";
            lblErrorCiudad.Text = " ";
            lblErrorFechaNacimiento.Text = " ";
            lblErrorEmail.Text = " ";
            lblErrorContrasena.Text = " ";
            lblErrorConfirmar.Text = " ";
            lblErrorRol.Text = " ";

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                lblErrorNombre.Text = "El nombre es obligatorio.";
                esValido = false;
            }

            // Validar Apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                lblErrorApellido.Text = "El apellido es obligatorio.";
                esValido = false;
            }

            // Validar DNI
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                lblErrorDNI.Text = "El DNI es obligatorio.";
                esValido = false;
            }
            else if (!Regex.IsMatch(txtDNI.Text, @"^\d+$"))
            {
                lblErrorDNI.Text = "El DNI solo puede contener números.";
                esValido = false;
            }

            // Validar Teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                lblErrorTelefono.Text = "El teléfono es obligatorio.";
                esValido = false;
            }
            else if (!Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                lblErrorTelefono.Text = "El teléfono solo puede contener números.";
                esValido = false;
            }

            // Validar Dirección
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                lblErrorDireccion.Text = "La dirección es obligatoria.";
                esValido = false;
            }

            // Validar País
            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                lblErrorPais.Text = "El país es obligatorio.";
                esValido = false;
            }

            // Validar Ciudad
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                lblErrorCiudad.Text = "La ciudad es obligatoria.";
                esValido = false;
            }

            // Validar Fecha de Nacimiento
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                lblErrorFechaNacimiento.Text = "La fecha de nacimiento no es válida.";
                esValido = false;
            }

            // Validar Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblErrorEmail.Text = "El email es obligatorio.";
                esValido = false;
            }
            else if (!EsEmailValido(txtEmail.Text))
            {
                lblErrorEmail.Text = "El formato de email no es válido.";
                esValido = false;
            }
            else if (listaUsuarios.Any(u => u.Email.Equals(txtEmail.Text, StringComparison.OrdinalIgnoreCase)))
            {
                lblErrorEmail.Text = "Este email ya está registrado.";
                esValido = false;
            }

            // Validar Contraseña
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                lblErrorContrasena.Text = "La contraseña es obligatoria.";
                esValido = false;
            }
            else if (txtContrasena.Text.Length < 6)
            {
                lblErrorContrasena.Text = "La contraseña debe tener al menos 6 caracteres.";
                esValido = false;
            }
            else if (!Regex.IsMatch(txtContrasena.Text, @"^(?=.*[A-Za-z])(?=.*\d).*$"))
            {
                lblErrorContrasena.Text = "Debe contener letras y números.";
                esValido = false;
            }

            // Validar Confirmación de Contraseña
            if (string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                lblErrorConfirmar.Text = "Confirme su contraseña.";
                esValido = false;
            }
            else if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblErrorConfirmar.Text = "Las contraseñas no coinciden.";
                esValido = false;
            }

            // Validar Rol
            if (cmbRol.SelectedItem == null)
            {
                lblErrorRol.Text = "Selecciona un rol.";
                esValido = false;
            }

            return esValido;
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtPais.Clear();
            txtCiudad.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            txtEmail.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
            cmbRol.SelectedIndex = -1;
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txt_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }

    // Clase Usuario actualizada para incluir País y Ciudad
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
    }
}