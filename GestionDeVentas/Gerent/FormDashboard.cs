using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionDeVentas.Gerent
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadStaticData();
        }

        private void LoadStaticData()
        {
            // Datos para los paneles de KPIs
            lblVentasTotalesValor.Text = "$ 150,000";
            lblProductosVendidosValor.Text = "2,500";
            lblClientesNuevosValor.Text = "85";

            // Datos para el DataGridView (Top 5 Productos de ropa)
            dgvTopProductos.Columns.Clear();
            dgvTopProductos.Rows.Clear();
            dgvTopProductos.ColumnCount = 2;
            dgvTopProductos.Columns[0].Name = "Producto";
            dgvTopProductos.Columns[1].Name = "Cantidad Vendida";

            dgvTopProductos.Rows.Add("Buzo Canguro", "550");
            dgvTopProductos.Rows.Add("Remera Mitos", "480");
            dgvTopProductos.Rows.Add("Campera de Cuero", "390");
            dgvTopProductos.Rows.Add("jean Cargo ", "320");
            dgvTopProductos.Rows.Add("jeans Baggy", "280");

            dgvTopProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopProductos.AllowUserToAddRows = false;
            dgvTopProductos.ReadOnly = true;
            dgvTopProductos.RowHeadersVisible = false;

            // Datos para el gráfico de barras (Ingresos Mensuales)
            chartIngresosMensuales.Series.Clear();
            var ingresosSeries = new Series("Ingresos");
            ingresosSeries.ChartType = SeriesChartType.Column;
            ingresosSeries.Points.AddXY("Ene", 75);
            ingresosSeries.Points.AddXY("Feb", 82);
            ingresosSeries.Points.AddXY("Mar", 72);
            ingresosSeries.Points.AddXY("Abr", 23);
            ingresosSeries.Points.AddXY("May", 81);
            ingresosSeries.Points.AddXY("Jun", 40);
            chartIngresosMensuales.Series.Add(ingresosSeries);
            chartIngresosMensuales.Titles.Clear();
            chartIngresosMensuales.Titles.Add("Ingresos Mensuales");
            chartIngresosMensuales.ChartAreas[0].AxisY.Maximum = 100;
            chartIngresosMensuales.ChartAreas[0].AxisY.Minimum = 0;
            chartIngresosMensuales.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            // Datos para el gráfico circular (Ventas por Producto)
            chartVentasPorProducto.Series.Clear();
            var ventasSeries = new Series("Ventas");
            ventasSeries.ChartType = SeriesChartType.Pie;
            ventasSeries.Points.AddXY("Remeras", 30);
            ventasSeries.Points.AddXY("Buzos", 25);
            ventasSeries.Points.AddXY("Jeans", 20);
            ventasSeries.Points.AddXY("Camperas", 15);
            ventasSeries.Points.AddXY("Hoodies", 10);
            chartVentasPorProducto.Series.Add(ventasSeries);
            chartVentasPorProducto.Titles.Clear();
            chartVentasPorProducto.Titles.Add("Ventas por Producto");
        }

        private void chartVentasPorProducto_Click(object sender, EventArgs e)
        {

        }
    }
}