using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarUsuario : Form
    {
        private List<Usuario> listaUsuarios = new List<Usuario>();
        private int? usuarioSeleccionadoIndex = null;

        public FormRegistrarUsuario()
        {
            InitializeComponent();
            CargarRoles();
            CargarDatosIniciales();
            ConfigurarDataGridView();
            ActualizarDataGridView();
            btnDesactivar.Visible = false;

            this.txtNombreUsuario.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtApellido.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtPais.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCiudad.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtDNI.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);

            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.cmbFiltrarRol.SelectedIndexChanged += new System.EventHandler(this.cmbFiltrarRol_SelectedIndexChanged);
            this.cmbFiltrarEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltrarEstado_SelectedIndexChanged);
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            this.dgvUsuarios.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvUsuarios_CellFormatting);
        }

        private void FormRegistrarUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarRoles()
        {
            string[] roles = { "Vendedor", "Administrador", "Administrador Superior", "Gerente" };
            cmbRol.Items.AddRange(roles);
            cmbFiltrarRol.Items.Add("Todos");
            cmbFiltrarRol.Items.AddRange(roles);
            cmbFiltrarRol.SelectedIndex = 0;

            cmbFiltrarEstado.Items.Add("Todos");
            cmbFiltrarEstado.Items.Add("Activo");
            cmbFiltrarEstado.Items.Add("Inactivo");
            cmbFiltrarEstado.SelectedIndex = 0;
        }

        private void CargarDatosIniciales()
        {
            listaUsuarios.Add(new Usuario { Nombre = "Juan", Apellido = "Perez", DNI = "12345678", Telefono = "1122334455", Email = "juan.perez@mail.com", Rol = "Administrador", Activo = true, Direccion = "Calle Falsa 123", Pais = "Argentina", Ciudad = "Buenos Aires", FechaNacimiento = new DateTime(1985, 5, 10), Contrasena = "juan123" });
            listaUsuarios.Add(new Usuario { Nombre = "Maria", Apellido = "Gomez", DNI = "87654321", Telefono = "9988776655", Email = "maria.gomez@mail.com", Rol = "Vendedor", Activo = true, Direccion = "Avenida Siempreviva 742", Pais = "Argentina", Ciudad = "Mendoza", FechaNacimiento = new DateTime(1990, 8, 20), Contrasena = "maria456" });
            listaUsuarios.Add(new Usuario { Nombre = "Carlos", Apellido = "Lopez", DNI = "11223344", Telefono = "3344556677", Email = "carlos.lopez@mail.com", Rol = "Gerente", Activo = false, Direccion = "Calle 50 # 25-10", Pais = "Colombia", Ciudad = "Bogotá", FechaNacimiento = new DateTime(1975, 2, 28), Contrasena = "carlos789" });
        }

        private void ConfigurarDataGridView()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "DNI", DataPropertyName = "DNI" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Apellido", DataPropertyName = "Apellido" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Teléfono", DataPropertyName = "Telefono" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Email", DataPropertyName = "Email" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Rol", DataPropertyName = "Rol" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Estado", DataPropertyName = "Estado" });
        }

        private void ActualizarDataGridView()
        {
            var filtroTexto = txtFiltro.Text.ToLower();
            var filtroRol = cmbFiltrarRol.SelectedItem?.ToString();
            var filtroEstado = cmbFiltrarEstado.SelectedItem?.ToString();

            var usuariosFiltrados = listaUsuarios.Where(u =>
                (filtroRol == "Todos" || filtroRol == null || u.Rol == filtroRol) &&
                (filtroEstado == "Todos" || filtroEstado == null || u.ActivoTexto == filtroEstado) &&
                (string.IsNullOrEmpty(filtroTexto) || u.Nombre.ToLower().Contains(filtroTexto) || u.DNI.Contains(filtroTexto) || u.Apellido.ToLower().Contains(filtroTexto) || u.Rol.ToLower().Contains(filtroTexto) || u.ActivoTexto.ToLower().Contains(filtroTexto))
            ).ToList();

            var datosParaTabla = usuariosFiltrados.Select(u => new
            {
                u.DNI,
                u.Nombre,
                u.Apellido,
                u.Telefono,
                u.Email,
                u.Rol,
                Estado = u.ActivoTexto
            }).ToList();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = datosParaTabla;
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var confirmacion = MessageBox.Show(
                    "¿Está seguro de guardar los cambios?",
                    "Confirmar acción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion == DialogResult.No) return;

                if (usuarioSeleccionadoIndex != null)
                {
                    var usuarioAEditar = listaUsuarios[usuarioSeleccionadoIndex.Value];
                    usuarioAEditar.Nombre = txtNombreUsuario.Text;
                    usuarioAEditar.Apellido = txtApellido.Text;
                    usuarioAEditar.DNI = txtDNI.Text;
                    usuarioAEditar.Telefono = txtTelefono.Text;
                    usuarioAEditar.Direccion = txtDireccion.Text;
                    usuarioAEditar.Pais = txtPais.Text;
                    usuarioAEditar.Ciudad = txtCiudad.Text;
                    usuarioAEditar.FechaNacimiento = dtpFechaNacimiento.Value;
                    usuarioAEditar.Email = txtEmail.Text;
                    usuarioAEditar.Contrasena = txtContrasena.Text;
                    usuarioAEditar.Rol = cmbRol.SelectedItem.ToString();

                    MessageBox.Show("Usuario editado correctamente!", "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usuarioSeleccionadoIndex = null;
                    btnRegistrarUsuario.Text = "Registrar Usuario";
                    btnLimpiar.Text = "Limpiar";
                    btnDesactivar.Visible = false;
                }
                else
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
                        Rol = cmbRol.SelectedItem.ToString(),
                        Activo = true
                    };

                    listaUsuarios.Add(nuevoUsuario);
                    MessageBox.Show("Usuario registrado correctamente!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LimpiarCampos();
                ActualizarDataGridView();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            usuarioSeleccionadoIndex = null;
            btnRegistrarUsuario.Text = "Registrar Usuario";
            btnLimpiar.Text = "Limpiar";
            btnDesactivar.Visible = false;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionadoIndex != null)
            {
                var usuario = listaUsuarios[usuarioSeleccionadoIndex.Value];

                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de {(usuario.Activo ? "desactivar" : "activar")} a {usuario.Nombre}?",
                    "Confirmar acción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No) return;

                string nuevoEstado = usuario.Activo ? "inactivado" : "activado";
                usuario.Activo = !usuario.Activo;
                MessageBox.Show($"Usuario {usuario.Nombre} {nuevoEstado} correctamente.", "Estado de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                ActualizarDataGridView();
                usuarioSeleccionadoIndex = null;
                btnRegistrarUsuario.Text = "Registrar Usuario";
                btnLimpiar.Text = "Limpiar";
                btnDesactivar.Visible = false;
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dniSeleccionado = dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                var usuarioSeleccionado = listaUsuarios.FirstOrDefault(u => u.DNI == dniSeleccionado);

                if (usuarioSeleccionado != null)
                {
                    usuarioSeleccionadoIndex = listaUsuarios.IndexOf(usuarioSeleccionado);

                    txtNombreUsuario.Text = usuarioSeleccionado.Nombre;
                    txtApellido.Text = usuarioSeleccionado.Apellido;
                    txtDNI.Text = usuarioSeleccionado.DNI;
                    txtTelefono.Text = usuarioSeleccionado.Telefono;
                    txtDireccion.Text = usuarioSeleccionado.Direccion;
                    txtPais.Text = usuarioSeleccionado.Pais;
                    txtCiudad.Text = usuarioSeleccionado.Ciudad;
                    dtpFechaNacimiento.Value = usuarioSeleccionado.FechaNacimiento;
                    txtEmail.Text = usuarioSeleccionado.Email;

                    // Mostrar la contraseña al editar
                    txtContrasena.Text = usuarioSeleccionado.Contrasena;
                    txtConfirmarContrasena.Text = usuarioSeleccionado.Contrasena;

                    cmbRol.SelectedItem = usuarioSeleccionado.Rol;

                    btnRegistrarUsuario.Text = "Editar Usuario";
                    btnLimpiar.Text = "Cancelar Edición";
                    btnDesactivar.Visible = true;
                    btnDesactivar.Text = usuarioSeleccionado.Activo ? "Desactivar" : "Activar";
                }
            }
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].HeaderText == "Estado")
            {
                var estado = dgvUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (estado == "Inactivo")
                {
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e) => ActualizarDataGridView();
        private void cmbFiltrarRol_SelectedIndexChanged(object sender, EventArgs e) => ActualizarDataGridView();
        private void cmbFiltrarEstado_SelectedIndexChanged(object sender, EventArgs e) => ActualizarDataGridView();

        private bool ValidarCampos()
        {
            bool esValido = true;
            lblErrorNombre.Text = lblErrorApellido.Text = lblErrorDNI.Text = lblErrorTelefono.Text = lblErrorDireccion.Text = " ";
            lblErrorPais.Text = lblErrorCiudad.Text = lblErrorFechaNacimiento.Text = lblErrorEmail.Text = lblErrorContrasena.Text = lblErrorConfirmar.Text = lblErrorRol.Text = " ";

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

            if (string.IsNullOrWhiteSpace(txtDNI.Text) || !Regex.IsMatch(txtDNI.Text, @"^\d+$"))
            {
                lblErrorDNI.Text = "DNI inválido.";
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                lblErrorTelefono.Text = "Teléfono inválido.";
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
                lblErrorCiudad.Text = "La ciudad es obligatoria.";
                esValido = false;
            }

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                lblErrorFechaNacimiento.Text = "Fecha de nacimiento inválida.";
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !EsEmailValido(txtEmail.Text))
            {
                lblErrorEmail.Text = "Email inválido.";
                esValido = false;
            }
            else if (listaUsuarios.Any(u => u.Email.Equals(txtEmail.Text, StringComparison.OrdinalIgnoreCase) && (usuarioSeleccionadoIndex == null || listaUsuarios[usuarioSeleccionadoIndex.Value].Email != txtEmail.Text)))
            {
                lblErrorEmail.Text = "Este email ya está registrado.";
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text) && usuarioSeleccionadoIndex == null)
            {
                lblErrorContrasena.Text = "La contraseña es obligatoria.";
                esValido = false;
            }

            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                lblErrorConfirmar.Text = "Las contraseñas no coinciden.";
                esValido = false;
            }

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

            lblErrorNombre.Text = lblErrorApellido.Text = lblErrorDNI.Text = lblErrorTelefono.Text = lblErrorDireccion.Text = " ";
            lblErrorPais.Text = lblErrorCiudad.Text = lblErrorFechaNacimiento.Text = lblErrorEmail.Text = lblErrorContrasena.Text = lblErrorConfirmar.Text = lblErrorRol.Text = " ";
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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void formPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

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
        public bool Activo { get; set; }
        public string ActivoTexto => Activo ? "Activo" : "Inactivo";
    }
}
