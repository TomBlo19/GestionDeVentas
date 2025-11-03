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
using ClosedXML.Excel;
using System.IO;

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

        // Se elimina 'private Panel panelSuperior;'

        public FormReportesGerente()
        {
            InitializeComponent();
            // ❌ IMPORTANTE: Eliminamos la vinculación manual aquí. El Designer se encarga.
        }

        private void FormReportesGerente_Load(object sender, EventArgs e)
        {
            try
            {
                _todasLasFacturas = _facturaDatos.ObtenerTodasLasFacturasConDetalles();
                _datosCargadosCorrectamente = true;

                CargarFiltros();
                AplicarEstiloTYV();
                btnReset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFiltros()
        {
            var vendedores = new List<string> { "Todos" }
                .Union(_todasLasFacturas.Select(f => f.UsuarioNombre).Distinct())
                .OrderBy(v => v == "Todos" ? " " : v)
                .ToList();
            cmbVendedor.DataSource = vendedores;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_datosCargadosCorrectamente) return;

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
                return;
            }

            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IEnumerable<Factura> resultados = _todasLasFacturas
                .Where(f => f.FechaFactura.Date >= dtpDesde.Value.Date && f.FechaFactura.Date <= dtpHasta.Value.Date);

            if (cmbVendedor.SelectedItem?.ToString() != "Todos")
                resultados = resultados.Where(f => f.UsuarioNombre == cmbVendedor.SelectedItem.ToString());

            if (!string.IsNullOrWhiteSpace(txtDniCliente.Text))
            {
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

            txtDniCliente.Clear();
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

        // Implementación de Exportar a Excel con ClosedXML (real)
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Archivo Excel|*.xlsx",
                    FileName = $"Reporte_Facturas_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                })
                {
                    // Solo procedemos si el usuario hace clic en Aceptar en el primer cuadro de diálogo.
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Facturas");

                            // 1. Título
                            ws.Cell(1, 1).Value = "Reporte de Facturas - TYV WEAR";
                            ws.Range("A1:F1").Merge().Style.Fill.BackgroundColor = XLColor.FromHtml("#3E2723");
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 14;
                            ws.Cell(1, 1).Style.Font.FontColor = XLColor.White;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // 2. Encabezados
                            int headerRow = 3;
                            int currentColumn = 1;
                            for (int i = 0; i < dgvFacturas.Columns.Count; i++)
                            {
                                // Ignorar la columna "Ver Detalle"
                                if (dgvFacturas.Columns[i].Name == "colVerDetalle") continue;

                                ws.Cell(headerRow, currentColumn).Value = dgvFacturas.Columns[i].HeaderText;
                                ws.Cell(headerRow, currentColumn).Style.Fill.BackgroundColor = XLColor.FromHtml("#C19A6B");
                                ws.Cell(headerRow, currentColumn).Style.Font.Bold = true;
                                ws.Cell(headerRow, currentColumn).Style.Font.FontColor = XLColor.White;
                                currentColumn++;
                            }

                            // 3. Datos de la tabla
                            int contentRow = headerRow + 1;
                            foreach (DataGridViewRow dgvRow in dgvFacturas.Rows)
                            {
                                currentColumn = 1;
                                for (int i = 0; i < dgvFacturas.Columns.Count; i++)
                                {
                                    // Ignorar la columna "Ver Detalle"
                                    if (dgvFacturas.Columns[i].Name == "colVerDetalle") continue;

                                    var cellValue = dgvRow.Cells[i].Value?.ToString();

                                    // Formato especial para el Total (colTotal es la columna 6, índice 5)
                                    if (i == 5 && decimal.TryParse(cellValue.Replace("$", "").Replace("€", "").Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator, "").Replace(" ", ""), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal totalValue))
                                    {
                                        ws.Cell(contentRow, currentColumn).Value = totalValue;
                                        ws.Cell(contentRow, currentColumn).Style.NumberFormat.Format = "$ #,##0.00";
                                    }
                                    else
                                    {
                                        ws.Cell(contentRow, currentColumn).Value = cellValue;
                                    }

                                    currentColumn++;
                                }
                                contentRow++;
                            }

                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }

                        // Este es el cartel de éxito que quieres ver una sola vez.
                        MessageBox.Show("Reporte exportado a Excel correctamente.", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 💅 Estilo visual TYV
        private void AplicarEstiloTYV()
        {
            this.BackColor = colorFondoPrincipal;
            this.FormBorderStyle = FormBorderStyle.None;

            // Header (panelHeader)
            panelHeader.BackColor = colorMarronOscuro;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            btnCerrar.BackColor = colorMarronOscuro;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.MouseEnter += (s, e) => btnCerrar.BackColor = colorCamel;
            btnCerrar.MouseLeave += (s, e) => btnCerrar.BackColor = colorMarronOscuro;

            // Labels de filtro
            foreach (var lbl in new[] { lblFechaDesde, lblFechaHasta, lblCliente, lblVendedor, lblNroFactura })
            {
                lbl.ForeColor = colorMarronOscuro;
                lbl.Font = new Font("Segoe UI Semibold", 9);
            }

            // Textboxes y ComboBox
            foreach (var ctrl in new Control[] { txtDniCliente, cmbVendedor, txtNroFactura })
            {
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = colorMarronOscuro;
                ctrl.Font = new Font("Segoe UI", 9);
            }

            // DateTimePickers
            foreach (var dtp in new[] { dtpDesde, dtpHasta })
            {
                dtp.CalendarMonthBackground = colorBeigeClaro;
                dtp.Font = new Font("Segoe UI", 9);
                dtp.CalendarForeColor = colorMarronOscuro;
            }

            // Botones de Acción (incluyendo el nuevo de Exportar)
            foreach (var boton in new[] { btnBuscar, btnReset, btnExportarExcel })
            {
                boton.FlatStyle = FlatStyle.Flat;
                boton.FlatAppearance.BorderSize = 0;
                boton.ForeColor = Color.White;
                boton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                boton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, boton.Width, boton.Height, 10, 10));
                boton.Cursor = Cursors.Hand;
            }

            btnBuscar.BackColor = colorCamel;
            btnReset.BackColor = colorVerdeOliva;
            btnExportarExcel.BackColor = colorMarronOscuro;

            // DataGridView
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
            dgvFacturas.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            lblResultados.ForeColor = ColorTranslator.FromHtml("#5E4A3B");
            lblResultados.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblResultados.TextAlign = ContentAlignment.MiddleRight;
        }

        // Se elimina CrearEncabezadoConDegradado y PanelSuperior_Paint
    }
}