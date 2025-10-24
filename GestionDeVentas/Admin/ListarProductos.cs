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

        public ListarProductos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
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

            foreach (var p in productos)
            {
                dataTableProductos.Rows.Add(p.Id, p.Codigo, p.Nombre, p.Marca, p.Stock, p.TalleNombre, p.CategoriaNombre, p.Estado);
            }
        }

        private void CargarFiltros()
        {
            // Carga del desplegable para buscar por Nombre o Código
            cboBuscarPor.Items.Clear();
            cboBuscarPor.Items.Add("Nombre");
            cboBuscarPor.Items.Add("Código");
            cboBuscarPor.SelectedIndex = 0;

            // Carga de Categorías
            var categorias = dataTableProductos.AsEnumerable()
                                               .Select(row => row.Field<string>("Categoría"))
                                               .Distinct().OrderBy(c => c).ToList();
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;

            // Carga de Marcas
            var marcas = dataTableProductos.AsEnumerable()
                                           .Select(row => row.Field<string>("Marca"))
                                           .Where(m => !string.IsNullOrEmpty(m)) // Ignorar marcas vacías
                                           .Distinct().OrderBy(m => m).ToList();
            cmbMarca.Items.Clear();
            cmbMarca.Items.Add("Todas");
            cmbMarca.Items.AddRange(marcas.ToArray());
            cmbMarca.SelectedIndex = 0;
        }

        private void AplicarFiltros()
        {
            StringBuilder rowFilter = new StringBuilder();

            // 1. Filtro por Nombre o Código
            string textoBusqueda = txtBusqueda.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                string criterio = cboBuscarPor.SelectedItem.ToString();
                rowFilter.Append($"[{criterio}] LIKE '%{textoBusqueda}%'");
            }

            // 2. Filtro por Categoría
            string filtroCategoria = cmbCategoria.SelectedItem?.ToString();
            if (filtroCategoria != "Todas" && !string.IsNullOrEmpty(filtroCategoria))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Categoría = '{filtroCategoria}'");
            }

            // 3. Filtro por Marca 
            string filtroMarca = cmbMarca.SelectedItem?.ToString();
            if (filtroMarca != "Todas" && !string.IsNullOrEmpty(filtroMarca))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Marca = '{filtroMarca}'");
            }

            dataTableProductos.DefaultView.RowFilter = rowFilter.ToString();
        }

        private void filtros_Aplicar(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dataRowView = dataGridViewProductos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dataRowView == null) return;

            string estado = dataRowView.Row.Field<string>("Estado");

            if (estado != null && estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.LightCoral;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                e.CellStyle.BackColor = (e.RowIndex % 2 != 0) ? SystemColors.ControlLight : SystemColors.Window;
                e.CellStyle.ForeColor = SystemColors.ControlText;
                e.CellStyle.SelectionBackColor = SystemColors.Highlight;
                e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
            }
        }

        private void topPanel_Paint_1(object sender, PaintEventArgs e) { }
    }
}