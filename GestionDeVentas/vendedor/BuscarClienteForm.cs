using GestionDeVentas.Datos;
using GestionDeVentas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Modelos;
using Datos;

namespace GestionDeVentas
{
    public partial class BuscarClienteForm : Form
    {
        private readonly ClienteDatos clienteDatos = new ClienteDatos();
        public Cliente ClienteSeleccionado { get; private set; }

        public BuscarClienteForm()
        {
            InitializeComponent();
        }

        private void BuscarClienteForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            ConfigurarBusqueda();
            CargarClientesIniciales();
        }

        private void ConfigurarGrilla()
        {
            dataGridViewClientes.AutoGenerateColumns = false;
            dataGridViewClientes.Columns.Clear();

            // Usamos DataPropertyName para vincular la columna a la propiedad del objeto Cliente
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dni", HeaderText = "DNI" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellido" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Teléfono" });
            dataGridViewClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CorreoElectronico", HeaderText = "Correo" });
        }

        private void ConfigurarBusqueda()
        {
            cboBuscarPor.Items.Add("DNI");
            cboBuscarPor.Items.Add("Apellido");
            cboBuscarPor.SelectedIndex = 0;
        }

        private void CargarClientesIniciales()
        {
            try
            {
                // Al inicio, cargamos solo los clientes activos
                var clientesActivos = clienteDatos.ObtenerClientes().Where(c => c.Activo).ToList();
                ActualizarGrilla(clientesActivos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = cboBuscarPor.SelectedItem.ToString();
            string valorBusqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(valorBusqueda))
            {
                // Si el campo está vacío, mostramos la lista inicial de activos
                CargarClientesIniciales();
                return;
            }

            try
            {
                List<Cliente> clientesEncontrados;

                // Llamamos al método de la base de datos correspondiente
                if (criterio == "DNI")
                {
                    clientesEncontrados = clienteDatos.BuscarClientesPorDni(valorBusqueda);
                }
                else // Apellido
                {
                    clientesEncontrados = clienteDatos.BuscarClientesPorApellido(valorBusqueda);
                }

                // Filtramos para mostrar solo los activos en los resultados de búsqueda
                var clientesActivos = clientesEncontrados.Where(c => c.Activo).ToList();
                ActualizarGrilla(clientesActivos);

                if (!clientesActivos.Any())
                {
                    MessageBox.Show("No se encontraron clientes activos con ese criterio.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            CargarClientesIniciales(); // Vuelve a cargar la lista original de clientes activos
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Forma segura de obtener el objeto Cliente completo de la fila seleccionada
                ClienteSeleccionado = dataGridViewClientes.SelectedRows[0].DataBoundItem as Cliente;

                if (ClienteSeleccionado != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarGrilla(List<Cliente> clientes)
        {
            dataGridViewClientes.DataSource = null; // Limpia el datasource anterior
            dataGridViewClientes.DataSource = clientes;
            dataGridViewClientes.ClearSelection();
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true; // Evita el sonido de "beep"
            }
        }
    }
}