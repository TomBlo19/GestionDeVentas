using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Drawing.Drawing2D;
using Datos;
using ClosedXML.Excel;

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
            btnExportar.Click += btnExportar_Click;
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

            // Botones
            foreach (var btn in new[] { btnAplicar, btnExportar })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            btnAplicar.BackColor = colorAcento1;
            btnExportar.BackColor = colorAcento2;

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

        // 📊 Configurar gráfico TYV
        private void ConfigurarGraficoTYV(Chart chart, string titulo, Color colorBase)
        {
            chart.BackColor = ColorTranslator.FromHtml("#FDF8F2");
            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add(new ChartArea("MainArea"));

            var area = chart.ChartAreas[0];
            area.BackColor = Color.Transparent;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0CFA5");
            area.AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");

            chart.Titles.Clear();
            chart.Titles.Add(titulo);
            chart.Titles[0].Font = new Font("Segoe UI Semibold", 13);
            chart.Titles[0].ForeColor = ColorTranslator.FromHtml("#3E2723");
        }

        // 🧩 Cargar combo de vendedores
        private void CargarComboVendedores()
        {
            var vendedores = _datos.ObtenerVendedores();
            var lista = vendedores.Select(v => new { v.Id, v.Vendedor }).ToList();
            lista.Insert(0, new { Id = 0, Vendedor = "Todos" });
            cbVendedor.DataSource = lista;
            cbVendedor.DisplayMember = "Vendedor";
            cbVendedor.ValueMember = "Id";
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
        }

        // 📊 Detalle de vendedor
        private void CargarDetalleVendedor(string nombreVendedor)
        {
            int idVendedor = (int)cbVendedor.SelectedValue;
            var datos = _datos.ObtenerDatosVendedor(idVendedor, dtpDesde.Value, dtpHasta.Value);

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

        // 📤 Exportar Excel
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Archivo Excel|*.xlsx",
                    FileName = $"Rendimiento_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Rendimiento");
                            ws.Cell(1, 1).Value = "Reporte de Rendimiento de Vendedores - TYV WEAR";
                            ws.Range("A1:D1").Merge().Style.Fill.BackgroundColor = XLColor.FromHtml("#C19A6B");
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 14;

                            int row = 3;

                            if ((int)cbVendedor.SelectedValue == 0)
                            {
                                ws.Cell(row, 1).Value = "Vendedor";
                                ws.Cell(row, 2).Value = "Total Ingresos ($)";
                                row++;

                                var ranking = _datos.ObtenerRanking(dtpDesde.Value, dtpHasta.Value);
                                foreach (var v in ranking.OrderByDescending(r => r.Total))
                                {
                                    ws.Cell(row, 1).Value = v.Vendedor;
                                    ws.Cell(row, 2).Value = v.Total;
                                    row++;
                                }
                            }
                            else
                            {
                                int idVendedor = (int)cbVendedor.SelectedValue;
                                string nombre = cbVendedor.Text;
                                var productos = _datos.ObtenerProductosMasVendidos(idVendedor, dtpDesde.Value, dtpHasta.Value);

                                ws.Cell(row, 1).Value = $"Detalle de ventas de {nombre}";
                                ws.Range(row, 1, row, 3).Merge().Style.Fill.BackgroundColor = XLColor.FromHtml("#EBD3B3");
                                row += 2;

                                ws.Cell(row, 1).Value = "Producto";
                                ws.Cell(row, 2).Value = "Cantidad vendida";
                                row++;

                                foreach (var p in productos)
                                {
                                    ws.Cell(row, 1).Value = p.Producto;
                                    ws.Cell(row, 2).Value = p.Cantidad;
                                    row++;
                                }
                            }

                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Reporte exportado correctamente.", "TYV WEAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "TYV WEAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ❌ Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
