using GestionDeVentas.Datos;
using GestionDeVentas.Modelos;
using System;
using System.Windows.Forms;

namespace GestionDeVentas
{
    public partial class BuscarClienteForm : Form
    {
        private ClienteDatos clienteDatos = new ClienteDatos();

        // Propiedad para almacenar el cliente seleccionado
        public Cliente ClienteSeleccionado { get; private set; }

        public BuscarClienteForm()
        {
            InitializeComponent();
            this.Text = "Buscar y Seleccionar Cliente";
        }

        // Evento para realizar la búsqueda manual
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                MessageBox.Show("Ingrese un DNI o Apellido para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarClientes(clienteDatos.BuscarClientes(textoBusqueda));
        }

        // Evento cuando se selecciona una fila y se confirma la selección
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells[0].Value);

                // Guardamos el objeto completo en ClienteSeleccionado
                ClienteSeleccionado = new Cliente
                {
                    Id = id,
                    Dni = dataGridViewClientes.SelectedRows[0].Cells[1].Value.ToString(),
                    Nombre = dataGridViewClientes.SelectedRows[0].Cells[2].Value.ToString(),
                    Apellido = dataGridViewClientes.SelectedRows[0].Cells[3].Value.ToString(),
                    Telefono = dataGridViewClientes.SelectedRows[0].Cells[4].Value.ToString(),
                    CorreoElectronico = dataGridViewClientes.SelectedRows[0].Cells[5].Value.ToString(),
                    Activo = dataGridViewClientes.SelectedRows[0].Cells[6].Value.ToString() == "Activo"
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BuscarClienteForm_Load(object sender, EventArgs e)
        {
            // Configurar columnas si no lo hiciste en el diseñador
            dataGridViewClientes.Columns.Clear();
            dataGridViewClientes.Columns.Add("Id", "ID");
            dataGridViewClientes.Columns["Id"].Visible = false;
            dataGridViewClientes.Columns.Add("Dni", "DNI");
            dataGridViewClientes.Columns.Add("Nombre", "Nombre");
            dataGridViewClientes.Columns.Add("Apellido", "Apellido");
            dataGridViewClientes.Columns.Add("Telefono", "Teléfono");
            dataGridViewClientes.Columns.Add("Correo", "Correo");
            dataGridViewClientes.Columns.Add("Estado", "Estado");

            dataGridViewClientes.AllowUserToResizeRows = false;
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 🔹 Al cargar el formulario, muestro solo los clientes activos
            var clientesActivos = clienteDatos.ObtenerClientes().FindAll(c => c.Activo);
            CargarClientes(clientesActivos);
        }

        // Método auxiliar para cargar clientes en la grilla
        private void CargarClientes(System.Collections.Generic.List<Cliente> clientes)
        {
            dataGridViewClientes.Rows.Clear();

            foreach (var c in clientes)
            {
                string estado = c.Activo ? "Activo" : "Inactivo";
                dataGridViewClientes.Rows.Add(c.Id, c.Dni, c.Nombre, c.Apellido, c.Telefono, c.CorreoElectronico, estado);
            }

            dataGridViewClientes.ClearSelection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
