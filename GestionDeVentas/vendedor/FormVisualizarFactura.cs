using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace GestionDeVentas.Vendedor
{
    public partial class FormVisualizarFactura : Form
    {
        // La clase Factura ahora tendrá todos los detalles que necesitamos
        private readonly FormVentas.Factura _factura;

        public FormVisualizarFactura(FormVentas.Factura factura)
        {
            InitializeComponent();
            _factura = factura;
            CargarDatosFactura();
        }

        private void CargarDatosFactura()
        {
            // Títulos y datos de la factura
            lblTitulo.Text = $"Factura Nº {_factura.NroFactura.ToString("D6")}";
            lblFecha.Text = $"Fecha: {_factura.Fecha.ToShortDateString()}";
            lblVendedor.Text = $"Vendedor: {_factura.Vendedor}";

            // Datos del cliente
            txtClienteNombre.Text = _factura.Cliente;
            txtClienteDni.Text = _factura.DniCliente;
            txtClienteDireccion.Text = _factura.DireccionCliente;
            txtClienteContacto.Text = _factura.ContactoCliente;

            // Llenar el DataGridView con los productos
            dgvProductos.Rows.Clear();
            foreach (var detalle in _factura.Detalles)
            {
                dgvProductos.Rows.Add(
                    detalle.Codigo,
                    detalle.Producto,
                    detalle.Talle,
                    detalle.Cantidad,
                    detalle.PrecioUnitario.ToString("C", CultureInfo.CurrentCulture),
                    (detalle.Cantidad * detalle.PrecioUnitario).ToString("C", CultureInfo.CurrentCulture)
                );
            }

            // Totales y Método de Pago
            txtSubtotal.Text = _factura.Subtotal.ToString("C", CultureInfo.CurrentCulture);
            txtIVA.Text = _factura.IVA.ToString("C", CultureInfo.CurrentCulture);
            txtTotal.Text = _factura.Total.ToString("C", CultureInfo.CurrentCulture);
            txtMetodoPago.Text = _factura.MetodoPago;
            txtMontoEntregado.Text = _factura.MontoEntregado.ToString("C", CultureInfo.CurrentCulture);
            txtVuelto.Text = _factura.Vuelto.ToString("C", CultureInfo.CurrentCulture);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}