using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionDeVentas.Gerent
{
    public partial class FormDashboard : Form
    {
        // Datos de ejemplo (mensuales)
        private readonly List<RegistroMensual> _data = new List<RegistroMensual>
        {
            new RegistroMensual(new DateTime(DateTime.Today.Year, 1, 1),  7500, 410, 12),
            new RegistroMensual(new DateTime(DateTime.Today.Year, 2, 1),  8200, 430, 14),
            new RegistroMensual(new DateTime(DateTime.Today.Year, 3, 1),  7800, 420, 12),
            new RegistroMensual(new DateTime(DateTime.Today.Year, 4, 1),  9200, 470, 18),
            new RegistroMensual(new DateTime(DateTime.Today.Year, 5, 1),  8700, 440, 16),
            new RegistroMensual(new DateTime(DateTime.Today.Year, 6, 1),  8900, 460, 13),
        };

        public FormDashboard()
        {
            InitializeComponent();
        }

        // =======================
        //        EVENTOS
        // =======================

        // ¡OJO! El Designer debe enlazar: this.Load += FormDashboard_Load;
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // Rango por defecto: 1° día del mes actual hasta hoy
            var hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = hoy;
            AplicarFiltros();
        }

        // Handler del botón ❌ (el Designer debe enlazar: this.btnCerrar.Click += btnCerrar_Click;)
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario; el contenedor limpia y vuelve al Inicio
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chartVentasPorProducto_Click(object sender, EventArgs e)
        {
            // opcional
        }

        private void lblTituloDashboard_Click(object sender, EventArgs e)
        {
            // opcional
        }

        // =======================
        //        LÓGICA
        // =======================

        private void AplicarFiltros()
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que 'Desde'.",
                                "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadData(desde, hasta);
        }

        private void LoadData(DateTime desde, DateTime hasta)
        {
            var desdeMes = new DateTime(desde.Year, desde.Month, 1);
            var hastaMes = new DateTime(hasta.Year, hasta.Month, 1);

            var enRango = _data
                .Where(r => r.Mes >= desdeMes && r.Mes <= hastaMes)
                .OrderBy(r => r.Mes)
                .ToList();

            // KPIs
            var totalIngresos = enRango.Sum(r => r.Ingresos);
            var totalVendidos = enRango.Sum(r => r.ProductosVendidos);
            var totalClientes = enRango.Sum(r => r.ClientesNuevos);

            lblVentasTotalesValor.Text = totalIngresos.ToString("$ #,0", CultureInfo.GetCultureInfo("es-AR"));
            lblProductosVendidosValor.Text = totalVendidos.ToString("N0");
            lblClientesNuevosValor.Text = totalClientes.ToString("N0");

            // Top 5 (demo)
            dgvTopProductos.Columns.Clear();
            dgvTopProductos.Rows.Clear();
            dgvTopProductos.ColumnCount = 2;
            dgvTopProductos.Columns[0].Name = "Producto";
            dgvTopProductos.Columns[1].Name = "Cantidad Vendida";
            dgvTopProductos.Rows.Add("Buzo Canguro", "550");
            dgvTopProductos.Rows.Add("Remera Mitos", "480");
            dgvTopProductos.Rows.Add("Campera de Cuero", "390");
            dgvTopProductos.Rows.Add("Jean Cargo", "320");
            dgvTopProductos.Rows.Add("Jeans Baggy", "280");
            dgvTopProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopProductos.AllowUserToAddRows = false;
            dgvTopProductos.ReadOnly = true;
            dgvTopProductos.RowHeadersVisible = false;

            // Gráfico Columnas: Ingresos mensuales
            chartIngresosMensuales.Series.Clear();
            chartIngresosMensuales.Titles.Clear();
            chartIngresosMensuales.Titles.Add("Ingresos Mensuales");

            var serieIngresos = new Series("Ingresos") { ChartType = SeriesChartType.Column };

            if (enRango.Count == 0)
                serieIngresos.Points.AddXY("Sin datos", 0);
            else
                foreach (var r in enRango)
                    serieIngresos.Points.AddXY(r.Mes.ToString("MMM", new CultureInfo("es-AR")), r.Ingresos);

            chartIngresosMensuales.Series.Add(serieIngresos);
            chartIngresosMensuales.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIngresosMensuales.ChartAreas[0].AxisY.LabelStyle.Format = "$ #,0";

            // Gráfico Pie: Ventas por producto (demo)
            chartVentasPorProducto.Series.Clear();
            chartVentasPorProducto.Titles.Clear();
            chartVentasPorProducto.Titles.Add("Ventas por Producto");

            var serieVentas = new Series("Ventas") { ChartType = SeriesChartType.Pie };
            serieVentas.Points.AddXY("Remeras", 30);
            serieVentas.Points.AddXY("Buzos", 25);
            serieVentas.Points.AddXY("Jeans", 20);
            serieVentas.Points.AddXY("Camperas", 15);
            serieVentas.Points.AddXY("Hoodies", 10);
            chartVentasPorProducto.Series.Add(serieVentas);
        }

        // =======================
        //   CLASE AUXILIAR
        // =======================
        private class RegistroMensual
        {
            public DateTime Mes { get; set; }
            public int Ingresos { get; set; }
            public int ProductosVendidos { get; set; }
            public int ClientesNuevos { get; set; }

            public RegistroMensual(DateTime mes, int ingresos, int productosVendidos, int clientesNuevos)
            {
                Mes = mes;
                Ingresos = ingresos;
                ProductosVendidos = productosVendidos;
                ClientesNuevos = clientesNuevos;
            }
        }
    }
}
