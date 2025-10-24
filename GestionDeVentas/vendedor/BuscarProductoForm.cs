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
            public string Marca { get; set; } // Propiedad cambiada de TalleNombre a Marca
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

            // Configurar desplegable de Marcas
            var marcas = todosLosProductosActivos
                .Select(p => p.Marca)
                .Where(m => !string.IsNullOrEmpty(m))
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            cmbMarca.Items.Clear();
            cmbMarca.Items.Add("Todas");
            cmbMarca.Items.AddRange(marcas.ToArray());
            cmbMarca.SelectedIndex = 0;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // El filtro de marca es independiente de la categoría, solo aplicamos filtros.
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (todosLosProductosActivos == null) return;

            IEnumerable<Producto> productosFiltrados = todosLosProductosActivos;

            // 1. Filtro por Nombre o Código
            string terminoBusqueda = txtBusqueda.Text.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(terminoBusqueda) && cboBuscarPor.SelectedItem != null)
            {
                string criterio = cboBuscarPor.SelectedItem.ToString();
                if (criterio == "Nombre")
                {
                    productosFiltrados = productosFiltrados.Where(p => p.Nombre.ToLowerInvariant().Contains(terminoBusqueda));
                }
                else // Código
                {
                    productosFiltrados = productosFiltrados.Where(p => p.Codigo.ToLowerInvariant().Contains(terminoBusqueda));
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

            // 3. Filtro por Marca (reemplaza el de Talle)
            if (cmbMarca.SelectedItem != null)
            {
                string marcaSeleccionada = cmbMarca.SelectedItem.ToString();
                if (marcaSeleccionada != "Todas")
                {
                    productosFiltrados = productosFiltrados.Where(p => p.Marca == marcaSeleccionada);
                }
            }

            var datosParaMostrar = productosFiltrados.Select(p => new
            {
                ID = p.Id,
                p.Codigo,
                p.Nombre,
                p.Marca, // Propiedad cambiada
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
            cmbMarca.SelectedIndex = 0; // Limpiar también el filtro de marca
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
                Marca = row.Cells["Marca"].Value?.ToString(), // Propiedad cambiada
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