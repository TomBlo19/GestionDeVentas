using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestionDeVentas.Gerente
{
    public partial class FormRegistrarCliente : Form
    {
        private List<Cliente> listaClientes = new List<Cliente>();
        private int? clienteSeleccionadoId = null;

        public FormRegistrarCliente()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            this.txtNombre.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtApellido.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtPais.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCiudad.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtDni.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
        }

        private void FormRegistrarCliente_Load(object sender, EventArgs e)
        {
            // Agregamos algunos clientes de ejemplo para que la tabla no esté vacía al iniciar.
            listaClientes.Add(new Cliente { Nombre = "Juan", Apellido = "Pérez", Dni = "12345678", Telefono = "11223344", Direccion = "Calle Falsa 123", Pais = "Argentina", Ciudad = "Buenos Aires", FechaNacimiento = new DateTime(1990, 5, 15) });
            listaClientes.Add(new Cliente { Nombre = "Maria", Apellido = "Gómez", Dni = "87654321", Telefono = "55667788", Direccion = "Avenida Siempreviva 742", Pais = "Argentina", Ciudad = "Rosario", FechaNacimiento = new DateTime(1985, 10, 20), Activo = false });
            listaClientes.Add(new Cliente { Nombre = "Carlos", Apellido = "López", Dni = "99887766", Telefono = "99887766", Direccion = "Calle 10 555", Pais = "Chile", Ciudad = "Santiago", FechaNacimiento = new DateTime(1995, 3, 30) });

            ActualizarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            // Las columnas se definen en el archivo .Designer.
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AllowUserToResizeColumns = true;
            dgvClientes.ReadOnly = true;
        }

        private void ActualizarDataGridView()
        {
            dgvClientes.Rows.Clear();
            foreach (var cliente in listaClientes)
            {
                string estado = cliente.Activo ? "Activo" : "Inactivo";
                dgvClientes.Rows.Add(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Telefono, cliente.Direccion, cliente.Pais, cliente.Ciudad, cliente.FechaNacimiento.ToShortDateString(), estado);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(false))
            {
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Dni = txtDni.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Pais = txtPais.Text,
                    Ciudad = txtCiudad.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value
                };

                listaClientes.Add(nuevoCliente);
                MessageBox.Show("Cliente registrado correctamente!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                ActualizarDataGridView();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId.HasValue && ValidarCampos(true))
            {
                var clienteAEditar = listaClientes.FirstOrDefault(c => c.Id == clienteSeleccionadoId.Value);
                if (clienteAEditar != null)
                {
                    clienteAEditar.Nombre = txtNombre.Text;
                    clienteAEditar.Apellido = txtApellido.Text;
                    clienteAEditar.Dni = txtDni.Text;
                    clienteAEditar.Telefono = txtTelefono.Text;
                    clienteAEditar.Direccion = txtDireccion.Text;
                    clienteAEditar.Pais = txtPais.Text;
                    clienteAEditar.Ciudad = txtCiudad.Text;
                    clienteAEditar.FechaNacimiento = dtpFechaNacimiento.Value;

                    MessageBox.Show("Cliente editado correctamente!", "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    ActualizarDataGridView();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId.HasValue)
            {
                var clienteAEliminar = listaClientes.FirstOrDefault(c => c.Id == clienteSeleccionadoId.Value);
                if (clienteAEliminar != null)
                {
                    if (clienteAEliminar.Activo)
                    {
                        clienteAEliminar.Activo = false;
                        MessageBox.Show("Cliente eliminado (desactivado) correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        clienteAEliminar.Activo = true;
                        MessageBox.Show("Cliente activado correctamente.", "Activación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LimpiarCampos();
                    ActualizarDataGridView();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private bool ValidarCampos(bool esEdicion)
        {
            bool esValido = true;

            lblErrorNombre.Text = " ";
            lblErrorApellido.Text = " ";
            lblErrorDni.Text = " ";
            lblErrorTelefono.Text = " ";
            lblErrorDireccion.Text = " ";
            lblErrorPais.Text = " ";
            lblErrorCiudad.Text = " ";
            lblErrorFechaNacimiento.Text = " ";

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblErrorNombre.Text = "El nombre es obligatorio.";
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                lblErrorApellido.Text = "El apellido es obligatorio.";
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                lblErrorDni.Text = "El DNI es obligatorio.";
                esValido = false;
            }
            else if (!Regex.IsMatch(txtDni.Text, @"^\d+$"))
            {
                lblErrorDni.Text = "El DNI solo puede contener números.";
                esValido = false;
            }
            else if (listaClientes.Any(c => c.Dni == txtDni.Text && (esEdicion == false || c.Id != clienteSeleccionadoId)))
            {
                lblErrorDni.Text = "Este DNI ya existe.";
                esValido = false;
            }

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
                lblErrorFechaNacimiento.Text = "La fecha de nacimiento no es válida.";
                esValido = false;
            }

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
            dtpFechaNacimiento.Value = DateTime.Now;
            txtNombre.Focus();

            clienteSeleccionadoId = null;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnEliminar.Text = "Eliminar Cliente";
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaClientes.Count)
            {
                var clienteSeleccionado = listaClientes[e.RowIndex];
                clienteSeleccionadoId = clienteSeleccionado.Id;

                txtNombre.Text = clienteSeleccionado.Nombre;
                txtApellido.Text = clienteSeleccionado.Apellido;
                txtDni.Text = clienteSeleccionado.Dni;
                txtTelefono.Text = clienteSeleccionado.Telefono;
                txtDireccion.Text = clienteSeleccionado.Direccion;
                txtPais.Text = clienteSeleccionado.Pais;
                txtCiudad.Text = clienteSeleccionado.Ciudad;
                dtpFechaNacimiento.Value = clienteSeleccionado.FechaNacimiento;

                btnRegistrar.Visible = false;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;

                if (clienteSeleccionado.Activo)
                {
                    btnEliminar.Text = "Eliminar Cliente";
                }
                else
                {
                    btnEliminar.Text = "Activar Cliente";
                }
            }
            else
            {
                LimpiarCampos();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Cliente
    {
        private static int IdCounter = 0;
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; } = true;

        public Cliente()
        {
            Id = ++IdCounter;
        }
    }
}