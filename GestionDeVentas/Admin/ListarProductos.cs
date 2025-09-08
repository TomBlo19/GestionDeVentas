using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GestionDeVentas.Admin
{
    public partial class ListarProductos : Form
    {
        private DataTable dataTableProductos = new DataTable();

        public ListarProductos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ListarProductos_Load(object sender, EventArgs e)
        {
            // La única configuración que necesitamos para el DataTable
            // es agregar las columnas que vamos a usar en el código,
            // incluyendo las de los filtros, para que el .DefaultView.RowFilter funcione.
            dataTableProductos.Columns.Add("Código", typeof(string));
            dataTableProductos.Columns.Add("Nombre", typeof(string));
            dataTableProductos.Columns.Add("Marca", typeof(string));
            dataTableProductos.Columns.Add("Stock", typeof(int));
            dataTableProductos.Columns.Add("Talle", typeof(string));
            dataTableProductos.Columns.Add("Categoría", typeof(string));

            CargarDatosDeEjemplo();

            // Asignamos el DataTable como origen de datos.
            // Como AutoGenerateColumns es false, solo se llenarán las columnas
            // que ya están en el diseñador.
            dataGridViewProductos.DataSource = dataTableProductos;

            CargarFiltros();

            dataGridViewProductos.Dock = DockStyle.Fill;
            dataGridViewProductos.BringToFront();
        }

        private void CargarDatosDeEjemplo()
        {
            dataTableProductos.Rows.Clear();
            dataTableProductos.Rows.Add("101", "Remera Algodón", "Nike", 50, "M", "Remera");
            dataTableProductos.Rows.Add("102", "Pantalón Jean", "Levi's", 25, "L", "Pantalón");
            dataTableProductos.Rows.Add("103", "Buzo con Capucha", "Adidas", 15, "S", "Buzo");
            dataTableProductos.Rows.Add("104", "Zapatillas Running", "Puma", 10, "42", "Calzado");
            dataTableProductos.Rows.Add("105", "Camisa Cuadros", "Zara", 30, "M", "Camisa");
            dataTableProductos.Rows.Add("106", "Pantalón Deportivo", "Adidas", 40, "XL", "Pantalón");
            dataTableProductos.Rows.Add("107", "Remera Estampada", "Nike", 60, "L", "Remera");
        }

        private void CargarFiltros()
        {
            var talles = dataTableProductos.AsEnumerable()
                                             .Select(row => row.Field<string>("Talle"))
                                             .Distinct()
                                             .ToList();
            talles.Sort();
            cmbTalle.Items.Clear();
            cmbTalle.Items.Add("Todos");
            cmbTalle.Items.AddRange(talles.ToArray());
            cmbTalle.SelectedIndex = 0;

            var categorias = dataTableProductos.AsEnumerable()
                                                 .Select(row => row.Field<string>("Categoría"))
                                                 .Distinct()
                                                 .ToList();
            categorias.Sort();
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0;
        }

        private void AplicarFiltros()
        {
            string filtroNombre = txtBuscarNombre.Text.Trim();
            string filtroTalle = cmbTalle.SelectedItem?.ToString();
            string filtroCategoria = cmbCategoria.SelectedItem?.ToString();

            StringBuilder rowFilter = new StringBuilder();

            if (!string.IsNullOrEmpty(filtroNombre))
            {
                rowFilter.Append($"Nombre LIKE '%{filtroNombre.Replace("'", "''")}%'");
            }

            if (filtroTalle != "Todos" && !string.IsNullOrEmpty(filtroTalle))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Talle = '{filtroTalle.Replace("'", "''")}'");
            }

            if (filtroCategoria != "Todas" && !string.IsNullOrEmpty(filtroCategoria))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Categoría = '{filtroCategoria.Replace("'", "''")}'");
            }

            dataTableProductos.DefaultView.RowFilter = rowFilter.Length > 0 ? rowFilter.ToString() : string.Empty;
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Código de evento
        }
    }
}