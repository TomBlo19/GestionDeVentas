using GestionDeVentas.Modelos;
using GestionDeVentas.Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Modelos;
using Datos;

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

            // Configurar ComboBox de búsqueda
            cboBuscarPor.Items.Add("DNI");
            cboBuscarPor.Items.Add("Apellido");
            cboBuscarPor.SelectedIndex = 0;

            dgvClientes.ClearSelection();
            dgvClientes.CurrentCell = null;
        }

        // --------------------------------------------------------------------------------------
        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.ReadOnly = true;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellido" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dni", HeaderText = "DNI" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Teléfono" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Direccion", HeaderText = "Dirección" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Pais", HeaderText = "País" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Ciudad", HeaderText = "Ciudad" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CorreoElectronico", HeaderText = "Correo" });

            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
        }

        // --------------------------------------------------------------------------------------
        private void ActualizarDataGridView()
        {
            try
            {
                dgvClientes.DataSource = clienteDatos.ObtenerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvClientes.ClearSelection();
                dgvClientes.CurrentCell = null;
            }
        }

        // --------------------------------------------------------------------------------------
        private bool Confirmar(string mensaje, string titulo = "Confirmación")
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // =======================================================================================
        // MÉTODOS DE BÚSQUEDA (CONECTADOS A LA BASE DE DATOS)
        // =======================================================================================

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // <<< CAMBIO PRINCIPAL: AHORA CONSULTA DIRECTAMENTE A LA BASE DE DATOS >>>

            string criterio = cboBuscarPor.SelectedItem.ToString();
            string valorBusqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(valorBusqueda))
            {
                ActualizarDataGridView(); // Si no hay texto, muestra todos los clientes
                return;
            }

            try
            {
                List<Cliente> clientesFiltrados;

                // Llama al método específico de la capa de datos según el criterio
                if (criterio == "DNI")
                {
                    clientesFiltrados = clienteDatos.BuscarClientesPorDni(valorBusqueda);
                }
                else // Apellido
                {
                    clientesFiltrados = clienteDatos.BuscarClientesPorApellido(valorBusqueda);
                }

                // Actualiza la grilla con los resultados de la base de datos
                dgvClientes.DataSource = clientesFiltrados;
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que pueda ocurrir durante la conexión o consulta
                MessageBox.Show($"Ocurrió un error al buscar los clientes: {ex.Message}",
                                "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvClientes.ClearSelection();
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            ActualizarDataGridView(); // Recarga la lista completa de clientes
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick(); // Simula un clic en el botón de buscar
                e.Handled = true;         // Evita el sonido "ding"
            }
        }

        // =======================================================================================
        // MÉTODOS CRUD (SIN CAMBIOS)
        // =======================================================================================

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(false)) return;

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

        // =======================================================================================
        // MÉTODOS AUXILIARES Y DE VALIDACIÓN (SIN CAMBIOS)
        // =======================================================================================

        private bool ValidarCampos(bool esEdicion)
        {
            bool esValido = true;
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            lblErrorNombre.Text = " "; lblErrorApellido.Text = " "; lblErrorDni.Text = " ";
            lblErrorTelefono.Text = " "; lblErrorDireccion.Text = " "; lblErrorPais.Text = " ";
            lblErrorCiudad.Text = " "; lblErrorCorreo.Text = " ";

            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { lblErrorNombre.Text = "El nombre es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { lblErrorApellido.Text = "El apellido es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtDni.Text)) { lblErrorDni.Text = "El DNI es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtDni.Text, @"^\d+$")) { lblErrorDni.Text = "El DNI solo debe contener números."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) { lblErrorTelefono.Text = "El teléfono es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtTelefono.Text, @"^\d+$")) { lblErrorTelefono.Text = "El teléfono solo debe contener números."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { lblErrorDireccion.Text = "La dirección es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtPais.Text)) { lblErrorPais.Text = "El país es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text)) { lblErrorCiudad.Text = "La ciudad es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text)) { lblErrorCorreo.Text = "El correo es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtCorreo.Text, patronEmail)) { lblErrorCorreo.Text = "Formato de correo inválido."; esValido = false; }

            return esValido;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear(); txtApellido.Clear(); txtDni.Clear();
            txtTelefono.Clear(); txtDireccion.Clear(); txtPais.Clear();
            txtCiudad.Clear(); txtCorreo.Clear();
            txtNombre.Focus();

            clienteSeleccionadoId = null;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;

            btnLimpiarBusqueda_Click(null, null);

            dgvClientes.ClearSelection();
            dgvClientes.CurrentCell = null;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Rows[e.RowIndex].DataBoundItem is Cliente fila)
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

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Rows[e.RowIndex].DataBoundItem is Cliente cliente)
            {
                if (cliente != null && !cliente.Activo)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = dgvClientes.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = dgvClientes.DefaultCellStyle.ForeColor;
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
                this.Close();
        }
    }
}