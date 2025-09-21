using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GestionDeVentas.Vendedor
{
    public partial class FormFactura : Form
    {
        private int numeroFactura = 12;

        private List<string> clientes = new List<string>
        {
            "35123456 - Valentina Barbero",
            "40222333 - Juan Pérez",
            "30987654 - Ana Torres",
            "29876543 - Luis Fernández"
        };

        // El vendedor se obtiene de la sesión (simulado)
        private string vendedorActual = "V001 - Tomás Bolo";

        private List<(string codigo, string nombre, string talle, decimal precio)> productos =
            new List<(string, string, string, decimal)>
        {
            ("A123", "Camiseta Básica", "M", 20.00m),
            ("A124", "Camiseta Estampada", "L", 25.00m),
            ("B456", "Jeans Slim Fit", "32", 50.00m),
            ("C789", "Campera Deportiva", "S", 80.00m)
        };

        public FormFactura()
        {
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            // Configuración inicial del formulario
            lblNroFactura.Text = $"Nº Factura: {numeroFactura.ToString("D6")}";
            lblFecha.Text = $"Fecha: {DateTime.Now.ToShortDateString()}";

            // Asignar el vendedor actual al label
            lblVendedorActual.Text = $"Vendedor: {vendedorActual}";

            // Configurar el ComboBox de Métodos de Pago
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.SelectedIndex = 0;

            // Configurar placeholders
            SetPlaceholder(txtBuscarCliente, "Buscar por nombre o DNI");
            SetPlaceholder(txtBuscarProducto, "Buscar por código o nombre");

            // Llama a la lógica de pago al iniciar
            cmbMetodoPago_SelectedIndexChanged(null, null);
        }

        // === Placeholder y Diseño ===
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

        // === Cliente ===
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (var c in clientes)
            {
                menu.Items.Add(c, null, (s, ev) =>
                {
                    txtBuscarCliente.Text = c.Split('-')[1].Trim();
                    txtBuscarCliente.ForeColor = Color.Black;

                    if (c.Contains("Valentina"))
                    {
                        txtDni.Text = "35123456";
                        txtNombre.Text = "Valentina Barbero";
                        txtDireccion.Text = "Av. Siempre Viva 742";
                        txtContacto.Text = "valentina@example.com, 555-1234";
                    }
                    else if (c.Contains("Juan Pérez"))
                    {
                        txtDni.Text = "40222333";
                        txtNombre.Text = "Juan Pérez";
                        txtDireccion.Text = "Calle San Martín 1200";
                        txtContacto.Text = "juan@example.com, 555-7890";
                    }
                });
            }
            menu.Show(btnBuscarCliente, new Point(0, btnBuscarCliente.Height));
        }

        // === Producto ===
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (var p in productos)
            {
                string item = $"{p.codigo} - {p.nombre} ({p.talle})";
                menu.Items.Add(item, null, (s, ev) =>
                {
                    dgvDetalle.Rows.Add(p.codigo, p.nombre, p.talle, 1, p.precio, p.precio);
                    CalcularTotales();
                });
            }
            menu.Show(btnBuscarProducto, new Point(0, btnBuscarProducto.Height));
        }

        // === Totales y Lógica de Pago ===
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvDetalle.Rows[e.RowIndex];

            // Validar la cantidad
            if (e.ColumnIndex == dgvDetalle.Columns["colCantidad"].Index)
            {
                if (!int.TryParse(row.Cells["colCantidad"].Value?.ToString(), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número entero mayor a 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["colCantidad"].Value = 1;
                    cantidad = 1;
                }
            }

            // Validar el precio
            if (e.ColumnIndex == dgvDetalle.Columns["colPrecio"].Index)
            {
                if (!decimal.TryParse(row.Cells["colPrecio"].Value?.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("El precio debe ser un número decimal mayor a 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var originalProduct = productos.Find(p => p.codigo == row.Cells["colCodigo"].Value.ToString());
                    row.Cells["colPrecio"].Value = originalProduct.precio;
                }
            }

            if (row.Cells["colCantidad"].Value != null && row.Cells["colPrecio"].Value != null)
            {
                int cantidad = Convert.ToInt32(row.Cells["colCantidad"].Value);
                decimal precio = Convert.ToDecimal(row.Cells["colPrecio"].Value);
                row.Cells["colSubtotal"].Value = (cantidad * precio).ToString("C", CultureInfo.CurrentCulture);
            }
            CalcularTotales();
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalle.Columns["colEliminar"].Index && e.RowIndex >= 0)
            {
                dgvDetalle.Rows.RemoveAt(e.RowIndex);
                CalcularTotales();
            }
        }

        private void txtMontoEntregado_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

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

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["colSubtotal"].Value != null && decimal.TryParse(row.Cells["colSubtotal"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal rowSubtotal))
                {
                    subtotal += rowSubtotal;
                }
            }

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C", CultureInfo.CurrentCulture);
            txtIVA.Text = iva.ToString("C", CultureInfo.CurrentCulture);
            txtTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);

            if (cmbMetodoPago.SelectedItem.ToString() == "Efectivo")
            {
                if (decimal.TryParse(txtMontoEntregado.Text, out decimal montoEntregado))
                {
                    if (montoEntregado < total)
                    {
                        txtVuelto.Text = "Monto insuficiente";
                    }
                    else
                    {
                        txtVuelto.Text = (montoEntregado - total).ToString("C", CultureInfo.CurrentCulture);
                    }
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

        // === Botones de Acción ===
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string metodoPago = cmbMetodoPago.SelectedItem.ToString();
            if (metodoPago == "Efectivo")
            {
                if (!decimal.TryParse(txtMontoEntregado.Text, out decimal montoEntregado) || montoEntregado < Convert.ToDecimal(txtTotal.Text.Replace("$", "")))
                {
                    MessageBox.Show("Debe ingresar un monto válido y suficiente para calcular el vuelto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtInfoPago.Text) || txtInfoPago.ForeColor == Color.Gray)
                {
                    MessageBox.Show($"Debe ingresar los datos de {metodoPago.ToLower()}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Factura generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}