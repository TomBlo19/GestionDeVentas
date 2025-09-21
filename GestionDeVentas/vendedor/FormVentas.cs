using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GestionDeVentas.Vendedor
{
    public partial class FormVentas : Form
    {
        private List<Factura> facturas = new List<Factura>();

        public FormVentas()
        {
            InitializeComponent();
            // Desactivar el ControlBox completo para evitar los botones de minimizar/maximizar
            this.ControlBox = false;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarDatosDePrueba();
            ActualizarTablaVentas();
            SetPlaceholder(txtBuscarCliente, "Nombre o DNI del cliente");
            SetPlaceholder(txtBuscarNroFactura, "Número de factura");
        }

        private void CargarDatosDePrueba()
        {
            // (El mismo código de carga de datos de prueba que ya teníamos)
            var factura1 = new Factura
            {
                NroFactura = 12,
                Fecha = new DateTime(2023, 10, 25),
                Vendedor = "Martín Giménez",
                Cliente = "Juan Pérez",
                DniCliente = "30-12345678-9",
                DireccionCliente = "Av. Siempre Viva 742",
                ContactoCliente = "juan.perez@email.com",
                MetodoPago = "Efectivo",
                MontoEntregado = 100.00m,
                Detalles = new List<DetalleFactura>
                {
                    new DetalleFactura { Codigo = "A123", Producto = "Camiseta Básica", Talle = "M", Cantidad = 2, PrecioUnitario = 20.00m },
                    new DetalleFactura { Codigo = "B456", Producto = "Jeans Slim Fit", Talle = "32", Cantidad = 1, PrecioUnitario = 50.00m }
                }
            };
            factura1.CalcularTotales();
            facturas.Add(factura1);

            var factura2 = new Factura
            {
                NroFactura = 13,
                Fecha = new DateTime(2023, 10, 26),
                Vendedor = "Martín Giménez",
                Cliente = "Ana Torres",
                DniCliente = "30-87654321-8",
                DireccionCliente = "Calle Falsa 123",
                ContactoCliente = "ana.torres@email.com",
                MetodoPago = "Tarjeta",
                MontoEntregado = 0,
                Detalles = new List<DetalleFactura>
                {
                    new DetalleFactura { Codigo = "A124", Producto = "Camiseta Estampada", Talle = "L", Cantidad = 3, PrecioUnitario = 25.00m }
                }
            };
            factura2.CalcularTotales();
            facturas.Add(factura2);
        }

        private void ActualizarTablaVentas()
        {
            dgvVentas.Rows.Clear();
            foreach (var factura in facturas)
            {
                dgvVentas.Rows.Add(
                    factura.NroFactura.ToString("D6"),
                    factura.Fecha.ToShortDateString(),
                    factura.Cliente,
                    factura.MetodoPago,
                    factura.Total.ToString("C", CultureInfo.CurrentCulture)
                );
            }
        }

        // Lógica de Placeholder y Filtros (sin cambios)
        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            txt.Font = new Font(txt.Font, FontStyle.Italic);
            txt.GotFocus += (s, e) =>
            {
                if (txt.ForeColor == Color.Gray)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    txt.Font = new Font(txt.Font, FontStyle.Regular);
                }
            };
            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    txt.Font = new Font(txt.Font, FontStyle.Italic);
                }
            };
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var facturasFiltradas = new List<Factura>();
            string clienteBuscado = txtBuscarCliente.Text.ToLower();
            string nroFacturaBuscado = txtBuscarNroFactura.Text.ToLower();

            foreach (var factura in facturas)
            {
                bool cumpleFiltroCliente = string.IsNullOrWhiteSpace(clienteBuscado) || factura.Cliente.ToLower().Contains(clienteBuscado);
                bool cumpleFiltroNroFactura = string.IsNullOrWhiteSpace(nroFacturaBuscado) || factura.NroFactura.ToString().Contains(nroFacturaBuscado);
                bool cumpleFiltroFecha = true;

                if (dtpFechaInicio.Checked)
                {
                    cumpleFiltroFecha = factura.Fecha.Date >= dtpFechaInicio.Value.Date;
                }
                if (dtpFechaFin.Checked && cumpleFiltroFecha)
                {
                    cumpleFiltroFecha = factura.Fecha.Date <= dtpFechaFin.Value.Date;
                }

                if (cumpleFiltroCliente && cumpleFiltroNroFactura && cumpleFiltroFecha)
                {
                    facturasFiltradas.Add(factura);
                }
            }

            dgvVentas.Rows.Clear();
            foreach (var factura in facturasFiltradas)
            {
                dgvVentas.Rows.Add(
                    factura.NroFactura.ToString("D6"),
                    factura.Fecha.ToShortDateString(),
                    factura.Cliente,
                    factura.MetodoPago,
                    factura.Total.ToString("C", CultureInfo.CurrentCulture)
                );
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Text = "Nombre o DNI del cliente";
            txtBuscarNroFactura.Text = "Número de factura";
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;
            ActualizarTablaVentas();
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nroFacturaString = dgvVentas.Rows[e.RowIndex].Cells["colNroFactura"].Value.ToString();
                int nroFactura = int.Parse(nroFacturaString);

                var facturaSeleccionada = facturas.Find(f => f.NroFactura == nroFactura);

                if (facturaSeleccionada != null)
                {
                    var formDetalleFactura = new FormVisualizarFactura(facturaSeleccionada);
                    formDetalleFactura.ShowDialog();
                }
            }
        }

        // NUEVO: Método para cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Clases de datos (sin cambios)
        public class Factura
        {
            public int NroFactura { get; set; }
            public DateTime Fecha { get; set; }
            public string Cliente { get; set; }
            public string DniCliente { get; set; }
            public string DireccionCliente { get; set; }
            public string ContactoCliente { get; set; }
            public string Vendedor { get; set; }
            public string MetodoPago { get; set; }
            public decimal MontoEntregado { get; set; }
            public decimal Vuelto { get; private set; }
            public decimal Subtotal { get; private set; }
            public decimal IVA { get; private set; }
            public decimal Total { get; private set; }
            public List<DetalleFactura> Detalles { get; set; }

            public void CalcularTotales()
            {
                Subtotal = 0;
                if (Detalles != null)
                {
                    foreach (var detalle in Detalles)
                    {
                        Subtotal += (detalle.Cantidad * detalle.PrecioUnitario);
                    }
                }
                IVA = Subtotal * 0.21m;
                Total = Subtotal + IVA;

                if (MetodoPago == "Efectivo")
                {
                    Vuelto = MontoEntregado - Total;
                }
                else
                {
                    Vuelto = 0;
                }
            }
        }

        public class DetalleFactura
        {
            public string Codigo { get; set; }
            public string Producto { get; set; }
            public string Talle { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
        }
    }
}