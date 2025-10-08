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
        // Instancia de la capa de datos
        private readonly ProductoDatos productoDatos = new ProductoDatos();

        public ListarProductos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            // Conectar el evento de formato condicional
            dataGridViewProductos.CellFormatting += dataGridViewProductos_CellFormatting;
        }

        private void ListarProductos_Load(object sender, EventArgs e)
        {
            // 1. Definición de las columnas del DataTable (Necesario para los filtros y el formato)
            dataTableProductos.Columns.Add("Id", typeof(int));
            dataTableProductos.Columns.Add("Código", typeof(string));
            dataTableProductos.Columns.Add("Nombre", typeof(string));
            dataTableProductos.Columns.Add("Marca", typeof(string));
            dataTableProductos.Columns.Add("Stock", typeof(int));
            dataTableProductos.Columns.Add("Talle", typeof(string));
            dataTableProductos.Columns.Add("Categoría", typeof(string));
            dataTableProductos.Columns.Add("Estado", typeof(string)); // <-- CRUCIAL PARA EL COLOR

            // 2. Cargar datos reales de la BDD
            CargarProductosEnDataTable();

            // 3. Asignamos el DataTable como origen de datos.
            dataGridViewProductos.DataSource = dataTableProductos;

            // 4. Ocultar columnas internas (Id y Estado)
            if (dataGridViewProductos.Columns.Contains("Id"))
                dataGridViewProductos.Columns["Id"].Visible = false;
            if (dataGridViewProductos.Columns.Contains("Estado"))
                dataGridViewProductos.Columns["Estado"].Visible = false;

            CargarFiltros();

            dataGridViewProductos.Dock = DockStyle.Fill;
            dataGridViewProductos.BringToFront();
        }

        // --- Carga de datos reales de la BDD ---
        private void CargarProductosEnDataTable()
        {
            dataTableProductos.Rows.Clear();
            var productos = productoDatos.ObtenerProductos();

            // Cache para evitar consultas repetidas
            var nombreTalles = new Dictionary<int, string>();
            var nombreCategorias = new Dictionary<int, string>();

            foreach (var p in productos)
            {
                // Obtenemos los nombres usando la capa de datos
                string talle = GetNombreTalle(p.IdTalle, nombreTalles);
                string categoria = GetNombreCategoria(p.IdCategoria, nombreCategorias);

                dataTableProductos.Rows.Add(
                    p.Id,
                    p.Codigo,
                    p.Nombre,
                    p.Marca,
                    p.Stock,
                    talle,
                    categoria,
                    p.Estado // <-- Usamos el estado real
                );
            }
        }

        // Métodos auxiliares para obtener nombres (llaman a ProductoDatos)
        private string GetNombreTalle(int idTalle, Dictionary<int, string> cache)
        {
            if (idTalle == 0) return "-";
            if (!cache.ContainsKey(idTalle))
            {
                // Asume que este método ya existe en ProductoDatos
                cache[idTalle] = productoDatos.ObtenerNombreTalle(idTalle) ?? "-";
            }
            return cache[idTalle];
        }

        private string GetNombreCategoria(int idCategoria, Dictionary<int, string> cache)
        {
            if (idCategoria == 0) return "-";
            if (!cache.ContainsKey(idCategoria))
            {
                // Asume que este método ya existe en ProductoDatos
                cache[idCategoria] = productoDatos.ObtenerNombreCategoria(idCategoria) ?? "-";
            }
            return cache[idCategoria];
        }

        // 🔴 Formato condicional: Pinta la línea en rojo si el producto está Inactivo
        private void dataGridViewProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dataRowView = dataGridViewProductos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dataRowView == null) return;

            // Obtenemos el valor de la columna "Estado"
            string estado = dataRowView.Row.Field<string>("Estado");

            if (!string.IsNullOrEmpty(estado) && estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
            {
                // Estilo para filas INACTIVAS
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            }
            else
            {
                // Restablecer estilos para filas ACTIVAS (manteniendo el alternado visual)
                if (e.RowIndex % 2 != 0)
                {
                    dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.ControlLight;
                }
                else
                {
                    dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                }
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                dataGridViewProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            }
        }

        // =========================================================================
        //  MÉTODOS DE FILTROS (Sin el filtro de Estado)
        // =========================================================================

        private void CargarFiltros()
        {
            // Carga y configuración del filtro de Talle
            var talles = dataTableProductos.AsEnumerable()
                                             .Select(row => row.Field<string>("Talle"))
                                             .Distinct()
                                             .Where(t => !string.IsNullOrEmpty(t) && t != "-")
                                             .ToList();
            talles.Sort();
            cmbTalle.Items.Clear();
            cmbTalle.Items.Add("Todos");
            cmbTalle.Items.AddRange(talles.ToArray());
            cmbTalle.SelectedIndex = 0;

            // Carga y configuración del filtro de Categoría
            var categorias = dataTableProductos.AsEnumerable()
                                               .Select(row => row.Field<string>("Categoría"))
                                               .Distinct()
                                               .Where(c => !string.IsNullOrEmpty(c) && c != "-")
                                               .ToList();
            categorias.Sort();
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;

            // *** Se ha eliminado la carga del cmbEstado ***
        }

        private void AplicarFiltros()
        {
            string filtroNombre = txtBuscarNombre.Text.Trim();
            string filtroTalle = cmbTalle.SelectedItem?.ToString();
            string filtroCategoria = cmbCategoria.SelectedItem?.ToString();

            StringBuilder rowFilter = new StringBuilder();

            // Filtro por Nombre o Código
            if (!string.IsNullOrEmpty(filtroNombre))
            {
                rowFilter.Append($"(Nombre LIKE '%{filtroNombre.Replace("'", "''")}%' OR Código LIKE '%{filtroNombre.Replace("'", "''")}%')");
            }

            // Filtro por Talle
            if (filtroTalle != "Todos" && !string.IsNullOrEmpty(filtroTalle))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Talle = '{filtroTalle.Replace("'", "''")}'");
            }

            // Filtro por Categoría
            if (filtroCategoria != "Todas" && !string.IsNullOrEmpty(filtroCategoria))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Categoría = '{filtroCategoria.Replace("'", "''")}'");
            }

            // Mantenemos visible solo los activos por defecto (Opcional, si la BDD trae todos)
            // Si ObtenerProductos() trae TODOS, podemos forzar el filtro a solo Activos aquí:
            /*
            if (rowFilter.Length > 0) rowFilter.Append(" AND ");
            rowFilter.Append($"Estado = 'Activo'");
            */


            dataTableProductos.DefaultView.RowFilter = rowFilter.Length > 0 ? rowFilter.ToString() : string.Empty;
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Se unifica el manejador de cambios de selección para ambos combos de filtro
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { /* ... */ }
        private void topPanel_Paint(object sender, PaintEventArgs e) { /* ... */ }
    }
}