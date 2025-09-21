using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    // Asegúrate de que esta sea la primera clase en el archivo.
    public partial class FormDetalleFacturaGerente : Form
    {
        private FormReportesGerente.Factura facturaActual;

        public FormDetalleFacturaGerente(FormReportesGerente.Factura factura)
        {
            InitializeComponent();
            this.facturaActual = factura;
        }

        private void FormDetalleFacturaGerente_Load(object sender, EventArgs e)
        {
            // Cargar los datos de la factura en la interfaz
            CargarDatosFactura();
        }

        private void CargarDatosFactura()
        {
            if (facturaActual == null) return;

            // Actualizar la información de la factura
            lblNroFactura.Text = $"N° Factura: {facturaActual.NroFactura}";
            lblFecha.Text = $"Fecha: {facturaActual.Fecha.ToShortDateString()}";
            lblCliente.Text = $"Cliente: {facturaActual.Cliente}";
            lblVendedor.Text = $"Vendedor: {facturaActual.Vendedor}";
            lblMetodoPago.Text = $"Método de Pago: {facturaActual.MetodoPago}";

            // Llenar la tabla de productos
            dgvProductos.Rows.Clear();
            foreach (var producto in facturaActual.Productos)
            {
                dgvProductos.Rows.Add(
                    producto.Codigo,
                    producto.Nombre,
                    producto.Talle,
                    producto.Cantidad.ToString(),
                    $"${producto.Precio:N2}",
                    $"${producto.Subtotal:N2}"
                );
            }

            // Calcular y mostrar los totales
            decimal subtotal = facturaActual.Productos.Sum(p => p.Subtotal);
            decimal iva = subtotal * 0.21m; // 21% de IVA
            decimal total = subtotal + iva;

            txtSubtotal.Text = $"${subtotal:N2}";
            txtIVA.Text = $"${iva:N2}";
            txtTotal.Text = $"${total:N2}";
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulación de impresión de factura.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}