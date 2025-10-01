using System;
using System.Data;
using System.Windows.Forms;

namespace TuProyecto
{
    public partial class BuscarClienteForm : Form
    {
        // Propiedad para almacenar el cliente seleccionado
        public string ClienteSeleccionado { get; private set; }

        public BuscarClienteForm()
        {
            InitializeComponent();
            this.Text = "Buscar y Seleccionar Cliente";
        }

        // Evento para realizar la búsqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text.Trim();

            // LÓGICA DE BÚSQUEDA REAL: 
            // Aquí iría el código que llama a tu base de datos (SQL, etc.) 
            // usando 'textoBusqueda' para llenar el 'dataGridViewClientes'.

            // EJEMPLO (Simulación de datos):
            MessageBox.Show($"Buscando clientes que coincidan con: {textoBusqueda}", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Asumiendo que el DataGridView se llenó correctamente.
        }

        // Evento cuando se selecciona una fila y se confirma la selección
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Ejemplo: Obtener el valor de la primera celda (ej. ID o Nombre)
                ClienteSeleccionado = dataGridViewClientes.SelectedRows[0].Cells[0].Value.ToString();

                // Cierra la ventana, retornando el control a Form1
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}