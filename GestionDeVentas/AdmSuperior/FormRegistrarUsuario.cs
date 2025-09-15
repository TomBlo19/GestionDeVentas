using GestionDeVentas.Datos;
using GestionDeVentas.Modelos;
using System;
using System.Linq;
using System.Windows.Forms;


namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarUsuario : Form
    {
        private UsuarioDatos usuarioDatos = new UsuarioDatos();
        private int? usuarioSeleccionadoId = null;

        public FormRegistrarUsuario()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void FormRegistrarUsuario_Load(object sender, EventArgs e)
        {
            // ✅ Configuración inicial del DataGridView
            dgvUsuarios.AutoGenerateColumns = false; // No generar columnas automáticas
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

            // Usar la propiedad ActivoTexto en la columna "Estado"
            Estado.DataPropertyName = "ActivoTexto";

            // Cargar usuarios
            dgvUsuarios.DataSource = usuarioDatos.ObtenerUsuarios();

            // ✅ Eventos de filtros
            txtFiltro.TextChanged += TxtFiltro_TextChanged;
            cmbFiltrarRol.SelectedIndexChanged += CmbFiltrarRol_SelectedIndexChanged;
            cmbFiltrarEstado.SelectedIndexChanged += CmbFiltrarEstado_SelectedIndexChanged;

            // Doble click en fila → editar
            dgvUsuarios.CellDoubleClick += dgvUsuarios_CellDoubleClick;
            dgvUsuarios.CellFormatting += dgvUsuarios_CellFormatting;

            // Restringir solo números en DNI y Teléfono
            txtDNI.KeyPress += SoloNumeros_KeyPress;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
        }

        // ✅ Handlers de filtros
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

        // ✅ Aplicar filtros
        private void ActualizarDataGridView()
        {
            var filtroTexto = txtFiltro.Text.ToLower();
            var filtroRol = cmbFiltrarRol.SelectedItem?.ToString();
            var filtroEstado = cmbFiltrarEstado.SelectedItem?.ToString();

            var usuariosFiltrados = usuarioDatos.ObtenerUsuarios()
                .Where(u =>
                    (string.IsNullOrEmpty(filtroTexto) ||
                     u.Apellido.ToLower().Contains(filtroTexto) ||
                     u.DNI.Contains(filtroTexto)) &&
                    (filtroRol == "Todos" || u.Rol == filtroRol) &&
                    (filtroEstado == "Todos" || u.ActivoTexto == filtroEstado)
                )
                .ToList();

            dgvUsuarios.DataSource = usuariosFiltrados;
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

            if (usuarioSeleccionadoId == null) // Nuevo
            {
                if (usuarioDatos.ExisteDNI(usuario.DNI))
                {
                    lblErrorDNI.Text = "El DNI ya existe.";
                    return;
                }
                if (usuarioDatos.ExisteCorreo(usuario.Email))
                {
                    lblErrorEmail.Text = "El correo ya existe.";
                    return;
                }

                if (MessageBox.Show("¿Seguro que quieres registrar este usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No) return;

                usuarioDatos.InsertarUsuario(usuario);
            }
            else // Editar
            {
                if (usuarioDatos.ExisteDNI(usuario.DNI, usuario.Id))
                {
                    lblErrorDNI.Text = "El DNI ya está en uso.";
                    return;
                }
                if (usuarioDatos.ExisteCorreo(usuario.Email, usuario.Id))
                {
                    lblErrorEmail.Text = "El correo ya está en uso.";
                    return;
                }

                if (MessageBox.Show("¿Seguro que quieres editar este usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No) return;

                usuarioDatos.EditarUsuario(usuario);
            }

            dgvUsuarios.DataSource = usuarioDatos.ObtenerUsuarios();
            LimpiarCampos();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionadoId == null) return;

            var usuario = usuarioDatos.ObtenerUsuarios().First(u => u.Id == usuarioSeleccionadoId);

            var confirm = MessageBox.Show($"¿Seguro que quieres {(usuario.Activo ? "desactivar" : "activar")} este usuario?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.No) return;

            usuarioDatos.CambiarEstado(usuario.Id, !usuario.Activo);

            dgvUsuarios.DataSource = usuarioDatos.ObtenerUsuarios();
            LimpiarCampos();
        }

        

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
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
                dtpFechaNacimiento.Value = usuario.FechaNacimiento;

                btnRegistrarUsuario.Text = "Guardar Cambios";
                btnDesactivar.Visible = true;
                btnDesactivar.Text = usuario.Activo ? "Desactivar" : "Activar";
            }
        }

        // ✅ Validaciones
        private bool ValidarCampos()
        {
            bool esValido = true;

            lblErrorNombre.Text = lblErrorApellido.Text = lblErrorDNI.Text = lblErrorTelefono.Text =
                lblErrorDireccion.Text = lblErrorPais.Text = lblErrorCiudad.Text = lblErrorEmail.Text =
                lblErrorContrasena.Text = lblErrorConfirmar.Text = lblErrorRol.Text = "";

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                lblErrorNombre.Text = "El nombre es obligatorio.";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                lblErrorApellido.Text = "El apellido es obligatorio.";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                lblErrorDNI.Text = "El DNI es obligatorio.";
                esValido = false;
            }
            else if (!int.TryParse(txtDNI.Text, out _))
            {
                lblErrorDNI.Text = "El DNI debe ser numérico.";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                lblErrorTelefono.Text = "El teléfono es obligatorio.";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                lblErrorDireccion.Text = "La dirección es obligatoria.";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                lblErrorPais.Text = "El país es obligatorio.";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                lblErrorCiudad.Text = "La ciudad es obligatorio.";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblErrorEmail.Text = "El correo es obligatorio.";
                esValido = false;
            }
            if (cmbRol.SelectedItem == null)
            {
                lblErrorRol.Text = "Debe seleccionar un rol.";
                esValido = false;
            }

            if (usuarioSeleccionadoId == null) // solo en registro
            {
                if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    lblErrorContrasena.Text = "La contraseña es obligatoria.";
                    esValido = false;
                }
                if (txtContrasena.Text != txtConfirmarContrasena.Text)
                {
                    lblErrorConfirmar.Text = "Las contraseñas no coinciden.";
                    esValido = false;
                }
            }

            return esValido;
        }

        // ✅ Restringir solo números
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quieres limpiar los campos?",
                                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }
        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                if (estado == "Inactivo")
                {
                    // Fondo rojo suave y letras negras
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                }
                else if (estado == "Activo")
                {
                    // Fondo blanco y letras negras
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

        private void formPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
