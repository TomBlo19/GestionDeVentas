using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestionDeVentas.Vendedor
{
    public partial class FormRegistrarCliente : Form
    {
        private List<Cliente> listaClientes = new List<Cliente>();

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
            ActualizarDataGridView();
            dgvClientes.Visible = true;
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AllowUserToResizeColumns = true;
            dgvClientes.ReadOnly = true;

            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("Id", "ID");
            dgvClientes.Columns.Add("Nombre", "Nombre");
            dgvClientes.Columns.Add("Apellido", "Apellido");
            dgvClientes.Columns.Add("Dni", "DNI");
            dgvClientes.Columns.Add("Telefono", "Teléfono");
            dgvClientes.Columns.Add("Direccion", "Dirección");
            dgvClientes.Columns.Add("Pais", "País");
            dgvClientes.Columns.Add("Ciudad", "Ciudad");
            dgvClientes.Columns.Add("FechaNacimiento", "Fecha de Nacimiento");
        }

        private void ActualizarDataGridView()
        {
            dgvClientes.Rows.Clear();
            foreach (var cliente in listaClientes)
            {
                dgvClientes.Rows.Add(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.Telefono, cliente.Direccion, cliente.Pais, cliente.Ciudad, cliente.FechaNacimiento.ToShortDateString());
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
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

        private bool ValidarCampos()
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
            else if (listaClientes.Any(c => c.Dni == txtDni.Text))
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
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaClientes.Count)
            {
                var clienteSeleccionado = listaClientes[e.RowIndex];
                txtNombre.Text = clienteSeleccionado.Nombre;
                txtApellido.Text = clienteSeleccionado.Apellido;
                txtDni.Text = clienteSeleccionado.Dni;
                txtTelefono.Text = clienteSeleccionado.Telefono;
                txtDireccion.Text = clienteSeleccionado.Direccion;
                txtPais.Text = clienteSeleccionado.Pais;
                txtCiudad.Text = clienteSeleccionado.Ciudad;
                dtpFechaNacimiento.Value = clienteSeleccionado.FechaNacimiento;
                dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
    }


    // La clase Cliente debe estar en un archivo separado para una mejor organización,
    // pero para evitar el error de "diseño", la podemos dejar aquí, como en tu código de Usuario.
    public class Cliente
    {
        public static int IdCounter = 0;
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Cliente()
        {
            Id = ++IdCounter;
        }
    }
}