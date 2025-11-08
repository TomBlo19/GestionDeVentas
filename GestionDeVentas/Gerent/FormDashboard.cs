using GestionDeVentas.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace GestionDeVentas.Gerent
{
    public partial class FormDashboard : Form
    {
        // ===========================
        // ATRIBUTOS
        // ===========================
        private decimal ventasTotalesMesAnterior = 0;
        private int productosVendidosMesAnterior = 0;
        private int clientesNuevosMesAnterior = 0;

        private readonly Color colorCrecimiento = ColorTranslator.FromHtml("#4CAF50");
        private readonly Color colorDescenso = ColorTranslator.FromHtml("#F44336");
        private readonly Color colorEstable = ColorTranslator.FromHtml("#FFC107");

        // ===========================
        // CONSTRUCTOR
        // ===========================
        public FormDashboard()
        {
            InitializeComponent();

            // Asignar el evento de pintura para el degradado de los paneles KPI
            panelVentasTotales.Paint += PanelKpi_Paint;
            panelProductosVendidos.Paint += PanelKpi_Paint;
            panelClientesNuevos.Paint += PanelKpi_Paint;

            // Asignar evento de filtro rápido
            btnUltimaSemana.Click += BtnFiltroRapido_Click;
            btnMesActual.Click += BtnFiltroRapido_Click;
            btnUltimoTrimestre.Click += BtnFiltroRapido_Click;

            // El evento del botón de exportar ya está enlazado en InitializeComponent.
        }

        // ===========================
        // LOAD DEL FORMULARIO
        // ===========================
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // Ajustes de Docking
            lblTituloDashboard.Dock = DockStyle.Top;
            panelFiltros.Dock = DockStyle.Top;
            panelKpis.Dock = DockStyle.Top;
            panelGrafico.Dock = DockStyle.Top;
            panelProductos.Dock = DockStyle.Fill;

            AplicarEstiloTYV();
            InicializarPanelesKpi();

            // Simular clic para cargar la configuración inicial por defecto
            btnMesActual.PerformClick();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
        private void btnAplicar_Click(object sender, EventArgs e) => CargarDatosDashboard(false);

        // ===========================
        // FILTROS RÁPIDOS
        // ===========================
        private void BtnFiltroRapido_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DateTime hoy = DateTime.Today;

            // Resetear estilos de todos los botones de filtro rápido
            foreach (Control c in panelFiltros.Controls)
            {
                if (c is Button b && b.Tag?.ToString() == "filtro_rapido")
                {
                    b.BackColor = ColorTranslator.FromHtml("#EBD3B3");
                    b.ForeColor = ColorTranslator.FromHtml("#3E2723");
                }
            }

            // Aplicar estilo activo
            btn.BackColor = ColorTranslator.FromHtml("#C19A6B");
            btn.ForeColor = Color.White;

            if (btn.Text == "Última semana")
            {
                dtpDesde.Value = hoy.AddDays(-7).Date;
                dtpHasta.Value = hoy.Date;
            }
            else if (btn.Text == "Mes actual")
            {
                dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1).Date;
                dtpHasta.Value = hoy.Date;
            }
            
            else if (btn.Text == "Ultimos Meses") 
            {
                dtpDesde.Value = hoy.AddMonths(-3).Date;
                dtpHasta.Value = hoy.Date;
            }

            CargarDatosDashboard(true);
        }

        // ===========================
        // EXPORTAR A EXCEL (CON GRÁFICOS)
        // ===========================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Archivo Excel|*.xlsx",
                    FileName = $"Dashboard_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Resumen");

                            // --- TÍTULO ---
                            ws.Cell(1, 1).Value = "Reporte Gerencial - TYV WEAR";
                            ws.Range("A1:E1").Merge();
                            ws.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#C19A6B");
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 14;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // --- KPI ---
                            ws.Cell(3, 1).Value = "Indicador";
                            ws.Cell(3, 2).Value = "Valor";
                            ws.Cell(3, 3).Value = "Tendencia";
                            ws.Range("A3:C3").Style.Fill.BackgroundColor = XLColor.FromHtml("#EBD3B3");
                            ws.Range("A3:C3").Style.Font.Bold = true;


                            int row = 4;
                            // Ventas Totales
                            ws.Cell(row++, 1).Value = "Ventas Totales";
                            ws.Cell(row - 1, 2).Value = lblVentasTotalesValor.Text;
                            ws.Cell(row - 1, 3).Value = lblTendenciaVentas.Text;

                            // Productos Vendidos
                            ws.Cell(row++, 1).Value = "Productos Vendidos";
                            ws.Cell(row - 1, 2).Value = lblProductosVendidosValor.Text;
                            ws.Cell(row - 1, 3).Value = lblTendenciaProductos.Text;

                            // Clientes Nuevos
                            ws.Cell(row++, 1).Value = "Clientes Nuevos";
                            ws.Cell(row - 1, 2).Value = lblClientesNuevosValor.Text;
                            ws.Cell(row - 1, 3).Value = lblTendenciaClientes.Text;

                            // Ticket Promedio
                            ws.Cell(row++, 1).Value = "Ticket Promedio";
                            ws.Cell(row - 1, 2).Value = lblTicketPromedio.Text;

                            row += 2;
                            // Top Productos
                            ws.Cell(row, 1).Value = "Top 5 Productos";
                            ws.Cell(row, 1).Style.Font.Bold = true;
                            ws.Range(row, 1, row, 3).Merge();
                            row++;

                            // Encabezados de la tabla
                            for (int i = 0; i < dgvTopProductos.Columns.Count; i++)
                                ws.Cell(row, i + 1).Value = dgvTopProductos.Columns[i].HeaderText;
                            row++;

                            // Datos de la tabla
                            foreach (DataGridViewRow dgvr in dgvTopProductos.Rows)
                            {
                                for (int i = 0; i < dgvTopProductos.Columns.Count; i++)
                                    ws.Cell(row, i + 1).Value = dgvr.Cells[i].Value?.ToString();
                                row++;
                            }

                            ws.Columns().AdjustToContents();

                            // 📊 Insertar gráficos
                            using (var img1 = new MemoryStream())
                            using (var img2 = new MemoryStream())
                            {
                                chartIngresosMensuales.SaveImage(img1, ChartImageFormat.Png);
                                chartVentasPorProducto.SaveImage(img2, ChartImageFormat.Png);

                                img1.Position = 0;
                                img2.Position = 0;

                                // Posicionamiento de imágenes
                                ws.AddPicture(img1).MoveTo(ws.Cell(2, 5)).Scale(0.7);
                                ws.AddPicture(img2).MoveTo(ws.Cell(30, 5)).Scale(0.7);
                            }

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Reporte exportado correctamente con gráficos incluidos.", "TYV WEAR",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "TYV WEAR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🎨 Estilo general TYV
        private void AplicarEstiloTYV()
        {
            // --- Fondos y Títulos ---
            this.BackColor = ColorTranslator.FromHtml("#F5E6CC");

            lblTituloDashboard.BackColor = ColorTranslator.FromHtml("#3E2723");
            lblTituloDashboard.ForeColor = Color.White;
            lblTituloDashboard.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTituloDashboard.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloDashboard.Height = 60;

            // --- Filtros ---
            panelFiltros.BackColor = ColorTranslator.FromHtml("#EBD3B3");
            foreach (var lbl in new[] { lblDesde, lblHasta })
            {
                lbl.ForeColor = ColorTranslator.FromHtml("#3E2723");
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            // Estilos para botones de filtro rápido
            foreach (var btn in new[] { btnUltimaSemana, btnMesActual, btnUltimoTrimestre })
            {
                btn.BackColor = ColorTranslator.FromHtml("#EBD3B3");
                btn.ForeColor = ColorTranslator.FromHtml("#3E2723");
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C19A6B");
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Tag = "filtro_rapido";
            }

            // Estilo Botón Aplicar y Exportar
            foreach (var button in new[] { btnAplicar, btnExportar })
            {
                button.BackColor = ColorTranslator.FromHtml("#C19A6B");
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                button.Cursor = Cursors.Hand;
            }

            // Estilo para DatePickers
            dtpDesde.CalendarForeColor = ColorTranslator.FromHtml("#3E2723");
            dtpHasta.CalendarForeColor = ColorTranslator.FromHtml("#3E2723");

            // --- KPI ---
            // Colores de los paneles KPI (usados en PanelKpi_Paint)
            panelVentasTotales.Tag = ("#C19A6B", "#A87D56");
            panelProductosVendidos.Tag = ("#7A9E7E", "#5E7C68");
            panelClientesNuevos.Tag = ("#8D6E63", "#6D4C41");

            // Etiquetas de títulos de KPI
            foreach (var lbl in new[] { lblVentasTotales, lblProductosVendidos, lblClientesNuevos })
            {
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lbl.TextAlign = ContentAlignment.TopCenter;
            }

            // Etiquetas de valores de KPI
            foreach (var val in new[] { lblVentasTotalesValor, lblProductosVendidosValor, lblClientesNuevosValor })
            {
                val.ForeColor = Color.White;
                val.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                val.TextAlign = ContentAlignment.MiddleCenter;
            }

            // Flechas de tendencia
            foreach (var lbl in new[] { lblTendenciaVentas, lblTendenciaProductos, lblTendenciaClientes })
            {
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.BackColor = Color.Transparent;
                lbl.Text = "";
            }

            // Sub-indicador de Ticket Promedio
            lblTicketPromedio.ForeColor = Color.White;
            lblTicketPromedio.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblTicketPromedio.TextAlign = ContentAlignment.BottomCenter;

            // --- Gráficos ---
            ConfigurarGraficoTYV(chartIngresosMensuales, "Ingresos Mensuales ($)", "#C19A6B");
            ConfigurarGraficoTYV(chartVentasPorProducto, "Top Productos Vendidos", "#7A9E7E");
            panelGrafico.BackColor = ColorTranslator.FromHtml("#F5E6CC");

            // --- DataGridView (Tabla) ---
            panelProductos.BackColor = ColorTranslator.FromHtml("#F5E6CC");

            lblTituloProductos.ForeColor = ColorTranslator.FromHtml("#3E2723");
            lblTituloProductos.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblTituloProductos.TextAlign = ContentAlignment.MiddleLeft;
            lblTituloProductos.Padding = new Padding(5);

            dgvTopProductos.BackgroundColor = Color.White;
            dgvTopProductos.BorderStyle = BorderStyle.None;
            dgvTopProductos.EnableHeadersVisualStyles = false;

            // Estilo de Cabecera
            dgvTopProductos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3E2723");
            dgvTopProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTopProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTopProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTopProductos.ColumnHeadersHeight = 35;

            // Estilo de Celdas
            dgvTopProductos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTopProductos.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAF0E6");
            dgvTopProductos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#C19A6B");
            dgvTopProductos.RowHeadersVisible = false;
            dgvTopProductos.GridColor = ColorTranslator.FromHtml("#EBD3B3");
            dgvTopProductos.RowTemplate.Height = 30;

            // --- Botón Cerrar ---
            btnCerrar.BackColor = ColorTranslator.FromHtml("#3E2723");
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            btnCerrar.Text = "✕";
            btnCerrar.Cursor = Cursors.Hand;
        }

        private void InicializarPanelesKpi()
        {
            ConfigurarPanelKpi(panelVentasTotales, lblVentasTotales, lblVentasTotalesValor, lblTendenciaVentas, lblTicketPromedio, ((ValueTuple<string, string>)panelVentasTotales.Tag).Item1, "Ventas Totales", "$ 0,00", 15);
            ConfigurarPanelKpi(panelProductosVendidos, lblProductosVendidos, lblProductosVendidosValor, lblTendenciaProductos, null, ((ValueTuple<string, string>)panelProductosVendidos.Tag).Item1, "Productos Vendidos", "0", 340);
            ConfigurarPanelKpi(panelClientesNuevos, lblClientesNuevos, lblClientesNuevosValor, lblTendenciaClientes, null, ((ValueTuple<string, string>)panelClientesNuevos.Tag).Item1, "Clientes Nuevos", "0", 665);
        }

        private void ConfigurarPanelKpi(Panel panel, Label lblTitulo, Label lblValor, Label lblTendencia, Label lblSubIndicador, string colorHex, string titulo, string valor, int x)
        {
            panel.Size = new Size(310, 90);
            panel.Location = new Point(x, 15);

            lblTitulo.Text = titulo;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 23;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            lblTendencia.Location = new Point(panel.Width - 45, 5);
            lblTendencia.BringToFront();

            lblValor.Text = valor;
            if (lblSubIndicador != null)
            {
                lblValor.Dock = DockStyle.Top;
                lblValor.Height = 45;
            }
            else
            {
                lblValor.Dock = DockStyle.Fill;
            }
            lblValor.TextAlign = ContentAlignment.MiddleCenter;

            if (lblSubIndicador != null)
            {
                lblSubIndicador.Dock = DockStyle.Fill;
                lblSubIndicador.Text = "Ticket promedio: $ 0,00";
            }
        }

        // 🟤 Degradado KPI
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

        // 📊 Configuración de gráficos TYV + paleta
        private void ConfigurarGraficoTYV(Chart chart, string titulo, string colorHex)
        {
            chart.BackColor = ColorTranslator.FromHtml("#FAFAFA");

            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add(new ChartArea("MainArea"));

            var area = chart.ChartAreas[0];
            area.BackColor = Color.Transparent;
            area.BorderColor = ColorTranslator.FromHtml("#EBD3B3");
            area.BorderWidth = 1;

            area.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#EBD3B3");
            area.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#EBD3B3");
            area.AxisX.LineColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.LineColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#3E2723");

            area.AxisY2.MajorGrid.LineColor = Color.Transparent;
            area.AxisY2.MajorTickMark.LineColor = ColorTranslator.FromHtml("#3E2723");

            chart.Titles.Clear();
            chart.Titles.Add(titulo);
            chart.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chart.Titles[0].ForeColor = ColorTranslator.FromHtml("#3E2723");

            Color[] paletaTYV =
            {
                ColorTranslator.FromHtml("#C19A6B"),
                ColorTranslator.FromHtml("#8D6E63"),
                ColorTranslator.FromHtml("#7A9E7E"),
                ColorTranslator.FromHtml("#EBD3B3"),
                ColorTranslator.FromHtml("#D4AF37")
            };

            chart.Palette = ChartColorPalette.None;
            chart.BorderlineColor = ColorTranslator.FromHtml("#EBD3B3");
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            foreach (var serie in chart.Series)
            {
                serie.Color = ColorTranslator.FromHtml(colorHex);
                serie.IsValueShownAsLabel = true;
                serie.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                serie.LabelForeColor = ColorTranslator.FromHtml("#3E2723");
                serie.BorderWidth = 2;
                serie.BorderColor = ColorTranslator.FromHtml("#F5E6CC");
                serie["DrawingStyle"] = "Cylinder";

                if (serie.ChartType == SeriesChartType.Pie)
                {
                    for (int i = 0; i < serie.Points.Count; i++)
                    {
                        var color = paletaTYV[i % paletaTYV.Length];
                        serie.Points[i].Color = color;

                        serie.Points[i].Label = $"#VALX (#PERCENT)";
                        serie.Points[i].LegendText = $"#VALX";
                    }

                    serie["PieLabelStyle"] = "Outside";
                    serie["PieLineColor"] = "#3E2723";
                }
            }
        }

        private void AnimarGrafico(Chart chart)
        {
            foreach (var series in chart.Series)
            {
                series["AnimationEnabled"] = "true";
                series["AnimationDuration"] = "2000";
                series["AnimationType"] = "All";
            }
        }

        private async void AnimarKpi(Label lbl, decimal valorFinal, bool esMoneda)
        {
            decimal valorActual = 0;
            int pasos = 30;
            decimal incremento = valorFinal / pasos;

            for (int i = 0; i < pasos; i++)
            {
                valorActual += incremento;
                lbl.Text = esMoneda ? $"$ {valorActual:N2}" : Math.Round(valorActual, 0).ToString("N0");
                await Task.Delay(20);
            }

            lbl.Text = esMoneda ? $"$ {valorFinal:N2}" : valorFinal.ToString("N0");
        }

        private void ResaltarPanel(Panel panel)
        {
            panel.Invalidate();

            var timer = new Timer { Interval = 50 };
            int contador = 0;
            timer.Tick += (s, e) =>
            {
                contador++;
                panel.BackColor = ControlPaint.Dark(panel.BackColor, 0.02f);
                if (contador > 15)
                {
                    timer.Stop();
                    panel.Invalidate();
                }
            };
            timer.Start();
        }

        // Lógica para establecer la tendencia y el ticket promedio
        private void EstablecerTendencia(Label lblTendencia, decimal valorActual, decimal valorAnterior, bool esMoneda, Label lblSubIndicador = null, int numeroFacturas = 0)
        {
            if (valorAnterior == 0)
            {
                lblTendencia.Text = "";
                lblTendencia.ForeColor = Color.Transparent;
            }
            else
            {
                decimal cambio = (valorActual - valorAnterior) / valorAnterior;
                string simbolo = valorActual > valorAnterior ? "▲" : (valorActual < valorAnterior ? "▼" : "—");

                lblTendencia.Text = $"{simbolo} {Math.Abs(cambio):P0}";
                lblTendencia.ForeColor = valorActual > valorAnterior ? colorCrecimiento : (valorActual < valorAnterior ? colorDescenso : colorEstable);
            }

            // Actualizar Ticket Promedio
            if (lblSubIndicador != null)
            {
                decimal ticketPromedio = numeroFacturas > 0 ? valorActual / numeroFacturas : 0;
                lblSubIndicador.Text = $"Ticket promedio: $ {ticketPromedio:N2}";
            }
        }

        // Obtener datos de facturas (usado para tendencia temporal)
        private DataTable ObtenerDatosFacturas(DateTime desde, DateTime hasta)
        {
            string query = @"
                SELECT fecha_factura, total_factura
                FROM factura 
                WHERE activo = 1 AND fecha_factura BETWEEN @Desde AND @Hasta
                ORDER BY fecha_factura;";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                    da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta.AddDays(1).AddSeconds(-1));
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Cargar datos del período anterior
        private void CargarDatosMesAnterior(DateTime desde, DateTime hasta)
        {
            TimeSpan duracion = hasta.Subtract(desde);
            DateTime desdeAnterior = desde.Subtract(duracion).AddDays(-1);
            DateTime hastaAnterior = desde.AddDays(-1);

            string queryKpis = @"
                SELECT  
                    ISNULL(SUM(f.total_factura),0) AS TotalVentas,
                    ISNULL(SUM(d.cantidad),0) AS ProductosVendidos,
                    COUNT(DISTINCT c.id_cliente) AS ClientesNuevos
                FROM factura f
                JOIN detalle_factura d ON d.id_factura = f.id_factura
                JOIN cliente c ON c.id_cliente = f.id_cliente
                WHERE f.fecha_factura BETWEEN @Desde AND @Hasta
                    AND f.activo = 1;";

            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryKpis, conn))
                    {
                        cmd.Parameters.AddWithValue("@Desde", desdeAnterior);
                        cmd.Parameters.AddWithValue("@Hasta", hastaAnterior.AddDays(1).AddSeconds(-1));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ventasTotalesMesAnterior = reader.GetDecimal(0);
                                productosVendidosMesAnterior = reader.GetInt32(1);
                                clientesNuevosMesAnterior = reader.GetInt32(2);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ventasTotalesMesAnterior = 0;
                productosVendidosMesAnterior = 0;
                clientesNuevosMesAnterior = 0;
            }
        }


        private async void CargarDatosDashboard(bool isQuickFilter)
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date;

                // 1. Cargar datos del período anterior de forma asíncrona
                await Task.Run(() => CargarDatosMesAnterior(desde, hasta));

                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();

                    // --- KPI PRINCIPALES ---
                    string queryKpis = @"
    SELECT  
        ISNULL(SUM(d.cantidad * d.precio_unitario),0) AS TotalVentas,
        ISNULL(SUM(d.cantidad),0) AS ProductosVendidos,
        COUNT(DISTINCT c.id_cliente) AS ClientesNuevos,
        COUNT(DISTINCT f.id_factura) AS NumeroFacturas
    FROM factura f
    JOIN detalle_factura d ON d.id_factura = f.id_factura
    JOIN cliente c ON c.id_cliente = f.id_cliente
    WHERE f.fecha_factura BETWEEN @Desde AND @Hasta
        AND f.activo = 1;";

                    decimal totalVentas = 0;
                    int productosVendidos = 0, clientesNuevos = 0, numeroFacturas = 0;

                    using (SqlCommand cmd = new SqlCommand(queryKpis, conn))
                    {
                        cmd.Parameters.AddWithValue("@Desde", desde);
                        cmd.Parameters.AddWithValue("@Hasta", hasta.AddDays(1).AddSeconds(-1));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalVentas = reader.GetDecimal(0);
                                productosVendidos = reader.GetInt32(1);
                                clientesNuevos = reader.GetInt32(2);
                                numeroFacturas = reader.GetInt32(3);
                            }
                        }
                    }

                    // 2. Aplicar indicadores comparativos y Ticket Promedio
                    EstablecerTendencia(lblTendenciaVentas, totalVentas, ventasTotalesMesAnterior, true, lblTicketPromedio, numeroFacturas);
                    EstablecerTendencia(lblTendenciaProductos, productosVendidos, productosVendidosMesAnterior, false);
                    EstablecerTendencia(lblTendenciaClientes, clientesNuevos, clientesNuevosMesAnterior, false);

                    // Animación de valores
                    AnimarKpi(lblVentasTotalesValor, totalVentas, true);
                    AnimarKpi(lblProductosVendidosValor, productosVendidos, false);
                    AnimarKpi(lblClientesNuevosValor, clientesNuevos, false);

                    // --- GRÁFICO DE INGRESOS MENSUALES ---
                    string queryIngresos = @"
    SELECT  
        FORMAT(f.fecha_factura, 'MM-yyyy') AS Mes,
        SUM(d.cantidad * d.precio_unitario) AS Total
    FROM factura f
    JOIN detalle_factura d ON d.id_factura = f.id_factura
    WHERE f.activo = 1
        AND f.fecha_factura BETWEEN @Desde AND @Hasta
    GROUP BY FORMAT(f.fecha_factura, 'MM-yyyy')
    ORDER BY MIN(f.fecha_factura);";



                    var serieIngresos = new Series("Ingresos")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = ColorTranslator.FromHtml("#C19A6B"),
                        IsValueShownAsLabel = true
                    };

                    using (SqlCommand cmd = new SqlCommand(queryIngresos, conn))
                    {
                        cmd.Parameters.AddWithValue("@Desde", desde);
                        cmd.Parameters.AddWithValue("@Hasta", hasta.AddDays(1).AddSeconds(-1));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string mes = reader.GetString(0);
                                decimal total = reader.GetDecimal(1);
                                serieIngresos.Points.AddXY(mes, total);
                            }
                        }
                    }

                    chartIngresosMensuales.Series.Clear();
                    chartIngresosMensuales.Series.Add(serieIngresos);

                    // Gráfico de tendencia diaria si el rango es pequeño
                    if (hasta.Subtract(desde).TotalDays <= 31)
                    {
                        var dtFacturas = ObtenerDatosFacturas(desde, hasta);
                        var datosDiarios = dtFacturas.AsEnumerable()
                            .GroupBy(r => r.Field<DateTime>("fecha_factura").Date)
                            .Select(g => new { Dia = g.Key.ToString("dd"), Total = g.Sum(r => r.Field<decimal>("total_factura")) })
                            .OrderBy(x => x.Dia)
                            .ToList();

                        if (datosDiarios.Count > 0)
                        {
                            var serieTendenciaDiaria = new Series("Tendencia Diaria ($)")
                            {
                                ChartArea = "MainArea",
                                ChartType = SeriesChartType.Line,
                                Color = ColorTranslator.FromHtml("#3E2723"),
                                BorderWidth = 3,
                                MarkerStyle = MarkerStyle.Circle,
                                MarkerSize = 6,
                                YAxisType = AxisType.Secondary,
                                IsValueShownAsLabel = false
                            };

                            foreach (var dato in datosDiarios)
                                serieTendenciaDiaria.Points.AddXY(dato.Dia, dato.Total);

                            chartIngresosMensuales.Series.Add(serieTendenciaDiaria);
                        }

                        ConfigurarGraficoTYV(chartIngresosMensuales, "Ingresos y Tendencia Diaria ($)", "#C19A6B");
                        chartIngresosMensuales.ChartAreas[0].AxisX.Title = "Día del Mes";
                        chartIngresosMensuales.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                        chartIngresosMensuales.ChartAreas[0].AxisY2.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
                        chartIngresosMensuales.ChartAreas[0].AxisY.Title = "Ingresos Acumulados";
                    }
                    else
                    {
                        ConfigurarGraficoTYV(chartIngresosMensuales, "Ingresos Mensuales ($)", "#C19A6B");
                        chartIngresosMensuales.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;
                        chartIngresosMensuales.ChartAreas[0].AxisX.Title = "";
                        chartIngresosMensuales.ChartAreas[0].AxisY.Title = "";
                    }

                    AnimarGrafico(chartIngresosMensuales);

                    // --- TOP 5 PRODUCTOS ---
                    string queryTopProductos = @"
                        SELECT TOP 5 
                            p.nombre_producto AS Producto,
                            SUM(d.cantidad) AS CantidadVendida,
                            SUM(d.cantidad * d.precio_unitario) AS TotalVentasProducto
                        FROM detalle_factura d
                        JOIN producto p ON p.id_producto = d.id_producto
                        JOIN factura f ON f.id_factura = d.id_factura
                        WHERE f.fecha_factura BETWEEN @Desde AND @Hasta
                            AND f.activo = 1
                        GROUP BY p.nombre_producto
                        ORDER BY SUM(d.cantidad) DESC;";

                    DataTable dtTop = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(queryTopProductos, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                        da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta.AddDays(1).AddSeconds(-1));
                        da.Fill(dtTop);
                    }

                    dgvTopProductos.DataSource = dtTop;
                    dgvTopProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dtTop.Rows.Count == 0)
                    {
                        chartVentasPorProducto.Series.Clear();
                        return;
                    }

                    if (!dtTop.Columns.Contains("Contribucion (%)"))
                        dtTop.Columns.Add("Contribucion (%)", typeof(string));

                    double totalUnidadesVendidas = dtTop.AsEnumerable().Sum(row => row.Field<int>("CantidadVendida"));
                    dgvTopProductos.Columns[0].HeaderText = "Producto";
                    dgvTopProductos.Columns[1].HeaderText = "Cantidad Vendida";

                    if (dgvTopProductos.Columns.Contains("TotalVentasProducto"))
                        dgvTopProductos.Columns["TotalVentasProducto"].Visible = false;

                    var serieProductos = new Series("Productos")
                    {
                        ChartType = SeriesChartType.Pie,
                        IsValueShownAsLabel = true
                    };

                    foreach (DataRow row in dtTop.Rows)
                    {
                        int unidades = row.Field<int>("CantidadVendida");
                        double porcentaje = totalUnidadesVendidas > 0 ? (unidades / totalUnidadesVendidas) * 100 : 0;
                        row["Contribucion (%)"] = $"{porcentaje:N1} %";
                        serieProductos.Points.AddXY(row["Producto"], unidades);
                    }

                    dgvTopProductos.Columns["Contribucion (%)"].HeaderText = "Contribución (%)";

                    chartVentasPorProducto.Series.Clear();
                    chartVentasPorProducto.Series.Add(serieProductos);
                    ConfigurarGraficoTYV(chartVentasPorProducto, "Top Productos Vendidos", "#7A9E7E");
                    AnimarGrafico(chartVentasPorProducto);

                    // --- Efecto visual ---
                    ResaltarPanel(panelVentasTotales);
                    ResaltarPanel(panelProductosVendidos);
                    ResaltarPanel(panelClientesNuevos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del Dashboard:\n{ex.Message}",
                    "TYV Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control c in panelFiltros.Controls)
            {
                if (c is Button b && b.Tag?.ToString() == "filtro_rapido")
                {
                    b.BackColor = ColorTranslator.FromHtml("#EBD3B3");
                    b.ForeColor = ColorTranslator.FromHtml("#3E2723");
                }
            }
        }
    }
}