using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Modelos; // ✅ Agregado para que reconozca la clase Factura real

namespace GestionDeVentas.Gerente
{
    public partial class FormDetalleFacturaGerente : Form
    {
        // ✅ Cambiado para usar el modelo de Factura real
        private readonly Factura _facturaActual;

        // ✅ Cambiado para recibir el modelo de Factura real
        public FormDetalleFacturaGerente(Factura factura)
        {
            InitializeComponent();
            _facturaActual = factura ?? throw new ArgumentNullException(nameof(factura));
        }

        private void FormDetalleFacturaGerente_Load(object sender, EventArgs e)
        {
            CargarDatosFactura();
        }

        private void CargarDatosFactura()
        {
            if (_facturaActual == null) return;

            // ✅ Actualizado para usar las propiedades del modelo real
            lblNroFactura.Text = $"N° Factura: {_facturaActual.IdFactura:D6}";
            lblFecha.Text = $"Fecha: {_facturaActual.FechaFactura:dd/MM/yyyy}";
            lblCliente.Text = $"Cliente: {_facturaActual.ClienteNombre}";
            lblVendedor.Text = $"Vendedor: {_facturaActual.UsuarioNombre}";
            lblMetodoPago.Text = $"Método de Pago: {_facturaActual.MetodoPagoNombre}";

            // Llenar la tabla de productos usando la lista de Detalles
            dgvProductos.Rows.Clear();
            if (_facturaActual.Detalles != null)
            {
                foreach (var detalle in _facturaActual.Detalles)
                {
                    dgvProductos.Rows.Add(
                        detalle.ProductoCodigo,
                        detalle.ProductoNombre,
                        detalle.TalleNombre ?? "-",
                        detalle.Cantidad,
                        detalle.PrecioUnitario.ToString("C", CultureInfo.CurrentCulture),
                        (detalle.Cantidad * detalle.PrecioUnitario).ToString("C", CultureInfo.CurrentCulture)
                    );
                }
            }

            // Calcular y mostrar los totales
            decimal subtotal = _facturaActual.Detalles?.Sum(p => p.Cantidad * p.PrecioUnitario) ?? 0m;
            decimal iva = subtotal * 0.21m; // 21% de IVA

            // Usamos el total guardado en la factura para mayor precisión
            decimal total = _facturaActual.TotalFactura;

            txtSubtotal.Text = subtotal.ToString("C", CultureInfo.CurrentCulture);
            txtIVA.Text = iva.ToString("C", CultureInfo.CurrentCulture);
            txtTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulación de impresión de factura.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}