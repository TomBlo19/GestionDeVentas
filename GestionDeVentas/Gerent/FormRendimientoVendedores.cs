using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Drawing.Drawing2D;
using Datos;
using ClosedXML.Excel;
using System.IO;

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
            // ❌ IMPORTANTE: Eliminada la línea btnExportar.Click += btnExportar_Click;
            // El diseñador (InitializeComponent) es ahora la única fuente de vinculación.
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
                btn.Cursor = Cursors.Hand;
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
            btnCerrar.Cursor = Cursors.Hand;

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

            if (chart.Series.Count > 0)
            {
                chart.Series[0].Color = colorBase;
                chart.Series[0].Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
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

            var totalIngresos = ranking.Sum(r => r.Total);
            lblIngresosValor.Text = $"$ {totalIngresos:N2}";

            var serie = new Series("Vendedores")
            {
                ChartArea = "MainArea",
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Color = colorAcento1,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            foreach (var v in ranking.OrderByDescending(r => r.Total))
                serie.Points.AddXY(v.Vendedor, v.Total);

            chartIngresosMensuales.Series.Add(serie);
            ConfigurarGraficoTYV(chartIngresosMensuales, "Ranking de Vendedores (Ingresos)", colorAcento1);

            // Limpiar el segundo gráfico y título en modo Ranking
            chartVentasPorProducto.Titles.Clear();
            chartVentasPorProducto.Titles.Add("Productos vendidos (No aplica en ranking)");
        }

        // 📊 Detalle de vendedor
        private void CargarDetalleVendedor(string nombreVendedor)
        {
            int idVendedor = (int)cbVendedor.SelectedValue;
            var datos = _datos.ObtenerDatosVendedor(idVendedor, dtpDesde.Value, dtpHasta.Value);

            lblIngresosValor.Text = $"$ {datos.ingresos:N2}";
            lblVentasUnidadesValor.Text = datos.unidades.ToString("N0");

            // Gráfico 1: Ingresos Mensuales
            var ingresos = _datos.ObtenerIngresosMensuales(idVendedor); // Nota: Asumo que este método usa las fechas del DT
            chartIngresosMensuales.Series.Clear();
            var serie = new Series("Ingresos")
            {
                ChartArea = "MainArea",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = colorAcento1,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            foreach (var m in ingresos)
                serie.Points.AddXY(m.Mes, m.Total);
            chartIngresosMensuales.Series.Add(serie);
            ConfigurarGraficoTYV(chartIngresosMensuales, $"Ingresos mensuales de {nombreVendedor}", colorAcento1);

            // Gráfico 2: Productos más vendidos (Pie Chart)
            var productos = _datos.ObtenerProductosMasVendidos(idVendedor, dtpDesde.Value, dtpHasta.Value);
            chartVentasPorProducto.Series.Clear();
            var serieProd = new Series("Productos")
            {
                ChartArea = "MainArea",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                LabelFormat = "#PERCENT"
            };

            Color[] paletaPie = { colorAcento2, ColorTranslator.FromHtml("#8D6E63"), ColorTranslator.FromHtml("#EBD3B3"), colorAcento1, ColorTranslator.FromHtml("#D4AF37") };
            int i = 0;
            foreach (var p in productos)
            {
                var dataPoint = serieProd.Points.Add(p.Cantidad);
                dataPoint.LegendText = p.Producto;
                dataPoint.Color = paletaPie[i++ % paletaPie.Length];
            }

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

        // 📤 Exportar Excel (AHORA CON GRÁFICOS)
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (chartIngresosMensuales.Series.Count == 0)
            {
                MessageBox.Show("Cargue los datos primero haciendo clic en 'Aplicar'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Archivo Excel|*.xlsx",
                    FileName = $"Rendimiento_Vendedores_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Rendimiento");
                            ws.Cell(1, 1).Value = "Reporte de Rendimiento de Vendedores - TYV WEAR";
                            ws.Range("A1:E1").Merge().Style.Fill.BackgroundColor = XLColor.FromHtml("#C19A6B");
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 14;

                            int row = 3;

                            // 1. Exportación de Datos (KPIs y Tablas)
                            if ((int)cbVendedor.SelectedValue == 0)
                            {
                                // MODO RANKING
                                ws.Cell(row, 1).Value = "Ranking General de Vendedores (Ingresos)";
                                ws.Range(row, 1, row, 3).Merge().Style.Fill.BackgroundColor = XLColor.FromHtml("#EBD3B3");
                                ws.Range(row, 1, row, 3).Style.Font.Bold = true;
                                row++;

                                ws.Cell(row, 1).Value = "Vendedor";
                                ws.Cell(row, 2).Value = "Total Ingresos ($)";
                                row++;

                                var ranking = _datos.ObtenerRanking(dtpDesde.Value, dtpHasta.Value);
                                foreach (var v in ranking.OrderByDescending(r => r.Total))
                                {
                                    ws.Cell(row, 1).Value = v.Vendedor;
                                    ws.Cell(row, 2).Value = v.Total;
                                    ws.Cell(row, 2).Style.NumberFormat.Format = "$ #,##0.00"; // Formato moneda
                                    row++;
                                }
                            }
                            else
                            {
                                // MODO DETALLE DE VENDEDOR
                                string nombre = cbVendedor.Text;
                                int idVendedor = (int)cbVendedor.SelectedValue;
                                var datosKPI = _datos.ObtenerDatosVendedor(idVendedor, dtpDesde.Value, dtpHasta.Value);
                                var productos = _datos.ObtenerProductosMasVendidos(idVendedor, dtpDesde.Value, dtpHasta.Value);

                                ws.Cell(row, 1).Value = $"Detalle de ventas de {nombre}";
                                ws.Range(row, 1, row, 3).Merge().Style.Fill.BackgroundColor = XLColor.FromHtml("#EBD3B3");
                                ws.Range(row, 1, row, 3).Style.Font.Bold = true;
                                row += 2;

                                // Exportar KPIs
                                ws.Cell(row, 1).Value = "KPI: Ingresos Totales";
                                ws.Cell(row++, 2).Value = datosKPI.ingresos;
                                ws.Cell(row - 1, 2).Style.NumberFormat.Format = "$ #,##0.00";

                                ws.Cell(row, 1).Value = "KPI: Unidades Vendidas";
                                ws.Cell(row++, 2).Value = datosKPI.unidades;
                                row++;

                                // Exportar Tabla de Productos Vendidos
                                ws.Cell(row, 1).Value = "Productos Más Vendidos (Cant.)";
                                ws.Range(row, 1, row, 2).Merge().Style.Fill.BackgroundColor = XLColor.FromHtml("#EBD3B3");
                                ws.Range(row, 1, row, 2).Style.Font.Bold = true;
                                row++;

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

                            // 2. Exportar Gráficos
                            using (var img1 = new MemoryStream())
                            using (var img2 = new MemoryStream())
                            {
                                // Captura Chart 1 (Ranking o Ingresos Mensuales)
                                chartIngresosMensuales.SaveImage(img1, ChartImageFormat.Png);
                                img1.Position = 0;
                                ws.AddPicture(img1).MoveTo(ws.Cell(3, 4)).Scale(0.8);

                                // Captura Chart 2 (Productos Vendidos, si aplica)
                                if ((int)cbVendedor.SelectedValue != 0 && chartVentasPorProducto.Series.Count > 0)
                                {
                                    chartVentasPorProducto.SaveImage(img2, ChartImageFormat.Png);
                                    img2.Position = 0;
                                    // Coloca el segundo gráfico más abajo.
                                    ws.AddPicture(img2).MoveTo(ws.Cell(25, 1)).Scale(0.8);
                                }
                            }

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Reporte exportado correctamente con gráficos.", "TYV WEAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
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