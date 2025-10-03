using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using GestionDeVentas.Modelos; // 🔹 Para la clase Cliente
using GestionDeVentas;         // 🔹 Donde está BuscarClienteForm y BuscarProductoForm

namespace GestionDeVentas.Vendedor
{
    public partial class FormFactura : Form
    {
        private int numeroFactura = 12;
        private string vendedorActual = "V001 - Tomás Bolo";

        public FormFactura()
        {
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            lblNroFactura.Text = $"Nº Factura: {numeroFactura:D6}";
            lblFecha.Text = $"Fecha: {DateTime.Now.ToShortDateString()}";
            lblVendedorActual.Text = $"Vendedor: {vendedorActual}";

            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.SelectedIndex = 0;

            SetPlaceholder(txtInfoPago, "Número, vencimiento, CVV");

            // Campos del cliente solo lectura
            txtDni.ReadOnly = true;
            txtNombre.ReadOnly = true;
            //txtDireccion.ReadOnly = true;
            txtContacto.ReadOnly = true;
            txtBuscarCliente.ReadOnly = true;
            txtBuscarProducto.ReadOnly = true;

            cmbMetodoPago_SelectedIndexChanged(null, null);
        }

        // === Placeholders ===
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

        // ----------------------------------------------------------------------
        // Buscar Cliente
        // ----------------------------------------------------------------------
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (BuscarClienteForm buscarCliente = new BuscarClienteForm())
            {
                if (buscarCliente.ShowDialog() == DialogResult.OK)
                {
                    Cliente cliente = buscarCliente.ClienteSeleccionado; // 🔹 Es un objeto Cliente

                    if (cliente != null)
                    {
                        // Cargo los datos del cliente en los textboxes
                        txtBuscarCliente.Text = $"{cliente.Apellido}, {cliente.Nombre}";
                        txtDni.Text = cliente.Dni;
                        txtNombre.Text = $"{cliente.Nombre} {cliente.Apellido}";
                        //txtDireccion.Text = cliente.Direccion;
                        txtContacto.Text = cliente.CorreoElectronico;
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó ningún cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // ----------------------------------------------------------------------
        // Buscar Producto
        // ----------------------------------------------------------------------
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (BuscarProductoForm buscarProducto = new BuscarProductoForm())
            {
                if (buscarProducto.ShowDialog() == DialogResult.OK)
                {
                    var p = buscarProducto.ProductoSeleccionado; // 🔹 Igual que Cliente, pero con Producto

                    if (p != null)
                    {
                        string talle = (p.GetType().GetProperty("Talle") != null)
                            ? (string)p.GetType().GetProperty("Talle").GetValue(p)
                            : "N/A";

                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                        {
                            if (row.Cells["colCodigo"].Value?.ToString() == p.Id.ToString())
                            {
                                int cantidadActual = Convert.ToInt32(row.Cells["colCantidad"].Value);
                                row.Cells["colCantidad"].Value = cantidadActual + 1;
                                dgvDetalle_CellEndEdit(dgvDetalle, new DataGridViewCellEventArgs(dgvDetalle.Columns["colCantidad"].Index, row.Index));
                                return;
                            }
                        }

                        dgvDetalle.Rows.Add(
                            p.Id.ToString(),
                            p.Nombre,
                            talle,
                            1,
                            p.Precio.ToString("N2", CultureInfo.CurrentCulture),
                            p.Precio.ToString("C", CultureInfo.CurrentCulture)
                        );

                        txtBuscarProducto.Text = $"Producto cargado. Stock: {p.StockDisponible}";
                        CalcularTotales();
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó ningún producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // === Calcular totales ===
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvDetalle.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvDetalle.Columns["colCantidad"].Index)
            {
                if (!int.TryParse(row.Cells["colCantidad"].Value?.ToString(), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["colCantidad"].Value = 1;
                }
            }

            if (row.Cells["colCantidad"].Value != null && row.Cells["colPrecio"].Value != null)
            {
                int cantidad = Convert.ToInt32(row.Cells["colCantidad"].Value);
                decimal.TryParse(row.Cells["colPrecio"].Value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, ""), out decimal precio);
                row.Cells["colSubtotal"].Value = (cantidad * precio).ToString("C", CultureInfo.CurrentCulture);
            }

            CalcularTotales();
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0
                && e.ColumnIndex == dgvDetalle.Columns["colEliminar"].Index
                && !dgvDetalle.Rows[e.RowIndex].IsNewRow)
            {
                dgvDetalle.Rows.RemoveAt(e.RowIndex);
                CalcularTotales();
            }
        }

        private void txtMontoEntregado_TextChanged(object sender, EventArgs e) => CalcularTotales();

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodoSeleccionado = cmbMetodoPago.SelectedItem.ToString();
            bool esEfectivo = metodoSeleccionado == "Efectivo";

            lblMontoEntregado.Visible = esEfectivo;
            txtMontoEntregado.Visible = esEfectivo;
            lblVuelto.Visible = esEfectivo;
            txtVuelto.Visible = esEfectivo;

            lblInfoPago.Visible = !esEfectivo;
            txtInfoPago.Visible = !esEfectivo;

            if (metodoSeleccionado == "Tarjeta")
            {
                lblInfoPago.Text = "Datos de Tarjeta:";
                SetPlaceholder(txtInfoPago, "Número, vencimiento, CVV");
            }
            else if (metodoSeleccionado == "Transferencia")
            {
                lblInfoPago.Text = "Datos de Transferencia:";
                SetPlaceholder(txtInfoPago, "Nº de Referencia / ID de Transacción");
            }

            if (!esEfectivo) txtMontoEntregado.Text = "";
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (!row.IsNewRow && row.Cells["colSubtotal"].Value != null)
                {
                    string subtotalStr = row.Cells["colSubtotal"].Value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "").Trim();
                    if (decimal.TryParse(subtotalStr, NumberStyles.Number | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out decimal rowSubtotal))
                        subtotal += rowSubtotal;
                }
            }

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C", CultureInfo.CurrentCulture);
            txtIVA.Text = iva.ToString("C", CultureInfo.CurrentCulture);
            txtTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);

            if (cmbMetodoPago.SelectedItem?.ToString() == "Efectivo")
            {
                if (decimal.TryParse(txtMontoEntregado.Text, out decimal montoEntregado))
                {
                    txtVuelto.Text = montoEntregado < total ? "Monto insuficiente" : (montoEntregado - total).ToString("C", CultureInfo.CurrentCulture);
                    txtVuelto.ForeColor = montoEntregado < total ? Color.Red : Color.Black;
                }
                else
                {
                    txtVuelto.Text = "";
                }
            }
            else
            {
                txtVuelto.Text = "";
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0 || (dgvDetalle.Rows.Count == 1 && dgvDetalle.Rows[0].IsNewRow))
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Factura generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            numeroFactura++;
            FormFactura_Load(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}
