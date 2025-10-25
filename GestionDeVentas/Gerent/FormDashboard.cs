using GestionDeVentas.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionDeVentas.Gerent
{
    public partial class FormDashboard : Form
    {
        private readonly GerenteReportesDatos _reportesDatos = new GerenteReportesDatos();

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = hoy;

            AplicarEstilosTYV();
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

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

            CargarDatos(desde, hasta);
        }

        private void CargarDatos(DateTime desde, DateTime hasta)
        {
            try
            {
                var kpi = _reportesDatos.ObtenerKpis(desde, hasta);
                var ventasMes = _reportesDatos.ObtenerVentasPorMes(desde, hasta);
                var topProductos = _reportesDatos.ObtenerTopProductos(desde, hasta);

                // --- KPIs ---
                lblVentasTotalesValor.Text = kpi.TotalVentas.ToString("$ #,0", CultureInfo.GetCultureInfo("es-AR"));
                lblProductosVendidosValor.Text = kpi.CantProductosVendidos.ToString("N0");
                lblClientesNuevosValor.Text = kpi.ClientesNuevos.ToString("N0");

                // --- Gráfico Ingresos Mensuales ---
                chartIngresosMensuales.Series.Clear();
                var serieIngresos = new Series("Ingresos")
                {
                    ChartType = SeriesChartType.Column,
                    Color = ColorTranslator.FromHtml("#D2B48C")
                };

                if (ventasMes.Count == 0)
                    serieIngresos.Points.AddXY("Sin datos", 0);
                else
                    foreach (var v in ventasMes)
                        serieIngresos.Points.AddXY(v.Mes, v.Total);

                chartIngresosMensuales.Series.Add(serieIngresos);

                // --- Gráfico Ventas por Producto (Top 5) ---
                chartVentasPorProducto.Series.Clear();
                var serieVentas = new Series("Ventas")
                {
                    ChartType = SeriesChartType.Pie
                };

                if (topProductos.Count == 0)
                    serieVentas.Points.AddXY("Sin datos", 0);
                else
                    foreach (var p in topProductos)
                        serieVentas.Points.AddXY(p.Producto, p.Cantidad);

                chartVentasPorProducto.Series.Add(serieVentas);

                // --- DataGrid Top 5 Productos ---
                dgvTopProductos.Columns.Clear();
                dgvTopProductos.Rows.Clear();
                dgvTopProductos.ColumnCount = 2;
                dgvTopProductos.Columns[0].Name = "Producto";
                dgvTopProductos.Columns[1].Name = "Cantidad Vendida";

                foreach (var p in topProductos)
                    dgvTopProductos.Rows.Add(p.Producto, p.Cantidad);

                dgvTopProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTopProductos.AllowUserToAddRows = false;
                dgvTopProductos.ReadOnly = true;
                dgvTopProductos.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Estilo visual camel/cacao minimalista ---
        private void AplicarEstilosTYV()
        {
            this.BackColor = ColorTranslator.FromHtml("#F9F6F2");

            Color camel = ColorTranslator.FromHtml("#D2B48C");
            Color cacao = ColorTranslator.FromHtml("#4B3F35");
            Color beige = ColorTranslator.FromHtml("#F9F6F2");
            Color verde = ColorTranslator.FromHtml("#50C878");
            Color rojo = ColorTranslator.FromHtml("#E57373");
            Color azul = ColorTranslator.FromHtml("#64B5F6");

            // --- Título principal ---
            lblTituloDashboard.ForeColor = cacao;
            lblTituloDashboard.Font = new Font("Segoe UI Semibold", 17, FontStyle.Bold);
            lblTituloDashboard.TextAlign = ContentAlignment.MiddleCenter;

            // --- Panel filtros ---
            panelFiltros.BackColor = Color.White;
            panelFiltros.BorderStyle = BorderStyle.None;

            lblDesde.ForeColor = cacao;
            lblHasta.ForeColor = cacao;

            btnAplicar.BackColor = camel;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAplicar.Cursor = Cursors.Hand;

            // --- Paneles KPI ---
            panelVentasTotales.BackColor = rojo;
            panelProductosVendidos.BackColor = verde;
            panelClientesNuevos.BackColor = azul;

            Label[] kpiTitulos = { lblVentasTotales, lblProductosVendidos, lblClientesNuevos };
            Label[] kpiValores = { lblVentasTotalesValor, lblProductosVendidosValor, lblClientesNuevosValor };

            foreach (var lbl in kpiTitulos)
            {
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lbl.ForeColor = Color.White;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            foreach (var lbl in kpiValores)
            {
                lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                lbl.ForeColor = Color.White;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            // --- Botón cerrar ---
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.ForeColor = cacao;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnCerrar.Cursor = Cursors.Hand;

            // --- Gráficos ---
            Chart[] charts = { chartIngresosMensuales, chartVentasPorProducto };

            foreach (var ch in charts)
            {
                ch.BackColor = beige;
                ch.ChartAreas[0].BackColor = Color.White;
                ch.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                ch.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(220, 210, 190);
                ch.ChartAreas[0].AxisX.LabelStyle.ForeColor = cacao;
                ch.ChartAreas[0].AxisY.LabelStyle.ForeColor = cacao;
                ch.Legends[0].BackColor = Color.Transparent;
                ch.Legends[0].ForeColor = cacao;
                ch.Titles.Clear();
                ch.Titles.Add(ch == chartIngresosMensuales ? "Ingresos Mensuales" : "Ventas por Producto");
                ch.Titles[0].Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
                ch.Titles[0].ForeColor = cacao;
            }

            // --- DataGrid ---
            dgvTopProductos.BackgroundColor = Color.White;
            dgvTopProductos.BorderStyle = BorderStyle.None;
            dgvTopProductos.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAFAFA");
            dgvTopProductos.DefaultCellStyle.ForeColor = cacao;
            dgvTopProductos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTopProductos.ColumnHeadersDefaultCellStyle.BackColor = camel;
            dgvTopProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTopProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            dgvTopProductos.EnableHeadersVisualStyles = false;
            dgvTopProductos.GridColor = ColorTranslator.FromHtml("#E0E0E0");
            dgvTopProductos.RowHeadersVisible = false;

            lblTituloProductos.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            lblTituloProductos.ForeColor = cacao;
        }

        private void chartIngresosMensuales_Click(object sender, EventArgs e) { }
        private void lblTituloDashboard_Click(object sender, EventArgs e) { }
        private void chartVentasPorProducto_Click(object sender, EventArgs e) { }
    }
}
