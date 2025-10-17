using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Datos;
using Modelos;

namespace GestionDeVentas.Admin
{
    public partial class ListarProductos : Form
    {
        private DataTable dataTableProductos = new DataTable();
        private readonly ProductoDatos productoDatos = new ProductoDatos();

        // Mapeamos los nuevos controles a las variables que usabas antes para mantener consistencia
        private System.Windows.Forms.Label lblBuscarNombre;
        private System.Windows.Forms.TextBox txtBuscarNombre;

        public ListarProductos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            this.lblBuscarNombre = this.lblBuscar;
            this.txtBuscarNombre = this.txtBusqueda;

            dataGridViewProductos.CellFormatting += dataGridViewProductos_CellFormatting;
        }

        private void ListarProductos_Load(object sender, EventArgs e)
        {
            dataTableProductos.Columns.Add("Id", typeof(int));
            dataTableProductos.Columns.Add("Código", typeof(string));
            dataTableProductos.Columns.Add("Nombre", typeof(string));
            dataTableProductos.Columns.Add("Marca", typeof(string));
            dataTableProductos.Columns.Add("Stock", typeof(int));
            dataTableProductos.Columns.Add("Talle", typeof(string));
            dataTableProductos.Columns.Add("Categoría", typeof(string));
            dataTableProductos.Columns.Add("Estado", typeof(string));

            CargarProductosEnDataTable();

            dataGridViewProductos.DataSource = dataTableProductos;

            if (dataGridViewProductos.Columns.Contains("Id"))
                dataGridViewProductos.Columns["Id"].Visible = false;
            if (dataGridViewProductos.Columns.Contains("Estado"))
                dataGridViewProductos.Columns["Estado"].Visible = false;

            CargarFiltros();

            dataGridViewProductos.Dock = DockStyle.Fill;
            dataGridViewProductos.BringToFront();
        }

        private void CargarProductosEnDataTable()
        {
            dataTableProductos.Rows.Clear();
            var productos = productoDatos.ObtenerProductos();
            var nombreTalles = new Dictionary<int, string>();
            var nombreCategorias = new Dictionary<int, string>();

            foreach (var p in productos)
            {
                string talle = GetNombreTalle(p.IdTalle, nombreTalles);
                string categoria = GetNombreCategoria(p.IdCategoria, nombreCategorias);
                dataTableProductos.Rows.Add(p.Id, p.Codigo, p.Nombre, p.Marca, p.Stock, talle, categoria, p.Estado);
            }
        }

        private string GetNombreTalle(int idTalle, Dictionary<int, string> cache)
        {
            if (idTalle == 0) return "-";
            if (!cache.ContainsKey(idTalle))
            {
                cache[idTalle] = productoDatos.ObtenerNombreTalle(idTalle) ?? "-";
            }
            return cache[idTalle];
        }

        private string GetNombreCategoria(int idCategoria, Dictionary<int, string> cache)
        {
            if (idCategoria == 0) return "-";
            if (!cache.ContainsKey(idCategoria))
            {
                cache[idCategoria] = productoDatos.ObtenerNombreCategoria(idCategoria) ?? "-";
            }
            return cache[idCategoria];
        }

        // --- LÓGICA DE FILTROS ACTUALIZADA ---

        private void CargarFiltros()
        {
            // Carga del desplegable para buscar por Nombre o Código
            cboBuscarPor.Items.Clear();
            cboBuscarPor.Items.Add("Nombre");
            cboBuscarPor.Items.Add("Código");
            cboBuscarPor.SelectedIndex = 0;

            // Carga de Categorías desde la base de datos
            var categorias = productoDatos.ObtenerTodasCategorias();
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;

            // El desplegable de Talle empieza deshabilitado
            cmbTalle.Items.Clear();
            cmbTalle.Items.Add("[Seleccione Categoría]");
            cmbTalle.SelectedIndex = 0;
            cmbTalle.Enabled = false;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();

            if (categoriaSeleccionada != "Todas")
            {
                // Si se elige una categoría, habilitamos y cargamos sus talles
                cmbTalle.Enabled = true;
                var talles = productoDatos.ObtenerTallesPorCategoria(categoriaSeleccionada);
                cmbTalle.Items.Clear();
                cmbTalle.Items.Add("Todos");
                cmbTalle.Items.AddRange(talles.ToArray());
                cmbTalle.SelectedIndex = 0;
            }
            else
            {
                // Si se vuelve a "Todas", deshabilitamos y reseteamos el combo de talles
                cmbTalle.Enabled = false;
                cmbTalle.Items.Clear();
                cmbTalle.Items.Add("[Seleccione Categoría]");
                cmbTalle.SelectedIndex = 0;
            }
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            StringBuilder rowFilter = new StringBuilder();

            // 1. Filtro por Nombre o Código
            string textoBusqueda = txtBusqueda.Text.Trim().Replace("'", "''"); // Evita errores de SQL Injection en el filtro
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                string criterio = cboBuscarPor.SelectedItem.ToString();
                if (criterio == "Nombre")
                {
                    rowFilter.Append($"Nombre LIKE '%{textoBusqueda}%'");
                }
                else // Código
                {
                    rowFilter.Append($"Código LIKE '%{textoBusqueda}%'");
                }
            }

            // 2. Filtro por Categoría
            string filtroCategoria = cmbCategoria.SelectedItem?.ToString();
            if (filtroCategoria != "Todas" && !string.IsNullOrEmpty(filtroCategoria))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Categoría = '{filtroCategoria}'");
            }

            // 3. Filtro por Talle
            if (cmbTalle.Enabled)
            {
                string filtroTalle = cmbTalle.SelectedItem?.ToString();
                if (filtroTalle != "Todos" && !string.IsNullOrEmpty(filtroTalle))
                {
                    if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                    rowFilter.Append($"Talle = '{filtroTalle}'");
                }
            }

            dataTableProductos.DefaultView.RowFilter = rowFilter.ToString();
        }

        // --- Eventos de UI ---

        private void filtros_Aplicar(object sender, EventArgs e)
        {
            // Este único evento se encarga de llamar a AplicarFiltros cuando cualquier control cambia
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Lógica original (sin cambios) ---

        private void dataGridViewProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dataRowView = dataGridViewProductos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dataRowView == null) return;

            string estado = dataRowView.Row.Field<string>("Estado");

            if (!string.IsNullOrEmpty(estado) && estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
            {
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            }
            else
            {
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = (e.RowIndex % 2 != 0) ? SystemColors.ControlLight : SystemColors.Window;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            }
        }

        private void topPanel_Paint(object sender, PaintEventArgs e) { }
        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // Estos métodos ya no son necesarios porque usamos un solo evento "filtros_Aplicar"
        private void txtBuscarNombre_TextChanged(object sender, EventArgs e) { }
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}