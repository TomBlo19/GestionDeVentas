using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Datos;
using Modelos;

namespace GestionDeVentas.Vendedor
{
    public partial class FormFactura : Form
    {
        private readonly FacturaDatos facturaDatos = new FacturaDatos();
        private readonly DetalleFacturaDatos detalleDatos = new DetalleFacturaDatos();
        private readonly MetodoPagoDatos metodoPagoDatos = new MetodoPagoDatos();
        private readonly ProductoDatos productoDatos = new ProductoDatos();

        private object productoSeleccionadoTmp = null;
        private int? idClienteSeleccionado = null;

        public FormFactura()
        {
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            lblFecha.Text = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
            lblVendedorActual.Text = $"Vendedor: {SesionActual.NombreCompleto}";

            CargarMetodosPago();

            txtDni.ReadOnly = txtNombre.ReadOnly = txtContacto.ReadOnly = true;
            txtBuscarCliente.ReadOnly = txtBuscarProducto.ReadOnly = true;

            pnlSeleccionProducto.Visible = false;
            SetPlaceholder(txtInfoPago, "—");

        }

        // --------------------------
        // PLACEHOLDERS
        // --------------------------
        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            txt.Font = new Font(txt.Font, FontStyle.Italic);

            txt.GotFocus += (s, ev) =>
            {
                if (txt.ForeColor == Color.Gray)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    txt.Font = new Font(txt.Font, FontStyle.Regular);
                }
            };

            txt.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    txt.Font = new Font(txt.Font, FontStyle.Italic);
                }
            };
        }

        // --------------------------
        // MÉTODOS DE PAGO
        // --------------------------
        private void CargarMetodosPago()
        {
            try
            {
                var metodos = metodoPagoDatos.ObtenerMetodosPago();
                cmbMetodoPago.DataSource = metodos;
                cmbMetodoPago.DisplayMember = "NombreMetodo";
                cmbMetodoPago.ValueMember = "IdMetodoPago";
                cmbMetodoPago.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar métodos de pago: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --------------------------
        // CLIENTE
        // --------------------------
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var frm = new BuscarClienteForm())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.ClienteSeleccionado != null)
                {
                    var c = frm.ClienteSeleccionado;
                    idClienteSeleccionado = c.Id;
                    txtBuscarCliente.Text = $"{c.Apellido}, {c.Nombre}";
                    txtDni.Text = c.Dni;
                    txtNombre.Text = $"{c.Nombre} {c.Apellido}";
                    txtContacto.Text = c.CorreoElectronico;
                }
            }
        }

        // --------------------------
        // PRODUCTO
        // --------------------------
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var frm = new BuscarProductoForm())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.ProductoSeleccionado != null)
                {
                    var p = frm.ProductoSeleccionado;
                    productoSeleccionadoTmp = p;

                    txtBuscarProducto.Text = $"{p.Nombre} | Talle: {p.TalleNombre} | Stock: {p.StockDisponible}";
                    pnlSeleccionProducto.Visible = true;
                    txtCantidadSeleccionada.Text = "1";
                    txtCantidadSeleccionada.Focus();
                }
            }
        }

        private void btnAgregarAlDetalle_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoTmp == null)
            {
                MessageBox.Show("Seleccione un producto primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic p = productoSeleccionadoTmp;

            if (!int.TryParse(txtCantidadSeleccionada.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida (>0).", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidadSeleccionada.Focus();
                return;
            }

            if (cantidad > p.StockDisponible)
            {
                MessageBox.Show($"Stock insuficiente. Disponible: {p.StockDisponible}", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Comprobar duplicado por Código
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["colCodigo"].Value?.ToString() == p.Codigo.ToString())
                {
                    MessageBox.Show("Este producto ya fue agregado al detalle.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pnlSeleccionProducto.Visible = false;
                    return;
                }
            }


            // ✅ Mostrar el Código (no el ID)
            dgvDetalle.Rows.Add(
                p.Codigo.ToString(),
                p.Nombre,
                p.TalleNombre,
                cantidad,
                p.Precio.ToString("N2"),
                (cantidad * p.Precio).ToString("C")
            );

            pnlSeleccionProducto.Visible = false;
            CalcularTotales();
        }

        private void RecalcularFila(DataGridViewRow row)
        {
            if (int.TryParse(row.Cells["colCantidad"].Value?.ToString(), out int cant) &&
                decimal.TryParse(row.Cells["colPrecio"].Value?.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precio))
            {
                row.Cells["colSubtotal"].Value = (cant * precio).ToString("C");
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != dgvDetalle.Columns["colEliminar"].Index) return;

            var fila = dgvDetalle.Rows[e.RowIndex];
            if (fila.IsNewRow || fila.Cells["colCodigo"].Value == null) return;

            dgvDetalle.Rows.RemoveAt(e.RowIndex);
            CalcularTotales();
        }

        // --------------------------
        // TOTALES
        // --------------------------
        private void CalcularTotales()
        {
            decimal subtotal = 0m;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;

                if (!int.TryParse(row.Cells["colCantidad"].Value?.ToString(), out int cant)) continue;
                if (!decimal.TryParse(row.Cells["colPrecio"].Value?.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precio)) continue;

                decimal linea = cant * precio;
                row.Cells["colSubtotal"].Value = linea.ToString("C");
                subtotal += linea;
            }

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C");
            txtIVA.Text = iva.ToString("C");
            txtTotal.Text = total.ToString("C");

            txtMontoEntregado_TextChanged(null, null);
        }

        // --------------------------
        // MÉTODO DE PAGO (UI)
        // --------------------------
        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedItem == null) return;

            string metodo = ((MetodoPago)cmbMetodoPago.SelectedItem).NombreMetodo;

            bool esEfectivo = metodo.Equals("Efectivo", StringComparison.OrdinalIgnoreCase);
            bool esTarjeta = metodo.Equals("Tarjeta", StringComparison.OrdinalIgnoreCase);
            bool esTransferencia = metodo.Equals("Transferencia", StringComparison.OrdinalIgnoreCase);

            txtMontoEntregado.Text = "";
            txtVuelto.Text = "";
            txtInfoPago.Text = "";
            txtInfoPago.ForeColor = Color.Black;

            lblMontoEntregado.Visible = esEfectivo;
            txtMontoEntregado.Visible = esEfectivo;
            lblVuelto.Visible = esEfectivo;
            txtVuelto.Visible = esEfectivo;

            lblInfoPago.Visible = esTarjeta || esTransferencia;
            txtInfoPago.Visible = esTarjeta || esTransferencia;

            if (esTarjeta)
            {
                lblInfoPago.Text = "Número de Tarjeta:";
                SetPlaceholder(txtInfoPago, "Ej.: 4567-8901-2345-6789");
            }
            else if (esTransferencia)
            {
                lblInfoPago.Text = "N°/ID de Transferencia:";
                SetPlaceholder(txtInfoPago, "Ej.: TRANS-00123 / CBU");
            }

            CalcularTotales();
        }

        // --------------------------
        // CÁLCULO DE VUELTO
        // --------------------------
        private void txtMontoEntregado_TextChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedItem == null) return;

            string metodo = ((MetodoPago)cmbMetodoPago.SelectedItem).NombreMetodo;
            if (!metodo.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
            {
                txtVuelto.Text = "";
                txtVuelto.ForeColor = Color.Black;
                return;
            }

            if (decimal.TryParse(txtTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal total) &&
                decimal.TryParse(txtMontoEntregado.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal entregado))
            {
                if (entregado < total)
                {
                    txtVuelto.ForeColor = Color.Red;
                    txtVuelto.Text = "Monto insuficiente";
                }
                else
                {
                    txtVuelto.ForeColor = Color.Black;
                    txtVuelto.Text = (entregado - total).ToString("C", CultureInfo.CurrentCulture);
                }
            }
            else
            {
                txtVuelto.Text = "";
                txtVuelto.ForeColor = Color.Black;
            }
        }

        // --------------------------
        // GENERAR FACTURA
        // --------------------------
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SesionActual.IdUsuario <= 0)
            {
                MessageBox.Show("Usuario no reconocido. Reinicie sesión.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un método de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvDetalle.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Agregue al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string metodo = ((MetodoPago)cmbMetodoPago.SelectedItem).NombreMetodo;

            if (metodo.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
            {
                if (!decimal.TryParse(txtMontoEntregado.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal entregado))
                {
                    MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal total = decimal.Parse(txtTotal.Text, NumberStyles.Currency);
                if (entregado < total)
                {
                    MessageBox.Show("El monto entregado no puede ser menor al total.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if ((metodo.Equals("Tarjeta", StringComparison.OrdinalIgnoreCase) ||
                     metodo.Equals("Transferencia", StringComparison.OrdinalIgnoreCase)) &&
                     (string.IsNullOrWhiteSpace(txtInfoPago.Text) || txtInfoPago.Text.StartsWith("Ej.:")))
            {
                MessageBox.Show($"Ingrese el dato correspondiente al método de pago ({metodo}).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var totalFactura = decimal.Parse(txtTotal.Text, NumberStyles.Currency);
                var factura = new Factura
                {
                    IdCliente = idClienteSeleccionado.Value,
                    IdUsuario = SesionActual.IdUsuario,
                    IdMetodoPago = (int)cmbMetodoPago.SelectedValue,
                    FechaFactura = DateTime.Now,
                    TotalFactura = totalFactura,
                    Activo = true
                };

                int idFactura = facturaDatos.InsertarFactura(factura);

                // 🔹 Convertir Código → Id antes de insertar detalle
                var detalles = new List<DetalleFactura>();
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    if (row.IsNewRow) continue;

                    string codigo = row.Cells["colCodigo"].Value?.ToString();
                    int idProd = productoDatos.ObtenerIdPorCodigo(codigo); // ✅ cambio
                    if (idProd == 0) continue;

                    if (!int.TryParse(row.Cells["colCantidad"].Value?.ToString(), out int cant)) continue;
                    if (!decimal.TryParse(row.Cells["colPrecio"].Value?.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precio)) continue;

                    detalles.Add(new DetalleFactura
                    {
                        IdFactura = idFactura,
                        IdProducto = idProd,
                        Cantidad = cant,
                        PrecioUnitario = precio
                    });
                }

                detalleDatos.InsertarDetalles(idFactura, detalles);

                // 🔹 Actualizar stock
                foreach (var det in detalles)
                {
                    try
                    {
                        productoDatos.ActualizarStock(det.IdProducto, det.Cantidad);
                    }
                    catch (Exception exStock)
                    {
                        MessageBox.Show($"Error al actualizar stock del producto ID {det.IdProducto}:\n{exStock.Message}",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // 🔹 Obtener datos completos de la factura recién generada
                factura.IdFactura = idFactura;
                factura.Detalles = facturaDatos.ObtenerDetallesPorFactura(idFactura);

                var facturasVendedor = facturaDatos.ObtenerFacturasPorVendedor(SesionActual.IdUsuario);
                var facturaCompleta = facturasVendedor.FirstOrDefault(f => f.IdFactura == idFactura);

                if (facturaCompleta != null)
                {
                    factura.ClienteNombre = facturaCompleta.ClienteNombre;
                    factura.ClienteDni = facturaCompleta.ClienteDni;
                    factura.ClienteDireccion = facturaCompleta.ClienteDireccion;
                    factura.ClienteTelefono = facturaCompleta.ClienteTelefono;
                    factura.ClienteCorreo = facturaCompleta.ClienteCorreo;
                    factura.UsuarioNombre = facturaCompleta.UsuarioNombre;
                    factura.MetodoPagoNombre = facturaCompleta.MetodoPagoNombre;
                }
                else
                {
                    factura.UsuarioNombre = SesionActual.NombreCompleto;
                    factura.MetodoPagoNombre = metodo;
                }

                using (var formVista = new FormVisualizarFactura(factura))
                {
                    this.Hide();
                    formVista.ShowDialog();
                    this.Show();
                }

                LimpiarPantalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarPantalla()
        {
            idClienteSeleccionado = null;
            productoSeleccionadoTmp = null;

            txtBuscarCliente.Clear();
            txtDni.Clear();
            txtNombre.Clear();
            txtContacto.Clear();
            txtBuscarProducto.Clear();

            dgvDetalle.Rows.Clear();
            txtSubtotal.Text = txtIVA.Text = txtTotal.Text = "";
            cmbMetodoPago.SelectedIndex = -1;
            pnlSeleccionProducto.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => Close();
        private void btnCerrar_Click(object sender, EventArgs e) => Close();
        private void lblVendedorActual_Click(object sender, EventArgs e) { }

        private void lblFecha_Click(object sender, EventArgs e)
        {
            lblFecha.Text = $"Fecha: {DateTime.Now:dd/MM/yyyy}";
        }
    }
}
