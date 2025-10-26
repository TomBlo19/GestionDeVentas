using GestionDeVentas.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace GestionDeVentas.Gerent
{
    public partial class FormDashboard : Form
    {
        // 🆕 NUEVOS ATRIBUTOS PARA EL CÁLCULO DE INDICADORES
        private decimal ventasTotalesMesAnterior = 0;
        private int productosVendidosMesAnterior = 0;
        private int clientesNuevosMesAnterior = 0;

        // 🆕 PALETA DE COLORES PARA LAS FLECHAS DE TENDENCIA
        private readonly Color colorCrecimiento = ColorTranslator.FromHtml("#4CAF50"); // Verde
        private readonly Color colorDescenso = ColorTranslator.FromHtml("#F44336"); // Rojo
        private readonly Color colorEstable = ColorTranslator.FromHtml("#FFC107"); // Amarillo/Naranja

        public FormDashboard()
        {
            InitializeComponent();

            panelVentasTotales.Paint += PanelKpi_Paint;
            panelProductosVendidos.Paint += PanelKpi_Paint;
            panelClientesNuevos.Paint += PanelKpi_Paint;

            // 🆕 Inicializar eventos de filtros rápidos
            btnUltimaSemana.Click += BtnFiltroRapido_Click;
            btnMesActual.Click += BtnFiltroRapido_Click;
            btnUltimoTrimestre.Click += BtnFiltroRapido_Click;

            // 🆕 Manejador para el botón de exportar
            btnExportar.Click += BtnExportar_Click;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            lblTituloDashboard.Dock = DockStyle.Top;
            panelFiltros.Dock = DockStyle.Top;
            panelKpis.Dock = DockStyle.Top;
            panelGrafico.Dock = DockStyle.Top;
            panelProductos.Dock = DockStyle.Fill;

            AplicarEstiloTYV();
            InicializarPanelesKpi();

            // 🔹 Mostrar datos del mes actual por defecto
            btnMesActual.PerformClick(); // Carga por defecto el mes actual
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
        private void btnAplicar_Click(object sender, EventArgs e) => CargarDatosDashboard(false);

        // 🆕 Lógica para filtros rápidos
        private void BtnFiltroRapido_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DateTime hoy = DateTime.Today;

            // Restablecer el estilo de todos los botones
            foreach (Control c in panelFiltros.Controls)
            {
                if (c is Button b && b.Tag != null && b.Tag.ToString() == "filtro_rapido")
                {
                    b.BackColor = ColorTranslator.FromHtml("#EBD3B3");
                    b.ForeColor = ColorTranslator.FromHtml("#3E2723");
                }
            }

            // Aplicar el estilo al botón presionado
            btn.BackColor = ColorTranslator.FromHtml("#C19A6B");
            btn.ForeColor = Color.White;

            if (btn.Text == "Última semana")
            {
                dtpDesde.Value = hoy.AddDays(-7);
                dtpHasta.Value = hoy;
            }
            else if (btn.Text == "Mes actual")
            {
                dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
                dtpHasta.Value = hoy;
            }
            else if (btn.Text == "Último trimestre")
            {
                dtpDesde.Value = hoy.AddMonths(-3).AddDays(1); // Ajuste: 3 meses y 1 día
                dtpHasta.Value = hoy;
            }

            CargarDatosDashboard(true);
        }

        // 🆕 Lógica para Exportar
        private void BtnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de exportar a PDF/Excel en desarrollo.", "TYV Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí iría la lógica real para generar el PDF/Excel con los datos de las tablas y gráficos
        }


        // 🎨 Estilo general TYV - APLICANDO ESTÉTICA CÁLIDA (Añadimos estilos para los nuevos elementos)
        private void AplicarEstiloTYV()
        {
            // --- Fondos y Títulos ---
            this.BackColor = ColorTranslator.FromHtml("#F5E6CC"); // Fondo principal crema/beige

            lblTituloDashboard.BackColor = ColorTranslator.FromHtml("#3E2723"); // Marrón oscuro
            lblTituloDashboard.ForeColor = Color.White;
            lblTituloDashboard.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTituloDashboard.TextAlign = ContentAlignment.MiddleCenter;
            lblTituloDashboard.Height = 60;

            // --- Filtros ---
            panelFiltros.BackColor = ColorTranslator.FromHtml("#EBD3B3"); // Marrón claro para filtros
            foreach (var lbl in new[] { lblDesde, lblHasta })
            {
                lbl.ForeColor = ColorTranslator.FromHtml("#3E2723"); // Texto marrón oscuro
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

            btnAplicar.BackColor = ColorTranslator.FromHtml("#C19A6B"); // Marrón caramelo para aplicar
            btnAplicar.ForeColor = Color.White;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAplicar.Cursor = Cursors.Hand;
            btnAplicar.Padding = new Padding(0);

            // Estilo para DatePickers (Mejora estética)
            dtpDesde.CalendarForeColor = ColorTranslator.FromHtml("#3E2723");
            dtpHasta.CalendarForeColor = ColorTranslator.FromHtml("#3E2723");

            // 🆕 Estilo para el botón de exportar
            btnExportar.BackColor = ColorTranslator.FromHtml("#3E2723");
            btnExportar.ForeColor = Color.White;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnExportar.Cursor = Cursors.Hand;

            // --- KPI's ---
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

            // 🆕 Estilo para el sub-indicador de Ticket Promedio
            lblTicketPromedio.ForeColor = Color.White;
            lblTicketPromedio.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblTicketPromedio.TextAlign = ContentAlignment.BottomCenter;

            // 🆕 Estilo para las flechas de tendencia
            foreach (var lbl in new[] { lblTendenciaVentas, lblTendenciaProductos, lblTendenciaClientes })
            {
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.BackColor = Color.Transparent; // Para que se vea el degradado del panel
                lbl.Text = ""; // Inicialmente vacío
            }

            // Colores de los paneles KPI (usados en PanelKpi_Paint)
            panelVentasTotales.Tag = ("#C19A6B", "#A87D56"); // Marrón claro a oscuro (Ventas Totales)
            panelProductosVendidos.Tag = ("#7A9E7E", "#5E7C68"); // Verde oliva a oscuro (Productos Vendidos)
            panelClientesNuevos.Tag = ("#8D6E63", "#6D4C41"); // Marrón grisáceo a oscuro (Clientes Nuevos)

            // --- Gráficos ---
            ConfigurarGraficoTYV(chartIngresosMensuales, "Ingresos Mensuales ($)", "#C19A6B"); // Color principal
            ConfigurarGraficoTYV(chartVentasPorProducto, "Top Productos Vendidos", "#7A9E7E"); // Color secundario
            panelGrafico.BackColor = ColorTranslator.FromHtml("#F5E6CC"); // Asegura que el panel de fondo sea el mismo que el principal

            // --- DataGridView (Tabla) ---
            panelProductos.BackColor = ColorTranslator.FromHtml("#F5E6CC");

            lblTituloProductos.ForeColor = ColorTranslator.FromHtml("#3E2723"); // Texto marrón oscuro
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
            dgvTopProductos.ColumnHeadersHeight = 35; // Altura para mejor vista

            // Estilo de Celdas
            dgvTopProductos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTopProductos.DefaultCellStyle.BackColor = Color.White;
            dgvTopProductos.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAF0E6"); // Fila alterna para contraste suave
            dgvTopProductos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#C19A6B"); // Selección con color de acento
            dgvTopProductos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTopProductos.RowHeadersVisible = false;
            dgvTopProductos.GridColor = ColorTranslator.FromHtml("#EBD3B3"); // Líneas de cuadrícula suaves
            dgvTopProductos.RowTemplate.Height = 30; // Altura de fila para mejor vista

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
            // Pasa las referencias de los labels existentes, incluyendo el nuevo de ticket promedio y tendencia
            ConfigurarPanelKpi(panelVentasTotales, lblVentasTotales, lblVentasTotalesValor, lblTendenciaVentas, lblTicketPromedio, ((ValueTuple<string, string>)panelVentasTotales.Tag).Item1, "Ventas Totales", "$ 0,00", 15);

            // Los otros KPI no tienen Ticket Promedio, se pasa null
            ConfigurarPanelKpi(panelProductosVendidos, lblProductosVendidos, lblProductosVendidosValor, lblTendenciaProductos, null, ((ValueTuple<string, string>)panelProductosVendidos.Tag).Item1, "Productos Vendidos", "0", 340);
            ConfigurarPanelKpi(panelClientesNuevos, lblClientesNuevos, lblClientesNuevosValor, lblTendenciaClientes, null, ((ValueTuple<string, string>)panelClientesNuevos.Tag).Item1, "Clientes Nuevos", "0", 665);
        }

        // Método corregido: Configura los labels que ya existen
        private void ConfigurarPanelKpi(Panel panel, Label lblTitulo, Label lblValor, Label lblTendencia, Label lblSubIndicador, string colorHex, string titulo, string valor, int x)
        {
            panel.Size = new Size(310, 90);
            panel.Location = new Point(x, 15);

            lblTitulo.Text = titulo;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 25;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Posicionar la tendencia (se ajustará dinámicamente)
            lblTendencia.Location = new Point(265, 5);
            lblTendencia.BringToFront(); // Asegura que la flecha esté visible

            lblValor.Text = valor;
            // Si hay subindicador (Ticket Promedio), el valor ocupa solo la parte superior, si no, ocupa todo el espacio
            lblValor.Dock = lblSubIndicador == null ? DockStyle.Fill : DockStyle.Top;
            lblValor.Height = lblSubIndicador == null ? panel.Height - lblTitulo.Height : 45;
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
            chart.BackColor = ColorTranslator.FromHtml("#FAFAFA"); // Un blanco muy suave

            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add(new ChartArea("MainArea"));

            var area = chart.ChartAreas[0];
            area.BackColor = Color.Transparent; // Fondo transparente, usa el color del panelGrafico
            area.BorderColor = ColorTranslator.FromHtml("#EBD3B3"); // Borde del área de trazado suave
            area.BorderWidth = 1;

            // Estilo de cuadrícula y ejes
            area.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#EBD3B3");
            area.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#EBD3B3");
            area.AxisX.LineColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.LineColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisX.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisX.MajorTickMark.LineColor = ColorTranslator.FromHtml("#3E2723");
            area.AxisY.MajorTickMark.LineColor = ColorTranslator.FromHtml("#3E2723");

            // Configuración del eje secundario (para tendencia diaria)
            area.AxisY2.MajorGrid.LineColor = Color.Transparent;
            area.AxisY2.MajorTickMark.LineColor = ColorTranslator.FromHtml("#3E2723");


            chart.Titles.Clear();
            chart.Titles.Add(titulo);
            chart.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chart.Titles[0].ForeColor = ColorTranslator.FromHtml("#3E2723");

            Color[] paletaTYV =
            {
                ColorTranslator.FromHtml("#C19A6B"), // Marrón claro
                ColorTranslator.FromHtml("#8D6E63"), // Marrón grisáceo
                ColorTranslator.FromHtml("#7A9E7E"), // Verde oliva
                ColorTranslator.FromHtml("#EBD3B3"), // Beige claro
                ColorTranslator.FromHtml("#D4AF37")  // Dorado suave
            };

            chart.Palette = ChartColorPalette.None; // Desactivar paletas predefinidas
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
                serie.BorderColor = ColorTranslator.FromHtml("#F5E6CC"); // Borde de columna/barra más sutil
                serie["DrawingStyle"] = "Cylinder";

                if (serie.ChartType == SeriesChartType.Pie)
                {
                    // Asignar colores de la paleta manualmente para gráficos circulares
                    for (int i = 0; i < serie.Points.Count; i++)
                    {
                        var color = paletaTYV[i % paletaTYV.Length];
                        serie.Points[i].Color = color;

                        // 🆕 Formato de etiqueta con porcentaje
                        serie.Points[i].Label = $"#VALX (#PERCENT)"; // Muestra producto y porcentaje
                        serie.Points[i].LegendText = $"#VALX"; // La leyenda muestra solo el producto
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
            panel.BackColor = ControlPaint.Light(ColorTranslator.FromHtml(((ValueTuple<string, string>)panel.Tag).Item1), 0.3f);
            var timer = new Timer { Interval = 15 };
            int contador = 0;
            timer.Tick += (s, e) =>
            {
                contador++;
                // Usamos el color original del tag para el degradado en Paint, y solo oscurecemos ligeramente
                panel.BackColor = ControlPaint.Dark(panel.BackColor, 0.02f);
                if (contador > 10)
                {
                    timer.Stop();
                    // Forzar redibujo para que el Paint use el degradado (PanelKpi_Paint)
                    panel.Invalidate();
                }
            };
            timer.Start();
        }

        // 🆕 Lógica para establecer la tendencia y el ticket promedio
        private void EstablecerTendencia(Label lblTendencia, decimal valorActual, decimal valorAnterior, bool esMoneda, Label lblSubIndicador = null, int numeroFacturas = 0)
        {
            if (valorAnterior == 0)
            {
                lblTendencia.Text = ""; // No hay datos previos para comparar
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

        // 🆕 NUEVO: Obtener datos de facturas (usado para tendencia temporal)
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


        // 🆕 NUEVO: Cargar datos del período anterior
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
                // En caso de error de conexión, se asume 0 para no bloquear la carga principal.
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
                            ISNULL(SUM(f.total_factura),0) AS TotalVentas,
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

                    // 2. Aplicar indicadores comparativos (flechas) y Ticket Promedio
                    EstablecerTendencia(lblTendenciaVentas, totalVentas, ventasTotalesMesAnterior, true, lblTicketPromedio, numeroFacturas);
                    EstablecerTendencia(lblTendenciaProductos, productosVendidos, productosVendidosMesAnterior, false);
                    EstablecerTendencia(lblTendenciaClientes, clientesNuevos, clientesNuevosMesAnterior, false);

                    AnimarKpi(lblVentasTotalesValor, totalVentas, true);
                    AnimarKpi(lblProductosVendidosValor, productosVendidos, false);
                    AnimarKpi(lblClientesNuevosValor, clientesNuevos, false);

                    if (isQuickFilter && totalVentas == 0 && productosVendidos == 0 && clientesNuevos == 0)
                        MessageBox.Show("No se encontraron datos en el rango seleccionado.",
                            "TYV Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    // --- GRÁFICO DE INGRESOS MENSUALES ---
                    string queryIngresos = @"
                        SELECT 
                            FORMAT(f.fecha_factura, 'MM-yyyy') AS Mes,
                            SUM(f.total_factura) AS Total
                        FROM factura f
                        WHERE f.activo = 1
                          AND f.fecha_factura BETWEEN @Desde AND @Hasta
                        GROUP BY FORMAT(f.fecha_factura, 'MM-yyyy')
                        ORDER BY MIN(f.fecha_factura);";

                    var serieIngresos = new Series("Ingresos") { ChartType = SeriesChartType.Column, Color = ColorTranslator.FromHtml("#C19A6B"), IsValueShownAsLabel = true };

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

                    // 3. Gráfico de Tendencia Temporal (Por Días) - Se superpone
                    if (hasta.Subtract(desde).TotalDays <= 31) // Si el rango es de un mes o menos
                    {
                        var dtFacturas = ObtenerDatosFacturas(desde, hasta);
                        var datosDiarios = dtFacturas.AsEnumerable()
                            .GroupBy(r => r.Field<DateTime>("fecha_factura").Date)
                            .Select(g => new { Dia = g.Key.ToString("dd"), Total = g.Sum(r => r.Field<decimal>("total_factura")) })
                            .OrderBy(x => x.Dia)
                            .ToList();

                        var serieTendenciaDiaria = new Series("Tendencia Diaria ($)")
                        {
                            ChartArea = "MainArea",
                            ChartType = SeriesChartType.Line,
                            Color = ColorTranslator.FromHtml("#3E2723"), // Marrón oscuro
                            BorderWidth = 3,
                            MarkerStyle = MarkerStyle.Circle,
                            MarkerSize = 6,
                            YAxisType = AxisType.Secondary, // Usar eje Y secundario
                            IsValueShownAsLabel = false
                        };

                        foreach (var dato in datosDiarios)
                            serieTendenciaDiaria.Points.AddXY(dato.Dia, dato.Total);

                        chartIngresosMensuales.Series.Add(serieTendenciaDiaria);
                        ConfigurarGraficoTYV(chartIngresosMensuales, "Ingresos y Tendencia Diaria ($)", "#C19A6B");
                        chartIngresosMensuales.ChartAreas[0].AxisX.Title = "Día del Mes";
                        // <<<<< CORRECCIÓN CS0029 AQUI >>>>>
                        chartIngresosMensuales.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                        chartIngresosMensuales.ChartAreas[0].AxisY2.LabelStyle.ForeColor = ColorTranslator.FromHtml("#3E2723");
                        chartIngresosMensuales.ChartAreas[0].AxisY.Title = "Ingresos Acumulados";
                    }
                    else
                    {
                        ConfigurarGraficoTYV(chartIngresosMensuales, "Ingresos Mensuales ($)", "#C19A6B");
                        // <<<<< CORRECCIÓN CS0029 AQUI >>>>>
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

                    // 4. Cálculo de Porcentaje de Participación
                    if (!dtTop.Columns.Contains("Contribucion (%)"))
                        dtTop.Columns.Add("Contribucion (%)", typeof(string));

                    // Calcular el total de ventas (en unidades) para el top 5 para el gráfico circular
                    double totalUnidadesVendidas = dtTop.AsEnumerable().Sum(row => row.Field<int>("CantidadVendida"));
                    decimal totalVentasProductos = dtTop.AsEnumerable().Sum(row => row.Field<decimal>("TotalVentasProducto"));

                    dgvTopProductos.DataSource = dtTop;
                    dgvTopProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvTopProductos.Columns[0].HeaderText = "Producto";
                    dgvTopProductos.Columns[1].HeaderText = "Cantidad Vendida";

                    // Ocultar la columna de totales en dinero, solo la usaremos para calcular %
                    if (dgvTopProductos.Columns.Contains("TotalVentasProducto"))
                        dgvTopProductos.Columns["TotalVentasProducto"].Visible = false;

                    var serieProductos = new Series("Productos") { ChartType = SeriesChartType.Pie, IsValueShownAsLabel = true };

                    // Llenar tabla y serie con porcentajes
                    foreach (DataRow row in dtTop.Rows)
                    {
                        int unidades = row.Field<int>("CantidadVendida");
                        // Aquí el porcentaje se calcula sobre las unidades vendidas (para el gráfico circular y la tabla)
                        double porcentaje = totalUnidadesVendidas > 0 ? (unidades / totalUnidadesVendidas) * 100 : 0;

                        row["Contribucion (%)"] = $"{porcentaje:N1} %";

                        serieProductos.Points.AddXY(row["Producto"], unidades);
                    }
                    dgvTopProductos.Columns["Contribucion (%)"].HeaderText = "Contribución (%)";


                    chartVentasPorProducto.Series.Clear();
                    chartVentasPorProducto.Series.Add(serieProductos);
                    ConfigurarGraficoTYV(chartVentasPorProducto, "Top Productos Vendidos", "#7A9E7E");
                    AnimarGrafico(chartVentasPorProducto);

                    // --- Efecto de luz en los paneles KPI ---
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

        }
    }
}