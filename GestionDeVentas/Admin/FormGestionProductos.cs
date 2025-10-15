using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Datos;

namespace GestionDeVentas.Admin
{
    public partial class FormReportes : Form
    {
        private readonly ReporteDatos _reporteDatos = new ReporteDatos();

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // ✅ Inicializar combo si no se hizo en el diseñador
            if (cmbMovimiento.Items.Count == 0)
            {
                cmbMovimiento.Items.AddRange(new object[] { "Todos", "Entrada", "Venta", "Ajuste" });
            }

            // ✅ Evita el null en la primera carga
            cmbMovimiento.SelectedIndex = 0;

            // ✅ Inicializar fechas
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;

            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                //------------------------------------------------------
                // 🔸 Alertas de Stock
                //------------------------------------------------------
                var alertas = _reporteDatos.ObtenerProductosBajoStock();

                lblAlertasStock.Text = alertas.Any()
                    ? "⚠️ Productos con stock bajo:\n\n" + string.Join("\n",
                        alertas.Select(a => $"- {a.Nombre} (Stock: {a.Stock}/{a.StockMinimo})"))
                    : "✅ No hay productos con stock bajo.";

                //------------------------------------------------------
                // 🔸 Historial filtrado
                //------------------------------------------------------
                dgvHistorial.Rows.Clear();
                var movs = _reporteDatos.ObtenerHistorialMovimientos();

                var desde = dtpDesde.Value.Date;
                var hasta = dtpHasta.Value.Date.AddDays(1);

                // ⚙️ Evita NullReferenceException
                string tipo = (cmbMovimiento.SelectedItem != null)
                    ? cmbMovimiento.SelectedItem.ToString()
                    : "Todos";

                var filtrados = movs.Where(m =>
                    m.Fecha >= desde &&
                    m.Fecha < hasta &&
                    (tipo == "Todos" || m.TipoMovimiento == tipo));

                foreach (var m in filtrados)
                    dgvHistorial.Rows.Add(
                        m.Fecha.ToShortDateString(),
                        m.ProductoNombre,
                        m.TipoMovimiento,
                        m.Cantidad
                    );

                //------------------------------------------------------
                // 🔸 Gráfico de Ventas Mejorado
                //------------------------------------------------------
                var top = _reporteDatos.ObtenerProductosMasVendidos();
                chartVentas.Series.Clear();

                var serie = new Series("Top Ventas")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.FromArgb(128, 64, 0),
                    IsValueShownAsLabel = true
                };

                // Efecto visual tipo cilindro + sombra
                serie["DrawingStyle"] = "Cylinder";
                serie.ShadowOffset = 3;

                foreach (var item in top)
                    serie.Points.AddXY(item.Producto, item.Ventas);

                chartVentas.Series.Add(serie);

                // Ejes y estilo
                var area = chartVentas.ChartAreas[0];
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9);
                area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9);
                area.BackColor = System.Drawing.Color.FromArgb(245, 240, 230);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
