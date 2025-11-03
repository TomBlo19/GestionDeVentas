using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
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
            // 🔸 Configuración inicial de tabla e interfaz
            //------------------------------------------------------
            if (dgvHistorial.Columns.Count == 0)
            {
                dgvHistorial.Columns.Add("colFecha", "Fecha");
                dgvHistorial.Columns.Add("colModulo", "Módulo");
                dgvHistorial.Columns.Add("colDetalle", "Detalle");
                dgvHistorial.Columns.Add("colTipo", "Movimiento");
                dgvHistorial.Columns.Add("colCantidad", "Cantidad");
                dgvHistorial.Columns.Add("colDescripcion", "Usuario / Descripción");

                dgvHistorial.EnableHeadersVisualStyles = false;
                dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 64, 0);
                dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 245, 240);
                dgvHistorial.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            }

            InicializarFiltros();
            CargarDatos();
        }

        //------------------------------------------------------
        // 🔸 MÉTODO: Inicializar filtros de fecha y movimiento
        //------------------------------------------------------
        private void InicializarFiltros()
        {
            try
            {
                dtpDesde.Value = DateTime.Today.AddMonths(-1);
                dtpHasta.Value = DateTime.Today;

                cmbMovimiento.Items.Clear();
                cmbMovimiento.Items.AddRange(new object[]
                {
                    "Todos", "Venta", "Entrada", "Ajuste", "Alta", "Baja", "Modificación", "Activación", "Inactivación"
                });

                cmbMovimiento.SelectedIndex = 0;
            }
            catch
            {
                // si el combo aún no está inicializado, no genera error
            }
        }

        //------------------------------------------------------
        // 🔸 CARGAR DATOS COMPLETOS DEL PANEL
        //------------------------------------------------------
        private void CargarDatos()
        {
            try
            {
                //------------------------------------------------------
                // 1️⃣ PANEL ALERTAS DE STOCK BAJO
                //------------------------------------------------------
                var alertas = _reporteDatos.ObtenerProductosBajoStock();
                panelAlertas.Controls.Clear();
                panelAlertas.Controls.Add(lblTituloAlertas);

                PictureBox iconoAlerta = new PictureBox
                {
                    Image = Properties.Resources.warning_icon,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(15, 55),
                    Size = new Size(32, 32),
                    BackColor = Color.Transparent
                };

                Label lblDescripcion = new Label
                {
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(91, 58, 41),
                    Location = new Point(55, 60),
                    AutoSize = true,
                    Text = "Productos con stock bajo:"
                };

                Panel panelListado = new Panel
                {
                    AutoScroll = true,
                    Location = new Point(15, 90),
                    Size = new Size(310, 110),
                    BackColor = Color.Transparent,
                    Name = "panelListadoAlertas"
                };

                if (!alertas.Any())
                {
                    Label lblOK = new Label
                    {
                        Text = "✅ No hay productos con stock bajo.",
                        Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                        ForeColor = Color.FromArgb(70, 45, 35),
                        AutoSize = true,
                        Location = new Point(5, 10)
                    };
                    panelListado.Controls.Add(lblOK);
                }
                else
                {
                    int y = 5;
                    foreach (var a in alertas)
                    {
                        Label lblProd = new Label
                        {
                            Text = $"• {a.Nombre} (Stock: {a.Stock}/{a.StockMinimo})",
                            Font = new Font("Segoe UI", 10F),
                            ForeColor = a.Stock == 0 ? Color.FromArgb(160, 60, 45) : Color.FromArgb(91, 58, 41),
                            AutoSize = true,
                            Location = new Point(5, y)
                        };
                        y += 25;
                        panelListado.Controls.Add(lblProd);
                    }
                }

                panelAlertas.Controls.Add(iconoAlerta);
                panelAlertas.Controls.Add(lblDescripcion);
                panelAlertas.Controls.Add(panelListado);

                //------------------------------------------------------
                // 2️⃣ HISTORIAL DE MOVIMIENTOS
                //------------------------------------------------------
                dgvHistorial.Rows.Clear();
                var movs = _reporteDatos.ObtenerHistorialMovimientos();

                var desde = dtpDesde.Value.Date;
                var hasta = dtpHasta.Value.Date.AddDays(1);
                var tipo = cmbMovimiento.SelectedItem?.ToString() ?? "Todos";

                var filtrados = movs.Where(m =>
                    m.Fecha >= desde &&
                    m.Fecha < hasta &&
                    (tipo == "Todos" || m.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase)));

                foreach (var m in filtrados)
                {
                    dgvHistorial.Rows.Add(
                        m.Fecha.ToShortDateString(),
                        m.Modulo,
                        m.Detalle,
                        m.Tipo,
                        m.Cantidad?.ToString() ?? "-",
                        m.Descripcion
                    );
                }

                //------------------------------------------------------
                // 3️⃣ ACTIVIDAD RECIENTE
                //------------------------------------------------------
                var hoy = DateTime.Today;
                var movimientosHoy = movs.Where(m => m.Fecha.Date == hoy);

                lblMovimientosDia.Text = $"• Movimientos del día: {movimientosHoy.Count()}";
                lblAltasNuevas.Text = $"• Altas nuevas: {movimientosHoy.Count(m => m.Tipo.Equals("Alta", StringComparison.OrdinalIgnoreCase))}";
                lblModificaciones.Text = $"• Modificaciones: {movimientosHoy.Count(m => m.Tipo.Equals("Modificación", StringComparison.OrdinalIgnoreCase))}";
                lblInactivaciones.Text = $"• Inactivaciones: {movimientosHoy.Count(m => m.Tipo.Equals("Inactivación", StringComparison.OrdinalIgnoreCase))}";

                //------------------------------------------------------
                // 4️⃣ ESTADO DEL INVENTARIO
                //------------------------------------------------------
                var productos = _reporteDatos.ObtenerTodosLosProductos();

                lblActivos.Text = $"• Productos activos: {productos.Count(p => p.Estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))}";
                lblInactivos.Text = $"• Productos inactivos: {productos.Count(p => p.Estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))}";
                lblStockBajo.Text = $"• Con stock bajo: {productos.Count(p => p.Stock <= p.StockMinimo && p.Stock > 0)}";
                lblSinStock.Text = $"• Sin stock: {productos.Count(p => p.Stock == 0)}";

                //------------------------------------------------------
                // 5️⃣ ACTUALIZACIÓN Y EFECTO VISUAL
                //------------------------------------------------------
                lblUltimaActualizacion.Text = $"Última actualización: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                IniciarAnimacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //------------------------------------------------------
        // 🔸 BOTONES
        //------------------------------------------------------
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            InicializarFiltros();
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------------
        // 🔸 EFECTO VISUAL ANIMADO
        //------------------------------------------------------
        private void IniciarAnimacion()
        {
            panelActividad.BackColor = Color.FromArgb(255, 245, 230);
            timerAnimacion.Start();
        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            int r = panelActividad.BackColor.R;
            int g = panelActividad.BackColor.G;
            int b = panelActividad.BackColor.B;

            if (g < 244) g += 3;
            if (b < 239) b += 3;
            if (r > 248) r -= 2;

            panelActividad.BackColor = Color.FromArgb(
                Math.Min(r, 248),
                Math.Min(g, 244),
                Math.Min(b, 239)
            );

            if (panelActividad.BackColor == Color.FromArgb(248, 244, 239))
                timerAnimacion.Stop();
        }

        private void lblInactivos_Click(object sender, EventArgs e)
        {

        }
    }
}
