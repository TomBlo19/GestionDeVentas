using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Datos;
using Modelos;

namespace GestionDeVentas
{
    public partial class BuscarProductoForm : Form
    {
        private readonly ProductoDatos productoDatos = new ProductoDatos();

        public ProductoInfo ProductoSeleccionado { get; private set; }

        public BuscarProductoForm()
        {
            InitializeComponent();
            this.Text = "Buscar y Seleccionar Producto";
        }

        public class ProductoInfo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string TalleNombre { get; set; }     // ✅ agregado
            public decimal Precio { get; set; }
            public int StockDisponible { get; set; }
        }

        private void BuscarProductoForm_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos(string filtro = "")
        {
            try
            {
                List<Producto> productos = productoDatos.ObtenerProductos();

                // Solo productos activos
                productos = productos
                    .Where(p => string.Equals(p.Estado, "Activo", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Filtrar por texto
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.ToLower();
                    productos = productos
                        .Where(p =>
                            p.Nombre.ToLower().Contains(filtro) ||
                            p.Codigo.ToLower().Contains(filtro))
                        .ToList();
                }

                // Mostrar datos relevantes
                var datosMostrar = productos.Select(p => new
                {
                    ID = p.Id,
                    Nombre = p.Nombre,
                    Talle = p.TalleNombre,   // ✅ mostramos el talle real
                    Precio = p.Precio,
                    Stock = p.Stock
                }).ToList();

                dataGridViewProductos.DataSource = datosMostrar;
                dataGridViewProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBusqueda.Text.Trim();
            CargarProductos(textoBusqueda);
        }

        private void dataGridViewProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                SeleccionarProducto();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarProducto();
        }

        private void SeleccionarProducto()
        {
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridViewProductos.SelectedRows[0];

            ProductoSeleccionado = new ProductoInfo
            {
                Id = Convert.ToInt32(row.Cells["ID"].Value),
                Nombre = row.Cells["Nombre"].Value.ToString(),
                TalleNombre = row.Cells["Talle"].Value?.ToString(),  // ✅ trae el talle real
                Precio = Convert.ToDecimal(row.Cells["Precio"].Value),
                StockDisponible = Convert.ToInt32(row.Cells["Stock"].Value)
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }
    }
}
