using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class ListarProductos : Form
    {
        private DataTable dataTableProductos = new DataTable();

        public ListarProductos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScroll = true; // Agregado para que se pueda desplazar
        }

        private void ListarProductos_Load(object sender, EventArgs e)
        {
            CargarColumnas();
            CargarDatosDeEjemplo();
            CargarFiltros();
            // Asegúrate de que el DataGridView ocupe el espacio restante
            // Nota: El Dock en el diseñador ya hace esto, pero es bueno confirmarlo.
            dataGridViewProductos.Dock = DockStyle.Fill;
            dataGridViewProductos.BringToFront(); // Asegúrate de que esté encima
        }

        private void CargarColumnas()
        {
            dataTableProductos.Columns.Add("ID", typeof(int));
            dataTableProductos.Columns.Add("Nombre", typeof(string));
            dataTableProductos.Columns.Add("Descripción", typeof(string));
            dataTableProductos.Columns.Add("Talle", typeof(string));
            dataTableProductos.Columns.Add("Categoría", typeof(string));
            dataTableProductos.Columns.Add("Precio", typeof(decimal));
            dataTableProductos.Columns.Add("Stock", typeof(int));

            dataGridViewProductos.DataSource = dataTableProductos;
        }

        private void CargarDatosDeEjemplo()
        {
            dataTableProductos.Rows.Clear();
            dataTableProductos.Rows.Add(1, "Remera Blanca", "100% algodón", "M", "Remera", 15.99, 50);
            dataTableProductos.Rows.Add(2, "Pantalón Jean", "Corte recto, azul", "L", "Pantalón", 45.00, 25);
            dataTableProductos.Rows.Add(3, "Buzo Gris", "Con capucha, material suave", "S", "Buzo", 35.50, 15);
            dataTableProductos.Rows.Add(4, "Zapatillas Deportivas", "Color negro, para correr", "42", "Calzado", 75.99, 10);
            dataTableProductos.Rows.Add(5, "Camisa Cuadros", "Manga larga, estilo leñador", "M", "Camisa", 29.90, 30);
            dataTableProductos.Rows.Add(6, "Pantalón Deportivo", "Material ligero, color negro", "XL", "Pantalón", 25.00, 40);
            dataTableProductos.Rows.Add(7, "Remera Estampada", "Diseño gráfico", "L", "Remera", 18.50, 60);
        }

        private void CargarFiltros()
        {
            // Carga los talles únicos
            var talles = dataTableProductos.AsEnumerable()
                                           .Select(row => row.Field<string>("Talle"))
                                           .Distinct()
                                           .ToList();
            talles.Sort();
            cmbTalle.Items.Clear();
            cmbTalle.Items.Add("Todos");
            cmbTalle.Items.AddRange(talles.ToArray());
            cmbTalle.SelectedIndex = 0; // Selecciona "Todos" por defecto

            // Carga las categorías únicas
            var categorias = dataTableProductos.AsEnumerable()
                                               .Select(row => row.Field<string>("Categoría"))
                                               .Distinct()
                                               .ToList();
            categorias.Sort();
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas");
            cmbCategoria.Items.AddRange(categorias.ToArray());
            cmbCategoria.SelectedIndex = 0; // Selecciona "Todas" por defecto
        }

        private void AplicarFiltros()
        {
            string filtroNombre = txtBuscarNombre.Text.Trim();
            string filtroTalle = cmbTalle.SelectedItem?.ToString();
            string filtroCategoria = cmbCategoria.SelectedItem?.ToString();

            // Construye la cadena de filtro
            StringBuilder rowFilter = new StringBuilder();

            // Filtro por nombre
            if (!string.IsNullOrEmpty(filtroNombre))
            {
                rowFilter.Append($"Nombre LIKE '%{filtroNombre.Replace("'", "''")}%'");
            }

            // Filtro por talle
            if (filtroTalle != "Todos" && !string.IsNullOrEmpty(filtroTalle))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Talle = '{filtroTalle.Replace("'", "''")}'");
            }

            // Filtro por categoría
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

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}