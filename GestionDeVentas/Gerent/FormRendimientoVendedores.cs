using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionDeVentas.Gerent
{
    public partial class FormRendimientoVendedores : Form
    {
        public FormRendimientoVendedores()
        {
            InitializeComponent();
        }

        private void FormRendimientoVendedores_Load(object sender, EventArgs e)
        {
            LoadStaticData();
        }

        private void LoadStaticData()
        {
            // Datos estáticos para los filtros
            cbVendedor.Items.Add("Vendedor 1");
            cbVendedor.Items.Add("Vendedor 2");
            cbVendedor.Items.Add("Vendedor 3");
            cbVendedor.SelectedIndex = 0;

            // Datos para los KPIs
            lblIngresosValor.Text = "$ 12,500";
            lblVentasUnidadesValor.Text = "1,150";

            // Gráfico de Ingresos Mensuales
            chartIngresosMensuales.Series.Clear();
            var ingresosSeries = new Series("Ingresos");
            ingresosSeries.ChartType = SeriesChartType.Column;
            ingresosSeries.Points.AddXY("Ene", 7500);
            ingresosSeries.Points.AddXY("Feb", 8200);
            ingresosSeries.Points.AddXY("Mar", 9000);
            ingresosSeries.Points.AddXY("Abr", 7800);
            ingresosSeries.Points.AddXY("May", 9500);
            ingresosSeries.Points.AddXY("Jun", 8800);
            chartIngresosMensuales.Series.Add(ingresosSeries);
            chartIngresosMensuales.ChartAreas[0].AxisY.Maximum = 10000;
            chartIngresosMensuales.ChartAreas[0].AxisY.Minimum = 0;
            chartIngresosMensuales.Titles.Clear();
            chartIngresosMensuales.Titles.Add("Ingresos Mensuales");
            chartIngresosMensuales.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            // Gráfico de Ventas por Producto (Circular/Pie)
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

        // >>> NUEVO: handler del botón ✕
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
