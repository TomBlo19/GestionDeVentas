using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Drawing.Drawing2D;
using Datos;

namespace GestionDeVentas.Gerent
{
    public partial class FormRendimientoVendedores : Form
    {
        private readonly RendimientoVendedorDatos _datos = new RendimientoVendedorDatos();

        // 🎨 Paleta de colores TYV
        private readonly Color colorFondoPrincipal = ColorTranslator.FromHtml("#F5E6CC");
        private readonly Color colorMarrónOscuro = ColorTranslator.FromHtml("#3E2723");
        private readonly Color colorMarrónClaro = ColorTranslator.FromHtml("#EBD3B3");
        private readonly Color colorAcento1 = ColorTranslator.FromHtml("#C19A6B");
        private readonly Color colorAcento2 = ColorTranslator.FromHtml("#7A9E7E");

        public FormRendimientoVendedores()
        {
            InitializeComponent();
            panelIngresos.Paint += PanelKpi_Paint;
            panelVentasUnidades.Paint += PanelKpi_Paint;
            btnAplicar.Click += btnAplicar_Click;
            btnCerrar.Click += btnCerrar_Click;
        }

        private void FormRendimientoVendedores_Load(object sender, EventArgs e)
        {
            AplicarEstiloTYV();

            dtpDesde.Value = DateTime.Today.AddMonths(-3);
            dtpHasta.Value = DateTime.Today;

            CargarComboVendedores();
            btnAplicar.PerformClick();
        }

        // 🌈 Estilo TYV
        private void AplicarEstiloTYV()
        {
            this.BackColor = colorFondoPrincipal;
            this.FormBorderStyle = FormBorderStyle.None;

            // Panel filtros
            panelFiltros.BackColor = colorMarrónClaro;
            foreach (var lbl in new[] { lblDesde, lblHasta, lblVendedor })
            {
                lbl.ForeColor = colorMarrónOscuro;
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            btnAplicar.BackColor = colorAcento1;
            btnAplicar.ForeColor = Color.White;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.Font = new Font("Segoe UI", 10, FontStyle.Bold);


            cbVendedor.ForeColor = colorMarrónOscuro;
            cbVendedor.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Botón cerrar
            btnCerrar.BackColor = colorMarrónOscuro;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            btnCerrar.Text = "✕";

            // Panel KPIs
            panelKPIs.BackColor = colorFondoPrincipal;
            panelIngresos.Tag = ("#C19A6B", "#A87D56");
            panelVentasUnidades.Tag = ("#7A9E7E", "#5E7C68");

            foreach (var lbl in new[] { lblIngresos, lblVentasUnidades })
            {
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Dock = DockStyle.Top;
                lbl.Height = 25;
            }

            foreach (var val in new[] { lblIngresosValor, lblVentasUnidadesValor })
            {
                val.ForeColor = Color.White;
                val.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                val.TextAlign = ContentAlignment.MiddleCenter;
                val.Dock = DockStyle.Fill;
            }

            panelGraficos.BackColor = colorFondoPrincipal;
            ConfigurarGraficoTYV(chartIngresosMensuales, "Ranking de Vendedores (Ingresos)", colorAcento1);
            ConfigurarGraficoTYV(chartVentasPorProducto, "Productos vendidos", colorAcento2);
        }

        // 💡 KPI degradado
        private void PanelKpi_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel?.Tag is ValueTuple<string, string> colors)
            {
                var color1 = ColorTranslator.FromHtml(colors.Item1);
                var color2 = ColorTranslator.FromHtml(colors.Item2);
                using (var brush = new LinearGradientBrush(panel.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
                    e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        // 📊 Configurar gráfico (corregido)
        private void ConfigurarGraficoTYV(Chart chart, string titulo, Color colorBase)
        {
            chart.BackColor = ColorTranslator.FromHtml("#FDF8F2");

            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add(new ChartArea("MainArea"));

            var area = chart.ChartAreas[0];
            area.BackColor = Color.Transparent;
            area.BorderColor = Color.Transparent;

            // Ejes sutiles y elegantes
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0CFA5");
            area.AxisX.LineColor = ColorTranslator.FromHtml("#A47C48");
            area.AxisY.LineColor = ColorTranslator.FromHtml("#A47C48");
            area.AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            // Título TYV
            chart.Titles.Clear();
            chart.Titles.Add(titulo);
            chart.Titles[0].Font = new Font("Segoe UI Semibold", 13);
            chart.Titles[0].ForeColor = ColorTranslator.FromHtml("#3E2723");
            chart.Titles[0].Alignment = ContentAlignment.TopCenter;

            // Leyenda discreta
            chart.Legends.Clear();
            var legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = ColorTranslator.FromHtml("#3E2723"),
                BackColor = Color.Transparent
            };
            chart.Legends.Add(legend);

            chart.Palette = ChartColorPalette.None;

            if (chart.Series.Count == 0)
                return;

            var serie = chart.Series[0];
            serie.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            serie.LabelForeColor = ColorTranslator.FromHtml("#3E2723");
            serie.IsValueShownAsLabel = true;
            serie.ToolTip = "#AXISLABEL: $ #VALY{N0}";
            serie["DrawingStyle"] = "Cylinder";

            // 🔶 Barras / Columnas
            if (serie.ChartType == SeriesChartType.Bar || serie.ChartType == SeriesChartType.Column)
            {
                serie.Color = colorBase;
                serie.BackGradientStyle = GradientStyle.TopBottom;
                serie.BackSecondaryColor = ControlPaint.Light(colorBase);
                serie.BorderWidth = 0;

                // ✅ Mostrar valores sin “#VALY”
                serie.Label = "$ #VALY{N0}";
                serie.LabelFormat = "";
                area.AxisY.MajorGrid.Enabled = false;
            }

            // 🥧 Torta (productos vendidos)
            if (serie.ChartType == SeriesChartType.Pie)
            {
                Color[] paletaTYV =
                {
            ColorTranslator.FromHtml("#C19A6B"),
            ColorTranslator.FromHtml("#8D6E63"),
            ColorTranslator.FromHtml("#7A9E7E"),
            ColorTranslator.FromHtml("#EBD3B3"),
            ColorTranslator.FromHtml("#D4AF37")
        };

                for (int i = 0; i < serie.Points.Count; i++)
                {
                    var punto = serie.Points[i];
                    var color = paletaTYV[i % paletaTYV.Length];
                    punto.Color = color;

                    // Mostrar nombre + cantidad + porcentaje
                    punto.Label = $"{punto.AxisLabel}\n{punto.YValues[0]:N0} ({punto.YValues[0] / serie.Points.Sum(p => p.YValues[0]) * 100:N0}%)";
                    punto.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    punto.LabelForeColor = ColorTranslator.FromHtml("#3E2723");
                    punto.ToolTip = $"{punto.AxisLabel}: {punto.YValues[0]:N0}";
                }

                serie["PieLabelStyle"] = "Outside";
                serie["PieLineColor"] = ColorTranslator.FromHtml("#3E2723").ToArgb().ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
        }



        // 🧩 Cargar combo de vendedores
        private void CargarComboVendedores()
        {
            var vendedores = _datos.ObtenerVendedores();

            cbVendedor.DisplayMember = "Vendedor";
            cbVendedor.ValueMember = "Id";

            var lista = vendedores
                .Select(v => new { Id = v.Id, Vendedor = v.Vendedor })
                .ToList();

            lista.Insert(0, new { Id = 0, Vendedor = "Todos" });
            cbVendedor.DataSource = lista;
            cbVendedor.SelectedIndex = 0;
        }

        // 📈 Ranking general
        private void CargarRankingGeneral()
        {
            var ranking = _datos.ObtenerRanking(dtpDesde.Value, dtpHasta.Value);
            chartIngresosMensuales.Series.Clear();
            chartVentasPorProducto.Series.Clear();

            lblIngresosValor.Text = "$ 0.00";
            lblVentasUnidadesValor.Text = "0";

            var serie = new Series("Vendedores")
            {
                ChartArea = "MainArea",
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            foreach (var v in ranking.OrderByDescending(r => r.Total))
                serie.Points.AddXY(v.Vendedor, v.Total);

            chartIngresosMensuales.Series.Add(serie);
            ConfigurarGraficoTYV(chartIngresosMensuales, "Ranking de Vendedores (Ingresos)", colorAcento1);
            chartIngresosMensuales.ChartAreas[0].AxisX.Title = "Ingresos ($)";
            chartIngresosMensuales.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            ConfigurarGraficoTYV(chartVentasPorProducto, "Seleccione un vendedor para ver detalle", Color.LightGray);
        }

        // 📊 Detalle de vendedor
        private void CargarDetalleVendedor(string nombreVendedor)
        {
            if (cbVendedor.SelectedValue == null)
                return;

            int idVendedor = (int)cbVendedor.SelectedValue;
            var datos = _datos.ObtenerDatosVendedor(idVendedor, dtpDesde.Value, dtpHasta.Value);

            this.Text = $"Rendimiento de {nombreVendedor}";
            lblIngresosValor.Text = $"$ {datos.ingresos:N2}";
            lblVentasUnidadesValor.Text = datos.unidades.ToString("N0");

            var ingresos = _datos.ObtenerIngresosMensuales(idVendedor);
            chartIngresosMensuales.Series.Clear();
            var serie = new Series("Meses")
            {
                ChartArea = "MainArea",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            foreach (var m in ingresos)
                serie.Points.AddXY(m.Mes, m.Total);
            chartIngresosMensuales.Series.Add(serie);
            ConfigurarGraficoTYV(chartIngresosMensuales, $"Ingresos mensuales de {nombreVendedor}", colorAcento1);

            var productos = _datos.ObtenerProductosMasVendidos(idVendedor, dtpDesde.Value, dtpHasta.Value);
            chartVentasPorProducto.Series.Clear();
            var serieProd = new Series("Productos")
            {
                ChartArea = "MainArea",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };
            foreach (var p in productos)
                serieProd.Points.AddXY(p.Producto, p.Cantidad);
            chartVentasPorProducto.Series.Add(serieProd);
            ConfigurarGraficoTYV(chartVentasPorProducto, $"Productos vendidos por {nombreVendedor}", colorAcento2);
        }

        // ▶ Botón Aplicar
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if ((int)cbVendedor.SelectedValue == 0)
                CargarRankingGeneral();
            else
                CargarDetalleVendedor(cbVendedor.Text);
        }

        // ❌ Botón Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e) { }
    }
}
