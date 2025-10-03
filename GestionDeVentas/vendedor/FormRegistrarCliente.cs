using GestionDeVentas.Modelos;
using GestionDeVentas.Datos;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    public partial class FormRegistrarCliente : Form
    {
        private ClienteDatos clienteDatos = new ClienteDatos();
        private int? clienteSeleccionadoId = null;

        public FormRegistrarCliente()
        {
            InitializeComponent();
            ConfigurarDataGridView();

            // Validaciones de tipeo
            this.txtNombre.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtApellido.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtPais.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCiudad.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtDni.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
        }

        private void FormRegistrarCliente_Load(object sender, EventArgs e)
        {
            btnCerrar.BringToFront();
            ActualizarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AllowUserToResizeColumns = true;
            dgvClientes.ReadOnly = true;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellido" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dni", HeaderText = "DNI" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Teléfono" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Direccion", HeaderText = "Dirección" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Pais", HeaderText = "País" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ciudad", HeaderText = "Ciudad" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CorreoElectronico", HeaderText = "Correo" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ActivoTexto", HeaderText = "Estado" });

            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
        }

        private void ActualizarDataGridView()
        {
            dgvClientes.DataSource = clienteDatos.ObtenerClientes();
        }

        // 🔹 Confirmación
        private bool Confirmar(string mensaje, string titulo = "Confirmación")
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(false)) return;

            // Validaciones únicas ANTES de confirmar
            if (clienteDatos.ExisteDni(txtDni.Text))
            {
                lblErrorDni.Text = "El DNI ya existe.";
                return;
            }
            if (clienteDatos.ExisteCorreo(txtCorreo.Text))
            {
                lblErrorCorreo.Text = "El correo ya existe.";
                return;
            }

            if (!Confirmar("¿Deseas registrar este cliente?")) return;

            var nuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Pais = txtPais.Text,
                Ciudad = txtCiudad.Text,
                CorreoElectronico = txtCorreo.Text,
                Activo = true
            };

            clienteDatos.InsertarCliente(nuevoCliente);
            MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            ActualizarDataGridView();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(clienteSeleccionadoId.HasValue && ValidarCampos(true))) return;

            // Validaciones únicas
            if (clienteDatos.ExisteDni(txtDni.Text, clienteSeleccionadoId.Value))
            {
                lblErrorDni.Text = "El DNI ya existe.";
                return;
            }
            if (clienteDatos.ExisteCorreo(txtCorreo.Text, clienteSeleccionadoId.Value))
            {
                lblErrorCorreo.Text = "El correo ya existe.";
                return;
            }

            if (!Confirmar("¿Guardar cambios para este cliente?")) return;

            var clienteAEditar = new Cliente
            {
                Id = clienteSeleccionadoId.Value,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Pais = txtPais.Text,
                Ciudad = txtCiudad.Text,
                CorreoElectronico = txtCorreo.Text
            };

            clienteDatos.EditarCliente(clienteAEditar);
            MessageBox.Show("Cliente editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            ActualizarDataGridView();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (!Confirmar("¿Deseas limpiar los campos?")) return;
            LimpiarCampos();
        }

        private bool ValidarCampos(bool esEdicion)
        {
            bool esValido = true;
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            lblErrorNombre.Text = " ";
            lblErrorApellido.Text = " ";
            lblErrorDni.Text = " ";
            lblErrorTelefono.Text = " ";
            lblErrorDireccion.Text = " ";
            lblErrorPais.Text = " ";
            lblErrorCiudad.Text = " ";
            lblErrorCorreo.Text = " ";

            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { lblErrorNombre.Text = "El nombre es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { lblErrorApellido.Text = "El apellido es obligatorio."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtDni.Text)) { lblErrorDni.Text = "El DNI es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtDni.Text, @"^\d+$")) { lblErrorDni.Text = "El DNI solo puede contener números."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) { lblErrorTelefono.Text = "El teléfono es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtTelefono.Text, @"^\d+$")) { lblErrorTelefono.Text = "El teléfono solo puede contener números."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { lblErrorDireccion.Text = "La dirección es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtPais.Text)) { lblErrorPais.Text = "El país es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text)) { lblErrorCiudad.Text = "La ciudad es obligatoria."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text)) { lblErrorCorreo.Text = "El correo es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtCorreo.Text, patronEmail)) { lblErrorCorreo.Text = "Formato de correo inválido."; esValido = false; }

            return esValido;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtPais.Clear();
            txtCiudad.Clear();
            txtCorreo.Clear();

            txtNombre.Focus();
            clienteSeleccionadoId = null;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvClientes.Rows[e.RowIndex].DataBoundItem as Cliente;
                if (fila != null)
                {
                    clienteSeleccionadoId = fila.Id;
                    txtNombre.Text = fila.Nombre;
                    txtApellido.Text = fila.Apellido;
                    txtDni.Text = fila.Dni;
                    txtTelefono.Text = fila.Telefono;
                    txtDireccion.Text = fila.Direccion;
                    txtPais.Text = fila.Pais;
                    txtCiudad.Text = fila.Ciudad;
                    txtCorreo.Text = fila.CorreoElectronico;

                    btnRegistrar.Visible = false;
                    btnEditar.Visible = true;
                }
            }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name == "ActivoTexto" && e.Value != null)
            {
                if (e.Value.ToString() == "Inactivo")
                {
                    dgvClientes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dgvClientes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void txt_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Confirmar("¿Seguro que deseas cerrar esta ventana?", "Cerrar"))
                this.Close();
        }
    }
}
