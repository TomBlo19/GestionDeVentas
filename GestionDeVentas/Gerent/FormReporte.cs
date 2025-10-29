using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Datos;
using Modelos;
using GestionDeVentas.Vendedor;
using System.Globalization;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GestionDeVentas.Gerente
{
    public partial class FormReportesGerente : Form
    {
        private readonly FacturaDatos _facturaDatos = new FacturaDatos();
        private List<Factura> _todasLasFacturas;
        private bool _datosCargadosCorrectamente = false;

        // 🎨 Paleta TYV aesthetic
        private readonly Color colorFondoPrincipal = ColorTranslator.FromHtml("#F5E6CC");
        private readonly Color colorMarronOscuro = ColorTranslator.FromHtml("#3E2723");
        private readonly Color colorBeigeClaro = ColorTranslator.FromHtml("#EBD3B3");
        private readonly Color colorCamel = ColorTranslator.FromHtml("#C19A6B");
        private readonly Color colorVerdeOliva = ColorTranslator.FromHtml("#7A9E7E");
        private readonly Color colorBorde = ColorTranslator.FromHtml("#DCC4A3");

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private Panel panelSuperior;

        public FormReportesGerente()
        {
            InitializeComponent();
        }

        private void FormReportesGerente_Load(object sender, EventArgs e)
        {
            try
            {
                _todasLasFacturas = _facturaDatos.ObtenerTodasLasFacturasConDetalles();
                _datosCargadosCorrectamente = true;

                CargarFiltros();
                btnReset_Click(null, null);
                AplicarEstiloTYV(); // 💅 Aplica estilo visual TYV
                CrearEncabezadoConDegradado(); // 🌄 Franja superior estética
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFiltros()
        {
            // ✨ CAMBIO: Se elimina la carga del ComboBox de clientes.
            // Ahora solo cargamos el de vendedores.
            var vendedores = new List<string> { "Todos" }
                .Union(_todasLasFacturas.Select(f => f.UsuarioNombre).Distinct())
                .OrderBy(v => v == "Todos" ? " " : v)
                .ToList();
            cmbVendedor.DataSource = vendedores;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_datosCargadosCorrectamente) return;

            // 🔧 CORRECCIÓN: Búsqueda prioritaria por N° de Factura. Se añade Trim() para robustez.
            if (!string.IsNullOrWhiteSpace(txtNroFactura.Text))
            {
                if (int.TryParse(txtNroFactura.Text.Trim(), out int nroFactura))
                {
                    var resultado = _todasLasFacturas.Where(f => f.IdFactura == nroFactura).ToList();
                    MostrarFacturas(resultado);
                }
                else
                {
                    MessageBox.Show("El número de factura debe ser numérico.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return; // Importante salir para no aplicar los otros filtros
            }

            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inicia el filtrado con todas las facturas
            IEnumerable<Factura> resultados = _todasLasFacturas
                .Where(f => f.FechaFactura.Date >= dtpDesde.Value.Date && f.FechaFactura.Date <= dtpHasta.Value.Date);

            // Aplica filtro por Vendedor si se seleccionó uno
            if (cmbVendedor.SelectedItem?.ToString() != "Todos")
                resultados = resultados.Where(f => f.UsuarioNombre == cmbVendedor.SelectedItem.ToString());

            // ✨ CAMBIO: Aplicar filtro por DNI del cliente si el campo no está vacío
            if (!string.IsNullOrWhiteSpace(txtDniCliente.Text))
            {
                // Usamos Contains para una búsqueda más flexible (ej: buscar '123' y que encuentre '...123...')
                resultados = resultados.Where(f => f.ClienteDni != null && f.ClienteDni.Contains(txtDniCliente.Text.Trim()));
            }

            MostrarFacturas(resultados.ToList());
        }


        private void MostrarFacturas(List<Factura> facturas)
        {
            dgvFacturas.Rows.Clear();
            if (facturas == null) return;

            foreach (var factura in facturas)
            {
                dgvFacturas.Rows.Add(
                    factura.IdFactura.ToString("D6"),
                    factura.FechaFactura.ToShortDateString(),
                    factura.ClienteNombre,
                    factura.UsuarioNombre,
                    factura.MetodoPagoNombre,
                    factura.TotalFactura.ToString("C", CultureInfo.CurrentCulture)
                );
            }
            lblResultados.Text = $"{dgvFacturas.Rows.Count} facturas encontradas";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!_datosCargadosCorrectamente) return;

            txtDniCliente.Clear(); // ✨ CAMBIO: Limpiamos el textbox de DNI
            cmbVendedor.SelectedIndex = 0;
            txtNroFactura.Clear();
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            MostrarFacturas(_todasLasFacturas);
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvFacturas.Columns[e.ColumnIndex].Name == "colVerDetalle")
            {
                var nroFacturaStr = dgvFacturas.Rows[e.RowIndex].Cells["colNroFactura"].Value.ToString();
                if (int.TryParse(nroFacturaStr, out int nroFacturaSeleccionada))
                {
                    var facturaSeleccionada = _todasLasFacturas.FirstOrDefault(f => f.IdFactura == nroFacturaSeleccionada);
                    if (facturaSeleccionada != null)
                    {
                        FormVisualizarFactura frmDetalle = new FormVisualizarFactura(facturaSeleccionada);
                        frmDetalle.ShowDialog();
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Exportación PDF completada (simulada).", "Exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Exportación Excel completada (simulada).", "Exportar Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 💅 Estilo visual TYV
        private void AplicarEstiloTYV()
        {
            this.BackColor = colorFondoPrincipal;
            this.FormBorderStyle = FormBorderStyle.None;

            lblTitulo.ForeColor = colorMarronOscuro;
            lblTitulo.Font = new Font("Poppins", 18, FontStyle.Bold);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            btnCerrar.BackColor = colorMarronOscuro;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.MouseEnter += (s, e) => btnCerrar.BackColor = colorCamel;
            btnCerrar.MouseLeave += (s, e) => btnCerrar.BackColor = colorMarronOscuro;

            foreach (var lbl in new[] { lblFechaDesde, lblFechaHasta, lblCliente, lblVendedor, lblNroFactura })
            {
                lbl.ForeColor = colorMarronOscuro;
                lbl.Font = new Font("Segoe UI Semibold", 9);
            }

            // ✨ CAMBIO: Se actualiza el array de controles para aplicar estilo
            foreach (var ctrl in new Control[] { txtDniCliente, cmbVendedor, txtNroFactura })
            {
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = colorMarronOscuro;
                ctrl.Font = new Font("Segoe UI", 9);
            }

            foreach (var dtp in new[] { dtpDesde, dtpHasta })
            {
                dtp.CalendarMonthBackground = colorBeigeClaro;
                dtp.Font = new Font("Segoe UI", 9);
                dtp.CalendarForeColor = colorMarronOscuro;
            }

            foreach (var boton in new[] { btnBuscar, btnReset })
            {
                boton.FlatStyle = FlatStyle.Flat;
                boton.FlatAppearance.BorderSize = 0;
                boton.ForeColor = Color.White;
                boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                boton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, boton.Width, boton.Height, 10, 10));
                boton.Cursor = Cursors.Hand;
            }

            btnBuscar.BackColor = colorCamel;
            btnReset.BackColor = colorVerdeOliva;
           

            dgvFacturas.BackgroundColor = ColorTranslator.FromHtml("#FDF8F2");
            dgvFacturas.BorderStyle = BorderStyle.None;
            dgvFacturas.EnableHeadersVisualStyles = false;
            dgvFacturas.ColumnHeadersDefaultCellStyle.BackColor = colorCamel;
            dgvFacturas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            dgvFacturas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFacturas.ColumnHeadersHeight = 35;
            dgvFacturas.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF9F0");
            dgvFacturas.AlternatingRowsDefaultCellStyle.BackColor = colorBeigeClaro;
            dgvFacturas.DefaultCellStyle.ForeColor = colorMarronOscuro;
            dgvFacturas.DefaultCellStyle.SelectionBackColor = colorVerdeOliva;
            dgvFacturas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFacturas.GridColor = colorBorde;
            dgvFacturas.RowTemplate.Height = 28;
            dgvFacturas.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            lblResultados.ForeColor = ColorTranslator.FromHtml("#5E4A3B");
            lblResultados.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblResultados.TextAlign = ContentAlignment.MiddleRight;
        }

        // 🟤 Franja superior con degradado sin sombra
        private void CrearEncabezadoConDegradado()
        {
            panelSuperior = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.Transparent
            };
            panelSuperior.Paint += PanelSuperior_Paint;
            this.Controls.Add(panelSuperior);
            panelSuperior.BringToFront();

            btnCerrar.Parent = panelSuperior;
            btnCerrar.Location = new Point(panelSuperior.Width - btnCerrar.Width - 10, 15);
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblTitulo.Parent = panelSuperior;
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Poppins", 18, FontStyle.Bold);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != panelSuperior)
                    ctrl.Top += panelSuperior.Height - 10;
            }
        }

        private void PanelSuperior_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = panelSuperior.ClientRectangle;
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect,
                ColorTranslator.FromHtml("#C19A6B"),
                ColorTranslator.FromHtml("#3E2723"),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }
    }
}