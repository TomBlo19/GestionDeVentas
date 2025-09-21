using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    // Asegúrate de que esta sea la primera clase en el archivo para que el diseñador de Visual Studio funcione correctamente.
    public partial class FormReportesGerente : Form
    {
        // 🔹 Clases de datos de ejemplo para simular la información de una base de datos.
        public class Factura
        {
            public string NroFactura { get; set; }
            public DateTime Fecha { get; set; }
            public string Cliente { get; set; }
            public string Vendedor { get; set; }
            public string MetodoPago { get; set; }
            public decimal Total { get; set; }
            public List<ProductoFactura> Productos { get; set; } = new List<ProductoFactura>();
        }

        public class ProductoFactura
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Talle { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public decimal Subtotal => Cantidad * Precio;
        }

        private List<Factura> facturasFicticias = new List<Factura>();

        public FormReportesGerente()
        {
            InitializeComponent();
            CargarDatosFicticios();
        }

        // 🔹 Función para crear los datos de ejemplo
        private void CargarDatosFicticios()
        {
            facturasFicticias.Add(new Factura
            {
                NroFactura = "000001",
                Fecha = new DateTime(2025, 09, 10),
                Cliente = "Valentina Barbero",
                Vendedor = "Tomás Bolo",
                MetodoPago = "Efectivo",
                Total = 1200.00m,
                Productos = new List<ProductoFactura>
                {
                    new ProductoFactura { Codigo = "A123", Nombre = "Camiseta Básica", Talle = "M", Cantidad = 2, Precio = 500.00m },
                    new ProductoFactura { Codigo = "B456", Nombre = "Jeans Slim Fit", Talle = "32", Cantidad = 1, Precio = 200.00m }
                }
            });

            facturasFicticias.Add(new Factura
            {
                NroFactura = "000002",
                Fecha = new DateTime(2025, 09, 12),
                Cliente = "Juan Pérez",
                Vendedor = "Valentina Asselborn",
                MetodoPago = "Tarjeta",
                Total = 2400.00m,
                Productos = new List<ProductoFactura>
                {
                    new ProductoFactura { Codigo = "C789", Nombre = "Sudadera con Capucha", Talle = "L", Cantidad = 1, Precio = 1200.00m },
                    new ProductoFactura { Codigo = "D012", Nombre = "Zapatillas Deportivas", Talle = "40", Cantidad = 1, Precio = 1200.00m }
                }
            });

            facturasFicticias.Add(new Factura
            {
                NroFactura = "000003",
                Fecha = new DateTime(2025, 09, 13),
                Cliente = "Ana Torres",
                Vendedor = "Juan Gómez",
                MetodoPago = "Transferencia",
                Total = 1800.00m,
                Productos = new List<ProductoFactura>
                {
                    new ProductoFactura { Codigo = "E345", Nombre = "Vestido Verano", Talle = "S", Cantidad = 1, Precio = 1800.00m }
                }
            });
        }

        private void FormReportesGerente_Load(object sender, EventArgs e)
        {
            // Inicializar combos con los nombres de los datos ficticios
            var clientes = new List<string> { "Todos" }.Union(facturasFicticias.Select(f => f.Cliente).Distinct()).OrderBy(c => c).ToList();
            cmbCliente.DataSource = clientes;

            var vendedores = new List<string> { "Todos" }.Union(facturasFicticias.Select(f => f.Vendedor).Distinct()).OrderBy(v => v).ToList();
            cmbVendedor.DataSource = vendedores;

            var metodosPago = new List<string> { "Todos" }.Union(facturasFicticias.Select(f => f.MetodoPago).Distinct()).OrderBy(m => m).ToList();
            cmbMetodoPago.DataSource = metodosPago;

            // Cargar los datos iniciales en el DataGridView
            MostrarFacturas(facturasFicticias);
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultados = facturasFicticias.AsQueryable();

            // Filtrar por fechas
            resultados = resultados.Where(f => f.Fecha.Date >= dtpDesde.Value.Date && f.Fecha.Date <= dtpHasta.Value.Date);

            // Filtrar por vendedor
            if (cmbVendedor.SelectedItem.ToString() != "Todos")
            {
                resultados = resultados.Where(f => f.Vendedor == cmbVendedor.SelectedItem.ToString());
            }

            // Filtrar por cliente
            if (cmbCliente.SelectedItem.ToString() != "Todos")
            {
                resultados = resultados.Where(f => f.Cliente == cmbCliente.SelectedItem.ToString());
            }

            // Filtrar por método de pago
            if (cmbMetodoPago.SelectedItem.ToString() != "Todos")
            {
                resultados = resultados.Where(f => f.MetodoPago == cmbMetodoPago.SelectedItem.ToString());
            }

            MostrarFacturas(resultados.ToList());
        }

        private void MostrarFacturas(List<Factura> facturas)
        {
            dgvFacturas.Rows.Clear();
            foreach (var factura in facturas)
            {
                dgvFacturas.Rows.Add(factura.NroFactura, factura.Fecha.ToShortDateString(), factura.Cliente, factura.Vendedor, factura.MetodoPago, $"${factura.Total:N2}");
            }
            lblResultados.Text = $"{dgvFacturas.Rows.Count} facturas encontradas";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = 0;
            cmbVendedor.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            MostrarFacturas(facturasFicticias);
        }

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

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvFacturas.Columns[e.ColumnIndex].Name == "colVerDetalle")
            {
                var nroFacturaSeleccionada = dgvFacturas.Rows[e.RowIndex].Cells["colNroFactura"].Value.ToString();
                var facturaSeleccionada = facturasFicticias.FirstOrDefault(f => f.NroFactura == nroFacturaSeleccionada);

                if (facturaSeleccionada != null)
                {
                    FormDetalleFacturaGerente frmDetalle = new FormDetalleFacturaGerente(facturaSeleccionada);
                    frmDetalle.ShowDialog();
                }
            }
        }
    }
}