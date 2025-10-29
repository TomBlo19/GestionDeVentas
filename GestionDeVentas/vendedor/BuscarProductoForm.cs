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
        private List<Producto> todosLosProductosActivos;

        public ProductoInfo ProductoSeleccionado { get; private set; }

        public BuscarProductoForm()
        {
            InitializeComponent();
            this.Text = "Buscar y Seleccionar Producto";
        }

        // Clase interna para devolver solo la información necesaria
        public class ProductoInfo
        {
            public string Nombre { get; set; }
            public string Marca { get; set; }
            public string Codigo { get; set; }
            public decimal Precio { get; set; }
            public int StockDisponible { get; set; }
        }

        private void BuscarProductoForm_Load(object sender, EventArgs e)
        {
            try
            {
                todosLosProductosActivos = productoDatos.ObtenerProductos()
                    .Where(p => string.Equals(p.Estado, "Activo", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                ConfigurarFiltros();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ConfigurarFiltros()
        {
            cboBuscarPor.Items.Clear();
            cboBuscarPor.Items.Add("Nombre");
            cboBuscarPor.Items.Add("Código");
            // ✨ CAMBIO: Se agrega "Marca" como nueva opción de búsqueda.
            cboBuscarPor.Items.Add("Marca");
            cboBuscarPor.SelectedIndex = 0;

            var categorias = todosLosProductosActivos
                .Select(p => p.CategoriaNombre)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;

            // ✨ CAMBIO: Se elimina por completo el bloque de código que configuraba el ComboBox de Marcas.
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (todosLosProductosActivos == null) return;

            IEnumerable<Producto> productosFiltrados = todosLosProductosActivos;

            // 1. Filtro por Nombre, Código o Marca
            string terminoBusqueda = txtBusqueda.Text.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(terminoBusqueda) && cboBuscarPor.SelectedItem != null)
            {
                string criterio = cboBuscarPor.SelectedItem.ToString();

                // ✨ CAMBIO: Se reemplaza el if/else por un switch para incluir la nueva opción "Marca".
                switch (criterio)
                {
                    case "Nombre":
                        productosFiltrados = productosFiltrados.Where(p => p.Nombre.ToLowerInvariant().Contains(terminoBusqueda));
                        break;
                    case "Código":
                        productosFiltrados = productosFiltrados.Where(p => p.Codigo.ToLowerInvariant().Contains(terminoBusqueda));
                        break;
                    case "Marca":
                        productosFiltrados = productosFiltrados.Where(p => p.Marca != null && p.Marca.ToLowerInvariant().Contains(terminoBusqueda));
                        break;
                }
            }

            // 2. Filtro por Categoría
            if (cmbCategoria.SelectedItem != null)
            {
                string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();
                if (categoriaSeleccionada != "Todas")
                {
                    productosFiltrados = productosFiltrados.Where(p => p.CategoriaNombre == categoriaSeleccionada);
                }
            }

            // ✨ CAMBIO: Se elimina el bloque de código que filtraba por el ComboBox de Marcas.

            var datosParaMostrar = productosFiltrados.Select(p => new
            {
                ID = p.Id,
                p.Codigo,
                p.Nombre,
                p.Marca,
                p.Precio,
                p.Stock
            }).ToList();

            dataGridViewProductos.DataSource = datosParaMostrar;

            if (dataGridViewProductos.Columns.Contains("ID"))
                dataGridViewProductos.Columns["ID"].Visible = false;

            dataGridViewProductos.ClearSelection();
        }

        private void btnBuscar_Click(object sender, EventArgs e) => AplicarFiltros();
        private void filtros_Changed(object sender, EventArgs e) => AplicarFiltros();

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cboBuscarPor.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;
            // ✨ CAMBIO: Se elimina la limpieza del ComboBox de Marcas.
            AplicarFiltros();
        }

        private void SeleccionarProducto()
        {
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridViewProductos.SelectedRows[0];

            ProductoSeleccionado = new ProductoInfo
            {
                Codigo = row.Cells["Codigo"].Value.ToString(),
                Nombre = row.Cells["Nombre"].Value.ToString(),
                Marca = row.Cells["Marca"].Value?.ToString(),
                Precio = Convert.ToDecimal(row.Cells["Precio"].Value),
                StockDisponible = Convert.ToInt32(row.Cells["Stock"].Value)
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e) => SeleccionarProducto();

        private void dataGridViewProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                SeleccionarProducto();
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AplicarFiltros();
            }
        }
    }
}