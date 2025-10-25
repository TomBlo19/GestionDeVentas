using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Datos;

namespace GestionDeVentas.Admin
{
    public partial class FormGestionProductos : Form
    {
        private readonly ReporteDatos _reporteDatos = new ReporteDatos();

        public FormGestionProductos()
        {
            InitializeComponent();
        }

        private void FormGestionProductos_Load(object sender, EventArgs e)
        {
            //------------------------------------------------------
            // 🔸 Definir columnas si no existen (evita error de filas sin columnas)
            //------------------------------------------------------
            if (dgvHistorial.Columns.Count == 0)
            {
                dgvHistorial.Columns.Add("colFecha", "Fecha");
                dgvHistorial.Columns.Add("colProducto", "Producto");
                dgvHistorial.Columns.Add("colTipo", "Movimiento");
                dgvHistorial.Columns.Add("colCantidad", "Cantidad");

                // Estilo camel/cacao visual
                dgvHistorial.EnableHeadersVisualStyles = false;
                dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);
                dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 245, 240);
                dgvHistorial.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9);
            }

            //------------------------------------------------------
            // 🔸 Inicializar filtros y combos
            //------------------------------------------------------
            if (cmbMovimiento.Items.Count == 0)
                cmbMovimiento.Items.AddRange(new object[] { "Todos", "Entrada", "Venta", "Ajuste" });

            cmbMovimiento.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;

            //------------------------------------------------------
            // 🔸 Cargar datos
            //------------------------------------------------------
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                //------------------------------------------------------
                // 1️⃣ Alertas de Stock Bajo
                //------------------------------------------------------
                var alertas = _reporteDatos.ObtenerProductosBajoStock();

                lblAlertasStock.Text = alertas.Any()
                    ? "⚠️ Productos con stock bajo:\n\n" + string.Join("\n",
                        alertas.Select(a => $"- {a.Nombre} (Stock: {a.Stock}/{a.StockMinimo})"))
                    : "✅ No hay productos con stock bajo.";

                //------------------------------------------------------
                // 2️⃣ Historial de Movimientos
                //------------------------------------------------------
                dgvHistorial.Rows.Clear();
                var movs = _reporteDatos.ObtenerHistorialMovimientos();

                var desde = dtpDesde.Value.Date;
                var hasta = dtpHasta.Value.Date.AddDays(1);
                string tipo = cmbMovimiento.SelectedItem?.ToString() ?? "Todos";

                var filtrados = movs.Where(m =>
                    m.Fecha >= desde &&
                    m.Fecha < hasta &&
                    (tipo == "Todos" || m.TipoMovimiento.Equals(tipo, StringComparison.OrdinalIgnoreCase)));

                foreach (var m in filtrados)
                {
                    dgvHistorial.Rows.Add(
                        m.Fecha.ToShortDateString(),
                        m.ProductoNombre,
                        m.TipoMovimiento,
                        m.Cantidad
                    );
                }

                //------------------------------------------------------
                // 3️⃣ Gráfico de Productos Más Vendidos
                //------------------------------------------------------
                chartVentas.Series.Clear();
                chartVentas.Titles.Clear();
                var top = _reporteDatos.ObtenerProductosMasVendidos();

                if (top == null || !top.Any())
                {
                    chartVentas.Titles.Add("Sin datos de ventas registradas");
                    return;
                }

                var serie = new Series("Top Ventas")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.FromArgb(128, 64, 0),
                    IsValueShownAsLabel = true
                };
                serie["DrawingStyle"] = "Cylinder";
                serie.ShadowOffset = 3;

                foreach (var item in top)
                    serie.Points.AddXY(item.Producto, item.Ventas);

                chartVentas.Series.Add(serie);

                var area = chartVentas.ChartAreas[0];
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9);
                area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9);
                area.AxisX.LabelStyle.Angle = -45;
                area.AxisX.Interval = 1;
                area.BackColor = System.Drawing.Color.FromArgb(245, 240, 230);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
