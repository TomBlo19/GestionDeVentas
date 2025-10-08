using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Modelos;

namespace GestionDeVentas.Vendedor
{
    public partial class FormVisualizarFactura : Form
    {
        private readonly Factura _factura;   

        public FormVisualizarFactura(Factura factura)
        {
            InitializeComponent();
            _factura = factura ?? throw new ArgumentNullException(nameof(factura));
        }

        private void FormVisualizarFactura_Load(object sender, EventArgs e)
        {
            CargarDatosFactura();
        }

        private void CargarDatosFactura()
        {
            // ========= Encabezado =========
            lblTitulo.Text = $"Factura Nº {_factura.IdFactura:D6}";
            lblFecha.Text = $"Fecha: {_factura.FechaFactura:dd/MM/yyyy}";
            lblVendedor.Text = $"Vendedor: {_factura.UsuarioNombre ?? "-"}";

            // ========= Cliente =========
            txtClienteNombre.Text = _factura.ClienteNombre ?? "-";
            txtClienteDni.Text = _factura.ClienteDni ?? "-";
            txtClienteDireccion.Text = _factura.ClienteDireccion ?? "-";

            // 👇 Mostramos teléfono + correo juntos, más claro visualmente
            if (!string.IsNullOrEmpty(_factura.ClienteTelefono) && !string.IsNullOrEmpty(_factura.ClienteCorreo))
                txtClienteContacto.Text = $"{_factura.ClienteTelefono} | {_factura.ClienteCorreo}";
            else if (!string.IsNullOrEmpty(_factura.ClienteTelefono))
                txtClienteContacto.Text = _factura.ClienteTelefono;
            else if (!string.IsNullOrEmpty(_factura.ClienteCorreo))
                txtClienteContacto.Text = _factura.ClienteCorreo;
            else
                txtClienteContacto.Text = "-";

            // ========= Detalle =========
            dgvProductos.Rows.Clear();

            if (_factura.Detalles != null && _factura.Detalles.Count > 0)
            {
                foreach (var d in _factura.Detalles)
                {
                    dgvProductos.Rows.Add(
                        d.ProductoCodigo,
                        d.ProductoNombre,
                        d.TalleNombre ?? "-", 
                        d.Cantidad,
                        d.PrecioUnitario.ToString("C", CultureInfo.CurrentCulture),
                        (d.Cantidad * d.PrecioUnitario).ToString("C", CultureInfo.CurrentCulture)
                    );
                }
            }

            // ========= Totales =========
            decimal subtotal = _factura.Detalles?.Sum(x => x.Cantidad * x.PrecioUnitario) ?? 0m;
            decimal iva = subtotal * 0.21m;
            decimal total = _factura.TotalFactura > 0 ? _factura.TotalFactura : subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C", CultureInfo.CurrentCulture);
            txtIVA.Text = iva.ToString("C", CultureInfo.CurrentCulture);
            txtTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);

            // ========= Método de pago =========
            txtMetodoPago.Text = _factura.MetodoPagoNombre ?? "-";

            // ========= Monto entregado / vuelto =========
            txtMontoEntregado.Text = "-";
            txtVuelto.Text = "-";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Eventos vacíos (requeridos por el .Designer)
        private void lblEmpresaDireccion_Click(object sender, EventArgs e) { }
        private void lblEmpresaNombre_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
