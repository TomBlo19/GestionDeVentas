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
        private List<Producto> todosLosProductosActivos; // Lista para filtrar en memoria

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
            public string TalleNombre { get; set; }
            public string Codigo { get; set; }
            public decimal Precio { get; set; }
            public int StockDisponible { get; set; }
        }

        private void BuscarProductoForm_Load(object sender, EventArgs e)
        {
            try
            {
                // <<<--- PASO 1: Cargamos la lista de productos de la base de datos --- >>>
                todosLosProductosActivos = productoDatos.ObtenerProductos()
                    .Where(p => string.Equals(p.Estado, "Activo", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // <<<--- PASO 2: Llenamos los ComboBox con sus opciones --- >>>
                ConfigurarFiltros();

                // <<<--- PASO 3: AHORA SÍ, mostramos los datos en la grilla --- >>>
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cerramos el formulario si no se pueden cargar los datos
            }
        }

        private void ConfigurarFiltros()
        {
            // Configurar desplegable de búsqueda por Nombre/Código
            cboBuscarPor.Items.Clear();
            cboBuscarPor.Items.Add("Nombre");
            cboBuscarPor.Items.Add("Código");
            cboBuscarPor.SelectedIndex = 0;

            // Configurar desplegable de Categorías
            var categorias = todosLosProductosActivos
                .Select(p => p.CategoriaNombre)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;

            // Configurar desplegable de Talle (inicialmente deshabilitado)
            cmbTalle.Items.Clear();
            cmbTalle.Items.Add("[Seleccione Categoría]");
            cmbTalle.SelectedIndex = 0;
            cmbTalle.Enabled = false;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que haya algo seleccionado para evitar errores
            if (cmbCategoria.SelectedItem == null) return;

            string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();

            if (categoriaSeleccionada != "Todas")
            {
                cmbTalle.Enabled = true;
                var talles = todosLosProductosActivos
                    .Where(p => p.CategoriaNombre == categoriaSeleccionada)
                    .Select(p => p.TalleNombre)
                    .Distinct()
                    .OrderBy(t => t)
                    .ToList();

                cmbTalle.Items.Clear();
                cmbTalle.Items.Add("Todos");
                cmbTalle.Items.AddRange(talles.ToArray());
                cmbTalle.SelectedIndex = 0;
            }
            else
            {
                cmbTalle.Enabled = false;
                cmbTalle.Items.Clear();
                cmbTalle.Items.Add("[Seleccione Categoría]");
                cmbTalle.SelectedIndex = 0;
            }
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            // Si la lista principal no se cargó, no hacemos nada
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

            // 2. Filtro por Categoría (AHORA ES SEGURO)
            if (cmbCategoria.SelectedItem != null)
            {
                string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();
                if (categoriaSeleccionada != "Todas")
                {
                    productosFiltrados = productosFiltrados.Where(p => p.CategoriaNombre == categoriaSeleccionada);
                }
            }

            // 3. Filtro por Talle
            if (cmbTalle.Enabled && cmbTalle.SelectedItem != null)
            {
                string talleSeleccionado = cmbTalle.SelectedItem.ToString();
                if (talleSeleccionado != "Todos")
                {
                    productosFiltrados = productosFiltrados.Where(p => p.TalleNombre == talleSeleccionado);
                }
            }

            // Proyectar los datos para la grilla y asignarlos
            var datosParaMostrar = productosFiltrados.Select(p => new
            {
                ID = p.Id,
                p.Codigo,
                p.Nombre,
                Talle = p.TalleNombre,
                p.Precio,
                Stock = p.Stock
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
                TalleNombre = row.Cells["Talle"].Value?.ToString(),
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

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }
    }
}
