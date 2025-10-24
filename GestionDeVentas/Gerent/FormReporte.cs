using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Datos;
using Modelos;
using GestionDeVentas.Vendedor;
using System.Globalization;

namespace GestionDeVentas.Gerente
{
    public partial class FormReportesGerente : Form
    {
        private readonly FacturaDatos _facturaDatos = new FacturaDatos();
        private List<Factura> _todasLasFacturas;
        private bool _datosCargadosCorrectamente = false;

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
                // ✅ CORRECCIÓN 1: Llamar a Reset en lugar de a Buscar para la carga inicial.
                btnReset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFiltros()
        {
            var clientes = new List<string> { "Todos" }
                .Union(_todasLasFacturas.Select(f => f.ClienteNombre).Distinct())
                .OrderBy(c => c == "Todos" ? " " : c)
                .ToList();
            cmbCliente.DataSource = clientes;

            var vendedores = new List<string> { "Todos" }
                .Union(_todasLasFacturas.Select(f => f.UsuarioNombre).Distinct())
                .OrderBy(v => v == "Todos" ? " " : v)
                .ToList();
            cmbVendedor.DataSource = vendedores;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!_datosCargadosCorrectamente) return;

            // ✅ CORRECCIÓN 2: Lógica de búsqueda separada.
            // Si se busca por N° de Factura, es una búsqueda exclusiva.
            if (!string.IsNullOrWhiteSpace(txtNroFactura.Text))
            {
                if (int.TryParse(txtNroFactura.Text, out int nroFactura))
                {
                    var resultado = _todasLasFacturas.Where(f => f.IdFactura == nroFactura).ToList();
                    MostrarFacturas(resultado);
                }
                else
                {
                    MessageBox.Show("El número de factura debe ser un valor numérico.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return; // Termina aquí si se buscó por número de factura.
            }

            // Si no se busca por N° de Factura, se aplican los otros filtros.
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IEnumerable<Factura> resultados = _todasLasFacturas;

            resultados = resultados.Where(f => f.FechaFactura.Date >= dtpDesde.Value.Date && f.FechaFactura.Date <= dtpHasta.Value.Date);

            if (cmbVendedor.SelectedItem?.ToString() != "Todos")
            {
                resultados = resultados.Where(f => f.UsuarioNombre == cmbVendedor.SelectedItem.ToString());
            }

            if (cmbCliente.SelectedItem?.ToString() != "Todos")
            {
                resultados = resultados.Where(f => f.ClienteNombre == cmbCliente.SelectedItem.ToString());
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
            cmbCliente.SelectedIndex = 0;
            cmbVendedor.SelectedIndex = 0;
            txtNroFactura.Clear();
            dtpDesde.Value = DateTime.Today.AddMonths(-1); // Rango de un mes por defecto
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
            MessageBox.Show("La función de exportación a PDF se ejecutó con éxito. (Simulación)", "Exportación PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("La función de exportación a Excel se ejecutó con éxito. (Simulación)", "Exportación Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}