using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class ListarVentas : Form
    {
        private DataTable dataTableVentas = new DataTable();
        private bool columnasCargadas = false;

        public ListarVentas()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ListarVentas_Load(object sender, EventArgs e)
        {
            CargarColumnas();
            CargarDatosDeEjemplo();
            CargarFiltros();
        }

        private void CargarColumnas()
        {
            // Solo se cargan las columnas si no han sido cargadas previamente.
            if (!columnasCargadas)
            {
                dataTableVentas.Columns.Add("ID Venta", typeof(int));
                dataTableVentas.Columns.Add("Fecha", typeof(DateTime));
                dataTableVentas.Columns.Add("Vendedor", typeof(string));
                dataTableVentas.Columns.Add("Producto", typeof(string));
                dataTableVentas.Columns.Add("Cantidad", typeof(int));
                dataTableVentas.Columns.Add("Precio Total", typeof(decimal));
                columnasCargadas = true;
            }

            dataGridViewVentas.DataSource = dataTableVentas;

            // Formateo de las columnas de la DataGridView
            dataGridViewVentas.Columns["Precio Total"].DefaultCellStyle.Format = "C2";
            dataGridViewVentas.Columns["Fecha"].DefaultCellStyle.Format = "d";
        }

        private void CargarDatosDeEjemplo()
        {
            dataTableVentas.Rows.Clear();
            dataTableVentas.Rows.Add(1, DateTime.Now.AddDays(-5), "Ana Torres", "Remera Blanca", 2, 31.98M);
            dataTableVentas.Rows.Add(2, DateTime.Now.AddDays(-4), "Juan Pérez", "Pantalón Jean", 1, 45.00M);
            dataTableVentas.Rows.Add(3, DateTime.Now.AddDays(-3), "Ana Torres", "Buzo Gris", 1, 35.50M);
            dataTableVentas.Rows.Add(4, DateTime.Now.AddDays(-2), "Juan Pérez", "Zapatillas Deportivas", 1, 75.99M);
            dataTableVentas.Rows.Add(5, DateTime.Now.AddDays(-1), "Ana Torres", "Camisa Cuadros", 3, 89.70M);
            dataTableVentas.Rows.Add(6, DateTime.Now, "Sofía García", "Remera Estampada", 1, 18.50M);
            dataTableVentas.Rows.Add(7, DateTime.Now, "Sofía García", "Pantalón Deportivo", 2, 50.00M);
        }

        private void CargarFiltros()
        {
            var vendedores = dataTableVentas.AsEnumerable()
                                               .Select(row => row.Field<string>("Vendedor"))
                                               .Distinct()
                                               .ToList();
            vendedores.Sort();
            cmbVendedor.Items.Clear();
            cmbVendedor.Items.Add("Todos");
            cmbVendedor.Items.AddRange(vendedores.ToArray());
            cmbVendedor.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Now;
        }

        private void AplicarFiltros()
        {
            DateTime filtroFecha = dtpFecha.Value.Date;
            string filtroVendedor = cmbVendedor.SelectedItem?.ToString();

            // Usamos el DataTable original para filtrar
            var filteredRows = dataTableVentas.AsEnumerable();

            // Filtrar por fecha
            filteredRows = filteredRows.Where(row => row.Field<DateTime>("Fecha").Date == filtroFecha);

            // Filtrar por vendedor
            if (filtroVendedor != "Todos" && !string.IsNullOrEmpty(filtroVendedor))
            {
                filteredRows = filteredRows.Where(row => row.Field<string>("Vendedor") == filtroVendedor);
            }

            if (filteredRows.Any())
            {
                dataGridViewVentas.DataSource = filteredRows.CopyToDataTable();
            }
            else
            {
                // Si no hay resultados, limpiamos la DataGridView para mostrar una tabla vacía
                dataGridViewVentas.DataSource = null;
            }

            // Reaplicamos la fuente de datos original para mantener los datos para futuros filtros
            dataGridViewVentas.DataSource = dataTableVentas;

            // Reaplicamos el filtro
            string rowFilter = $"Convert(Fecha, 'System.String') LIKE '*{filtroFecha.ToString("d/MM/yyyy")}*'";
            if (filtroVendedor != "Todos" && !string.IsNullOrEmpty(filtroVendedor))
            {
                rowFilter += $" AND Vendedor = '{filtroVendedor.Replace("'", "''")}'";
            }
            dataTableVentas.DefaultView.RowFilter = rowFilter;

        }

        private void AplicarFiltros_EventHandler(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}