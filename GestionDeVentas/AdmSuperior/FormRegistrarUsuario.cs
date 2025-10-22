using GestionDeVentas.Datos;
using GestionDeVentas.Modelos;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic; // Para que funcione List<T>
using System.Drawing; // Para que funcione Color
using System.Text.RegularExpressions; // ✅ 1. Agregado para validar el correo

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarUsuario : Form
    {
        private UsuarioDatos usuarioDatos = new UsuarioDatos();
        private int? usuarioSeleccionadoId = null;
        private List<Usuario> _listaMaestraUsuarios;

        public FormRegistrarUsuario()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void FormRegistrarUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Estado.DataPropertyName = "ActivoTexto";

            _listaMaestraUsuarios = usuarioDatos.ObtenerUsuarios();

            ConfigurarFiltroBusqueda();
            ConectarEventosDeFiltro();

            ActualizarDataGridView();

            dgvUsuarios.CellDoubleClick += dgvUsuarios_CellDoubleClick;
            dgvUsuarios.CellFormatting += dgvUsuarios_CellFormatting;
            txtDNI.KeyPress += SoloNumeros_KeyPress;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
        }

        private void ConectarEventosDeFiltro()
        {
            txtFiltro.TextChanged += TxtFiltro_TextChanged;
            cboBuscarPor.SelectedIndexChanged += (s, e) => ActualizarDataGridView();
            cmbFiltrarRol.SelectedIndexChanged += CmbFiltrarRol_SelectedIndexChanged;
            cmbFiltrarEstado.SelectedIndexChanged += CmbFiltrarEstado_SelectedIndexChanged;
        }

        private void ConfigurarFiltroBusqueda()
        {
            if (this.Controls.Find("lblFiltro", true).FirstOrDefault() is Label lblFiltro)
            {
                lblFiltro.Visible = false;
            }
            cboBuscarPor.Items.Add("Apellido");
            cboBuscarPor.Items.Add("DNI");
            cboBuscarPor.SelectedIndex = 0;
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e) => ActualizarDataGridView();
        private void CmbFiltrarRol_SelectedIndexChanged(object sender, EventArgs e) => ActualizarDataGridView();
        private void CmbFiltrarEstado_SelectedIndexChanged(object sender, EventArgs e) => ActualizarDataGridView();

        private void CargarRoles()
        {
            var roles = usuarioDatos.ObtenerRoles();
            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(roles.ToArray());
            cmbFiltrarRol.Items.Clear();
            cmbFiltrarRol.Items.Add("Todos");
            cmbFiltrarRol.Items.AddRange(roles.ToArray());
            cmbFiltrarRol.SelectedIndex = 0;
            cmbFiltrarEstado.Items.Clear();
            cmbFiltrarEstado.Items.Add("Todos");
            cmbFiltrarEstado.Items.Add("Activo");
            cmbFiltrarEstado.Items.Add("Inactivo");
            cmbFiltrarEstado.SelectedIndex = 0;
        }

        private void ActualizarDataGridView()
        {
            if (_listaMaestraUsuarios == null) return;
            var filtroTexto = txtFiltro.Text.ToLower();
            var filtroRol = cmbFiltrarRol.SelectedItem?.ToString();
            var filtroEstado = cmbFiltrarEstado.SelectedItem?.ToString();
            var criterioBusqueda = cboBuscarPor.SelectedItem?.ToString();

            IEnumerable<Usuario> usuariosFiltrados = _listaMaestraUsuarios;

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                if (criterioBusqueda == "DNI")
                {
                    usuariosFiltrados = usuariosFiltrados.Where(u => u.DNI.Contains(filtroTexto));
                }
                else // Apellido
                {
                    usuariosFiltrados = usuariosFiltrados.Where(u => u.Apellido.ToLower().Contains(filtroTexto));
                }
            }
            if (filtroRol != "Todos")
            {
                usuariosFiltrados = usuariosFiltrados.Where(u => u.Rol == filtroRol);
            }
            if (filtroEstado != "Todos")
            {
                usuariosFiltrados = usuariosFiltrados.Where(u => u.ActivoTexto == filtroEstado);
            }
            dgvUsuarios.DataSource = usuariosFiltrados.ToList();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            var usuario = new Usuario
            {
                Id = usuarioSeleccionadoId ?? 0,
                Nombre = txtNombreUsuario.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Pais = txtPais.Text,
                Ciudad = txtCiudad.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Contrasena = txtContrasena.Text,
                Rol = cmbRol.SelectedItem?.ToString(),
                Activo = true
            };

            if (usuarioSeleccionadoId == null)
            {
                if (usuarioDatos.ExisteDNI(usuario.DNI)) { lblErrorDNI.Text = "El DNI ya existe."; return; }
                if (usuarioDatos.ExisteCorreo(usuario.Email)) { lblErrorEmail.Text = "El correo ya existe."; return; }
                if (MessageBox.Show("¿Seguro que quieres registrar este usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No) return;
                usuarioDatos.InsertarUsuario(usuario);
            }
            else
            {
                if (usuarioDatos.ExisteDNI(usuario.DNI, usuario.Id)) { lblErrorDNI.Text = "El DNI ya está en uso."; return; }
                if (usuarioDatos.ExisteCorreo(usuario.Email, usuario.Id)) { lblErrorEmail.Text = "El correo ya está en uso."; return; }
                if (MessageBox.Show("¿Seguro que quieres editar este usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No) return;
                usuarioDatos.EditarUsuario(usuario);
            }
            _listaMaestraUsuarios = usuarioDatos.ObtenerUsuarios();
            ActualizarDataGridView();
            LimpiarCampos();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionadoId == null) return;
            var usuario = _listaMaestraUsuarios.FirstOrDefault(u => u.Id == usuarioSeleccionadoId);
            if (usuario == null) return;

            var confirm = MessageBox.Show($"¿Seguro que quieres {(usuario.Activo ? "desactivar" : "activar")} este usuario?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            usuarioDatos.CambiarEstado(usuario.Id, !usuario.Activo);
            usuario.Activo = !usuario.Activo;
            ActualizarDataGridView();
            LimpiarCampos();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var usuario = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
            usuarioSeleccionadoId = usuario.Id;
            txtNombreUsuario.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtDNI.Text = usuario.DNI;
            txtTelefono.Text = usuario.Telefono;
            txtDireccion.Text = usuario.Direccion;
            txtPais.Text = usuario.Pais;
            txtCiudad.Text = usuario.Ciudad;
            txtEmail.Text = usuario.Email;
            txtContrasena.Text = usuario.Contrasena;
            txtConfirmarContrasena.Text = usuario.Contrasena;
            cmbRol.SelectedItem = usuario.Rol;
            dtpFechaNacimiento.Value = usuario.FechaNacimiento > dtpFechaNacimiento.MinDate ? usuario.FechaNacimiento : DateTime.Now;
            btnRegistrarUsuario.Text = "Guardar Cambios";
            btnDesactivar.Visible = true;
            btnDesactivar.Text = usuario.Activo ? "Desactivar" : "Activar";
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            lblErrorNombre.Text = lblErrorApellido.Text = lblErrorDNI.Text = lblErrorTelefono.Text =
            lblErrorDireccion.Text = lblErrorPais.Text = lblErrorCiudad.Text = lblErrorEmail.Text =
            lblErrorContrasena.Text = lblErrorConfirmar.Text = lblErrorRol.Text = "";

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text)) { lblErrorNombre.Text = "El nombre es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { lblErrorApellido.Text = "El apellido es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtDNI.Text)) { lblErrorDNI.Text = "El DNI es obligatorio."; esValido = false; }
            else if (!long.TryParse(txtDNI.Text, out _)) { lblErrorDNI.Text = "El DNI debe ser numérico."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) { lblErrorTelefono.Text = "El teléfono es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { lblErrorDireccion.Text = "La dirección es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtPais.Text)) { lblErrorPais.Text = "El país es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text)) { lblErrorCiudad.Text = "La ciudad es obligatoria."; esValido = false; }

            // ✅ CORRECCIÓN #2: Se agrega la validación de formato para el correo.
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblErrorEmail.Text = "El correo es obligatorio.";
                esValido = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblErrorEmail.Text = "El formato del correo es inválido.";
                esValido = false;
            }

            if (cmbRol.SelectedItem == null) { lblErrorRol.Text = "Debe seleccionar un rol."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtContrasena.Text)) { lblErrorContrasena.Text = "La contraseña es obligatoria."; esValido = false; }
            else if (txtContrasena.Text != txtConfirmarContrasena.Text) { lblErrorConfirmar.Text = "Las contraseñas no coinciden."; esValido = false; }

            return esValido;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quieres limpiar los campos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var usuario = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as Usuario;
            if (usuario != null)
            {
                if (!usuario.Activo)
                {
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                }
            }
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
            txtEmail.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
            cmbRol.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;

            usuarioSeleccionadoId = null;
            btnRegistrarUsuario.Text = "Registrar Usuario";
            btnDesactivar.Visible = false;

            lblErrorNombre.Text = lblErrorApellido.Text = lblErrorDNI.Text = lblErrorTelefono.Text =
            lblErrorDireccion.Text = lblErrorPais.Text = lblErrorCiudad.Text = lblErrorEmail.Text =
            lblErrorContrasena.Text = lblErrorConfirmar.Text = lblErrorRol.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formPanel_Paint(object sender, PaintEventArgs e) { }
    }
}