using System;
using System.Data;
using System.Windows.Forms;

namespace TuProyecto
{
    public partial class BuscarProductoForm : Form
    {
        // Propiedad compleja para almacenar la información completa del producto
        public ProductoInfo ProductoSeleccionado { get; private set; }

        public BuscarProductoForm()
        {
            InitializeComponent();
            this.Text = "Buscar y Seleccionar Producto";
        }

        // Clase auxiliar para guardar los datos del producto (ID, Nombre, Precio, Stock, etc.)
        public class ProductoInfo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int StockDisponible { get; set; }
        }

        // Evento para realizar la búsqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text.Trim();

            // LÓGICA DE BÚSQUEDA REAL: 
            // Aquí iría el código que llama a tu base de datos para llenar el 'dataGridViewProductos'.
            // Asegúrate de traer las columnas: ID, Nombre, Precio y STOCK.

            // EJEMPLO (Simulación de datos):
            MessageBox.Show($"Buscando productos que coincidan con: {textoBusqueda}", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Asumiendo que el DataGridView se llenó correctamente.
        }

        // Evento cuando se selecciona una fila y se confirma la selección
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewProductos.SelectedRows[0];

                // Se asume que las columnas están en un orden conocido o nombrado:
                // Columna 0 = ID, Columna 1 = Nombre, Columna 2 = Precio, Columna 3 = Stock
                ProductoSeleccionado = new ProductoInfo
                {
                    Id = Convert.ToInt32(row.Cells[0].Value),
                    Nombre = row.Cells[1].Value.ToString(),
                    Precio = Convert.ToDecimal(row.Cells[2].Value),
                    StockDisponible = Convert.ToInt32(row.Cells[3].Value)
                };

                // Cierra la ventana, retornando el objeto ProductoSeleccionado a Form1
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}